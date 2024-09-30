using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UserManagementApp.Areas.Identity.Data;
using UserManagementApp.Models;

namespace UserManagementApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser>userManager)
        {
            _logger = logger;
            this._userManager = userManager;
        }

        public IActionResult Index()
        {
            //ViewData["UserID"] = _userManager.GetUserId(this.User);
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

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        //[HttpPost]
        //public async Task<IActionResult> Delete(ApplicationUser viewModel)
        //{
        //    var users = await _userManager.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);
        //    if (users is not null)
        //    {
        //        _userManager.Users.remove(viewModel);
        //        await _userManager.SaveChangesAsync();
        //    }

        //    return RedirectToAction("List", "Home");
        //}


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            // Find the user by their ID.
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                // Delete the user using UserManager's DeleteAsync method.
                var result = await _userManager.DeleteAsync(user);

                // Check if the deletion was successful.
                if (result.Succeeded)
                {
                    return RedirectToAction("List", "Home");
                }
                else
                {
                    // Handle any errors here (e.g., log them or show a message to the user).
                    ModelState.AddModelError("", "Error deleting user");
                }
            }
            else
            {
                ModelState.AddModelError("", "User not found");
            }

            // If there's an issue, return to the list page with the error messages.
            var users = await _userManager.Users.ToListAsync();
            return View("List", users);
        }

        [HttpPost]
        public async Task<IActionResult> Block(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Status = "Blocked";
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("List");
                }
                ModelState.AddModelError("", "Error blocking user");
            }
            else
            {
                ModelState.AddModelError("", "User not found");
            }

            var users = await _userManager.Users.ToListAsync();
            return View("List", users);
        }

        [HttpPost]
        public async Task<IActionResult> Active(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Status = "Active";
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("List");
                }
                ModelState.AddModelError("", "Error activating user");
            }
            else
            {
                ModelState.AddModelError("", "User not found");
            }

            var users = await _userManager.Users.ToListAsync();
            return View("List", users);
        }

    }
}
