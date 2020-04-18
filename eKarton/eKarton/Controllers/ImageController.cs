using eKarton.Models.SQL;
using eKarton.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace eKarton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        private readonly IService<Image> _service;

        public ImageController(IWebHostEnvironment environment, IService<Image> service)
        {
            _environment = environment;
            _service = service;
        }

        [HttpPost("{action}/{guid}")]
        public async Task<string> UploadFile([FromForm] IFormFile file, string guid)
        {
            var form = HttpContext.Request.Form;
            var form1 = HttpContext.Request.Form.Files;
            string fName = file.FileName;
            string path = Path.Combine(_environment.ContentRootPath, "Images/" + file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return path;
        }

        // GET: api/Image
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages()
        {
            return _service.GetAll();
        }

        // GET: api/Image/guid
        [HttpGet("{guid}")]
        public async Task<ActionResult<Image>> GetImage(string guid)
        {
            var image = _service.GetByGuid(guid);
            if (image == null)
            {
                return NotFound();
            }

            return image;
        }

        // POST: api/Image/snapshot
        [HttpPost("snapshot")]
        public async Task<ActionResult<Snapshot>> PostSnapshot(Snapshot snapshot)
        {
            if (_service.GetByGuid(snapshot.Guid) != null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _service.Create(snapshot);
            return CreatedAtAction("Created Snapshot", new { guid = snapshot.Guid }, snapshot);
        }

        // POST: api/Image/instruction
        [HttpPost("instruction")]
        public async Task<ActionResult<Instruction>> PostInstruction(Instruction instruction)
        {
            if (_service.GetByGuid(instruction.Guid) != null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _service.Create(instruction);
            return CreatedAtAction("Created Instruction", new { guid = instruction.Guid }, instruction);
        }

        // POST: api/Image/analysis
        [HttpPost("analysis")]
        public async Task<ActionResult<Analysis>> PostAnalysis(Analysis analysis)
        {
            if (_service.GetByGuid(analysis.Guid) != null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _service.Create(analysis);
            return CreatedAtAction("Created Analysis", new { guid = analysis.Guid }, analysis);
        }

        // DELETE: api/Image/guid
        [HttpDelete("{guid}")]
        public async Task<ActionResult<Image>> DeleteImage(string guid)
        {
            _service.Delete(guid);
            return Accepted();
        }
    }
}
