#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
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

namespace SampleBrowser
{
    public partial class OLEObjectPresentation : SamplePage
    {
        private Context m_context;
        public override View GetSampleContent(Context con)
        {
            LinearLayout linear = new LinearLayout(con);
            linear.SetBackgroundColor(Android.Graphics.Color.White);
            linear.Orientation = Orientation.Vertical;
            linear.SetPadding(10, 10, 10, 10);
            
            TextView text1 = new TextView(con);
            text1.TextSize = 17;
            text1.TextAlignment = TextAlignment.Center;
            text1.SetTextColor(Android.Graphics.Color.ParseColor("#262626"));
            text1.Text = "This sample demonstrates how to insert and extract a OLE Object in PowerPoint presentation.";
            text1.SetPadding(5, 10, 10, 5);
            linear.AddView(text1);
            
            TextView space = new TextView(con);
            space.TextSize = 10;
            linear.AddView(space);
            m_context = con;
            
            TextView space2 = new TextView(con);
            space2.TextSize = 10;
            linear.AddView(space2);

            Button button1 = new Button(con);
            button1.Text = "Create Presentation";
            button1.Click += OnInsertOleButtonClicked;
            linear.AddView(button1);

            Button button2 = new Button(con);
            button2.Text = "Open Embedded File";
            button2.Click += OnButtonClicked;
            linear.AddView(button2);
            
            return linear;
        }

        void OnInsertOleButtonClicked(object sender, EventArgs e)
        {
            
            Assembly assembly = Assembly.GetExecutingAssembly();            

            //New Instance of PowerPoint is Created.[Equivalent to launching MS PowerPoint with no slides].
            IPresentation presentation = Syncfusion.Presentation.Presentation.Create();

            ISlide slide = presentation.Slides.Add(SlideLayoutType.TitleOnly);

            IShape titleShape = slide.Shapes[0] as IShape;
            titleShape.Left = 0.65 * 72;
            titleShape.Top = 0.24 * 72;
            titleShape.Width = 11.5 * 72;
            titleShape.Height = 1.45 * 72;
            titleShape.TextBody.AddParagraph("Ole Object");
            titleShape.TextBody.Paragraphs[0].Font.Bold = true;
            titleShape.TextBody.Paragraphs[0].HorizontalAlignment = HorizontalAlignmentType.Left;

            IShape heading = slide.Shapes.AddTextBox(100, 100, 100, 100);
            heading.Left = 0.84 * 72;
            heading.Top = 1.65 * 72;
            heading.Width = 2.23 * 72;
            heading.Height = 0.51 * 72;
            heading.TextBody.AddParagraph("MS Word Object");
            heading.TextBody.Paragraphs[0].Font.Italic = true;
            heading.TextBody.Paragraphs[0].Font.Bold = true;
            heading.TextBody.Paragraphs[0].Font.FontSize = 18;
			
            string mswordPath = "SampleBrowser.Samples.Presentation.Templates.OleTemplate.docx";			

            //Get the word file as stream
            Stream wordStream = assembly.GetManifestResourceStream(mswordPath);
            string imagePath = "SampleBrowser.Samples.Presentation.Templates.OlePicture.png";

            //Image to be displayed, This can be any image
            Stream imageStream = assembly.GetManifestResourceStream(imagePath);

            IOleObject oleObject = slide.Shapes.AddOleObject(imageStream, "Word.Document.12", wordStream);
            //Set size and position of the ole object
            oleObject.Left = 4.53 * 72;
            oleObject.Top = 0.79 * 72;
            oleObject.Width = 4.26 * 72;
            oleObject.Height = 5.92 * 72;
            //Set DisplayAsIcon as true, to open the embedded document in separate (default) application.
            oleObject.DisplayAsIcon = true;
            MemoryStream stream = new MemoryStream();
            presentation.Save(stream);
            presentation.Close();
            stream.Position = 0;
            if (stream != null)
            {
                SaveAndroid androidSave = new SaveAndroid();
                androidSave.Save("InsertOLEObject.pptx", "application/powerpoint", stream, m_context);
            }
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            string resourcePath = "SampleBrowser.Samples.Presentation.Templates.EmbeddedOleObject.pptx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            IPresentation presentation = Syncfusion.Presentation.Presentation.Open(fileStream);
            //Gets the first slide of the Presentation
            ISlide slide = presentation.Slides[0];
            //Gets the Ole Object of the slide
            IOleObject oleObject = slide.Shapes[2] as IOleObject;
            //Gets the file data of embedded Ole Object.
            byte[] array = oleObject.ObjectData;
            //Gets the file Name of OLE Object
            string outputFile = oleObject.FileName;
            
            MemoryStream stream = new MemoryStream(array);            
            presentation.Close();
            stream.Position = 0;
            if (stream != null)
            {
                SaveAndroid androidSave = new SaveAndroid ();
                androidSave.Save (outputFile, "application/msword", stream, m_context);
            }
        }        
    }
}
