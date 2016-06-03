using System;
using System.Collections.Generic;
using ShEM.Model;
using System.Net.Http;
using System.IO;
using System.Runtime.Serialization.Json;
using Windows.UI.Popups;

namespace ShEM.ViewModel
{
    class NewsFeedViewModel
    {
        public List<User> users { get; set; }
        public List<Collection> collection { get; set; }

        public async void getAllFriends()
        {
            /*
            HttpClient client = new HttpClient();
            HttpResponseMessage msg = await client.GetAsync("url"); //url
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("aplication/json"));

            if (msg.IsSuccessStatusCode)
            {
                MemoryStream ms = new MemoryStream();
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(User));
                serializer.WriteObject(ms, msg);
                users = (List<User>)serializer.ReadObject(ms);
            }
            else
            {
                var dialog = new MessageDialog("Your access data is not valid, please try again");
                await dialog.ShowAsync();
            }
            */
        }
    }
}
