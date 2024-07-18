using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystemUI.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public StudentsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {

            try
            {
                //GETALL
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7146/api/students");

                httpResponseMessage.EnsureSuccessStatusCode();

                var stringResponseBody = await httpResponseMessage.Content.ReadAsStringAsync();
                ViewBag.Response = stringResponseBody;
            }
            catch (Exception ex)
            {
                
            }

            return View();
        }
    }
}
