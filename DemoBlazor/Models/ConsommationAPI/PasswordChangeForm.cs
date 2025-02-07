using System.ComponentModel.DataAnnotations;

namespace DemoBlazor.Models.ConsommationAPI
{
    public class PasswordChangeForm
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
        [Required]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}
