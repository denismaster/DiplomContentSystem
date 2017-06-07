using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace DiplomContentSystem.Requests
{
    public class RequestService
    {
        public async Task<Stream> SendRequest(object data)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var content = new StringContent(JsonConvert.SerializeObject(data,
                    new JsonSerializerSettings()
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver() 
                    }), System.Text.Encoding.UTF8, "application/json");
                    client.BaseAddress = new Uri("http://localhost:1337");
                    
                    var response = await client.PostAsync("api/docx",content);
                    response.EnsureSuccessStatusCode(); // Throw in not success

                    return await response.Content.ReadAsStreamAsync();
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request exception: {e.Message}");
                    throw (e);
                }
            }
        }
    }
}
