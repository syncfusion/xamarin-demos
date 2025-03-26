#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Syncfusion.XlsIO;
using Xamarin.Forms;

namespace SampleBrowser.XlsIO
{
    /// <summary>
    /// This class is used to filter data within a range of Excel worksheet.
    /// </summary>
    public partial class FiltersPage : SampleView
    {
        public FiltersPage()
        {
            InitializeComponent();

            this.picker.Items.Add("Custom Filter");
            this.picker.Items.Add("Text Filter");
            this.picker.Items.Add("DateTime Filter");
            this.picker.Items.Add("Dynamic Filter");
            this.picker.Items.Add("Color Filter");
            this.picker.Items.Add("Icon Filter");
            this.picker.Items.Add("Advanced Filter");
            this.Advanced.Items.Add("Filter In Place");
            this.Advanced.Items.Add("Filter Copy");
            this.picker.SelectedIndex = 0;
            this.Advanced.SelectedIndex = 0;
            this.ColorFilterType.Items.Add("Font Color");
            this.ColorFilterType.Items.Add("Cell Color");
            this.ColorsList.Items.Add("Red");
            this.ColorsList.Items.Add("Blue");
            this.ColorsList.Items.Add("Green");
            this.ColorsList.Items.Add("Yellow");
            this.ColorsList.Items.Add("Empty");
            this.IconSetList.Items.Add("ThreeSymbols");
            this.IconSetList.Items.Add("FourRating");
            this.IconSetList.Items.Add("FiveArrows");
            this.IconIdList.Items.Add("1");
            this.IconIdList.Items.Add("2");
            this.IconIdList.Items.Add("3");
            this.IconIdList.Items.Add("NoIcon");
            this.IconIdList.SelectedIndex = 0;
            this.ColorsList.SelectedIndex = 0;
            this.ColorFilterType.SelectedIndex = 0;
            this.IconSetList.SelectedIndex = 0;

            
            if (Device.Idiom != TargetIdiom.Phone && (Device.RuntimePlatform == Device.UWP))
            {
                this.Content_1.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
                this.btnGetInputTemplate.HorizontalOptions = LayoutOptions.Start;

                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.BackgroundColor = Color.Gray;
                this.btnGetInputTemplate.VerticalOptions = LayoutOptions.Center;
                this.btnGetInputTemplate.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                {
                    this.Content_1.FontSize = 13.5;
                    this.Content_3.FontSize = 13.5;
                    this.Label1.FontSize = 13.5;
                    this.Label2.FontSize = 13.5;
                }

                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnGetInputTemplate.VerticalOptions = LayoutOptions.Center;
            }
        }

        internal void OnButtonClicked(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            // Initializing Workbook
            Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            Stream fileStream = null;
            int filterType = this.picker.SelectedIndex;
			#if COMMONSB
			 if (filterType == 6)
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.AdvancedFilterData.xlsx");
            else if (filterType == 5)
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.IconFilterData.xlsx");
            else if (filterType == 4)
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.FilterData_Color.xlsx");
            else
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.FilterData.xlsx");
			#else
			if (filterType == 6)
            {
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.AdvancedFilterData.xlsx");
            }
            else if (filterType == 5)
            {
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.IconFilterData.xlsx");
            }
            else if (filterType == 4)
            {
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.FilterData_Color.xlsx");
            }
            else
            {
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.FilterData.xlsx");
            }
			#endif
           
            IWorkbook workbook = application.Workbooks.Open(fileStream);

            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];     
            
            if (filterType != 6)
            {
                sheet.AutoFilters.FilterRange = sheet.Range[1, 1, 49, 3];
            }

            switch (filterType)
            {
                case 0:
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
                    IAutoFilter filter2 = sheet.AutoFilters[0];
                    filter2.AddTextFilter(new string[] { "Owner", "Sales Representative", "Sales Associate" });
                    break;

                case 2:
                    IAutoFilter filter3 = sheet.AutoFilters[1];
                    filter3.AddDateFilter(new DateTime(2004, 9, 1, 1, 0, 0, 0), DateTimeGroupingType.month);
                    filter3.AddDateFilter(new DateTime(2011, 1, 1, 1, 0, 0, 0), DateTimeGroupingType.year);
                    break;

                case 3:
                    IAutoFilter filter4 = sheet.AutoFilters[1];
                    filter4.AddDynamicFilter(DynamicFilterType.Quarter1);
                    break;

                case 4:
                    // ColorFilter
                    sheet.AutoFilters.FilterRange = sheet["A1:C49"];
                    Syncfusion.Drawing.Color color = Syncfusion.Drawing.Color.Empty;
                    switch (ColorsList.SelectedIndex)
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

                    if (ColorFilterType.SelectedIndex == 0)
                    {
                        IAutoFilter filter = sheet.AutoFilters[2];
                        filter.AddColorFilter(color, ExcelColorFilterType.FontColor);
                    }
                    else
                    {
                        IAutoFilter filter = sheet.AutoFilters[0];
                        filter.AddColorFilter(color, ExcelColorFilterType.CellColor);
                    }

                    break;

                case 5:
                    sheet.AutoFilters.FilterRange = sheet["A4:D44"];
                    ExcelIconSetType iconSet = ExcelIconSetType.FiveArrows;
                    int filterIndex = 0;
                    int iconId = 0;
                    switch (IconSetList.SelectedIndex)
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

                    switch (IconIdList.SelectedIndex)
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
                            if (IconSetList.SelectedIndex == 0)
                            {
                                iconSet = (ExcelIconSetType)(-1);
                            }
                            else
                            {
                                iconId = 3;
                            }

                            break;
                        case 4:
                            if (IconSetList.SelectedIndex == 1)
                            {
                                iconSet = (ExcelIconSetType)(-1);
                            }
                            else
                            {
                                iconId = 4;
                            }

                            break;
                        case 5:
                            iconSet = (ExcelIconSetType)(-1);
                            break;
                    }

