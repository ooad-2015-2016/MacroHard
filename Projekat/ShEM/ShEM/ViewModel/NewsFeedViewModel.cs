using System;
using System.Collections.Generic;
using ShEM.Model;
using System.Net.Http;
using System.IO;
using System.Runtime.Serialization.Json;
using Windows.UI.Popups;
using System.Collections.ObjectModel;
using ShEM.BazaPodataka.Static_variables;
using System.Net.Http.Headers;
using Windows.Data.Json;

namespace ShEM.ViewModel
{
    class NewsFeedViewModel
    {
        public List<User> users { get; set; }
        public ObservableCollection<Collection> collectionFeed { get; set; }

        public StaticVariablesClass statika = new StaticVariablesClass();
        public NewsFeedViewModel()
        {
            collectionFeed = new ObservableCollection<Collection>();
        }


        public async void getNewsFeed()
        {
            HttpClient client = new HttpClient();

            String query = "NewsFeed?" + "id=" + statika.userID.ToString();
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
                    collectionFeed.Clear();
                    for (uint i = 0; i < CollectionData.Count; i++)
                    {
                        int id = (int)CollectionData.GetObjectAt(i).GetNamedNumber("id");
                        String name = CollectionData.GetObjectAt(i).GetNamedString("name");
                        IJsonValue nullalbedescription = CollectionData.GetObjectAt(i).GetNamedValue("description");
                        String description = "";
                        if (nullalbedescription.ValueType != JsonValueType.Null)
                        {
                            description = nullalbedescription.GetString();
                        }
                        //int visibleinteger = (int)CollectionData.GetObjectAt(i).GetNamedNumber("visible");
                        //Boolean visible = false;
                        //if (visibleinteger == 1)
                        //{
                        //    visible = true;
                        //}
                        collectionFeed.Add(new Collection(id, name, description, true));
                    }

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
        public async void LikeCollection(string collectionID)
        {
            HttpClient client = new HttpClient();

            String query = "like?" + "id=" + statika.userID.ToString() + "&collection_id="+ collectionID;
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

                    var dialog = new MessageDialog("Succecfully Liked!");
                    await dialog.ShowAsync();
                }
                else
                {
                    var dialog = new MessageDialog("Colleciton already like!");
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
