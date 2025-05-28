using System.Collections.Generic;
using System.Web.Http;
using QuizLatihan.Handler;
using QuizLatihan.Model;

namespace QuizLatihan.Controllers
{
    public class JewelController : ApiController
    {
        [HttpGet]
        [Route("api/jewels")]
        public IEnumerable<TblJewel> GetAllJewels()
        {
            return JewelHandler.GetAllJewels();
        }

        [HttpGet]
        [Route("api/jewels/{id}")]
        public IHttpActionResult GetJewelById(int id)
        {
            var jewel = JewelHandler.GetJewelById(id);
            if (jewel == null)
                return NotFound();
            return Ok(jewel);
        }

        [HttpPost]
        [Route("api/jewels")]
        public IHttpActionResult CreateJewel([FromBody] TblJewel jewel)
        {
            if (JewelHandler.CreateJewel(jewel))
                return Ok();
            return BadRequest("Failed to create jewel.");
        }

        [HttpPut]
        [Route("api/jewels")]
        public IHttpActionResult UpdateJewel([FromBody] TblJewel jewel)
        {
            if (JewelHandler.UpdateJewel(jewel))
                return Ok();
            return BadRequest("Failed to update jewel.");
        }

        [HttpDelete]
        [Route("api/jewels/{id}")]
        public IHttpActionResult DeleteJewel(int id)
        {
            if (JewelHandler.DeleteJewel(id))
                return Ok();
            return BadRequest("Failed to delete jewel.");
        }
    }
}
