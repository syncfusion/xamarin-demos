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
    public partial class GettingStarted : SampleView
    {
        public GettingStarted()
        {
            InitializeComponent();

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
				this.btnGenerate.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Content_1.FontSize = 13.5;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
            }
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
			string resourcePath = "";
			#if COMMONSB
			resourcePath = "SampleBrowser.Samples.Presentation.Samples.Templates.HelloWorld.pptx";
            #else
			resourcePath = "SampleBrowser.Presentation.Samples.Templates.HelloWorld.pptx";
#endif
            Assembly assembly = typeof(GettingStarted).GetTypeInfo().Assembly;
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            //Open a PowerPoint presentation
            IPresentation presentation = Syncfusion.Presentation.Presentation.Open(fileStream);

#region Slide1
            //Get the first slide from Presentation
            ISlide slide1 = presentation.Slides[0];
            //Get the shape from slide and set bounds
            IShape titleShape = slide1.Shapes[0] as IShape;
            titleShape.Left = 0.33 * 72;
            titleShape.Top = 0.58 * 72;
            titleShape.Width = 12.5 * 72;
            titleShape.Height = 1.75 * 72;
            //Set a content to the text box and apply text formatting
            ITextBody textFrame1 = (slide1.Shapes[0] as IShape).TextBody;
            IParagraphs paragraphs1 = textFrame1.Paragraphs;
            IParagraph paragraph = paragraphs1.Add();
            paragraph.HorizontalAlignment = HorizontalAlignmentType.Center;
            ITextPart textPart1 = paragraph.AddTextPart();
            textPart1.Text = "Essential Presentation";
            textPart1.Font.CapsType = TextCapsType.All;
            textPart1.Font.FontName = "Arial";
            textPart1.Font.Bold = true;
            textPart1.Font.FontSize = 40;

            IShape subtitle = slide1.Shapes[1] as IShape;
            subtitle.Left = 0.5 * 72;
            subtitle.Top = 3 * 72;
            subtitle.Width = 11.8 * 72;
            subtitle.Height = 1.7 * 72;

            ITextBody textFrame2 = (slide1.Shapes[1] as IShape).TextBody;
            textFrame2.VerticalAlignment = VerticalAlignmentType.Top;
            IParagraphs paragraphs2 = textFrame2.Paragraphs;
            IParagraph para = paragraphs2.Add();
            para.HorizontalAlignment = HorizontalAlignmentType.Left;
            ITextPart textPart2 = para.AddTextPart();
            textPart2.Text = "Lorem ipsum dolor sit amet, lacus amet amet ultricies. Quisque mi venenatis morbi libero, orci dis, mi ut et class porta, massa ligula magna enim, aliquam orci vestibulum tempus.Turpis facilisis vitae consequat, cum a a, turpis dui consequat massa in dolor per, felis non amet.";
            textPart2.Font.FontName = "Arial";
            textPart2.Font.FontSize = 21;

            para = paragraphs2.Add();
            para.HorizontalAlignment = HorizontalAlignmentType.Left;
            textPart2 = para.AddTextPart();
            textPart2.Text = "Turpis facilisis vitae consequat, cum a a, turpis dui consequat massa in dolor per, felis non amet. Auctor eleifend in omnis elit vestibulum, donec non elementum tellus est mauris, id aliquam, at lacus, arcu pretium proin lacus dolor et. Eu tortor, vel ultrices amet dignissim mauris vehicula.For more details please ";
            textPart2.Font.FontName = "Arial";
            textPart2.Font.FontSize = 21;

            //Add hyperlink to the paragraph
            ITextPart textPart3 = para.AddTextPart();
			textPart3.Font.FontName = "Arial";
            textPart3.Text = "click here";
            textPart3.SetHyperlink("https://msdn.microsoft.com/en-in/library/mt299001.aspx");
#endregion

            //Save the Presentation to stream
            MemoryStream stream = new MemoryStream();
            presentation.Save(stream);
            presentation.Close();
            stream.Position = 0;
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("GettingStartedSample.pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("GettingStartedSample.pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", stream);
        }
    }
}
