using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiliconWebApplication.ViewModels.Courses;

namespace SiliconWebApplication.Controllers;

public class SingleCourseController : Controller
{
    private readonly HttpClient _http;

    public SingleCourseController(HttpClient httpClient)
    {
        _http = httpClient;
    }

    public async Task<IActionResult> SingleCourse(string courseId)
    {
        var viewModel = new CoursesViewModel();

        var response = await _http.GetAsync($"https://localhost:7086/api/course/{courseId}");

        if (response.IsSuccessStatusCode)
        {
            var course = JsonConvert.DeserializeObject<CourseModel>(await response.Content.ReadAsStringAsync());
            viewModel.CourseModel = [course];
            return View(viewModel);
        }
        else
        {
            return View("Error404");
        }
    }

}

