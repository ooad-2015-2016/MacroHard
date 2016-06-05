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
using Windows.Data.Json;
using System.Collections.ObjectModel;

namespace ShEM.ViewModel
{
    public class MyCollectionsViewModel
    {
       // public List<Collection> Mycollections {  get; set; }
        public ObservableCollection<Collection> Mycollections { get; set; }

        private StaticVariablesClass statika = new StaticVariablesClass();

        public MyCollectionsViewModel()
        {
            // Mycollections = new List<Collection>();
            Mycollections = new ObservableCollection<Collection>();
        }
        public async void povuciKolekcije()
        {
            HttpClient client = new HttpClient();

            String query = "UserCollections?" + "id=" + statika.userID.ToString();
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
                    JsonArray CollectionData = JsonValue.Parse(stream).GetArray();
                    Mycollections.Clear();
                    for (uint i = 0; i < CollectionData.Count; i++)
                    {
                        int id = (int)CollectionData.GetObjectAt(i).GetNamedNumber("id");
                        String name = CollectionData.GetObjectAt(i).GetNamedString("collection_name");
                        IJsonValue nullalbedescription = CollectionData.GetObjectAt(i).GetNamedValue("description");
                        String description = "";
                        if (nullalbedescription.ValueType != JsonValueType.Null)
                        {
                            description = nullalbedescription.GetString();
                        }          
                        int visibleinteger  = (int)CollectionData.GetObjectAt(i).GetNamedNumber("visible");
                        Boolean visible = false;
                        if (visibleinteger == 1)
                        {
                            visible = true;
                        }
                        Mycollections.Add(new Collection(id, name, description, visible));
                    }
                  //  return Mycollections;

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
            }

        }
    }
    }

