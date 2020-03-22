using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eKarton.Models.SQL;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace eKarton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly MedicalRecordContext _context;
        public static IWebHostEnvironment _environment;

        public ImageController(IWebHostEnvironment environment, MedicalRecordContext context)
        {
            _environment = environment;
            _context = context;
        }

        [HttpPost("UploadFile")]
        public async Task<string> UploadFile([FromForm] IFormFile file)
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

    
        

        /// <summary>
        /// Uplaods an image to the server.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>


        // GET: api/Image
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages()
        {
            return await _context.Images.ToListAsync();
        }

        // GET: api/Image/5
        [HttpGet("{guid}")]
        public async Task<ActionResult<Image>> GetImage(string guid)
        {
            var image = await _context.Images.FindAsync(guid);

            if (image == null)
            {
                return NotFound();
            }

            return image;
        }

        // PUT: api/Image/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{guid}")]
        public async Task<IActionResult> PutImage(string guid, Image image)
        {
            if (guid != image.Guid)
            {
                return BadRequest();
            }

            _context.Entry(image).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(guid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Image
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Image>> PostImage(Image image)
        {
            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImage", new { guid = image.Guid }, image);
        }

        // DELETE: api/Image/5
        [HttpDelete("{guid}")]
        public async Task<ActionResult<Image>> DeleteImage(string guid)
        {
            var image = await _context.Images.FindAsync(guid);
            if (image == null)
            {
                return NotFound();
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return image;
        }

        private bool ImageExists(string guid)
        {
            return _context.Images.Any(e => e.Guid == guid);
        }
    }
}
