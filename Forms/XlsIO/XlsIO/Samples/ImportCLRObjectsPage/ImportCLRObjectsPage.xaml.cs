#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XlsIO;
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using COLOR = Syncfusion.Drawing;
using Xamarin.Forms;
using System.Xml.Linq;
using Syncfusion.SfDataGrid.XForms;
using Syncfusion.SfDataGrid;
using System.Globalization;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace SampleBrowser.XlsIO
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public partial class ImportCLRObjectsPage : SampleView
    {
        ExportingViewModel exportViewModel;

        public ImportCLRObjectsPage(ExportingViewModel viewModel)
        {
            exportViewModel = viewModel;
        }

        public ImportCLRObjectsPage()
        {
            InitializeComponent();
            if (Device.Idiom != TargetIdiom.Phone && (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WinRT))
            {
                this.Content_1.HorizontalOptions = LayoutOptions.Start;
                //dataGrid.ColumnSizer = ColumnSizer.Star;
                this.btnGenerate.BackgroundColor = Color.Gray;
                this.btnInput.BackgroundColor = Color.Gray;
                this.btnImport.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.WinPhone)
            {
                
                {
                    this.Content_1.FontSize = 13.5;
                }
                this.Content_1.VerticalOptions = LayoutOptions.Center;
            }
            if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.iOS)
            {
                this.dataGrid.DefaultColumnWidth = 120;
                //this.dataGrid.ColumnSizer = ColumnSizer.Auto;
                //this.dataGrid.AllowResizingColumn = true;
            }
            else
                this.dataGrid.DefaultColumnWidth = 160;
        }
        void OnInputClicked(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            #region Initializing Workbook
            Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            Stream fileStream = null;
           
			#if COMMONSB
			 fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.ExportSales.xlsx");
			#else
            fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.ExportSales.xlsx");
			#endif
            IWorkbook workbook = application.Workbooks.Open(fileStream);
            #endregion
            workbook.Version = ExcelVersion.Excel2013;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();

            if (Device.RuntimePlatform == Device.WinPhone || Device.RuntimePlatform == Device.WinRT || Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("InputTemplate.xlsx", "application/msexcel", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("InputTemplate.xlsx", "application/msexcel", stream);
        }
        void OnImportClicked(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            #region Initializing Workbook
            Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            Stream fileStream = null;
            
			#if COMMONSB
			 fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.ExportSales.xlsx");
			#else
            fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.ExportSales.xlsx");
			#endif
            IWorkbook workbook = application.Workbooks.Open(fileStream);
            #endregion
            workbook.Version = ExcelVersion.Excel2013;
            IWorksheet sheet = workbook.Worksheets[0];
            List<CustomerObject> CLRObjects = sheet.ExportData<CustomerObject>(1, 1, 41, 4);
            dataGrid.ItemsSource = CLRObjects;
            this.btnGenerate.IsEnabled = true;
            workbook.Close();
            excelEngine.Dispose();
        }
        void OnExportClicked(object sender, EventArgs e)
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

            Assembly assembly = typeof(App).GetTypeInfo().Assembly;
			
			Stream fileStream=null;
			#if COMMONSB
			fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.CLRObjects.xml");
			#else
            fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.CLRObjects.xml");
			#endif

            // Import the Custom Object to worksheet
            StreamReader reader = new StreamReader(fileStream);
            //IEnumerable<CLRObject> customers = GetData<CLRObject>(reader.ReadToEnd());

            sheet.ImportData((List<CustomerObject>)dataGrid.ItemsSource, 5, 1, false);

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
            #endregion

            #region Saving workbook and disposing objects
            workbook.Version = ExcelVersion.Excel2013;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();

            if (Device.RuntimePlatform == Device.WinPhone || Device.RuntimePlatform == Device.WinRT || Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("CLRObjects.xlsx", "application/msexcel", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("CLRObjects.xlsx", "application/msexcel", stream);
            #endregion
        }
        static IEnumerable<T> GetData<T>(string xml)
        where T : BusinessObject, new()
        {
            return XElement.Parse(xml)
               .Elements("Customers")
               .Select(c => new T
               {
                   SalesPerson = (string)c.Element("SalesPerson"),
                   SalesJanJune = (int)c.Element("SalesJanJune"),
                   SalesJulyDec = (int)c.Element("SalesJulyDec"),
                   Change = (int)c.Element("Change"),
               });
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
            CustomersInfo = new List<CustomerObject>();
            foreach(int i in Enumerable.Range(1,20))
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
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
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