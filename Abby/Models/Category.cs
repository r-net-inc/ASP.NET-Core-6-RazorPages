using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Abby.Models
{
    public class Category
    {
        [Key] // Not necessary when Id, only for other columns
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name="Display Order")]
        [Range(0, 100, ErrorMessage ="Display order must be between 1 and 100.")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Today;
    }
}
