using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;//IFormCollection
using System.Net.Http;//IHttpClientFactory 
using Newtonsoft.Json.Linq;//JObject
using Newtonsoft.Json;
using FrontEnd.Models;
using FrontEnd.Converters;

namespace FrontEnd.Controllers
{
    public class AdresesController : Controller
    {
        private readonly ILogger<AdresesController> _logger;

        private readonly IHttpClientFactory _clientFactory;//A factory abstraction for a component that can create HttpClient instances with custom configuration for a given logical name.

        public AdresesController(ILogger<AdresesController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;

            _clientFactory = clientFactory;
        }

        // GET: Adreses/Details/5
        [Route("Adreses/Details/{id}")]
        public async Task<IActionResult> Details(decimal? id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44303/api/adreses/Detalas/" + id + "");


            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var jsonString = "";

            JObject jsonObjects;

            JArray jsonArray;

            IArg_Adrese adreseDetails;

            List<Arg_Adrese> products;

            Arg_Adrese adrese;

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                jsonString = await response.Content.ReadAsStringAsync();
                // Branches = await JsonSerializer.DeserializeAsync <IEnumerable<GitHubBranch>>(responseStream);

                Console.WriteLine("jsonString " + jsonString);

                //int startIndex = 1186;
                //int endIndex = 1200;

                //var text = jsonString.Substring(startIndex, endIndex);

                //Console.WriteLine("izmeklētais teksts : " + text);


                //jsonArray = JArray.Parse(jsonString);
                jsonObjects = JObject.Parse(jsonString);


                adrese = JsonConvert.DeserializeObject<Arg_Adrese>(jsonString);




                adreseDetails = JsonConvert.DeserializeObject<IArg_Adrese>(jsonString, new Arg_AdreseConverter());

                string output = JsonConvert.SerializeObject(adreseDetails);

                Console.WriteLine("output " + output);


                Arg_Adrese p1 = new Arg_Adrese() { STD = "Product1" };
                Arg_Adrese p2 = new Arg_Adrese() { STD = "Product2" };
                products = new List<Arg_Adrese>() { p1, p2 };

            }
            else
            {

                jsonArray = null;

                jsonObjects = null;

                adrese = null;

                adreseDetails = null;

                products = null;

            }




            ViewBag.detalas = jsonObjects;

            return PartialView("_Details", adrese);
            //return View(adrese);
        }


        [Route("Adreses/Satur/{id}")]
        public async Task<IActionResult> Satur(Decimal? id)
        {
            var requestSatur = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44303/api/adreses/satur/" + id);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(requestSatur);

            var jsonString = "";

            JObject jsonObjects;

            JArray jsonArray;


            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                jsonString = await response.Content.ReadAsStringAsync();

                //jsonObjects = JObject.Parse(jsonString);

                jsonArray = JArray.Parse(jsonString);

                Console.WriteLine("jsonObjects " + jsonArray);

            }
            else
            {
                jsonObjects = null;

                jsonArray = null;
            }

            ViewBag.satur = jsonArray;

            return PartialView();
        }

        // POST: Adreses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Adreses/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Adreses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Adreses/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Adreses/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}