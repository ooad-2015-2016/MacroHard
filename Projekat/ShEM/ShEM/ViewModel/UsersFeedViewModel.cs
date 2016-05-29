using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShEM.Model;
using System.Net.Http;
using System.IO;
using System.Runtime.Serialization.Json;
using Windows.UI.Popups;
using Shem.Helpers;
using ShEM.BazaPodataka.Static_variables;

namespace ShEM.ViewModel
{
    public class UsersFeedViewModel
    {
        private List<User> users { get; set; }
        StaticVariablesClass statika = new StaticVariablesClass();
        string username;

        public UsersFeedViewModel()
        {
            users = new List<User>();
            username = statika.username;
        }

        public async void povuciSvePrijatelje(string username)
        {
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage msg = await client.GetAsync(statika.getIP + statika.getPort.ToString()); //treba dodati korektan url
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("aplication/json"));
                if (msg.IsSuccessStatusCode)
                {
                    MemoryStream ms = new MemoryStream();
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<User>));
                    serializer.WriteObject(ms, msg);
                    users = (List<User>)serializer.ReadObject(ms);
                }
                else
                {
                    var dialog = new MessageDialog("Your access data is not valid, please try again");
                    await dialog.ShowAsync();
                }
            }
            catch (HttpRequestException e)
            {
                var dialog = new MessageDialog(e.StackTrace.ToString());
                await dialog.ShowAsync();
            }
        }
    }
}
