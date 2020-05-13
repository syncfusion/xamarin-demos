#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfImageEditor.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfImageEditor
{
    public partial class CustomViewSample : SampleView
    {

        CustomViewViewModel viewModel;
        CustomViewModel model;
        double height = 0, width = 0;
        public CustomViewSample()
        {
            viewModel = new CustomViewViewModel();
            model = new CustomViewModel();
           this.BindingContext = new ImageListModel(viewModel);
            InitializeComponent();
        }
        void ImageTapped(object sender, System.EventArgs e)
        {
            LoadFromStream((sender as Image).Source, viewModel, model);
        }

        void LoadFromStream(ImageSource source, CustomViewViewModel viewModel, CustomViewModel model)
        {
            if (Device.RuntimePlatform.ToLower() == "ios")
            {
                Navigation.PushAsync(new NavigationPage(new CustomViewHomePage(source, viewModel)));
            }
            else if (Device.RuntimePlatform.ToLower() == "uwp")
            {
                Navigation.PushAsync(new CustomViewHomePage(source, viewModel));
            }
            else
            {
                Navigation.PushModalAsync(new CustomViewHomePage(source, viewModel));
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (Device.RuntimePlatform.ToLower() == "uwp" && Device.Idiom == TargetIdiom.Desktop)
            {
                imageGrid.RowDefinitions.Clear();
                imageGrid.Padding = new Thickness(20, 70, 20, 0);
                imageGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.1, GridUnitType.Star) });
                imageGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
                imageGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.1, GridUnitType.Star) });
                mainGrid.ColumnDefinitions.Clear();
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            }
           else if ((width != this.width || height != this.height) && (width > -1 || height > -1))
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
    public class ImageListModel
    {
        public ImageSource Image1 { get; set; }
        public ImageSource Image2 { get; set; }
        public ImageSource Image3 { get; set; }

        public ImageListModel(CustomViewViewModel viewmodel)
        {
            Image1 = viewmodel.ImageList[0].Image;
            Image2 = viewmodel.ImageList[1].Image;
            Image3 = viewmodel.ImageList[2].Image;
        }

    }

    public class CustomViewViewModel
    {
        public ObservableCollection<CustomViewModel> ImageList
        {
            get;
            set;
        }
        public CustomViewViewModel()
        {
            Assembly assembly = typeof(CustomViewHomePage).GetTypeInfo().Assembly;
            ImageList = new ObservableCollection<CustomViewModel>
            {
                #if COMMONSB
                new CustomViewModel { Image=ImageSource.FromResource("SampleBrowser.Icons.EditorBuilding1.png",assembly),ImageName="Nature1"} ,
                new CustomViewModel { Image=ImageSource.FromResource("SampleBrowser.Icons.EditorBuilding2.png",assembly),ImageName="Nature2"} ,
                new CustomViewModel { Image=ImageSource.FromResource("SampleBrowser.Icons.EditorTablet.png",assembly),ImageName="Nature3"} ,
                #else
                new CustomViewModel { Image=ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.EditorBuilding1.png",assembly),ImageName="Nature1"} ,
                new CustomViewModel { Image=ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.EditorBuilding2.png",assembly),ImageName="Nature2"} ,
                new CustomViewModel { Image=ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.EditorTablet.png",assembly),ImageName="Nature3"} ,
                #endif
            };

        }
    }

    public class CustomViewModel
    {
        public ImageSource Image
        {
            get; set;
        }

        public string ImageName
        {
            get; set;
        }
    }
}