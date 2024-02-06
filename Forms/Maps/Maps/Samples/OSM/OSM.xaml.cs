#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfMaps.XForms;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfMaps
{
    [Preserve(AllMembers = true)]
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OSM : SampleView
    {
        Label label;
        Grid childGrid;
        StackLayout stack;
        ViewModel viewModel;
        ImageryLayer layer;
        Syncfusion.SfMaps.XForms.SfMaps maps;
        Syncfusion.SfCarousel.XForms.SfCarousel carousel;
        
        /// <summary>
        /// Gets or sets the padding value to provide gap between the items from the selected item.
        /// </summary>
        private int carouselItemGap;
        
        public OSM()
        {
            InitializeComponent();
            carouselItemGap = 30;
            viewModel = new ViewModel();
            this.SizeChanged += OSM_SizeChanged;
            IsConnectedToNetwork();       
        }

        private void OSM_SizeChanged(object sender, EventArgs e)
        {
            InitializeChildGrid();
            
            if (Height > 0)
            {
                var row = Height / 512;
                if (Math.Ceiling(row) <= 0)
                    row = 1;
                else
                    row = Math.Ceiling(row);
                for (int i = 0; i < row; i++)
                {
                    var rowDefinition = new RowDefinition() { Height = 500 };
                    childGrid.RowDefinitions.Add(rowDefinition);
                }
            }
            if (Width > 0)
            {
                if (carousel != null)
                {
                    if (Device.RuntimePlatform == Device.Android)
                    {
                        carousel.ItemWidth = (int)(Width * 0.75f);
                    }
                    else if (Device.RuntimePlatform == Device.iOS)
                    {
                        carousel.ItemWidth = (int)(Width * 0.7f);
                    }
                    else
                    {
                        carousel.ItemWidth = (int)(Width * 0.5f);
                        carousel.Offset = (int)(Width * 0.15f);
                    }

                    carousel.SelectedItemOffset = (int)(carousel.ItemWidth / 2) - carouselItemGap;               
                }               

                var column = Width / 512;
                if (Math.Ceiling(column) <= 0)
                    column = 1;
                else
                    column = Math.Ceiling(column);
                for (int i = 0; i < column; i++)
                {
                    var columnDefinition = new ColumnDefinition() { Width = 500 };
                    childGrid.ColumnDefinitions.Add(columnDefinition);
                }
            }
            if (childGrid.Children.Count > 0)
                childGrid.Children.Clear();
            {
                for (int i = 0; i < childGrid.RowDefinitions.Count; i++)
                {
                    for (int j = 0; j < childGrid.ColumnDefinitions.Count; j++)
                    {
                        Image image = new Image();
                        image.Source = "grid.png";
                        image.HeightRequest = 512;
                        image.WidthRequest = 512;
                        image.HorizontalOptions = LayoutOptions.FillAndExpand;
                        image.VerticalOptions = LayoutOptions.FillAndExpand;
                        if (Device.RuntimePlatform != Device.Android)
                            image.Margin = new Thickness(-5);

                        childGrid.Children.Add(image, j, i);
                    }
                }
            }
            childGrid.IsClippedToBounds = true;
        }


         void IsConnectedToNetwork()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                AddContent();
            }
            else
            {
                label = new Label();
                label.Margin = new Thickness(10, 0, 5, 0);
                label.Text = "Since this application requires network connection, please check your network connection.";
                label.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                label.TextColor = Color.Black;
                label.HorizontalOptions = LayoutOptions.Center;
                label.VerticalOptions = LayoutOptions.Center;
                this.Content = label;
            }
        }

       
        void AddContent()
        {
            InitializeChildGrid();
            mainGrid.HorizontalOptions = LayoutOptions.FillAndExpand;
            mainGrid.VerticalOptions = LayoutOptions.FillAndExpand;
            mainGrid.BackgroundColor = Color.FromRgb(249, 245, 237);
            mainGrid.Children.Add(childGrid);
            maps = new Syncfusion.SfMaps.XForms.SfMaps();
            layer = new ImageryLayer();
            layer.GeoCoordinates = new Point(27.1751, 78.0421);
            maps.MaxZoom = 8;
            maps.MinZoom = 4;

            layer.DistanceType = DistanceType.KiloMeter;

            if (Device.RuntimePlatform == Device.Android)
            {
                layer.Radius = 1500;
            }
            else
            {
                layer.Radius = 500;
            }

            
            //layer.MarkerTemplate = mainGrid.Resources["markerTemplate"] as DataTemplate;

            CustomMarker marker = new CustomMarker();
            marker.Latitude = "20.6843";
            marker.Longitude = "-88.5678";
            marker.Location = "Mexico";
            layer.Markers.Add(marker);

            marker = new CustomMarker();
            marker.Location = "Peru";
            marker.Latitude = "-13.1631";
            marker.Longitude = "-72.5450";
            layer.Markers.Add(marker);

            marker = new CustomMarker();
            marker.Location = "Brazil";
            marker.Latitude = "-22.9519";
            marker.Longitude = "-43.2106";
            layer.Markers.Add(marker);

            marker = new CustomMarker();
            marker.Location = "Rome";
            marker.Latitude = "41.8902";
            marker.Longitude = "12.4922";
            layer.Markers.Add(marker);

            marker = new CustomMarker();
            marker.Location = "Jordan";
            marker.Latitude = "30.3285";
            marker.Longitude = "35.4444";
            layer.Markers.Add(marker);

            marker = new CustomMarker();
            marker.Location = "India";
            marker.Latitude = "27.1751";
            marker.Longitude = "78.0421";
            layer.Markers.Add(marker);

            marker = new CustomMarker();
            marker.Location = "China";
            marker.Latitude = "40.4319";
            marker.Longitude = "116.5704";
            layer.Markers.Add(marker);

            MapMarkerSetting markerSettings = new MapMarkerSetting();

            markerSettings.IconSize = 20;
            markerSettings.IconColor = Color.FromHex("#FF2196ef");
            markerSettings.TooltipSettings.TooltipTemplate = mainGrid.Resources["toolTipTemplate"] as DataTemplate;
            markerSettings.TooltipSettings.ShowTooltip = true;
            markerSettings.TooltipSettings.FontSize = 15;
            layer.MarkerSettings = markerSettings;
          
            maps.Layers.Add(layer);
            mainGrid.Children.Add(maps);

            carousel = new Syncfusion.SfCarousel.XForms.SfCarousel();
            carousel.RotationAngle = 0;
            if (Device.RuntimePlatform == Device.UWP)
            {
                carousel.HeightRequest = 150;
                carousel.ItemHeight = 150;
            }
            else
            {
                carousel.HeightRequest = 125;
                carousel.ItemHeight = 125;
            }
            
            carousel.VerticalOptions = LayoutOptions.EndAndExpand;
            carousel.Margin = new Thickness(0, 0, 0, 5);
           
            carousel.ItemTemplate= mainGrid.Resources["carouselTemplate"] as DataTemplate;
            carousel.SelectionChanged += Carousel_SelectionChanged;
            carousel.ItemsSource = viewModel.RotatorItems;
            carousel.SelectedIndex = 5;
            mainGrid.Children.Add(carousel);

            stack = new StackLayout();
            stack.Orientation = StackOrientation.Horizontal;
            stack.BackgroundColor = Color.White;
            stack.HorizontalOptions = LayoutOptions.EndAndExpand;
            stack.VerticalOptions = LayoutOptions.End;
            Label label1 = new Label();
            label1.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
            label1.Text = "©";
            label1.Margin = new Thickness(2);
            stack.Children.Add(label1);

            Label label2 = new Label();
            label2.Margin = new Thickness(0, 2, 3, 2);
            label2.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
            label2.Text = "OpenStreetMap contributors.";
            label2.TextColor = Color.DeepSkyBlue;
            Uri uri = new Uri("https://www.openstreetmap.org/copyright");
            label2.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => Launcher.OpenAsync(uri))
            });
            stack.Children.Add(label2);
            mainGrid.Children.Add(stack);
        }

        private void Carousel_SelectionChanged(object sender, Syncfusion.SfCarousel.XForms.SelectionChangedEventArgs e)
        {
            int index = carousel.SelectedIndex;
            
            if (index == 0)
            {
                layer.GeoCoordinates = new Point(20.6843, -88.5678);
            }
            else if (index == 1)
            {
                layer.GeoCoordinates = new Point(-13.1631, -72.5450);
            }
            else if (index == 2)
            {
                layer.GeoCoordinates = new Point(-22.9519, -43.2106);
            }
            else if (index == 3)
            {
                layer.GeoCoordinates = new Point(41.8902, 12.4922);
            }
            else if (index == 4)
            {
                layer.GeoCoordinates = new Point(30.3285, 35.4444);
            }
            else if (index == 5)
            {
                layer.GeoCoordinates = new Point(27.1751, 78.0421);
            }
            else if (index == 6)
            {
                layer.GeoCoordinates = new Point(40.4319, 116.5704);
            }
        }

        void InitializeChildGrid()
        {
            if (childGrid == null)
            {
                childGrid = new Grid();
                childGrid.HorizontalOptions = LayoutOptions.FillAndExpand;
                childGrid.VerticalOptions = LayoutOptions.FillAndExpand;
            }
        }
    }

    public class Model
    {
        private ImageSource image;
        private string description;
        private string title;
        private int index;

        public int SelectedIndex
        {
            get { return index; }
            set
            {
                index = value;
            }
        }
        public ImageSource Image
        {
            get { return image; }
            set
            {
                image = value;
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
            }
        }
    }

    public class ViewModel
    {
        public ObservableCollection<Model> RotatorItems { get; set; }
        public ViewModel()
        {
            RotatorItems = new ObservableCollection<Model>();
            RotatorItems.Add(new Model()
            {
                Title = "Chichen Itza, Mexico",
                SelectedIndex = 0,
                Image = "Mexico.jpg",
                Description = "Mayan ruins on Mexico's Yucatan Peninsula. It was one of the largest Maya cities, thriving from around A.D. 600 to 1200."
            }) ;
            RotatorItems.Add(new Model()
            {
                Title = "Machu Picchu, Peru",
                SelectedIndex = 1,
                Image = "Peru.jpg",
                Description = "An inca citadel built in the mid-1400s. It was not widely known until the early 20th century."
            });
            RotatorItems.Add(new Model()
            {
                Title = "Christ the Redeemer, Brazil",
                SelectedIndex = 2,
                Image = "Christ.jpg",
                Description = "An enormous statue of Jesus Christ with open arms. A symbol of Christianity across the world, the statue has also become a cultural icon of both Rio de Janeiro and Brazil."
            });
            RotatorItems.Add(new Model()
            {
                Title = "Colosseum, Rome",
                SelectedIndex = 3,
                Image = "Colosseum.jpg",
                Description = "Built between A.D. 70 and 80. It is one of the most popular touristattractions in Europe."
            });
            RotatorItems.Add(new Model()
            {
                Title = "Petra, Jordan",
                SelectedIndex = 4,
                Image = "Petra.jpg",
                Description = "It is a historic and archaeological city in southern Jordan. Petra lies around Jabal Al-Madbah in a basin surrounded by mountains which form the eastern flank of the Arabah valley that runs from the Dead Sea to the Gulf of Aqaba."
            });
            RotatorItems.Add(new Model()
            {
                Title = "Taj Mahal, India",
                SelectedIndex = 5,
                Image = "TajMahal.jpg",
                Description = "It is an ivory-white marble mausoleum on the southern bank of the river Yamuna in the Indian city of Agra."
            });
            RotatorItems.Add(new Model()
            {
                Title = "Great wall of China, China",
                SelectedIndex = 6,
                Image = "China_wall.jpg",
                Description = "The Great Wall of China is a series of fortifications that were built across the historical northern borders of ancient Chinese states and Imperial China as protection against various nomadic groups from the Eurasian Steppe."
            });
        }
    }
}