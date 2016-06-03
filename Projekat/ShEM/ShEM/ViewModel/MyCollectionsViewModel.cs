using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShEM.Model;
using ShEM.BazaPodataka.Static_variables;
using System.Net.Http;
using System.Net.Http.Headers;
using Windows.UI.Xaml;
using Newtonsoft.Json;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;

namespace ShEM.ViewModel
{
    public class MyCollectionsViewModel
    {
        public List<Collection> collections {  get; set; }
        private StaticVariablesClass statika = new StaticVariablesClass();

        public MyCollectionsViewModel()
        {
            collections = statika.collections;
        }
        public async void povuciKolekcije()
        {
            HttpClient client = new HttpClient();

            String query = "mycollections?" + "ID=" + statika.userID;
            System.Diagnostics.Debug.WriteLine(query);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("http://" + statika.getIP + statika.getPort.ToString() + "/");
            try
            {
                HttpResponseMessage msg = await client.GetAsync(query); //treba dodati korektan url

                //  client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("aplication/json"));
                if (msg.IsSuccessStatusCode)
                {
                    String stream = await msg.Content.ReadAsStringAsync();
                    dynamic dyn = JsonConvert.DeserializeObject(stream);
                    
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
