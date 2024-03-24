using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using newshub.Models;
using Newtonsoft.Json;

public class NewsController : Controller
{
    private const string API_KEY = "9f28e401370a95acacea9457870ac419";

    public async Task<IActionResult> SearchNews(string query)
    {
        string apiUrl = $"https://gnews.io/api/v4/search?q={query}&lang=en&country=us&max=10&apikey={API_KEY}";

        using (var client = new HttpClient())
        {
            try
            {
                var response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ApiResponse>(responseBody);

                return View(data.Articles);
            }
            catch (HttpRequestException ex)
            {
                
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, "Error fetching news. Please try again later.");
            }
        }
    }
}
