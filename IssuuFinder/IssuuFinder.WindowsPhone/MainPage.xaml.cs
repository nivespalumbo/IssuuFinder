﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// Il modello di elemento per la pagina vuota è documentato all'indirizzo http://go.microsoft.com/fwlink/?LinkId=234238
using IssuuFinder.Model;
using IssuuFinder.ViewModels;

namespace IssuuFinder
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel _viewModel = new MainViewModel();

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        public MainViewModel ViewModel
        {
            get { return _viewModel; }
            set { _viewModel = value; }
        }

        /// <summary>
        /// Richiamato quando la pagina sta per essere visualizzata in un Frame.
        /// </summary>
        /// <param name="e">Dati dell'evento in cui vengono descritte le modalità con cui la pagina è stata raggiunta.
        /// Questo parametro viene in genere utilizzato per configurare la pagina.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: preparare la pagina da visualizzare qui.
            if (!ViewModel.IsDataLoaded)
            {
                ViewModel.LoadData();
            }

            // TODO: se l'applicazione contiene più pagine, assicurarsi che si stia
            // gestendo il pulsante Indietro dell'hardware effettuando la registrazione per
            // l'evento Windows.Phone.UI.Input.HardwareButtons.BackPressed.
            // Se si utilizza l'elemento NavigationHelper fornito da alcuni modelli,
            // questo evento viene gestito automaticamente.
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SearchPage));

        }
    }
}
