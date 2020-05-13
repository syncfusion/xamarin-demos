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
using Syncfusion.SfRangeSlider.iOS;
using UIKit;

namespace SampleBrowser
{
    class EditTextAnnotationHelper
    {
        CustomToolbar parent;
        TextMarkupAnnotationHelper textmarkupHelper;
        AnnotationHelper annotHelper;
        internal const float DefaultToolbarHeight = 50f;
        CGColor separatorgray = UIColor.FromRGBA(red: 0.86f, green: 0.86f, blue: 0.86f, alpha: 1.0f).CGColor;
        internal UIButton editButton = new UIButton();
        internal UIButton editTextButton = new UIButton();
        internal const float DefaultEditToolbarHeight = 50f;
        internal UILabel rangeSliderLabel = new UILabel();
        public EditTextAnnotationHelper(CustomToolbar customtoolbar)
        {
            parent = customtoolbar;
        }
        public EditTextAnnotationHelper(TextMarkupAnnotationHelper helper, CustomToolbar customtoolbar)
        {
            textmarkupHelper = helper;
            parent = customtoolbar;
        }
        public EditTextAnnotationHelper(AnnotationHelper annottoolbar, CustomToolbar customtoolbar)
        {
            annotHelper = annottoolbar;
            parent = customtoolbar;
        }
        internal void PdfViewerControl_FreeTextPopupDisappearing(object sender, FreeTextPopupDisappearedEventArgs args)
        {
            if (args.PopupResult == FreeTextPopupResult.Cancel || args.PopupResult == FreeTextPopupResult.Ok)
            {
                parent.editTextAnnotationToolbar.RemoveFromSuperview();
                if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
                    parent.pdfViewerControl.AnnotationMode = AnnotationMode.None;
            }
        }
        internal void PdfViewerControl_FreeTextAnnotationSelected(object sender, FreeTextAnnotationSelectedEventArgs args)
        {
            parent.annotation = sender as FreeTextAnnotation;
            parent.toolbarBackbutton.RemoveFromSuperview();
            parent.isOpacityNeeded = false;
            parent.iseditEnable = true;
            parent.annotationFrame = parent.Frame;
            parent.annotationFrame.Height = DefaultToolbarHeight;
            parent.annotationFrame.Y = parent.parentView.Frame.Height - parent.annotationFrame.Height + 4;
            parent.editTextAnnotationToolbar.Frame = parent.annotationFrame;
            parent.editTextAnnotationToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);
            parent.editTextAnnotationToolbar.RemoveFromSuperview();
            
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                editTextButton.Frame = new CGRect(65, 7, 35, 35);
            else
                editTextButton.Frame = new CGRect(40, 7, 35, 35);
            editTextButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            editTextButton.Font = parent.highFont;
            editTextButton.SetTitle("\ue700", UIControlState.Normal);
            editTextButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            parent.editTextAnnotationToolbar.Add(editTextButton);
            if (parent.iseditEnable)
            {
                editButton.Frame = new CGRect(parent.parentView.Frame.Width - 200, 7, 35, 35);
                editButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                editButton.Font = parent.highFont;
                editButton.TouchUpInside += EditButton_TouchUpInside;
                editButton.SetTitle("\ue720", UIControlState.Normal);
                editButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
                parent.editTextAnnotationToolbar.Add(editButton);
            }
            else
            {
                editButton.RemoveFromSuperview();
            }
            parent.edittextThicknessButton.Frame = new CGRect(parent.parentView.Frame.Width - 150, 7, 30, 30);
            parent.edittextThicknessButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.edittextThicknessButton.Font = parent.fontSizeFont;
            parent.edittextThicknessButton.SetTitle("\ue700", UIControlState.Normal);
            parent.edittextThicknessButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);           
            parent.editTextAnnotationToolbar.Add(parent.edittextThicknessButton);

            parent.edittextColorButton.Frame = new CGRect(parent.parentView.Frame.Width - 100, 7, 30, 30);
            parent.edittextColorButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            if (parent.annotation != null)
                parent.edittextColorButton.BackgroundColor = (parent.annotation as FreeTextAnnotation).Settings.TextColor;
            else
                parent.edittextColorButton.BackgroundColor = parent.pdfViewerControl.AnnotationSettings.FreeText.TextColor;
            parent.editTextAnnotationToolbar.Add(parent.edittextColorButton);
           
            parent.editTextAnnotationToolbar = parent.UpdateToolbarBorder(parent.editTextAnnotationToolbar, parent.annotationFrame);
            parent.Add(parent.editTextAnnotationToolbar);
           
