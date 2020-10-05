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
	public partial class CollectionObjects : SampleView
	{
		CGRect frameRect = new CGRect();
		float frameMargin = 8.0f;
		UILabel label;
		UILabel label1;
		UIButton button;
		UIButton btnInput;
		UIButton btnImport;
		SfDataGrid sfGrid;
		CLRObjectViewModel viewmodel;

		public CollectionObjects()
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
			viewmodel = new CLRObjectViewModel();
			sfGrid.AutoGenerateColumns = false;
			sfGrid.RowHeight = 50;
			sfGrid.AllowEditing = true;
			sfGrid.EditTapAction = TapAction.OnTap;
			sfGrid.ColumnSizer = ColumnSizer.Star;
			sfGrid.SelectionMode = SelectionMode.None;
			sfGrid.HeaderRowHeight = 40;
			sfGrid.ItemsSource = viewmodel.CustomersInfo;

			GridTextColumn brand = new GridTextColumn();
            brand.MappingName = "BrandName";
            brand.HeaderText = "Brand";
            brand.HeaderTextAlignment = UIKit.UITextAlignment.Center;

			GridTextColumn vehicleType = new GridTextColumn();
            vehicleType.MappingName = "VehicleType.VehicleName";
            vehicleType.HeaderText = "Vehicle Type";
            vehicleType.HeaderTextAlignment = UIKit.UITextAlignment.Center;

			GridTextColumn model = new GridTextColumn();
            model.MappingName = "VehicleType.Model.ModelName";
            model.HeaderText = "Model";
            model.HeaderTextAlignment = UIKit.UITextAlignment.Center;

			sfGrid.Columns.Add(brand);
			sfGrid.Columns.Add(vehicleType);
			sfGrid.Columns.Add(model);
			this.AddSubview(sfGrid);
		}

		void LoadAllowedTextsLabel()
		{

			label.Frame = frameRect;
			label.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
			label.Text = "This sample allows you to import/export data from/to Collection Objects.";
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
			string resourcePath = "SampleBrowser.Samples.XlsIO.Template.ExportData.xlsx";
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
			string resourcePath = "SampleBrowser.Samples.XlsIO.Template.ExportData.xlsx";
			Assembly assembly = Assembly.GetExecutingAssembly();
			Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

			IWorkbook workbook = application.Workbooks.Open(fileStream);

			IWorksheet sheet = workbook.Worksheets[0];
			#endregion

            Dictionary<string, string> mappingProperties = new Dictionary<string, string>();
            mappingProperties.Add("Brand", "BrandName");
            mappingProperties.Add("Vehicle Type", "VehicleType.VehicleName");
            mappingProperties.Add("Model", "VehicleType.Model.ModelName");

            List<Brand> CLRObjects = sheet.ExportData<Brand>(4, 1, 141, 3, mappingProperties);

            button.Enabled = true;
            sfGrid.ItemsSource = CLRObjects;
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
			IWorksheet worksheet = workbook.Worksheets[0];

            worksheet.ImportData((List<Brand>)sfGrid.ItemsSource, 4, 1, true);

            #region Define Styles
            IStyle pageHeader = workbook.Styles.Add("PageHeaderStyle");
            IStyle tableHeader = workbook.Styles.Add("TableHeaderStyle");

            pageHeader.Font.FontName = "Calibri";
            pageHeader.Font.Size = 16;
            pageHeader.Font.Bold = true;
            pageHeader.Color = Color.FromArgb(0, 146, 208, 80);
            pageHeader.HorizontalAlignment = ExcelHAlign.HAlignCenter;
            pageHeader.VerticalAlignment = ExcelVAlign.VAlignCenter;

            tableHeader.Font.Bold = true;
            tableHeader.Font.FontName = "Calibri";
            tableHeader.Color = Color.FromArgb(0, 146, 208, 80);

            #endregion

            #region Apply Styles
            // Apply style for header
            worksheet["A1:C2"].Merge();
            worksheet["A1"].Text = "Automobile Brands in the US";
            worksheet["A1"].CellStyle = pageHeader;

            worksheet["A4:C4"].CellStyle = tableHeader;

            worksheet["A1:C1"].CellStyle.Font.Bold = true;
            worksheet.UsedRange.AutofitColumns();

            #endregion

            workbook.Version = ExcelVersion.Excel2013;

			MemoryStream stream = new MemoryStream();
			workbook.SaveAs(stream);
			workbook.Close();
			excelEngine.Dispose();

			if (stream != null)
			{
				SaveiOS iOSSave = new SaveiOS();
				iOSSave.Save("ImportCollectionObjects.xlsx", "application/msexcel", stream);
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


	}

    [Preserve(AllMembers = true)]
	public class CLRObjectViewModel : INotifyPropertyChanged
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
		public CLRObjectViewModel()
		{
			CustomersInfo = new List<Brand>();
			foreach (int i in Enumerable.Range(1, 20))
			{
				CustomersInfo.Add(new Brand());
			}
		}

		#region ItemsSource
		private List<Brand> customersInfo;
		public List<Brand> CustomersInfo
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

    public class Brand
    {
        private string m_brandName;
        [DisplayNameAttribute("Brand")]
        public string BrandName
        {
            get { return m_brandName; }
            set
            {
                m_brandName = value;
                RaisePropertyChanged("BrandName");
            }
        }

        private VehicleType m_vehicleType;
        public VehicleType VehicleType
        {
            get { return m_vehicleType; }
            set
            {
                m_vehicleType = value;
                RaisePropertyChanged("VehicleType");
            }
        }

        public Brand(string brandName)
        {
            m_brandName = brandName;
        }
        public Brand()
        {

        }
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(String Name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(Name));
        }
        #endregion
    }

    public class VehicleType
    {
        private string m_vehicleName;
        [DisplayNameAttribute("Vehicle Type")]
        public string VehicleName
        {
            get { return m_vehicleName; }
            set
            {
                m_vehicleName = value;
                RaisePropertyChanged("VehicleName");
            }
        }

        private ModelObject m_model;
        public ModelObject Model
        {
            get { return m_model; }
            set
            {
                m_model = value;
                RaisePropertyChanged("Model");
            }
        }

        public VehicleType(string vehicle)
        {
            m_vehicleName = vehicle;
        }
        public VehicleType()
        {

        }
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(String Name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(Name));
        }
        #endregion
    }

    public class ModelObject
    {
        private string m_modelName;
        [DisplayNameAttribute("Model")]
        public string ModelName
        {
            get { return m_modelName; }
            set
            {
                m_modelName = value;
                RaisePropertyChanged("ModelName");
            }
        }

        public ModelObject(string name)
        {
            m_modelName = name;
        }
        public ModelObject()
        {

        }
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
