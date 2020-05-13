#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
          //  cancelToolBar.IsVisible = false;
        }

        void Cancel_Clicked(object sender, System.EventArgs e)
        {
            imageEditor.ToggleCropping();
          //  cancelToolBar.IsVisible = false;
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
           // imageEditor.SetToolbarItemVisibility("Cancel,Ok", false);
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


            HeaderToolbarItem item2 = new HeaderToolbarItem();
            item2.Name = "Share";
            item2.IconHeight = 30;
			item2.Icon = new FontImageSource()
			{
				Glyph = "\ue751",
				FontFamily = Device.RuntimePlatform == Device.iOS ? "Sync FontIcons" : Device.RuntimePlatform == Device.Android ? "Sync FontIcons.ttf#" : "Sync FontIcons.ttf#Sync FontIcons",
				Color = Color.Black
			};

			imageEditor.ToolbarSettings.ToolbarItems.Add(item2);
            imageEditor.ToolbarSettings.ToolbarItems.Add(banner);
            imageEditor.ToolbarSettings.ToolbarItemSelected += (sender, e) =>
            {
                var selected = (e.ToolbarItem as Syncfusion.SfImageEditor.XForms.ToolbarItem);
                if (selected != null)
                {
                    if (selected.Name == "Share")
                        Share();
                    else if (selected.Text == "Facebook Post" || selected.Text=="Banner Types")
                        imageEditor.ToggleCropping(1200, 900);
                    else if (selected.Text == "Facebook Cover")
                        imageEditor.ToggleCropping(851, 315);
                    else if (selected.Text == "Twitter Cover")
                        imageEditor.ToggleCropping(1500, 500);
                    else if (selected.Text == "Twitter Post")
                        imageEditor.ToggleCropping(1024, 512);
                    else if (selected.Text == "YouTubeChannel Cover")
                        imageEditor.ToggleCropping(2560, 1440);
                }
            };
          
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if ((width > height && isCropped) || (width < height && isCropped))
            {
             //   cancelToolBar.IsVisible = false;
                isCropped = false;
            }

        }

        public async Task DelayActionAsync(int delay, Action action)
        {
            await Task.Delay(delay);
            action();
        }

        async void Share()
        {
            imageEditor.Save();
            imageEditor.ImageSaving += (sender, args) => {
            };
            imageEditor.ImageSaved += (sender, args) =>
            {
                location = args.Location;
            };

            await DelayActionAsync(2500, Sharing);
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
