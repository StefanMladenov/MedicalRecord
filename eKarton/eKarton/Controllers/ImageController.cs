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
        private readonly IService<Snapshot> _snapshotService;
        private readonly IService<Instruction> _instructionService;
        private readonly IService<Analysis> _analysisService;

        public ImageController(IWebHostEnvironment environment, IService<Snapshot> snapshotService, IService<Instruction> instructionService, IService<Analysis> analysisService)
        {
            _environment = environment;
            _snapshotService = snapshotService;
            _instructionService = instructionService;
            _analysisService = analysisService;
        }

        // POST: api/Image/UploadFile/foldername
        [HttpPost("{action}/{foldername}")]
        public async Task<string> UploadFile([FromForm] IFormFile file, string foldername)
        {
            var form = HttpContext.Request.Form;
            var form1 = HttpContext.Request.Form.Files;
            string fName = file.FileName;
            string path = Path.Combine(_environment.ContentRootPath, "Images\\" + foldername);
            string pathWithFilename = path + "\\" + file.FileName;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (var stream = new FileStream(pathWithFilename, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return pathWithFilename;
        }

        // GET: api/Image
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages()
        {
            List<Image> list = new List<Image>();
            list.AddRange(_snapshotService.GetAll());
            list.AddRange(_instructionService.GetAll());
            list.AddRange(_analysisService.GetAll());
            return list;
        }

        // GET: api/Image/Snapshot
        [HttpGet("snapshot")]
        public async Task<ActionResult<IEnumerable<Snapshot>>> GetSnapshots()
        {
            return _snapshotService.GetAll();
        }

        // GET: api/Image/Instruction
        [HttpGet("instruction")]
        public async Task<ActionResult<IEnumerable<Instruction>>> GetInstructions()
        {
            return _instructionService.GetAll();
        }

        // GET: api/Image/Analysis
        [HttpGet("analysis")]
        public async Task<ActionResult<IEnumerable<Analysis>>> GetAnalyses()
        {
            return _analysisService.GetAll();
        }

        // GET: api/Image/guid
        [HttpGet("{guid}")]
        public ActionResult<Image> GetImage(string guid)
        {
            Image image = _snapshotService.GetByGuid(guid);
            if (image != null)
            {
                return image;
            }
            image = _instructionService.GetByGuid(guid);
            if (image != null)
            {
                return image;
            }
            image = _analysisService.GetByGuid(guid);
            if (image != null)
            {
                return image;
            }
            return NotFound();
        }

        // GET: api/Image/Snapshot/guid
        [HttpGet("snapshot/{guid}")]
        public ActionResult<Snapshot> GetSnapshot(string guid)
        {
            var snapshot = _snapshotService.GetByGuid(guid);
            if (snapshot != null)
            {
                return snapshot;
            }
            return NotFound();
        }

        // GET: api/Image/Instruction/guid
        [HttpGet("instruction/{guid}")]
        public ActionResult<Instruction> GetInstruction(string guid)
        {
            var instruction = _instructionService.GetByGuid(guid);
            if (instruction != null)
            {
                return instruction;
            }
            return NotFound();
        }

        // GET: api/Image/Analysis/guid
        [HttpGet("analysis/{guid}")]
        public ActionResult<Analysis> GetAnalysis(string guid)
        {
            var analysis = _analysisService.GetByGuid(guid);
            if (analysis != null)
            {
                return analysis;
            }
            return NotFound();
        }

        // POST: api/Image/Snapshot
        [HttpPost("snapshot")]
        public ActionResult<Snapshot> PostSnapshot(Snapshot snapshot)
        {
            if (_snapshotService.GetByGuid(snapshot.Guid) != null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _snapshotService.Create(snapshot);
            return CreatedAtAction("PostSnapshot", new { guid = snapshot.Guid }, snapshot);
        }

        // POST: api/Image/Instruction
        [HttpPost("instruction")]
        public ActionResult<Instruction> PostInstruction(Instruction instruction)
        {
            if (_instructionService.GetByGuid(instruction.Guid) != null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _instructionService.Create(instruction);
            return CreatedAtAction("PostInstruction", new { guid = instruction.Guid }, instruction);
        }

        // POST: api/Image/Analysis
        [HttpPost("analysis")]
        public ActionResult<Analysis> PostAnalysis(Analysis analysis)
        {
            if (_analysisService.GetByGuid(analysis.Guid) != null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _analysisService.Create(analysis);
            return CreatedAtAction("PostAnalysis", new { guid = analysis.Guid }, analysis);
        }

        // PUT: api/Image/Snapshot/guid
        [HttpPut("snapshot/{guid}")]
        public ActionResult<Snapshot> PutSnapshot(string guid, [FromBody]Snapshot snapshot)
        {
            if (ModelState.IsValid)
            {
                var snapsh = _snapshotService.GetByGuid(guid);
                if (snapsh != null)
                {
                    _snapshotService.Update(guid, snapshot, snapsh);
                    return Accepted();
                }
                else
                {
                    snapshot.Guid = guid;
                    _snapshotService.Create(snapshot);
                    return Created("guid", guid);
                }
            }
            return BadRequest();
        }

        // PUT: api/Image/Instruction/guid
        [HttpPut("instruction/{guid}")]
        public ActionResult<Instruction> PutInstruction(string guid, [FromBody]Instruction instruction)
        {
            if (ModelState.IsValid)
            {
                var instr = _instructionService.GetByGuid(guid);
                if (instr != null)
                {
                    _instructionService.Update(guid, instruction, instr);
                    return Accepted();
                }
                else
                {
                    instruction.Guid = guid;
                    _instructionService.Create(instruction);
                    return Created("guid", guid);
                }
            }
            return BadRequest();
        }

        // PUT: api/Image/Analysis/guid
        [HttpPut("analysis/{guid}")]
        public ActionResult<Analysis> PutAnalysis(string guid, [FromBody]Analysis analysis)
        {
            if (ModelState.IsValid)
            {
                var analys = _analysisService.GetByGuid(guid);
                if (analys != null)
                {
                    _analysisService.Update(guid, analysis, analys);
                    return Accepted();
                }
                else
                {
                    analysis.Guid = guid;
                    _analysisService.Create(analysis);
                    return Created("guid", guid);
                }
            }
            return BadRequest();
        }

        // DELETE: api/Image/guid
        [HttpDelete("{guid}")]
        public ActionResult<Image> DeleteImage(string guid)
        {
            _snapshotService.Delete(guid);
            _instructionService.Delete(guid);
            _analysisService.Delete(guid);
            return Accepted();
        }

        // DELETE: api/Image/DeleteFileOnPath
        [HttpDelete("{action}")]
        public ActionResult<Image> DeleteFileOnPath([FromBody]Snapshot image)
        {
            if (System.IO.File.Exists(image.ImagePath))
            {
                System.IO.File.Delete(image.ImagePath);
            }
            return Accepted();
        }
    }
}
