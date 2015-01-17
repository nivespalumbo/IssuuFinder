using IssuuFinder.Model;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// Il modello di elemento per la pagina vuota è documentato all'indirizzo http://go.microsoft.com/fwlink/?LinkID=390556

namespace IssuuFinder
{
    /// <summary>
    /// Pagina vuota che può essere utilizzata autonomamente oppure esplorata all'interno di un frame.
    /// </summary>
    public sealed partial class DocumentDetailPage : Page
    {
        private IssuuDocument _document;

        public DocumentDetailPage()
        {
            this.InitializeComponent();
        }

        public IssuuDocument Document
        {
            get { return _document; }
        }

        /// <summary>
        /// Richiamato quando la pagina sta per essere visualizzata in un Frame.
        /// </summary>
        /// <param name="e">Dati dell'evento in cui vengono descritte le modalità con cui la pagina è stata raggiunta.
        /// Questo parametro viene in genere utilizzato per configurare la pagina.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _document = e.Parameter as IssuuDocument;
            if (_document == null) 
                return;
            
            txDocname.Text = _document.Docname;
            txEditor.Text = _document.Username;
            Uri url =
                new Uri("http://issuu.com/" + _document.Username + "/docs/" + _document.Docname);
            webView.Navigate(url);
        }
    }
}
