using PAFIAST_IMS.Data;
using PAFIAST_IMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace PAFIAST_IMS.Controllers
{
    public class stdInfoController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly PAFIAST_IMSContext _db;
        public stdInfoController(PAFIAST_IMSContext db, UserManager<IdentityUser> usermanager)
        {
            _userManager = usermanager;
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<stdInfo> objstdInfoList = _db.stdInfo_IMS;
            return View(objstdInfoList);
        }
        public IActionResult Details()
        {
            IEnumerable<stdInfo> objstdInfoList = _db.stdInfo_IMS;
            return View(objstdInfoList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(stdInfo obj)
        {
            /*if (obj.Name == obj.DisplayOrder.ToString())
            { ModelState.AddModelError("Name", "The Display Order cannot exactly match Name"); }*/

            //var user1 = _userManager.Users.Where(u => u.Email.Equals(obj.User)).Select(u => u).FirstOrDefault();
            //var user = User.Claims.FirstOrDefault(x => x.Type.Equals("name"))?.Value;

            var user = User.Identity?.Name;
            /*if (ModelState.IsValid)
            {*/
            if (user != null&&!_db.stdInfo_IMS.Any(s=>s.userid==user))
            {
                obj.userid = user;
                //obj.User = null;
                _db.stdInfo_IMS.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Student information created successfully!";
                return RedirectToAction("Index");
            }
            /*else
            {
                ModelState.AddModelError("", "Invalid username or password.");
            }*/
            else
            {
                return View();
            }
            //return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var stdinfoFromDb = _db.stdInfo_IMS.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (stdinfoFromDb == null)
            {
                return NotFound();
            }
            return View(stdinfoFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(stdInfo obj)
        {
            /*if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name");
            }*/
            /*if (ModelState.IsValid)
            {*/
                _db.stdInfo_IMS.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Student Information updated successfully!";
                return RedirectToAction("Index");
            /*}*/
            //return View(obj);
        }


        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var stdinfoFromDb = _db.stdInfo_IMS.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (stdinfoFromDb == null)
            {
                return NotFound();
            }
            return View(stdinfoFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.stdInfo_IMS.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.stdInfo_IMS.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Student information deleted successfully!";
            return RedirectToAction("Index");

        }

        public IActionResult Getstdinfo()
        {

            var user = User.Identity?.Name;
            var obj = _db.stdInfo_IMS.Where(h => h.userid.Equals(user)).Select(h => h).FirstOrDefault();
            //var obj = _db.stdInfo_IMS.Where(ie => ie.stdinfoid.Equals(stdInfo.stdId)).Select(ie => ie).FirstOrDefault();
            //here need to add db connection
            return View(obj);
        }

    }
}
