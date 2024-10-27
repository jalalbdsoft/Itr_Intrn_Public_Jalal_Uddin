using CustomisableFormsApp.Data;
using CustomisableFormsApp.Models;
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
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
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
    }
}
