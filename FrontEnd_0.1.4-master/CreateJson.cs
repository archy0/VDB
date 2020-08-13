using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FrontEnd {
    public class CreateJson {

        private readonly IHttpClientFactory _clientFactory;

        public CreateJson(IHttpClientFactory clientFactory) {
            _clientFactory = clientFactory;
        }


        //generic asynchronous method with type constraint for JsonDocument, JsonArray, JsonObject c# asp net core mvc 3.1

        public async Task<JsonDocument> GetJsonDocument(string url){
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await client.SendAsync(request);

            JsonDocument jsonDocument;

            if (response.IsSuccessStatusCode) {
                string jsonString = await response.Content.ReadAsStringAsync();
                jsonDocument = JsonDocument.Parse(jsonString);
            } else {
                jsonDocument = null;
            }

            return jsonDocument;
        }

        public async Task<JArray> GetJsonArray(string url) {
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await client.SendAsync(request);

            JArray jArray;

            if (response.IsSuccessStatusCode) {
                string jsonString = await response.Content.ReadAsStringAsync();
                jArray = JArray.Parse(jsonString);
            } else {
                jArray = null;
            }

            return jArray;
        }
    }
}
