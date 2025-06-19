using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiliconWebApplication.ViewModels.Courses;


namespace SiliconWebApplication.Controllers;


public class CoursesController(CategoryService service, CourseService courseService) : Controller
{
    private readonly CategoryService _service = service;
    private readonly CourseService _courseService = courseService;


    //[Authorize]
    public async Task<IActionResult> Courses(string category ="", string searchQuery = "",int pageNumber = 1, int pageSize = 6)
    {
        var courseResult = await _courseService.GetCourseAsync(category, searchQuery, pageNumber, pageSize);


         var viewModel = new CoursesViewModel
        {
            Category = await _service.GetCategoriesAsync(),
            CourseModel = courseResult.Courses,
            pagination = new Pagination
            {
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = courseResult.TotalPages,
                TotalItems = courseResult.TotalItems
                
            }
        };


        return View(viewModel);
    }


}

