#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
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
using Xamarin.Forms;


namespace SampleBrowser.XlsIO
{
	public partial class FindAndReplacePage : SampleView
    {
		public FindAndReplacePage()
		{
			InitializeComponent ();

			this.picker.Items.Add ("Berlin");
			this.picker.Items.Add ("8000");
			this.picker.Items.Add ("Representative");
			this.picker.SelectedIndex = 0;
            
			if (Device.Idiom != TargetIdiom.Phone && (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WinRT))
            {
				this.Content_1.HorizontalOptions = LayoutOptions.Start;
				this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
                this.btnGetInputTemplate.HorizontalOptions = LayoutOptions.Start;
                Error.HorizontalOptions = LayoutOptions.Start;
                Error.VerticalOptions = LayoutOptions.Center;
                this.Content_1.VerticalOptions = LayoutOptions.Center;
				this.btnGenerate.VerticalOptions = LayoutOptions.Center;
				this.btnGenerate.BackgroundColor = Color.Gray;
                this.btnGetInputTemplate.VerticalOptions = LayoutOptions.Center;
                this.btnGetInputTemplate.BackgroundColor = Color.Gray;               
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.WinPhone)
            {
				
				{
					this.Content_1.FontSize = 13.5;
                    Error.FontSize = 13.5;
                }
				this.Content_1.VerticalOptions = LayoutOptions.Center;
                Error.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnGetInputTemplate.VerticalOptions = LayoutOptions.Center;
            }
            Error.Text = string.Empty;
            Error.TextColor = Color.Red;
        }

        void ReplaceTextChanged(object sender, TextChangedEventArgs e)
        {
            Error.Text = "";
        }

        void OnButtonClicked(object sender, EventArgs e)
		{
			ExcelEngine excelEngine = new ExcelEngine();
			IApplication application = excelEngine.Excel;
			application.DefaultVersion = ExcelVersion.Excel2013;

			#region Initializing Workbook
			Assembly assembly = typeof(App).GetTypeInfo().Assembly;
			
			Stream fileStream=null;
			#if COMMONSB
			fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.ReplaceOptions.xlsx");
			#else
            fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.ReplaceOptions.xlsx");
			#endif

			IWorkbook workbook = application.Workbooks.Open(fileStream);
			//The first worksheet object in the worksheets collection is accessed.
			IWorksheet sheet = workbook.Worksheets[0];
			#endregion

			int replaceIndex = this.picker.SelectedIndex;
			string replaceText;

			switch(replaceIndex)
			{
			default:
			case 0:
				replaceText = "Berlin";
				break;

			case 1:
				replaceText = "8000";
                break;

			case 2:
				replaceText = "Representative";
				break;

			}
			ExcelFindOptions option = ExcelFindOptions.None;

			if (switch1.IsToggled) 
				option |= ExcelFindOptions.MatchCase;

			if (switch2.IsToggled) 
				option |= ExcelFindOptions.MatchEntireCellContent;
            MemoryStream stream = null;
            try
            {
                if (entry.Text != null && entry.Text != "")
                    sheet.Replace(replaceText, entry.Text, option);
                stream = new MemoryStream();
                workbook.SaveAs(stream);
            }
            catch(Exception ex)
            {
                string exception = ex.ToString();
                Error.Text = "Given string is invalid.";
            }
			workbook.Version = ExcelVersion.Excel2013;            
			workbook.Close();
			excelEngine.Dispose();

            if (stream!=null)
            {
                if (Device.RuntimePlatform == Device.WinPhone || Device.RuntimePlatform == Device.WinRT || Device.RuntimePlatform == Device.UWP)
                    Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("FindAndReplace.xlsx", "application/msexcel", stream);
                else
                    Xamarin.Forms.DependencyService.Get<ISave>().Save("FindAndReplace.xlsx", "application/msexcel", stream);
            }
            
		}
        void OnButtonClicked1(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            #region Initializing Workbook
            Assembly assembly = typeof(App).GetTypeInfo().Assembly;
			
			Stream fileStream=null;
			#if COMMONSB
			fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Samples.Template.ReplaceOptions.xlsx");
			#else
			fileStream = assembly.GetManifestResourceStream("SampleBrowser.XlsIO.Samples.Template.ReplaceOptions.xlsx");
			#endif

            IWorkbook workbook = application.Workbooks.Open(fileStream);
            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];
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
    }
    }

