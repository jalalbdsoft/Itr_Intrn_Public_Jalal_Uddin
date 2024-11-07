using CustomisableFormsApp.Data;
using CustomisableFormsApp.Models;
using CustomisableFormsApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CustomisableFormsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SalesforceService _salesforceService;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager, SalesforceService salesforceService)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _salesforceService = salesforceService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //UserList Portion

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UserList()
        {
            // Fetch users directly from ApplicationDbContext to include custom fields
            var usersWithRoles = await _context.Users.OfType<ApplicationUser>()
               .Select(user => new ApplicationUser
               {
                   Id = user.Id,
                   Name = user.Name,
                   Email = user.Email,
                   PhoneNumber = user.PhoneNumber,
                   RegistrationTime = user.RegistrationTime,
                   LastLoginTime = user.LastLoginTime,
                   Status = user.Status,
                   Roles = (from userRole in _context.UserRoles
                            join role in _context.Roles on userRole.RoleId equals role.Id
                            where userRole.UserId == user.Id
                            select role.Name).ToList()
               }).ToListAsync();
            return View(usersWithRoles);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            // Find the user by their ID in the database.
            var user = await _context.Users.OfType<ApplicationUser>().FirstOrDefaultAsync(u => u.Id == id);

            if (user != null)
            {
                // Delete related Templates entries for the user
                var templates = _context.Templates.Where(t => t.USER_ID == id || t.USER_ID_CANDIDATE == id);
                _context.Templates.RemoveRange(templates);

                // Remove the user from the database.
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                // Redirect to the UserList action if deletion is successful.
                TempData["success"] = "User deleted successfully";
                return RedirectToAction("UserList");
            }
            else
            {
                // Handle case where user is not found.
                ModelState.AddModelError("", "User not found");
            }

            // Reload the user list and return to the UserList view with error messages if any.
            var users = await _context.Users.OfType<ApplicationUser>().ToListAsync();
            return View("UserList", users);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Block(string id)
        {
            // Find the user by their ID in the database.
            var user = await _context.Users.OfType<ApplicationUser>().FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                // Set the user's status to "Blocked".
                user.Status = "Blocked";
                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                // Redirect to the List action if update is successful.
                TempData["success"] = "User Blocked successfully";
                return RedirectToAction("UserList");
            }
            else
            {
                // Handle case where user is not found.
                ModelState.AddModelError("", "User not found");
            }

            // Reload the user list and return to the UserList view with error messages if any.
            var users = await _context.Users.OfType<ApplicationUser>().ToListAsync();
            return View("UserList", users);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Active(string id)
        {
            // Find the user by their ID in the database.
            var user = await _context.Users.OfType<ApplicationUser>().FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                // Set the user's status to "Active".
                user.Status = "Active";
                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                // Redirect to the List action if update is successful.
                TempData["success"] = "User Activated successfully";
                return RedirectToAction("UserList");
            }
            else
            {
                // Handle case where user is not found.
                ModelState.AddModelError("", "User not found");
            }

            // Reload the user list and return to the UserList view with error messages if any.
            var users = await _context.Users.OfType<ApplicationUser>().ToListAsync();
            return View("UserList", users);
        }

        // Add User to Admin Role
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddtoAdmin(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return RedirectToAction("UserList");
            }

            var result = await _userManager.AddToRoleAsync(user, "Admin");
            if (result.Succeeded)
            {
                TempData["success"] = "User promoted to Admin successfully";
            }
            else
            {
                TempData["error"] = "Failed to promote user to Admin";
            }

            return RedirectToAction("UserList");
        }

        // Remove User from Admin Role
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemovefromAdmin(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return RedirectToAction("UserList");
            }

            var result = await _userManager.RemoveFromRoleAsync(user, "Admin");
            if (result.Succeeded)
            {
                TempData["success"] = "User removed from Admin successfully";
            }
            else
            {
                TempData["error"] = "Failed to remove user from Admin";
            }

            return RedirectToAction("UserList");
        }

        // Salesforce Portion
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateSalesforceAccount(string userId)
        {
            var user = _context.Users.OfType<ApplicationUser>().FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                TempData["error"] = "User not found";
                return RedirectToAction("UserList");
            }

            return View(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateSalesforceAccountPost(string USERID, string PhoneNumber)
        {
            var user = await _context.Users.OfType<ApplicationUser>().FirstOrDefaultAsync(u => u.Id == USERID);
            if (user == null)
            {
                TempData["error"] = "User not found";
                return RedirectToAction("UserList");
            }

            var accessToken = await _salesforceService.Authenticate();
            bool isSuccess = await _salesforceService.CreateAccount(user.Name, PhoneNumber ?? user.PhoneNumber, accessToken);

            //TempData[isSuccess ? "success" : "error"] = isSuccess ? "Account created in Salesforce successfully." : "Failed to create account in Salesforce.";

            if (isSuccess)
            {
                TempData["success"] = "Account created in Salesforce successfully.";
            }
            else
            {
                TempData["error"] = "Failed to create account in Salesforce.";
            }
            return RedirectToAction("UserList");
        }
    }
}