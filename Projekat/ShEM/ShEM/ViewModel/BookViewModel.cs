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
using ShEM.BazaPodataka.Static_variables;
using System.Net.Http.Headers;
using Windows.Data.Json;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace ShEM.ViewModel
{
    public class BookViewModel
    {
        public Book book { get; set; }
        public BookAPIParser api { get; set; }
        public ImageSource Poster { get; set; }
        public string naziv { get; set; }
        public StaticVariablesClass statika = new StaticVariablesClass();

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
        public async void AddToCollection(int id)
        {
            HttpClient client = new HttpClient();

            String query = "AddBook?collection_id=" + id.ToString() + "&name=" + book.articleName.Replace(' ','+') + "&image=";
            if (book.image != null) { query += Convert.ToBase64String(book.image); }
            query += "&author=";
            if(book.author!= null) { query += book.author.Replace(' ','+'); }
            query += "&publisher=";
            if(book.publisher != null) { query += book.publisher.Replace(' ', '+'); }
            query += "&synopsys=";
            if(book._synopsys !=null) { query += book.synopsys.Replace(' ', '+'); }
            System.Diagnostics.Debug.WriteLine(query);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("http://" + statika.getIP + statika.getPort.ToString() + "/");
            try
            {
                HttpResponseMessage msg = await client.GetAsync(query);
                if (msg.IsSuccessStatusCode)
                {
                    var dialog = new MessageDialog("Succecfully Sumbited");
                    await dialog.ShowAsync();
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
                // return new List<Collection>();
            }

        }

    }
}
