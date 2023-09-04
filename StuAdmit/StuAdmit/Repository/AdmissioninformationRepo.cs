using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StuAdmit.Controllers.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuAdmit.Repository
{
    public class AdmissioninformationRepo : IAdmissioninformation
    {
        private readonly CrudCoreDbContext _context;

        public AdmissioninformationRepo(CrudCoreDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Admissioninformation>>> GetAdmin()
        {
            return await _context.Admin.ToListAsync();
        }
        public async Task<ActionResult<Admissioninformation>> GetAdmissioninformation(int id)
        {
            var admissioninformation = await _context.Admin.FindAsync(id);

            //if (admissioninformation == null)
            //{
            //    return NotFound();
            //}

            return admissioninformation;
        }
        public async Task<IActionResult> PutAdmissioninformation(int id, Admissioninformation admissioninformation)
        {
            //if (id != admissioninformation.Admission_Id)
            //{
            //    return BadRequest();
            //}

            _context.Entry(admissioninformation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return (IActionResult)admissioninformation;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!AdmissioninformationExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }
        public async Task<ActionResult<Admissioninformation>> PostAdmissioninformation(Admissioninformation admissioninformation)
        {
            _context.Admin.Add(admissioninformation);
            await _context.SaveChangesAsync();
            return admissioninformation;

            //return CreatedAtAction("GetAdmissioninformation", new { id = admissioninformation.Admission_Id }, admissioninformation);
        }
        public async Task<ActionResult<Admissioninformation>> DeleteAdmissioninformation(int id)
        {
            var admissioninformation = await _context.Admin.FindAsync(id);
            //if (admissioninformation == null)
            //{
            //    return NotFound();
            //}

            _context.Admin.Remove(admissioninformation);
            await _context.SaveChangesAsync();

            return admissioninformation;
        }
    }
}
