using Azure;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemUI.Models;
using StudentManagementSystemUI.Models.DTO;
using System.Text;
using System.Text.Json;

namespace StudentManagementSystemUI.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public StudentsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            List<StudentDto> response = new List<StudentDto>();
            try
            {
                //GETALL
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7069/api/Students");

                httpResponseMessage.EnsureSuccessStatusCode();

                response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<StudentDto>>());
            }
            catch (Exception ex)
            {
                //Exception 
            }

            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel model)
        {
            var client = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7069/api/Students"),
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
            };
            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            
            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<StudentDto>();
            if(response is not null)
            {
                return RedirectToAction("Index", "Students");
            }
            return View();

        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<StudentDto>($"https://localhost:7069/api/Students/{id.ToString()}");

            if(response is not null)
            {
                return View(response);
            }
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentDto request)
        {
            var client = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7069/api/students/{request.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json")
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            //httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<StudentDto>();

            if(response is not null)
            {
                return RedirectToAction("Edit", "Students");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<StudentDto>($"https://localhost:7069/api/Students/{id.ToString()}");

            if (response is not null)
            {
                return View(response);
            }
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult>Delete(StudentDto request)
        {
            try
            {
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.DeleteAsync($"https://localhost:7069/api/students/{request.Id}");

                httpResponseMessage.EnsureSuccessStatusCode();

                return RedirectToAction("Index", "Students");
            }
            catch (Exception)
            {
                            
            }
            return View();
        }

    }
}
