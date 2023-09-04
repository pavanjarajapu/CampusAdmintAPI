using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuAdmit.Controllers.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuAdmit.Repository
{
    public class CoursesRepo : ICourses
    {
        private readonly CrudCoreDbContext _context;

        public CoursesRepo(CrudCoreDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Courses>>> GetCourse()
        {
            return await _context.Course.ToListAsync();
        }
        public async Task<ActionResult<Courses>> GetCourses(int id)
        {
            var courses = await _context.Course.FindAsync(id);

            //if (courses == null)
            //{
            //    return NotFound();
            //}

            return courses;
        }
        public async Task<IActionResult> PutCourses(int id, Courses courses)
        {

            //if (id != courses.Course_Id)
            //{
            //    return BadRequest();
            //}

            _context.Entry(courses).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return (IActionResult)courses;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!CoursesExists(id))
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
        public async Task<ActionResult<Courses>> PostCourses(Courses courses)
        {
            _context.Course.Add(courses);
            await _context.SaveChangesAsync();
            return courses;

            //return CreatedAtAction("GetCourses", new { id = courses.Course_Id }, courses);
        }
        public async Task<ActionResult<Courses>> DeleteCourses(int id)
        {
            var courses = await _context.Course.FindAsync(id);
            //if (courses == null)
            //{
            //    return NotFound();
            //}

            _context.Course.Remove(courses);
            await _context.SaveChangesAsync();

            return courses;
        }

    }
}
