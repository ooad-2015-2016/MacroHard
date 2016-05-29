﻿using ShEM.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace ShEM.ViewModel
{
    public class BookViewModel
    {
        public Book book { get; set; }

        public async void getBook()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage msg = await client.GetAsync("url"); //url
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("aplication/json"));

            if (msg.IsSuccessStatusCode)
            {
                MemoryStream ms = new MemoryStream();
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Book));
                serializer.WriteObject(ms, msg);
                book = (Book)serializer.ReadObject(ms);
            }
            else
            {
                var dialog = new MessageDialog("Your access data is not valid, please try again");
                await dialog.ShowAsync();
            }
        }
    }
}