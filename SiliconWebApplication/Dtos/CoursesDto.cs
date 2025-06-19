using System.ComponentModel.DataAnnotations.Schema;

namespace SiliconWebApplication.Dtos;

public class CoursesDto
{
  
    public string Title { get; set; } = null!;

    public string? Author { get; set; }

    public string? ImageName { get; set; }

    public decimal Price { get; set; }

    public decimal Discount { get; set; }

    public int Hours { get; set; }

    public bool IsBestSeller { get; set; }

    public string? LikesNumbers { get; set; }

    public string? LikesProcent { get; set; }


}
