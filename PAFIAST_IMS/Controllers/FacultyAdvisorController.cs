using PAFIAST_IMS.Data;
using PAFIAST_IMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace PAFIAST_IMS.Controllers
{
    public class FacultyAdvisorController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly PAFIAST_IMSContext _db;
        public FacultyAdvisorController(PAFIAST_IMSContext db, UserManager<IdentityUser> usermanager)
        {
            _userManager = usermanager;
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<FacultyAdvisor> objFacultyAdvisorList = _db.FacultyAdvisor_IMS.Include(f=>f.stdinfo);
            return View(objFacultyAdvisorList);
        }
        public IActionResult Details()
        {
            IEnumerable<FacultyAdvisor> objFacultyAdvisorList = _db.FacultyAdvisor_IMS.Include(f=>f.stdinfo);
            return View(objFacultyAdvisorList);
        }
        //GET
        public IActionResult Create()
        {
/*          string id = _userManager.GetUserId(User);
            stdInfo stdinfo = new stdInfo();
            stdinfo = _db.stdInfo_IMS.Where(std => std.userid.Equals(id)).FirstOrDefault();*/
            return View(/*stdinfo*/);
            //return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FacultyAdvisor obj)
        {
/*            var options = new DbContextOptions<PAFIAST_IMSContext>();
            PAFIAST_IMSContext dbContext = new PAFIAST_IMSContext(options);*/
            /*if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order cannot exactly match Name");
            }*/
            //var user = User.Claims.FirstOrDefault(x => x.Type.Equals("name"))?.Value;
            //var user = User.Identity?.Name;
            //var user = _userManager.Users.Where(u => u.Email.Equals(User.Claims.Name)).Select(u => u).FirstOrDefault();
            //obj.stdinfo = _db.stdInfo_IMS.Where(h => h.stdId.Equals(obj.stdinfoid)).Select(h => h).FirstOrDefault();
            var user =  User.Identity?.Name;
            obj.stdinfo = _db.stdInfo_IMS.Where(h => h.userid.Equals(user)).Select(h => h).FirstOrDefault();
            /*if (ModelState.IsValid)
            {*/
            /*            if (user != null)
                        {
                            obj.userid = user.Id;
                            obj.User = null;*/
                _db.FacultyAdvisor_IMS.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Faculty advisor profile created successfully!";
                return RedirectToAction("Index");
            }
         /*   return View(obj);
        }*/

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var FacultyAdvisorFromDb = _db.FacultyAdvisor_IMS.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (FacultyAdvisorFromDb == null)
            {
                return NotFound();
            }
            return View(FacultyAdvisorFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FacultyAdvisor obj)
        {
            /*if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name");
            }*/
            if (ModelState.IsValid)
            {
                _db.FacultyAdvisor_IMS.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Faculty advisor profile updated successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var FacultyAdvisorFromDb = _db.FacultyAdvisor_IMS.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (FacultyAdvisorFromDb == null)
            {
                return NotFound();
            }
            return View(FacultyAdvisorFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.FacultyAdvisor_IMS.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.FacultyAdvisor_IMS.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Faculty advisor profile deleted successfully!";
            return RedirectToAction("Index");

        }
        public IActionResult GetFacultyAdvisor()
        {

            var user = User.Identity?.Name;
            var stdInfo = _db.stdInfo_IMS.Where(h => h.userid.Equals(user)).Select(h => h).FirstOrDefault();
            var obj = _db.FacultyAdvisor_IMS.Where(sup => sup.stdinfoid.Equals(stdInfo.stdId)).Select(sup => sup).FirstOrDefault();
            //here need to add db connection
            return View(obj);
        }

    }
}
