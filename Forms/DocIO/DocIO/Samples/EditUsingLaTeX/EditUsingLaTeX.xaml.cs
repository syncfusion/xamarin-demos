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
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using Syncfusion.OfficeChart;

namespace SampleBrowser.DocIO
{
    public partial class EditUsingLaTeX : SampleView
    {
        public EditUsingLaTeX()
        {
            InitializeComponent();
			this.docxButton.IsChecked = true;

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
            Assembly assembly = typeof(EditUsingLaTeX).GetTypeInfo().Assembly;
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath + "EditEquationLaTeXInput.docx");

            MemoryStream stream = new MemoryStream();
            fileStream.CopyTo(stream);
            stream.Position = 0;
            fileStream.Dispose();
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("EditEquationLaTeXInput.docx", "application/msword", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("EditEquationLaTeXInput.docx", "application/msword", stream);
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            Assembly assembly = typeof(EditUsingLaTeX).GetTypeInfo().Assembly;
#if COMMONSB
            string rootPath = "SampleBrowser.Samples.DocIO.Samples.Templates.";
#else
            string rootPath = "SampleBrowser.DocIO.Samples.Templates.";
#endif
            Stream inputStream = assembly.GetManifestResourceStream(rootPath + "EditEquationLaTeXInput.docx");
            
            // Loads the stream into Word Document.
            WordDocument document = new WordDocument(inputStream, Syncfusion.DocIO.FormatType.Automatic);
             //Find all the equations in the Word document.
            List<Entity> entities = document.FindAllItemsByProperty(EntityType.Math, null, null);

            //Iterate through each equation in the Word document.
            foreach (Entity entity in entities)
            {
                WMath math = entity as WMath;
                //Get the laTeX code of equation.
                string laTeX = math.MathParagraph.LaTeX;

                //Modify the laTeX code of derivative equation.
                if (laTeX.StartsWith("\\frac"))
                    laTeX = laTeX.Replace("n", "k");
                //Modify the laTeX code of expansion of the sum equation.
                else if (laTeX.StartsWith("{\\left"))
                    laTeX = laTeX.Replace("n", "k");
                //Modify the laTeX code of quadratic equation.
                else if (laTeX.StartsWith("x=\\frac"))
                    laTeX = laTeX.Replace("x", "y");

                //Update the modified laTeX code to the equation.
                math.MathParagraph.LaTeX = laTeX;
            }

            string filename = "";
            string contenttype = "";
            MemoryStream outputStream = new MemoryStream();
            if (this.pdfButton.IsChecked != null && (bool)this.pdfButton.IsChecked)
            {
                filename = "EditEquationLaTeX.pdf";
                contenttype = "application/pdf";
                DocIORenderer renderer = new DocIORenderer();
                PdfDocument pdfDoc = renderer.ConvertToPDF(document);
                pdfDoc.Save(outputStream);
                pdfDoc.Close();
            }
            else
            {
                filename = "EditEquationLaTeX.docx";
                contenttype = "application/msword";
                document.Save(outputStream, FormatType.Docx);
            }
            document.Close();
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save(filename, contenttype, outputStream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save(filename, contenttype, outputStream);
        }
    }
}
