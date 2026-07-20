using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Examination
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Question { get; set; } = string.Empty;

        public int AnswerChoiceNo { get; set; }

        [Required]
        [MaxLength(100)]
        public string Answer1Detail { get; set; } = string.Empty; 

        [Required]
        [MaxLength(100)]
        public string Answer2Detail { get; set; } = string.Empty; 

        [Required]
        [MaxLength(100)]
        public string Answer3Detail { get; set; } = string.Empty; 

        
        [Required]
        [MaxLength(100)]
        public string Answer4Detail { get; set; } = string.Empty; 

        public DateTime RecordTimestamp { get; set; } = DateTime.Now;
    }
}