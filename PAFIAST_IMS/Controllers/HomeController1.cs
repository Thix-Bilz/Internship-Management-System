using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Mvc;
using PAFIAST_IMS.Data;
using PAFIAST_IMS.Models;
using Wkhtmltopdf.NetCore;

namespace PAFIAST_IMS.Controllers
{
    [Route("api/[controller]")]
    public class HomeController1 : Controller
    {
        readonly IGeneratePdf _generatePdf;
        private readonly PAFIAST_IMSContext db;
        private readonly IRouter _router;
        public HomeController1(IGeneratePdf generatePdf, PAFIAST_IMSContext _db, IRouter router)
        {
            _generatePdf = generatePdf;
            db = _db;
            _router = router;   
        }
        [HttpGet]
      [Route("Get")]
        public async Task<IActionResult> GetFormC() 
        {

            var user = User.Identity?.Name;
            var stdInfo = db.stdInfo_IMS.Where(h => h.userid.Equals(user)).Select(h => h).FirstOrDefault();
            var obj = db.FormC_IMS.Where(fc => fc.stdinfoid.Equals(stdInfo.stdId)).Select(fc => fc).FirstOrDefault();
            //here need to add db connection
            return await _generatePdf.GetPdf("Views/FormC/Details.cshtml", obj);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
