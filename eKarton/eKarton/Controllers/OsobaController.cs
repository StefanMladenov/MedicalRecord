//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using eKarton.Models.SQL;
//using eKarton.Services;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace eKarton.Controllers
//{

//    [Route("api/[controller]/[action]")]
//    [ApiController]
//    public class OsobaController : ControllerBase
//    {
//        public readonly OsobaServis _servis;
//        public readonly EKartonContext _context;
//        public OsobaController(EKartonContext context)
//        {
//            _context = context;
//            _servis = new OsobaServis(context);
//        }

//        //    [HttpPost]
//        //    public async Task<ActionResult> CreateOsoba()
//        //    {
//        //        Pacijent osoba = new Pacijent();
//        //        //osoba.Id = 1;
//        //        osoba.DatumRodjenja = DateTime.Now;
//        //        osoba.EMail = "ssss";
//        //        osoba.Ime = "Stefa";
//        //        osoba.Prezime = "Stefa";
//        //        osoba.JMBG = "2";
//        //        _context.Osobe.Add(osoba);
//        //        await _context.SaveChangesAsync();
//        //        return CreatedAtAction("CreateOsoba", new { id = osoba.Id }, osoba);
//        //    }

//        // GET: api/<controller>
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Osoba>>> GetLekari()
//        {
//            return await _context.Lekari.ToListAsync();
//            //return _servis.GetLekari();
//        }

//        //    // GET api/<controller>/5
//        //    [HttpGet("{id}")]
//        //    public async Task<ActionResult<Osoba>> GetOsoba(int id)
//        //    {
//        //        var osoba = await _context.Osobe.FindAsync(id);

//        //        if (osoba == null)
//        //        {
//        //            return NotFound();
//        //        }

//        //        return osoba;
//        //    }

//        //    // POST api/<controller>
//        //    [HttpPost]
//        //    public void Post([FromBody]string value)
//        //    {
//        //    }

//        //    // PUT api/<controller>/5
//        //    [HttpPut("{id}")]
//        //    public void Put(int id, [FromBody]string value)
//        //    {
//        //    }

//        //    // DELETE api/<controller>/5
//        //    [HttpPut("{id}")]
//        //    public async Task<IActionResult> PutOsoba(int id, Osoba osoba)
//        //    {
//        //        if (id != osoba.Id)
//        //        {
//        //            return BadRequest();
//        //        }

//        //        _context.Entry(osoba).State = EntityState.Modified;

//        //        try
//        //        {
//        //            await _context.SaveChangesAsync();
//        //        }
//        //        catch (DbUpdateConcurrencyException)
//        //        {
//        //            if (!OsobaExists(id))
//        //            {
//        //                return NotFound();
//        //            }
//        //            else
//        //            {
//        //                throw;
//        //            }
//        //        }

//        //        return NoContent();
//        //    }

//        //    [HttpPost]
//        //    public async Task<ActionResult<EKarton>> PostEKarton(Osoba osoba)
//        //    {
//        //        _context.Osobe.Add(osoba);
//        //        await _context.SaveChangesAsync();

//        //        return CreatedAtAction("GetOsoba", new { id = osoba.Id }, osoba);
//        //    }

//        //    // DELETE: api/EKarton/5
//        //    [HttpDelete("{id}")]
//        //    public async Task<ActionResult<Osoba>> DeleteOsoba(int id)
//        //    {
//        //        var osoba = await _context.Osobe.FindAsync(id);
//        //        if (osoba == null)
//        //        {
//        //            return NotFound();
//        //        }

//        //        _context.Osobe.Remove(osoba);
//        //        await _context.SaveChangesAsync();

//        //        return osoba;
//        //    }

//        //    private bool OsobaExists(int id)
//        //    {
//        //        return _context.Osobe.Any(e => e.Id == id);
//        //    }
//        //}
//    }
//}
