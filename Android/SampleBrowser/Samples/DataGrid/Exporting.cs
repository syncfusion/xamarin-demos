#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Syncfusion.SfDataGrid;
using System.Globalization;
using Syncfusion.SfDataGrid.Exporting;
using System.Reflection;
using System.IO;
using Java.IO;
using Android.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using Android.Content.Res;
using Android.Support.V4.Content;
using Android;
using Android.Content.PM;
using Android.Support.V4.App;

namespace SampleBrowser
{
    public class Exporting : SamplePage
    {
        #region Fields

        SfDataGrid sfGrid;
        ExportingViewModel viewModel;
        Button exportPdf;
        Button exportExcel;
        ImageView pdfImage;
        ImageView excelImage;
        Label spacing;

        #endregion

        public override Android.Views.View GetSampleContent(Context context)
        {
            sfGrid = new SfDataGrid(context);
            if (ContextCompat.CheckSelfPermission(context, Manifest.Permission.WriteExternalStorage) != Permission.Granted)
            {
                ActivityCompat.RequestPermissions((Android.App.Activity)context, new String[] { Manifest.Permission.WriteExternalStorage }, 1);
            }
            sfGrid.SelectionMode = SelectionMode.Single;
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            viewModel = new ExportingViewModel();
            sfGrid.AutoGeneratingColumn += GridGenerateColumns;
            sfGrid.ItemsSource = (viewModel.OrdersInfo);
            pdfImage = new ImageView(context);
            pdfImage.Touch += ExportToPdf;
            pdfImage.SetImageResource(Resource.Drawable.pdfexport);
            pdfImage.SetPadding((int)(10 * Resources.System.DisplayMetrics.Density), 0, 0, 0);

            exportPdf = new Button(context);
            exportPdf.Text = "Export PDF";
            exportPdf.SetTextSize(Android.Util.ComplexUnitType.Px, 12 * Resources.System.DisplayMetrics.Density);
            exportPdf.Click += ExportToPdf;
            exportPdf.SetBackgroundColor(Android.Graphics.Color.Transparent);
            exportPdf.SetTextColor(Android.Graphics.Color.ParseColor("#666666"));
            exportPdf.SetPadding(0, 0, (int)(10 * Resources.System.DisplayMetrics.Density), 0);

            excelImage = new ImageView(context);
            excelImage.Touch += ExportToExcel;
            excelImage.SetImageResource(Resource.Drawable.excelexport);
            excelImage.SetPadding((int)(10 * Resources.System.DisplayMetrics.Density), 0, 0, 0);

            exportExcel = new Button(context);
            exportExcel.Text = "Export Excel";
            exportExcel.SetTextSize(Android.Util.ComplexUnitType.Px, 12 * Resources.System.DisplayMetrics.Density);
            exportExcel.Click += ExportToExcel;
            exportExcel.SetBackgroundColor(Android.Graphics.Color.Transparent);
            exportExcel.SetTextColor(Android.Graphics.Color.ParseColor("#666666"));
            exportExcel.SetPadding(0, 0, (int)(10 * Resources.System.DisplayMetrics.Density), 0);

            spacing = new Label(context);
            spacing.SetBackgroundColor(Android.Graphics.Color.Transparent);
          
            LinearLayout excelOption = new LinearLayout(context);
            excelOption.SetGravity(GravityFlags.Center);
            excelOption.Orientation = Android.Widget.Orientation.Horizontal;
            excelOption.AddView(excelImage, Convert.ToInt32(50 * sfGrid.Resources.DisplayMetrics.Density), Convert.ToInt32(56 * sfGrid.Resources.DisplayMetrics.Density));
            excelOption.AddView(exportExcel, Convert.ToInt32(100 * sfGrid.Resources.DisplayMetrics.Density), Convert.ToInt32(56 * sfGrid.Resources.DisplayMetrics.Density));
            LinearLayout.LayoutParams excelLayoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
            excelLayoutParams.Gravity = GravityFlags.CenterHorizontal;
            excelOption.LayoutParameters = excelLayoutParams;
            excelOption.SetPadding((int)(10 * Resources.System.DisplayMetrics.Density), 0 , (int)(10 * Resources.System.DisplayMetrics.Density), 0 );
            excelOption.SetBackgroundResource(Resource.Layout.backgroundborder);

            LinearLayout pdfOption = new LinearLayout(context );
            pdfOption.SetGravity(GravityFlags.Center);
            pdfOption.Orientation = Android.Widget.Orientation.Horizontal;
            pdfOption.AddView(pdfImage, Convert.ToInt32(50 * sfGrid.Resources.DisplayMetrics.Density), Convert.ToInt32(56 * sfGrid.Resources.DisplayMetrics.Density));
            pdfOption.AddView(exportPdf, Convert.ToInt32(100 * sfGrid.Resources.DisplayMetrics.Density), Convert.ToInt32(56 * sfGrid.Resources.DisplayMetrics.Density));
            LinearLayout.LayoutParams pdfLayoutparams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
            pdfLayoutparams.Gravity = GravityFlags.CenterHorizontal;
            pdfOption.LayoutParameters = pdfLayoutparams;
            pdfOption.SetPadding((int)(10 * Resources.System.DisplayMetrics.Density), 0, (int)(10 * Resources.System.DisplayMetrics.Density), 0 );
            pdfOption.SetBackgroundResource(Resource.Layout.backgroundborder);

            LinearLayout option = new LinearLayout(context);
            option.SetGravity(GravityFlags.Center);
            option.Orientation = Android.Widget.Orientation.Horizontal;
            option.AddView(pdfOption, Convert.ToInt32(150 * sfGrid.Resources.DisplayMetrics.Density), Convert.ToInt32(46 * sfGrid.Resources.DisplayMetrics.Density));
            option.AddView(spacing, Convert.ToInt32(20 * sfGrid.Resources.DisplayMetrics.Density), Convert.ToInt32(46 * sfGrid.Resources.DisplayMetrics.Density));
            option.AddView(excelOption, Convert.ToInt32(150 * sfGrid.Resources.DisplayMetrics.Density), Convert.ToInt32(46 * sfGrid.Resources.DisplayMetrics.Density));
            LinearLayout.LayoutParams layoutparams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
            layoutparams.Gravity = GravityFlags.Start;
            option.SetPadding((int)(10 * Resources.System.DisplayMetrics.Density), (int)(10 * Resources.System.DisplayMetrics.Density), 0, (int)(10 * Resources.System.DisplayMetrics.Density));
            option.LayoutParameters = layoutparams;

            LinearLayout mainView = new LinearLayout(context);
            mainView.Orientation = Android.Widget.Orientation.Vertical;
            mainView.AddView(option);
            mainView.AddView(sfGrid);
            return mainView;
        }

