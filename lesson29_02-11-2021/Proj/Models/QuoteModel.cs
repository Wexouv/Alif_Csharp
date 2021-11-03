using System;
using System.ComponentModel.DataAnnotations;
namespace Proj.Models
{
    public class Quote
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        // Not required
        public string Author { get; set; }
        [Required]
        public DateTime InsertDate { get; set; }
    }
}
