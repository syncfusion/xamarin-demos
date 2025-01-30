#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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

namespace SampleBrowser.DocIO
{
    public partial class HTMLToWord : SampleView
    {
        public HTMLToWord()
        {
            InitializeComponent();

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
               
                this.Content_1.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;

                
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.BackgroundColor = Xamarin.Forms.Color.Gray;
                this.btnGenerate1.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate1.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Content_1.FontSize = 13.5;
                
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
				this.btnGenerate1.VerticalOptions = LayoutOptions.Center;
            }
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            Assembly assembly = typeof(HTMLToWord).GetTypeInfo().Assembly;
            // Creating a new document.
            WordDocument document = new WordDocument();
#if COMMONSB
            string rootPath = "SampleBrowser.Samples.DocIO.Samples.Templates.";
#else
            string rootPath = "SampleBrowser.DocIO.Samples.Templates.";
#endif
            Stream inputStream = assembly.GetManifestResourceStream(rootPath + "HTMLToWord.html");
            //Open the HTML file to convert.
            document.Open(inputStream, FormatType.Html);
            inputStream.Dispose();
            //Convert HTML file to Word document.
            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Docx);
            document.Close();

            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("HTMLToWord.docx", "application/msword", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("HTMLToWord.docx", "application/msword", stream);
        }
        void OnButtonClicked1(object sender, EventArgs e)
        {
            Assembly assembly = typeof(HTMLToWord).GetTypeInfo().Assembly;
#if COMMONSB
            string rootPath = "SampleBrowser.Samples.DocIO.Samples.Templates.";
#else
            string rootPath = "SampleBrowser.DocIO.Samples.Templates.";
#endif
            Stream inputStream = assembly.GetManifestResourceStream(rootPath + "HTMLToWord.html");
            MemoryStream stream = new MemoryStream();
            inputStream.CopyTo(stream);
            inputStream.Dispose();
            stream.Position = 0;
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("HTMLToWord.html", "application/html", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("HTMLToWord.html", "application/html", stream);
            if (!(Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP))
            {
                //Set the stream to start position to read the content as string
                stream.Position = 0;
                StreamReader reader = new StreamReader(stream);
                string htmlString = reader.ReadToEnd();

                //Set the HtmlWebViewSource to the html string
                HtmlWebViewSource html = new HtmlWebViewSource();
                html.Html = htmlString;

                //Create the web view control to view the web page
                WebView view = new WebView();
                view.Source = html;
                ContentPage webpage = new ContentPage();
                webpage.Content = view;
                this.Content.Navigation.PushAsync(webpage);
            }
        }
    }
}
