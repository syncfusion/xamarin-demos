#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.XlsIO;
using Syncfusion.SfDataGrid;
using System.IO;
using COLOR = Syncfusion.Drawing;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.ComponentModel;
#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using CGRect = System.Drawing.RectangleF;
using CGPoint = System.Drawing.PointF;
using CGSize = System.Drawing.SizeF;
#endif
namespace SampleBrowser
{
	public partial class BusinessObjects : SampleView
	{
		CGRect frameRect = new CGRect();
		float frameMargin = 8.0f;
		UILabel label;
		UILabel label1;
		UIButton button;
		UIButton btnInput;
		UIButton btnImport;
		SfDataGrid sfGrid;
		BusinessObjectViewModel viewmodel;

		public BusinessObjects()
		{
			label = new UILabel();
			label1 = new UILabel();
			button = new UIButton(UIButtonType.System);
			button.TouchUpInside += OnButtonClicked;
			btnInput = new UIButton(UIButtonType.System);
			btnInput.TouchUpInside += OnButtonInputClicked;
			btnImport = new UIButton(UIButtonType.System);
			btnImport.TouchUpInside += OnButtonImportClicked;

			sfGrid = new SfDataGrid();
			viewmodel = new BusinessObjectViewModel();
			sfGrid.AutoGenerateColumns = false;
			sfGrid.RowHeight = 50;
			sfGrid.AllowEditing = true;
			sfGrid.EditTapAction = TapAction.OnTap;
			sfGrid.ColumnSizer = ColumnSizer.Star;
			sfGrid.SelectionMode = SelectionMode.None;
			sfGrid.HeaderRowHeight = 40;
			sfGrid.ItemsSource = viewmodel.CustomersInfo;

			GridTextColumn salesPerson = new GridTextColumn();
			salesPerson.MappingName = "SalesPerson";
			salesPerson.HeaderText = "Name";
			salesPerson.HeaderTextAlignment = UIKit.UITextAlignment.Center;

			GridTextColumn salesJanJune = new GridTextColumn();
			salesJanJune.MappingName = "SalesJanJune";
			salesJanJune.HeaderText = "Jan-June";
			salesPerson.HeaderTextAlignment = UIKit.UITextAlignment.Center;

			GridTextColumn salesJulyDec = new GridTextColumn();
			salesJulyDec.MappingName = "SalesJulyDec";
			salesJulyDec.HeaderText = "July-Dec";
			salesPerson.HeaderTextAlignment = UIKit.UITextAlignment.Center;

			GridTextColumn change = new GridTextColumn();
			change.MappingName = "Change";
			change.HeaderText = "Change";
			salesPerson.HeaderTextAlignment = UIKit.UITextAlignment.Center;

			sfGrid.Columns.Add(salesPerson);
			sfGrid.Columns.Add(salesJanJune);
			sfGrid.Columns.Add(salesJulyDec);
			sfGrid.Columns.Add(change);
			this.AddSubview(sfGrid);
		}

		void LoadAllowedTextsLabel()
		{

			label.Frame = frameRect;
			label.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
			label.Text = "This sample allows you to import/export data from/to Business Objects.";
			label.Font = UIFont.SystemFontOfSize(15);
			label.Lines = 0;
			label.LineBreakMode = UILineBreakMode.WordWrap;
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				label.Font = UIFont.SystemFontOfSize(18);
				label.Frame = new CGRect(5, 5, frameRect.Location.X + frameRect.Size.Width, 50);
			}
			else
			{
				label.Frame = new CGRect(5, 5, frameRect.Size.Width, 70);

			}
			this.AddSubview(label);


			btnInput.SetTitle("Input Template", UIControlState.Normal);
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				btnInput.Frame = new CGRect(0, 65, frameRect.Location.X + frameRect.Size.Width, 10);
			}
			else
			{
				btnInput.Frame = new CGRect(5, 75, frameRect.Size.Width, 10);

			}
			this.AddSubview(btnInput);