        private void ExportToExcel(object sender, EventArgs e)
        {
            DataGridExcelExportingController excelExport = new DataGridExcelExportingController();
            var excelEngine = excelExport.ExportToExcel(this.sfGrid, new DataGridExcelExportingOption() { ExportRowHeight = false, ExportColumnWidth = false, DefaultColumnWidth = 100, DefaultRowHeight = 60 });
            var workbook = excelEngine.Excel.Workbooks[0];
            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();
            Save("DataGrid.xlsx", "application/msexcel", stream , sfGrid.Context);
        }

        private void ExportToPdf(object sender, EventArgs e)
        {
            DataGridPdfExportingController pdfExport = new DataGridPdfExportingController();
            pdfExport.HeaderAndFooterExporting += pdfExport_HeaderAndFooterExporting;
            MemoryStream stream = new MemoryStream();
            var doc = pdfExport.ExportToPdf(this.sfGrid);
            doc.Save(stream);
            doc.Close(true);
            Save("DataGrid.pdf", "application/pdf", stream, sfGrid.Context);
        }

        private void pdfExport_HeaderAndFooterExporting(object sender, PdfHeaderFooterEventArgs e)
        {
            var width = e.PdfPage.GetClientSize().Width;

            PdfPageTemplateElement header = new PdfPageTemplateElement(width, 60);
            var assmbely = Assembly.GetExecutingAssembly();
            var imagestream = assmbely.GetManifestResourceStream("SampleBrowser.Resources.drawable.SyncfusionLogo.jpg");
            if (imagestream != null)
            {
                PdfImage pdfImage = PdfImage.FromStream(imagestream);
                header.Graphics.DrawImage(pdfImage, new RectangleF(0, 0, width, 50));
                e.PdfDocumentTemplate.Top = header;
            }
        }

        public void Save(string fileName, String contentType, MemoryStream stream , Context context)
        {
            string exception = string.Empty;
            string root = null;
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
            }
            else
                root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            Java.IO.File myDir = new Java.IO.File(root + "/Syncfusion");
            myDir.Mkdir();

            Java.IO.File file = new Java.IO.File(myDir, fileName);

            if (file.Exists())
            {
                file.Delete();
                file.CreateNewFile();
            }
            try
            {
                FileOutputStream outs = new FileOutputStream(file, false);
                outs.Write(stream.ToArray());

                outs.Flush();
                outs.Close();
            }
            catch (Exception e)
            {
                exception = e.ToString();
            }
            if (file.Exists() && contentType != "application/html")
            {
                Android.Net.Uri path = FileProvider.GetUriForFile(Android.App.Application.Context, Android.App.Application.Context.PackageName + ".provider", file);
                string extension = Android.Webkit.MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
                string mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
                Intent intent = new Intent(Intent.ActionView);
                intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);
                intent.SetDataAndType(path, mimeType);
                intent.AddFlags(ActivityFlags.GrantReadUriPermission);
                context.StartActivity(Intent.CreateChooser(intent, "Choose App"));

            }
        }

        void GridGenerateColumns(object sender, AutoGeneratingColumnEventArgs e)
        {
            if (e.Column.MappingName == "OrderID")
            {
                e.Column.HeaderText = "Order ID";
            }
            else if (e.Column.MappingName == "CustomerID")
            {
                e.Column.HeaderText = "Customer ID";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "Freight")
            {
                e.Column.Format = "C";
                e.Column.CultureInfo = new CultureInfo("en-US");
                e.Column.TextAlignment = GravityFlags.Center;
            }
            else if (e.Column.MappingName == "ShipCity")
            {
                e.Column.HeaderText = "Ship City";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "ShipCountry")
            {
                e.Column.HeaderText = "Ship Country";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "EmployeeID")
            {
                e.Column.HeaderText = "Employee ID";
                e.Column.TextAlignment = GravityFlags.Center;
            }
            else if (e.Column.MappingName == "FirstName")
            {
                e.Column.HeaderText = "First Name";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "LastName")
            {
                e.Column.HeaderText = "Last Name";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "Gender")
            {
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "ShippingDate")
            {
                e.Column.HeaderText = "Shipping Date";
                e.Column.Format = "d";
            }
            else if (e.Column.MappingName == "IsClosed")
            {
                e.Column.HeaderText = "Is Closed";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
        }

        public override void Destroy()
        {
            sfGrid.AutoGeneratingColumn -= GridGenerateColumns;
            sfGrid.Dispose();
            sfGrid = null;
            viewModel = null;
        }

    }
}