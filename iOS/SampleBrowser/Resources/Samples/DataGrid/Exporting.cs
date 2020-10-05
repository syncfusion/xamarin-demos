#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using CoreGraphics;
using Foundation;
using QuickLook;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.SfDataGrid;
using Syncfusion.SfDataGrid.Exporting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Reflection;
using UIKit;

namespace SampleBrowser
{
    public class Exporting : SampleView
    {
        #region Fields

        SfDataGrid SfGrid;
        UIButton exportPdf;
        UIButton exportExcel;
        CustomView excelView;
        CustomView pdfView;
        UIButton exportPDfImage;
        UIButton exportExcelImage;

#endregion

        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

		public Exporting()
		{
			this.SfGrid = new SfDataGrid();
			this.SfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
            this.SfGrid.SelectionMode = SelectionMode.Single;
			this.SfGrid.ItemsSource = new ExportingViewModel().OrdersInfo;
			this.SfGrid.ShowRowHeader = false;
			this.SfGrid.HeaderRowHeight = 45;
			this.SfGrid.RowHeight = 45;

            exportPDfImage = new UIButton();
            exportPDfImage.SetImage(UIImage.FromFile("Images/pdfexport.png"), UIControlState.Normal);
            exportPDfImage.TouchDown += ExportToPdf;

            exportPdf = new UIButton(UIButtonType.RoundedRect);
			exportPdf.SetTitleColor (UIColor.Black, UIControlState.Normal);
			exportPdf.SetTitle("Export To Pdf",UIControlState.Normal);
            exportPdf.Font = UIFont.SystemFontOfSize(11);
            exportPdf.TouchDown += ExportToPdf;

            exportExcelImage = new UIButton();
            exportExcelImage.SetImage(UIImage.FromFile("Images/excelexport.png"), UIControlState.Normal);
            exportExcelImage.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            exportExcelImage.TouchDown += ExportToExcel;

			exportExcel = new UIButton(UIButtonType.RoundedRect);
            exportExcel.Font = UIFont.SystemFontOfSize(11);
			exportExcel.SetTitle("Export To Excel", UIControlState.Normal);
            exportExcel.SetTitleColor(UIColor.Black, UIControlState.Normal);
            exportExcel.TouchDown += ExportToExcel;

            UIButton b = new UIButton();
            b.Font = UIFont.SystemFontOfSize(5);

            excelView = new CustomView();
            excelView.AddSubviews((exportExcelImage));
            excelView.AddSubviews((exportExcel));

            pdfView = new CustomView();
            pdfView.AddSubviews(exportPDfImage);
            pdfView.AddSubviews(exportPdf);

            this.AddSubview(excelView);            
            this.AddSubview(pdfView);            
			this.AddSubview(this.SfGrid);
		}

		private void ExportToExcel(object sender, EventArgs e)
		{
			DataGridExcelExportingController excelExport = new DataGridExcelExportingController();
			var excelEngine = excelExport.ExportToExcel(this.SfGrid , new DataGridExcelExportingOption() {ExportRowHeight = false,ExportColumnWidth = false , DefaultColumnWidth = 100, DefaultRowHeight =  60});
			var workbook = excelEngine.Excel.Workbooks[0];
			MemoryStream stream = new MemoryStream();
			workbook.SaveAs(stream);
			workbook.Close();
			excelEngine.Dispose();
			Save("DataGrid.xlsx", "application/msexcel", stream);
		}

		private void ExportToPdf(object sender, EventArgs e)
		{
			DataGridPdfExportingController pdfExport = new DataGridPdfExportingController();
			MemoryStream stream = new MemoryStream();
			pdfExport.HeaderAndFooterExporting += pdfExport_HeaderAndFooterExporting;
			var doc = pdfExport.ExportToPdf(this.SfGrid);
			doc.Save(stream);
			doc.Close(true);
			Save("DataGrid.pdf", "application/pdf", stream);
		}

		private void pdfExport_HeaderAndFooterExporting(object sender, PdfHeaderFooterEventArgs e)
		{
			var width = e.PdfPage.GetClientSize().Width;

			PdfPageTemplateElement header = new PdfPageTemplateElement(width, 60);
			var assmbely = Assembly.GetExecutingAssembly();
			var imagestream = assmbely.GetManifestResourceStream("SampleBrowser.Resources.Images.SyncfusionLogo.jpg");
			PdfImage pdfImage = PdfImage.FromStream(imagestream);
			header.Graphics.DrawImage(pdfImage, new RectangleF(0, 0, width, 50));
			e.PdfDocumentTemplate.Top = header;
		}


		private void Save(string filename, string contentType, MemoryStream stream)
		{
			string exception = string.Empty;
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string filePath = Path.Combine(path, filename);
			try
			{
				FileStream fileStream = File.Open(filePath, FileMode.Create);
				stream.Position = 0;
				stream.CopyTo(fileStream);
				fileStream.Flush();
				fileStream.Close();
			}
			catch (Exception e)
			{
				exception = e.ToString();
			}
			if (contentType == "application/html" || exception != string.Empty)
				return;
			UIViewController currentController = UIApplication.SharedApplication.KeyWindow.RootViewController;
			while (currentController.PresentedViewController != null)
				currentController = currentController.PresentedViewController;
			UIView currentView = currentController.View;

			QLPreviewController qlPreview = new QLPreviewController();
			QLPreviewItem item = new QLPreviewItemBundles(filename, filePath);
			qlPreview.DataSource = new PreviewControllersDS(item);

			currentController.PresentViewController((UIViewController)qlPreview, true, (Action)null);
		}

