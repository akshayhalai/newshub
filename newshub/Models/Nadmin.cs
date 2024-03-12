using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace newshub.Models
{
    public class Nadmin()
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string uemail { get; set; }
        [Required]
        public string upass { get; set; }

    }
    
}
