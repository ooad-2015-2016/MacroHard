using ShEM.BazaPodataka.Static_variables;
using ShEM.ViewModel;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ShEM.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Movie : Page
    {
        MovieViewModel mvm;
        StaticVariablesClass statika = new StaticVariablesClass();
        public Movie()
        {
            this.InitializeComponent();
            mvm = new MovieViewModel();
            mvm.naziv = statika.Search;
            metoda();
        }
        public async void metoda()
        {
            await mvm.getMovie();
            DataContext = mvm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame currentFrame = Window.Current.Content as Frame;
            currentFrame.Navigate(typeof(NewsFeed));
        }
    }
}
