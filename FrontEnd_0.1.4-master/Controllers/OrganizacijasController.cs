using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;//IFormCollection
using System.Net.Http;//IHttpClientFactory 
using System.Text.Json;// JsonSerializer, contains all the entry points and the main types
using System.Text.Json.Serialization;//contains attributes and APIs for advanced scenarios and customization specific to serialization and deserialization
using Newtonsoft.Json.Linq;//JObject
using Newtonsoft.Json;
using FrontEnd.Models;


namespace FrontEnd.Controllers
{
    public class OrganizacijasController : Controller
    {
        private readonly ILogger<OrganizacijasController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public OrganizacijasController(ILogger<OrganizacijasController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;

            _clientFactory = clientFactory;
        }
        // GET: Organizacijas
        public async Task<IActionResult> Saraksts()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44303/api/art_organiz");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            string jsonString = "";

            string jsonString2;


            //JObject json;
            JArray jsonArray;

            JObject jsonObjects;

            //var art_Organiz;

            string jsonSerialized = "";

            JArray jsonArraySerialized;


            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                jsonString = await response.Content.ReadAsStringAsync();

                var res = jsonString.Replace("[", "").Replace("]", "");

                //Console.WriteLine("res : " + res);


                jsonArray = JArray.Parse(jsonString);
                //Branches = JsonSerializer.Serialize<IEnumerable<Art_Organiz>>(responseStream);

                //jsonObjects = JObject.Parse(jsonString);

                var jsonString3 = @"{""ID"": 123, ""NOSAUKUMS"": ""zz""}";

                //var art_Organiz = JsonSerializer.Deserialize<Art_Organiz>(res);



                // var art_Organiz = JsonConvert.DeserializeObject<List<string>>(jsonArray);

                // Console.WriteLine("art_Organiz : " + art_Organiz);

                //json = JObject.Parse(jsonString);

                //Console.WriteLine("jsonArray " + jsonArray);


                List<Art_Organiz> products = JsonConvert.DeserializeObject<List<Art_Organiz>>(jsonString);

                Console.WriteLine("products[0] : " + products[0].NOSAUKUMS);

                jsonSerialized = JsonConvert.SerializeObject(products, Formatting.Indented);

                jsonArraySerialized = JArray.Parse(jsonSerialized);

                Console.WriteLine("jsonSerialized : " + jsonSerialized);


            }
            else
            {
                //GetBranchesError = true;
                //Branches = Array.Empty<GitHubBranch>();
                jsonArray = null;
                jsonSerialized = null;

                jsonArraySerialized = null;
                //var art_Organiz = null;

                List<Art_Organiz> products = null;
            }
            ViewBag.saraksts = jsonArraySerialized;
            return View();
        }

        // GET: Organizacijas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Organizacijas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organizacijas/Create
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

        // GET: Organizacijas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Organizacijas/Edit/5
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

        // GET: Organizacijas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Organizacijas/Delete/5
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

        public async Task<IActionResult> SarakstsClass2(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44303/api/art_organiz"); 
            var client = _clientFactory.CreateClient(); 
            var response = await client.SendAsync(request); 
            JArray jsonArray; 
            //JObject jsonObjects; 
            string jsonString = ""; 
            string jsonSerialized = ""; 
            JArray jsonArraySerialized; 
            List<Art_Organiz> products; 
            //IOrderedEnumerable<Art_Organiz> order; 
            IOrderedEnumerable<Art_Organiz> entries; 

            if (response.IsSuccessStatusCode) { 
                using var responseStream = await response.Content.ReadAsStreamAsync(); 
                jsonString = await response.Content.ReadAsStringAsync(); 
                jsonArray = JArray.Parse(jsonString); 
                products = JsonConvert.DeserializeObject<List<Art_Organiz>>(jsonString); 
            } else { 
                jsonArray = null; 
                jsonSerialized = null; 
                jsonArraySerialized = null; 
                products = null; 
                //order = null; 
            }

            ViewData["CurrentSort"] = sortOrder; 
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : ""; 
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date"; 
            
            if (searchString != null) { 
                pageNumber = 1; 
            } else { 
                searchString = currentFilter; 
            }

            ViewData["CurrentFilter"] = searchString; 
            entries = from s in products orderby s.NOSAUKUMS select s; 

            if (!String.IsNullOrEmpty(searchString))
            { }

            switch (sortOrder)
            {
                case "name_desc": entries = entries.OrderByDescending(s => s.ID);
                    break; 
                case "Date": entries = entries.OrderBy(s => s.NOSAUKUMS); 
                    break; 
                case "date_desc": entries = entries.OrderByDescending(s => s.ABREV); 
                    break; 
                default: entries = entries.OrderBy(s => s.NOSAUKUMS); 
                    break; 
            }

            int pageSize = 11; 

            return View(await PaginatedList<Art_Organiz>.CreateAsync(entries, pageNumber ?? 1, pageSize));
        }

    }
}