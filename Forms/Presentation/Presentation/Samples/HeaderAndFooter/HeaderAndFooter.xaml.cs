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
    public partial class HeaderFooter : SampleView
    {
        public HeaderFooter()
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
            string resourcePath = "";
#if COMMONSB
			resourcePath = "SampleBrowser.Samples.Presentation.Samples.Templates.HeaderFooter.pptx";
#else
            resourcePath = "SampleBrowser.Presentation.Samples.Templates.HeaderFooter.pptx";
#endif
            Assembly assembly = typeof(WriteProtection).GetTypeInfo().Assembly;
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            //Open a existing PowerPoint presentation
            IPresentation presentation = Syncfusion.Presentation.Presentation.Open(fileStream);

            //Add footers into all the PowerPoint slides.
            foreach (ISlide slide in presentation.Slides)
            {
                //Enable a date and time footer in slide.
                slide.HeadersFooters.DateAndTime.Visible = true;
                //Enable a footer in slide.
                slide.HeadersFooters.Footer.Visible = true;
                //Sets the footer text.
                slide.HeadersFooters.Footer.Text = "Footer";
                //Enable a slide number footer in slide.
                slide.HeadersFooters.SlideNumber.Visible = true;
            }

            //Add header into first slide notes page.
            //Add a notes slide to the slide.
            INotesSlide notesSlide = presentation.Slides[0].AddNotesSlide();
            //Enable a header in notes slide.
            notesSlide.HeadersFooters.Header.Visible = true;
            //Sets the header text.
            notesSlide.HeadersFooters.Header.Text = "Header";

            MemoryStream stream = new MemoryStream();
            presentation.Save(stream);
            presentation.Close();
            stream.Position = 0;
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("HeaderFooterSample.pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("HeaderFooterSample.pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", stream);
        }
    }
}
