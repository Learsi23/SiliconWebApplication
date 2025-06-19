using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class CourseEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();


    public string Title { get; set; } = null!;

    public string? Author { get; set; }

    public string? ImageName { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Discount { get; set; }

    public int Hours { get; set; }

    public bool IsBestSeller { get; set; }

    public string? LikesNumbers { get; set; }

   
    public string? LikesProcent { get; set; }



    public string UserId { get; set; } = null!;
    public UserEntity User { get; set; } = null!;

}