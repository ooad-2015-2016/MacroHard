using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ShEM.BazaPodataka.Static_variables;
using System.Net.Http;
using Newtonsoft.Json;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ShEM.View;
using Windows.UI.Popups;

namespace ShEM.ViewModel
{
    class RegisterViewModel
    {
        private string username;
        private string password;
        private string email;
        private StaticVariablesClass statika;
        public RegisterViewModel(string username, string email, string password)
        {
            this.username = username;
            this.password = password;
            this.email = email;
        }

        public async void RegistrujUsera()
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("http://" + statika.getIP + statika.getPort.ToString() + "/");
            String query = "register?" + "username=" + username.Replace(' ', '+') + "&email=" + password.Replace(' ','+') + "&password=" + password.Replace(' ', '+');
            try
            {
                HttpResponseMessage msg = await client.GetAsync(query); //treba dodati korektan url

                //  client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("aplication/json"));
                if (msg.IsSuccessStatusCode)
                {
                    String stream = await msg.Content.ReadAsStringAsync();
                    dynamic dyn = JsonConvert.DeserializeObject(stream);
        
                    Frame rootFrame = Window.Current.Content as Frame;
                    rootFrame.Navigate(typeof(NewsFeed));
                }
                else
                {
                    var dialog = new MessageDialog("Your access data is not valid, please try again");
                    await dialog.ShowAsync();
                }
             
            }
            catch (HttpRequestException e)
            {
                var dialog = new MessageDialog(e.StackTrace.ToString());
                await dialog.ShowAsync();
            }

        }
    }

}
