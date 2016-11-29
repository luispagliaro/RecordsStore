using System.ComponentModel.DataAnnotations;

namespace Records.API.Models
{
    public class RecordUpdateDto
    {
        [Required(ErrorMessage = "A title for the record must be provided.")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "A release year for the record must be provided.")]
        public int ReleaseYear { get; set; }

        [Required(ErrorMessage = "A price for the record must be provided.")]
        public int Price { get; set; }
    }
}
