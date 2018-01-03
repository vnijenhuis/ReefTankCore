using System.ComponentModel.DataAnnotations;

namespace ReefTankCore.Web.Models.Account
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
