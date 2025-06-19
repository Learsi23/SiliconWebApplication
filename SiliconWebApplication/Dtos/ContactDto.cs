using System.ComponentModel.DataAnnotations;

namespace SiliconWebApplication.DTOs
{
    public class ContactDto
    {
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, ErrorMessage = "Full name must be at most {1} characters long.")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "The email address is not valid.")]
        public string EmailAddress { get; set; } = null!;

        [Required(ErrorMessage = "Service is required.")]
        [StringLength(50, ErrorMessage = "Service must be at most {1} characters long.")]
        public string Service { get; set; }= null!;

        [Required(ErrorMessage = "Message is required.")]
        [StringLength(500, ErrorMessage = "Message must be at most {1} characters long.")]
        public string Message { get; set; }= null!;
    }
}
