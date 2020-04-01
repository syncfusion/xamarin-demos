#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using CoreGraphics;
using Syncfusion.SfPdfViewer.iOS;
using UIKit;

namespace SampleBrowser
{
    public class AnnotationHelper
    {
        CustomToolbar m_parent;
        InkAnnotationHelper m_inkannot;
        internal const float DefaultToolbarHeight = 50f;

        private CustomToolbar Parent
        {
            get
            {
                return m_parent;
            }
            set
            {
                m_parent = value;
            }
        }

        public AnnotationHelper(CustomToolbar customtoolbar)
        {
            Parent = customtoolbar;
        }


        internal void AnnotationButton_TouchUpInside(object sender, EventArgs e)
        {
            Parent.isColorSelected = false;
            Parent.isThicknessTouched = false;
            Parent.isOpacityNeeded = false;
            if(Parent.pdfViewerControl.AnnotationMode== AnnotationMode.Ink)
            {
                Parent.pdfViewerControl.EndInkSession(false);
            }
            if (Parent.annotation != null)
            {
                Parent.inkThicknessButton.Frame = new CGRect(Parent.parentView.Frame.Width - 55, 7, 35, 35);
                Parent.inkAnnotationToolbar.Add(Parent.inkThicknessButton);

                Parent.inkColorButton.Frame = new CGRect(Parent.parentView.Frame.Width - 100, 7, 35, 35);
                Parent.inkAnnotationToolbar.Add(Parent.inkColorButton);
                Parent.inkdeleteButton.RemoveFromSuperview();
                Parent.annotation = null;
            }
            if (!Parent.isAnnotationToolbarVisible)
            {
                Parent.thicknessToolbar.RemoveFromSuperview();
                Parent.toolBar.RemoveFromSuperview();
                Parent.toolbar = Parent.toolBar;
                Parent.toolBarFrame.Height = DefaultToolbarHeight;
                Parent.AddSubview(Parent.toolbar);
                Parent.searchToolBar.RemoveFromSuperview();
                Parent.annotationFrame = Parent.Frame;
                Parent.annotationFrame.Height = DefaultToolbarHeight;
                Parent.annotationFrame.Y = Parent.parentView.Frame.Height - Parent.annotationFrame.Height + 4;
                Parent.annotationToolbar.Frame = Parent.annotationFrame;
                Parent.annotationToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);

                Parent.textMarkupAnnotationButton.Frame = new CGRect(Parent.annotationToolbar.Frame.Width / 2 - 85, 7, 35, 35);
                Parent.textMarkupAnnotationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                Parent.textMarkupAnnotationButton.TouchUpInside += Parent.helper.TextMarkupAnnotationButton_TouchUpInside;
                Parent.textMarkupAnnotationButton.Font = Parent.highFont;
                Parent.textMarkupAnnotationButton.SetTitle("\ue70e", UIControlState.Normal);
                Parent.textMarkupAnnotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
                Parent.annotationToolbar.Add(Parent.textMarkupAnnotationButton);

                Parent.inkAnnotationButton.Frame = new CGRect(Parent.annotationToolbar.Frame.Width / 2 + 85, 7, 35, 35);
                Parent.inkAnnotationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                Parent.inkAnnotationButton.Font = Parent.highFont;
                Parent.inkAnnotationButton.SetTitle("\ue704", UIControlState.Normal);
                Parent.inkAnnotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
                Parent.annotationToolbar.Add(Parent.inkAnnotationButton);

                Parent.annotationToolbar = Parent.UpdateToolbarBorder(Parent.annotationToolbar, Parent.annotationFrame);
                Parent.Add(Parent.annotationToolbar);
                Parent.isAnnotationToolbarVisible = true;
                Parent.highlightToolbar.RemoveFromSuperview();
                Parent.strikeOutToolbar.RemoveFromSuperview();
                Parent.underlineToolbar.RemoveFromSuperview();
                Parent.colorToolbar.RemoveFromSuperview();
            }
            else
            {
                RemoveAllToolbars(false);
                Parent.pdfViewerControl.AnnotationMode = AnnotationMode.None;
                Parent.isAnnotationToolbarVisible = false;
            }
        }

        internal void RemoveAllToolbars(bool isBackButton)
        {
            Parent.textAnnotationToolbar.RemoveFromSuperview();
            if (!isBackButton)
            {
                Parent.colorToolbar.RemoveFromSuperview();
                Parent.highlightToolbar.RemoveFromSuperview();
                Parent.strikeOutToolbar.RemoveFromSuperview();
                Parent.underlineToolbar.RemoveFromSuperview();
                Parent.opacityPanel.RemoveFromSuperview();
                Parent.inkAnnotationSessionToolbar.RemoveFromSuperview();
                Parent.textAnnotationToolbar.RemoveFromSuperview();
                Parent.inkAnnotationToolbar.RemoveFromSuperview();
                Parent.annotationToolbar.RemoveFromSuperview();
                Parent.thicknessToolbar.RemoveFromSuperview();
            }
            Parent.isAnnotationToolbarVisible = false;
            Parent.isColorSelected = false;
            Parent.isThicknessTouched = false;
            Parent.isOpacityNeeded = false;
        }

        internal void SaveButton_TouchUpInside(object sender, EventArgs e)
        {
            Stream stream = new MemoryStream();
            stream = Parent.pdfViewerControl.SaveDocument();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filepath = Path.Combine(path, "savedDocument.pdf");

            FileStream outputFillStream = File.Open(filepath, FileMode.Create);
            stream.Position = 0;
            stream.CopyTo(outputFillStream);
            outputFillStream.Close();

            UIAlertView alertview = new UIAlertView();
            alertview.Frame = new CGRect(20, 100, 200, 200);
            alertview.Message = filepath;
            alertview.Title = "The modified document is saved in the below location.";
            alertview.AddButton("Ok");
            alertview.Show();
            RemoveAllToolbars(false);
        }
    }
}