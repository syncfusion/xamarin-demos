#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;
using SampleBrowser.Core;

namespace SampleBrowser.PDF
{
    public partial class Booklet : SampleView
    {
        public Booklet()
        {
            InitializeComponent();
            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.BackgroundColor = Xamarin.Forms.Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.FontSize = 13.5;
                this.Description.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
            }
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            //Load PDF document to stream.
#if COMMONSB
            Stream docStream = typeof(Booklet).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.JavaScript Succinctly.pdf");
#else
            Stream docStream = typeof(Booklet).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.JavaScript Succinctly.pdf");
#endif

            //Load the PDF document into the loaded document object.
            PdfLoadedDocument ldoc = new PdfLoadedDocument(docStream);
            float width = 1224;
            float height = 792;

            //Create a booklet form exisitng PDF document
            PdfDocument document = PdfBookletCreator.CreateBooklet(ldoc, new SizeF(width, height), true);
            MemoryStream stream = new MemoryStream();

            //Save the PDF document
            document.Save(stream);

            //Close the PDF document
            document.Close(true);

            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("Booklet.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("Booklet.pdf", "application/pdf", stream);

        }
    }
}
