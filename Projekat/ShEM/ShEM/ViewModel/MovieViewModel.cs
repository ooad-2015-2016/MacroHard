using ShEM.Helpers;
using ShEM.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace ShEM.ViewModel
{
    public class MovieViewModel  
    {
        public Movie movie { get; set; }
        public MovieAPIParser api { get; set; }
        public ImageSource Poster { get; set; }
        public string naziv { get; set; }
        public MovieViewModel()
        {
            movie = new Movie();
            api = new  MovieAPIParser();
        }

        public async void getMovie()
        {
            movie = await api.getMovie(naziv);
            if (movie.image != null)
                 await LoadImageAsync();
        }

        private async Task LoadImageAsync()
        {
            using (InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(ms.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(movie.image);
                    await writer.StoreAsync();
                }
                var image = new BitmapImage();
                await image.SetSourceAsync(ms);
                Poster = image;
            }
        }
    }
}
