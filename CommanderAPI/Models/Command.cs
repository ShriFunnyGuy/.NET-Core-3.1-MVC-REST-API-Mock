using System;
using System.ComponentModel.DataAnnotations;
namespace CommanderAPI.Models
{
    public class Command
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string HowTo{ get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string App { get; set; }
    }
}
