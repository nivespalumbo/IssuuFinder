﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using IssuuFinder.Resources;
using IssuuFinder.ViewModels;

namespace IssuuFinder
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Costruttore
        public MainPage()
        {
            InitializeComponent();

            // Impostare il contesto dei dati nel controllo casella di riepilogo su dati di esempio
            DataContext = App.ViewModel;

            // Codice di esempio per localizzare la ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Caricare i dati per gli elementi ViewModel
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void DocumentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (documentList.SelectedItem == null)
                return;
            
            IssuuDocument item = documentList.SelectedItem as IssuuDocument;

            NavigationService.Navigate(new Uri("/DocumentDetail.xaml", UriKind.Relative));

            // Reset selected item to null
            documentList.SelectedItem = null;
        }

        // Codice di esempio per la realizzazione di una ApplicationBar localizzata
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Imposta la barra delle applicazioni della pagina su una nuova istanza di ApplicationBar
        //    ApplicationBar = nuova ApplicationBar();

        //    // Crea un nuovo pulsante e imposta il valore del testo sulla stringa localizzata da AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Crea una nuova voce di menu con la stringa localizzata da AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}