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
    class ShapeAnnotationHelper
    {
        CustomToolbar parent;
        TextMarkupAnnotationHelper textmarkupHelper;
        AnnotationHelper annotHelper;
        internal const float DefaultToolbarHeight = 50f;
        CGColor separatorgray = UIColor.FromRGBA(red: 0.86f, green: 0.86f, blue: 0.86f, alpha: 1.0f).CGColor;
        internal UIButton editButton = new UIButton();
        internal UIButton shapeButton = new UIButton();
        internal const float DefaultEditToolbarHeight = 50f;
        public ShapeAnnotationHelper(CustomToolbar customtoolbar)
        {
            parent = customtoolbar;

        }
        public ShapeAnnotationHelper(TextMarkupAnnotationHelper helper, CustomToolbar customtoolbar)
        {
            textmarkupHelper = helper;
            parent = customtoolbar;
        }
        public ShapeAnnotationHelper(AnnotationHelper annottoolbar, CustomToolbar customtoolbar)
        {
            annotHelper = annottoolbar;
            parent = customtoolbar;
        }
        internal void PdfViewerControl_ShapeAnnotationSelected(object sender, ShapeAnnotationSelectedEventArgs args)
        {
            parent.annotation = sender as ShapeAnnotation;
            parent.shapeView = args.AnnotationType;
            if (args.AnnotationType == AnnotationMode.Arrow)
            {
                parent.arrowToolbar = CreateSeparateAnnotationToolbar(parent.arrowToolbar, parent.arrowEnable, "\ue712", true, (parent.annotation as ShapeAnnotation).Settings.StrokeColor);
                parent.isOpacityNeeded = true;
                parent.textToolbarBackButton.RemoveFromSuperview();
                parent.Add(parent.arrowToolbar);
            }
            if (args.AnnotationType == AnnotationMode.Line)
            {
                parent.lineToolbar = CreateSeparateAnnotationToolbar(parent.lineToolbar, parent.lineEnable, "\ue717", true, (parent.annotation as ShapeAnnotation).Settings.StrokeColor);
                parent.isOpacityNeeded = true;
                parent.textToolbarBackButton.RemoveFromSuperview();
                parent.Add(parent.lineToolbar);
            }
            if (args.AnnotationType == AnnotationMode.Rectangle)
            {
                parent.rectangleToolbar = CreateSeparateAnnotationToolbar(parent.rectangleToolbar, parent.rectangleEnable, "\ue705", true, (parent.annotation as ShapeAnnotation).Settings.StrokeColor);
                parent.isOpacityNeeded = true;
                parent.textToolbarBackButton.RemoveFromSuperview();
                parent.Add(parent.rectangleToolbar);
            }
            if (args.AnnotationType == AnnotationMode.Circle)
            {
                parent.circleToolbar = CreateSeparateAnnotationToolbar(parent.circleToolbar, parent.circleEnable, "\ue71f", true, (parent.annotation as ShapeAnnotation).Settings.StrokeColor);
                parent.isOpacityNeeded = true;
                parent.textToolbarBackButton.RemoveFromSuperview();
                parent.Add(parent.circleToolbar);
            }
        }
        internal void PdfViewerControl_ShapeAnnotationDeselected(object sender, ShapeAnnotationDeselectedEventArgs args)
        {
            parent.annotation = null;
            parent.isOpacityNeeded = false;
            if (args.AnnotationType == AnnotationMode.Rectangle)
            {
                parent.rectangleToolbar.RemoveFromSuperview();
            }
            else if (args.AnnotationType == AnnotationMode.Circle)
            {
                parent.circleToolbar.RemoveFromSuperview();
            }
            else if (args.AnnotationType == AnnotationMode.Line)
            {
                parent.lineToolbar.RemoveFromSuperview();
            }
            else if (args.AnnotationType == AnnotationMode.Arrow)
            {
                parent.arrowToolbar.RemoveFromSuperview();
            }
            parent.colorToolbar.RemoveFromSuperview();
            parent.shapeAnnotationToolbar.RemoveFromSuperview();
            parent.isAnnotationToolbarVisible = false;
            parent.thicknessToolbar.RemoveFromSuperview();
            parent.opacityPanel.RemoveFromSuperview();
        }
        internal void ShapeAnnotationButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.isOpacityNeeded = true;
            parent.annotationFrame = parent.Frame;
            parent.annotationFrame.Height = DefaultToolbarHeight;
            parent.annotationFrame.Y = parent.parentView.Frame.Height - parent.annotationFrame.Height + 4;
            parent.shapeAnnotationToolbar.Frame = parent.annotationFrame;
            parent.shapeAnnotationToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                parent.toolbarBackbutton.Frame = new CGRect(15, 7, 35, 35);
            else
                parent.toolbarBackbutton.Frame = new CGRect(5, 7, 35, 35);
            parent.toolbarBackbutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.toolbarBackbutton.TouchUpInside += ToolbarBackbutton_TouchUpInside;
            parent.toolbarBackbutton.Font = parent.highFont;
            parent.toolbarBackbutton.SetTitle("\ue708", UIControlState.Normal);
            parent.toolbarBackbutton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            parent.shapeAnnotationToolbar.Add(parent.toolbarBackbutton);
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                parent.rectangleAnnotationButton.Frame = new CGRect((240), 7, 35, 35);
            else
                parent.rectangleAnnotationButton.Frame = new CGRect((75), 7, 35, 35);
            parent.rectangleAnnotationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.rectangleAnnotationButton.TouchUpInside += RectangleAnnotationButton_TouchUpInside;
            parent.rectangleAnnotationButton.Font = parent.highFont;
            parent.rectangleAnnotationButton.SetTitle("\ue705", UIControlState.Normal);
            parent.rectangleAnnotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            parent.shapeAnnotationToolbar.Add(parent.rectangleAnnotationButton);
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                parent.circleAnnotationButton.Frame = new CGRect((parent.annotationToolbar.Frame.Width - 100) / 2, 7, 35, 35);
            else
                parent.circleAnnotationButton.Frame = new CGRect(145, 7, 35, 35);
            parent.circleAnnotationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.circleAnnotationButton.TouchUpInside += CircleAnnotationButton_TouchUpInside;
            parent.circleAnnotationButton.Font = parent.highFont;
            parent.circleAnnotationButton.SetTitle("\ue71f", UIControlState.Normal);
            parent.circleAnnotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            parent.shapeAnnotationToolbar.Add(parent.circleAnnotationButton);
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                parent.lineAnnotationButton.Frame = new CGRect((parent.annotationToolbar.Frame.Width + 100) / 2, 7, 35, 35);
            else
                parent.lineAnnotationButton.Frame = new CGRect(215, 7, 35, 35);
            parent.lineAnnotationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.lineAnnotationButton.TouchUpInside += LineAnnotationButton_TouchUpInside;
            parent.lineAnnotationButton.Font = parent.highFont;
            parent.lineAnnotationButton.SetTitle("\ue717", UIControlState.Normal);
            parent.lineAnnotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            parent.shapeAnnotationToolbar.Add(parent.lineAnnotationButton);
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                parent.arrowAnnotationButton.Frame = new CGRect((parent.annotationToolbar.Frame.Width - 250), 7, 35, 35);
            else
                parent.arrowAnnotationButton.Frame = new CGRect(275, 7, 35, 35);
            parent.arrowAnnotationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.arrowAnnotationButton.TouchUpInside += ArrowAnnotationButton_TouchUpInside;
            parent.arrowAnnotationButton.Font = parent.highFont;
            parent.arrowAnnotationButton.SetTitle("\ue712", UIControlState.Normal);
            parent.arrowAnnotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            parent.shapeAnnotationToolbar.Add(parent.arrowAnnotationButton);

            parent.shapeAnnotationToolbar = parent.UpdateToolbarBorder(parent.shapeAnnotationToolbar, parent.annotationFrame);
            parent.Add(parent.shapeAnnotationToolbar);
        }
        private void RectangleAnnotationButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.pdfViewerControl.AnnotationMode = AnnotationMode.Rectangle;
            parent.isOpacityNeeded = true;
            parent.shapeAnnotationToolbar.RemoveFromSuperview();
            parent.isAnnotationToolbarVisible = true;
            parent.shapeDeleteButton.RemoveFromSuperview();
            parent.shapeThicknessButton.RemoveFromSuperview();
            parent.shapeColorButton.RemoveFromSuperview();
            parent.rectangleToolbar = CreateSeparateAnnotationToolbar(parent.rectangleToolbar, parent.rectangleEnable, "\ue705", false, parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor);
            parent.Add(parent.rectangleToolbar);
        }
        private void CircleAnnotationButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.pdfViewerControl.AnnotationMode = AnnotationMode.Circle;
            parent.isOpacityNeeded = true;
            parent.shapeAnnotationToolbar.RemoveFromSuperview();
            parent.isAnnotationToolbarVisible = true;
            parent.shapeDeleteButton.RemoveFromSuperview();
            parent.shapeThicknessButton.RemoveFromSuperview();
            parent.shapeColorButton.RemoveFromSuperview();
            parent.circleToolbar = CreateSeparateAnnotationToolbar(parent.circleToolbar, parent.circleEnable, "\ue71f", false, parent.pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor);
            parent.Add(parent.circleToolbar);
        }
        private void LineAnnotationButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.pdfViewerControl.AnnotationMode = AnnotationMode.Line;
            parent.isOpacityNeeded = true;
            parent.shapeAnnotationToolbar.RemoveFromSuperview();
            parent.isAnnotationToolbarVisible = true;
            parent.shapeDeleteButton.RemoveFromSuperview();
            parent.shapeThicknessButton.RemoveFromSuperview();
            parent.shapeColorButton.RemoveFromSuperview();
            parent.lineToolbar = CreateSeparateAnnotationToolbar(parent.lineToolbar, parent.lineEnable, "\ue717", false, parent.pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor);
            parent.Add(parent.lineToolbar);
        }
        private void ArrowAnnotationButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.pdfViewerControl.AnnotationMode = AnnotationMode.Arrow;
            parent.isOpacityNeeded = true;
            parent.shapeAnnotationToolbar.RemoveFromSuperview();
            parent.isAnnotationToolbarVisible = true;
            parent.shapeDeleteButton.RemoveFromSuperview();
            parent.shapeThicknessButton.RemoveFromSuperview();
            parent.shapeColorButton.RemoveFromSuperview();
            parent.arrowToolbar = CreateSeparateAnnotationToolbar(parent.arrowToolbar, parent.arrowEnable, "\ue712", false, parent.pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor);
            parent.Add(parent.arrowToolbar);
        }
        internal UIView CreateSeparateAnnotationToolbar(UIView separateToolbar, UIButton enableLabel, string imageName, bool isSelected, UIColor colorButtonColor)
        {
            parent.isOpacityNeeded = true;
            parent.separateAnnotationFrame = parent.Frame;
            parent.separateAnnotationFrame.Height = DefaultToolbarHeight;
            parent.separateAnnotationFrame.Y = parent.parentView.Frame.Height - parent.separateAnnotationFrame.Height + 4;
            separateToolbar.Frame = parent.separateAnnotationFrame;
            separateToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);
            enableLabel.Frame = new CGRect(65, 7, 35, 35);
            enableLabel.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            enableLabel.Font = parent.highFont;
            enableLabel.SetTitle(imageName, UIControlState.Normal);
            enableLabel.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            separateToolbar.Add(enableLabel);
            parent.IsSelected = isSelected;
            if (!isSelected)
            {
                parent.textToolbarBackButton.Frame = new CGRect(parent.parentView.Frame.Width - 45, 7, 35, 35);
                parent.textToolbarBackButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                parent.textToolbarBackButton.TouchUpInside += ToolbarBackbutton_TouchUpInside;
                parent.textToolbarBackButton.Font = parent.highFont;
                parent.textToolbarBackButton.SetTitle("\ue715", UIControlState.Normal);
                parent.textToolbarBackButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
                separateToolbar.Add(parent.textToolbarBackButton);
                parent.shapeColorButton.Frame = new CGRect(parent.parentView.Frame.Width - 95, 7, 30, 30);
                parent.shapeThicknessButton.Frame = new CGRect(parent.parentView.Frame.Width - 155, 7, 30, 30);
            }
            else
            {
                parent.shapeDeleteButton.Frame = new CGRect(parent.parentView.Frame.Width - 45, 7, 35, 35);
                parent.shapeDeleteButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                parent.shapeDeleteButton.TouchUpInside += DeleteButton_TouchUpInside; ;
                parent.shapeDeleteButton.Font = parent.highFont;
                parent.shapeDeleteButton.SetTitle("\ue714", UIControlState.Normal);
                parent.shapeDeleteButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
                separateToolbar.Add(parent.shapeDeleteButton);
                parent.shapeColorButton.Frame = new CGRect(parent.parentView.Frame.Width - 95, 7, 30, 30);
                parent.shapeThicknessButton.Frame = new CGRect(parent.parentView.Frame.Width - 155, 7, 30, 30);
            }
            parent.shapeThicknessButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.shapeThicknessButton.Font = parent.highFont;
            parent.shapeThicknessButton.SetTitle("\ue722", UIControlState.Normal);
            parent.shapeThicknessButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            separateToolbar.Add(parent.shapeThicknessButton);
           
            parent.shapeColorButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            nfloat r, g, b, a;
            colorButtonColor.GetRGBA(out r, out g, out b, out a);
            UIColor color = new UIColor(r, g, b, (nfloat)1);
            parent.shapeColorButton.BackgroundColor = color;
            separateToolbar.Add(parent.shapeColorButton);
            separateToolbar = parent.UpdateToolbarBorder(separateToolbar, parent.separateAnnotationFrame);
            return separateToolbar;
        }
        private void ToolbarBackbutton_TouchUpInside(object sender, EventArgs e)
        {
            parent.pdfViewerControl.AnnotationMode = AnnotationMode.None;
            parent.isOpacityNeeded = false;
            parent.textAnnotationToolbar.RemoveFromSuperview();
            parent.colorToolbar.RemoveFromSuperview();
            parent.highlightToolbar.RemoveFromSuperview();
            parent.editStampAnnotationToolbar.RemoveFromSuperview();
            parent.strikeOutToolbar.RemoveFromSuperview();
            parent.underlineToolbar.RemoveFromSuperview();
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
            parent.isAnnotationToolbarVisible = false;
            parent.isColorSelected = false;
            parent.isThicknessTouched = false;
            parent.isOpacityNeeded = false;
            parent.Add(parent.shapeAnnotationToolbar);
            parent.isColorSelected = false;
            parent.opacityPanel.RemoveFromSuperview();
            parent.toolbarBackbutton.RemoveFromSuperview();
        }
        private void DeleteButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.pdfViewerControl.RemoveAnnotation(parent.annotation);
            parent.annotHelper.RemoveAllToolbars(false);
        }
    }
}