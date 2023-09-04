using Microsoft.AspNetCore.Mvc;
using StuAdmit.Controllers.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StuAdmit.Repository
{
    public interface IAdmissioninformation
    {
        Task<ActionResult<IEnumerable<Admissioninformation>>> GetAdmin();
        Task<ActionResult<Admissioninformation>> GetAdmissioninformation(int id);
        Task<IActionResult> PutAdmissioninformation(int id, Admissioninformation admissioninformation);
        Task<ActionResult<Admissioninformation>> PostAdmissioninformation(Admissioninformation admissioninformation);
        Task<ActionResult<Admissioninformation>> DeleteAdmissioninformation(int id);
    }
}
