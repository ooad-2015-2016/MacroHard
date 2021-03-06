﻿using System;
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
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using ShEM.View;

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

            if (userInfo != null && pass != null && userInfo != "" && pass != "" && userInfo != " " && pass != " ")
            {
                String query = "login?" + "username=" + userInfo.Replace(' ', '+') + "&password=" + pass.Replace(' ', '+');
                System.Diagnostics.Debug.WriteLine(query);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri("http://" + statika.getIP + statika.getPort.ToString() + "/");
                try
                {
                    HttpResponseMessage msg = await client.GetAsync(query);
                    if (msg.IsSuccessStatusCode)
                    {
                        String stream = await msg.Content.ReadAsStringAsync();
                        dynamic dyn = JsonConvert.DeserializeObject(stream);
                        user.userID = dyn["id"];
                        user.email = dyn["email"];
                        user.username = dyn["username"];
                        Frame rFrame = Window.Current.Content as Frame;
                        rFrame.Navigate(typeof(NewsFeed));
                    }
                    else
                    {
                        //Vec gotova validacija na konto cinjenice da nece biti povuceni podaci o korisniku iz baze,
                        //vec ce se ispisati poruka o nepravilnosti unijetih podataka
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

            else
            {
                //validacija na konto cinjenice da se moze desiti da korisnik posalje zahtjev za login
                //medjutim nije unio sve potrebne podatke
                var dialog = new MessageDialog("There is some input data missing, please try again!");
                await dialog.ShowAsync();
            }
        }

        string retStr;
        public async Task<string> validirajEmailUsera(string _email)
        {
            HttpClient client = new HttpClient();

            String query = "login?" + "username=" + _email;
            System.Diagnostics.Debug.WriteLine(query);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("http://" + statika.getIP + statika.getPort.ToString() + "/");
            try
            {
                HttpResponseMessage msg = await client.GetAsync(query);
                if (msg.IsSuccessStatusCode)
                {
                    String stream = await msg.Content.ReadAsStringAsync();
                    dynamic dyn = JsonConvert.DeserializeObject(stream);
                    retStr = dyn["email"];
                }
                else
                {
                    var dialog = new MessageDialog("No such E-mail, please try again");
                    await dialog.ShowAsync();
                }
            }
            catch (HttpRequestException e)
            {
                var dialog = new MessageDialog(e.StackTrace.ToString());
                await dialog.ShowAsync();
            }
            return retStr;
        }

        public void assignUser()
        {
            statika.userID = user.userID;
            statika.username = user.username;
            statika.profilePic = user.profilePic;
            statika.collections = user.collections;
            statika.email = user.email;
        }        
    }
}
