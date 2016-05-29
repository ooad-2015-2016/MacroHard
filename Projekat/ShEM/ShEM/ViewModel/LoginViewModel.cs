using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShEM.Model;
using System.Windows;
using Windows.UI.Popups;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json.Serialization;
using Windows.Data.Json;
using ShEM.BazaPodataka.Static_variables;

namespace ShEM.ViewModel
{
    public class LoginViewModel
    {
        private string userInfo;
        private string pass;
        User user = new User();
        StaticVariablesClass statika = new StaticVariablesClass();


        public LoginViewModel(string info, string pass)
        {
            this.userInfo = info;
            this.pass = pass;
        }

        public async void passVerification()
        {
            if (pass.Length < 6)
            {
                var dialog = new MessageDialog("Your password must be at least 6 chracters long");
                await dialog.ShowAsync();
            }
        }

        public async void povuciUsera()
        {
            HttpClient client = new HttpClient();
            try {
                HttpResponseMessage msg = await client.GetAsync(statika.getIP + statika.getPort.ToString()); //treba dodati korektan url
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("aplication/json"));
                if (msg.IsSuccessStatusCode)
                {
                    MemoryStream ms = new MemoryStream();
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(User));
                    serializer.WriteObject(ms, msg);
                    user = (User)serializer.ReadObject(ms);
                }
                else
                {
                    var dialog = new MessageDialog("Your access data is not valid, please try again");
                    await dialog.ShowAsync();
                }
                this.assignUser();
            }
            catch (HttpRequestException e)
            {
                var dialog = new MessageDialog(e.StackTrace.ToString());
                await dialog.ShowAsync();
            }            
        }

        public void assignUser()
        {
            statika.userID = user.userID;
            statika.username = user.username;
            statika.password = user.password;
            statika.profilePic = user.profilePic;
            statika.collections = user.collections;
            statika.email = user.email;
        }
    }
}
