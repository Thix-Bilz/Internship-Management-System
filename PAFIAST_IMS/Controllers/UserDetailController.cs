/*using Microsoft.AspNetCore.Mvc;
using PAFIAST_IMS.Models;
using Microsoft.AspNetCore.Identity;
using PAFIAST_IMS.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace PAFIAST_IMS.Controllers
{
    public class UserDetailController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signinManager;
        public UserDetailController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signinManager)

        {
            _userManager = userManager;
            _signinManager = signinManager;
        }
        [HttpGet]
        public async Task<ActionResult> UserProfile()
        {
            ViewBag.Message = "Welcome to my demo!";

            stdInfo stdinfo = new stdInfo();
            PAFIAST_IMSContext applicationDbContext = new PAFIAST_IMSContext(new DbContextOptions<PAFIAST_IMSContext>());
            if (_signinManager.IsSignedIn(User))
            {

                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                // var user=_userManager.Users.Where(u => u.Id == _userManager.GetUserId(HttpContext.User)).Select(u => u).FirstOrDefault();
                //var user=await _userManager.FindByIdAsync(userid);

                stdinfo = applicationDbContext.stdInfo_IMS.Include(hd => hd.User)
                    .Where(hd => hd.userid.Equals(user.Id))
                    .Select(hd => hd).FirstOrDefault();

            }

            return View(stdinfo);
        }
        *//*[HttpPost]
        public ActionResult ProfileData(profile profile)
        {
            ViewBag.Message = "Welcome to my demo!";
            return View();
        }*//*
    }
}

*/