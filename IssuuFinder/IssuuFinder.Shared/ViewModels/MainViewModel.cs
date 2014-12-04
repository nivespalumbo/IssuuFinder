using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using IssuuFinder.Model;
using Newtonsoft.Json.Serialization;

namespace IssuuFinder.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            _items = new ObservableCollection<IssuuDocument>();
            _searchResults = new ObservableCollection<IssuuDocument>();
        }

        private ObservableCollection<IssuuDocument> _items;

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

        private ObservableCollection<IssuuDocument> _searchResults;

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

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public async void LoadData()
        {
            //WebClient webclient = new WebClient();
            //webclient.DownloadStringCompleted += (sender, e) =>
            //{
            //    if (!string.IsNullOrEmpty(e.Result))
            //    {
            //        IssuuResponse root = JsonConvert.DeserializeObject<IssuuResponse>(e.Result);
            //        Items = new ObservableCollection<IssuuDocument>(root.Response.Docs);
            //    }

            //    this.IsDataLoaded = true;
            //};

            //webclient.DownloadStringAsync(new Uri("http://search.issuu.com/api/2_0/document"));

            try
            {
                HttpClient httpClient = new HttpClient();
                string response =
                    await httpClient.GetStringAsync(new Uri("http://search.issuu.com/api/2_0/document?language=it&pageSize=30"));
                
                if (!string.IsNullOrEmpty(response))
                {
                    IssuuResponse root = JsonConvert.DeserializeObject<IssuuResponse>(response);
                    Items = new ObservableCollection<IssuuDocument>(root.Response.Docs);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        public void Search(string key)
        {
            //WebClient webclient = new WebClient();
            //webclient.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) =>
            //{
            //    if (!string.IsNullOrEmpty(e.Result))
            //    {
            //        IssuuResponse root = JsonConvert.DeserializeObject<IssuuResponse>(e.Result);
            //        SearchResults = new ObservableCollection<IssuuDocument>(root.Response.Docs);
            //    }

            //    IsDataLoaded = true;
            //};
            //webclient.DownloadStringAsync(new Uri("http://search.issuu.com/api/2_0/document?q="+key));
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