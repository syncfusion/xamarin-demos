#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
        Stream mainStrem;
        string itemName = "";
        Assembly assembly = typeof(ImageSerializeModel).GetTypeInfo().Assembly;
        void ImageEditor_ImageSaving(object sender, Syncfusion.SfImageEditor.XForms.ImageSavingEventArgs args)
        {
            mainStrem = new System.IO.MemoryStream();
            mainStrem = args.Stream;
            args.Cancel = true;

            SerializationModel newItem = new SerializationModel();
            if (SelectedItem.ImageName == "CreateNew")
            {
                mainModel.ModelList.Add(new SerializationModel
                {
                    Name = ImageSource.FromStream(() => mainStrem),
#if COMMONSB
                    SelectionImage = ImageSource.FromResource("SampleBrowser.Icons.NotSelected.png", assembly),
#else
                    SelectionImage = ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.NotSelected.png", assembly),
#endif
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

                });
        }
            else
            {
                for (int i = 0; i < mainModel.ModelList.Count; i++)
                {
                    if (SelectedItem.ImageName == mainModel.ModelList[i].ImageName)
                    {
                        mainModel.ModelList[i].Strm = imageEditor.SaveEdits();
                        mainModel.ModelList[i].Name = ImageSource.FromStream(() => mainStrem);

                    }
                }
            }
        }

        public SerializationContentPage(SerializationModel selectedItem, Syncfusion.ListView.XForms.SfListView listView, SerializationViewModel model)
        {
            InitializeComponent();
            mainModel = model;
            SelectedItem = selectedItem;
            imageEditor.SetToolbarItemVisibility("save", false);
            CustomHeader item1 = new CustomHeader();
            item1.Text = "Save Edits";
            item1.HeaderName = "Save";
            imageEditor.ImageSaving += ImageEditor_ImageSaving;
            imageEditor.ToolbarSettings.ToolbarItems.Add(item1);

            imageEditor.ToolbarSettings.ToolbarItemSelected += (sender, e) =>
            {

                if (e.ToolbarItem is CustomHeader)
                {

                    var text = (e.ToolbarItem as CustomHeader).HeaderName;
                    if (text == "Save")
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
                imageEditor.Source = ImageSource.FromResource("SampleBrowser.Icons.Plain.png", assembly);
#else
                imageEditor.Source = ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.Plain.png", assembly);
#endif

            }
            DelayActionAsync(1500, Action);
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

            for (int i = 0; i < mainModel.ModelList.Count; i++)
            {
                if (SelectedItem.ImageName == mainModel.ModelList[i].ImageName)
                {
                    var assembly = typeof(App).GetTypeInfo().Assembly;
                    Stream stream = new MemoryStream();
                    if (mainModel.ModelList[i].Strm == null && mainModel.ModelList[i].Imagestream != null)
                        stream = assembly.GetManifestResourceStream("" + mainModel.ModelList[i].Imagestream);
                    else
                        stream = mainModel.ModelList[i].Strm;
                    if (stream != null)
                        imageEditor.LoadEdits(stream);

                }
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

    public class CustomHeader : HeaderToolbarItem
    {

        public string HeaderName { get; set; }
    }
}
