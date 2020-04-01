#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfImageEditor
{
    public partial class BannerCreator : SampleView
    {
        ImageSerializeModel model;

        ViewModel viewModel;

        Model data;

        double height = 0, width = 0;

        public BannerCreator()
        {
            data = new Model();
            viewModel = new ViewModel();
            model = new ImageSerializeModel(viewModel);
            InitializeComponent();
            BindingContext = model;

        }

        void ImageTapped(object sender, System.EventArgs e)
        {

            LoadFromStream((sender as Image).Source, viewModel, data);
        }

        void LoadFromStream(ImageSource source, ViewModel viewModel, Model data)
        {
            if (Device.RuntimePlatform.ToLower() == "ios")
            {
                  Navigation.PushAsync(new NavigationPage(new ImageEditorToolbarPage(source, viewModel, data)));
            }
            else if (Device.RuntimePlatform.ToLower() == "uwp")
            {
                Navigation.PushAsync(new ImageEditorToolbarPage(source, viewModel, data));
            }
            else
            {
                Navigation.PushModalAsync(new ImageEditorToolbarPage(source, viewModel, data));


            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (Device.RuntimePlatform.ToLower() == "uwp") return;
            if ((width != this.width || height != this.height) && (width > -1 || height > -1))
            {
                this.width = width;
                this.height = height;
                if (width < height)
                {
                    imageGrid.RowDefinitions.Clear();
                    imageGrid.Padding = new Thickness(20, 70, 20, 0);
                    imageGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.1, GridUnitType.Star) });
                    imageGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.6, GridUnitType.Star) });
                    imageGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                    mainGrid.ColumnDefinitions.Clear();
                    mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                    mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                    mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                }
                else
                {
                    imageGrid.RowDefinitions.Clear();
                    mainGrid.ColumnDefinitions.Clear();
                    imageGrid.Padding = new Thickness(20, 10, 20, 0);
                    imageGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.1, GridUnitType.Star) });
                    imageGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1.5, GridUnitType.Star) });
                    imageGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0, GridUnitType.Star) });
                    mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.5, GridUnitType.Star) });
                    mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.5, GridUnitType.Star) });
                    mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.5, GridUnitType.Star) });
                }
            }
        }
    }
    public class ImageSerializeModel
    {
        public ImageSource BroweImage1 { get; set; }
        public ImageSource BroweImage2 { get; set; }
        public ImageSource BroweImage3 { get; set; }

        public ImageSerializeModel(ViewModel viewmodel)
        {
            BroweImage1 = viewmodel.ModelList[0].Name;
            BroweImage2 = viewmodel.ModelList[1].Name;
            BroweImage3 = viewmodel.ModelList[2].Name;
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
            Assembly assembly = typeof(ImageSerializeModel).GetTypeInfo().Assembly;
            ModelList = new ObservableCollection<Model>
            {
                #if COMMONSB
                new Model { Name=ImageSource.FromResource("SampleBrowser.Icons.EditorDashboard.jpg",assembly),ImageName="Dashboard"} ,
                new Model { Name=ImageSource.FromResource("SampleBrowser.Icons.EditorSuccinity.png",assembly),ImageName="Succinity"} ,
                new Model { Name=ImageSource.FromResource("SampleBrowser.Icons.EditorTwitter.jpeg",assembly),ImageName="Twitter"} ,
                #else
                new Model { Name=ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.EditorDashboard.jpg",assembly),ImageName="Dashboard"} ,
                new Model { Name=ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.EditorSuccinity.png",assembly),ImageName="Succinity"} ,
                new Model { Name=ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.EditorTwitter.jpeg",assembly),ImageName="Twitter"} ,
                #endif

    };

        }
    }

    public class Model : INotifyPropertyChanged
    {
        private ImageSource name;
        public ImageSource Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");

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

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }

}
