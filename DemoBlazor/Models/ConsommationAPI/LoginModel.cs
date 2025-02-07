using System.ComponentModel.DataAnnotations;

namespace DemoBlazor.Models.ConsommationAPI
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
