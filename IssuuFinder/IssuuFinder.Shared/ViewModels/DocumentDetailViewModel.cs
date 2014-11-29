using IssuuFinder.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuuFinder.ViewModels
{
    public class DocumentDetailViewModel
    {
        private IssuuDocument _document = null;

        public IssuuDocument Document
        {
            get 
            { 
                return _document; 
            }
            private set
            {
                if(value != _document) {
                    _document = value;
                    NotifyPropertyChanged("Document");
                }
            }
        }

        public DocumentDetailViewModel(IssuuDocument doc)
        {
            Document = doc;
        }

        public DocumentDetailViewModel() { }

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
