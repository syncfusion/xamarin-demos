#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COLOR = Syncfusion.Drawing;
using System.IO;
using System.Reflection;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Xml;
using Syncfusion.PresentationRenderer;
using Android.Graphics;

namespace SampleBrowser
{
    public partial class PPTXToImage : SamplePage
    {
        private Context m_context;
        RadioGroup radioGroup;
        RadioButton pngButton;
        RadioButton jpegButton;


        public override View GetSampleContent(Context con)
        {
            LinearLayout linear = new LinearLayout(con);
            linear.SetBackgroundColor(Color.White);
            linear.Orientation = Orientation.Vertical;
            linear.SetPadding(10, 10, 10, 10);

            TextView text2 = new TextView(con);
            text2.TextSize = 17;
            text2.TextAlignment = TextAlignment.Center;
            text2.Text = "This sample demonstrates how to convert the PowerPoint slide to an image.";
            text2.SetTextColor(Color.ParseColor("#262626"));
            text2.SetPadding(5, 5, 5, 5);

            linear.AddView(text2);

            TextView space1 = new TextView(con);
            space1.TextSize = 10;
            linear.AddView(space1);

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

            Button convertButton = new Button(con);
            convertButton.Text = "Convert";
            convertButton.Click += OnConvertButtonClicked;
            linear.AddView(convertButton);

            return linear;
        }
        
        private void OnConvertButtonClicked(object sender, EventArgs e)
        {
            string resourcePath = "SampleBrowser.Samples.Presentation.Templates.Template.pptx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            //Open a existing PowerPoint presentation.
            IPresentation presentation = Syncfusion.Presentation.Presentation.Open(fileStream);

            //Initialize PresentationRenderer to perform image conversion.
            presentation.PresentationRenderer = new PresentationRenderer();

            //Set file content type
            string contentType;
            Syncfusion.Presentation.ExportImageFormat imageFormat;
            if (pngButton.Checked)
            {
                contentType = "image/png";
                imageFormat = ExportImageFormat.Png;
            }
            else
            {                
                contentType = "image/jpeg";
                imageFormat = ExportImageFormat.Jpeg;
            }

            //Convert PowerPoint slide to image stream.
            Stream stream = presentation.Slides[0].ConvertToImage(imageFormat);

            //Reset the stream position
            stream.Position = 0;

            //Close the PowerPoint Presentation.
            presentation.Close();            

            //Save and view the generated file.
            SaveAndView(stream as MemoryStream, contentType, true);
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            string resourcePath = "SampleBrowser.Samples.Presentation.Templates.Template.pptx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            MemoryStream stream = new MemoryStream();
            fileStream.CopyTo(stream);
            fileStream.Dispose();

            SaveAndView(stream, "application/powerpoint", false);
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
                    androidSave.Save("InputTemplate.pptx", contentType, stream, m_context);
            }
        }
    }
}
