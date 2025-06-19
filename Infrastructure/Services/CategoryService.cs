

using Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace Infrastructure.Services;

public class CategoryService(HttpClient http, IConfiguration config)
{
    private readonly HttpClient _http = http;
    private readonly IConfiguration _config = config;


    public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync()
    {
        var response = await _http.GetAsync(_config["ApiUris:Category"]);
        if (response.IsSuccessStatusCode)
        {
            var categories = JsonConvert.DeserializeObject<IEnumerable<CategoryModel>>(await response.Content.ReadAsStringAsync());

            return categories ??= null!;
        }
        return null!;
    }

}

