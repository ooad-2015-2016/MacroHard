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
        SearchResultViewModel srvm;
        List<Collection> MyCollections;
        int state = 1;
        StaticVariablesClass statika = new StaticVariablesClass();
        public NewsFeed()
        {
            this.InitializeComponent();
            nfvm = new NewsFeedViewModel();
            mcvm = new MyCollectionsViewModel();
            srvm = new SearchResultViewModel();
            MyCollections = new List<Collection>();
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
            SearchResultsPanel.Visibility = Visibility.Collapsed;
            MyCollectionsPanel.Visibility = Visibility.Collapsed;
            SettingsPanel.Visibility = Visibility.Collapsed;
            NewsFeedPanel.Visibility = Visibility.Visible;
            nfvm.getNewsFeed();
            NewsFeedPanel.DataContext = nfvm;


        }
        private void MyCollectionsClick(object sender, RoutedEventArgs e)
        {
            SearchResultsPanel.Visibility = Visibility.Collapsed;
            NewsFeedPanel.Visibility = Visibility.Collapsed;
            SettingsPanel.Visibility = Visibility.Collapsed;
            MyCollectionsPanel.Visibility = Visibility.Visible;
            mcvm.povuciKolekcije();
            MyCollectionsPanel.DataContext = mcvm;
        }
        private void HelpCLick(object sender, RoutedEventArgs e)
        {

            Frame currentFrame = Window.Current.Content as Frame;
            currentFrame.Navigate(typeof(Help));
        }
        private void SettingsClick(object sender, RoutedEventArgs e)
        {
            SearchResultsPanel.Visibility = Visibility.Collapsed;

            NewsFeedPanel.Visibility = Visibility.Collapsed;
            MyCollectionsPanel.Visibility = Visibility.Collapsed;
            SettingsPanel.Visibility = Visibility.Visible;

            ChangeUsername.Text = statika.username;
            ChangeEmail.Text = statika.email;

        }

        private void Trazi(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
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
            }
        }

        private void Search_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
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
            else {
                MyCollectionsPanel.Visibility = Visibility.Collapsed;
                SettingsPanel.Visibility = Visibility.Collapsed;
                NewsFeedPanel.Visibility = Visibility.Collapsed;
                SearchResultsPanel.Visibility = Visibility.Visible;
                srvm.Pretrazi(statika.Search);
                SearchResultsPanel.DataContext = srvm;


            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button mojBTN = (Button)sender;
            System.Diagnostics.Debug.WriteLine(mojBTN.Tag.ToString());
            srvm.FollowUsera(mojBTN.Tag.ToString());
          //  mojBTN.IsEnabled = false;

        }

        private void LikeCollection(object sender, RoutedEventArgs e)
        {
            Button mojBTN = (Button)sender;
            System.Diagnostics.Debug.WriteLine(mojBTN.Tag.ToString());
            nfvm.LikeCollection(mojBTN.Tag.ToString());
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
