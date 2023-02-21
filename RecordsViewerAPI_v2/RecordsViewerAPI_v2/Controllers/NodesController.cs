using Microsoft.AspNetCore.Mvc;
using RecordsViewerAPI_v2.Models;
using RecordsViewerAPI_v2.Services;

namespace RecordsViewerAPI_v2.Controllers
{
    [Route("RecordsViewerAPI/nodes")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        private readonly IRecordsService recordsService;

        public NodesController(IRecordsService recordsService)
        {
            this.recordsService = recordsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var nodes = await recordsService.GetAll();
            return Ok(nodes);
        }

        [HttpGet("{id}", Name = "GetNode")]
        public async Task<IActionResult> Get(int id)
        {
            Node node = await recordsService.Get(id);

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

            recordsService.Add(node);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Node node)
        {
            if (node == null)
                return BadRequest("Node is null.");

            Node nodeToUpdate = await recordsService.Get(id);
            if (nodeToUpdate == null)
                return NotFound("The node couldn't be found.");

            if (!ModelState.IsValid)
                return BadRequest();

            recordsService.Update(nodeToUpdate, node);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Node node = await recordsService.Get(id);
            if (node == null)
                return NotFound("The node couldn't be found.");

            recordsService.Delete(node);
            return NoContent();
        }
    }
}
