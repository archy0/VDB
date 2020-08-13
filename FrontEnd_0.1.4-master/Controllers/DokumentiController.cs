using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using FrontEnd.Models;
using Newtonsoft.Json;
using System.Text.Json;
using FrontEnd.Converters;

namespace FrontEnd.Controllers
{
    public class DokumentiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly ILogger<HomeController> _logger;

        private readonly IHttpClientFactory _clientFactory;//A factory abstraction for a component that can create HttpClient instances with custom configuration for a given logical name.

        public DokumentiController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;

            _clientFactory = clientFactory;
        }


        [Route("Dokumenti/Detalas")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Detalas(decimal id)
        {
            var requestDokumenti = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44303/api/Art_Dokuments/Detalas/" + id);
            var client = _clientFactory.CreateClient();
            var responseDokumenti = await client.SendAsync(requestDokumenti);

            JObject jsonObject;
            Art_Dokuments adrese;

            if (responseDokumenti.IsSuccessStatusCode)
            {
                using var responseStream = await responseDokumenti.Content.ReadAsStreamAsync();
                string jsonString = await responseDokumenti.Content.ReadAsStringAsync();
                jsonObject = JObject.Parse(jsonString);

                adrese = JsonConvert.DeserializeObject<Art_Dokuments>(jsonString);
            }
            else
            {
                jsonObject = null;

                adrese = null;
            }

            ViewBag.dokDetalas = jsonObject;

            return View(adrese);
        }

        [Route("Dokumenti/DokumentiAll")]
        [HttpGet]
        public async Task<JsonDocument> Dokumenti() {
            CreateJson createJson = new CreateJson(_clientFactory);

            string url = "https://localhost:44303/api/Art_Dokuments";

            JsonDocument jsonDocument = await createJson.GetJsonDocument(url);

            return jsonDocument;
        }

        [Route("Dokumenti/DokumentiById")]
        [HttpGet/*("{id}")*/]
        public async Task<JsonDocument> DokumentiByID(int page, int pageSize) {
            string url = "https://localhost:44303/api/Art_Dokuments" + "?page=" + page + "&pageSize=" + pageSize;

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            string jsonString;
            JsonDocument jsonDocument;

            if (response.IsSuccessStatusCode) {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                if (response.Headers.TryGetValues("Pagination", out IEnumerable<string> values)) {
                    string session = values.First();
                    Response.Headers.Add("Pagination", session);

                } else StatusCode(500); //internal server error

                jsonString = await response.Content.ReadAsStringAsync();
                jsonDocument = JsonDocument.Parse(jsonString);
            } else {
                jsonDocument = null;
            }

            return jsonDocument;
        }
    }
}