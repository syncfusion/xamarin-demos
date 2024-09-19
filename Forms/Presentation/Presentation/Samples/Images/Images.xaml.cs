#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
    public partial class Images : SampleView
    {
        public Images()
        {
            InitializeComponent();

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                
                this.Description.HorizontalOptions = LayoutOptions.Start;
                
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;

                
                this.Description.VerticalOptions = LayoutOptions.Center;
                
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
				this.btnGenerate.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                //if (!SampleBrowser.App.isUWP)
                {
                    this.Description.FontSize = 13.5;
                    
                }
                //else
                //{
                //    this.Description.FontSize = 13.5;
                //    this.Content_2.FontSize = 13.5;
                //}
                
                this.Description.VerticalOptions = LayoutOptions.Center;
                
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
            }
        }

        void OnButtonClicked(object sender, EventArgs e)
        {

            IPresentation pptxDoc = Syncfusion.Presentation.Presentation.Create();
            //Add a blank slide to Presentation.
            ISlide firstSlide = pptxDoc.Slides.Add(SlideLayoutType.Blank);

            //Add a title text box to the slide.
            IShape titleShape = firstSlide.Shapes.AddTextBox(55, 23, 853, 72);
            //Set vertical alignment to the text body.
            titleShape.TextBody.VerticalAlignment = VerticalAlignmentType.Bottom;
            //Add a title paragraph.
            IParagraph titleParagraph = titleShape.TextBody.AddParagraph();
            //Set the alignment properties for the paragraph.
            titleParagraph.HorizontalAlignment = HorizontalAlignmentType.Center;
            //Add a text part.
            ITextPart titleTextPart = titleParagraph.AddTextPart("Adventure Works Cycles");
            //Set the font properties for the text part.
            titleTextPart.Font.FontSize = 36;

            //Add a content text box to the slide.
            IShape textbox = firstSlide.Shapes.AddTextBox(66, 132, 543, 350);
            //Add the first paragraph.
            IParagraph paragraph1 = textbox.TextBody.AddParagraph();
            //Set bulleted list type.
            paragraph1.ListFormat.Type = ListType.Bulleted;
            //Set paragraph properties.
            paragraph1.LeftIndent = 22;
            paragraph1.FirstLineIndent = -22;
            paragraph1.LineSpacing = 38;
            paragraph1.SpaceBefore = 10;
            //Add a new text part.
            paragraph1.AddTextPart("Adventure Works Cycles, the fictitious company on which the Adventure Works sample databases are based, is a large, multinational manufacturing company.");

            //Add the second paragraph.
            IParagraph paragraph2 = textbox.TextBody.AddParagraph();
            //Set bulleted list type.
            paragraph2.ListFormat.Type = ListType.Bulleted;
            //Set paragraph properties.
            paragraph2.LeftIndent = 22;
            paragraph2.FirstLineIndent = -22;
            paragraph2.LineSpacing = 38;
            paragraph2.SpaceBefore = 10;
            //Add a new text part.
            paragraph2.AddTextPart("The company manufactures and sells metal and composite bicycles to North American, European, and Asian commercial markets. While its base operation is located in Bothell, Washington, with 290 employees, several regional sales teams are located throughout their market base.");

            //Create an instance for the image as a stream.
#if COMMONSB
			string resourcePath = "SampleBrowser.Samples.Presentation.Samples.Templates.CycleLogo.jpg";
#else
            string resourcePath = "SampleBrowser.Presentation.Samples.Templates.CycleLogo.jpg";
#endif
            Assembly assembly = typeof(Images).GetTypeInfo().Assembly;
            Stream imageStream = assembly.GetManifestResourceStream(resourcePath);
            //Add a picture to the shape collection.
            IPicture picture = firstSlide.Shapes.AddPicture(imageStream, 610, 246, 328, 123);
            imageStream.Dispose();
            //Add alternate text to the picture.
            picture.Description = "Adventure Works Cycles Logo";
            //Apply bounding box size and position.
            picture.Crop.ContainerWidth = 328f;
            picture.Crop.ContainerHeight = 123f;
            picture.Crop.ContainerLeft = 609f;
            picture.Crop.ContainerTop = 246f;
            //Apply cropping size and offsets.
            picture.Crop.Width = 370f;
            picture.Crop.Height = 151f;
            picture.Crop.OffsetX = -4.32f;
            picture.Crop.OffsetY = 1.44f;

            //Add a title-only slide to Presentation.
            ISlide secondSlide = pptxDoc.Slides.Add(SlideLayoutType.TitleOnly);
            //Retrieve the first shape of the slide.
            IShape titleShape2 = secondSlide.Shapes[0] as IShape;
            //Add a title paragraph.
            IParagraph titleParagraph2 = titleShape2.TextBody.AddParagraph();
            //Set the alignment properties for the paragraph.
            titleParagraph2.HorizontalAlignment = HorizontalAlignmentType.Center;
            //Add a text part.
            ITextPart titleTextPart2 = titleParagraph2.AddTextPart("About Adventure Works Cycles");
            //Set the font properties for the text part.
            titleTextPart2.Font.FontName = "Calibri";
            titleTextPart2.Font.FontSize = 40;

            //Get an SVG image as a stream.
#if COMMONSB
			resourcePath = "SampleBrowser.Samples.Presentation.Samples.Templates.About.svg";
#else
            resourcePath = "SampleBrowser.Presentation.Samples.Templates.About.svg";
#endif
            Stream svgImageStream = assembly.GetManifestResourceStream(resourcePath);
            //Get a fallback image as a stream.
#if COMMONSB
			resourcePath = "SampleBrowser.Samples.Presentation.Samples.Templates.About.png";
#else
            resourcePath = "SampleBrowser.Presentation.Samples.Templates.About.png";
#endif
            Stream fallbackImageStream = assembly.GetManifestResourceStream(resourcePath);
            //Add the SVG picture to a slide by specifying its size and position.
            IPicture svgPicture = secondSlide.Pictures.AddPicture(svgImageStream, fallbackImageStream, 172, 155, 643, 256);
            //Add alternate text to the picture.
            svgPicture.Description = "About Adventure Works Cycles";
            svgImageStream.Dispose();
            fallbackImageStream.Dispose();

            MemoryStream stream = new MemoryStream();
            pptxDoc.Save(stream);
            pptxDoc.Close();
            stream.Position = 0;
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("ImagesSample.pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("ImagesSample.pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", stream);
        }
    }
}
