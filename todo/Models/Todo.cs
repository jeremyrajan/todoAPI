using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace todo.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool Done { get; set; }
    }
}