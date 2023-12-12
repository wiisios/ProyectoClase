using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Entities
{
    public class URL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int Id { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string ShortUrl { get; set; }
        public int VisitCounter { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; } = new();

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new();
    }
}
