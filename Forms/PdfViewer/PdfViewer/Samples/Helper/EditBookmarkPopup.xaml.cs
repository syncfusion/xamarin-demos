#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfPdfViewer.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfPdfViewer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditBookmarkPopup : Grid
    {
        private PDFViewerCustomToolbar_Desktop desktopToolbar;
        private PDFViewerCustomToolbar_Phone phoneToolbar;
        private PDFViewerCustomToolbar_Tablet tabletToolbar;
        public bool IsRenamePopupOpened { get; set; }
        public bool IsRenameEntryFocused { get; set; }
        internal Entry EditEntry
        {
            get { return textEntry; }
        }

        internal EditBookmarkPopup(PDFViewerCustomToolbar_Desktop desktopToolbar)
        {
            InitializeComponent();
            BackgroundColor = Color.FromRgba(0, 0, 0, 0.3);
            CancelBtn.Text = "CANCEL";
            OKBtn.Text = "OK";
            this.desktopToolbar = desktopToolbar;
        }
        internal EditBookmarkPopup(PDFViewerCustomToolbar_Phone phoneToolbar)
        {
            InitializeComponent();
            BackgroundColor = Color.FromRgba(0, 0, 0, 0.3);
            CancelBtn.Text = "CANCEL";
            OKBtn.Text = "OK";
            this.phoneToolbar = phoneToolbar;
        }
        internal EditBookmarkPopup(PDFViewerCustomToolbar_Tablet tabletToolbar)
        {
            InitializeComponent();
            BackgroundColor = Color.FromRgba(0, 0, 0, 0.3);
            CancelBtn.Text = "CANCEL";
            OKBtn.Text = "OK";
            this.tabletToolbar = tabletToolbar;
        }
        private void textEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.OldTextValue != null || e.OldTextValue != String.Empty)
            {
                if (e.NewTextValue != String.Empty || e.OldTextValue == String.Empty)
                {
                    OKBtn.IsEnabled = true;
                }
                else
                {
                    OKBtn.IsEnabled = false;
                }
            }
            else
            {
                OKBtn.IsEnabled = false;
            }
        }

        private void CancelBtn_Clicked(object sender, EventArgs e)
        {
            this.IsVisible = false;
            IsRenamePopupOpened = false;
            textEntry.Text = string.Empty;
        }
        
        private async void OKBtn_Clicked(object sender, EventArgs e)
        {
            this.IsVisible = false;
            if (Device.Idiom == TargetIdiom.Desktop)
            {
                desktopToolbar.bookMarkPane.messageLabel.Text = desktopToolbar.pdfViewer.CustomBookmarks[desktopToolbar.bookMarkPane.selectedCustomBookmarkIndex].Name + "-Edited";
                if(textEntry.Text!= desktopToolbar.pdfViewer.CustomBookmarks[desktopToolbar.bookMarkPane.selectedCustomBookmarkIndex].Name)
                {
                    desktopToolbar.pdfViewer.CustomBookmarks[desktopToolbar.bookMarkPane.selectedCustomBookmarkIndex].Name = textEntry.Text;
                    desktopToolbar.PositionToastMessage();
                    desktopToolbar.bookMarkPane.toastMessageFrame.IsVisible = true;
                    await desktopToolbar.bookMarkPane.toastMessageFrame.FadeTo(1, 1000);
                    await desktopToolbar.bookMarkPane.toastMessageFrame.FadeTo(0, 1000);
                }
                else
                {
                    desktopToolbar.bookMarkPane.toastMessageFrame.IsVisible = false;
                }

            }
            else if (Device.Idiom == TargetIdiom.Phone)
            {
                phoneToolbar.bookmarkToolbar.messageLabel.Text = phoneToolbar.pdfViewer.CustomBookmarks[phoneToolbar.bookmarkToolbar.selectedCustomBookmarkIndex].Name + "-Edited";
                if(textEntry.Text!= phoneToolbar.pdfViewer.CustomBookmarks[phoneToolbar.bookmarkToolbar.selectedCustomBookmarkIndex].Name)
                {
                    phoneToolbar.pdfViewer.CustomBookmarks[phoneToolbar.bookmarkToolbar.selectedCustomBookmarkIndex].Name = textEntry.Text;
                    phoneToolbar.bookmarkToolbar.toastMessageFrame.IsVisible = true;
                    await phoneToolbar.bookmarkToolbar.toastMessageFrame.FadeTo(1, 1000);
                    await phoneToolbar.bookmarkToolbar.toastMessageFrame.FadeTo(0, 1000);
                }
                else
                {
                    phoneToolbar.bookmarkToolbar.toastMessageFrame.IsVisible = false;
                }
            }
            else
            {
                tabletToolbar.bookmarkToolbar.messageLabel.Text = tabletToolbar.pdfViewer.CustomBookmarks[tabletToolbar.bookmarkToolbar.selectedCustomBookmarkIndex].Name + "-Edited";
                if(textEntry.Text!= tabletToolbar.pdfViewer.CustomBookmarks[tabletToolbar.bookmarkToolbar.selectedCustomBookmarkIndex].Name)
                {
                    tabletToolbar.pdfViewer.CustomBookmarks[tabletToolbar.bookmarkToolbar.selectedCustomBookmarkIndex].Name = textEntry.Text;
                    tabletToolbar.PositionToastMessage();
                    tabletToolbar.bookmarkToolbar.toastMessageFrame.IsVisible = true;
                    await tabletToolbar.bookmarkToolbar.toastMessageFrame.FadeTo(1, 1000);
                    await tabletToolbar.bookmarkToolbar.toastMessageFrame.FadeTo(0, 1000);
                }
                else
                {
                    tabletToolbar.bookmarkToolbar.toastMessageFrame.IsVisible = false ;
                }
            }
            IsRenamePopupOpened = false;
            textEntry.Text = string.Empty;
        }

        private void textEntry_Focused(object sender, FocusEventArgs e)
        {
            IsRenamePopupOpened = true;
            IsRenameEntryFocused = true;
            EditEntry.CursorPosition = 0;
            EditEntry.SelectionLength = EditEntry.Text.Length;
        }

        private void textEntry_Unfocused(object sender, FocusEventArgs e)
        {
            IsRenameEntryFocused = false;
        }
    }
    internal class EditBookmarkPopupEffect : RoutingEffect
    {
        internal EditBookmarkPopupEffect() : base("SampleBrowser.SfPdfViewer.EditBookmarkPopupEffect")
        {
        }
    }
}