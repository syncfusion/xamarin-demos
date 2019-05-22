#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.XlsIO;
using System.IO;
using COLOR = Syncfusion.Drawing;
using System.Reflection;
using System.Collections.Generic;


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
	public partial class FindandReplace : SampleView
	{
	
		CGRect frameRect = new CGRect ();
		float frameMargin = 8.0f;
		UILabel label;
		UILabel label1;
		UIButton button_1;
		UIButton button ;
	
		public FindandReplace()
		{
		   label = new UILabel ();
		   label1 = new UILabel ();
		   button_1 = new UIButton (UIButtonType.System);
		   button = new UIButton (UIButtonType.System);
		   button_1.TouchUpInside += OnButtonClicked_1;
		   button.TouchUpInside += OnButtonClicked;
		}



		void LoadAllowedTextsLabel()
		{
			
			label.Frame = frameRect;
			label.TextColor = UIColor.FromRGB (38/255.0f, 38/255.0f, 38/255.0f);
			label.Text = "This sample demonstrates how to find the word Berlin and replace it as Rome within the worksheet.";
			label.Font = UIFont.SystemFontOfSize(15);
			label.Lines 				= 0;
			label.LineBreakMode 		= UILineBreakMode.WordWrap;
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				label.Font = UIFont.SystemFontOfSize(18);
				label.Frame = new CGRect (5, 5,frameRect.Location.X + frameRect.Size.Width  , 50);
			} 
			else {
				label.Frame = new CGRect (5, 5, frameRect.Size.Width , 60);

			}
			this.AddSubview (label);
			
			button_1.SetTitle("Input Template",UIControlState.Normal);
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				button_1.Frame = new CGRect (0, 65, frameRect.Location.X + frameRect.Size.Width , 20);
			} 
			else {
				button_1.Frame = new CGRect (5, 70, frameRect.Size.Width , 20);

			}
			
			this.AddSubview (button_1);

			
			button.SetTitle("Replace all",UIControlState.Normal);
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				button.Frame = new CGRect (0, 95, frameRect.Location.X + frameRect.Size.Width , 20);
			} 
			else {
				button.Frame = new CGRect (5, 100, frameRect.Size.Width , 20);

			}
			
			this.AddSubview (button);
		}
			
		void OnButtonClicked(object sender, EventArgs e)
		{
			ExcelEngine excelEngine = new ExcelEngine();
			IApplication application = excelEngine.Excel;

			application.DefaultVersion = ExcelVersion.Excel2013;

			#region Initializing Workbook
			string resourcePath = "SampleBrowser.Samples.XlsIO.Template.ReplaceOptions.xlsx";
			Assembly assembly = Assembly.GetExecutingAssembly ();
			Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

			IWorkbook workbook = application.Workbooks.Open(fileStream);

			IWorksheet sheet = workbook.Worksheets[0];
			#endregion

			string replaceText = "Berlin";

			ExcelFindOptions option = ExcelFindOptions.None;
			option |= ExcelFindOptions.MatchCase;
			option |= ExcelFindOptions.MatchEntireCellContent;

			sheet.Replace (replaceText, "Rome", option); 

			workbook.Version = ExcelVersion.Excel2013;

			MemoryStream stream = new MemoryStream();
			workbook.SaveAs(stream);
			workbook.Close();
			excelEngine.Dispose();

			if (stream != null)
			{
				SaveiOS iOSSave = new SaveiOS ();
				iOSSave.Save ("FindAndReplace.xlsx", "application/msexcel", stream);
			}

		}

		void OnButtonClicked_1(object sender, EventArgs e)
		{
			ExcelEngine excelEngine = new ExcelEngine();
			IApplication application = excelEngine.Excel;

			application.DefaultVersion = ExcelVersion.Excel2013;

			string resourcePath = "SampleBrowser.Samples.XlsIO.Template.ReplaceOptions.xlsx";
			Assembly assembly = Assembly.GetExecutingAssembly ();
			Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

			IWorkbook workbook = application.Workbooks.Open(fileStream);

			MemoryStream stream = new MemoryStream();
			workbook.SaveAs(stream);
			workbook.Close();
			excelEngine.Dispose();

			if (stream != null)
			{
				SaveiOS iOSSave = new SaveiOS ();
				iOSSave.Save ("InputTemplate.xlsx", "application/msexcel", stream );
			}

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

