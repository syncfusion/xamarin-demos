#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
    public partial class WordToHTML : SampleView
    {
        public WordToHTML()
        {
            InitializeComponent();

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
               
                this.Content_1.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;

                
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.BackgroundColor = Xamarin.Forms.Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
               // if (!SampleBrowser.DocIO.App.isUWP)
              //  {
              //      this.Content_1.FontSize = 18.5;
              //  }
              //  else
             //   {
                    this.Content_1.FontSize = 13.5;
              //  }
                
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
            }
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            Assembly assembly = typeof(WordToHTML).GetTypeInfo().Assembly;
            // Creating a new document.
            WordDocument document = new WordDocument();
#if COMMONSB
            string rootPath = "SampleBrowser.Samples.DocIO.Samples.Templates.";
#else
            string rootPath = "SampleBrowser.DocIO.Samples.Templates.";
#endif
            Stream inputStream = assembly.GetManifestResourceStream(rootPath + "WordtoHTML.doc");
            //Open the Word document to convert
            document.Open(inputStream, FormatType.Doc);
            //Export the Word document to HTML file
            MemoryStream stream = new MemoryStream();
            HTMLExport htmlExport = new HTMLExport();
            htmlExport.SaveAsXhtml(document, stream);
            document.Close();

            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("WordtoHTML.html", "application/html", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("WordtoHTML.html", "application/html", stream);
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
