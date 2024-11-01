namespace utssapi.Models
{
    public class Course
    {
        public int courseId { get; set; } = 0;
        public required string name { get; set; }
        public string? imageName { get; set; }
        public double? duration { get; set; }
        public string? description { get; set; }
        public int categoryId { get; set; } = 0;
    }
}
