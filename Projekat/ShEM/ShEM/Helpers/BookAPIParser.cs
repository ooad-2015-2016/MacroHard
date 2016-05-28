using Newtonsoft.Json;
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
        Book book;
        public async void getBook(string search)
        {
            try
            {

                var client = new HttpClient();
                var address = new Uri("https://ajax.googleapis.com/ajax/services/search/web?v=1.0&q=" + search);
                HttpResponseMessage response = await client.GetAsync(address);
                String stream = await response.Content.ReadAsStringAsync();
                dynamic dyn = JsonConvert.DeserializeObject(stream);
                if (dyn != null)
                {
                    book.articleName = dyn.Title.ToString();
                    //book.authorn = dyn.Author.ToString();
                    //film.duration = broj;
                    //film.synopsys = dyn.Plot.ToString();
                    //film.director = dyn.Director.ToString();
                    //film.yearOfRelease = dyn.Year.ToString();
                    //film.genre = dyn.Genre.ToString();
                    //  film.articleID = dyn.imdbID.ToString();
                    /*    string slika = dyn.Poster.ToString();
                        WebClient webClient = new WebClient();
                        still not sure how to do this
                           webClient.DownloadFile(slika, film.image);
                       */


                }

                else
                {
                    var dialog = new MessageDialog("Nothing has been found. Please try again!");
                    await dialog.ShowAsync();
                }
            }
            catch (Exception e)
            {
                var dialog = new MessageDialog("Nothing has been found. Please try again!");
                await dialog.ShowAsync();
            }

        }
    }
}
