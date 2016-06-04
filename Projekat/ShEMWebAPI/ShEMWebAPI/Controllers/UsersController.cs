using Newtonsoft.Json;
using ShEMWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShEMWebAPI.Controllers
{
    public class UsersController : ApiController
    {
        List<User> users = new List<User>();

        public async Task<List<User>> GetAllUsers()
        {
           
            HttpClient client = new HttpClient();

            String query = "AllUsers";
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
                        User user = new User();
                        user.UserID = obj["id"];
                        user.Email = obj["email"];
                        user.Username = obj["username"];
                        users.Add(user);
                    }
                }

            }
            catch (HttpRequestException e)
            {
                //nisam 100% šta treba da ovo vrati
            }
            return users;
        }
       
        //public IHttpActionResult GetUser(int id)
        //{
        //    var user = users.FirstOrDefault((p) => p.UserID == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(user);
        //}
    }
}

