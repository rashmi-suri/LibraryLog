using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryLog.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        //validation rules which are mandatory
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(64, ErrorMessage = "Length of description cannot be greater than 64 characters")]
        [MinLength(2, ErrorMessage = "Length of description cannot be less than 2 characters")]
        public string? Title { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public string? publisher { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string? Status { get; set; }
    }

}
