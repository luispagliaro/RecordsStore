using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Records.API.Entities
{
    public class Record
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public int ReleaseYear { get; set; }

        public int Price { get; set; }

        [ForeignKey("BandId")]
        public int BandId { get; set; }
    }
}
