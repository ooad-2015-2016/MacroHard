﻿using Newtonsoft.Json;
using ShEM.BazaPodataka.Static_variables;
using ShEM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace ShEM.Helpers
{
    public class BookAPIParser
    {
        StaticVariablesClass statika;
        public BookAPIParser()
        {
            statika = new StaticVariablesClass();
        }
        public async Task<Book> getBook(string search)
        {
            Book book = new Book();
            try
            {
                var client = new HttpClient();
                var address = new Uri(statika.BookAPI+ search + statika.BookAPIAdditions);
                HttpResponseMessage response = await client.GetAsync(address);
                String stream = await response.Content.ReadAsStringAsync();
                dynamic dyn = JsonConvert.DeserializeObject(stream);
                foreach (var objekat in dyn["items"])
                {
                    var obj = objekat["volumeInfo"];
                    book.articleName = obj["title"];
                    string pisci = " ";
                    foreach (var umjetnik in obj["authors"])
                        pisci += (umjetnik + (" "));
                    book.author = pisci;
                    book.publisher = obj["publisher"];
                    book.synopsys = obj["description"];
                    var ob = obj["imageLinks"];
                    string url = ob["thumbnail"];
                    HttpClient wClient = new HttpClient();
                    book.image = await wClient.GetByteArrayAsync(url);
                }

            }
            catch (Exception e)
            {
                var dialog = new MessageDialog(e.Message);
                await dialog.ShowAsync();
            }
            return book;
        }
    }
}
