using System.ComponentModel.DataAnnotations;

namespace APIDemo.DataLayer.Models
{
    public class AuthontecatedUserModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [StringLength(8,MinimumLength=3,ErrorMessage="3-8 Digits")]
        public string Password { get; set; }
    }
}