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
        CustomToolbar parent;
        internal const float DefaultToolbarHeight = 50f;
        private const int numberOfButtonsInAnnotationToolbar = 6;
        public AnnotationHelper(CustomToolbar customtoolbar)
        {
            parent = customtoolbar;
        }
        internal void AnnotationButton_TouchUpInside(object sender, EventArgs e)
        {
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad && parent.bookmarkToolbar != null && parent.bookmarkToolbar.Superview != null)
            {
                parent.bookmarkToolbar.RemoveFromSuperview();
                parent.isBookmarkPaneVisible = false;
            }
            parent.isColorSelected = false;
            parent.isThicknessTouched = false;
            parent.isOpacityNeeded = false;
            parent.annotationToolbar.AutoresizingMask = UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleWidth;
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                parent.pdfViewerControl.EndInkSession(false);
            }
            if (parent.annotation != null)
            {
                parent.inkThicknessButton.Frame = new CGRect(parent.parentView.Frame.Width - 55, 7, 35, 35);
                parent.inkAnnotationToolbar.Add(parent.inkThicknessButton);

                parent.inkColorButton.Frame = new CGRect(parent.parentView.Frame.Width - 100, 7, 35, 35);
                parent.inkAnnotationToolbar.Add(parent.inkColorButton);
                parent.inkdeleteButton.RemoveFromSuperview();
                parent.annotation = null;
            }
            if (!parent.isAnnotationToolbarVisible)
            {
                int buttonSpacing = (int)((parent.annotationToolbar.Frame.Width - 100) / numberOfButtonsInAnnotationToolbar);
                int left = 80;
                parent.thicknessToolbar.RemoveFromSuperview();
                parent.toolBar.RemoveFromSuperview();
                parent.toolbar = parent.toolBar;
                parent.toolBarFrame.Height = DefaultToolbarHeight;
                parent.AddSubview(parent.toolbar);
                parent.searchToolBar.RemoveFromSuperview();
                parent.annotationFrame = parent.Frame;
                parent.annotationFrame.Height = DefaultToolbarHeight;
                parent.annotationFrame.Y = parent.parentView.Frame.Height - parent.annotationFrame.Height + 4;
                parent.annotationToolbar.Frame = parent.annotationFrame;
                parent.annotationToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);
                if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                    parent.textMarkupAnnotationButton.Frame = new CGRect(left, 7, 35, 35);
                else
                    parent.textMarkupAnnotationButton.Frame = new CGRect(0, 7, 35, 35);
                parent.textMarkupAnnotationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                parent.textMarkupAnnotationButton.TouchUpInside += parent.helper.TextMarkupAnnotationButton_TouchUpInside;
                parent.textMarkupAnnotationButton.Font = parent.highFont;
                parent.textMarkupAnnotationButton.SetTitle("\ue70e", UIControlState.Normal);
                parent.textMarkupAnnotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
                parent.annotationToolbar.Add(parent.textMarkupAnnotationButton);

                if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                    parent.inkAnnotationButton.Frame = new CGRect(left + 4 * buttonSpacing, 7, 35, 35);
                else
                    parent.inkAnnotationButton.Frame = new CGRect(105, 7, 35, 35);
                parent.inkAnnotationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                parent.inkAnnotationButton.Font = parent.highFont;
                parent.inkAnnotationButton.SetTitle("\ue704", UIControlState.Normal);
                parent.inkAnnotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
                parent.annotationToolbar.Add(parent.inkAnnotationButton);

                if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                    parent.editTextAnnotationButton.Frame = new CGRect(left + buttonSpacing, 7, 35, 35);
                else
                    parent.editTextAnnotationButton.Frame = new CGRect((165), 7, 35, 35);
                parent.editTextAnnotationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                parent.editTextAnnotationButton.TouchUpInside += parent.edittextHelper.EditTextAnnotationButton_TouchUpInside;
                parent.editTextAnnotationButton.Font = parent.highFont;
                parent.editTextAnnotationButton.SetTitle("\ue700", UIControlState.Normal);
                parent.editTextAnnotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
                parent.annotationToolbar.Add(parent.editTextAnnotationButton);
                
                if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                    parent.shapeAnnotationButton.Frame = new CGRect(left + 2*buttonSpacing, 7, 35, 35);
                else
                    parent.shapeAnnotationButton.Frame = new CGRect(45, 7, 35, 35);
                parent.shapeAnnotationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                parent.shapeAnnotationButton.TouchUpInside += parent.shapeHelper.ShapeAnnotationButton_TouchUpInside;
                parent.shapeAnnotationButton.Font = parent.highFont;
                parent.shapeAnnotationButton.SetTitle("\ue721", UIControlState.Normal);
                parent.shapeAnnotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
                parent.annotationToolbar.Add(parent.shapeAnnotationButton);


                if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                    parent.signatureButton.Frame = new CGRect(left + 3 * buttonSpacing, 7, 35, 35);
                else
                    parent.signatureButton.Frame = new CGRect(225, 7, 35, 35);
                parent.signatureButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                parent.signatureButton.VerticalAlignment = UIControlContentVerticalAlignment.Top;
				parent.signatureButton.TouchUpInside += SignatureButton_TouchUpInside;
                parent.signatureButton.Font = parent.signatureFont;
                parent.signatureButton.SetTitle("\ue702", UIControlState.Normal);
                parent.signatureButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
                parent.annotationToolbar.Add(parent.signatureButton);

                if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                    parent.stampButton.Frame = new CGRect(left + 5 * buttonSpacing, 7, 35, 35);
                else
                    parent.stampButton.Frame = new CGRect(275, 7, 35, 35);
                parent.stampButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                parent.stampButton.VerticalAlignment = UIControlContentVerticalAlignment.Top;
                parent.stampButton.TouchUpInside += StampButton_TouchUpInside;
                parent.stampButton.Font = parent.stampFont;
                parent.stampButton.SetTitle("\ue701", UIControlState.Normal);
                parent.stampButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
                parent.annotationToolbar.Add(parent.stampButton);

                parent.annotationToolbar = parent.UpdateToolbarBorder(parent.annotationToolbar, parent.annotationFrame);

                parent.annotationToolbar = parent.UpdateToolbarBorder(parent.annotationToolbar, parent.annotationFrame);
                
                parent.Add(parent.annotationToolbar);
                parent.isAnnotationToolbarVisible = true;
                parent.highlightToolbar.RemoveFromSuperview();
                parent.editStampAnnotationToolbar.RemoveFromSuperview();
                parent.strikeOutToolbar.RemoveFromSuperview();
                parent.underlineToolbar.RemoveFromSuperview();
                parent.colorToolbar.RemoveFromSuperview();
            }
            else
            {
                parent.annotHelper.RemoveAllToolbars(false);
                parent.pdfViewerControl.AnnotationMode = AnnotationMode.None;
                parent.isAnnotationToolbarVisible = false;
            }
        }
        private void StampButton_TouchUpInside(object sender, EventArgs e)
        {
            if(parent.stampView == null)
                parent.stampView = new StampAnnotationView(parent);
            parent.AddSubview(parent.stampView);
            parent.isStampViewVisible = true;
        }

        internal void RemoveAllToolbars(bool isBackButton)
        {
            parent.textAnnotationToolbar.RemoveFromSuperview();
            if (!isBackButton)
            {
                parent.colorToolbar.RemoveFromSuperview();
                parent.highlightToolbar.RemoveFromSuperview();
                parent.strikeOutToolbar.RemoveFromSuperview();
                parent.underlineToolbar.RemoveFromSuperview();
                parent.editStampAnnotationToolbar.RemoveFromSuperview();
                parent.opacityPanel.RemoveFromSuperview();
                parent.inkAnnotationSessionToolbar.RemoveFromSuperview();
                parent.textAnnotationToolbar.RemoveFromSuperview();
                parent.inkAnnotationToolbar.RemoveFromSuperview();
                parent.annotationToolbar.RemoveFromSuperview();
                parent.thicknessToolbar.RemoveFromSuperview();
                parent.editTextAnnotationToolbar.RemoveFromSuperview();
                parent.lineToolbar.RemoveFromSuperview();
                parent.arrowToolbar.RemoveFromSuperview();
                parent.circleToolbar.RemoveFromSuperview();
                parent.rectangleToolbar.RemoveFromSuperview();
                parent.shapeAnnotationToolbar.RemoveFromSuperview();
                parent.rangeSlider.RemoveFromSuperview();
                parent.FontSizePanel.RemoveFromSuperview();
            }
            parent.isAnnotationToolbarVisible = false;
            parent.isColorSelected = false;
            parent.isThicknessTouched = false;
            parent.isOpacityNeeded = false;
        }

        void SignatureButton_TouchUpInside(object sender, EventArgs e)
		{
			parent.pdfViewerControl.AnnotationMode = AnnotationMode.HandwrittenSignature;
		}


		internal void SaveButton_TouchUpInside(object sender, EventArgs e)
        {
            Stream stream = new MemoryStream();
            stream = parent.pdfViewerControl.SaveDocument();
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
            parent.annotHelper.RemoveAllToolbars(false);
        }
    }
}