#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Foundation;
using UIKit;

namespace SampleBrowser.SfPdfViewer.iOS
{
	internal class AlertViewDelegate : UIAlertViewDelegate
	{
		Syncfusion.SfPdfViewer.XForms.SfPdfViewer pdfviewer;
		UIAlertView uiAlertView;
		UIAlertView alert;
		int pageNum = 0;
		nint clickedButtonIndex = -1;
		NSObject notificationToken;

		public AlertViewDelegate(Syncfusion.SfPdfViewer.XForms.SfPdfViewer pdfviewerControl)
		{
			pdfviewer = pdfviewerControl;
			alert = new UIAlertView();
			alert.AlertViewStyle = UIAlertViewStyle.Default;
			alert.Title = "Error";
			alert.AddButton("Ok");
			alert.Message = "Please enter a valid page number";
		}

		public override bool ShouldEnableFirstOtherButton(UIAlertView alertView)
		{
			return alertView.GetTextField(0).Text.Length > 0;
		}

		public override void Clicked(UIAlertView alertview, nint buttonIndex)
		{
			uiAlertView = alertview;
			clickedButtonIndex = buttonIndex;
			if (buttonIndex != alertview.CancelButtonIndex)
			{
				alertview.GetTextField(0).ResignFirstResponder();
				if (int.TryParse(alertview.GetTextField(0).Text, out pageNum) && pageNum > 0 && pageNum <= pdfviewer.PageCount)
					pdfviewer.PageNumber = pageNum;
			}
			notificationToken = NSNotificationCenter.DefaultCenter.AddObserver((NSString)"UIKeyboardDidHideNotification", KeyboardDidHide);
		}

		void KeyboardDidHide(NSNotification obj)
		{
			if (clickedButtonIndex != -1 && clickedButtonIndex != uiAlertView.CancelButtonIndex && uiAlertView.GetTextField(0).Text != "" && (!(int.TryParse(uiAlertView.GetTextField(0).Text, out pageNum) && pageNum > 0 && pageNum <= pdfviewer.PageCount)))
				alert.Show();
			NSNotificationCenter.DefaultCenter.RemoveObserver(notificationToken);
		}

		public override void Presented(UIAlertView alertView)
		{
			UITextRange textRange = alertView.GetTextField(0).SelectedTextRange;
			alertView.GetTextField(0).SelectAll(null);
			alertView.GetTextField(0).SelectedTextRange = textRange;
		}
	}
}
