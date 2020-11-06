#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Foundation;
using Syncfusion.SfPdfViewer.iOS;
using UIKit;

namespace SampleBrowser
{
	internal class AlertViewDelegate : UIAlertViewDelegate
	{
		SfPdfViewer pdfviewer;
		UIAlertView uiAlertView;
		UIAlertView alert;
		NSObject nsObject;
		public AlertViewDelegate(SfPdfViewer pdfviewerControl)
		{
			pdfviewer = pdfviewerControl;
		}
		public override bool ShouldEnableFirstOtherButton(UIAlertView alertView)
		{
			return alertView.GetTextField(0).Text.Length > 0;
		}
		public override void Clicked(UIAlertView alertview, nint buttonIndex)
		{
			uiAlertView = alertview;
			if (buttonIndex != alertview.CancelButtonIndex)
			{
				alertview.GetTextField(0).ResignFirstResponder();
				int pageNum = 0;

				if (int.TryParse(alertview.GetTextField(0).Text, out pageNum) && pageNum > 0 && (pageNum <= pdfviewer.PageCount))
				{
					pdfviewer.GoToPage(pageNum);
				}
				else
				{
					alert = new UIAlertView();
					alert.AlertViewStyle = UIAlertViewStyle.Default;
					alert.AddButton("OK");
					alert.Title = "Invalid Page Number";
				}
			}
			nsObject=NSNotificationCenter.DefaultCenter.AddObserver((NSString)"UIKeyboardDidHideNotification", KeyboardDidHide);
		}
		void KeyboardDidHide(NSNotification obj)
		{
			int input = 0;
			if (!(int.TryParse(uiAlertView.GetTextField(0).Text, out input) && input > 0 && (input <= pdfviewer.PageCount)))
			{
				if (alert != null)
				{
					alert.Show();
				}
			}
			NSNotificationCenter.DefaultCenter.RemoveObserver(nsObject);
		}
		public override void Presented(UIAlertView alertView)
		{
			UITextRange textRange = alertView.GetTextField(0).SelectedTextRange;
			alertView.GetTextField(0).SelectAll(null);
			alertView.GetTextField(0).SelectedTextRange = textRange;
		}
	}
}
