namespace todo.Dtos
{
    public class TodoReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public bool Done { get; set; }
    }
}