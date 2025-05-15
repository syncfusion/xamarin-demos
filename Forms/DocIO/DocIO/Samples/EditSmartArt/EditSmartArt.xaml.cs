#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DocIO;
using SampleBrowser.Core;
using Syncfusion.DocIO.DLS;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Syncfusion.Office;

namespace SampleBrowser.DocIO
{
    public partial class EditSmartArt : SampleView
    {
        public EditSmartArt()
        {
            InitializeComponent();

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
                this.Description.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.BackgroundColor = Color.Gray;
                this.btnInpTemplate.HorizontalOptions = LayoutOptions.Start;
                this.btnInpTemplate.VerticalOptions = LayoutOptions.Center;
                this.btnInpTemplate.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.FontSize = 13.5;
                this.Description.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnInpTemplate.VerticalOptions = LayoutOptions.Center;
            }
        }

        void OnInputButtonClicked(object sender, EventArgs e)
        {
            string resourcePath = "";
#if COMMONSB
            resourcePath = "SampleBrowser.Samples.DocIO.Samples.Templates.";
#else
            resourcePath = "SampleBrowser.DocIO.Samples.Templates.";
#endif
            Assembly assembly = typeof(EditSmartArt).GetTypeInfo().Assembly;
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath + "EditSmartArtInput.docx");

            MemoryStream stream = new MemoryStream();
            fileStream.CopyTo(stream);
            stream.Position = 0;
            fileStream.Dispose();
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("EditSmartArtInput.docx", "application/msword", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("EditSmartArtInput.docx", "application/msword", stream);
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            Assembly assembly = typeof(EditSmartArt).GetTypeInfo().Assembly;
#if COMMONSB
            string rootPath = "SampleBrowser.Samples.DocIO.Samples.Templates.";
#else
            string rootPath = "SampleBrowser.DocIO.Samples.Templates.";
#endif
            Stream inputStream = assembly.GetManifestResourceStream(rootPath + "EditSmartArtInput.docx");
            
            //Loads the stream into Word Document.
            WordDocument document = new WordDocument(inputStream, Syncfusion.DocIO.FormatType.Docx);
            //Gets the last paragraph in the document.
            WParagraph paragraph = document.LastParagraph;
            //Retrieves the SmartArt object from the paragraph.
            WSmartArt smartArt = paragraph.ChildEntities[0] as WSmartArt;
            //Sets the background fill type of the SmartArt to solid.
            smartArt.Background.FillType = OfficeShapeFillType.Solid;
            //Sets the background color of the SmartArt.
            smartArt.Background.SolidFill.Color = Syncfusion.Drawing.Color.FromArgb(255, 242, 169, 132);
            //Gets the first node of the SmartArt.
            IOfficeSmartArtNode node = smartArt.Nodes[0];
            //Modifies the text content of the first node.
            node.TextBody.Text = "Goals";
            //Retrieves the first shape of the node.
            IOfficeSmartArtShape shape = node.Shapes[0];
            //Sets the fill color of the shape.
            shape.Fill.SolidFill.Color = Syncfusion.Drawing.Color.FromArgb(255, 160, 43, 147);
            //Sets the line format color of the shape.
            shape.LineFormat.Fill.SolidFill.Color = Syncfusion.Drawing.Color.FromArgb(255, 160, 43, 147);
            //Gets the first child node of the current node.
            IOfficeSmartArtNode childNode = node.ChildNodes[0];
            //Modifies the text content of the child node.
            childNode.TextBody.Text = "Set clear goals to the team.";
            //Sets the line format color of the first shape in the child node.
            childNode.Shapes[0].LineFormat.Fill.SolidFill.Color = Syncfusion.Drawing.Color.FromArgb(255, 160, 43, 147);

            //Retrieves the second node in the SmartArt and updates its text content.
            node = smartArt.Nodes[1];
            node.TextBody.Text = "Progress";

            //Retrieves the third node in the SmartArt and updates its text content.
            node = smartArt.Nodes[2];
            node.TextBody.Text = "Result";
            //Retrieves the first shape of the third node.
            shape = node.Shapes[0];
            //Sets the fill color of the shape.
            shape.Fill.SolidFill.Color = Syncfusion.Drawing.Color.FromArgb(255, 78, 167, 46);
            //Sets the line format color of the shape.
            shape.LineFormat.Fill.SolidFill.Color = Syncfusion.Drawing.Color.FromArgb(255, 78, 167, 46);
            //Sets the line format color of the first shape in the child node.
            node.ChildNodes[0].Shapes[0].LineFormat.Fill.SolidFill.Color = Syncfusion.Drawing.Color.FromArgb(255, 78, 167, 46);

            //Saves the Word document.
            string filename = "EditSmartArt.docx";
            string contenttype = "application/msword";
            MemoryStream outputStream = new MemoryStream();
            document.Save(outputStream, FormatType.Docx);
            document.Close();
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save(filename, contenttype, outputStream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save(filename, contenttype, outputStream);
        }
    }
}