namespace SiliconWebApplication.ViewModels.Courses
{
    public class SavedCourseViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string ImageName { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Hours { get; set; }
        public bool IsBestSeller { get; set; }
        public string? LikesNumbers { get; set; }
        public string? LikesProcent { get; set; }
    }
}
