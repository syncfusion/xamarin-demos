#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XlsIO;
using Syncfusion.XlsIORenderer;
using System;
using System.IO;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using System.Reflection;
using Syncfusion.Pdf;

namespace SampleBrowser
{
    public partial class ExcelToPDFPage : SamplePage
    {
		private Context m_context;
        Spinner spinner;
        CheckBox checkfontName;
        CheckBox checkfontStream;

        public override View GetSampleContent (Context con)
		{
            int numerHeight = getDimensionPixelSize(con, Resource.Dimension.numeric_txt_ht);
            int width = con.Resources.DisplayMetrics.WidthPixels - 40;
            LinearLayout linear = new LinearLayout(con);
			linear.SetBackgroundColor(Color.White);
			linear.Orientation = Orientation.Vertical;
			linear.SetPadding(10, 10, 10, 10);

			TextView text2 = new TextView(con);
			text2.TextSize = 17;
			text2.TextAlignment = TextAlignment.Center;
			text2.Text = "This sample illustrates the conversion of a simple Excel document to PDF.";
			text2.SetTextColor(Color.ParseColor("#262626"));
			text2.SetPadding(5, 5, 5, 5);

			linear.AddView(text2);

			TextView space1 = new TextView (con);
			space1.TextSize = 10;
			linear.AddView (space1);

			m_context = con;

            LinearLayout subLinearLayout = new LinearLayout(con);
            subLinearLayout.Orientation = Orientation.Horizontal;

            TextView pageSetup = new TextView(con);
            pageSetup.Text = "Page Setup Options : ";
            pageSetup.TextAlignment = TextAlignment.Center;
            pageSetup.TextSize = 17;
            pageSetup.SetTextColor(Color.ParseColor("#262626"));
            pageSetup.LayoutParameters = new ViewGroup.LayoutParams(width / 2, numerHeight);
            subLinearLayout.AddView(pageSetup);

            string[] list = { "NoScaling", "FitAllRowsOnOnePage", "FitAllColumnsOnOnePage", "FitSheetOnOnePage"};
            ArrayAdapter<String> array = new ArrayAdapter<String>(con, Android.Resource.Layout.SimpleSpinnerItem, list);
            spinner = new Spinner(con);
            spinner.Adapter = array;
            spinner.SetSelection(0);
            subLinearLayout.AddView(spinner);
            linear.AddView(subLinearLayout);

            TextView space3 = new TextView(con);
            space3.TextSize = 10;
            linear.AddView(space3);

            TextView susbstitute = new TextView(con);
            susbstitute.Text = "Substitute Fonts : ";
            susbstitute.TextAlignment = TextAlignment.ViewStart;
            susbstitute.TextSize = 17;
            susbstitute.SetTextColor(Color.ParseColor("#262626"));
            linear.AddView(susbstitute);

            TextView space5 = new TextView(con);
            space5.TextSize = 17;
            linear.AddView(space5);

            checkfontName = new CheckBox(con);
            checkfontName.Text = "Font Name";
            linear.AddView(checkfontName);

            TextView susbstituteFontName = new TextView(con);
            susbstituteFontName.Text = "Missing fonts in the device will be substituted to Calibri.";
            susbstituteFontName.TextAlignment = TextAlignment.ViewStart;
            susbstituteFontName.TextSize = 10;
            susbstituteFontName.SetTextColor(Color.ParseColor("#262626"));
            linear.AddView(susbstituteFontName);

            TextView space6 = new TextView(con);
            space6.TextSize = 17;
            linear.AddView(space6);

            checkfontStream = new CheckBox(con);
            checkfontStream.Text = "Font Stream";
            linear.AddView(checkfontStream);

            TextView susbstituteFontStream = new TextView(con);
            susbstituteFontStream.Text = "Missing fonts in the device will be substituted from embedded resource.";
            susbstituteFontStream.TextAlignment = TextAlignment.ViewStart;
            susbstituteFontStream.TextSize = 10;
            susbstituteFontStream.SetTextColor(Color.ParseColor("#262626"));
            linear.AddView(susbstituteFontStream);

            TextView space4 = new TextView(con);
            space4.TextSize = 17;
            linear.AddView(space4);

            Button templateButton = new Button(con);
            templateButton.Text = "Input Template";
            templateButton.Click += OnButtonClicked;
            linear.AddView(templateButton);

            Button convertButton = new Button (con);
			convertButton.Text = "Convert To PDF";
			convertButton.Click += OnConvertButtonClicked;
			linear.AddView (convertButton);

			return linear;
		}

