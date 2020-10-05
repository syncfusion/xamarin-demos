#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COLOR = Syncfusion.Drawing;
using Xamarin.Forms;
using System.IO;
using System.Reflection;
using SampleBrowser.Core;
using Syncfusion.PresentationRenderer;

namespace SampleBrowser.Presentation
{
    public partial class PPTXToImage : SampleView
    {
        public PPTXToImage()
        {
            InitializeComponent();
            this.pngButton.IsChecked = true;

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Content_1.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;
                this.btnInput.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;
                this.Content_1.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnInput.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate.BackgroundColor = Color.Gray;
                this.btnInput.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                {
                    this.Content_1.FontSize = 13.5;
                }

                this.Content_1.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnInput.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
            }
        }

        internal void OnInputButtonClicked(object sender, EventArgs e)
        {
			string resourcePath = "";
#if COMMONSB
			resourcePath = "SampleBrowser.Samples.Presentation.Samples.Templates.Template.pptx";
#else
            resourcePath = "SampleBrowser.Presentation.Samples.Templates.Template.pptx";
            #endif
            Assembly assembly = typeof(GettingStarted).GetTypeInfo().Assembly;
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            MemoryStream stream = new MemoryStream();
            fileStream.CopyTo(stream);
            stream.Position = 0;
            fileStream.Dispose();
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("InputTemplate.pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("InputTemplate.pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", stream);
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
			string resourcePath = "";
#if COMMONSB
			resourcePath = "SampleBrowser.Samples.Presentation.Samples.Templates.Template.pptx";
#else
            resourcePath = "SampleBrowser.Presentation.Samples.Templates.Template.pptx";
#endif
            Assembly assembly = typeof(GettingStarted).GetTypeInfo().Assembly;
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            //Open a PowerPoint presentation
            IPresentation presentation = Syncfusion.Presentation.Presentation.Open(fileStream);

            //Initialize PresentationRenderer to perform image conversion.
            presentation.PresentationRenderer = new PresentationRenderer();

            string fileName = null;
            string contentType = null;
            Syncfusion.Presentation.ExportImageFormat imageFormat;

            if (this.jpegButton.IsChecked != null && (bool)this.jpegButton.IsChecked)
            {
                imageFormat = ExportImageFormat.Jpeg;
                fileName = "Image.jpeg";
                contentType = "image/jpeg";
            }
            else
            {
                imageFormat = ExportImageFormat.Png;
                fileName = "Image.png";
                contentType = "image/png";
            }

            //Convert PowerPoint slide to image stream.
            Stream stream = presentation.Slides[0].ConvertToImage(imageFormat);                       

            //Close the PowerPoint Presentation.            
            presentation.Close();

            //Reset the stream position.
            stream.Position = 0;
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save(fileName, contentType, stream as MemoryStream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save(fileName, contentType, stream as MemoryStream);
        }
    }
}
