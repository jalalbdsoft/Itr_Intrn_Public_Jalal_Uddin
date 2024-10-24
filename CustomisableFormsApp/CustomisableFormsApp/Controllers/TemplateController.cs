using CustomisableFormsApp.Data;
using CustomisableFormsApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CustomisableFormsApp.Controllers
{
    public class TemplateController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        public TemplateController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Index()
        {         
            if (User.IsInRole("Candidate") || User.IsInRole("Explorer"))
            {
                var applicationDbContext = _db.Templates.Include(d => d.User);
                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                var applicationDbContext = from c in _db.Templates
                                           select c;
                applicationDbContext = applicationDbContext.Where(a => a.USER_ID == User.FindFirstValue(ClaimTypes.NameIdentifier));
                return View(await applicationDbContext.Include(d => d.User).ToListAsync());
            }
        }

        [Authorize(Roles ="Admin, User")]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Create(Template obj)
        {
            if (ModelState.IsValid)
            {
                _db.Templates.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Form created successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            ///////////GET CANDIDATE EMAIL/////////
            var template = _db.Templates.Include(t => t.User_CANDIDATE).FirstOrDefault(t => t.ID == id);

            if (template == null)
            {
                return NotFound();
            }

            // Check if the user is logged in
            if (template.User_CANDIDATE != null && User.Identity != null && User.Identity.IsAuthenticated)
            {
                ViewData["UserEmail"] = template.User_CANDIDATE.Email;
            }
            else
            {
                ViewData["UserEmail"] = "None";
            }
            ///////////---GET CANDIDATE EMAIL---/////////

            if (id == null || id == 0)
            {
                return NotFound();
            }
            Template? TemplateFromDb = _db.Templates.Find(id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

            if (TemplateFromDb == null)
            {
                return NotFound();
            }
            return View(TemplateFromDb);
        }

        [HttpPost]
        //public IActionResult Edit(Template obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Templates.Update(obj);
        //        _db.SaveChanges();
        //        TempData["success"] = "Form updated successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View();

        //}

        public IActionResult Edit(Template obj)
        {
            if (User.IsInRole("Admin") || User.IsInRole("User"))
            {
                var template = _db.Templates.Find(obj.ID);
                if (template is not null)
                {
                    template.TITLE = obj.TITLE;
                    template.DESCRIPTION = obj.DESCRIPTION;

                    template.CUSTOM_STRING1_QUESTION = obj.CUSTOM_STRING1_QUESTION;
                    template.CUSTOM_STRING1_ANSWER = obj.CUSTOM_STRING1_ANSWER;
                    template.CUSTOM_STRING2_QUESTION = obj.CUSTOM_STRING2_QUESTION;
                    template.CUSTOM_STRING2_ANSWER = obj.CUSTOM_STRING2_ANSWER;
                    template.CUSTOM_STRING3_QUESTION = obj.CUSTOM_STRING3_QUESTION;
                    template.CUSTOM_STRING3_ANSWER = obj.CUSTOM_STRING3_ANSWER;
                    template.CUSTOM_STRING4_QUESTION = obj.CUSTOM_STRING4_QUESTION;
                    template.CUSTOM_STRING4_ANSWER = obj.CUSTOM_STRING4_ANSWER;

                    _db.SaveChanges();
                    //return RedirectToAction("Index");
                }
            }
            else if (User.IsInRole("Candidate"))
            {
                var template = _db.Templates.Find(obj.ID);
                if (template is not null)
                {
                    //template.TITLE = obj.TITLE;
                    //template.DESCRIPTION = obj.DESCRIPTION;
                    template.USER_ID_CANDIDATE = obj.USER_ID_CANDIDATE;
                    //template.CUSTOM_STRING1_QUESTION = obj.CUSTOM_STRING1_QUESTION;
                    template.CUSTOM_STRING1_ANSWER = obj.CUSTOM_STRING1_ANSWER;
                    //template.CUSTOM_STRING2_QUESTION = obj.CUSTOM_STRING2_QUESTION;
                    template.CUSTOM_STRING2_ANSWER = obj.CUSTOM_STRING2_ANSWER;
                    //template.CUSTOM_STRING3_QUESTION = obj.CUSTOM_STRING3_QUESTION;
                    template.CUSTOM_STRING3_ANSWER = obj.CUSTOM_STRING3_ANSWER;
                    //template.CUSTOM_STRING4_QUESTION = obj.CUSTOM_STRING4_QUESTION;
                    template.CUSTOM_STRING4_ANSWER = obj.CUSTOM_STRING4_ANSWER;

                    _db.SaveChanges();
                    //return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Delete(int? id)
        {

            Template? obj = _db.Templates.Where(u => u.ID == id).FirstOrDefault();
            if (obj == null)
            {
                return NotFound();
            }
            _db.Templates.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Template deleted successfully";
            return RedirectToAction("Index");
        }        
    }
}
