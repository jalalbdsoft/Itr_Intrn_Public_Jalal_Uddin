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
            if (User.IsInRole("Candidate") || User.IsInRole("Creator"))
            {
                var applicationDbContext = from c in _db.Templates
                                           select c;
                applicationDbContext = applicationDbContext.Where(a => a.USER_ID == User.FindFirstValue(ClaimTypes.NameIdentifier));
                return View(await applicationDbContext.Include(d => d.User).ToListAsync());
            }
            else
            {
                var applicationDbContext = _db.Templates.Include(d => d.User);
                return View(await applicationDbContext.ToListAsync());
            }
        }

        [Authorize(Roles = "Admin, Creator")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Creator")]
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
            ///////////GET CANDIDATE NAME/////////
            var template = _db.Templates.Include(t => t.User_CANDIDATE).FirstOrDefault(t => t.ID == id);

            if (template == null)
            {
                return NotFound();
            }

            // Check if the user is logged in
            if (template.User_CANDIDATE != null && User.Identity != null && User.Identity.IsAuthenticated)
            {
                ViewData["UserName"] = template.User_CANDIDATE.UserName;
            }
            else
            {
                ViewData["UserName"] = "None";
            }
            ///////////---GET CANDIDATE NAME---/////////

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
        [Authorize(Roles = "Admin, Creator, Candidate")]
        public IActionResult Edit(Template obj, IFormCollection form)
        {
            if (User.IsInRole("Admin"))
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
                    template.CUSTOM_STRING5_QUESTION = obj.CUSTOM_STRING5_QUESTION;
                    template.CUSTOM_STRING5_ANSWER = obj.CUSTOM_STRING5_ANSWER;
                    template.CUSTOM_STRING6_QUESTION = obj.CUSTOM_STRING6_QUESTION;
                    template.CUSTOM_STRING6_ANSWER = obj.CUSTOM_STRING6_ANSWER;
                    template.CUSTOM_STRING7_QUESTION = obj.CUSTOM_STRING7_QUESTION;
                    template.CUSTOM_STRING7_ANSWER = obj.CUSTOM_STRING7_ANSWER;
                    template.CUSTOM_STRING8_QUESTION = obj.CUSTOM_STRING8_QUESTION;
                    template.CUSTOM_STRING8_ANSWER = obj.CUSTOM_STRING8_ANSWER;
                    template.CUSTOM_STRING9_QUESTION = obj.CUSTOM_STRING9_QUESTION;
                    template.CUSTOM_STRING9_ANSWER = obj.CUSTOM_STRING9_ANSWER;
                    template.CUSTOM_STRING10_QUESTION = obj.CUSTOM_STRING10_QUESTION;
                    template.CUSTOM_STRING10_ANSWER = obj.CUSTOM_STRING10_ANSWER;
                    template.CUSTOM_STRING11_QUESTION = obj.CUSTOM_STRING11_QUESTION;
                    template.CUSTOM_STRING11_ANSWER = obj.CUSTOM_STRING11_ANSWER;
                    template.CUSTOM_STRING12_QUESTION = obj.CUSTOM_STRING12_QUESTION;
                    template.CUSTOM_STRING12_ANSWER = obj.CUSTOM_STRING12_ANSWER;
                    template.CUSTOM_STRING13_QUESTION = obj.CUSTOM_STRING13_QUESTION;
                    template.CUSTOM_STRING13_ANSWER = obj.CUSTOM_STRING13_ANSWER;
                    template.CUSTOM_STRING14_QUESTION = obj.CUSTOM_STRING14_QUESTION;
                    template.CUSTOM_STRING14_ANSWER = obj.CUSTOM_STRING14_ANSWER;
                    template.CUSTOM_STRING15_QUESTION = obj.CUSTOM_STRING15_QUESTION;
                    template.CUSTOM_STRING15_ANSWER = obj.CUSTOM_STRING15_ANSWER;
                    template.CUSTOM_STRING16_QUESTION = obj.CUSTOM_STRING16_QUESTION;
                    template.CUSTOM_STRING16_ANSWER = obj.CUSTOM_STRING16_ANSWER;
                    template.CUSTOM_STRING17_QUESTION = obj.CUSTOM_STRING17_QUESTION;
                    template.CUSTOM_STRING17_ANSWER = obj.CUSTOM_STRING17_ANSWER;
                    template.CUSTOM_STRING18_QUESTION = obj.CUSTOM_STRING18_QUESTION;
                    template.CUSTOM_STRING18_ANSWER = obj.CUSTOM_STRING18_ANSWER;
                    template.CUSTOM_STRING19_QUESTION = obj.CUSTOM_STRING19_QUESTION;
                    template.CUSTOM_STRING19_ANSWER = obj.CUSTOM_STRING19_ANSWER;
                    template.CUSTOM_STRING20_QUESTION = obj.CUSTOM_STRING20_QUESTION;
                    template.CUSTOM_STRING20_ANSWER = obj.CUSTOM_STRING20_ANSWER;
                    template.CUSTOM_STRING21_QUESTION = obj.CUSTOM_STRING21_QUESTION;
                    template.CUSTOM_STRING21_ANSWER = obj.CUSTOM_STRING21_ANSWER;
                    template.CUSTOM_STRING22_QUESTION = obj.CUSTOM_STRING22_QUESTION;
                    template.CUSTOM_STRING22_ANSWER = obj.CUSTOM_STRING22_ANSWER;
                    template.CUSTOM_STRING23_QUESTION = obj.CUSTOM_STRING23_QUESTION;
                    template.CUSTOM_STRING23_ANSWER = obj.CUSTOM_STRING23_ANSWER;
                    template.CUSTOM_STRING24_QUESTION = obj.CUSTOM_STRING24_QUESTION;
                    template.CUSTOM_STRING24_ANSWER = obj.CUSTOM_STRING24_ANSWER;
                    template.CUSTOM_STRING25_QUESTION = obj.CUSTOM_STRING25_QUESTION;
                    template.CUSTOM_STRING25_ANSWER = obj.CUSTOM_STRING25_ANSWER;
                    template.CUSTOM_STRING26_QUESTION = obj.CUSTOM_STRING26_QUESTION;
                    template.CUSTOM_STRING26_ANSWER = obj.CUSTOM_STRING26_ANSWER;
                    template.CUSTOM_STRING27_QUESTION = obj.CUSTOM_STRING27_QUESTION;
                    template.CUSTOM_STRING27_ANSWER = obj.CUSTOM_STRING27_ANSWER;
                    template.CUSTOM_STRING28_QUESTION = obj.CUSTOM_STRING28_QUESTION;
                    template.CUSTOM_STRING28_ANSWER = obj.CUSTOM_STRING28_ANSWER;
                    template.CUSTOM_STRING29_QUESTION = obj.CUSTOM_STRING29_QUESTION;
                    template.CUSTOM_STRING29_ANSWER = obj.CUSTOM_STRING29_ANSWER;
                    template.CUSTOM_STRING30_QUESTION = obj.CUSTOM_STRING30_QUESTION;
                    template.CUSTOM_STRING30_ANSWER = obj.CUSTOM_STRING30_ANSWER;
                    template.CUSTOM_STRING31_QUESTION = obj.CUSTOM_STRING31_QUESTION;
                    template.CUSTOM_STRING31_ANSWER = obj.CUSTOM_STRING31_ANSWER;
                    template.CUSTOM_STRING32_QUESTION = obj.CUSTOM_STRING32_QUESTION;
                    template.CUSTOM_STRING32_ANSWER = obj.CUSTOM_STRING32_ANSWER;
                    template.CUSTOM_STRING33_QUESTION = obj.CUSTOM_STRING33_QUESTION;
                    template.CUSTOM_STRING33_ANSWER = obj.CUSTOM_STRING33_ANSWER;
                    template.CUSTOM_STRING34_QUESTION = obj.CUSTOM_STRING34_QUESTION;
                    template.CUSTOM_STRING34_ANSWER = obj.CUSTOM_STRING34_ANSWER;
                    template.CUSTOM_STRING35_QUESTION = obj.CUSTOM_STRING35_QUESTION;
                    template.CUSTOM_STRING35_ANSWER = obj.CUSTOM_STRING35_ANSWER;
                    template.CUSTOM_STRING36_QUESTION = obj.CUSTOM_STRING36_QUESTION;
                    template.CUSTOM_STRING36_ANSWER = obj.CUSTOM_STRING36_ANSWER;
                    template.CUSTOM_STRING37_QUESTION = obj.CUSTOM_STRING37_QUESTION;
                    template.CUSTOM_STRING37_ANSWER = obj.CUSTOM_STRING37_ANSWER;
                    template.CUSTOM_STRING38_QUESTION = obj.CUSTOM_STRING38_QUESTION;
                    template.CUSTOM_STRING38_ANSWER = obj.CUSTOM_STRING38_ANSWER;
                    template.CUSTOM_STRING39_QUESTION = obj.CUSTOM_STRING39_QUESTION;
                    template.CUSTOM_STRING39_ANSWER = obj.CUSTOM_STRING39_ANSWER;
                    template.CUSTOM_STRING40_QUESTION = obj.CUSTOM_STRING40_QUESTION;
                    template.CUSTOM_STRING40_ANSWER = obj.CUSTOM_STRING40_ANSWER;
                    template.CUSTOM_STRING41_QUESTION = obj.CUSTOM_STRING41_QUESTION;
                    template.CUSTOM_STRING41_ANSWER = obj.CUSTOM_STRING41_ANSWER;
                    template.CUSTOM_STRING42_QUESTION = obj.CUSTOM_STRING42_QUESTION;
                    template.CUSTOM_STRING42_ANSWER = obj.CUSTOM_STRING42_ANSWER;
                    template.CUSTOM_STRING43_QUESTION = obj.CUSTOM_STRING43_QUESTION;
                    template.CUSTOM_STRING43_ANSWER = obj.CUSTOM_STRING43_ANSWER;
                    template.CUSTOM_STRING44_QUESTION = obj.CUSTOM_STRING44_QUESTION;
                    template.CUSTOM_STRING44_ANSWER = obj.CUSTOM_STRING44_ANSWER;
                    template.CUSTOM_STRING45_QUESTION = obj.CUSTOM_STRING45_QUESTION;
                    template.CUSTOM_STRING45_ANSWER = obj.CUSTOM_STRING45_ANSWER;
                    template.CUSTOM_STRING46_QUESTION = obj.CUSTOM_STRING46_QUESTION;
                    template.CUSTOM_STRING46_ANSWER = obj.CUSTOM_STRING46_ANSWER;
                    template.CUSTOM_STRING47_QUESTION = obj.CUSTOM_STRING47_QUESTION;
                    template.CUSTOM_STRING47_ANSWER = obj.CUSTOM_STRING47_ANSWER;
                    template.CUSTOM_STRING48_QUESTION = obj.CUSTOM_STRING48_QUESTION;
                    template.CUSTOM_STRING48_ANSWER = obj.CUSTOM_STRING48_ANSWER;
                    template.CUSTOM_STRING49_QUESTION = obj.CUSTOM_STRING49_QUESTION;
                    template.CUSTOM_STRING49_ANSWER = obj.CUSTOM_STRING49_ANSWER;
                    template.CUSTOM_STRING50_QUESTION = obj.CUSTOM_STRING50_QUESTION;
                    template.CUSTOM_STRING50_ANSWER = obj.CUSTOM_STRING50_ANSWER;

                    _db.SaveChanges();
                    TempData["success"] = "Form updated successfully";
                    //return RedirectToAction("Index");
                }
            }

            else if (User.IsInRole("Creator"))
            {
                var template = _db.Templates.Find(obj.ID);

                // Get the logged-in user's ID
                var loggedinuserid = _userManager.GetUserId(User);

                if (template is not null)
                {
                    if (template.USER_ID == loggedinuserid)
                    {
                        if (template.USER_ID_CANDIDATE is null)
                        {
                            template.TITLE = obj.TITLE;
                            template.DESCRIPTION = obj.DESCRIPTION;

                            //This code also works

                            //template.CUSTOM_STRING1_QUESTION = obj.CUSTOM_STRING1_QUESTION;
                            //template.CUSTOM_STRING1_ANSWER = obj.CUSTOM_STRING1_ANSWER;
                            //template.CUSTOM_STRING2_QUESTION = obj.CUSTOM_STRING2_QUESTION;
                            //template.CUSTOM_STRING2_ANSWER = obj.CUSTOM_STRING2_ANSWER;
                            //template.CUSTOM_STRING3_QUESTION = obj.CUSTOM_STRING3_QUESTION;
                            //template.CUSTOM_STRING3_ANSWER = obj.CUSTOM_STRING3_ANSWER;
                            //template.CUSTOM_STRING4_QUESTION = obj.CUSTOM_STRING4_QUESTION;
                            //template.CUSTOM_STRING4_ANSWER = obj.CUSTOM_STRING4_ANSWER;
                            //template.CUSTOM_STRING5_QUESTION = obj.CUSTOM_STRING5_QUESTION;
                            //template.CUSTOM_STRING5_ANSWER = obj.CUSTOM_STRING5_ANSWER;
                            //template.CUSTOM_STRING6_QUESTION = obj.CUSTOM_STRING6_QUESTION;
                            //template.CUSTOM_STRING6_ANSWER = obj.CUSTOM_STRING6_ANSWER;
                            //template.CUSTOM_STRING7_QUESTION = obj.CUSTOM_STRING7_QUESTION;
                            //template.CUSTOM_STRING7_ANSWER = obj.CUSTOM_STRING7_ANSWER;
                            //template.CUSTOM_STRING8_QUESTION = obj.CUSTOM_STRING8_QUESTION;
                            //template.CUSTOM_STRING8_ANSWER = obj.CUSTOM_STRING8_ANSWER;
                            //template.CUSTOM_STRING9_QUESTION = obj.CUSTOM_STRING9_QUESTION;
                            //template.CUSTOM_STRING9_ANSWER = obj.CUSTOM_STRING9_ANSWER;
                            //template.CUSTOM_STRING10_QUESTION = obj.CUSTOM_STRING10_QUESTION;
                            //template.CUSTOM_STRING10_ANSWER = obj.CUSTOM_STRING10_ANSWER;
                            //template.CUSTOM_STRING11_QUESTION = obj.CUSTOM_STRING11_QUESTION;
                            //template.CUSTOM_STRING11_ANSWER = obj.CUSTOM_STRING11_ANSWER;
                            //template.CUSTOM_STRING12_QUESTION = obj.CUSTOM_STRING12_QUESTION;
                            //template.CUSTOM_STRING12_ANSWER = obj.CUSTOM_STRING12_ANSWER;
                            //template.CUSTOM_STRING13_QUESTION = obj.CUSTOM_STRING13_QUESTION;
                            //template.CUSTOM_STRING13_ANSWER = obj.CUSTOM_STRING13_ANSWER;
                            //template.CUSTOM_STRING14_QUESTION = obj.CUSTOM_STRING14_QUESTION;
                            //template.CUSTOM_STRING14_ANSWER = obj.CUSTOM_STRING14_ANSWER;
                            //template.CUSTOM_STRING15_QUESTION = obj.CUSTOM_STRING15_QUESTION;
                            //template.CUSTOM_STRING15_ANSWER = obj.CUSTOM_STRING15_ANSWER;
                            //template.CUSTOM_STRING16_QUESTION = obj.CUSTOM_STRING16_QUESTION;
                            //template.CUSTOM_STRING16_ANSWER = obj.CUSTOM_STRING16_ANSWER;
                            //template.CUSTOM_STRING17_QUESTION = obj.CUSTOM_STRING17_QUESTION;
                            //template.CUSTOM_STRING17_ANSWER = obj.CUSTOM_STRING17_ANSWER;
                            //template.CUSTOM_STRING18_QUESTION = obj.CUSTOM_STRING18_QUESTION;
                            //template.CUSTOM_STRING18_ANSWER = obj.CUSTOM_STRING18_ANSWER;
                            //template.CUSTOM_STRING19_QUESTION = obj.CUSTOM_STRING19_QUESTION;
                            //template.CUSTOM_STRING19_ANSWER = obj.CUSTOM_STRING19_ANSWER;
                            //template.CUSTOM_STRING20_QUESTION = obj.CUSTOM_STRING20_QUESTION;
                            //template.CUSTOM_STRING20_ANSWER = obj.CUSTOM_STRING20_ANSWER;
                            //template.CUSTOM_STRING21_QUESTION = obj.CUSTOM_STRING21_QUESTION;
                            //template.CUSTOM_STRING21_ANSWER = obj.CUSTOM_STRING21_ANSWER;
                            //template.CUSTOM_STRING22_QUESTION = obj.CUSTOM_STRING22_QUESTION;
                            //template.CUSTOM_STRING22_ANSWER = obj.CUSTOM_STRING22_ANSWER;
                            //template.CUSTOM_STRING23_QUESTION = obj.CUSTOM_STRING23_QUESTION;
                            //template.CUSTOM_STRING23_ANSWER = obj.CUSTOM_STRING23_ANSWER;
                            //template.CUSTOM_STRING24_QUESTION = obj.CUSTOM_STRING24_QUESTION;
                            //template.CUSTOM_STRING24_ANSWER = obj.CUSTOM_STRING24_ANSWER;
                            //template.CUSTOM_STRING25_QUESTION = obj.CUSTOM_STRING25_QUESTION;
                            //template.CUSTOM_STRING25_ANSWER = obj.CUSTOM_STRING25_ANSWER;
                            //template.CUSTOM_STRING26_QUESTION = obj.CUSTOM_STRING26_QUESTION;
                            //template.CUSTOM_STRING26_ANSWER = obj.CUSTOM_STRING26_ANSWER;
                            //template.CUSTOM_STRING27_QUESTION = obj.CUSTOM_STRING27_QUESTION;
                            //template.CUSTOM_STRING27_ANSWER = obj.CUSTOM_STRING27_ANSWER;
                            //template.CUSTOM_STRING28_QUESTION = obj.CUSTOM_STRING28_QUESTION;
                            //template.CUSTOM_STRING28_ANSWER = obj.CUSTOM_STRING28_ANSWER;
                            //template.CUSTOM_STRING29_QUESTION = obj.CUSTOM_STRING29_QUESTION;
                            //template.CUSTOM_STRING29_ANSWER = obj.CUSTOM_STRING29_ANSWER;
                            //template.CUSTOM_STRING30_QUESTION = obj.CUSTOM_STRING30_QUESTION;
                            //template.CUSTOM_STRING30_ANSWER = obj.CUSTOM_STRING30_ANSWER;
                            //template.CUSTOM_STRING31_QUESTION = obj.CUSTOM_STRING31_QUESTION;
                            //template.CUSTOM_STRING31_ANSWER = obj.CUSTOM_STRING31_ANSWER;
                            //template.CUSTOM_STRING32_QUESTION = obj.CUSTOM_STRING32_QUESTION;
                            //template.CUSTOM_STRING32_ANSWER = obj.CUSTOM_STRING32_ANSWER;
                            //template.CUSTOM_STRING33_QUESTION = obj.CUSTOM_STRING33_QUESTION;
                            //template.CUSTOM_STRING33_ANSWER = obj.CUSTOM_STRING33_ANSWER;
                            //template.CUSTOM_STRING34_QUESTION = obj.CUSTOM_STRING34_QUESTION;
                            //template.CUSTOM_STRING34_ANSWER = obj.CUSTOM_STRING34_ANSWER;
                            //template.CUSTOM_STRING35_QUESTION = obj.CUSTOM_STRING35_QUESTION;
                            //template.CUSTOM_STRING35_ANSWER = obj.CUSTOM_STRING35_ANSWER;
                            //template.CUSTOM_STRING36_QUESTION = obj.CUSTOM_STRING36_QUESTION;
                            //template.CUSTOM_STRING36_ANSWER = obj.CUSTOM_STRING36_ANSWER;
                            //template.CUSTOM_STRING37_QUESTION = obj.CUSTOM_STRING37_QUESTION;
                            //template.CUSTOM_STRING37_ANSWER = obj.CUSTOM_STRING37_ANSWER;
                            //template.CUSTOM_STRING38_QUESTION = obj.CUSTOM_STRING38_QUESTION;
                            //template.CUSTOM_STRING38_ANSWER = obj.CUSTOM_STRING38_ANSWER;
                            //template.CUSTOM_STRING39_QUESTION = obj.CUSTOM_STRING39_QUESTION;
                            //template.CUSTOM_STRING39_ANSWER = obj.CUSTOM_STRING39_ANSWER;
                            //template.CUSTOM_STRING40_QUESTION = obj.CUSTOM_STRING40_QUESTION;
                            //template.CUSTOM_STRING40_ANSWER = obj.CUSTOM_STRING40_ANSWER;
                            //template.CUSTOM_STRING41_QUESTION = obj.CUSTOM_STRING41_QUESTION;
                            //template.CUSTOM_STRING41_ANSWER = obj.CUSTOM_STRING41_ANSWER;
                            //template.CUSTOM_STRING42_QUESTION = obj.CUSTOM_STRING42_QUESTION;
                            //template.CUSTOM_STRING42_ANSWER = obj.CUSTOM_STRING42_ANSWER;
                            //template.CUSTOM_STRING43_QUESTION = obj.CUSTOM_STRING43_QUESTION;
                            //template.CUSTOM_STRING43_ANSWER = obj.CUSTOM_STRING43_ANSWER;
                            //template.CUSTOM_STRING44_QUESTION = obj.CUSTOM_STRING44_QUESTION;
                            //template.CUSTOM_STRING44_ANSWER = obj.CUSTOM_STRING44_ANSWER;
                            //template.CUSTOM_STRING45_QUESTION = obj.CUSTOM_STRING45_QUESTION;
                            //template.CUSTOM_STRING45_ANSWER = obj.CUSTOM_STRING45_ANSWER;
                            //template.CUSTOM_STRING46_QUESTION = obj.CUSTOM_STRING46_QUESTION;
                            //template.CUSTOM_STRING46_ANSWER = obj.CUSTOM_STRING46_ANSWER;
                            //template.CUSTOM_STRING47_QUESTION = obj.CUSTOM_STRING47_QUESTION;
                            //template.CUSTOM_STRING47_ANSWER = obj.CUSTOM_STRING47_ANSWER;
                            //template.CUSTOM_STRING48_QUESTION = obj.CUSTOM_STRING48_QUESTION;
                            //template.CUSTOM_STRING48_ANSWER = obj.CUSTOM_STRING48_ANSWER;
                            //template.CUSTOM_STRING49_QUESTION = obj.CUSTOM_STRING49_QUESTION;
                            //template.CUSTOM_STRING49_ANSWER = obj.CUSTOM_STRING49_ANSWER;
                            //template.CUSTOM_STRING50_QUESTION = obj.CUSTOM_STRING50_QUESTION;
                            //template.CUSTOM_STRING50_ANSWER = obj.CUSTOM_STRING50_ANSWER;

                            for (int i = 1; i <= 50; i++)
                            {
                                var questionProp = $"CUSTOM_STRING{i}_QUESTION";
                                var answerProp = $"CUSTOM_STRING{i}_ANSWER";

                                // Get values from form and assign to template
                                var questionValue = form[questionProp].ToString();
                                var answerValue = form[answerProp].ToString();

                                template.GetType().GetProperty(questionProp)?.SetValue(template, questionValue);
                                template.GetType().GetProperty(answerProp)?.SetValue(template, answerValue);
                            }

                            _db.SaveChanges();
                            TempData["success"] = "Form updated successfully";
                            //return RedirectToAction("Index");
                        }
                        else
                        {
                            TempData["error"] = "Can not Edit submitted form!!!";
                        }
                    }
                    else
                    {
                        TempData["error"] = "You cannot Edit another Creator form!!!";
                    }
                }

            }

            else if (User.IsInRole("Candidate"))
            {
                var template = _db.Templates.Find(obj.ID);
                if (template is not null)
                {
                    if (template.USER_ID_CANDIDATE is null)
                    {
                        //template.TITLE = obj.TITLE;
                        //template.DESCRIPTION = obj.DESCRIPTION;
                        template.USER_ID_CANDIDATE = obj.USER_ID_CANDIDATE;

                        //        template.CUSTOM_STRING1_QUESTION = obj.CUSTOM_STRING1_QUESTION;
                        template.CUSTOM_STRING1_ANSWER = obj.CUSTOM_STRING1_ANSWER;
                        //        template.CUSTOM_STRING2_QUESTION = obj.CUSTOM_STRING2_QUESTION;
                        template.CUSTOM_STRING2_ANSWER = obj.CUSTOM_STRING2_ANSWER;
                        //        template.CUSTOM_STRING3_QUESTION = obj.CUSTOM_STRING3_QUESTION;
                        template.CUSTOM_STRING3_ANSWER = obj.CUSTOM_STRING3_ANSWER;
                        //        template.CUSTOM_STRING4_QUESTION = obj.CUSTOM_STRING4_QUESTION;
                        template.CUSTOM_STRING4_ANSWER = obj.CUSTOM_STRING4_ANSWER;
                        //        template.CUSTOM_STRING5_QUESTION = obj.CUSTOM_STRING5_QUESTION;
                        template.CUSTOM_STRING5_ANSWER = obj.CUSTOM_STRING5_ANSWER;
                        //        template.CUSTOM_STRING6_QUESTION = obj.CUSTOM_STRING6_QUESTION;
                        template.CUSTOM_STRING6_ANSWER = obj.CUSTOM_STRING6_ANSWER;
                        //        template.CUSTOM_STRING7_QUESTION = obj.CUSTOM_STRING7_QUESTION;
                        template.CUSTOM_STRING7_ANSWER = obj.CUSTOM_STRING7_ANSWER;
                        //        template.CUSTOM_STRING8_QUESTION = obj.CUSTOM_STRING8_QUESTION;
                        template.CUSTOM_STRING8_ANSWER = obj.CUSTOM_STRING8_ANSWER;
                        //        template.CUSTOM_STRING9_QUESTION = obj.CUSTOM_STRING9_QUESTION;
                        template.CUSTOM_STRING9_ANSWER = obj.CUSTOM_STRING9_ANSWER;
                        //        template.CUSTOM_STRING10_QUESTION = obj.CUSTOM_STRING10_QUESTION;
                        template.CUSTOM_STRING10_ANSWER = obj.CUSTOM_STRING10_ANSWER;
                        //        template.CUSTOM_STRING11_QUESTION = obj.CUSTOM_STRING11_QUESTION;
                        template.CUSTOM_STRING11_ANSWER = obj.CUSTOM_STRING11_ANSWER;
                        //        template.CUSTOM_STRING12_QUESTION = obj.CUSTOM_STRING12_QUESTION;
                        template.CUSTOM_STRING12_ANSWER = obj.CUSTOM_STRING12_ANSWER;
                        //        template.CUSTOM_STRING13_QUESTION = obj.CUSTOM_STRING13_QUESTION;
                        template.CUSTOM_STRING13_ANSWER = obj.CUSTOM_STRING13_ANSWER;
                        //        template.CUSTOM_STRING14_QUESTION = obj.CUSTOM_STRING14_QUESTION;
                        template.CUSTOM_STRING14_ANSWER = obj.CUSTOM_STRING14_ANSWER;
                        //        template.CUSTOM_STRING15_QUESTION = obj.CUSTOM_STRING15_QUESTION;
                        template.CUSTOM_STRING15_ANSWER = obj.CUSTOM_STRING15_ANSWER;
                        //        template.CUSTOM_STRING16_QUESTION = obj.CUSTOM_STRING16_QUESTION;
                        template.CUSTOM_STRING16_ANSWER = obj.CUSTOM_STRING16_ANSWER;
                        //        template.CUSTOM_STRING17_QUESTION = obj.CUSTOM_STRING17_QUESTION;
                        template.CUSTOM_STRING17_ANSWER = obj.CUSTOM_STRING17_ANSWER;
                        //        template.CUSTOM_STRING18_QUESTION = obj.CUSTOM_STRING18_QUESTION;
                        template.CUSTOM_STRING18_ANSWER = obj.CUSTOM_STRING18_ANSWER;
                        //        template.CUSTOM_STRING19_QUESTION = obj.CUSTOM_STRING19_QUESTION;
                        template.CUSTOM_STRING19_ANSWER = obj.CUSTOM_STRING19_ANSWER;
                        //        template.CUSTOM_STRING20_QUESTION = obj.CUSTOM_STRING20_QUESTION;
                        template.CUSTOM_STRING20_ANSWER = obj.CUSTOM_STRING20_ANSWER;
                        //        template.CUSTOM_STRING21_QUESTION = obj.CUSTOM_STRING21_QUESTION;
                        template.CUSTOM_STRING21_ANSWER = obj.CUSTOM_STRING21_ANSWER;
                        //        template.CUSTOM_STRING22_QUESTION = obj.CUSTOM_STRING22_QUESTION;
                        template.CUSTOM_STRING22_ANSWER = obj.CUSTOM_STRING22_ANSWER;
                        //        template.CUSTOM_STRING23_QUESTION = obj.CUSTOM_STRING23_QUESTION;
                        template.CUSTOM_STRING23_ANSWER = obj.CUSTOM_STRING23_ANSWER;
                        //        template.CUSTOM_STRING24_QUESTION = obj.CUSTOM_STRING24_QUESTION;
                        template.CUSTOM_STRING24_ANSWER = obj.CUSTOM_STRING24_ANSWER;
                        //        template.CUSTOM_STRING25_QUESTION = obj.CUSTOM_STRING25_QUESTION;
                        template.CUSTOM_STRING25_ANSWER = obj.CUSTOM_STRING25_ANSWER;
                        //        template.CUSTOM_STRING26_QUESTION = obj.CUSTOM_STRING26_QUESTION;
                        template.CUSTOM_STRING26_ANSWER = obj.CUSTOM_STRING26_ANSWER;
                        //        template.CUSTOM_STRING27_QUESTION = obj.CUSTOM_STRING27_QUESTION;
                        template.CUSTOM_STRING27_ANSWER = obj.CUSTOM_STRING27_ANSWER;
                        //        template.CUSTOM_STRING28_QUESTION = obj.CUSTOM_STRING28_QUESTION;
                        template.CUSTOM_STRING28_ANSWER = obj.CUSTOM_STRING28_ANSWER;
                        //        template.CUSTOM_STRING29_QUESTION = obj.CUSTOM_STRING29_QUESTION;
                        template.CUSTOM_STRING29_ANSWER = obj.CUSTOM_STRING29_ANSWER;
                        //        template.CUSTOM_STRING30_QUESTION = obj.CUSTOM_STRING30_QUESTION;
                        template.CUSTOM_STRING30_ANSWER = obj.CUSTOM_STRING30_ANSWER;
                        //        template.CUSTOM_STRING31_QUESTION = obj.CUSTOM_STRING31_QUESTION;
                        template.CUSTOM_STRING31_ANSWER = obj.CUSTOM_STRING31_ANSWER;
                        //        template.CUSTOM_STRING32_QUESTION = obj.CUSTOM_STRING32_QUESTION;
                        template.CUSTOM_STRING32_ANSWER = obj.CUSTOM_STRING32_ANSWER;
                        //        template.CUSTOM_STRING33_QUESTION = obj.CUSTOM_STRING33_QUESTION;
                        template.CUSTOM_STRING33_ANSWER = obj.CUSTOM_STRING33_ANSWER;
                        //        template.CUSTOM_STRING34_QUESTION = obj.CUSTOM_STRING34_QUESTION;
                        template.CUSTOM_STRING34_ANSWER = obj.CUSTOM_STRING34_ANSWER;
                        //        template.CUSTOM_STRING35_QUESTION = obj.CUSTOM_STRING35_QUESTION;
                        template.CUSTOM_STRING35_ANSWER = obj.CUSTOM_STRING35_ANSWER;
                        //        template.CUSTOM_STRING36_QUESTION = obj.CUSTOM_STRING36_QUESTION;
                        template.CUSTOM_STRING36_ANSWER = obj.CUSTOM_STRING36_ANSWER;
                        //        template.CUSTOM_STRING37_QUESTION = obj.CUSTOM_STRING37_QUESTION;
                        template.CUSTOM_STRING37_ANSWER = obj.CUSTOM_STRING37_ANSWER;
                        //        template.CUSTOM_STRING38_QUESTION = obj.CUSTOM_STRING38_QUESTION;
                        template.CUSTOM_STRING38_ANSWER = obj.CUSTOM_STRING38_ANSWER;
                        //        template.CUSTOM_STRING39_QUESTION = obj.CUSTOM_STRING39_QUESTION;
                        template.CUSTOM_STRING39_ANSWER = obj.CUSTOM_STRING39_ANSWER;
                        //        template.CUSTOM_STRING40_QUESTION = obj.CUSTOM_STRING40_QUESTION;
                        template.CUSTOM_STRING40_ANSWER = obj.CUSTOM_STRING40_ANSWER;
                        //        template.CUSTOM_STRING41_QUESTION = obj.CUSTOM_STRING41_QUESTION;
                        template.CUSTOM_STRING41_ANSWER = obj.CUSTOM_STRING41_ANSWER;
                        //        template.CUSTOM_STRING42_QUESTION = obj.CUSTOM_STRING42_QUESTION;
                        template.CUSTOM_STRING42_ANSWER = obj.CUSTOM_STRING42_ANSWER;
                        //        template.CUSTOM_STRING43_QUESTION = obj.CUSTOM_STRING43_QUESTION;
                        template.CUSTOM_STRING43_ANSWER = obj.CUSTOM_STRING43_ANSWER;
                        //        template.CUSTOM_STRING44_QUESTION = obj.CUSTOM_STRING44_QUESTION;
                        template.CUSTOM_STRING44_ANSWER = obj.CUSTOM_STRING44_ANSWER;
                        //        template.CUSTOM_STRING45_QUESTION = obj.CUSTOM_STRING45_QUESTION;
                        template.CUSTOM_STRING45_ANSWER = obj.CUSTOM_STRING45_ANSWER;
                        //        template.CUSTOM_STRING46_QUESTION = obj.CUSTOM_STRING46_QUESTION;
                        template.CUSTOM_STRING46_ANSWER = obj.CUSTOM_STRING46_ANSWER;
                        //        template.CUSTOM_STRING47_QUESTION = obj.CUSTOM_STRING47_QUESTION;
                        template.CUSTOM_STRING47_ANSWER = obj.CUSTOM_STRING47_ANSWER;
                        //        template.CUSTOM_STRING48_QUESTION = obj.CUSTOM_STRING48_QUESTION;
                        template.CUSTOM_STRING48_ANSWER = obj.CUSTOM_STRING48_ANSWER;
                        //        template.CUSTOM_STRING49_QUESTION = obj.CUSTOM_STRING49_QUESTION;
                        template.CUSTOM_STRING49_ANSWER = obj.CUSTOM_STRING49_ANSWER;
                        //        template.CUSTOM_STRING50_QUESTION = obj.CUSTOM_STRING50_QUESTION;
                        template.CUSTOM_STRING50_ANSWER = obj.CUSTOM_STRING50_ANSWER;

                        _db.SaveChanges();
                        TempData["success"] = "Answers submitted successfully";
                        //return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["error"] = "Answers already submitted!!!";
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Creator")]
        public IActionResult Delete(int? id)
        {
            if (User.IsInRole("Admin"))
            {
                Template? obj = _db.Templates.Where(u => u.ID == id).FirstOrDefault();
                if (obj == null)
                {
                    return NotFound();
                }
                _db.Templates.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Form deleted successfully";
                //return RedirectToAction("Index");
            }
            else if (User.IsInRole("Creator"))
            {
                Template? obj = _db.Templates.Where(u => u.ID == id).FirstOrDefault();
                if (obj == null)
                {
                    return NotFound();
                }

                var loggedinuserid = _userManager.GetUserId(User);
                if (obj.USER_ID == loggedinuserid)
                {
                    _db.Templates.Remove(obj);
                    _db.SaveChanges();
                    TempData["success"] = "Form deleted successfully";
                    //return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "You cannot Delete another Creator form!!!";
                }
            }
            return RedirectToAction("Index");
        }
    }
}
