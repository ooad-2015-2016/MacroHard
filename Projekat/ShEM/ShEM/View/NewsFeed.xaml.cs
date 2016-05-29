﻿using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ShEM.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewsFeed : Page
    {
        NewsFeedViewModel nfvm;
        public NewsFeed()
        {
            this.InitializeComponent();
            nfvm = new NewsFeedViewModel();
            nfvm.getAllFriends();
        }

        private void PeopleCheck(object sender, RoutedEventArgs e)
        {


        }

        private void BooksCheck(object sender, RoutedEventArgs e)
        {

        }

        private void SongsCheck(object sender, RoutedEventArgs e)
        {

        }

        private void MoviesCheck(object sender, RoutedEventArgs e)
        {

        }
    }
}
