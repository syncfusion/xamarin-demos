#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Syncfusion.ListView.XForms;
using Syncfusion.SfImageEditor.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfImageEditor
{
    public partial class SerializationContentPage : ContentPage
    {
        SerializationModel SelectedItem;
        SerializationViewModel mainModel;
        string itemName = "";
        Assembly assembly = typeof(ImageSerializeModel).GetTypeInfo().Assembly;
        void ImageEditor_ImageSaving(object sender, Syncfusion.SfImageEditor.XForms.ImageSavingEventArgs args)
        {
           
            SerializationModel newItem = new SerializationModel();
            if (SelectedItem.ImageName == "CreateNew")
            {
                var serializationModel = new SerializationModel()
                {
					SelectionImage = new FontImageSource()
					{
						Glyph = "\ue718",
						FontFamily = Device.RuntimePlatform == Device.iOS ? "Sync FontIcons" : Device.RuntimePlatform == Device.Android ? "Sync FontIcons.ttf#" : "Sync FontIcons.ttf#Sync FontIcons",
						Color = Color.LightGray
					},
                    ImageName = itemName != "" ? itemName : ValidateName(),
                    HorizontalOption = LayoutOptions.FillAndExpand,
                    VerticalOption = LayoutOptions.FillAndExpand,
                    Visibility = "true",
                    Height = 50,
                    BackGround = Color.FromHex("#D3D3D3"),
                    CreateNewvisibility = "false",
                    SelectedImageVisibility = "false",
                    SelectedItemThickness = new Thickness(0, 0, 0, 0),
                    Strm = imageEditor.SaveEdits()

                };
                mainModel.ModelList.Add(serializationModel);
                SelectedItem = serializationModel;
        }
            else
            {
                SelectedItem.Strm = imageEditor.SaveEdits();
            }
        }

        void ImageEditor_ImageSaved(object sender, Syncfusion.SfImageEditor.XForms.ImageSavedEventArgs args)
        {
            if (Device.RuntimePlatform != "iOS")
            {
                SelectedItem.Location = args.Location;
            }
            else
            {
                SelectedItem.SetLocation(args.Location);
            }
        }

        public SerializationContentPage(SerializationModel selectedItem, Syncfusion.ListView.XForms.SfListView listView, SerializationViewModel model)
        {
            InitializeComponent();
            mainModel = model;
            SelectedItem = selectedItem;
            imageEditor.SetToolbarItemVisibility("save,effects", false);
            HeaderToolbarItem item1 = new HeaderToolbarItem();
            item1.Text = "Save Edits";
            item1.Name = "CustomSave";
            imageEditor.ImageSaving += ImageEditor_ImageSaving;
            imageEditor.ImageSaved += ImageEditor_ImageSaved;
            imageEditor.ToolbarSettings.ToolbarItems.Add(item1);

            imageEditor.ToolbarSettings.ToolbarItemSelected += (sender, e) =>
            {

                if (e.ToolbarItem is HeaderToolbarItem)
                {

                    var text = e.ToolbarItem.Name;
                    if (text == "CustomSave")
                    {
                        if (SelectedItem.ImageName == "CreateNew")
                        {
                            popup.IsVisible = true;
                            grid.IsVisible = true;
                        }
                        else
                            imageEditor.Save();

                    }

                }
            };
            if (Device.RuntimePlatform == Device.UWP && SelectedItem.ImageName == "CreateNew")
            {
#if COMMONSB
                imageEditor.Source = ImageSource.FromResource("SampleBrowser.Icons.Editor_Plain.png", assembly);
#else
                imageEditor.Source = ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.Editor_Plain.png", assembly);
#endif

            }
            LoadStream();
        }

        async void LoadStream()
        {
            await DelayActionAsync(1500, Action);
        }



        void Ok_Clicked(object sender, System.EventArgs e)
        {
            itemName = entry.Text;
            imageEditor.Save();
            popup.IsVisible = false;
            grid.IsVisible = false;
            entry.Text = "";
        }

        void Cancel_Clicked(object sender, System.EventArgs e)
        {
            popup.IsVisible = false;
            grid.IsVisible = false;
            entry.Text = "";
        }




        public async Task DelayActionAsync(int delay, Action action)
        {
            await Task.Delay(delay);

            action();
        }

        void Action()
        {
            if (SelectedItem.Strm != null)
            {
                imageEditor.LoadEdits(SelectedItem.Strm);
            }
            else if (SelectedItem.Imagestream != null)
            {
                var assembly = typeof(App).GetTypeInfo().Assembly;
                Stream stream = new MemoryStream();
                imageEditor.LoadEdits(assembly.GetManifestResourceStream(SelectedItem.Imagestream));
            }
        }


        void AddNewTemplate()
        {

        }


        string ValidateName()
        {
            String Name = "NewItem";
            int j = 1;
            for (int i = 0; i < mainModel.ModelList.Count; i++)
            {
                if (mainModel.ModelList[i].ImageName == Name)
                {
                    Name = "NewItem " + j;
                    j++;
                }

            }
            return Name;
        }


        protected override void OnAppearing()
        {

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();


        }

    }


}
