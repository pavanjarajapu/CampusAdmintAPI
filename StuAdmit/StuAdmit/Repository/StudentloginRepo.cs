using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuAdmit.Controllers.Model;

namespace StuAdmit.Repository
{
    public class StudentloginRepo : IStudentlogin
    {
        private readonly CrudCoreDbContext _context;

        public StudentloginRepo(CrudCoreDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Studentlogin>>> GetRegistaration()
        {
            return await _context.Registaration.ToListAsync();
        }
        public async Task<ActionResult<Studentlogin>> GetStudentlogin(int id)
        {
            var studentlogin = await _context.Registaration.FindAsync(id);

           // if (studentlogin == null)
           // {
            //    return NotFound();
            //}

            return studentlogin;
        }
        public async Task<ActionResult<Studentlogin>> GetStudentloginBypwd(string Email, string password)
        {
            var studentlogin = await _context.Registaration.FirstOrDefaultAsync(x => x.email == Email && x.password == password);

            //if (studentlogin == null)
            //{
            //    return NotFound();
            //}

            return studentlogin;
        }
        public async Task<IActionResult> PutStudentlogin(int id, Studentlogin studentlogin)
        {
            //if (id != studentlogin.Student_Id)
            //{
            //    return BadRequest();
            //}

            _context.Entry(studentlogin).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return (IActionResult)studentlogin;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!StudentloginExists(id))
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
        public async Task<ActionResult<Studentlogin>> PostStudentlogin(Studentlogin studentlogin)
        {
            _context.Registaration.Add(studentlogin);
            await _context.SaveChangesAsync();
            return studentlogin;

           // return CreatedAtAction("GetStudentlogin", new { id = studentlogin.Student_Id }, studentlogin);
        }
        public async Task<ActionResult<Studentlogin>> DeleteStudentlogin(int id)
        {
            var studentlogin = await _context.Registaration.FindAsync(id);
            //if (studentlogin == null)
            //{
            //    return NotFound();
            //}

            _context.Registaration.Remove(studentlogin);
            await _context.SaveChangesAsync();

            return studentlogin;
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
