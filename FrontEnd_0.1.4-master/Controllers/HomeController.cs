using ClosedXML.Excel;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;//IFormCollection
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;//JObject
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;//IHttpClientFactory 
using System.Text.Json;//JsonSerializer, JsonDocument(?)
using System.Threading.Tasks;

namespace FrontEnd.Controllers {
    public class HomeController : Controller {

        private readonly ILogger<HomeController> _logger;

        private readonly IHttpClientFactory _clientFactory;//A factory abstraction for a component that can create HttpClient instances with custom configuration for a given logical name.

        //PublicFunc publicFunc = new PublicFunc();

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory) {
            _logger = logger;

            _clientFactory = clientFactory;

        }

        public async Task<IActionResult> Index() {
            CreateJson createJson = new CreateJson(_clientFactory);

            string urlStatusi = "https://localhost:44303/api/Art_Konst/AdresesStatusi";
            string urlAdrVeidi = "https://localhost:44303/api/Art_Konst/KODIF100";

            ViewBag.novadi = await GetNovadi();
            ViewBag.statusi = await createJson.GetJsonArray(urlStatusi);
            ViewBag.adrVeidi = await createJson.GetJsonArray(urlAdrVeidi);

            return View();
        }

        //returno novadu + rep. pilsētu sarakstu / ViewBag.novadi = GetNovadi();
        public async Task<JArray> GetNovadi() {
            CreateJson createJson = new CreateJson(_clientFactory);
            string url = "https://localhost:44303/api/adreses/getNovadi2";
            return await createJson.GetJsonArray(url);
        }


        //iegūst tikai novadus
        public async Task<JArray> GetNovadiOnly() {
            CreateJson createJson = new CreateJson(_clientFactory);
            string url = "https://localhost:44303/api/adreses/getNovadi";
            return await createJson.GetJsonArray(url);
        }

        [Route("GetPagasti/NovadsID={NovadsID}")]
        [HttpGet("{NovadsID}")]
        public async Task<JsonDocument> GetPagasti(decimal NovadsID) {
            CreateJson createJson = new CreateJson(_clientFactory);

            string url = "https://localhost:44303/api/adreses/getPagasti/NovadsID=" + NovadsID + "";

            JsonDocument testJson = await createJson.GetJsonDocument(url);

            return testJson;
        }

        //https://localhost:44308/DBRezultati/PagastsID=100010804&VeidsID=107&Statuss=EKS&Nosauk_dala=dzi
        [Route("DBRezultati")]
        [HttpGet("NovadsID:{NovadsID}")]
        [HttpGet("VeidsID:{VeidsID}")]
        [HttpGet("Statuss:{Statuss}")]
        [HttpGet("PagastsID:{PagastsID}")]
        [HttpGet("Nosauk_dala:{Nosauk_dala}")]
        [HttpGet("Page:{page}")]
        [HttpGet("PageSize:{pageSize}")]
        public async Task<JsonDocument> DBRezultati(int PagastsID, int VeidsID, string Statuss, string Nosauk_dala, int NovadsID, int page, int pageSize)
        {
            Console.WriteLine("Tiek izpildīts DBRezultati");
            Console.WriteLine("NovadsID: " + NovadsID);
            Console.WriteLine("PagastsID: " + PagastsID);
            Console.WriteLine("VeidsID: " + VeidsID);
            Console.WriteLine("Statuss: " + Statuss);
            Console.WriteLine("Nosauk_dala: " + Nosauk_dala);
            Console.WriteLine("Page: " + page);
            Console.WriteLine("PageSize: " + pageSize);

            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44303/api/adreses/filterPaginated?" +
                //"VKUR_CD=" + PagastsID +
                "PagastsID=" + PagastsID +
                "&TIPS_CD=" + VeidsID +
                "&STATUSS=" + Statuss +
                "&STD=" + Nosauk_dala +
                "&NovadsID=" + NovadsID +
                "&page=" + page +
                "&pageSize=" + pageSize
                );

