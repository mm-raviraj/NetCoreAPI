using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code.Model
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Allowd upto 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Allowd upto 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Allowd upto 50 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Phone(ErrorMessage = "Invalid details.")]
        [MaxLength(10, ErrorMessage = "Allowed upto 10 digits.")]
        public string PhoneNumber { get; set; }
    }
}