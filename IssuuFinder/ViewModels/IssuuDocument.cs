using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace IssuuFinder.ViewModels
{
    public class IssuuDocument : INotifyPropertyChanged
    {
        private string _docname;
        /// <summary>
        /// Proprietà ViewModel di esempio: questa proprietà viene utilizzata per visualizzare il relativo valore mediante un'associazione.
        /// </summary>
        /// <returns></returns>
        public string Docname
        {
            get
            {
                return _docname;
            }
            set
            {
                if (value != _docname)
                {
                    _docname = value;
                    NotifyPropertyChanged("Docname");
                }
            }
        }

        private string _documentId;
        /// <summary>
        /// Proprietà ViewModel di esempio: questa proprietà viene utilizzata per visualizzare il relativo valore mediante un'associazione.
        /// </summary>
        /// <returns></returns>
        public string DocumentId
        {
            get
            {
                return _documentId;
            }
            set
            {
                if (value != _documentId)
                {
                    _documentId = value;
                    ThumbnailPath = value;
                    NotifyPropertyChanged("DocumentId");
                }
            }
        }

        private string _username;
        /// <summary>
        /// Proprietà ViewModel di esempio: questa proprietà viene utilizzata per visualizzare il relativo valore mediante un'associazione.
        /// </summary>
        /// <returns></returns>
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if (value != _username)
                {
                    _username = value;
                    NotifyPropertyChanged("Username");
                }
            }
        }

        private string _thumbnailPath;

        public string ThumbnailPath
        {
            get 
            { 
                return _thumbnailPath;
            }
            set
            { 
                _thumbnailPath = "http://image.issuu.com/"+_documentId+"/jpg/page_1_thumb_large.jpg";
                NotifyPropertyChanged("ThumbnailPath");
            }
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