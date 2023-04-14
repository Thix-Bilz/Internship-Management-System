using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAFIAST_IMS.Data;
using Wkhtmltopdf.NetCore;

namespace PAFIAST_IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeApiController : ControllerBase
    {
        readonly IGeneratePdf _generatePdf;
        private readonly PAFIAST_IMSContext db;
        public HomeApiController(IGeneratePdf generatePdf, PAFIAST_IMSContext _db)
        {
            _generatePdf = generatePdf;
            db = _db;
        }
        [HttpGet]
    [Route("GetFormC")]
        public async Task<IActionResult> GetFormC()
        
        {

            var user = User.Identity?.Name;
            var stdInfo = db.stdInfo_IMS.Where(h => h.userid.Equals(user)).Select(h => h).FirstOrDefault();
            var obj = db.FormC_IMS.Where(fc => fc.stdinfoid.Equals(stdInfo.stdId)).Select(fc => fc).FirstOrDefault();
            //here need to add db connection
            return await _generatePdf.GetPdf("~/Views/FormC/Details.cshtml", obj);
        }
    }
}
