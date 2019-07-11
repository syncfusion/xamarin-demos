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
namespace SampleBrowser
{
	public partial class  FiltersPage : SamplePage
	{
		private Context m_context;
		private Spinner spinner;
        private LinearLayout advancedLinear1;
        private LinearLayout advancedLinear2;
        private LinearLayout advancedLinear3;
        private LinearLayout advancedLinear4;
        private LinearLayout advancedLinear5;
        private LinearLayout advancedLinear6;
        private LinearLayout linear;
        private Spinner spinner1;
        private Spinner spinner2;
        private Spinner spinner3;
        private Spinner spinner4;
        private Spinner spinner5;
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


			TextView text2 = new TextView(con);
			text2.TextSize = 17;
			text2.TextAlignment = TextAlignment.Center;
			text2.Text = "This sample demonstrates how to filter data within a range of Excel worksheet.";
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
			space2.Text = "Filter Type";           
            space2.SetTextColor(Color.ParseColor("#262626"));
            space2.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            subLinear.AddView (space2);

			string[] list = { "Custom Filter", "Text Filter", "DateTime Filter", "Dynamic Filter", "Color Filter", "Icon Filter", "Advanced Filter" };
            ArrayAdapter<String> array = new ArrayAdapter<String>(con,Android.Resource.Layout.SimpleSpinnerItem , list);
			spinner = new Spinner (con);
			spinner.Adapter = array;
			spinner.SetSelection (1);           
            subLinear.AddView (spinner);
            linear.AddView(subLinear);

            advancedLinear1 = new LinearLayout(con);
            advancedLinear1.Orientation = Orientation.Horizontal;

            TextView space3 = new TextView(con);
            space3.TextSize = 17;
            space3.TextAlignment = TextAlignment.Center;
            space3.Text = "Filter Action";
            space3.SetTextColor(Color.ParseColor("#262626"));
            space3.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            advancedLinear1.AddView(space3);

            string[] list1 = new string[] { "Filter In Place", "Filter Copy" };
            ArrayAdapter array1 = new ArrayAdapter(con, Android.Resource.Layout.SimpleSpinnerItem, list1);
            spinner1 = new Spinner(con);
            spinner1.Adapter = array1;
            spinner1.SetSelection(1);
            advancedLinear1.AddView(spinner1);            

            advancedLinear2 = new LinearLayout(con);
            advancedLinear2.Orientation = Orientation.Horizontal;

            TextView space4 = new TextView(con);
            space4.TextSize = 17;
            space4.TextAlignment = TextAlignment.Center;
            space4.Text = "Unique Records";
            space4.SetTextColor(Color.ParseColor("#262626"));
            space4.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            advancedLinear2.AddView(space4);

            linear.AddView(advancedLinear1);
            linear.AddView(advancedLinear2);

            switch1 = new Switch(con);
            switch1.Checked = false;
            advancedLinear2.AddView(switch1);

            advancedLinear3 = new LinearLayout(con);
            advancedLinear3.Orientation = Orientation.Horizontal;

            TextView space5 = new TextView(con);
            space5.TextSize = 17;
            space5.TextAlignment = TextAlignment.Center;
            space5.Text = "Color Filter Type";
            space5.SetTextColor(Color.ParseColor("#262626"));
            space5.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            advancedLinear3.AddView(space5);

            string[] list2 = new string[] { "Font Color", "Cell Color" };
            ArrayAdapter array2 = new ArrayAdapter(con, Android.Resource.Layout.SimpleSpinnerItem, list2);
            spinner2 = new Spinner(con);
            spinner2.Adapter = array2;
            spinner2.SetSelection(0);
            advancedLinear3.AddView(spinner2);

            advancedLinear4 = new LinearLayout(con);
            advancedLinear4.Orientation = Orientation.Horizontal;

            TextView space6 = new TextView(con);
            space6.TextSize = 17;
            space6.TextAlignment = TextAlignment.Center;
            space6.Text = "Color";
            space6.SetTextColor(Color.ParseColor("#262626"));
            space6.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            advancedLinear4.AddView(space6);


            string[] list3 = new string[] { "Red", "Blue", "Green", "Yellow", "Empty" };
            ArrayAdapter array3 = new ArrayAdapter(con, Android.Resource.Layout.SimpleSpinnerItem, list3);
            spinner3 = new Spinner(con);
            spinner3.Adapter = array3;
            spinner3.SetSelection(0);
            advancedLinear4.AddView(spinner3);

