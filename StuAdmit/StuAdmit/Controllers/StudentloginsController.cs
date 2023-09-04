using System;
using System.Collections;
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

    public class StudentloginsController : ControllerBase
    {
        private readonly CrudCoreDbContext _context;
        ////private readonly CrudCoreDbContext _context;
        //public StudentloginsController(CrudCoreDbContext context)
        //{
        //    _context = context;
        //}
        //[Route("Registration")]
        //public IActionResult Registration()

        //{

        //    return Ok(_context.Registaration.ToList());

        //}
        //[Route("Login")]
        //public ActionResult Login(string Email, string Password)//([FromBody] User user)

        //{

        //    Hashtable err = new Hashtable();

        //    try

        //    {

        //        var result = _context.Registaration.Where(x => x.email.Equals(Email) && x.password.Equals(Password)).FirstOrDefault();

        //        if (result != null) return Ok(result);

        //        else

        //        {

        //            err.Add("Status", "Error");

        //            err.Add("Message", "Invalid Credentials");

        //            return Ok(err);

        //        }
        //    }

        //    catch (Exception)

        //    {
        //        throw;

        //    }



        public StudentloginsController(CrudCoreDbContext context)
        {
            _context = context;
        }


        // GET: api/Studentlogins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studentlogin>>> GetRegistaration()
        {
            return await _context.Registaration.ToListAsync();
        }

        // GET: api/Studentlogins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Studentlogin>> GetStudentlogin(int id)
        {
            var studentlogin = await _context.Registaration.FindAsync(id);

            if (studentlogin == null)
            {
                return NotFound();
            }

            return studentlogin;
        }
        // GET: api/Studentlogins/Email/password
        [HttpGet("{Email}/{password}")]
        public async Task<ActionResult<Studentlogin>> GetStudentloginBypwd(string Email, string password)
        {
            var studentlogin = await _context.Registaration.FirstOrDefaultAsync(x => x.email == Email && x.password == password);

            if (studentlogin == null)
            {
                return NotFound();
            }

            return studentlogin;
        }

        // PUT: api/Studentlogins/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentlogin(int id, Studentlogin studentlogin)
        {
            if (id != studentlogin.Student_Id)
            {
                return BadRequest();
            }

            _context.Entry(studentlogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentloginExists(id))
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

        // POST: api/Studentlogins
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Studentlogin>> PostStudentlogin(Studentlogin studentlogin)
        {
            _context.Registaration.Add(studentlogin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentlogin", new { id = studentlogin.Student_Id }, studentlogin);
        }

        // DELETE: api/Studentlogins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Studentlogin>> DeleteStudentlogin(int id)
        {
            var studentlogin = await _context.Registaration.FindAsync(id);
            if (studentlogin == null)
            {
                return NotFound();
            }

            _context.Registaration.Remove(studentlogin);
            await _context.SaveChangesAsync();

            return studentlogin;
        }

        private bool StudentloginExists(int id)
        {
            return _context.Registaration.Any(e => e.Student_Id == id);
        }
    }
}

    

