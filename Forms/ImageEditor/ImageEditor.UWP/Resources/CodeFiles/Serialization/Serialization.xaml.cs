#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SampleBrowser.Core;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfImageEditor
{
    public partial class Serialization : SampleView
    {
        SerializationViewModel model;
        SerializationModel SelectedItem;
        Assembly assembly = typeof(ImageSerializeModel).GetTypeInfo().Assembly;
        double height = 0, width = 0;

        public Serialization()
        {
            InitializeComponent();
            model = new SerializationViewModel();
            listView.BindingContext = model;
            listView.ItemsSource = model.ModelList;
			deleteImage.Source = new FontImageSource()
			{
				Glyph = "\ue735",
				FontFamily = Device.RuntimePlatform == Device.iOS ? "Sync FontIcons" : Device.RuntimePlatform == Device.Android ? "Sync FontIcons.ttf#" : "Sync FontIcons.ttf#Sync FontIcons",
				Color = Color.FromHex("#616161")
            };
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            var items = listView.SelectedItems.ToList();
            foreach (SerializationModel item in items)
            {
                (item as SerializationModel).SelectedImageVisibility = "false";
                if (model.ModelList.Contains(item))
                    model.ModelList.Remove(item);
            }
            ClearItems();
           
        }

        void ClearItems()
        {
            for (int i = 1; i < model.ModelList.Count; i++)
            {
                model.ModelList[i].SelectedImageVisibility = "false";
                model.ModelList[i].SelectedItemThickness = new Thickness(0, 0, 0, 0);

            }
            listView.SelectedItems.Clear();
            deleteImage.IsVisible = false;
            listView.SelectionChanged -= ListView_SelectionChanged;

        }

        void Handle_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            SelectedItem = e.ItemData as SerializationModel;
            //if (SelectedItem.ImageName == "CreateNew")
            //{
                var item = SelectedItem;
                if (SelectedItem.SelectedImageVisibility == "false")
                {
                    SelectedItem.SelectedImageVisibility = "false";
                if (Device.RuntimePlatform.ToLower() == "ios")
                    {
                        Navigation.PushAsync(new NavigationPage(new SerializationContentPage(item, listView, model)));
                    }
                else if (Device.RuntimePlatform.ToLower() == "uwp")
                    {
                        Navigation.PushAsync(new SerializationContentPage(item, listView, model));
                    }
                    else
                    {
                        Navigation.PushModalAsync(new SerializationContentPage(item, listView, model));
                    }
                    ClearItems();

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
                    imageGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.8, GridUnitType.Star) });
                    imageGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.1, GridUnitType.Star) });
                }
                else
                {
                    imageGrid.RowDefinitions.Clear();
                    imageGrid.Padding = new Thickness(20, 10, 20, 0);
                    imageGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.1, GridUnitType.Star) });
                    imageGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                    imageGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.1, GridUnitType.Star) });
                }
            }
        }

        void Handle_ItemHolding(object sender, Syncfusion.ListView.XForms.ItemHoldingEventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                listView.SelectedItems.Clear();
            }
            for (int i = 1; i < model.ModelList.Count; i++)
            {
                model.ModelList[i].SelectedImageVisibility = "true";
				model.ModelList[i].SelectionImage = new FontImageSource()
				{
					Glyph = "\ue718",
					FontFamily = Device.RuntimePlatform == Device.iOS ? "Sync FontIcons" : Device.RuntimePlatform == Device.Android ? "Sync FontIcons.ttf#" : "Sync FontIcons.ttf#Sync FontIcons",
					Color = Color.LightGray
				};
            }
            listView.SelectionChanged += ListView_SelectionChanged;
            deleteImage.IsVisible = true;
        }

        private void ListView_SelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            deleteImage.IsVisible = true;
            for (int i = 0; i < e.AddedItems.Count; i++)
            {
                var item = e.AddedItems[i];

                if ((item as SerializationModel).ImageName == "CreateNew")
                {
                    listView.SelectedItems.Remove(item);
                }
                else
                {
                    (item as SerializationModel).SelectedImageVisibility = "true";
					(item as SerializationModel).SelectionImage = new FontImageSource()
					{
						Glyph = "\ue748",
						FontFamily = Device.RuntimePlatform == Device.iOS ? "Sync FontIcons" : Device.RuntimePlatform == Device.Android ? "Sync FontIcons.ttf#" : "Sync FontIcons.ttf#Sync FontIcons",
						Color = Color.FromHex("#065DC7")
                    };
                    (item as SerializationModel).SelectedItemThickness = new Thickness(15, 15, 15, 15);
                }
            }
            for (int i = 0; i < e.RemovedItems.Count; i++)
            {
                var item = e.RemovedItems[i];
                (item as SerializationModel).SelectedImageVisibility = "true";
				(item as SerializationModel).SelectionImage = new FontImageSource()
				{
					Glyph = "\ue718",
					FontFamily = Device.RuntimePlatform == Device.iOS ? "Sync FontIcons" : Device.RuntimePlatform == Device.Android ? "Sync FontIcons.ttf#" : "Sync FontIcons.ttf#Sync FontIcons",
					Color = Color.LightGray
				};
                (item as SerializationModel).SelectedItemThickness = new Thickness(0, 0, 0, 0);


            }

        }


    }
 }
