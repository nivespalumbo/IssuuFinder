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
            _items = new ObservableCollection<IssuuDocument>();
        }

        /// <summary>
        /// Raccolta per oggetti ItemViewModel.
        /// </summary>
        private ObservableCollection<IssuuDocument> _items;

        private ObservableCollection<IssuuDocument> _searchResults;

        

        public ObservableCollection<IssuuDocument> Items
        {
            get
            {
                return _items;
            }
            private set
            {
                if (value != _items)
                {
                    _items = value;
                    NotifyPropertyChanged("Items");
                }
            }
        }
        
        public ObservableCollection<IssuuDocument> SearchResults
        {
            get 
            {
                return _searchResults;
            }
            set 
            {
                if (value != _searchResults)
                {
                    _searchResults = value;
                    NotifyPropertyChanged("SearchResults");
                }
            }
        }

        //private string _sampleProperty = "Sample Runtime Property Value";
        ///// <summary>
        ///// Proprietà ViewModel di esempio: questa proprietà viene utilizzata per visualizzare il relativo valore mediante un'associazione
        ///// </summary>
        ///// <returns></returns>
        //public string SampleProperty
        //{
        //    get
        //    {
        //        return _sampleProperty;
        //    }
        //    set
        //    {
        //        if (value != _sampleProperty)
        //        {
        //            _sampleProperty = value;
        //            NotifyPropertyChanged("SampleProperty");
        //        }
        //    }
        //}

        ///// <summary>
        ///// Proprietà di esempio che restituisce una stringa localizzata
        ///// </summary>
        //public string LocalizedSampleProperty
        //{
        //    get
        //    {
        //        return AppResources.SampleProperty;
        //    }
        //}

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData()
        {
            WebClient webclient = new WebClient();
            webclient.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) => {
                if (!string.IsNullOrEmpty(e.Result))
                {
                    IssuuResponse root = JsonConvert.DeserializeObject<IssuuResponse>(e.Result);
                    Items = new ObservableCollection<IssuuDocument>(root.Response.Docs);
                }
            
                this.IsDataLoaded = true;
            };
            webclient.DownloadStringAsync(new Uri("http://search.issuu.com/api/2_0/document"));
        }

        public void Search(string key)
        {
            WebClient webclient = new WebClient();
            webclient.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) =>
            {
                if (!string.IsNullOrEmpty(e.Result))
                {
                    IssuuResponse root = JsonConvert.DeserializeObject<IssuuResponse>(e.Result);
                    SearchResults = new ObservableCollection<IssuuDocument>(root.Response.Docs);
                }

                this.IsDataLoaded = true;
            };
            webclient.DownloadStringAsync(new Uri("http://search.issuu.com/api/2_0/document?q="+key));
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