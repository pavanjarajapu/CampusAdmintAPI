using System;
using System.ComponentModel.DataAnnotations;

namespace StuAdmit.Controllers.Model
{
    public class Studentlogin
    {

        [Key]
        public int Student_Id { get; set; }
        [Required(ErrorMessage ="student is required")]
        [MaxLength(20)]
        [MinLength(2)]
        public string username { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public String contact_number { get; set; }
        [Required(ErrorMessage ="Required field")]
        public string email { get; set; }
        [Required(ErrorMessage ="Required field")]
        [MaxLength(20)]
        [MinLength(2)]
        public string password { get; set; }
        [Required]
        public string confirmpassword { get; set; }
        [Required]
        public string usertype { get; set; }
       
        
    }
}
