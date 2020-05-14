#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "ExportingBehaviors.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfDataGrid
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using SampleBrowser.Core;
    using Syncfusion.Drawing;
    using Syncfusion.Pdf;
    using Syncfusion.Pdf.Graphics;
    using Syncfusion.SfDataGrid.XForms.Exporting;
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the Exporting samples
    /// </summary>
    public class ExportingBehaviors : Behavior<SampleView>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Xamarin.Forms.Image excelImage;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Xamarin.Forms.Image pdfImage;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Label exportToPdf;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Label exportToExcel;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private StackLayout pdfExport;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private StackLayout excelExport;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">SampleView type parameter as bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            var assembly = Assembly.GetAssembly(Application.Current.GetType());
            this.dataGrid = bindAble.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            this.excelImage = bindAble.FindByName<Xamarin.Forms.Image>("excelImage");
            this.pdfImage = bindAble.FindByName<Xamarin.Forms.Image>("pdfImage");
            this.excelImage.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.ExportToExcel) });
            this.pdfImage.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.ExportToPdf) });
           
            this.pdfExport = bindAble.FindByName<StackLayout>("PdfStack");
            this.excelExport = bindAble.FindByName<StackLayout>("ExcelStack");
            this.excelExport.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.ExportToExcel) });
            this.pdfExport.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.ExportToPdf) });
            this.pdfImage.Source = "PdfExport.png";
            this.excelImage.Source = "ExcelExport.png";
            this.excelImage.Margin = new Thickness(0, 0, 10, 0);
            this.exportToPdf = bindAble.FindByName<Label>("exportToPdf");
            this.exportToPdf.Focused += this.ExportToPdf_Clicked;
            //// exportToPdf.Clicked += ExportToPdf_Clicked;

            this.exportToExcel = bindAble.FindByName<Label>("exportToExcel");
            this.exportToExcel.Focused += this.ExportToExcel_Clicked;
            //// exportToExcel.Clicked += ExportToExcel_Clicked;

            base.OnAttachedTo(bindAble);
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">SampleView type of bindAble parameter</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            this.dataGrid = null;
            this.pdfImage = null;
            this.excelImage = null;
            base.OnDetachingFrom(bindAble);
        }

        /// <summary>
        /// Triggers while Export to Excel button was clicked
        /// </summary>
        /// <param name="sender">ExportToExcel_Clicked sender</param>
        /// <param name="e">ExportToExcel_Clicked EventArgs e</param>
        private void ExportToExcel_Clicked(object sender, EventArgs e)
        {
            this.ExportToExcel(sender);
        }

        /// <summary>
        /// Triggers while Export to PDF button was clicked
        /// </summary>
        /// <param name="sender">ExportTo PDF _Clicked sender</param>
        /// <param name="e">ExportTo PDF _Clicked EventArgs e</param>
        private void ExportToPdf_Clicked(object sender, EventArgs e)
        {
            this.ExportToPdf(sender);
        }

        /// <summary>
        /// Exports the DataGrid to PDF
        /// </summary>
        /// <param name="obj">object type parameter</param>
        private void ExportToPdf(object obj)
        {
            DataGridPdfExportingController pdfExport = new DataGridPdfExportingController();
            pdfExport.HeaderAndFooterExporting += this.PdfExport_HeaderAndFooterExporting;
            MemoryStream stream = new MemoryStream();
            var doc = pdfExport.ExportToPdf(this.dataGrid, new DataGridPdfExportOption() { FitAllColumnsInOnePage = true });
            if (doc == null)
            {
                return;
            }

            doc.Save(stream);
            doc.Close(true);

            if (Device.RuntimePlatform == Device.UWP)
            {
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("DataGrid.pdf", "application/pdf", stream);
            }
            else
            {
                Xamarin.Forms.DependencyService.Get<ISave>().Save("DataGrid.pdf", "application/pdf", stream);
            }
        }

        /// <summary>
        /// Export the DataGrid to Excel
        /// </summary>
        /// <param name="obj">object type parameter</param>
        private void ExportToExcel(object obj)
        {
            DataGridExcelExportingController excelExport = new DataGridExcelExportingController();
            DataGridExcelExportingOption exportOption = new DataGridExcelExportingOption();
            if (Device.RuntimePlatform == Device.iOS)
            {
                exportOption.ExportColumnWidth = true;
            }

            var excelEngine = excelExport.ExportToExcel(this.dataGrid, exportOption);
            if (excelEngine == null)
            {
                return;
            }

            var workbook = excelEngine.Excel.Workbooks[0];
            if (workbook == null)
            {
                return;
            }

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();

            if (Device.RuntimePlatform == Device.UWP)
            {
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("DataGrid.xlsx", "application/msexcel", stream);
            }
            else
            {
                Xamarin.Forms.DependencyService.Get<ISave>().Save("DataGrid.xlsx", "application/msexcel", stream);
            }
        }

        /// <summary>
        /// Fired when Header and Footer are exported to PDF
        /// </summary>
        /// <param name="sender">PDF Export_HeaderAndFooterExporting sender</param>
        /// <param name="e">PDF Export_HeaderAndFooterExporting EventArgs e</param>
        private void PdfExport_HeaderAndFooterExporting(object sender, PdfHeaderFooterEventArgs e)
        {
            var width = e.PdfPage.GetClientSize().Width;
            PdfStandardFont font = null;
            PdfPageTemplateElement header = new PdfPageTemplateElement(width, 60);
            var assmbely = this.GetType().GetTypeInfo().Assembly;
#if COMMONSB
            var imagestream = assmbely.GetManifestResourceStream("SampleBrowser.Icons.SyncfusionLogo.jpg");
#else
            var imagestream = assmbely.GetManifestResourceStream("SampleBrowser.SfDataGrid.Icons.SyncfusionLogo.jpg");
#endif
            PdfImage pdfImage = PdfImage.FromStream(imagestream);
            header.Graphics.DrawImage(pdfImage, new RectangleF(width - 148, 0, 148, 60));
            if (Device.RuntimePlatform == Device.iOS)
            {
                font = new PdfStandardFont(PdfFontFamily.Helvetica, 18, PdfFontStyle.Bold);
            }
            else
            {
                font = new PdfStandardFont(PdfFontFamily.Helvetica, 13, PdfFontStyle.Bold);
            }

            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);
            header.Graphics.DrawString("Customer Details", font, PdfBrushes.Black, new RectangleF(0, 25, 200, 60), format);
            e.PdfDocumentTemplate.Top = header;
        }
    }
}
