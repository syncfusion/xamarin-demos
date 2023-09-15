#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SampleBrowser.SfPdfViewer.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Rect = Android.Graphics.Rect;

[assembly: ResolutionGroupName("SampleBrowser.SfPdfViewer")]
[assembly: ExportEffect(typeof(EditBookmarkPopupEffect), nameof(EditBookmarkPopupEffect))]
namespace SampleBrowser.SfPdfViewer.Droid
{
   public class EditBookmarkPopupEffect : PlatformEffect
    {
        private LayoutListener layoutListener;

        [Obsolete]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        protected override void OnAttached()
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
        {
            if ((Activity)Xamarin.Forms.Forms.Context != null && ((Activity)Xamarin.Forms.Forms.Context).Window != null &&
                   ((Activity)Xamarin.Forms.Forms.Context).Window.DecorView != null && ((Activity)Xamarin.Forms.Forms.Context).Window.DecorView.RootView != null)
            {
                layoutListener = new LayoutListener(this.Element);
                ((Activity)Xamarin.Forms.Forms.Context).Window.DecorView.RootView.ViewTreeObserver?.AddOnGlobalLayoutListener(layoutListener);
            };
        }

        [Obsolete]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        protected override void OnDetached()
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
        {
            if (this?.Element is SampleBrowser.SfPdfViewer.EditBookmarkPopup editBookmarkPopupView && !editBookmarkPopupView.IsRenameEntryFocused && !editBookmarkPopupView.IsRenamePopupOpened)
            {
                if ((Activity)Xamarin.Forms.Forms.Context != null && ((Activity)Xamarin.Forms.Forms.Context).Window != null &&
               ((Activity)Xamarin.Forms.Forms.Context).Window.DecorView != null && ((Activity)Xamarin.Forms.Forms.Context).Window.DecorView.RootView != null)
                {
                    ((Activity)Xamarin.Forms.Forms.Context).Window.DecorView.RootView.ViewTreeObserver?.RemoveGlobalOnLayoutListener(layoutListener);
                }
            }
        }
    }
    internal class LayoutListener : Java.Lang.Object, ViewTreeObserver.IOnGlobalLayoutListener
    {
        [Obsolete]
        private EditBookmarkPopup editBookmarkPopupView;
        [Obsolete]
        internal LayoutListener(Element editBookmarkPopup)
        {
            editBookmarkPopupView = editBookmarkPopup as EditBookmarkPopup;
        }

        [Obsolete]
        public void OnGlobalLayout()
        {
            Rect rectangle = new Rect();
            if ((Activity)Xamarin.Forms.Forms.Context != null && ((Activity)Xamarin.Forms.Forms.Context).Window != null &&
             ((Activity)Xamarin.Forms.Forms.Context).Window.DecorView != null && ((Activity)Xamarin.Forms.Forms.Context).Window.DecorView.RootView != null)

                ((Activity)Xamarin.Forms.Forms.Context).Window.DecorView.GetWindowVisibleDisplayFrame(rectangle);
            int screenHeight = ((Activity)Xamarin.Forms.Forms.Context).Window.DecorView.RootView.Height;

            int keyboardSize = screenHeight - rectangle.Height();

            if (editBookmarkPopupView != null)
            {
                if (keyboardSize > 0 && editBookmarkPopupView.IsRenamePopupOpened && editBookmarkPopupView.IsRenameEntryFocused)
                {
                    editBookmarkPopupView.Children[0].Margin = new Thickness(0, 0, 0, keyboardSize / 4); //push the popup view up to keyboard height when keyboard is activated
                }
                else
                {
                    editBookmarkPopupView.Children[0].Margin = new Thickness(0); //set the Padding to zero when keyboard is dismissed
                    
                }

            }
            rectangle.Dispose();
        }

    }
}