#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System.Reflection;
using Xamarin.Forms;
using System.IO;
using SampleBrowser.Core;

namespace SampleBrowser.PDF
{
    public partial class Stamping : SampleView
    {
        public Stamping()
        {
            InitializeComponent();
            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.BackgroundColor = Xamarin.Forms.Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.FontSize = 13.5;
                this.Description.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
            }
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            //Load PDF document to stream.
#if COMMONSB
            Stream docStream = typeof(Stamping).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.Product Catalog.pdf");
#else
            Stream docStream = typeof(Stamping).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.Product Catalog.pdf");
#endif

            //Load the PDF document into the loaded document object.
            PdfLoadedDocument ldoc = new PdfLoadedDocument(docStream);

            //Create font object.
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 100f, PdfFontStyle.Regular);

            //Stamp or watermark on all the pages.
            foreach (PdfPageBase lPage in ldoc.Pages)
            {
                PdfGraphics g = lPage.Graphics;
                PdfGraphicsState state = g.Save();
                g.TranslateTransform(ldoc.Pages[0].Size.Width / 2, ldoc.Pages[0].Size.Height / 2);
                g.SetTransparency(0.25f);
                SizeF waterMarkSize = font.MeasureString("Sample");
                g.RotateTransform(-40);
                g.DrawString("Sample", font, PdfPens.Red, PdfBrushes.Red, new PointF(-waterMarkSize.Width / 2, -waterMarkSize.Height / 2));
                g.Restore(state); 
            }
            MemoryStream stream = new MemoryStream();

            //Save the PDF document
            ldoc.Save(stream);

            //Close the document
            ldoc.Close(true);

            //Open in default system viewer.
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("Stamping.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("Stamping.pdf", "application/pdf", stream);
        }
    }
}
