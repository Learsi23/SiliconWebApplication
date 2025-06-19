using Infrastructure.Models;


namespace SiliconWebApplication.ViewModels.Courses;

public class CoursesViewModel
{
    
    public IEnumerable<CourseModel>? CourseModel { get; set; } 
    public IEnumerable<CategoryModel>? Category { get; set; } 
    public Pagination? pagination { get; set; }
}
