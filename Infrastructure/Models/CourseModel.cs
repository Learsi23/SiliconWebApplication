namespace Infrastructure.Models;

public class CourseModel
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Author { get; set; }
    public string? ImageName { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public int Hours { get; set; }
    public bool IsBestSeller { get; set; }
    public bool IsDigital { get; set; }
    public string? LikesNumbers { get; set; }
    public string? LikesProcent { get; set; }
    public string? BigImageUrl { get; set; }
    public string Category { get; set; } = null!;

}