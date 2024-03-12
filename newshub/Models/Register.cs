using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace newshub.Models
{
    public partial class Register
    {
        [Key]
        public int userID { get; set; }

       
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string uname { get; set; }

        
        [Required(ErrorMessage ="Please Enter your Email")]
        public string uemail { get; set; }

   
        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string upass { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm password")]
        
        [DataType(DataType.Password)]
        [Compare("upass", ErrorMessage = "Doesn't Match With Password")]
        public string conpass { get; set; }

        

        [Required(ErrorMessage ="Please Enter your Mobile No.")]
        public string umob { get; set; }

      
    }

}
