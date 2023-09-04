using System.ComponentModel.DataAnnotations;

namespace StuAdmit.Controllers.Model
{
    public class Courses
    {
        
        [Key]
        public int Course_Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        public string Course_Name { get;set; }
        [Required]
        public string Course_fees { get; set; }
    }
}
