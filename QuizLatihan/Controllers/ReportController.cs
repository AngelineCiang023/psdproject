using System.Web.Http;
using QuizLatihan.Handler;

namespace QuizLatihan.Controllers
{
    public class ReportController : ApiController
    {
        [HttpGet]
        [Route("api/reports/inventory")]
        public IHttpActionResult GetInventoryReport()
        {
            var report = ReportHandler.GetInventoryReport();
            return Ok(report);
        }

        [HttpGet]
        [Route("api/reports/totalstockvalue")]
        public IHttpActionResult GetTotalStockValue()
        {
            var totalValue = ReportHandler.GetTotalStockValue();
            return Ok(totalValue);
        }
    }
}
