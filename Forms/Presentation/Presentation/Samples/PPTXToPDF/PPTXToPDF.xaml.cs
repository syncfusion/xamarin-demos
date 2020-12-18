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
using Syncfusion.Pdf;
using Syncfusion.PresentationToPdfConverter;

namespace SampleBrowser.Presentation
{
    public partial class PPTXToPDF : SampleView
    {
        public PPTXToPDF()
        {
            InitializeComponent();

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
				this.btnGenerate.BackgroundColor = Color.Gray;
                this.btnInpTemplate.HorizontalOptions = LayoutOptions.Start;
                this.btnInpTemplate.VerticalOptions = LayoutOptions.Center;
                this.btnInpTemplate.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.FontSize = 13.5;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnInpTemplate.VerticalOptions = LayoutOptions.Center;
            }
        }

        void OnInputButtonClicked(object sender, EventArgs e)
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

            //Convert the PowerPoint document to PDF document.
            PdfDocument pdfDocument = PresentationToPdfConverter.Convert(presentation);

            //Save the converted PDF document.
            MemoryStream pdfStream = new MemoryStream();
            pdfDocument.Save(pdfStream);
            pdfStream.Position = 0;            

            //Close the PDF document.
            pdfDocument.Close(true);

            //Close the PowerPoint Presentation.
            presentation.Close();
            
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("PPTXToPDF.pdf", "application/pdf", pdfStream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("PPTXToPDF.pdf", "application/pdf", pdfStream);
        }
    }
}
