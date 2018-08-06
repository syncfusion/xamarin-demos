#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Syncfusion.SfImageEditor.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfImageEditor
{
    public partial class ImageEditorToolbarPage : ContentPage
    {
        bool isCropped;
        void Done_Clicked(object sender, System.EventArgs e)
        {
            imageEditor.Crop();
            cancelToolBar.IsVisible = false;
        }

        void Cancel_Clicked(object sender, System.EventArgs e)
        {
            imageEditor.ToggleCropping();
            cancelToolBar.IsVisible = false;
        }

        Model data;
        ImageSource scr = null;
        ViewModel ViewModelMain;
        string location = "";
        public ImageEditorToolbarPage(ImageSource imagesource, ViewModel viewModel, Model model)
        {
            data = model;
            ViewModelMain = viewModel;
            this.BindingContext = ViewModelMain;
            scr = imagesource;
            InitializeComponent();
            imageEditor.Source = imagesource;
            imageEditor.ToolbarSettings.ToolbarItems.Clear();
            imageEditor.EnableZooming = false;
            Assembly assembly = typeof(ImageSerializeModel).GetTypeInfo().Assembly;
            FooterToolbarItem banner = new FooterToolbarItem()
            {
                Text = "Banner Types",
                SubItems = new System.Collections.ObjectModel.ObservableCollection<Syncfusion.SfImageEditor.XForms.ToolbarItem>()
                {
                    #if COMMONSB
                    new Syncfusion.SfImageEditor.XForms.ToolbarItem(){Text="Facebook Post",Icon=ImageSource.FromResource("SampleBrowser.Icons.fivetofour.png",assembly)},
                    new Syncfusion.SfImageEditor.XForms.ToolbarItem(){Text="Facebook Cover",Icon=ImageSource.FromResource("SampleBrowser.Icons.fourtothree.png",assembly)},
                    new Syncfusion.SfImageEditor.XForms.ToolbarItem(){Text="Twitter Cover",Icon=ImageSource.FromResource("SampleBrowser.Icons.fivetofour.png",assembly)},
                    new Syncfusion.SfImageEditor.XForms.ToolbarItem(){Text="Twitter Post",Icon=ImageSource.FromResource("SampleBrowser.Icons.fourtothree.png",assembly)},
                    new Syncfusion.SfImageEditor.XForms.ToolbarItem(){Text="YouTubeChannel Cover",Icon=ImageSource.FromResource("SampleBrowser.Icons.fivetofour.png",assembly)},
                    #else
                    new Syncfusion.SfImageEditor.XForms.ToolbarItem(){Text="Facebook Post",Icon=ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.fivetofour.png",assembly)},
                    new Syncfusion.SfImageEditor.XForms.ToolbarItem(){Text="Facebook Cover",Icon=ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.fourtothree.png",assembly)},
                    new Syncfusion.SfImageEditor.XForms.ToolbarItem(){Text="Twitter Cover",Icon=ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.fivetofour.png",assembly)},
                    new Syncfusion.SfImageEditor.XForms.ToolbarItem(){Text="Twitter Post",Icon=ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.fourtothree.png",assembly)},
                    new Syncfusion.SfImageEditor.XForms.ToolbarItem(){Text="YouTubeChannel Cover",Icon=ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.fivetofour.png",assembly)},
                    #endif
                },
            };


            CustomHeader item2 = new CustomHeader();
            item2.HeaderName = "Share";
            #if COMMONSB
            item2.Icon = ImageSource.FromResource("SampleBrowser.Icons.share.png", assembly);
            #else
            item2.Icon = ImageSource.FromResource("SampleBrowser.SfImageEditor.Icons.share.png", assembly);
            #endif
            imageEditor.ToolbarSettings.ToolbarItems.Add(item2);
            imageEditor.ToolbarSettings.ToolbarItems.Add(banner);
            imageEditor.ToolbarSettings.ToolbarItemSelected += (sender, e) =>
            {
               // cancelToolBar.IsVisible = false;
                if (e.ToolbarItem is CustomHeader)
                if ((e.ToolbarItem as CustomHeader).HeaderName == "Share")
                    {

                        Share();
                    }
                if (e.ToolbarItem is Syncfusion.SfImageEditor.XForms.ToolbarItem)
                {

                    var toolitem = e.ToolbarItem as Syncfusion.SfImageEditor.XForms.ToolbarItem;
					if (cancelToolBar.IsVisible == true && toolitem.Text =="Banner Types") { imageEditor.ToggleCropping(); }
                    cancelToolBar.IsVisible = false;
                    if (toolitem is CustomHeader)
                    {
                        var item = toolitem as CustomHeader;
                        if (item.HeaderName == "Banner Types" && item.HeaderName == "Share")
                        {
                            cancelToolBar.IsVisible = false;
                        }
                    }
                    else if (toolitem.Text != "Banner Types")
                    {
                        cancelToolBar.IsVisible = true;
                        isCropped = true;
                    }

                    if (toolitem.Text == "Facebook Post")
                        imageEditor.ToggleCropping(1200, 900);
                    else if (toolitem.Text == "Facebook Cover")
                        imageEditor.ToggleCropping(851, 315);
                    else if (toolitem.Text == "Twitter Cover")
                        imageEditor.ToggleCropping(1500, 500);
                    else if (toolitem.Text == "Twitter Post")
                        imageEditor.ToggleCropping(1024, 512);
                    else if (toolitem.Text == "YouTubeChannel Cover")
                        imageEditor.ToggleCropping(2560, 1440);
                }
            };
          
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if ((width > height && isCropped) || (width < height && isCropped))
            {
                cancelToolBar.IsVisible = false;
                isCropped = false;
            }

        }

        public async Task DelayActionAsync(int delay, Action action)
        {
            await Task.Delay(delay);
            action();
        }

        void Share()
        {
            imageEditor.Save();
            imageEditor.ImageSaving += (sender, args) => {
            };
            imageEditor.ImageSaved += (sender, args) =>
            {
                location = args.Location;
            };

            DelayActionAsync(2500, Sharing);
        }


        void Sharing()
        {
            var temp = location;
            var filePath = DependencyService.Get<IFileStore>().GetFilePath();
            var share = DependencyService.Get<IShare>();
            share.Show("Title", "Message", temp);
        }

    }
}
