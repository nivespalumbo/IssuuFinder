using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using IssuuFinder.ViewModels;

namespace IssuuFinder
{
    public partial class DocumentDetail : PhoneApplicationPage
    {
        public DocumentDetail()
        {
            InitializeComponent();

            DataContext = App.DetailViewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (App.DetailViewModel.Document != null)
            {
                Uri url = new Uri("http://issuu.com/" + App.DetailViewModel.Document.Username + "/docs/" + App.DetailViewModel.Document.Docname);
                webview.Navigate(url);
            }
        }
    }
}