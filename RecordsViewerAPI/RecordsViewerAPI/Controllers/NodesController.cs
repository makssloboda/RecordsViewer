using Microsoft.AspNetCore.Mvc;
using RecordsViewerAPI.Models;

namespace RecordsViewerAPI.Controllers
{
    [Route("RecordsViewerAPI/nodes")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        private readonly DBManager db;

        public NodesController(DBManager dbManager)
        {
            db = dbManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var nodes = db.GetAll();
            return Ok(nodes);
        }

        [HttpGet("{id}", Name = "GetNode")]
        public IActionResult Get(int id)
        {
            Node node = db.Get(id);

            if (node == null)
                return NotFound("Node not found.");

            return Ok(node);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Node node)
        {
            if (node == null)
                return BadRequest("Node is null.");

            if (!ModelState.IsValid)
                return BadRequest();

            db.Add(node);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Node node)
        {
            if (node == null)
                return BadRequest("Node is null.");

            Node nodeToUpdate = db.Get(id);
            if (nodeToUpdate == null)
                return NotFound("The node couldn't be found.");

            if (!ModelState.IsValid)
                return BadRequest();

            db.Update(nodeToUpdate, node);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Node node = db.Get(id);
            if (node == null)
                return NotFound("The node couldn't be found.");

            db.Delete(node);
            return NoContent();
        }
    }
}
