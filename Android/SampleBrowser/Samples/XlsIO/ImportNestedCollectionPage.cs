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
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SampleBrowser
{
	public partial class  ImportNestedCollectionPage : SamplePage
	{
		private Context m_context;
		private Spinner spinner;
        private LinearLayout advancedLinear1;
        private LinearLayout advancedLinear2;
        RadioGroup radioGroup;
        RadioButton expandButton;
        RadioButton collapseButton;
        EditText editText;
        private LinearLayout linear;
        private Switch switch1;
        private Button button1;
        public override View GetSampleContent (Context con)
		{
            int numerHeight = getDimensionPixelSize(con, Resource.Dimension.numeric_txt_ht);
            int width = con.Resources.DisplayMetrics.WidthPixels - 40;
            linear = new LinearLayout(con);
			linear.SetBackgroundColor(Color.White);
			linear.Orientation = Orientation.Vertical;
			linear.SetPadding(10, 10, 10, 10);
            linear.DividerPadding = 0;

			TextView text2 = new TextView(con);
			text2.TextSize = 17;
			text2.TextAlignment = TextAlignment.Center;
			text2.Text = "This sample demonstrates how to import data from nested collection with layout and group options.";
			text2.SetTextColor(Color.ParseColor("#262626"));
			text2.SetPadding(5, 5, 5, 5);
			linear.AddView(text2);

			TextView space1 = new TextView (con);
			space1.TextSize = 10;
			linear.AddView (space1);

			m_context = con;

            LinearLayout subLinear = new LinearLayout(con);
            subLinear.Orientation = Orientation.Horizontal;

            TextView space2 = new TextView (con);
			space2.TextSize = 17;
			space2.TextAlignment = TextAlignment.Center;
			space2.Text = "Layout Options";           
            space2.SetTextColor(Color.ParseColor("#262626"));
            space2.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            subLinear.AddView (space2);

			string[] list = { "Default", "Merge", "Repeat" };
            ArrayAdapter<String> array = new ArrayAdapter<String>(con,Android.Resource.Layout.SimpleSpinnerItem , list);
			spinner = new Spinner (con);
			spinner.Adapter = array;
			spinner.SetSelection (0);           
            subLinear.AddView (spinner);
            linear.AddView(subLinear);

            advancedLinear1 = new LinearLayout(con);
            advancedLinear1.Orientation = Orientation.Horizontal;
          
            TextView space4 = new TextView(con);
            space4.TextSize = 17;
            space4.TextAlignment = TextAlignment.Center;
            space4.Text = "Apply Group";
            space4.SetTextColor(Color.ParseColor("#262626"));
            space4.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            advancedLinear1.AddView(space4);

            switch1 = new Switch(con);
            switch1.Checked = false;
            advancedLinear1.AddView(switch1);
            linear.AddView(advancedLinear1);

            LinearLayout advancedLinear3 = new LinearLayout(con);
            advancedLinear3.Orientation = Orientation.Horizontal;            
            TextView space6 = new TextView(con);
            space6.TextSize = 17;
            space6.TextAlignment = TextAlignment.Center;
            space6.Text = "";
            space6.SetTextColor(Color.ParseColor("#262626"));
            space6.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            advancedLinear3.AddView(space6);

            advancedLinear2 = new LinearLayout(con);
            advancedLinear2.Orientation = Orientation.Vertical;

            TextView space5 = new TextView(con);
            space5.TextSize = 17;
            space5.TextAlignment = TextAlignment.Center;
            space5.Text = "Options";
            space5.SetTextColor(Color.ParseColor("#262626"));
            space5.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight - 90);
            advancedLinear2.AddView(space5);

            radioGroup = new RadioGroup(con);
            radioGroup.TextAlignment = TextAlignment.Center;
            radioGroup.Orientation = Orientation.Vertical;
            expandButton = new RadioButton(con);
            expandButton.Text = "Expand";
            radioGroup.AddView(expandButton);
            collapseButton = new RadioButton(con);
            collapseButton.Text = "Collapse at Level";
            radioGroup.AddView(collapseButton);
            advancedLinear2.AddView(radioGroup);

            editText = new EditText(con);
            editText.TextSize = 17;
            editText.TextAlignment = TextAlignment.Center;
            editText.Text = "1";
            editText.SetTextColor(Color.ParseColor("#262626"));

            advancedLinear3.AddView(advancedLinear2);

            button1 = new Button (con);
			button1.Text = "Generate Excel";
			button1.Click += OnButtonClicked;
			linear.AddView(button1);
            expandButton.Checked = true;

            switch1.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) =>
            {
                if (switch1.Checked)
                {
                    linear.RemoveView(button1);
                    linear.AddView(advancedLinear3);
                    linear.AddView(button1);
                }
                else
                {
                    linear.RemoveView(advancedLinear3);
                }
            };
            collapseButton.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) =>
            {
                if (collapseButton.Checked)
                {
                    linear.RemoveView(button1);
                    linear.RemoveView(advancedLinear3);
                    advancedLinear3.RemoveView(advancedLinear2);
                    advancedLinear2.AddView(editText);
                    advancedLinear3.AddView(advancedLinear2);
                    linear.AddView(advancedLinear3);
                    linear.AddView(button1);
                }
                else
                {
                    linear.RemoveView(button1);
                    linear.RemoveView(advancedLinear3);
                    advancedLinear3.RemoveView(advancedLinear2);
                    advancedLinear2.RemoveView(editText);
                    advancedLinear3.AddView(advancedLinear2);
                    linear.AddView(advancedLinear3);
                    linear.AddView(button1);
                }
            };
            return linear;
		}

        void OnButtonClicked(object sender, EventArgs e)
		{
			ExcelEngine excelEngine = new ExcelEngine();
			IApplication application = excelEngine.Excel;
			application.DefaultVersion = ExcelVersion.Excel2013;
            IWorkbook workbook = excelEngine.Excel.Workbooks.Create(1);
            IWorksheet worksheet = workbook.Worksheets[0];

            IList<Brands> list = GetVehicleDetails();

            ExcelImportDataOptions importDataOptions = new ExcelImportDataOptions();
            importDataOptions.FirstRow = 4;

            if (spinner.SelectedItemPosition == 0)
                importDataOptions.NestedDataLayoutOptions = ExcelNestedDataLayoutOptions.Default;
            else if (spinner.SelectedItemPosition == 1)
                importDataOptions.NestedDataLayoutOptions = ExcelNestedDataLayoutOptions.Merge;
            else if (spinner.SelectedItemPosition == 2)
                importDataOptions.NestedDataLayoutOptions = ExcelNestedDataLayoutOptions.Repeat;

            if (switch1.Checked)
            {
                if (expandButton.Checked)
                {
                    importDataOptions.NestedDataGroupOptions = ExcelNestedDataGroupOptions.Expand;
                }
                else if (collapseButton.Checked)
                {
                    importDataOptions.NestedDataGroupOptions = ExcelNestedDataGroupOptions.Collapse;
                    if (editText.Text != string.Empty)
                    {
                        importDataOptions.CollapseLevel = int.Parse(editText.Text);
                    }
                }
            }

            worksheet.ImportData(list, importDataOptions);

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
            worksheet["A1:C2"].Merge();
            worksheet["A1"].Text = "Automobile Brands in the US";
            worksheet["A1"].CellStyle = pageHeader;

            worksheet["A4:C4"].CellStyle = tableHeader;

            worksheet["A1:C1"].CellStyle.Font.Bold = true;
            worksheet.UsedRange.AutofitColumns();

            #endregion

            MemoryStream stream = new MemoryStream();
			workbook.SaveAs(stream);
			workbook.Close();
			excelEngine.Dispose();

			if (stream != null)
			{
				SaveAndroid androidSave = new SaveAndroid ();
				androidSave.Save ("ImportData.xlsx", "application/msexcel", stream, m_context);
			}
		}

        private int getDimensionPixelSize(Context con, int id)
        {
            return con.Resources.GetDimensionPixelSize(id);
        }

        #region Helper Methods
        private IList<Brands> GetVehicleDetails()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(BrandObjects));
            string resourcePath = "SampleBrowser.Samples.XlsIO.Template.ExportData.xml";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);
            TextReader textReader = new StreamReader(fileStream);
            BrandObjects brands = (BrandObjects)deserializer.Deserialize(textReader);

            List<Brands> list = new List<Brands>();
            string brandName = brands.BrandObject[0].BrandName;
            string vehicleType = brands.BrandObject[0].VahicleType;
            string modelName = brands.BrandObject[0].ModelName;
            Brands brand = new Brands(brandName);
            brand.VehicleTypes = new List<VehicleTypes>();

            VehicleTypes vehicle = new VehicleTypes(vehicleType);
            vehicle.Models = new List<ModelObject>();
            ModelObject model = new ModelObject(modelName);

            brand.VehicleTypes.Add(vehicle);
            list.Add(brand);

            foreach (BrandObject brandObj in brands.BrandObject)
            {
                if (brandName == brandObj.BrandName)
                {
                    if (vehicleType == brandObj.VahicleType)
                    {
                        vehicle.Models.Add(new ModelObject(brandObj.ModelName));
                        continue;
                    }
                    else
                    {
                        vehicle = new VehicleTypes(brandObj.VahicleType);
                        vehicle.Models = new List<ModelObject>();
                        vehicle.Models.Add(new ModelObject(brandObj.ModelName));
                        brand.VehicleTypes.Add(vehicle);
                        vehicleType = brandObj.VahicleType;
                    }
                    continue;
                }
                else
                {
                    brand = new Brands(brandObj.BrandName);
                    vehicle = new VehicleTypes(brandObj.VahicleType);
                    vehicle.Models = new List<ModelObject>();
                    vehicle.Models.Add(new ModelObject(brandObj.ModelName));
                    brand.VehicleTypes = new List<VehicleTypes>();
                    brand.VehicleTypes.Add(vehicle);
                    vehicleType = brandObj.VahicleType;
                    list.Add(brand);
                    brandName = brandObj.BrandName;
                }
            }
            textReader.Close();
            return list;
        }
        #endregion
    }

    #region Helper Class
    [XmlRootAttribute("BrandObjects")]
    public class BrandObjects
    {
        [XmlElement("BrandObject")]
        public BrandObject[] BrandObject { get; set; }
    }
    public class BrandObject
    {
        public string BrandName { get; set; }
        public string VahicleType { get; set; }
        public string ModelName { get; set; }
    }
    //[Serializable]
    public class Brands
    {
        private string m_brandName;
        [DisplayNameAttribute("Brand")]
        public string BrandName
        {
            get { return m_brandName; }
            set { m_brandName = value; }
        }

        private IList<VehicleTypes> m_vehicles;
        public IList<VehicleTypes> VehicleTypes
        {
            get { return m_vehicles; }
            set { m_vehicles = value; }
        }

        public Brands(string brandName)
        {
            m_brandName = brandName;
        }
    }

    public class VehicleTypes
    {
        private string m_vehicle;
        [DisplayNameAttribute("Vehicle Type")]
        public string Vehicle
        {
            get { return m_vehicle; }
            set { m_vehicle = value; }
        }

        private IList<ModelObject> m_models;
        public IList<ModelObject> Models
        {
            get { return m_models; }
            set { m_models = value; }
        }

        public VehicleTypes(string vehicle)
        {
            m_vehicle = vehicle;
        }
    }

    #endregion
}

