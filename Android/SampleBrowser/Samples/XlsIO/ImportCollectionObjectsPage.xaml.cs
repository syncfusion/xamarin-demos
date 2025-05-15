#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using COLOR = Syncfusion.Drawing;
using System.Xml;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using SampleBrowser;
using Android.App;
using Syncfusion.SfDataGrid;
using System.ComponentModel;

namespace SampleBrowser
{
    public partial class ImportCollectionObjectsPage : SamplePage
    {
        private Context m_context;
        SfDataGrid sfGrid;
        Button btnExport;
        CLRObjectViewModel viewmodel;
        public override View GetSampleContent(Context con)
        {
            LinearLayout linear = new LinearLayout(con);
            linear.SetBackgroundColor(Color.White);
            linear.Orientation = Orientation.Vertical;
            linear.SetPadding(10, 10, 10, 10);

            TextView text2 = new TextView(con);
            text2.TextSize = 17;
            text2.TextAlignment = TextAlignment.Center;
            text2.Text = "This sample allows you to import/export data from/to CLR Objects.";
            text2.SetTextColor(Color.ParseColor("#262626"));
            text2.SetPadding(5, 5, 5, 5);

            linear.AddView(text2);

            m_context = con;

            Button btnInput = new Button(con);
            btnInput.Text = "Input Template";
            btnInput.Click += ButtonInputClicked;
            linear.AddView(btnInput);

            Button btnImport = new Button(con);
            btnImport.Text = "Import From Excel";
            btnImport.Click += ButtonImportClicked;
            linear.AddView(btnImport);

            btnExport = new Button(con);
            btnExport.Text = "Export To Excel";
            btnExport.Click += ButtonExportClicked;
            btnExport.Enabled = false;
            linear.AddView(btnExport);

            sfGrid = new SfDataGrid(con);
            viewmodel = new CLRObjectViewModel();
            sfGrid.AutoGenerateColumns = false;
            sfGrid.RowHeight = 50;
            sfGrid.AllowEditing = true;
            sfGrid.EditTapAction = TapAction.OnTap;
            sfGrid.ColumnSizer = ColumnSizer.Star;
            sfGrid.SelectionMode = SelectionMode.None;
            sfGrid.HeaderRowHeight = 40;
            sfGrid.ItemsSource = viewmodel.CustomersInfo;
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;

            GridTextColumn brand = new GridTextColumn();
            brand.MappingName = "BrandName";
            brand.HeaderText = "Brand";
            //salesPerson.ItemsSource = viewmodel.CustomersInfo;
            brand.HeaderTextAlignment = GravityFlags.Center;

            GridTextColumn vehicleType = new GridTextColumn();
            vehicleType.MappingName = "VehicleType.VehicleName";
            vehicleType.HeaderText = "Vehicle Type";
            // salesJanJune.ItemsSource = viewmodel.CustomersInfo;
            vehicleType.HeaderTextAlignment = GravityFlags.Center;

            GridTextColumn model = new GridTextColumn();
            model.MappingName = "VehicleType.Model.ModelName";
            model.HeaderText = "Model";
            //salesJulyDec.ItemsSource = viewmodel.CustomersInfo;
            model.HeaderTextAlignment = GravityFlags.Center;

            sfGrid.Columns.Add(brand);
            sfGrid.Columns.Add(vehicleType);
            sfGrid.Columns.Add(model);
            linear.AddView(sfGrid);
            return linear;
        }

        void ButtonInputClicked(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;

            application.DefaultVersion = ExcelVersion.Excel2013;

            string resourcePath = "";
            resourcePath = "SampleBrowser.Samples.XlsIO.Template.ExportData.xlsx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            IWorkbook workbook = application.Workbooks.Open(fileStream);
            IWorksheet sheet = workbook.Worksheets[0];

            workbook.Version = ExcelVersion.Excel2013;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();

            if (stream != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save("Input Template.xlsx", "application/msexcel", stream, m_context);
            }
        }

        void ButtonImportClicked(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;

            application.DefaultVersion = ExcelVersion.Excel2013;

            string resourcePath = "";
            resourcePath = "SampleBrowser.Samples.XlsIO.Template.ExportData.xlsx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            IWorkbook workbook = application.Workbooks.Open(fileStream);
            IWorksheet sheet = workbook.Worksheets[0];

            workbook.Version = ExcelVersion.Excel2013;

            Dictionary<string, string> mappingProperties = new Dictionary<string, string>();
            mappingProperties.Add("Brand", "BrandName");
            mappingProperties.Add("Vehicle Type", "VehicleType.VehicleName");
            mappingProperties.Add("Model", "VehicleType.Model.ModelName");

            List<Brand> CLRObjects = sheet.ExportData<Brand>(4, 1, 141, 3, mappingProperties);
            
            sfGrid.ItemsSource = CLRObjects;
            btnExport.Enabled = true;
        }

        void ButtonExportClicked(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            #region Initializing Workbook
            //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
            //The new workbook will have 1 worksheets
            IWorkbook workbook = application.Workbooks.Create(1);
            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];
            
            sheet.ImportData((List<Brand>)sfGrid.ItemsSource, 4, 1, true);

            #region Define Styles
            IStyle pageHeader = workbook.Styles.Add("PageHeaderStyle");
            IStyle tableHeader = workbook.Styles.Add("TableHeaderStyle");

            pageHeader.Font.FontName = "Calibri";
            pageHeader.Font.Size = 16;
            pageHeader.Font.Bold = true;
            pageHeader.Color = Syncfusion.Drawing.Color.FromArgb(0, 146, 208, 80);
            pageHeader.HorizontalAlignment = ExcelHAlign.HAlignCenter;
            pageHeader.VerticalAlignment = ExcelVAlign.VAlignCenter;

            tableHeader.Font.Bold = true;
            tableHeader.Font.FontName = "Calibri";
            tableHeader.Color = Syncfusion.Drawing.Color.FromArgb(0, 146, 208, 80);

            #endregion

            #region Apply Styles
            // Apply style for header
            sheet["A1:C2"].Merge();
            sheet["A1"].Text = "Automobile Brands in the US";
            sheet["A1"].CellStyle = pageHeader;

            sheet["A4:C4"].CellStyle = tableHeader;

            sheet["A1:C1"].CellStyle.Font.Bold = true;
            sheet.UsedRange.AutofitColumns();

            #endregion

            #endregion

            #region Saving workbook and disposing objects
            workbook.Version = ExcelVersion.Excel2013;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();


            if (stream != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save("CLRObjects.xlsx", "application/msexcel", stream, m_context);
            }
            #endregion
        }        
    }
	
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
