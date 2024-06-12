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
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SampleBrowser.DocIO;
using System.Reflection;

namespace SampleBrowser.DocIO
{
    public partial class CompareDocuments : SampleView
    {
        public CompareDocuments()
        {
            InitializeComponent();

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.HorizontalOptions = Xamarin.Forms.LayoutOptions.Start;
                this.Description.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate.BackgroundColor = Xamarin.Forms.Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                {
                    this.Description.FontSize = 13.5;
                }

                this.Description.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
            }
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            Assembly assembly = typeof(CompareDocuments).GetTypeInfo().Assembly;
#if COMMONSB
            string rootPath = "SampleBrowser.Samples.DocIO.Samples.Templates.";
#else
            string rootPath = "SampleBrowser.DocIO.Samples.Templates.";
#endif
            //Loads the original document.
            using (Stream originalDocumentStreamPath = assembly.GetManifestResourceStream(rootPath + "OriginalDocument.docx"))
            {
                using (WordDocument originalDocument = new WordDocument(originalDocumentStreamPath, FormatType.Docx))
                {
                    //Loads the revised document.
                    using (Stream revisedDocumentStreamPath = assembly.GetManifestResourceStream(rootPath + "RevisedDocument.docx"))
                    {
                        using (WordDocument revisedDocument = new WordDocument(revisedDocumentStreamPath, FormatType.Automatic))
                        {
                            if (checkBox.IsChecked)
                            {
                                //Compares the original document with revised document
                                originalDocument.Compare(revisedDocument, "Nancy Davolio", DateTime.Now.AddDays(-1));
                            }
                            else
                            {
                                //Disable the flag to ignore the formatting changes while comparing the documents
                                ComparisonOptions comparisonOptions = new ComparisonOptions();
                                comparisonOptions.DetectFormatChanges = false;
                                originalDocument.Compare(revisedDocument, "Nancy Davolio", DateTime.Now.AddDays(-1), comparisonOptions);
                            }
                        }
                    }
                    MemoryStream stream = new MemoryStream();
                    originalDocument.Save(stream, FormatType.Docx);
                    if (Device.RuntimePlatform == Device.UWP)
                        Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("CompareDocuments.docx", "application/msword", stream);
                    else
                        Xamarin.Forms.DependencyService.Get<ISave>().Save("CompareDocuments.docx", "application/msword", stream);
                }
			}
        }
    }
}