		void GridAutoGenerateColumns(object sender, AutoGeneratingColumnEventArgs e)
		{
			if (e.Column.MappingName == "OrderID")
			{
				e.Column.HeaderText = "Order ID";
				e.Column.TextAlignment = UITextAlignment.Center;
			}
			else if (e.Column.MappingName == "CustomerID")
			{
				e.Column.HeaderText = "Customer ID";
				e.Column.TextMargin = 10;
				e.Column.TextAlignment = UITextAlignment.Left;
			}
			else if (e.Column.MappingName == "Freight")
			{
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo("en-US");
				e.Column.TextAlignment = UITextAlignment.Center;
			}
			else if (e.Column.MappingName == "ShipCity")
			{
				e.Column.HeaderText = "Ship City";
				e.Column.TextMargin = 10;
				e.Column.TextAlignment = UITextAlignment.Left;
			}
			else if (e.Column.MappingName == "ShipCountry")
			{
				e.Column.HeaderText = "Ship Country";
				e.Column.TextMargin = 10;
				e.Column.TextAlignment = UITextAlignment.Left;
			}
			else if (e.Column.MappingName == "Index")
			{
				e.Column.TextAlignment = UITextAlignment.Center;
			}
			else if (e.Column.MappingName == "EmployeeID")
			{
				e.Column.HeaderText = "Employee ID";
				e.Column.TextAlignment = UITextAlignment.Center;
			}
			else if (e.Column.MappingName == "FirstName")
			{
				e.Column.HeaderText = "First Name";
				e.Column.TextMargin = 10;
				e.Column.TextAlignment = UITextAlignment.Left;
			}
			else if (e.Column.MappingName == "LastName")
			{
				e.Column.HeaderText = "Last Name";
				e.Column.TextMargin = 10;
				e.Column.TextAlignment = UITextAlignment.Left;
			}
			else if (e.Column.MappingName == "Gender")
			{
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.TextMargin = 10;
			}
			else if (e.Column.MappingName == "ShippingDate")
			{
				e.Column.HeaderText = "Shipping Date";
				e.Column.TextMargin = 15;
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.Format = "d";
			}
			else if (e.Column.MappingName == "IsClosed")
			{
				e.Column.HeaderText = "Is Closed";
				e.Column.TextMargin = 15;
				e.Column.TextAlignment = UITextAlignment.Left;
			}
		}

		public override void LayoutSubviews()
		{
            this.pdfView.Frame = new CGRect((this.Frame.Left + 5), 10, ((this.Frame.Right / 2)- 30), 50);
            this.excelView.Frame = new CGRect(pdfView.Frame.Right, 10, ((this.Frame.Right / 2) - 30), 50);
            this.SfGrid.Frame = new CGRect(0, 70, this.Frame.Width, this.Frame.Height - 70);
            base.LayoutSubviews();
        }

        protected override void Dispose(bool disposing)
        {
            exportPDfImage.TouchDown -= ExportToPdf;
            exportPdf.TouchDown -= ExportToPdf;
            exportExcelImage.TouchDown -= ExportToExcel;
            exportExcel.TouchDown -= ExportToExcel;
            SfGrid.Dispose();
            base.Dispose(disposing);
        }
    }

	public class QLPreviewItemBundles : QLPreviewItem
	{
		string _fileName, _filePath;
		public QLPreviewItemBundles(string fileName, string filePath)
		{
			_fileName = fileName;
			_filePath = filePath;
		}

		public override string ItemTitle
		{
			get
			{
				return _fileName;
			}
		}
		public override NSUrl ItemUrl
		{
			get
			{
				var documents = NSBundle.MainBundle.BundlePath;
				var lib = Path.Combine(documents, _filePath);
				var url = NSUrl.FromFilename(lib);
				return url;
			}
		}
	}

	public class PreviewControllersDS : QLPreviewControllerDataSource
	{
		private QLPreviewItem _item;

		public PreviewControllersDS(QLPreviewItem item)
		{
			_item = item;
		}

		public override nint PreviewItemCount(QLPreviewController controller)
		{
			return (nint)1;
		}

		public override IQLPreviewItem GetPreviewItem(QLPreviewController controller, nint index)
		{
			return _item;
		}
	}

    public class CustomView : UIView
    {
        public CustomView() : base()
        {
            this.Layer.BorderColor = UIColor.Gray.CGColor;
            this.Layer.BorderWidth = 1;
                
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            this.Subviews[0].Frame = new CGRect(0, 10, 30, 26);
            this.Subviews[1].Frame = new CGRect(30, 10, 85, 30);
        }
    }
}
