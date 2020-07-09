#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using Android.Content.Res;

namespace SampleBrowser
{
    public class Model : INotifyPropertyChanged
    {
        private int name;
        public int Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");

            }
        }

        private Stream _stream;
        public Stream Strm
        {
            get { return _stream; }
            set
            {
                _stream = value;
                RaisePropertyChanged("Strm");
            }
        }


        private string _imageName;
        public string ImageName
        {
            get { return _imageName; }
            set
            {
                _imageName = value;
                RaisePropertyChanged("ImageName");
            }
        }

        private string _imagestream;
        public string Imagestream
        {
            get { return _imagestream; }
            set
            {
                _imagestream = value;
                RaisePropertyChanged("Imagestream");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }

    public class ViewModel
    {
        public ObservableCollection<Model> ModelList
        {
            get;
            set;
        }
        public ViewModel()
        {
            ModelList = new ObservableCollection<Model>
            {

                new Model { Name= Resource.Drawable.banner1,ImageName="Coffee",Imagestream="Ban1.txt"},
                new Model { Name= Resource.Drawable.banner2,ImageName="Food",Imagestream="Ban2.txt"},
                new Model { Name= Resource.Drawable.banner3,ImageName="Syncfusion",Imagestream="Ban3.txt"},

            };
        }
    }
}
