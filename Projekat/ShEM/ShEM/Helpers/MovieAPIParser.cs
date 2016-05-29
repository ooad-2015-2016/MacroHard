using Newtonsoft.Json;
using ShEM.BazaPodataka.Static_variables;
using ShEM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;


namespace ShEM.Helpers
{
    public class MovieAPIParser
    {

        StaticVariablesClass statika;
        public MovieAPIParser()
        {
            statika = new StaticVariablesClass();
        }
        public async Task<Movie> getMovie(string search)
        {
            Movie film = new Movie();
            try
            {
                var client = new HttpClient();
                var address = new Uri(statika.MovieAPI + search + statika.MovieAPIAdditions);
                HttpResponseMessage response = await client.GetAsync(address);
                String stream = await response.Content.ReadAsStringAsync();
                dynamic dyn = JsonConvert.DeserializeObject(stream);
                if (dyn != null)
                {
                    film.articleName = dyn.Title.ToString();
                    film.duration = dyn.Runtime.ToString();
                    film.synopsys = dyn.Plot.ToString();
                    film.director = dyn.Director.ToString();
                    film.yearOfRelease = dyn.Year.ToString();
                    HttpClient wClient = new HttpClient();
                    film.image = await wClient.GetByteArrayAsync(dyn.Poster.ToString());
                }

                else
                {
                    var dialog = new MessageDialog("Nothing has been found. Please try again!");
                    await dialog.ShowAsync();
                }
            }
            catch (Exception e)
            {
                var dialog = new MessageDialog(e.Message);
                await dialog.ShowAsync();
            }
            return film;
        }
    }
}

