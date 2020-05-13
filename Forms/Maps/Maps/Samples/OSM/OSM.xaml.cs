#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfMaps.XForms;
using System;
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
        Syncfusion.SfMaps.XForms.SfMaps maps;
        Label label;
        Grid childGrid;
        StackLayout stack;
        public OSM()
        {
            InitializeComponent();
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
            Syncfusion.SfMaps.XForms.ImageryLayer layer = new ImageryLayer();
            layer.GeoCoordinates = new Point(38.909804, -77.043442);
            layer.Radius = 5;
            CustomMarker marker = new CustomMarker();
            marker.Label = "Washington DC";
            marker.Latitude = "38.909804";
            marker.Longitude = "-77.043442";
            layer.MarkerTemplate = mainGrid.Resources["markerTemplate"] as DataTemplate;
            layer.Markers.Add(marker);
            MapMarkerSetting markerSettings = new MapMarkerSetting();
            markerSettings.VerticalAlignment = MarkerAlignment.Near;
            markerSettings.TooltipSettings.ShowTooltip = true;
            markerSettings.TooltipSettings.ValuePath = "Label";
            markerSettings.TooltipSettings.FontSize = 15;
            layer.MarkerSettings = markerSettings;
            if (Device.RuntimePlatform == Device.UWP)
                maps.MinZoom = 2;
            maps.Layers.Add(layer);
            mainGrid.Children.Add(maps);
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
                Command = new Command(() => Device.OpenUri(uri))
            });
            stack.Children.Add(label2);
            mainGrid.Children.Add(stack);
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
}