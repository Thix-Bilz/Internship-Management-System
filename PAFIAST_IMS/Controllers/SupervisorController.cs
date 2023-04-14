using PAFIAST_IMS.Data;
using PAFIAST_IMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace PAFIAST_IMS.Controllers
{
    public class SupervisorController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly PAFIAST_IMSContext _db;
        public SupervisorController(PAFIAST_IMSContext db, UserManager<IdentityUser> usermanager)
        {
            _userManager = usermanager;
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Supervisor> objSupervisorList = _db.Supervisor_IMS.Include(f=>f.stdinfo);
            return View(objSupervisorList);
        }
        public IActionResult Details()
        {
            IEnumerable<Supervisor> objSupervisorList = _db.Supervisor_IMS.Include(f=>f.stdinfo);
            return View(objSupervisorList);
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
        public IActionResult Create(Supervisor obj)
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
                _db.Supervisor_IMS.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Supervisor created successfully!";
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
            var SupervisorFromDb = _db.Supervisor_IMS.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (SupervisorFromDb == null)
            {
                return NotFound();
            }
            return View(SupervisorFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Supervisor obj)
        {
            /*if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name");
            }*/
            if (ModelState.IsValid)
            {
                _db.Supervisor_IMS.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Supervisor updated successfully!";
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
            var SupervisorFromDb = _db.Supervisor_IMS.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (SupervisorFromDb == null)
            {
                return NotFound();
            }
            return View(SupervisorFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Supervisor_IMS.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Supervisor_IMS.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Supervisor deleted successfully!";
            return RedirectToAction("Index");

        }
        public IActionResult GetSupervisor()
        {

            var user = User.Identity?.Name;
            var stdInfo = _db.stdInfo_IMS.Where(h => h.userid.Equals(user)).Select(h => h).FirstOrDefault();
            var obj = _db.Supervisor_IMS.Where(sup => sup.stdinfoid.Equals(stdInfo.stdId)).Select(sup => sup).FirstOrDefault();
            //here need to add db connection
            return View(obj);
        }

    }
}