        void OnButtonClicked(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Stream filestream = null;
            if (this.checkfontName.Checked || this.checkfontStream.Checked)
                filestream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Template.InvoiceTemplate.xlsx");
            else
                filestream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Template.ExcelToPDF.xlsx");

            MemoryStream stream = new MemoryStream();
            filestream.CopyTo(stream);

            SaveAndView(stream, "application/msexcel");
        }
        private void OnConvertButtonClicked(object sender, EventArgs e)
        {
            //Instantiate excel engine
            ExcelEngine excelEngine = new ExcelEngine();
            //Excel application
            IApplication application = excelEngine.Excel;

            //Get assembly manifest resource
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream;
            if (this.checkfontName.Checked || this.checkfontStream.Checked)
            {
                application.SubstituteFont += new Syncfusion.XlsIO.Implementation.SubstituteFontEventHandler(SubstituteFont);
                fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Template.InvoiceTemplate.xlsx");
            }
            else           
              fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Template.ExcelToPDF.xlsx");

            //Open Workbook
            IWorkbook workbook = application.Workbooks.Open(fileStream);

            XlsIORenderer renderer = new XlsIORenderer();
            XlsIORendererSettings settings = new XlsIORendererSettings();
            settings.IsConvertBlankPage = false;
			
            int index = spinner.SelectedItemPosition;

            if (index == 0)
                settings.LayoutOptions = LayoutOptions.NoScaling;
            else if (index == 1)
                settings.LayoutOptions = LayoutOptions.FitAllRowsOnOnePage;
            else if (index == 2)
                settings.LayoutOptions = LayoutOptions.FitAllColumnsOnOnePage;
            else
                settings.LayoutOptions = LayoutOptions.FitSheetOnOnePage;       

            PdfDocument pdfDocument = renderer.ConvertToPDF(workbook, settings);
            MemoryStream memoryStream = new MemoryStream();
            pdfDocument.Save(memoryStream);
            pdfDocument.Close(true);            

            workbook.Close();
            excelEngine.Dispose();

            //Save and view the generated file.
            SaveAndView(memoryStream, "application/pdf");
        }
        void SaveAndView(MemoryStream stream, string contentType)
        {
            if (stream != null)
            {
                stream.Position = 0;
                SaveAndroid androidSave = new SaveAndroid();
                if (contentType == "application/pdf")
                    androidSave.Save("ExcelToPDF.pdf", contentType, stream, m_context);
                else
                    androidSave.Save("Input Template.xlsx", contentType, stream, m_context);
            }
        }
        private int getDimensionPixelSize(Context con, int id)
        {
            return con.Resources.GetDimensionPixelSize(id);
        }
        private void SubstituteFont(object sender, Syncfusion.XlsIO.Implementation.SubstituteFontEventArgs args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            if (checkfontName.Checked && (args.OriginalFontName == "Bahnschrift Pro SemiBold" || args.OriginalFontName == "Georgia Pro Semibold"))
            {
                args.AlternateFontName = "Calibri";
            }
            if (checkfontStream.Checked)
            {
                if (args.OriginalFontName == "Georgia Pro Semibold")
                {
                    Stream file = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Template.georgiab.ttf");
                    MemoryStream memoryStream = new MemoryStream();
                    file.CopyTo(memoryStream);
                    file.Close();
                    args.AlternateFontStream = memoryStream;
                }
                else if (args.OriginalFontName == "Bahnschrift Pro SemiBold")
                {
                    Stream file = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Template.bahnschrift.ttf");
                    MemoryStream memoryStream = new MemoryStream();
                    file.CopyTo(memoryStream);
                    file.Close();
                    args.AlternateFontStream = memoryStream;
                }
            }
        }
    }
}
