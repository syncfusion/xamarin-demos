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
using Syncfusion.PresentationRenderer;
using System.Text.RegularExpressions;

namespace SampleBrowser.Presentation
{
    public partial class FindAndReplace : SampleView
    {
        public FindAndReplace()
        {
            InitializeComponent();

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Content_1.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;
                this.Content_2.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;
                this.Content_3.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;
                this.Content_4.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;
                this.Content_5.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;
                this.btnInput.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;
                this.Content_1.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.Content_2.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.Content_3.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.Content_4.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.Content_5.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnInput.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate.BackgroundColor = Color.Gray;
                this.btnInput.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                {
                    this.Content_1.FontSize = 13.5;
                    this.Content_2.FontSize = 13.5;
                    this.Content_3.FontSize = 13.5;
                    this.Content_4.FontSize = 13.5;
                    this.Content_5.FontSize = 13.5;
                }

                this.Content_1.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.Content_2.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.Content_3.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.Content_4.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.Content_5.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
            }
        }

        internal void OnInputButtonClicked(object sender, EventArgs e)
        {
            string resourcePath = "";
#if COMMONSB
			resourcePath = "SampleBrowser.Samples.Presentation.Samples.Templates.InputTemplate.pptx";
#else
            resourcePath = "SampleBrowser.Presentation.Samples.Templates.InputTemplate.pptx";
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

        void OnReplaceButtonClicked(object sender, EventArgs e)
        {
            string resourcePath = "";
#if COMMONSB
			resourcePath = "SampleBrowser.Samples.Presentation.Samples.Templates.InputTemplate.pptx";
#else
            resourcePath = "SampleBrowser.Presentation.Samples.Templates.InputTemplate.pptx";
#endif
            Assembly assembly = typeof(GettingStarted).GetTypeInfo().Assembly;
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            //Open a PowerPoint presentation
            IPresentation presentation = Syncfusion.Presentation.Presentation.Open(fileStream);

            //Finds the first occurrence of a particular text.
            ITextSelection textSelection = presentation.Find("{product}", false, false);

            if (textSelection != null)
            {
                //Gets the found text as single text part
                ITextPart textPart = textSelection.GetAsOneTextPart();
                //Replace the text
                textPart.Text = "Service";
            }

            Regex regex = new Regex("{[A-Za-z]+}");
            //Finds all the occurrence of a particular text pattern
            ITextSelection[] textSelections = presentation.FindAll(regex);

            if (textSelections != null)
            {
                foreach (ITextSelection textSelection2 in textSelections)
                {
                    //Gets the found text as single text part
                    ITextPart textPart = textSelection2.GetAsOneTextPart();
                    //Replace the text
                    textPart.Text = "Service";
                }
            }
            MemoryStream memoryStream = new MemoryStream();
            presentation.Save(memoryStream);
            memoryStream.Position = 0;
            //Close the PowerPoint Presentation.            
            presentation.Close();
            
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("FindAndReplace.pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", memoryStream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("FindAndReplace.pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", memoryStream);
        }
    }
}
