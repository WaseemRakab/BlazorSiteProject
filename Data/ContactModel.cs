using System.ComponentModel.DataAnnotations;

namespace WaseemRkab_Portfolio.Data
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Your Name: field is required")]
        [Display(Name = "Your Name: ")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Please Enter a valid Email Address")]
        [Required(ErrorMessage = "Your Email: field is required")]
        [Display(Name = "Your Email: ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Your Message: field is required")]
        [DataType(DataType.MultilineText)]
        [MinLength(20, ErrorMessage = "Please be more detailed with at least 20 characters.")]
        [Display(Name = "Message: ")]
        public string Message { get; set; }

    }
}
