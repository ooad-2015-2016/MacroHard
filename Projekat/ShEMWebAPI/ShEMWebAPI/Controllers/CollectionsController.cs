using ShEMWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using System.Json;
using Newtonsoft.Json.Linq;

namespace ShEMWebAPI.Controllers
{
    public class CollectionsController : ApiController
    {
        List<Collection> collections = new List<Collection>();

        public List<Collection> GetAllCollections()
        {
            return collections;
        }

        public  async Task<IHttpActionResult> GetCollections(int id)
        {
            HttpClient client = new HttpClient();

            String query = "UserCollections?" + "id=" + id.ToString() ;
            System.Diagnostics.Debug.WriteLine(query);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("http://192.168.1.6:3000/");
            try
            {
                HttpResponseMessage msg = await client.GetAsync(query); 
                if (msg.IsSuccessStatusCode)
                {
                    String stream = await msg.Content.ReadAsStringAsync();
                
                    dynamic dyn = JsonConvert.DeserializeObject(stream);
                    foreach (dynamic obj in dyn)
                    {
                        Collection nova = new Collection();
                        nova.CollectionID = obj["id"];
                        nova.Name = obj["collection_name"];
                        nova.Description = obj["description"];
                        nova.UserID = id.ToString();
                        collections.Add(nova);
                    }
                }
                
            }
            catch (HttpRequestException e)
            {
                return NotFound();
            }
            return Ok(collections);
        }
    }

}
