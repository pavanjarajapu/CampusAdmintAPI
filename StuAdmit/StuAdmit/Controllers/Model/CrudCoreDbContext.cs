using Microsoft.EntityFrameworkCore;

namespace StuAdmit.Controllers.Model
{
    public class CrudCoreDbContext : DbContext
    {
        public CrudCoreDbContext(DbContextOptions<CrudCoreDbContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Studentlogin> Registaration { get; set; }
        public virtual DbSet<Courses> Course { get; set; }
        public virtual DbSet<Admissioninformation> Admin{ get; set; }

    }
}