            advancedLinear5 = new LinearLayout(con);
            advancedLinear5.Orientation = Orientation.Horizontal;

            TextView space7 = new TextView(con);
            space7.TextSize = 17;
            space7.TextAlignment = TextAlignment.Center;
            space7.Text = "IconSet Type";
            space7.SetTextColor(Color.ParseColor("#262626"));
            space7.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            advancedLinear5.AddView(space7);


            string[] list4 = new string[] { "ThreeSymbols", "FourRating", "FiveArrows"};
            ArrayAdapter array4 = new ArrayAdapter(con, Android.Resource.Layout.SimpleSpinnerItem, list4);
            spinner4 = new Spinner(con);
            spinner4.Adapter = array4;
            spinner4.SetSelection(0);
            advancedLinear5.AddView(spinner4);

            advancedLinear6 = new LinearLayout(con);
            advancedLinear6.Orientation = Orientation.Horizontal;

            TextView space8 = new TextView(con);
            space8.TextSize = 17;
            space8.TextAlignment = TextAlignment.Center;
            space8.Text = "Icon ID";
            space8.SetTextColor(Color.ParseColor("#262626"));
            space8.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            advancedLinear6.AddView(space8);


            string[] list5 = new string[] { "RedCrossSymbol", "YellowExclamationSymbol", "GreenCheckSymbol", "NoIcon" };
            ArrayAdapter array5 = new ArrayAdapter(con, Android.Resource.Layout.SimpleSpinnerItem, list5);
            spinner5 = new Spinner(con);
            spinner5.Adapter = array5;
            spinner5.SetSelection(0);
            advancedLinear6.AddView(spinner5);

            string[] iconsList2 = new string[] { "SignalWithOneFillBar", "SignalWithTwoFillBars", "SignalWithThreeFillBars", "SignalWithFourFillBars", "NoIcon" };
            string[] iconsList3 = new string[] { "RedDownArrow", "YellowDownInclineArrow", "YellowSideArrow", "YellowUpInclineArrow", "GreenUpArrow", "NoIcon" };

            Button button = new Button(con);
            button.Text = "Input Template";
            button.Click += OnButtonClicked1;
            linear.AddView(button);

            button1 = new Button (con);
			button1.Text = "Generate Excel";
			button1.Click += OnButtonClicked;
			linear.AddView (button1);            
            spinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                String selectedItem = array.GetItem(e.Position);
                if (selectedItem.Equals("Advanced Filter"))
                {
                    linear.RemoveView(button1);
                    linear.RemoveView(button);
                    linear.AddView(advancedLinear1);
                    linear.AddView(advancedLinear2);
                    linear.AddView(button);
                    linear.AddView(button1);
                    linear.RemoveView(advancedLinear3);
                    linear.RemoveView(advancedLinear4);
                    linear.RemoveView(advancedLinear5);
                    linear.RemoveView(advancedLinear6);
                }
                else if(selectedItem.Equals("Icon Filter"))
                {
                    linear.RemoveView(button);
                    linear.RemoveView(button1);
                    linear.RemoveView(advancedLinear1);
                    linear.RemoveView(advancedLinear2);
                    linear.RemoveView(advancedLinear3);
                    linear.RemoveView(advancedLinear4);
                    linear.AddView(advancedLinear5);
                    linear.AddView(advancedLinear6);
                    linear.AddView(button);
                    linear.AddView(button1);
                }
                else if(selectedItem.Equals("Color Filter"))
                {
                    linear.RemoveView(button);
                    linear.RemoveView(button1);
                    linear.RemoveView(advancedLinear1);
                    linear.RemoveView(advancedLinear2);
                    linear.RemoveView(advancedLinear5);
                    linear.RemoveView(advancedLinear6);
                    linear.AddView(advancedLinear3);
                    linear.AddView(advancedLinear4);
                    linear.AddView(button);
                    linear.AddView(button1);
                }
                else
                {
                    linear.RemoveView(advancedLinear1);
                    linear.RemoveView(advancedLinear2);
                    linear.RemoveView(advancedLinear3);
                    linear.RemoveView(advancedLinear4);
                    linear.RemoveView(advancedLinear5);
                    linear.RemoveView(advancedLinear6);
                }
            };

