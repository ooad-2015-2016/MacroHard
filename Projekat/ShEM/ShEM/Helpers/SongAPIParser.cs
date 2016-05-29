using Newtonsoft.Json;
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
    public class SongAPIParser
    {
        StaticVariablesClass statika;
        public SongAPIParser()
        {
            statika = new StaticVariablesClass();
        }
        public async Task<Song> getSong(string search)
        {
            Song song = new Song();
            try
            {
                var client = new HttpClient();
                var address = new Uri(statika.SongAPI + search + statika.SongAPIAdditions);
                HttpResponseMessage response = await client.GetAsync(address);
                String stream = await response.Content.ReadAsStringAsync();
                dynamic dyn = JsonConvert.DeserializeObject(stream);
                dynamic obj = dyn["tracks"];
                foreach (var objekat in obj["items"])
                {

                    song.articleName = objekat["name"];
                    string izvodjaci = " ";
                    foreach (var umjetnik in objekat["artists"])
                        izvodjaci += (umjetnik["name"] + (" "));
                    song.performer = izvodjaci;
                    var ob = objekat["album"];
                    string url = ob["images"][0]["url"];
                    HttpClient wClient = new HttpClient();
                    song.image = await wClient.GetByteArrayAsync(url);
                }

            }
            catch (Exception e)
            {
                var dialog = new MessageDialog(e.Message);
                await dialog.ShowAsync();
            }
            return song;
        }
    }
}