                    IAutoFilter filter5 = sheet.AutoFilters[filterIndex];
                    filter5.AddIconFilter(iconSet, iconId);
                    break;

                case 6:
                    // AdvancedFilter
                    IRange filterRange = sheet.Range["A8:G51"];
                    IRange criteriaRange = sheet.Range["A2:B5"];
                    if (Advanced.SelectedIndex == 0)
                    {
                        sheet.AdvancedFilter(ExcelFilterAction.FilterInPlace, filterRange, criteriaRange, null, Switch1.IsToggled);
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
                        sheet.AdvancedFilter(ExcelFilterAction.FilterCopy, filterRange, criteriaRange, copyRange, Switch1.IsToggled);
                    }

                    break;
            }

            workbook.Version = ExcelVersion.Excel2013;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();

            if (Device.RuntimePlatform == Device.UWP)
            {
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("Filters.xlsx", "application/msexcel", stream);
            }
            else
            {
                Xamarin.Forms.DependencyService.Get<ISave>().Save("Filters.xlsx", "application/msexcel", stream);
            }
        }

        internal void OnButtonClicked1(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            // Initializing Workbook
            Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            Stream fileStream = null;
            int filterType = this.picker.SelectedIndex;
			#if COMMONSB
			 if (filterType == 6)
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.AdvancedFilterData.xlsx");
            else if (filterType == 5)
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.IconFilterData.xlsx");
            else if (filterType == 4)
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.FilterData_Color.xlsx");
            else
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.FilterData.xlsx");
			#else
			if (filterType == 6)
            {
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.AdvancedFilterData.xlsx");
            }
            else if (filterType == 5)
            {
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.IconFilterData.xlsx");
            }
            else if (filterType == 4)
            {
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.FilterData_Color.xlsx");
            }
            else
            {
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.FilterData.xlsx");
            }
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

        internal void OnItemSelected(object sender, EventArgs e)
        {
            if (this.picker.SelectedIndex == 6)
            {
                this.DynamicGrid.IsVisible = true;
                this.ColorFilterGrid.IsVisible = false;
                this.IconFilterGrid.IsVisible = false;
            }
            else if (this.picker.SelectedIndex == 5)
            {
                this.DynamicGrid.IsVisible = false;
                this.ColorFilterGrid.IsVisible = false;
                this.IconFilterGrid.IsVisible = true;
            }
            else if (this.picker.SelectedIndex == 4)
            {
                this.DynamicGrid.IsVisible = false;
                this.ColorFilterGrid.IsVisible = true;
                this.IconFilterGrid.IsVisible = false;
            }
            else
            {
                this.DynamicGrid.IsVisible = false;
                this.ColorFilterGrid.IsVisible = false;
                this.IconFilterGrid.IsVisible = false;
            }            
        }

        internal void IconSetChanged(object sender, EventArgs e)
        {
            if (IconSetList.SelectedIndex == 0)
            {
                this.IconIdList.Items.Clear();
                this.IconIdList.Items.Add("RedCrossSymbol");
                this.IconIdList.Items.Add("YellowExclamationSymbol");
                this.IconIdList.Items.Add("GreenCheckSymbol");
                this.IconIdList.Items.Add("NoIcon");
            }
            else if (IconSetList.SelectedIndex == 1)
            {
                this.IconIdList.Items.Clear();
                this.IconIdList.Items.Add("SignalWithOneFillBar");
                this.IconIdList.Items.Add("SignalWithTwoFillBars");
                this.IconIdList.Items.Add("SignalWithThreeFillBars");
                this.IconIdList.Items.Add("SignalWithFourFillBars");
                this.IconIdList.Items.Add("NoIcon");
            }
            else
            {
                this.IconIdList.Items.Clear();
                this.IconIdList.Items.Add("RedDownArrow");
                this.IconIdList.Items.Add("YellowDownInclineArrow");
                this.IconIdList.Items.Add("YellowSideArrow");
                this.IconIdList.Items.Add("YellowUpInclineArrow");
                this.IconIdList.Items.Add("GreenUpArrow");
                this.IconIdList.Items.Add("NoIcon");
            }

            this.IconIdList.SelectedIndex = 0;
        }          
    }

    public class IconList
    {
        public string IconName { get; set; }

        public string Icon { get; set; }
    }
}