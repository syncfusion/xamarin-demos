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

namespace SampleBrowser.Presentation
{
    public partial class OLEObject : SampleView
    {
        public OLEObject()
        {
            InitializeComponent();

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.btnExtractOle.HorizontalOptions = LayoutOptions.Start;
                this.btnExtractOle.VerticalOptions = LayoutOptions.Center;
				this.btnExtractOle.BackgroundColor = Color.Gray;
                this.btnInsertOle.HorizontalOptions = LayoutOptions.Start;
                this.btnInsertOle.VerticalOptions = LayoutOptions.Center;
                this.btnInsertOle.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.FontSize = 13.5;
                this.btnExtractOle.VerticalOptions = LayoutOptions.Center;
                this.btnInsertOle.VerticalOptions = LayoutOptions.Center;
            }
        }

        void OnInsertOleButtonClicked(object sender, EventArgs e)
        {
            Assembly assembly = typeof(GettingStarted).GetTypeInfo().Assembly;
            //New Instance of PowerPoint is Created.[Equivalent to launching MS PowerPoint with no slides].
            IPresentation presentation = Syncfusion.Presentation.Presentation.Create();

            ISlide slide = presentation.Slides.Add(SlideLayoutType.TitleOnly);

            IShape titleShape = slide.Shapes[0] as IShape;
            titleShape.Left = 0.65 * 72;
            titleShape.Top = 0.24 * 72;
            titleShape.Width = 11.5 * 72;
            titleShape.Height = 1.45 * 72;
            titleShape.TextBody.AddParagraph("Ole Object");
            titleShape.TextBody.Paragraphs[0].Font.Bold = true;
            titleShape.TextBody.Paragraphs[0].HorizontalAlignment = HorizontalAlignmentType.Left;

            IShape heading = slide.Shapes.AddTextBox(100, 100, 100, 100);
            heading.Left = 0.84 * 72;
            heading.Top = 1.65 * 72;
            heading.Width = 2.23 * 72;
            heading.Height = 0.51 * 72;
            heading.TextBody.AddParagraph("MS Word Object");
            heading.TextBody.Paragraphs[0].Font.Italic = true;
            heading.TextBody.Paragraphs[0].Font.Bold = true;
            heading.TextBody.Paragraphs[0].Font.FontSize = 18;

            string mswordPath = "";
#if COMMONSB
			mswordPath = "SampleBrowser.Samples.Presentation.Samples.Templates.OleTemplate.docx";
#else
            mswordPath = "SampleBrowser.Presentation.Samples.Templates.OleTemplate.docx";
#endif
            //Get the word file as stream
            Stream wordStream = assembly.GetManifestResourceStream(mswordPath);
            string imagePath = "";
#if COMMONSB
			imagePath = "SampleBrowser.Samples.Presentation.Samples.Templates.OlePicture.png";
#else
            imagePath = "SampleBrowser.Presentation.Samples.Templates.OlePicture.png";
#endif

            //Image to be displayed, This can be any image
            Stream imageStream = assembly.GetManifestResourceStream(imagePath);

            IOleObject oleObject = slide.Shapes.AddOleObject(imageStream, "Word.Document.12", wordStream);
            //Set size and position of the ole object
            oleObject.Left = 4.53 * 72;
            oleObject.Top = 0.79 * 72;
            oleObject.Width = 4.26 * 72;
            oleObject.Height = 5.92 * 72;

            MemoryStream stream = new MemoryStream();
            presentation.Save(stream);
            presentation.Close();
            stream.Position = 0;
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("InsertOLEObject.pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("InsertOLEObject.pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", stream);
        }

        void OnExtractOleButtonClicked(object sender, EventArgs e)
        {
			string resourcePath = "";
#if COMMONSB
			resourcePath = "SampleBrowser.Samples.Presentation.Samples.Templates.EmbeddedOleObject.pptx";
#else
			resourcePath = "SampleBrowser.Presentation.Samples.Templates.EmbeddedOleObject.pptx";
#endif
            Assembly assembly = typeof(GettingStarted).GetTypeInfo().Assembly;
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            //Open a PowerPoint presentation
            IPresentation presentation = Syncfusion.Presentation.Presentation.Open(fileStream);

            //Gets the first slide of the Presentation
            ISlide slide = presentation.Slides[0];
            //Gets the Ole Object of the slide
            IOleObject oleObject = slide.Shapes[2] as IOleObject;
            //Gets the file data of embedded Ole Object.
            byte[] array = oleObject.ObjectData;
            //Gets the file Name of OLE Object
            string outputFile = oleObject.FileName;
			
            //Save the Presentation to stream
            MemoryStream stream = new MemoryStream(array);            
            presentation.Close();
            stream.Position = 0;
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save(outputFile, "application/msword", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save(outputFile, "application/msword", stream);
        }
    }
}
