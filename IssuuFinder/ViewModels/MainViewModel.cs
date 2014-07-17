using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using IssuuFinder.Resources;
using System.Net;
using Newtonsoft.Json;

namespace IssuuFinder.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<IssuuDocument>();
        }

        /// <summary>
        /// Raccolta per oggetti ItemViewModel.
        /// </summary>
        public ObservableCollection<IssuuDocument> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Proprietà ViewModel di esempio: questa proprietà viene utilizzata per visualizzare il relativo valore mediante un'associazione
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        /// <summary>
        /// Proprietà di esempio che restituisce una stringa localizzata
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Crea e aggiunge alcuni oggetti ItemViewModel nella raccolta di elementi.
        /// </summary>
        public void LoadData()
        {
            WebClient webclient = new WebClient();
            webclient.DownloadStringCompleted += webclient_DownloadStringCompleted;
            webclient.DownloadStringAsync(new Uri("http://search.issuu.com/api/2_0/document"));
        }

        private void webclient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Result))
            {
                IssuuResponse root = JsonConvert.DeserializeObject<IssuuResponse>(e.Result);
                this.Items = new ObservableCollection<IssuuDocument>(root.Response.Docs);
            }
            
            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}