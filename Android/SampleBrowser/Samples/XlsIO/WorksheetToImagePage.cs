#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XlsIO;
using Syncfusion.XlsIORenderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COLOR = Syncfusion.Drawing;
using System.IO;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using System.Reflection;

namespace SampleBrowser
{
    public partial class WorksheetToImagePage : SamplePage
    {
		private Context m_context;
        RadioGroup radioGroup;
        RadioButton pngButton;
        RadioButton jpegButton;


        public override View GetSampleContent (Context con)
		{
			LinearLayout linear = new LinearLayout(con);
			linear.SetBackgroundColor(Color.White);
			linear.Orientation = Orientation.Vertical;
			linear.SetPadding(10, 10, 10, 10);

			TextView text2 = new TextView(con);
			text2.TextSize = 17;
			text2.TextAlignment = TextAlignment.Center;
			text2.Text = "This sample illustrates the conversion of a simple Excel document to an image.";
			text2.SetTextColor(Color.ParseColor("#262626"));
			text2.SetPadding(5, 5, 5, 5);

			linear.AddView(text2);

			TextView space1 = new TextView (con);
			space1.TextSize = 10;
			linear.AddView (space1);

			m_context = con;

            LinearLayout radioLinearLayout = new LinearLayout(con);
            radioLinearLayout.Orientation = Orientation.Horizontal;

            TextView imageType = new TextView(con);
            imageType.Text = "Image Format : ";
            imageType.TextSize = 19;
            radioLinearLayout.AddView(imageType);

            radioGroup = new RadioGroup(con);
            radioGroup.TextAlignment = TextAlignment.Center;
            radioGroup.Orientation = Orientation.Horizontal;
            pngButton = new RadioButton(con);
            pngButton.Text = "PNG";
            radioGroup.AddView(pngButton);
            jpegButton = new RadioButton(con);
            jpegButton.Text = "JPEG";
            radioGroup.AddView(jpegButton);
            radioGroup.Check(1);
            radioLinearLayout.AddView(radioGroup);
            linear.AddView(radioLinearLayout);
            pngButton.Checked = true;

            TextView space2 = new TextView(con);
            space2.TextSize = 10;
            linear.AddView(space2);

            Button templateButton = new Button(con);
            templateButton.Text = "Input Template";
            templateButton.Click += OnButtonClicked;
            linear.AddView(templateButton);

            Button convertButton = new Button (con);
			convertButton.Text = "Convert";
			convertButton.Click += OnConvertButtonClicked;
			linear.AddView (convertButton);

			return linear;
		}

        private void OnConvertButtonClicked(object sender, EventArgs e)
        {
            //Instantiate excel engine
            ExcelEngine excelEngine = new ExcelEngine();
            //Excel application
            IApplication application = excelEngine.Excel;

            //Get assembly manifest resource
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Template.ExpenseReport.xlsx");

            //Open Workbook
            IWorkbook workbook = application.Workbooks.Open(fileStream);

            //Get Worksheet
            IWorksheet worksheet = workbook.Worksheets[0];

            //Initialize XlsIORenderer
            application.XlsIORenderer = new XlsIORenderer();

            //Set file content type
            string contentType = "image/png";
			ExportImageOptions imageOptions = new ExportImageOptions();
			imageOptions.ImageFormat = ExportImageFormat.Png;

            //Create a new memory stream
            MemoryStream stream = new MemoryStream();

            if(pngButton.Checked)
            {
                worksheet.ConvertToImage(worksheet.UsedRange, imageOptions, stream);
            }
            else
            {
				imageOptions.ImageFormat = ExportImageFormat.Jpeg;
                worksheet.ConvertToImage(worksheet.UsedRange, imageOptions, stream);
                contentType = "image/jpeg";
            }

            workbook.Close();
            excelEngine.Dispose();

            //Save and view the generated file.
            SaveAndView(stream, contentType, true);
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream filestream = assembly.GetManifestResourceStream("SampleBrowser.Samples.XlsIO.Template.ExpenseReport.xlsx");

            MemoryStream stream = new MemoryStream();
            filestream.CopyTo(stream);

            SaveAndView(stream, "application/msexcel", false);
        }
        void SaveAndView(MemoryStream stream, string contentType, bool image)
        {
            if (stream != null)
            {
                stream.Position = 0;
                SaveAndroid androidSave = new SaveAndroid();
                if (image)
                    androidSave.Save("Image." + contentType.Split('/').ToArray()[1], contentType, stream, m_context);
                else
                    androidSave.Save("Template.xlsx", contentType, stream, m_context);
            }
        }
    }
}
