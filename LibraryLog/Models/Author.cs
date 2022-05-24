using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryLog.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        //validation rules which are mandatory
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(64, ErrorMessage = "Length of description cannot be greater than 64 characters")]
        [MinLength(2, ErrorMessage = "Length of description cannot be less than 2 characters")]
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int? PhoneNumb { get; set; }

    }

}