			btnImport.SetTitle("Import From Excel", UIControlState.Normal);
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				btnImport.Frame = new CGRect(0, 95, frameRect.Location.X + frameRect.Size.Width, 10);
			}
			else
			{
				btnImport.Frame = new CGRect(5, 105, frameRect.Size.Width, 10);

			}
			this.AddSubview(btnImport);

			button.SetTitle("Export To Excel", UIControlState.Normal);
			button.Enabled = false;
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				button.Frame = new CGRect(0, 125, frameRect.Location.X + frameRect.Size.Width, 10);
			}
			else
			{
				button.Frame = new CGRect(5, 135, frameRect.Size.Width, 10);

			}
			this.AddSubview(button);


			this.sfGrid.Frame = new CGRect(0, 155, this.Frame.Width, this.Frame.Height-155);
			base.LayoutSubviews();

		}

		void OnButtonInputClicked(object sender, EventArgs e)
		{
			ExcelEngine excelEngine = new ExcelEngine();
			IApplication application = excelEngine.Excel;

			application.DefaultVersion = ExcelVersion.Excel2013;

			#region Initializing Workbook
			string resourcePath = "SampleBrowser.Samples.XlsIO.Template.ExportSales.xlsx";
			Assembly assembly = Assembly.GetExecutingAssembly();
			Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

			IWorkbook workbook = application.Workbooks.Open(fileStream);

			IWorksheet sheet = workbook.Worksheets[0];
			#endregion


			workbook.Version = ExcelVersion.Excel2013;

			MemoryStream stream = new MemoryStream();
			workbook.SaveAs(stream);
			workbook.Close();
			excelEngine.Dispose();

			if (stream != null)
			{
				SaveiOS iOSSave = new SaveiOS();
				iOSSave.Save("InputTemplate.xlsx", "application/msexcel", stream);
			}
		}

		void OnButtonImportClicked(object sender, EventArgs e)
		{
			ExcelEngine excelEngine = new ExcelEngine();
			IApplication application = excelEngine.Excel;

			application.DefaultVersion = ExcelVersion.Excel2013;

			#region Initializing Workbook
			string resourcePath = "SampleBrowser.Samples.XlsIO.Template.ExportSales.xlsx";
			Assembly assembly = Assembly.GetExecutingAssembly();
			Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

			IWorkbook workbook = application.Workbooks.Open(fileStream);

			IWorksheet sheet = workbook.Worksheets[0];
			#endregion


			workbook.Version = ExcelVersion.Excel2013;

            List<CustomerObject> businessObjects = sheet.ExportData<CustomerObject>(1, 1, 41, 4);
			button.Enabled = true;
            sfGrid.ItemsSource = businessObjects;
		}

		void OnButtonClicked(object sender, EventArgs e)
		{
			ExcelEngine excelEngine = new ExcelEngine();
			IApplication application = excelEngine.Excel;
			application.DefaultVersion = ExcelVersion.Excel2013;

			//A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
			//The new workbook will have 1 worksheets
			IWorkbook workbook = application.Workbooks.Create(1);
			//The first worksheet object in the worksheets collection is accessed.
			IWorksheet sheet = workbook.Worksheets[0];

			Assembly assembly = Assembly.GetExecutingAssembly();
			Stream fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Template.BusinessObjects.xml");

			//IEnumerable<BusinessObject> customers = GetBusinessObjectsData(fileStream);
			sheet.ImportData((List<CustomerObject>)sfGrid.ItemsSource, 5, 1, false);

			#region Define Styles
			IStyle pageHeader = workbook.Styles.Add("PageHeaderStyle");
			IStyle tableHeader = workbook.Styles.Add("TableHeaderStyle");

			pageHeader.Font.RGBColor = COLOR.Color.FromArgb(255, 83, 141, 213);
			pageHeader.Font.FontName = "Calibri";
			pageHeader.Font.Size = 18;
			pageHeader.Font.Bold = true;
			pageHeader.HorizontalAlignment = ExcelHAlign.HAlignCenter;
			pageHeader.VerticalAlignment = ExcelVAlign.VAlignCenter;

			tableHeader.Font.Color = ExcelKnownColors.Black;
			tableHeader.Font.Bold = true;
			tableHeader.Font.Size = 11;
			tableHeader.Font.FontName = "Calibri";
			tableHeader.HorizontalAlignment = ExcelHAlign.HAlignCenter;
			tableHeader.VerticalAlignment = ExcelVAlign.VAlignCenter;
			tableHeader.Color = COLOR.Color.FromArgb(255, 118, 147, 60);
			tableHeader.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
			tableHeader.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
			tableHeader.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Thin;
			tableHeader.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
			#endregion

			#region Apply Styles
			// Apply style for header
			sheet["A1:D1"].Merge();
			sheet["A1"].Text = "Yearly Sales Report";
			sheet["A1"].CellStyle = pageHeader;
			sheet["A1"].RowHeight = 20;

			sheet["A2:D2"].Merge();
			sheet["A2"].Text = "Namewise Sales Comparison Report";
			sheet["A2"].CellStyle = pageHeader;
			sheet["A2"].CellStyle.Font.Bold = false;
			sheet["A2"].CellStyle.Font.Size = 16;
			sheet["A2"].RowHeight = 20;

			sheet["A3:A4"].Merge();
			sheet["D3:D4"].Merge();
			sheet["B3:C3"].Merge();
			sheet["B3"].Text = "Sales";
			sheet["A3:D4"].CellStyle = tableHeader;

			sheet["A3"].Text = "Sales Person";
			sheet["B4"].Text = "Jan - Jun";
			sheet["C4"].Text = "Jul - Dec";
			sheet["D3"].Text = "Change (%)";

			sheet.Columns[0].ColumnWidth = 19;
			sheet.Columns[1].ColumnWidth = 10;
			sheet.Columns[2].ColumnWidth = 10;
			sheet.Columns[3].ColumnWidth = 11;
			#endregion

			workbook.Version = ExcelVersion.Excel2013;

			MemoryStream stream = new MemoryStream();
			workbook.SaveAs(stream);
			workbook.Close();
			excelEngine.Dispose();

			if (stream != null)
			{
				SaveiOS iOSSave = new SaveiOS();
				iOSSave.Save("ImportBusinessObjects.xlsx", "application/msexcel", stream);
			}

		}

		public override void LayoutSubviews()
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				frameMargin = 0.0f;
			}
			frameRect = Bounds;
			frameRect.Location = new CGPoint(frameRect.Location.X + frameMargin, frameRect.Location.Y + 1.5f * frameMargin);
			frameRect.Size = new CGSize(frameRect.Size.Width - (frameRect.Location.X + frameMargin), frameRect.Size.Height - (frameRect.Location.Y + 1.5f * frameMargin));

			LoadAllowedTextsLabel();

			base.LayoutSubviews();
		}

		private IEnumerable<BusinessObject> GetBusinessObjectsData(Stream xml)
		{
			XmlReader reader = XmlReader.Create(xml);


			List<BusinessObject> collection = new List<BusinessObject>();

			string name = "";
			int firstHalf = 0;
			int secondHalf = 0;
			int value = 0;

			while (reader.Read())
			{
				if (reader.IsStartElement())
				{
					switch (reader.Name)
					{
						case "Customers":
							while (reader.Read())
							{
								if (reader.IsStartElement())
								{
									switch (reader.Name)
									{

										case "SalesPerson":
											reader.Read();
											name = reader.Value;
											break;
										case "SalesJanJune":
											reader.Read();
											firstHalf = XmlConvert.ToInt32(reader.Value);
											break;
										case "SalesJulyDec":
											reader.Read();
											secondHalf = XmlConvert.ToInt32(reader.Value);
											break;
										case "Change":
											reader.Read();
											value = XmlConvert.ToInt32(reader.Value);
											BusinessObject temp = new BusinessObject();
											temp.SalesPerson = name;
											temp.SalesJanJune = firstHalf;
											temp.SalesJulyDec = secondHalf;
											temp.Change = value;
											collection.Add(temp);
											break;
									}
								}
								else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Customers")
									break;
							}
							break;

					}
				}
			}

			return collection.AsEnumerable();

		}

	}

    [Preserve(AllMembers = true)]
	public class BusinessObjectViewModel : INotifyPropertyChanged
	{
		private bool isDataGridExported;

		public bool IsDataGridExported
		{
			get
			{
				return isDataGridExported;
			}
			set
			{
				isDataGridExported = value;
				RaisePropertyChanged("IsDataGridExported");
			}
		}
		public BusinessObjectViewModel()
		{
			CustomersInfo = new List<CustomerObject>();
			foreach (int i in Enumerable.Range(1, 20))
			{
				CustomersInfo.Add(new CustomerObject());
			}
		}

		#region ItemsSource
		private List<CustomerObject> customersInfo;
		public List<CustomerObject> CustomersInfo
		{
			get { return customersInfo; }
			set { this.customersInfo = value; RaisePropertyChanged("CustomersInfo"); }
		}
		#endregion

		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged(String name)
		{
			if (PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(name));
		}
		#endregion
	}



	/// <summary>
	/// Class used to store the customer details
	/// </summary>
    /// 
    [Preserve(AllMembers = true)]
	public class CustomerObject : INotifyPropertyChanged
	{
		public CustomerObject()
		{
		}

		#region private variables

		private string _salesPerson;
		private int _salesJanJune;
		private int _salesJulyDec;
		private string _change;

		#endregion

		#region Public Properties

		public string SalesPerson
		{
			get
			{
				return _salesPerson;
			}
			set
			{
				this._salesPerson = value;
				RaisePropertyChanged("SalesPerson");
			}
		}

		public int SalesJanJune
		{
			get
			{
				return _salesJanJune;
			}
			set
			{
				this._salesJanJune = value;
				RaisePropertyChanged("SalesJanJune");
			}
		}

		public int SalesJulyDec
		{
			get
			{
				return _salesJulyDec;
			}
			set
			{
				this._salesJulyDec = value;
				RaisePropertyChanged("SalesJulyDec");
			}
		}

		public string Change
		{
			get
			{
				return _change;
			}
			set
			{
				this._change = value;
				RaisePropertyChanged("Change");
			}
		}
		#endregion

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged(String Name)
		{
			if (PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(Name));
		}

		#endregion
	}
}
