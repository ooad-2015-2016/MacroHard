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
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace ShEM.ViewModel
{
    public class BookViewModel
    {
        public Book book { get; set; }
        public BookAPIParser api { get; set; }
        public ImageSource Poster { get; set; }
        public string naziv { get; set; }
        public BookViewModel()
        {
            book = new Book();
            api = new BookAPIParser();
        }

        public async Task getBook()
        {
            book = await api.getBook(naziv);
            await LoadImageAsync();

        }


        private async Task LoadImageAsync()
        {
            using (InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream())
            {
                // Writes the image byte array in an InMemoryRandomAccessStream
                // that is needed to set the source of BitmapImage.
                using (DataWriter writer = new DataWriter(ms.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(book.image);
                    await writer.StoreAsync();
                }

                var image = new BitmapImage();
                await image.SetSourceAsync(ms);
                Poster = image;
            }
        }
    }
}
