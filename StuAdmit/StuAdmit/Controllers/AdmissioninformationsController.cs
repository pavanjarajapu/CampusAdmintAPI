using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuAdmit.Controllers.Model;

namespace StuAdmit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissioninformationsController : ControllerBase
    {
        private readonly CrudCoreDbContext _context;

        public AdmissioninformationsController(CrudCoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Admissioninformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admissioninformation>>> GetAdmin()
        {
            return await _context.Admin.ToListAsync();
        }

        // GET: api/Admissioninformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admissioninformation>> GetAdmissioninformation(int id)
        {
            var admissioninformation = await _context.Admin.FindAsync(id);

            if (admissioninformation == null)
            {
                return NotFound();
            }

            return admissioninformation;
        }

        // PUT: api/Admissioninformations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmissioninformation(int id, Admissioninformation admissioninformation)
        {
            if (id != admissioninformation.Admission_Id)
            {
                return BadRequest();
            }

            _context.Entry(admissioninformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdmissioninformationExists(id))
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

        // POST: api/Admissioninformations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Admissioninformation>> PostAdmissioninformation(Admissioninformation admissioninformation)
        {
            _context.Admin.Add(admissioninformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmissioninformation", new { id = admissioninformation.Admission_Id }, admissioninformation);
        }

        // DELETE: api/Admissioninformations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Admissioninformation>> DeleteAdmissioninformation(int id)
        {
            var admissioninformation = await _context.Admin.FindAsync(id);
            if (admissioninformation == null)
            {
                return NotFound();
            }

            _context.Admin.Remove(admissioninformation);
            await _context.SaveChangesAsync();

            return admissioninformation;
        }

        private bool AdmissioninformationExists(int id)
        {
            return _context.Admin.Any(e => e.Admission_Id == id);
        }
    }
}
