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
    public sealed partial class BlankPage10 : Page
    {
        SongViewModel svm;
        public BlankPage10()
        {
            this.InitializeComponent();
            svm = new SongViewModel();
            svm.naziv = "baby one more time";
            metoda();
        }
        public async void metoda()
        {
            await svm.getSong();
            DataContext = svm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Play();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mediaElement1.Stop();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            mediaElement1.Pause();
        }
    }
}

