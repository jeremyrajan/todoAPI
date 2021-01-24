using System.ComponentModel.DataAnnotations;

namespace todo.Dtos
{
    public class TodoCreateDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public bool Done { get; set; }
    }
}