            //Console.WriteLine("FILTER URL \n" + "https://localhost:44303/api/adreses/filter?" +
            //    "VKUR_CD=" + PagastsID +
            //    "&TIPS_CD=" + VeidsID +
            //    "&STATUSS=" + Statuss +
            //    "&STD=" + Nosauk_dala);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var jsonString = "";
            ////JObject json;
            JArray jsonArray;
            JsonDocument jsonDocument;
            JObject jsonObject;

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                if (response.Headers.TryGetValues("Pagination", out IEnumerable<string> values))
                {
                    string session = values.First();
                    Response.Headers.Add("Pagination", session);

                }
                else StatusCode(500); //internal server error

                jsonString = await response.Content.ReadAsStringAsync();
                // Branches = await JsonSerializer.DeserializeAsync <IEnumerable<GitHubBranch>>(responseStream);
                Console.WriteLine("responseStream " + responseStream);

                //jsonArray = JArray.Parse(jsonString);

                //Console.WriteLine(jsonArray.Take<JToken>(5));

                jsonDocument = JsonDocument.Parse(jsonString);
                // jsonObject = JObject.Parse(jsonString);

                //Console.WriteLine("JsonDocument.RootElement objekti : " + jsonDocument.RootElement);

                //int length = jsonDocument.RootElement.GetArrayLength();

                //if (length > 200)
                //{

