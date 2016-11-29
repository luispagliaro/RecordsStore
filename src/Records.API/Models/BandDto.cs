using System.ComponentModel.DataAnnotations;

namespace Records.API.Models
{
    public class BandDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A name for the band must be provided.")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
