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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfImageEditor
{
    public partial class CustomViewHomePage : ContentPage
    {


        bool isReplaced;
        ObservableCollection<Syncfusion.SfImageEditor.XForms.ToolbarItem> CustomViewItems;
        Assembly assembly = typeof(CustomViewSample).GetTypeInfo().Assembly;
        #if COMMONSB
        string samplePath = "SampleBrowser.Icons.";
        #else
        string samplePath = "SampleBrowser.SfImageEditor.Icons.";
        #endif
        CustomViewSettings customViewSettings;
        public CustomViewHomePage(ImageSource source, CustomViewViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;

            // Set source to the SfImageEditor
            imageEditor.Source = source;
            imageEditor.RotatableElements = ImageEditorElements.CustomView;
            imageEditor.SetToolbarItemVisibility("text,transform,shape,path,effects", false);


            CustomViewItems = new ObservableCollection<Syncfusion.SfImageEditor.XForms.ToolbarItem>()
            {
                new CustomToolbarItem(){Icon=ImageSource.FromResource(samplePath+"ITypogy1.png", assembly),CustomName = "ITypogy1",IconHeight=70 },
                new CustomToolbarItem(){Icon=ImageSource.FromResource(samplePath+"ITypogy2.png", assembly),CustomName = "ITypogy2",IconHeight=70  },
                new CustomToolbarItem(){Icon=ImageSource.FromResource(samplePath+"ITypogy3.png", assembly),CustomName = "ITypogy3",IconHeight=70  },
                new CustomToolbarItem(){Icon=ImageSource.FromResource(samplePath+"ITypogy4.png", assembly),CustomName = "ITypogy4",IconHeight=70  },
                new CustomToolbarItem(){Icon=ImageSource.FromResource(samplePath+"ITypogy5.png", assembly),CustomName = "ITypogy5",IconHeight=70  },
                new CustomToolbarItem(){Icon=ImageSource.FromResource(samplePath+"ITypogy6.png", assembly),CustomName = "ITypogy6",IconHeight=70  }
            };

            // Add the custom tool bar items
            var item = new FooterToolbarItem()
            {
                Text = "Add",
                Icon = new FontImageSource()
                {
                    Glyph = "\ue70a", 
                    FontFamily = Device.RuntimePlatform == Device.iOS ? "Sync FontIcons" : Device.RuntimePlatform == Device.Android ? "Sync FontIcons.ttf#" : "Sync FontIcons.ttf#Sync FontIcons",
                    Color = Color.Black
                },
                SubItems = CustomViewItems,
                TextHeight = 20,
            };
            imageEditor.ToolbarSettings.ToolbarItems.Add(item);

			item = new FooterToolbarItem()
			{
				Text = "Replace",
				IconHeight = Device.RuntimePlatform == Device.Android ? 27 : double.NaN,
                Icon = new FontImageSource()
                {
                    Glyph = "\ue740",
                    FontFamily = Device.RuntimePlatform == Device.iOS ? "SB Icons" : Device.RuntimePlatform == Device.Android ? "SB Icons.ttf#" : "SB Icons.ttf#SB Icons",
                    Color = Color.Black
                }, 
                SubItems = CustomViewItems,
                TextHeight = 20
            };
            imageEditor.ToolbarSettings.ToolbarItems.Add(item);

            item = new FooterToolbarItem()
            {
                Icon = new FontImageSource()
                {
                    Glyph = "\ue764",
                    FontFamily = Device.RuntimePlatform == Device.iOS ? "Sync FontIcons" : Device.RuntimePlatform == Device.Android ? "Sync FontIcons.ttf#" : "Sync FontIcons.ttf#Sync FontIcons",
                    Color = Color.Black
                },
                Text = "Bring Front",
                TextHeight = 20
            };
            imageEditor.ToolbarSettings.ToolbarItems.Add(item);

            item = new FooterToolbarItem()
            {
                Icon = new FontImageSource()
                {
                    Glyph = "\ue70e", 
                    FontFamily = Device.RuntimePlatform == Device.iOS ? "Sync FontIcons" : Device.RuntimePlatform == Device.Android ? "Sync FontIcons.ttf#" : "Sync FontIcons.ttf#Sync FontIcons",
                    Color = Color.Black
                },
                Text = "Send Back",
                TextHeight = 20
            };
            imageEditor.ToolbarSettings.ToolbarItems.Add(item);
            imageEditor.ToolbarSettings.SubItemToolbarHeight = 70;
            imageEditor.ItemSelected += ImageEditor_ItemSelected;
            imageEditor.ToolbarSettings.ToolbarItemSelected += OnToolbarItemSelected;
        }
        private void ImageEditor_ItemSelected(object sender, ItemSelectedEventArgs args)
        {
            if (args.Settings != null && args.Settings is CustomViewSettings)
            {
                customViewSettings = args.Settings as CustomViewSettings;
            }
        }
        private void OnToolbarItemSelected(object sender, ToolbarItemSelectedEventArgs e)
        {
            string text = string.Empty;

            if (e.ToolbarItem is FooterToolbarItem)
            {
                text = e.ToolbarItem.Text;

                e.MoveSubItemsToFooterToolbar = true;
            }
            else if (e.ToolbarItem is CustomToolbarItem)
                text = (e.ToolbarItem as CustomToolbarItem).CustomName;
            else
                text = e.ToolbarItem.Name;

            if (text == "Replace")
            {
                isReplaced = true;
                //imageEditor.ToolbarSettings.FooterToolbarHeight = 70;
            }
            else if (text == "back")
            {
                isReplaced = false;
                //imageEditor.ToolbarSettings.FooterToolbarHeight = 50;
            }
            else if (text == "Add")
            {
                isReplaced = false;
                //imageEditor.ToolbarSettings.FooterToolbarHeight = 70;
            }
            if (isReplaced && imageEditor.IsSelected && (text == "ITypogy1" ||
                                                         text == "ITypogy2" || text == "ITypogy3" || text == "ITypogy4" || text == "ITypogy5" || text == "ITypogy6"))
            {
                imageEditor.Delete();
                AddImage(text);
            }
            if (!isReplaced)
                AddImage(text);
            if (text == "Bring Front")
                imageEditor.BringToFront();
            else if (text == "Send Back")
                imageEditor.SendToBack();
            var properties = typeof(Syncfusion.SfImageEditor.XForms.SfImageEditor).GetRuntimeProperties();
        }


        private void AddImage(string text)
        {
            if (text == "ITypogy1")
                SetSVGImage("Typogy1");

            else if (text == "ITypogy2")
                SetSVGImage("Typogy2");

            else if (text == "ITypogy3")
                SetSVGImage("Typogy3");

            else if (text == "ITypogy4")
                SetSVGImage("Typogy4");

            else if (text == "ITypogy5")
                SetSVGImage("Typogy5");

            else if (text == "ITypogy6")
                SetSVGImage("Typogy6");
        }
        private void SetSVGImage(string name)
        {
            object view = DependencyService.Get<ICustomViewDependencyService>().GetCustomView(name, this);
            if (isReplaced)
				imageEditor.AddCustomView(view, new CustomViewSettings() { Bounds = customViewSettings.Bounds,Angle=customViewSettings.Angle });
            else
            {
                imageEditor.AddCustomView(view, new CustomViewSettings() { });
            }
        }
    }

    public class CustomImageEditor : Syncfusion.SfImageEditor.XForms.SfImageEditor
    {

    }
    public interface ICustomViewDependencyService
    {
        object GetCustomView(string imageName, object context);
        Task<Stream> GetImageSource(string uri);
    }
    public class CustomToolbarItem : Syncfusion.SfImageEditor.XForms.ToolbarItem
    {
        public string CustomName { get; set; }
        public CustomToolbarItem()
        {

        }
    }
}
