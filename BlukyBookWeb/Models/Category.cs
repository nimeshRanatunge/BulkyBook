using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BlukyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        //now name is not nullable property
        [Required]
        public String Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100 only!!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