            spinner4.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                if (spinner4.SelectedItemPosition == 0)
                    spinner5.Adapter = new ArrayAdapter(con, Android.Resource.Layout.SimpleSpinnerItem, list5);
                else if (spinner4.SelectedItemPosition == 1)
                    spinner5.Adapter = new ArrayAdapter(con, Android.Resource.Layout.SimpleSpinnerItem, iconsList2);
                else if (spinner4.SelectedItemPosition == 2)
                    spinner5.Adapter = new ArrayAdapter(con, Android.Resource.Layout.SimpleSpinnerItem, iconsList3);
            };
            return linear;
		}
		void OnButtonClicked(object sender, EventArgs e)
		{
			ExcelEngine excelEngine = new ExcelEngine();
			IApplication application = excelEngine.Excel;

			application.DefaultVersion = ExcelVersion.Excel2013;
            int index = spinner.SelectedItemPosition;
            #region Initializing Workbook
            string resourcePath = "";
            if (index == 6)
                resourcePath = "SampleBrowser.Samples.XlsIO.Template.AdvancedFilterData.xlsx";
            else if (index == 5)
                resourcePath = "SampleBrowser.Samples.XlsIO.Template.IconFilterData.xlsx";
            else if (index == 4)
                resourcePath = "SampleBrowser.Samples.XlsIO.Template.FilterData_Color.xlsx";
            else
                resourcePath = "SampleBrowser.Samples.XlsIO.Template.FilterData.xlsx";
            Assembly assembly = Assembly.GetExecutingAssembly ();
			Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

			IWorkbook workbook = application.Workbooks.Open(fileStream);

			//The first worksheet object in the worksheets collection is accessed.
			IWorksheet sheet = workbook.Worksheets[0];
            sheet["A60"].Activate();
            #endregion
            if (index!=6)
                sheet.AutoFilters.FilterRange = sheet.Range[1, 1, 49, 3];
			string fileName = "";

			

			switch(index)
			{
			case 0:
				fileName = "CustomFilter.xlsx";
				IAutoFilter filter1 = sheet.AutoFilters[0];
				filter1.IsAnd = false;
				filter1.FirstCondition.ConditionOperator = ExcelFilterCondition.Equal;
				filter1.FirstCondition.DataType = ExcelFilterDataType.String;
				filter1.FirstCondition.String = "Owner";

				filter1.SecondCondition.ConditionOperator = ExcelFilterCondition.Equal;
				filter1.SecondCondition.DataType = ExcelFilterDataType.String;
				filter1.SecondCondition.String = "Sales Representative";            
				break;

			case 1:
				fileName = "TextFilter.xlsx";
				IAutoFilter filter2 = sheet.AutoFilters[0];
				filter2.AddTextFilter(new string[] { "Owner", "Sales Representative", "Sales Associate" });
				break;

			case 2:
				fileName = "DateTimeFilter.xlsx";
				IAutoFilter filter3 = sheet.AutoFilters[1];
				filter3.AddDateFilter(new DateTime(2004, 9, 1, 1, 0, 0, 0), DateTimeGroupingType.month);
				filter3.AddDateFilter(new DateTime(2011, 1, 1, 1, 0, 0, 0), DateTimeGroupingType.year);
				break;

			case 3:
				fileName = "DynamicFilter.xlsx";
				IAutoFilter filter4 = sheet.AutoFilters[1];
				filter4.AddDynamicFilter(DynamicFilterType.Quarter1);
				break;

            case 4:
                    fileName = "Color Filter.xlsx";
                    #region ColorFilter
                    sheet.AutoFilters.FilterRange = sheet["A1:C49"];
                    Syncfusion.Drawing.Color color = Syncfusion.Drawing.Color.Empty;

                    switch (spinner3.SelectedItemPosition)
                    {
                        case 0:
                            color = Syncfusion.Drawing.Color.Red;
                            break;
                        case 1:
                            color = Syncfusion.Drawing.Color.Blue;
                            break;
                        case 2:
                            color = Syncfusion.Drawing.Color.Green;
                            break;
                        case 3:
                            color = Syncfusion.Drawing.Color.Yellow;
                            break;
                        case 4:
                            color = Syncfusion.Drawing.Color.Empty;
                            break;

                    }
                    if(spinner2.SelectedItemPosition == 0)
                    {
                        IAutoFilter filter = sheet.AutoFilters[2];
                        filter.AddColorFilter(color, ExcelColorFilterType.FontColor);
                    }
                    else
                    {
                        IAutoFilter filter = sheet.AutoFilters[0];
                        filter.AddColorFilter(color, ExcelColorFilterType.CellColor);
                    }

                    #endregion
                    break;

            case 5:
                    fileName = "IconFilter.xlsx";
                    #region IconFilter
                    sheet.AutoFilters.FilterRange = sheet["A4:D44"];
                    ExcelIconSetType iconSet = ExcelIconSetType.FiveArrows;
                    int filterIndex = 0;
                    int iconId = 0;
                    switch(spinner4.SelectedItemPosition)
                    {
                        case 0:
                            filterIndex = 3;
                            iconSet = ExcelIconSetType.ThreeSymbols;
                            break;
                        case 1:
                            filterIndex = 1;
                            iconSet = ExcelIconSetType.FourRating;
                            break;
                        case 2:
                            filterIndex = 2;
                            iconSet = ExcelIconSetType.FiveArrows;
                            break;
                    }
                    switch (spinner5.SelectedItemPosition)
                    {
                        case 0:
                            iconId = 0;
                            break;
                        case 1:
                            iconId = 1;
                            break;
                        case 2:
                            iconId = 2;
                            break;
                        case 3:
                            if (spinner4.SelectedItemPosition == 0)
                                iconSet = (ExcelIconSetType)(-1);
                            else
                                iconId = 3;
                            break;
                        case 4:
                            if (spinner4.SelectedItemPosition == 1)
                                iconSet = (ExcelIconSetType)(-1);
                            else
                                iconId = 4;
                            break;
                        case 5:
                            iconSet = (ExcelIconSetType)(-1);
                            break;
                    }
                    IAutoFilter filter5 = sheet.AutoFilters[filterIndex];
                    filter5.AddIconFilter(iconSet, iconId);

                    #endregion
                    break;
            case 6:
                    #region AdvancedFilter
                    fileName = "AdvancedFilter.xlsx";
                    IRange filterRange = sheet.Range["A8:G51"];
                    IRange criteriaRange = sheet.Range["A2:B5"];
                    if (spinner1.SelectedItemPosition == 0)
                    {
                        sheet.AdvancedFilter(ExcelFilterAction.FilterInPlace, filterRange, criteriaRange, null, switch1.Checked);
                    }
                    else
                    {
                        IRange range = sheet.Range["I7:O7"];
                        range.Merge();
                        range.Text = "FilterCopy";
                        range.CellStyle.Font.RGBColor = Syncfusion.Drawing.Color.FromArgb(0, 112, 192);
                        range.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                        range.CellStyle.Font.Bold = true;
                        IRange copyRange = sheet.Range["I8"];
                        sheet.AdvancedFilter(ExcelFilterAction.FilterCopy, filterRange, criteriaRange, copyRange, switch1.Checked);
                    }
                    #endregion
                    break;
            }

			workbook.Version = ExcelVersion.Excel2013;

			MemoryStream stream = new MemoryStream();
			workbook.SaveAs(stream);
			workbook.Close();
			excelEngine.Dispose();

			if (stream != null)
			{
				SaveAndroid androidSave = new SaveAndroid ();
				androidSave.Save (fileName, "application/msexcel", stream, m_context);
			}


		}

        void OnButtonClicked1(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;

            application.DefaultVersion = ExcelVersion.Excel2013;
            int index = spinner.SelectedItemPosition;

            string resourcePath = "";
            if (index == 6)
                resourcePath = "SampleBrowser.Samples.XlsIO.Template.AdvancedFilterData.xlsx";
            else if (index == 5)
                resourcePath = "SampleBrowser.Samples.XlsIO.Template.IconFilterData.xlsx";
            else if (index == 4)
                resourcePath = "SampleBrowser.Samples.XlsIO.Template.FilterData_Color.xlsx";
            else
                resourcePath = "SampleBrowser.Samples.XlsIO.Template.FilterData.xlsx";
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

        private int getDimensionPixelSize(Context con, int id)
        {
            return con.Resources.GetDimensionPixelSize(id);
        }
    }
}

