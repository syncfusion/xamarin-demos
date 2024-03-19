#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using CoreGraphics;
using Foundation;
using SampleBrowser.SfPdfViewer.iOS;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("SampleBrowser.SfPdfViewer")]
[assembly: ExportEffect(typeof(EditBookmarkPopupEffect), nameof(EditBookmarkPopupEffect))]
namespace SampleBrowser.SfPdfViewer.iOS
{
    public class EditBookmarkPopupEffect : PlatformEffect
    {
        NSObject _keyboardShowObserver;
        NSObject _keyboardHideObserver;
        private PdfUnitConverter unitConverter = new PdfUnitConverter();

        protected override void OnAttached()
        {
            RegisterForKeyboardNotifications();
        }

        void RegisterForKeyboardNotifications()
        {
            if (_keyboardShowObserver == null)
                _keyboardShowObserver = UIKeyboard.Notifications.ObserveWillShow(OnKeyboardShow);
            if (_keyboardHideObserver == null)
                _keyboardHideObserver = UIKeyboard.Notifications.ObserveWillHide(OnKeyboardHide);
        }

        void OnKeyboardShow(object sender, UIKeyboardEventArgs args)
        {

            NSValue result = (NSValue)args.Notification.UserInfo.ObjectForKey(new NSString(UIKeyboard.FrameEndUserInfoKey));
            CGSize keyboardSize = result.RectangleFValue.Size;
            if (Element != null && Element is EditBookmarkPopup editBookmarkPopupView && editBookmarkPopupView.IsRenamePopupOpened && editBookmarkPopupView.IsRenameEntryFocused)
            {
                (Element as EditBookmarkPopup).Margin = new Thickness(0, 0, 0, unitConverter.ConvertFromPixels((float)keyboardSize.Height, PdfGraphicsUnit.Point)); //push the remname dialog up to keyboard height when keyboard is activated
            }
        }

        void OnKeyboardHide(object sender, UIKeyboardEventArgs args)
        {
            if (Element != null && (Element as EditBookmarkPopup) != null)
            {
                (Element as EditBookmarkPopup).Margin = new Thickness(0); //set the margins to zero when keyboard is dismissed
            }

        }


        void UnregisterForKeyboardNotifications()
        {
            if (_keyboardShowObserver != null)
            {
                _keyboardShowObserver.Dispose();
                _keyboardShowObserver = null;
            }

            if (_keyboardHideObserver != null)
            {
                _keyboardHideObserver.Dispose();
                _keyboardHideObserver = null;
            }
        }
        protected override void OnDetached()
        {
            UnregisterForKeyboardNotifications();
        }
    }
}