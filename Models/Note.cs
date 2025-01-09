namespace HelloWorld.Models
{
    public class Note
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ApplicationUserId { get; set; } = string.Empty;
    }
}
