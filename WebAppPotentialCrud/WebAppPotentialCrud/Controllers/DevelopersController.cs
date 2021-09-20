using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAppPotentialCrud.Models;

namespace WebAppPotentialCrud.Controllers
{
    public class DevelopersController : Controller
    {
        HttpClientHandler clientHandler = new HttpClientHandler();

        Developer developer = new Developer();
        List<Developer> developers = new List<Developer>();

        public DevelopersController()
        {
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<Developer>> GetAllDevelopers()
        {
            developers = new List<Developer>();

            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44384/api/Developer"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    developers = JsonConvert.DeserializeObject<List<Developer>>(apiResponse);
                }
            }

            return developers;
        }

        [HttpGet]
        public async Task<Developer> GetById(int developerId)
        {
            developer = new Developer();

            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44384/api/Developer/" + developerId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    developer = JsonConvert.DeserializeObject<Developer>(apiResponse);
                }
            }

            return developer;
        }

        [HttpPost]
        public async Task<Developer> AddUpdateDeveloper(Developer developerReq)
        {
            developer = new Developer();

            using (var httpClient = new HttpClient(clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(developerReq), Encoding.UTF8, "application/json");

                if (developerReq.Id == 0)
                {
                    using (var response = await httpClient.PostAsync("https://localhost:44384/api/Developer", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        developer = JsonConvert.DeserializeObject<Developer>(apiResponse);
                    }
                    return developer;
                }

                using (var response = await httpClient.PutAsync("https://localhost:44384/api/Developer/" + developerReq.Id, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    developer = JsonConvert.DeserializeObject<Developer>(apiResponse);
                }


            }

            return developer;
        }

        [HttpDelete]
        public async Task<string> Delete(int developerId)
        {
            string message = "";

            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44384/api/Developer/" + developerId))
                {
                    message = await response.Content.ReadAsStringAsync();
                }
            }

            return message;
        }
    }
}
