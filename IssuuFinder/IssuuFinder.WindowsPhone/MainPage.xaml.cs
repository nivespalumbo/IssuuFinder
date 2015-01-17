using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using IssuuFinder.Model;
using IssuuFinder.ViewModels;

// Il modello di elemento per la pagina vuota è documentato all'indirizzo http://go.microsoft.com/fwlink/?LinkId=234238

namespace IssuuFinder
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel _viewModel = App.MainVM;

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
            //this.Frame.Navigate(typeof(SearchPage));

        }

        private void ListViewBase_OnItemClick(object sender, ItemClickEventArgs e)
        {
            IssuuDocument doc = e.ClickedItem as IssuuDocument;
            this.Frame.Navigate(typeof (DocumentDetailPage), doc);
        }
    }
}
