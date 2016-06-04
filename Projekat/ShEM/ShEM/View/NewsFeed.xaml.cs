using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ShEM.ViewModel;
using ShEM.BazaPodataka.Static_variables;
using ShEM.Model;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ShEM.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewsFeed : Page
    {
        
        NewsFeedViewModel nfvm;
        MyCollectionsViewModel mcvm;
        List<Collection> MyCollections;
        int state = 1;
        StaticVariablesClass statika = new StaticVariablesClass();
        public NewsFeed()
        {
            this.InitializeComponent();
            nfvm = new NewsFeedViewModel();
            mcvm = new MyCollectionsViewModel();
            nfvm.getAllFriends();
            MyCollections = new List<Collection>();
        }

        private void PeopleCheck(object sender, RoutedEventArgs e)
        {

            //SongsCheckBox.IsChecked = false;
            //BooksCheckBox.IsChecked = false;
            //MoviesCheckBox.IsChecked = false;
        }

        private void BooksCheck(object sender, RoutedEventArgs e)
        {
            //SongsCheckBox.s
            //SongsCheckBox.IsChecked = false;
            //PeopleCheckBox.IsChecked = false;
            //MoviesCheckBox.IsChecked = false;
        }

        private void SongsCheck(object sender, RoutedEventArgs e)
        {
            //SongsCheckBox.IsChecked = true;
            //BooksCheckBox.IsChecked = false;
            //PeopleCheckBox.IsChecked = false;
            //MoviesCheckBox.IsChecked = false;
        }

        private void MoviesCheck(object sender, RoutedEventArgs e)
        {

            //SongsCheckBox.IsChecked = false;
            //BooksCheckBox.IsChecked = false;
            //PeopleCheckBox.IsChecked = false;
            //MoviesCheckBox.IsChecked = true;

        }

        private void LogoutClick(object sender, RoutedEventArgs e)
        {
            statika.userID = -1;
            statika.email = null;
            statika.username = null;
            Frame currentFrame = Window.Current.Content as Frame;
            currentFrame.Navigate(typeof(Login));

        }

        private void NewsFeedClick(object sender, RoutedEventArgs e)
        {
            MyCollectionsPanel.Visibility = Visibility.Collapsed;
            NewsFeedPanel.Visibility = Visibility.Visible;
        }
        private async void MyCollectionsClick(object sender, RoutedEventArgs e)
        {
            NewsFeedPanel.Visibility = Visibility.Collapsed;
            MyCollectionsPanel.Visibility = Visibility.Visible;
            mcvm.povuciKolekcije();

            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            statika.Search = Search.Text.ToString();
            if (BooksCheckBox.IsChecked == true)
            {                
                Frame currentFrame = Window.Current.Content as Frame;
                currentFrame.Navigate(typeof(Book));
            }
            else if (MoviesCheckBox.IsChecked == true)
            {
                Frame currentFrame = Window.Current.Content as Frame;
                currentFrame.Navigate(typeof(Movie));
            }
            else if (SongsCheckBox.IsChecked == true)
            {
                Frame currentFrame = Window.Current.Content as Frame;
                currentFrame.Navigate(typeof(Song));
            }
            else { }
        }
    }
}
