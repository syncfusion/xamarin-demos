#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.Presentation;
using System.IO;
using COLOR = Syncfusion.Drawing;
using System.Reflection;
#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using CGRect = System.Drawing.RectangleF;
using CGPoint = System.Drawing.PointF;
using CGSize = System.Drawing.SizeF;
#endif
namespace SampleBrowser
{
	public partial class ConnectorsPresentation : SampleView
	{
		CGRect frameRect = new CGRect ();
		float frameMargin = 8.0f;
		UILabel label;
		UILabel label1;
		UIButton button;
		public ConnectorsPresentation()
		{

			label1 = new UILabel();
			label = new UILabel();
			button = new UIButton(UIButtonType.System);
			button.TouchUpInside += OnButtonClicked;
		}

		void LoadAllowedTextsLabel()
		{
			label.Frame = frameRect;
			label.TextColor = UIColor.FromRGB (38/255.0f, 38/255.0f, 38/255.0f);
			label.Text = "This sample demonstrates how to insert a connectors in a PowerPoint slide.";
			label.Font = UIFont.SystemFontOfSize(15);
			label.Lines 				= 0;
			label.LineBreakMode 		= UILineBreakMode.WordWrap;
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				label.Font = UIFont.SystemFontOfSize(18);
				label.Frame = new CGRect (5, 5,frameRect.Location.X + frameRect.Size.Width  , 50);
			} 
			else {
				label.Frame = new CGRect (frameRect.Location.X, 5, frameRect.Size.Width , 70);

			}
			this.AddSubview (label);
			button.SetTitle("Generate Presentation",UIControlState.Normal);
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				button.Frame = new CGRect (0, 65, frameRect.Location.X + frameRect.Size.Width , 10);
			} 
			else {
				button.Frame = new CGRect (frameRect.Location.X, 70, frameRect.Size.Width , 10);

			}
			this.AddSubview (button);
		}




		void OnButtonClicked(object sender, EventArgs e)
		{
            //Create an instance for PowerPoint
            IPresentation presentation = Presentation.Create();

            //Add a blank slide to Presentation
            ISlide slide = presentation.Slides.Add(SlideLayoutType.Blank);

            //Add header shape
            IShape headerTextBox = slide.Shapes.AddTextBox(255.60, 11.35, 315.33, 41.20);
            //Add a paragraph into the text box
            IParagraph paragraph = headerTextBox.TextBody.AddParagraph("Flow chart with connector");
            //Set the font size of the paragraph
            paragraph.Font.FontSize = 28;

            //Add start shape to slide
            IShape startShape = slide.Shapes.AddShape(AutoShapeType.FlowChartTerminator, 343.69, 79.22, 101.34, 35.86);
            //Add a paragraph into the start shape text body
            AddParagraph(startShape, "Start");

            //Add alarm shape to slide
            IShape alarmShape = slide.Shapes.AddShape(AutoShapeType.FlowChartProcess, 343.69, 151.35, 101.34, 44.93);
            //Add a paragraph into the alarm shape text body
            AddParagraph(alarmShape, "Alarm Rings");

            //Add condition shape to slide
            IShape conditionShape = slide.Shapes.AddShape(AutoShapeType.FlowChartDecision, 343.69, 239.22, 101.34, 73.98);
            //Add a paragraph into the condition shape text body
            AddParagraph(conditionShape, "Ready to Get Up ?");
            //Change font size of the paragraph
            conditionShape.TextBody.Paragraphs[0].Font.FontSize = 12;

            //Add wake up shape to slide
            IShape wakeUpShape = slide.Shapes.AddShape(AutoShapeType.FlowChartProcess, 343.69, 356.15, 101.34, 44.93);
            //Add a paragraph into the wake up shape text body
            AddParagraph(wakeUpShape, "Wake Up");

            //Add end shape to slide
            IShape endShape = slide.Shapes.AddShape(AutoShapeType.FlowChartTerminator, 343.69, 447.93, 101.34, 35.86);
            //Add a paragraph into the end shape text body
            AddParagraph(endShape, "End");

            //Add snooze shape to slide
            IShape snoozeShape = slide.Shapes.AddShape(AutoShapeType.FlowChartProcess, 545.09, 239.22, 101.34, 73.98);
            //Add a paragraph into the snooze shape text body
            AddParagraph(snoozeShape, "Hit Snooze button");

            //Add relay shape to slide
            IShape relayShape = slide.Shapes.AddShape(AutoShapeType.FlowChartDelay, 545.09, 151.35, 101.34, 44.93);
            //Add a paragraph into the relay shape text body
            AddParagraph(relayShape, "Relay");

            //Connect the start shape with alarm shape using connector
            IConnector connector1 = slide.Shapes.AddConnector(ConnectorType.Straight, startShape, 2, alarmShape, 0);
            //Set the arrow style for the connector
            connector1.LineFormat.EndArrowheadStyle = ArrowheadStyle.Arrow;

            //Connect the alarm shape with condition shape using connector
            IConnector connector2 = slide.Shapes.AddConnector(ConnectorType.Straight, alarmShape, 2, conditionShape, 0);
            //Set the arrow style for the connector
            connector2.LineFormat.EndArrowheadStyle = ArrowheadStyle.Arrow;

            //Connect the condition shape with snooze shape using connector
            IConnector connector3 = slide.Shapes.AddConnector(ConnectorType.Straight, conditionShape, 3, snoozeShape, 1);
            //Set the arrow style for the connector
            connector3.LineFormat.EndArrowheadStyle = ArrowheadStyle.Arrow;

            //Connect the snooze shape with relay shape using connector
            IConnector connector4 = slide.Shapes.AddConnector(ConnectorType.Straight, snoozeShape, 0, relayShape, 2);
            //Set the arrow style for the connector
            connector4.LineFormat.EndArrowheadStyle = ArrowheadStyle.Arrow;

            //Connect the relay shape with alarm shape using connector
            IConnector connector5 = slide.Shapes.AddConnector(ConnectorType.Straight, relayShape, 1, alarmShape, 3);
            //Set the arrow style for the connector
            connector5.LineFormat.EndArrowheadStyle = ArrowheadStyle.Arrow;

            //Connect the condition shape with wake up shape using connector
            IConnector connector6 = slide.Shapes.AddConnector(ConnectorType.Straight, conditionShape, 2, wakeUpShape, 0);
            //Set the arrow style for the connector
            connector6.LineFormat.EndArrowheadStyle = ArrowheadStyle.Arrow;

            //Connect the wake up shape with end shape using connector
            IConnector connector7 = slide.Shapes.AddConnector(ConnectorType.Straight, wakeUpShape, 2, endShape, 0);
            //Set the arrow style for the connector
            connector7.LineFormat.EndArrowheadStyle = ArrowheadStyle.Arrow;

            //Add No textbox to slide
            IShape noTextBox = slide.Shapes.AddTextBox(470.97, 250.34, 35.67, 29.08);
            //Add a paragraph into the text box
            noTextBox.TextBody.AddParagraph("No");

            //Add Yes textbox to slide
            IShape yesTextBox = slide.Shapes.AddTextBox(394.15, 314.92, 38.23, 29.08);
            //Add a paragraph into the text box
            yesTextBox.TextBody.AddParagraph("Yes");

            MemoryStream stream = new MemoryStream();
            presentation.Save(stream);
            presentation.Close();
            stream.Position = 0;

			if (stream != null)
			{
				SaveiOS iOSSave = new SaveiOS ();
				iOSSave.Save ("ConnectorsPresentation.pptx", "application/mspowerpoint", stream);
			}

		}

        /// <summary>
        /// Add a paragraph into the specified shape with specified text
        /// </summary>
        /// <param name="shape">Represent the shape</param>
        /// <param name="text">Represent the text to be added</param>
        private void AddParagraph(IShape shape, string text)
        {
            //Add a paragraph into the specified shape with specified text
            IParagraph paragraph = shape.TextBody.AddParagraph(text);
            //Set the vertical alignment as center
            shape.TextBody.VerticalAlignment = VerticalAlignmentType.Middle;
            //Set horizontal alignment as center
            paragraph.HorizontalAlignment = HorizontalAlignmentType.Center;
            //Set font color as white
            paragraph.Font.Color = ColorObject.White;
        }

        public override void LayoutSubviews ()
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				frameMargin = 0.0f;
			}
			frameRect = Bounds;
			frameRect.Location = new CGPoint (frameRect.Location.X + frameMargin, frameRect.Location.Y + 1.5f * frameMargin);
			frameRect.Size = new CGSize(frameRect.Size.Width - (frameRect.Location.X + frameMargin), frameRect.Size.Height - (frameRect.Location.Y + 1.5f * frameMargin));

			LoadAllowedTextsLabel ();

			base.LayoutSubviews ();
		}
	}
}
