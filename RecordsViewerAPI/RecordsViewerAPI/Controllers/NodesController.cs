using Microsoft.AspNetCore.Mvc;
using RecordsViewerAPI.Models;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Get()
        {
            var nodes = await db.GetAll();
            return Ok(nodes);
        }

        [HttpGet("{id}", Name = "GetNode")]
        public async Task<IActionResult> Get(int id)
        {
            Node node = await db.Get(id);

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
        public async Task<IActionResult> Put(int id, [FromBody] Node node)
        {
            if (node == null)
                return BadRequest("Node is null.");

            Node nodeToUpdate = await db.Get(id);
            if (nodeToUpdate == null)
                return NotFound("The node couldn't be found.");

            if (!ModelState.IsValid)
                return BadRequest();

            db.Update(nodeToUpdate, node);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Node node = await db.Get(id);
            if (node == null)
                return NotFound("The node couldn't be found.");

            db.Delete(node);
            return NoContent();
        }
    }
}
