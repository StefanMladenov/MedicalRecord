using eKarton.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKarton.Services
{
    public class MedicalRecordService
    {
        private readonly MedicalRecordContext _context;

        public MedicalRecordService(MedicalRecordContext context)
        {
            _context = context;
        }

        // GET: api/EKarton
        public List<MedicalRecord> GetKartoni()
        {
            return _context.MedicalRecords.ToList();
        }

        // GET: api/EKarton/5
        public MedicalRecord GetEKarton(int id)
        {
            MedicalRecord medicalRecord = _context.MedicalRecords.Find(id);
            if (medicalRecord != null)
            {
                return medicalRecord;
            }
            return medicalRecord;
        }

        // PUT: api/EKarton/5
        //        public async Task<IActionResult> PutEKarton(int id, EKarton eKarton)
        //        {
        //            if (id != eKarton.Id)
        //            {
        //                return BadRequest();
        //            }

        //            _context.Entry(eKarton).State = EntityState.Modified;

        //            try
        //            {
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!EKartonExists(id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }

        //            return NoContent();
        //        }

        //        // POST: api/EKarton
        //        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //        // more details see https://aka.ms/RazorPagesCRUD.
        //        [HttpPost]
        //        public async Task<ActionResult<EKarton>> PostEKarton(EKarton eKarton)
        //        {
        //            _context.EKartoni.Add(eKarton);
        //            await _context.SaveChangesAsync();

        //            return CreatedAtAction("GetEKarton", new { id = eKarton.Id }, eKarton);
        //        }

        //        // DELETE: api/EKarton/5
        //        [HttpDelete("{id}")]
        //        public async Task<ActionResult<EKarton>> DeleteEKarton(int id)
        //        {
        //            var eKarton = await _context.EKartoni.FindAsync(id);
        //            if (eKarton == null)
        //            {
        //                return NotFound();
        //            }

        //            _context.EKartoni.Remove(eKarton);
        //            await _context.SaveChangesAsync();

        //            return eKarton;
        //        }

        //        private bool EKartonExists(int id)
        //        {
        //            return _context.EKartoni.Any(e => e.Id == id);
        //        }
        //    }
        //}

        //}
        //}
    }
}
