using Microsoft.AspNetCore.Mvc;
using StuAdmit.Controllers.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuAdmit.Repository
{
    public interface IStudentlogin
    {
        Task<ActionResult<IEnumerable<Studentlogin>>> GetRegistaration();
        Task<ActionResult<Studentlogin>> GetStudentlogin(int id);
        Task<ActionResult<Studentlogin>> GetStudentloginBypwd(string Email, string password);
        Task<IActionResult> PutStudentlogin(int id, Studentlogin studentlogin);
        Task<ActionResult<Studentlogin>> PostStudentlogin(Studentlogin studentlogin);
        Task<ActionResult<Studentlogin>> DeleteStudentlogin(int id);


    }
}
