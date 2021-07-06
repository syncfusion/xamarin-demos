#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DocIO;
using SampleBrowser.Core;
using Syncfusion.DocIO.DLS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SampleBrowser.DocIO;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using Syncfusion.OfficeChart;
using Syncfusion.Drawing;

namespace SampleBrowser.DocIO
{
    public partial class TrackChanges : SampleView
    {
        public TrackChanges()
        {
            InitializeComponent();

            this.acceptAll.IsChecked = true;

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;
                this.Description.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate1.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate1.BackgroundColor = Xamarin.Forms.Color.Gray;
                this.btnGenerate2.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate2.BackgroundColor = Xamarin.Forms.Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                {
                    this.Description.FontSize = 13.5;
                }

                this.Description.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate1.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate2.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
            }
        }
        void OnButtonClicked1(object sender, EventArgs e)
        {
            Assembly assembly = typeof(TrackChanges).GetTypeInfo().Assembly;
#if COMMONSB
            string rootPath = "SampleBrowser.Samples.DocIO.Samples.Templates.";
#else
            string rootPath = "SampleBrowser.DocIO.Samples.Templates.";
#endif
            Stream inputStream = assembly.GetManifestResourceStream(rootPath + "TrackChangesTemplate.docx");
            MemoryStream stream = new MemoryStream();
            inputStream.CopyTo(stream);
            inputStream.Dispose();
            stream.Position = 0;
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("TrackChangesTemplate.docx", "application/msword", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("TrackChangesTemplate.docx", "application/msword", stream);
        }
        void OnButtonClicked2(object sender, EventArgs e)
        {
            Assembly assembly = typeof(TrackChanges).GetTypeInfo().Assembly;
            WordDocument document = new WordDocument();
#if COMMONSB
            string rootPath = "SampleBrowser.Samples.DocIO.Samples.Templates.";
#else
            string rootPath = "SampleBrowser.DocIO.Samples.Templates.";
#endif
            // Open an existing template document.
            Stream inputStream = assembly.GetManifestResourceStream(rootPath + "TrackChangesTemplate.docx");
            document.Open(inputStream, FormatType.Docx);
            inputStream.Dispose();
            if (rejectAll != null && (bool)rejectAll.IsChecked)
                document.Revisions.RejectAll();
            else
                document.Revisions.AcceptAll();
            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Docx);
            document.Close();

            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("Track Changes.docx", "application/msword", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("Track Changes.docx", "application/msword", stream);
        }

    }
}
