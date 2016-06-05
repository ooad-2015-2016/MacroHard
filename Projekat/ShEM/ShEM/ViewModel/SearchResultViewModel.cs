using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShEM.Model;
using System.Net.Http;
using Windows.UI.Popups;
using ShEM.BazaPodataka.Static_variables;
using System.Net.Http.Headers;
using Windows.Data.Json;
using System.Collections.ObjectModel;

namespace ShEM.ViewModel
{
    class SearchResultViewModel
    {
        public ObservableCollection<User> rezultat { get; set; }
        public StaticVariablesClass statika = new StaticVariablesClass();

        public SearchResultViewModel()
        {
            rezultat = new ObservableCollection<User>();
        }

        public async void Pretrazi(string pretraga)
        {
            HttpClient client = new HttpClient();

            String query = "search?q=" + pretraga;

            System.Diagnostics.Debug.WriteLine(query);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("http://" + statika.getIP + statika.getPort.ToString() + "/");
            try
            {
                HttpResponseMessage msg = await client.GetAsync(query);
                if (msg.IsSuccessStatusCode)
                {
                    String stream = await msg.Content.ReadAsStringAsync();
                    JsonArray searchData = JsonValue.Parse(stream).GetArray();
                    rezultat.Clear();
                    for (uint i = 0; i < searchData.Count; i++)
                    {
                        JsonObject singleUser= searchData.GetObjectAt(i);
                        int id = (int)singleUser.GetNamedNumber("id");
                        String name = singleUser.GetNamedString("USERNAME");
                        String email = singleUser.GetNamedString("EMAIL");
                       // String picture = singleUser.GetNamedValue("")
                        rezultat.Add(new User(id,name,email));
                    }
                    var dialog = new MessageDialog("Succecfully Sumbited");
                    await dialog.ShowAsync();

                }
                else
                {
                    var dialog = new MessageDialog("Server error");
                    await dialog.ShowAsync();
                    //  return new List<Collection>();            
                }
            }
            catch (HttpRequestException e)
            {
                var dialog = new MessageDialog(e.StackTrace.ToString());
                await dialog.ShowAsync();
                // return new List<Collection>();
            }

        }
        public async void FollowUsera(string id)
        {
            HttpClient client = new HttpClient();

            String query = "follow?id="+ statika.userID.ToString() + "&friend_id=" + id.ToString();

            System.Diagnostics.Debug.WriteLine(query);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("http://" + statika.getIP + statika.getPort.ToString() + "/");
            try
            {
                HttpResponseMessage msg = await client.GetAsync(query);
                if (msg.IsSuccessStatusCode)
                {
       
                    var dialog = new MessageDialog("Succecfully Followed!");
                    await dialog.ShowAsync();

                }
                else
                {
                    var dialog = new MessageDialog("User already followed!");
                    await dialog.ShowAsync();
                    //  return new List<Collection>();            
                }
            }
            catch (HttpRequestException e)
            {
                var dialog = new MessageDialog(e.StackTrace.ToString());
                await dialog.ShowAsync();
                // return new List<Collection>();
            }
        }


    }


}
