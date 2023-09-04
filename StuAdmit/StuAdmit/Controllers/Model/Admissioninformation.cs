using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StuAdmit.Controllers.Model
{
    public class Admissioninformation
    {
        [Required]
        [Key]
        public int Admission_Id { get; set; }
        public DateTime Admission_date { get; set; }

        [ForeignKey("Studentlogin")]
        public int Student_Id { get; set; }

        public virtual  Studentlogin Studentlogin { get; set; }
        
        [ForeignKey("Courses")]
        public int Course_Id { get; set; }
        public virtual Courses Courses{ get; set; }

    }
}