                //    return null;
                //}
            }
            else
            {
                jsonArray = null;
                jsonDocument = null;
                jsonObject = null;
                jsonString = "";

            }
            return jsonDocument;
        }

        [HttpGet]
        [Route("DBPaginatedRez")]
        public async Task<JsonDocument> DBPaginatedRez(int page, int pageSize) {
            Console.WriteLine("Calling DB paginated rez frontend");
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44303/api/adreses/paginatedRez?" +
                "?page=" + page +
                "&pageSize=" + pageSize
            );
            var response = await client.SendAsync(request);

            JsonDocument jsonDocument;

            if (response.IsSuccessStatusCode) {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                if (response.Headers.TryGetValues("Pagination", out IEnumerable<string> values)) {
                    string session = values.First();
                    Response.Headers.Add("Pagination", session);
                } else StatusCode(500); //internal server error

                string jsonString = await response.Content.ReadAsStringAsync();
                jsonDocument = JsonDocument.Parse(jsonString);

            } else {
                jsonDocument = null;
            }
            return jsonDocument;
        }



        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Ciemi() {
            ViewBag.novadi = await GetNovadiOnly();
            return View();
        }

        public async Task<IActionResult> NekustamasLietas() {
            ViewBag.novadi = await GetNovadiOnly();
            return View();
        }

        public async Task<IActionResult> Dokumenti() {
            ViewBag.novadi = await GetNovadi();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Excel(int novadsID, int? pagastsID = null) {
            CreateJson createJson = new CreateJson(_clientFactory);
            //izveidojam excel workbook
            XLWorkbook wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Sheet");

            string fileName;

            //ciemi
            if (pagastsID == null) {
                fileName = "ciemuSaraksts.xlsx";
                //web requests uz backendu
                string url = "https://localhost:44303/api/Adreses/PagastiCiemi/NovadsID=" + novadsID;

                JArray ciemiJArray = await createJson.GetJsonArray(url);

                ws.Cell(1, 1).Value = "Ciemu saraksts novadā " + novadsID;
                ws.Cell(3, 1).Value = "Pagasts";
                ws.Cell(3, 2).Value = "Pagasta kods";
                ws.Cell(3, 3).Value = "Ciems";
                ws.Cell(3, 4).Value = "Ciema kods";
                ws.Cell(3, 5).Value = "Statuss";
                ws.Cell(3, 6).Value = "AR pēdējās veiktās izmaiņas";

                int totalCiemiCount = 0;

                for (int i = 0; i < ciemiJArray.Count(); i++) {
                    for (int j = 0; j < ciemiJArray[i]["arg_AdreseCiemi"].Count(); j++) {
                        totalCiemiCount++;
                        int row = totalCiemiCount + 3;
                        ws.Cell(row, 1).Value = (string)ciemiJArray[i]["std"]; //pagasts
                        ws.Cell(row, 2).Value = (string)ciemiJArray[i]["adR_CD"]; //pagasta kods
                        ws.Cell(row, 3).Value = (string)ciemiJArray[i]["arg_AdreseCiemi"][j]["std"]; //ciems
                        ws.Cell(row, 4).Value = (string)ciemiJArray[i]["arg_AdreseCiemi"][j]["adR_CD"]; //ciema id
                        ws.Cell(row, 5).Value = (string)ciemiJArray[i]["arg_AdreseCiemi"][j]["statuss"]; //statuss

                        JToken datMod = ciemiJArray[i]["arg_AdreseCiemi"][j]["daT_MOD"];
                        ws.Cell(row, 6).Value = datMod.HasValues ? (string)datMod : "Nav datu"; //pēd. veiktās izmaiņas
                    }
                }

                //ciemi specific formatting

                IXLRange dataRange = ws.Range(ws.Cell(4, 1).Address, ws.Cell(totalCiemiCount + 3, 6).Address);

                dataRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                dataRange.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                dataRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;


            }

            //nekustamas lietas
            else {
                fileName = "nLietuSaraksts.xlsx";

                string url = "https://localhost:44303/api/ArtNlietas/NLbyPagastsID/" + pagastsID;

                JArray jArray = await createJson.GetJsonArray(url);

                ws.Cell(1, 1).Value = "NL novads " + novadsID + " ; pagasts " + pagastsID;

                ws.Cell(3, 1).Value = "Adrese";
                ws.Cell(3, 2).Value = "Kods";
                ws.Cell(3, 3).Value = "Nekustama lieta";
                ws.Cell(3, 4).Value = "N/L kods";
                ws.Cell(3, 5).Value = "Statuss";
                ws.Cell(3, 6).Value = "AR pēdējās veiktās izmaiņas";

                int counter = 0;

                for (int i = 0; i < jArray.Count(); i++) {
                    counter++;
                    int row = counter + 3;

                    ws.Cell(row, 1).Value = "";
                    ws.Cell(row, 2).Value = "";
                    ws.Cell(row, 3).Value = (string)jArray[i]["nosaukums"];
                    ws.Cell(row, 4).Value = (string)jArray[i]["kods"];
                    ws.Cell(row, 5).Value = (string)jArray[i]["statuss"];
                    ws.Cell(row, 6).Value = (string)jArray[i]["daT_MOD"];
                }


            }

            //formatting
            ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Range("A1:F1").Merge();
            ws.Cell(1, 1).Style.Font.FontSize = 16;
            ws.Cell(1, 1).Style.Font.SetBold();

            ws.Range("A3:F3").Style.Border.BottomBorder = XLBorderStyleValues.Thick;
            ws.Range("A3:F3").Style.Border.TopBorder = XLBorderStyleValues.Thick;
            ws.Range("A3:F3").Style.Border.RightBorder = XLBorderStyleValues.Thick;
            ws.Range("A3:F3").Style.Fill.BackgroundColor = XLColor.FromHtml("E1E1E1");
            ws.Range("A3:F3").Style.Font.Bold = true;

            ws.Columns("1,2,3,4,5,6").AdjustToContents();


            //download stream
            using var stream = new MemoryStream();
            wb.SaveAs(stream);
            var content = stream.ToArray();

            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileName);
        }

        [HttpGet]
        [Route("NLietuSaraksts")]
        public async Task<JsonDocument> NLietuSaraksts() {
            CreateJson createJson = new CreateJson(_clientFactory);
            string url = "";
            JsonDocument jsonDocument = await createJson.GetJsonDocument(url);
            return jsonDocument;
        }
    }
}
