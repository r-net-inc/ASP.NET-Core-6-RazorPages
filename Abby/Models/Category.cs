using System.ComponentModel.DataAnnotations;

namespace Abby.Models
{
    public class Category
    {
        [Key] // Not necessary when Id, only for other columns
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Today;
    }
}
