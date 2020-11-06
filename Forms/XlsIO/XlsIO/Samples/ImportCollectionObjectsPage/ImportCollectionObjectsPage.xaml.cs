#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using COLOR = Syncfusion.Drawing;
using SampleBrowser.Core;
using Syncfusion.SfDataGrid;
using Syncfusion.SfDataGrid.XForms;
using Syncfusion.XlsIO;
using Xamarin.Forms;

namespace SampleBrowser.XlsIO
{
    /// <summary>
    /// This class allows you to import/export data from/to Collection Objects.
    /// </summary>
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public partial class ImportCollectionObjectsPage : SampleView
    {
        private ExportingViewModel exportViewModel;

        public ImportCollectionObjectsPage(ExportingViewModel viewModel)
        {
            exportViewModel = viewModel;
        }

        public ImportCollectionObjectsPage()
        {
            InitializeComponent();
            if (Device.Idiom != TargetIdiom.Phone && (Device.RuntimePlatform == Device.UWP))
            {
                this.Content_1.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.BackgroundColor = Color.Gray;
                this.btnInput.BackgroundColor = Color.Gray;
                this.btnImport.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {             
                {
                    this.Content_1.FontSize = 13.5;
                }

                this.Content_1.VerticalOptions = LayoutOptions.Center;
            }

            if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.iOS)
            {
                this.dataGrid.DefaultColumnWidth = 120;
            }
            else
            {
                this.dataGrid.DefaultColumnWidth = 160;
            }
        }

        internal void OnInputClicked(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            // Initializing Workbook
            Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            Stream fileStream = null;
           
			#if COMMONSB
			 fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.ExportData.xlsx");
			#else
            fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.ExportData.xlsx");
			#endif
            IWorkbook workbook = application.Workbooks.Open(fileStream);

            workbook.Version = ExcelVersion.Excel2013;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();

            if (Device.RuntimePlatform == Device.UWP)
            {
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("InputTemplate.xlsx", "application/msexcel", stream);
            }
            else
            {
                Xamarin.Forms.DependencyService.Get<ISave>().Save("InputTemplate.xlsx", "application/msexcel", stream);
            }
        }

        internal void OnImportClicked(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            // Initializing Workbook
            Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            Stream fileStream = null;
            
			#if COMMONSB
			 fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.ExportData.xlsx");
			#else
            fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.ExportData.xlsx");
			#endif
            IWorkbook workbook = application.Workbooks.Open(fileStream);

            workbook.Version = ExcelVersion.Excel2013;
            IWorksheet sheet = workbook.Worksheets[0];
            Dictionary<string, string> mappingProperties = new Dictionary<string, string>();
            mappingProperties.Add("Brand", "BrandName");
            mappingProperties.Add("Vehicle Type", "VehicleType.VehicleName");
            mappingProperties.Add("Model", "VehicleType.Model.ModelName");
            List<Brand> clrObjects = sheet.ExportData<Brand>(4, 1, 141, 3, mappingProperties);
            dataGrid.ItemsSource = clrObjects;
            this.btnGenerate.IsEnabled = true;
            workbook.Close();
            excelEngine.Dispose();
        }

        internal void OnExportClicked(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            //Initializing Workbook
            //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
            //The new workbook will have 1 worksheets
            IWorkbook workbook = application.Workbooks.Create(1);

            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            sheet.ImportData((List<Brand>)dataGrid.ItemsSource, 4, 1, true);

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

            // Saving workbook and disposing objects
            workbook.Version = ExcelVersion.Excel2013;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();

            if (Device.RuntimePlatform == Device.UWP)
            {
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("CollectionObjects.xlsx", "application/msexcel", stream);
            }
            else
            {
                Xamarin.Forms.DependencyService.Get<ISave>().Save("CollectionObjects.xlsx", "application/msexcel", stream);
            }
        }

    }


    /// <summary>
    /// Provides the implementation for ExportToDataGrid View Model
    /// </summary>
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class ExportingViewModel : INotifyPropertyChanged
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

        public ExportingViewModel()
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
            get
            {
                return customersInfo;
            }

            set
            {
                this.customersInfo = value;
                RaisePropertyChanged("CustomersInfo");
            }
        }
        #endregion

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }

    /// <summary>
    /// Class used to store the customer details
    /// </summary>
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class CustomerObject : INotifyPropertyChanged
    {
        public CustomerObject()
        {
        }

        #region private variables

        private string salesPerson;
        private int salesJanJune;
        private int salesJulyDec;
        private int change;

        #endregion

        #region Public Properties

        public string SalesPerson
        {
            get
            {
                return salesPerson;
            }

            set
            {
                this.salesPerson = value;
                RaisePropertyChanged("SalesPerson");
            }
        }

        public int SalesJanJune
        {
            get
            {
                return salesJanJune;
            }

            set
            {
                this.salesJanJune = value;
                RaisePropertyChanged("SalesJanJune");
            }
        }

        public int SalesJulyDec
        {
            get
            {
                return salesJulyDec;
            }

            set
            {
                this.salesJulyDec = value;
                RaisePropertyChanged("SalesJulyDec");
            }
        }

        public int Change
        {
            get
            {
                return change;
            }

            set
            {
                this.change = value;
                RaisePropertyChanged("Change");
            }
        }
        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
    public class Brand
    {
        private int m_Id;
        [Bindable(false)]
        public int ID
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        private string m_brandName;
        [DisplayNameAttribute("Brand")]
        public string BrandName
        {
            get { return m_brandName; }
            set { m_brandName = value; }
        }

        private VehicleType m_vehicleType;
        public VehicleType VehicleType
        {
            get { return m_vehicleType; }
            set { m_vehicleType = value; }
        }

        public Brand(string brandName)
        {
            m_brandName = brandName;
        }
        public Brand()
        {

        }
    }

    public class VehicleType
    {
        private string m_vehicleName;
        [DisplayNameAttribute("Vehicle Type")]
        public string VehicleName
        {
            get { return m_vehicleName; }
            set { m_vehicleName = value; }
        }

        private Model m_model;
        public Model Model
        {
            get { return m_model; }
            set { m_model = value; }
        }

        public VehicleType(string vehicle)
        {
            m_vehicleName = vehicle;
        }
        public VehicleType()
        {

        }
    }

    public class Model
    {
        private string m_modelName;
        [DisplayNameAttribute("Model")]
        public string ModelName
        {
            get { return m_modelName; }
            set { m_modelName = value; }
        }

        public Model(string name)
        {
            m_modelName = name;
        }
        public Model()
        {

        }
    }
}