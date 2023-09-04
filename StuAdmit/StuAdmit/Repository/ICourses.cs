using Microsoft.AspNetCore.Mvc;
using StuAdmit.Controllers.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuAdmit.Repository
{
    public interface ICourses
    {
        Task<ActionResult<IEnumerable<Courses>>> GetCourse();
        Task<ActionResult<Courses>> GetCourses(int id);
        Task<IActionResult> PutCourses(int id, Courses courses);
        Task<ActionResult<Courses>> PostCourses(Courses courses);
        Task<ActionResult<Courses>> DeleteCourses(int id);
    }
}
