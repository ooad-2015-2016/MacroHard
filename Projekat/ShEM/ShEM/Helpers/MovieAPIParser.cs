using Newtonsoft.Json;
using ShEM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace ShEM.Helpers
{
   public class MovieAPIParser
    {
        Movie film;
        public async void getMovie(string search)
        {
            try
            {
                var client = new HttpClient();
                var address = new Uri("http://www.omdbapi.com/?t=" + search + "&y=&plot=short&r=json");
                HttpResponseMessage response = await client.GetAsync(address);
                String stream = await response.Content.ReadAsStringAsync();
                dynamic dyn = JsonConvert.DeserializeObject(stream);
                if (dyn != null)
                {
                    film.articleName = dyn.Title.ToString();
                    int broj;
                    Int32.TryParse(dyn.Runtime.ToString(),out broj);
                    film.duration = broj;
                    film.synopsys = dyn.Plot.ToString();
                    film.director = dyn.Director.ToString();
                    film.yearOfRelease = dyn.Year.ToString();
                    film.genre = dyn.Genre.ToString();
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

