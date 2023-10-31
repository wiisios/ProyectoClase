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

        public string Catergory { get; set; }


    }
}