            parent.edittextDeleteButton.Frame = new CGRect(parent.parentView.Frame.Width - 55, 7, 35, 35);
            parent.edittextDeleteButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.edittextDeleteButton.TouchUpInside += parent.inkHelper.InkdeleteButton_TouchUpInside;
            parent.edittextDeleteButton.Font = parent.highFont;
            parent.edittextDeleteButton.SetTitle("\ue714", UIControlState.Normal);
            parent.edittextDeleteButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            parent.editTextAnnotationToolbar.Add(parent.edittextDeleteButton);
        }
        private void EditButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.pdfViewerControl.EditFreeTextAnnotation();
        }
        internal void PdfViewerControl_FreeTextAnnotationDeselected(object sender, FreeTextAnnotationDeselectedEventArgs args)
        {
            parent.editTextAnnotationButton.BackgroundColor = new UIColor(0, 0, 0, 0);
            parent.annotation = null;
            parent.iseditEnable = false;
            parent.edittextThicknessButton.Frame = new CGRect(parent.parentView.Frame.Width - 100, 7, 30, 30);
            parent.editTextAnnotationToolbar.Add(parent.edittextThicknessButton);
            parent.edittextColorButton.Frame = new CGRect(parent.parentView.Frame.Width - 55, 7, 30, 30);
            parent.editTextAnnotationToolbar.Add(parent.edittextColorButton);
            parent.edittextDeleteButton.RemoveFromSuperview();
            parent.editTextAnnotationToolbar.RemoveFromSuperview();
            parent.thicknessToolbar.RemoveFromSuperview();
            parent.colorToolbar.RemoveFromSuperview();
            parent.opacityPanel.RemoveFromSuperview();
            editButton.RemoveFromSuperview();
            parent.FontSizePanel.RemoveFromSuperview();
            parent.rangeSlider.RemoveFromSuperview();
            parent.isOpacityNeeded = false;
            parent.annotationToolbar.Add(parent.editTextAnnotationButton);
            parent.FontSizePanel.RemoveFromSuperview();           
        }

        internal void EditTextThicknessButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.colorToolbar.RemoveFromSuperview();
            parent.FontSizePanel.Frame = parent.Frame;
            CGRect rect = new CGRect();
            rect = parent.Frame;
            rect.Height = DefaultEditToolbarHeight + 16;
            rect.Y = parent.parentView.Frame.Height - (DefaultToolbarHeight + parent.editTextAnnotationToolbar.Frame.Height + 10);            
            rect.Width = parent.parentView.Frame.Width;
            parent.FontSizePanel.Frame = rect;
            
            parent.rangeSlider.ToolTipPlacement = SFToolTipPlacement.SFToolTipPlacementBottomRight;
            parent.rangeSlider.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleTopMargin;           
            parent.rangeSlider.ShowValueLabel = false;
            parent.rangeSlider.Minimum = 6;
            parent.rangeSlider.Maximum = 22;
            parent.rangeSlider.TickFrequency = 2;
            parent.rangeSlider.StepFrequency = 2;
            parent.rangeSlider.ShowRange = false;
            parent.rangeSlider.Value = (nfloat)parent.pdfViewerControl.AnnotationSettings.FreeText.TextSize;

            parent.rangeSlider.Orientation = SFOrientation.SFOrientationHorizontal;
            parent.rangeSlider.TickPlacement = SFTickPlacement.SFTickPlacementInline;
            parent.rangeSlider.SnapsTo = SFSnapsTo.SFSnapsToTicks;
            parent.FontSizePanel.BackgroundColor = UIColor.FromRGB(249, 249, 249);
            parent.Add(parent.FontSizePanel);
            parent.FontSizePanel.Add(parent.rangeSlider);
            parent.rangeSlider.Frame = new CGRect(rect.X + 8, 35, rect.Width - 8, 30);
           
            parent.rangeSlider.ValueChange += RangeSlider_ValueChange;
            rangeSliderLabel.AccessibilityIdentifier = "RangeSliderLabelLabel";
            rangeSliderLabel.Frame = new CGRect(((parent.FontSizePanel.Frame.Width) / 2) - 40, 8, 80, 22);
            rangeSliderLabel.Text = "Font:" + parent.rangeSlider.Value + "pt";
            rangeSliderLabel.TextColor = new UIColor(red: 0.17f, green: 0.17f, blue: 0.17f, alpha: 1.0f);
            parent.FontSizePanel.Add(rangeSliderLabel);

            parent.rangeSlider.BringSubviewToFront(parent.rangeSlider);
            parent.FontSizePanel.Layer.BorderColor = new CGColor(0.2f, 0.2f);
            parent.FontSizePanel.Layer.BorderWidth = 1;
        }
        private void RangeSlider_ValueChange(object sender, ValueEventArgs e)
        {
            rangeSliderLabel.Text = "Font:" + (int)e.Value + "pt";
            if (parent.annotation != null)
                (parent.annotation as FreeTextAnnotation).Settings.TextSize = (float)e.Value;
            else
                parent.pdfViewerControl.AnnotationSettings.FreeText.TextSize = (float)e.Value;
        }
        internal void PdfViewerControl_FreeTextAnnotationAdded(object sender, FreeTextAnnotationAddedEventArgs args)
        {            
            parent.rangeSlider.RemoveFromSuperview();
            parent.FontSizePanel.RemoveFromSuperview();
            parent.isAnnotationToolbarVisible = false;
            parent.annotHelper.RemoveAllToolbars(false);
            parent.annotationToolbar.Add(parent.editTextAnnotationButton);
            parent.Add(parent.annotationToolbar);
            parent.FontSizePanel.RemoveFromSuperview();
            parent.toolbarBackbutton.RemoveFromSuperview();
        }

        internal void EditTextAnnotationButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.pdfViewerControl.AnnotationMode = AnnotationMode.FreeText;
            parent.annotationFrame = parent.Frame;
            parent.annotationFrame.Height = DefaultToolbarHeight;
            parent.annotationFrame.Y = parent.parentView.Frame.Height - parent.annotationFrame.Height + 4;
            parent.editTextAnnotationToolbar.Frame = parent.annotationFrame;
            parent.editTextAnnotationToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);
            parent.editTextAnnotationToolbar.RemoveFromSuperview();

            editTextButton.Frame = new CGRect(65, 7, 35, 35);
            editTextButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            editTextButton.Font = parent.highFont;
            editTextButton.SetTitle("\ue700", UIControlState.Normal);
            editTextButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            parent.editTextAnnotationToolbar.Add(editTextButton);
            if (parent.iseditEnable)
            {
                editButton.Frame = new CGRect(parent.parentView.Frame.Width - 200, 7, 35, 35);
                editButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                editButton.Font = parent.highFont;
                editButton.TouchUpInside += EditButton_TouchUpInside;
                editButton.SetTitle("\ue709", UIControlState.Normal);
                editButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
                parent.editTextAnnotationToolbar.Add(editButton);
            }
            else
            {
                parent.toolbarBackbutton.Frame = new CGRect(15, 7, 35, 35);
                parent.toolbarBackbutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                parent.toolbarBackbutton.TouchUpInside += parent.ToolbarBackbutton_TouchUpInside;
                parent.toolbarBackbutton.Font = parent.highFont;
                parent.toolbarBackbutton.SetTitle("\ue708", UIControlState.Normal);
                parent.toolbarBackbutton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
                parent.editTextAnnotationToolbar.Add(parent.toolbarBackbutton);
            }
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                parent.edittextThicknessButton.Frame = new CGRect(parent.parentView.Frame.Width - 100, 7, 30, 30);
            else
                parent.edittextThicknessButton.Frame = new CGRect(parent.parentView.Frame.Width - 100, 7, 30, 30);
            parent.edittextThicknessButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.edittextThicknessButton.Font = parent.fontSizeFont;
            parent.edittextThicknessButton.SetTitle("\ue700", UIControlState.Normal);
            parent.edittextThicknessButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            
            parent.editTextAnnotationToolbar.Add(parent.edittextThicknessButton);
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                parent.edittextColorButton.Frame = new CGRect(parent.parentView.Frame.Width - 55, 7, 30, 30);
            else
                parent.edittextColorButton.Frame = new CGRect(parent.parentView.Frame.Width - 55, 7, 30, 30);
            parent.edittextColorButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.edittextColorButton.BackgroundColor = parent.pdfViewerControl.AnnotationSettings.FreeText.TextColor;
            parent.editTextAnnotationToolbar.Add(parent.edittextColorButton);
            parent.editTextAnnotationToolbar = parent.UpdateToolbarBorder(parent.editTextAnnotationToolbar, parent.annotationFrame);
            parent.Add(parent.editTextAnnotationToolbar);
        }
    }
}