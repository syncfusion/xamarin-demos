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
    public class InkAnnotationHelper
    {
        CustomToolbar parent;
        TextMarkupAnnotationHelper textmarkupHelper;
        AnnotationHelper annotHelper;
        internal const float DefaultToolbarHeight = 50f;
        CGColor separatorgray = UIColor.FromRGBA(red: 0.86f, green: 0.86f, blue: 0.86f, alpha: 1.0f).CGColor;
        public InkAnnotationHelper(CustomToolbar customtoolbar)
        {
            parent = customtoolbar;
        }
        public InkAnnotationHelper(TextMarkupAnnotationHelper helper, CustomToolbar customtoolbar)
        {
            textmarkupHelper = helper;
            parent = customtoolbar;
        }
        public InkAnnotationHelper(AnnotationHelper annottoolbar, CustomToolbar customtoolbar)
        {
            annotHelper = annottoolbar;
            parent = customtoolbar;
        }
        internal void PdfViewerControl_InkSelected(object sender, InkSelectedEventArgs args)
        {
			if (!args.IsSignature)
				parent.annotation = sender as InkAnnotation;
			else
				parent.annotation = sender as HandwrittenSignature;
            if (parent.inkAnnotationToolbar != null)
            {
                parent.inkAnnotationToolbar.RemoveFromSuperview();
            }
            parent.annotationFrame = parent.Frame;
            parent.annotationFrame.Height = DefaultToolbarHeight;
            parent.annotationFrame.Y = parent.parentView.Frame.Height - parent.annotationFrame.Height + 4;
            parent.inkAnnotationToolbar.Frame = parent.annotationFrame;
            parent.inkAnnotationToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);

            parent.toolbarBackbutton.Frame = new CGRect(15, 7, 35, 35);
            parent.toolbarBackbutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.toolbarBackbutton.TouchUpInside += parent.ToolbarBackbutton_TouchUpInside;
            parent.toolbarBackbutton.Font = parent.highFont;
            parent.toolbarBackbutton.SetTitle("\ue708", UIControlState.Normal);
            parent.toolbarBackbutton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            parent.inkAnnotationToolbar.Add(parent.toolbarBackbutton);

            parent.inkButton.Frame = new CGRect(65, 7, 35, 35);
            parent.inkButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.inkButton.Font = parent.highFont;
            parent.inkButton.SetTitle("\ue704", UIControlState.Normal);
            parent.inkButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            parent.inkAnnotationToolbar.Add(parent.inkButton);

            parent.inkThicknessButton.Frame = new CGRect(parent.parentView.Frame.Width - 55, 7, 30, 30);
            parent.inkThicknessButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.inkThicknessButton.Font = parent.highFont;
            parent.inkThicknessButton.SetTitle("\ue722", UIControlState.Normal);
            parent.inkThicknessButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);

            parent.inkAnnotationToolbar.Add(parent.inkThicknessButton);

            parent.inkColorButton.Frame = new CGRect(parent.parentView.Frame.Width - 100, 7, 30, 30);
            parent.inkColorButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			if (!args.IsSignature)
				parent.inkColorButton.BackgroundColor = (sender as InkAnnotation).Settings.Color;
			else
				parent.inkColorButton.BackgroundColor = (sender as HandwrittenSignature).Settings.Color;
            parent.inkAnnotationToolbar.Add(parent.inkColorButton);
            if (parent.annotation != null)
            {
                parent.toolbarBackbutton.RemoveFromSuperview();
                parent.isOpacityNeeded = true;
                parent.inkThicknessButton.Frame = new CGRect(parent.parentView.Frame.Width - 100, 7, 35, 35);
                parent.inkAnnotationToolbar.Add(parent.inkThicknessButton);
                parent.inkColorButton.Frame = new CGRect(parent.parentView.Frame.Width - 150, 7, 35, 35);
                parent.inkAnnotationToolbar.Add(parent.inkColorButton);
                parent.inkdeleteButton.Frame = new CGRect(parent.parentView.Frame.Width - 55, 7, 35, 35);
                parent.inkdeleteButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                parent.inkdeleteButton.TouchUpInside += InkdeleteButton_TouchUpInside;
                parent.inkdeleteButton.Font = parent.highFont;
                parent.inkdeleteButton.SetTitle("\ue714", UIControlState.Normal);
                parent.inkdeleteButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
                parent.inkAnnotationToolbar.Add(parent.inkdeleteButton);
            }
            parent.inkAnnotationToolbar = parent.UpdateToolbarBorder(parent.inkAnnotationToolbar, parent.annotationFrame);
            parent.Add(parent.inkAnnotationToolbar);
        }
        internal void PdfViewerControl_InkDeselected(object sender, InkDeselectedEventArgs args)
        {
            parent.annotation = null;
            parent.inkAnnotationToolbar.RemoveFromSuperview();
            parent.inkdeleteButton.RemoveFromSuperview();
            parent.inkAnnotationToolbar.RemoveFromSuperview();
            parent.thicknessToolbar.RemoveFromSuperview();
            parent.colorToolbar.RemoveFromSuperview();
            parent.opacityPanel.RemoveFromSuperview();
            parent.isOpacityNeeded = false;
        }
        internal void PdfViewerControl_CanUndoInkModified(object sender, CanUndoInkModifiedEventArgs args)
        {
            if (args.CanUndoInk)
            {
                parent.inkUndoButton.SetTitle("\ue70a", UIControlState.Normal);
                parent.inkUndoButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            }
            else
            {
                parent.inkUndoButton.SetTitle("\ue70a", UIControlState.Normal);
                parent.inkUndoButton.SetTitleColor(UIColor.LightGray, UIControlState.Normal);
            }
        }
        internal void PdfViewerControl_CanRedoInkModified(object sender, CanRedoInkModifiedEventArgs args)
        {
            if (args.CanRedoInk)
            {
                parent.inkRedoButton.SetTitle("\ue716", UIControlState.Normal);
                parent.inkRedoButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            }
            else
            {
                parent.inkRedoButton.SetTitle("\ue716", UIControlState.Normal);
                parent.inkRedoButton.SetTitleColor(UIColor.LightGray, UIControlState.Normal);
            }
        }
        internal void InkdeleteButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.pdfViewerControl.RemoveAnnotation(parent.annotation);
            parent.annotHelper.RemoveAllToolbars(false);
        }
        internal void InkUndoButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.pdfViewerControl.UndoInk();
        }
        internal void InkRedoButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.pdfViewerControl.RedoInk();
        }
        internal void InkConfirmButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.pdfViewerControl.EndInkSession(true);
            parent.pdfViewerControl.AnnotationMode = AnnotationMode.None;
            parent.annotHelper.RemoveAllToolbars(false);
            parent.Add(parent.annotationToolbar);
        }
        internal void InkAnnotationButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.pdfViewerControl.AnnotationMode = AnnotationMode.Ink;
            parent.isOpacityNeeded = true;
            parent.annotationFrame = parent.Frame;
            parent.annotationFrame.Height = DefaultToolbarHeight;
            parent.annotationFrame.Y = parent.parentView.Frame.Height - parent.annotationFrame.Height + 4;
            parent.inkAnnotationToolbar.Frame = parent.annotationFrame;
            parent.inkAnnotationToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);

            parent.toolbarBackbutton.Frame = new CGRect(15, 7, 35, 35);
            parent.toolbarBackbutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.toolbarBackbutton.TouchUpInside += parent.ToolbarBackbutton_TouchUpInside;
            parent.toolbarBackbutton.Font = parent.highFont;
            parent.toolbarBackbutton.SetTitle("\ue708", UIControlState.Normal);
            parent.toolbarBackbutton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            parent.inkAnnotationToolbar.Add(parent.toolbarBackbutton);

            parent.inkButton.Frame = new CGRect(65, 7, 35, 35);
            parent.inkButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.inkButton.Font = parent.highFont;
            parent.inkButton.SetTitle("\ue704", UIControlState.Normal);
            parent.inkButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            parent.inkAnnotationToolbar.Add(parent.inkButton);

            parent.inkThicknessButton.Frame = new CGRect(parent.parentView.Frame.Width - 55, 7, 30, 30);
            parent.inkThicknessButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.inkThicknessButton.Font = parent.highFont;
            parent.inkThicknessButton.SetTitle("\ue722", UIControlState.Normal);
            parent.inkThicknessButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
           
            parent.inkAnnotationToolbar.Add(parent.inkThicknessButton);

            parent.inkColorButton.Frame = new CGRect(parent.parentView.Frame.Width - 100, 7, 30, 30);
            parent.inkColorButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.inkColorButton.BackgroundColor = parent.pdfViewerControl.AnnotationSettings.Ink.Color;
            parent.inkAnnotationToolbar.Add(parent.inkColorButton);

            CreateInkSessionToolbar();
            parent.inkAnnotationToolbar = parent.UpdateToolbarBorder(parent.inkAnnotationToolbar, parent.annotationFrame);
            parent.Add(parent.inkAnnotationToolbar);
        }
        internal void CreateInkSessionToolbar()
        {
            parent.toolBarFrame = parent.Frame;
            parent.toolBarFrame.Height = DefaultToolbarHeight;
            parent.toolBarFrame.Y = 0;
            parent.inkAnnotationSessionToolbar.Frame = parent.toolBarFrame;
            parent.inkAnnotationSessionToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);
            parent.inkAnnotationSessionToolbar.AutoresizingMask = UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleWidth;

            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                parent.inkUndoButton.Frame = new CGRect(parent.parentView.Frame.Width / 2 - 25, 7, 35, 35);
            else
                parent.inkUndoButton.Frame = new CGRect(130, 7, 35, 35);
            parent.inkUndoButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.inkUndoButton.TouchUpInside += InkUndoButton_TouchUpInside; ; ;
            parent.inkUndoButton.Font = parent.highFont;
            parent.inkUndoButton.SetTitle("\ue70a", UIControlState.Normal);
            parent.inkUndoButton.SetTitleColor(UIColor.LightGray, UIControlState.Normal);
            parent.inkAnnotationSessionToolbar.Add(parent.inkUndoButton);

            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                parent.inkRedoButton.Frame = new CGRect(parent.parentView.Frame.Width / 2 + 10, 7, 35, 35);
            else
                parent.inkRedoButton.Frame = new CGRect(175, 7, 35, 35);
            parent.inkRedoButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.inkRedoButton.TouchUpInside += InkRedoButton_TouchUpInside;
            parent.inkRedoButton.Font = parent.highFont;
            parent.inkRedoButton.SetTitle("\ue716", UIControlState.Normal);
            parent.inkRedoButton.SetTitleColor(UIColor.LightGray, UIControlState.Normal);
            parent.inkAnnotationSessionToolbar.Add(parent.inkRedoButton);

            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                parent.inkConfirmButton.Frame = new CGRect(parent.parentView.Frame.Width - 50, 7, 35, 35);
            else
                parent.inkConfirmButton.Frame = new CGRect(parent.parentView.Frame.Width - 50, 7, 35, 35);
            parent.inkConfirmButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.inkConfirmButton.TouchUpInside += InkConfirmButton_TouchUpInside;
            parent.inkConfirmButton.Font = parent.highFont;
            parent.inkConfirmButton.SetTitle("\ue715", UIControlState.Normal);
            parent.inkConfirmButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            parent.inkAnnotationSessionToolbar.Add(parent.inkConfirmButton);

            parent.Add(parent.inkAnnotationSessionToolbar);
        }
        internal void InkThicknessButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.isColorSelected = false;
            parent.opacityPanel.RemoveFromSuperview();
            parent.colorToolbar.RemoveFromSuperview();
            parent.thicknessBar.RemoveFromSuperview();
            parent.sliderValue.RemoveFromSuperview();
            if (!parent.isThicknessTouched)
            {
                parent.opacityFrame = parent.Frame;
                parent.opacityFrame.Height = DefaultToolbarHeight;
                parent.opacityFrame.Y = parent.parentView.Frame.Height - (DefaultToolbarHeight + parent.opacityFrame.Height - 4);
                parent.thicknessToolbar.Frame = parent.opacityFrame;
                parent.thicknessToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);
                ThicknessView();
                parent.isThicknessTouched = true;
            }
            else
            {
                parent.thicknessToolbar.RemoveFromSuperview();
                parent.isThicknessTouched = false;
            }
        }
        internal void ThicknessBar_TouchUpInside(object sender, EventArgs e)
        {
            int value = (int)(sender as UISlider).Value;
			if (parent.annotation != null)
			{
				if (parent.annotation is InkAnnotation)
					(parent.annotation as InkAnnotation).Settings.Thickness = value;
				else if (parent.annotation is HandwrittenSignature)
					(parent.annotation as HandwrittenSignature).Settings.Thickness = value;
			}
			else
			{
				parent.pdfViewerControl.AnnotationSettings.HandwrittenSignature.Thickness = value;
				parent.pdfViewerControl.AnnotationSettings.Ink.Thickness = value;
			}
            if (parent.annotation != null && parent.annotation is ShapeAnnotation)
            {
                (parent.annotation as ShapeAnnotation).Settings.Thickness = value;
            }
            parent.sliderValue.Text = value.ToString();
        }
        internal void OpacitySlider_TouchUpInside(object sender, EventArgs e)
        {
            float value = (sender as UISlider).Value;
            if (parent.annotation != null)
            {
				if (parent.annotation is ShapeAnnotation)
				{
					(parent.annotation as ShapeAnnotation).Settings.Opacity = value;
				}
				else if (parent.annotation is InkAnnotation)
					(parent.annotation as InkAnnotation).Settings.Opacity = value;
				else if (parent.annotation is HandwrittenSignature)
					(parent.annotation as HandwrittenSignature).Settings.Opacity = value;
            }
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                parent.pdfViewerControl.AnnotationSettings.Ink.Opacity = value;
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                parent.pdfViewerControl.AnnotationSettings.Circle.Settings.Opacity = value;
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.Opacity = value;
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                parent.pdfViewerControl.AnnotationSettings.Line.Settings.Opacity = value;
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                parent.pdfViewerControl.AnnotationSettings.Arrow.Settings.Opacity = value;
			else if(parent.pdfViewerControl.AnnotationMode == AnnotationMode.HandwrittenSignature)
				parent.pdfViewerControl.AnnotationSettings.HandwrittenSignature.Opacity = value;
            parent.opacitySliderValue.Text = ((int)(value * 100)).ToString() + "%";
        }
        internal void OpacitySlider_TouchUpOutside(object sender, EventArgs e)
        {
            float value = (sender as UISlider).Value;
            if (parent.annotation != null)
            {
				if (parent.annotation is ShapeAnnotation)
				{
					(parent.annotation as ShapeAnnotation).Settings.Opacity = value;
				}
				else if (parent.annotation is InkAnnotation)
					(parent.annotation as InkAnnotation).Settings.Opacity = value;
				else if (parent.annotation is HandwrittenSignature)
					(parent.annotation as HandwrittenSignature).Settings.Opacity = value;
            }
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                parent.pdfViewerControl.AnnotationSettings.Ink.Opacity = value;
			else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.HandwrittenSignature)
				parent.pdfViewerControl.AnnotationSettings.HandwrittenSignature.Opacity = value;
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                parent.pdfViewerControl.AnnotationSettings.Circle.Settings.Opacity = value;
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.Opacity = value;
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                parent.pdfViewerControl.AnnotationSettings.Line.Settings.Opacity = value;
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                parent.pdfViewerControl.AnnotationSettings.Arrow.Settings.Opacity = value;

            parent.opacitySliderValue.Text = ((int)(value * 100)).ToString() + "%";
        }
        internal void ThicknessView()
        {
            parent.AutoresizingMask = UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleWidth;
            parent.BoldBtn1.AutoresizingMask = UIViewAutoresizing.All;
            parent.BoldBtn2.AutoresizingMask = UIViewAutoresizing.All;
            parent.BoldBtn3.AutoresizingMask = UIViewAutoresizing.All;
            parent.BoldBtn4.AutoresizingMask = UIViewAutoresizing.All;
            parent.BoldBtn5.AutoresizingMask = UIViewAutoresizing.All;
            parent.BoldColorBtn1.AutoresizingMask = UIViewAutoresizing.All;
            parent.BoldColorBtn2.AutoresizingMask = UIViewAutoresizing.All;
            parent.BoldColorBtn3.AutoresizingMask = UIViewAutoresizing.All;
            parent.BoldColorBtn4.AutoresizingMask = UIViewAutoresizing.All;
            parent.BoldColorBtn5.AutoresizingMask = UIViewAutoresizing.All;
            CreateThicknessToolbar();
        }
        internal void BoldColorBtn1_TouchUpInside(object sender, EventArgs e)
        {
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                parent.pdfViewerControl.AnnotationSettings.Ink.Thickness = 1;
            }
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
            {
                parent.pdfViewerControl.AnnotationSettings.FreeText.TextSize = 4;
            }
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line ||
                parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
            {
                if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                {
                    parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.Thickness = 1;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                {
                    parent.pdfViewerControl.AnnotationSettings.Circle.Settings.Thickness = 1;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                {
                    parent.pdfViewerControl.AnnotationSettings.Line.Settings.Thickness = 1;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                {
                    parent.pdfViewerControl.AnnotationSettings.Arrow.Settings.Thickness = 1;
                }
            }
            if (parent.annotation != null)
            {
                if (parent.annotation is InkAnnotation)
                    (parent.annotation as InkAnnotation).Settings.Thickness = 1;
				else if (parent.annotation is HandwrittenSignature)
					(parent.annotation as HandwrittenSignature).Settings.Thickness = 1;
                else if (parent.annotation is FreeTextAnnotation)
                {
                    (parent.annotation as FreeTextAnnotation).Settings.TextSize = 4;
                }
                else if (parent.annotation is ShapeAnnotation)
                {
                    (parent.annotation as ShapeAnnotation).Settings.Thickness = 1;
                }
            }
            parent.thicknessToolbar.RemoveFromSuperview();
            parent.isThicknessTouched = false;
        }
        internal void BoldColorBtn2_TouchUpInside(object sender, EventArgs e)
        {
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                parent.pdfViewerControl.AnnotationSettings.Ink.Thickness = 2;
            }
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
            {
                parent.pdfViewerControl.AnnotationSettings.FreeText.TextSize = 8;
            }
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line ||
                parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
            {
                if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                {
                    parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.Thickness = 2;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                {
                    parent.pdfViewerControl.AnnotationSettings.Circle.Settings.Thickness = 2;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                {
                    parent.pdfViewerControl.AnnotationSettings.Line.Settings.Thickness = 2;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                {
                    parent.pdfViewerControl.AnnotationSettings.Arrow.Settings.Thickness = 2;
                }
            }
            if (parent.annotation != null)
            {
                if (parent.annotation is InkAnnotation)
                    (parent.annotation as InkAnnotation).Settings.Thickness = 2;
				else if (parent.annotation is HandwrittenSignature)
					(parent.annotation as HandwrittenSignature).Settings.Thickness = 2;
                else if (parent.annotation is FreeTextAnnotation)
                {
                    (parent.annotation as FreeTextAnnotation).Settings.TextSize = 8;
                }
                else if (parent.annotation is ShapeAnnotation)
                {
                    (parent.annotation as ShapeAnnotation).Settings.Thickness = 2;
                }
            }
            parent.thicknessToolbar.RemoveFromSuperview();
            parent.isThicknessTouched = false;
        }

        internal void BoldColorBtn3_TouchUpInside(object sender, EventArgs e)
        {
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                parent.pdfViewerControl.AnnotationSettings.Ink.Thickness = 4;
            }
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
            {
                parent.pdfViewerControl.AnnotationSettings.FreeText.TextSize = 12;
            }
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line ||
                parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
            {
                if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                {
                    parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.Thickness = 4;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                {
                    parent.pdfViewerControl.AnnotationSettings.Circle.Settings.Thickness = 4;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                {
                    parent.pdfViewerControl.AnnotationSettings.Line.Settings.Thickness = 4;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                {
                    parent.pdfViewerControl.AnnotationSettings.Arrow.Settings.Thickness = 4;
                }
            }
            if (parent.annotation != null)
            {
                if (parent.annotation is InkAnnotation)
                    (parent.annotation as InkAnnotation).Settings.Thickness = 4;
				else if (parent.annotation is HandwrittenSignature)
					(parent.annotation as HandwrittenSignature).Settings.Thickness = 4;
				
                else if (parent.annotation is FreeTextAnnotation)
                {
                    (parent.annotation as FreeTextAnnotation).Settings.TextSize = 12;
                }
                else if (parent.annotation is ShapeAnnotation)
                {
                    (parent.annotation as ShapeAnnotation).Settings.Thickness = 4;
                }
            }
            parent.thicknessToolbar.RemoveFromSuperview();
            parent.isThicknessTouched = false;
        }
        internal void BoldColorBtn4_TouchUpInside(object sender, EventArgs e)
        {
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                parent.pdfViewerControl.AnnotationSettings.Ink.Thickness = 6;
            }
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
            {
                parent.pdfViewerControl.AnnotationSettings.FreeText.TextSize = 16;
            }
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line ||
                parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
            {
                if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                {
                    parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.Thickness = 6;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                {
                    parent.pdfViewerControl.AnnotationSettings.Circle.Settings.Thickness = 6;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                {
                    parent.pdfViewerControl.AnnotationSettings.Line.Settings.Thickness = 6;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                {
                    parent.pdfViewerControl.AnnotationSettings.Arrow.Settings.Thickness = 6;
                }
            }
            if (parent.annotation != null)
            {
                if (parent.annotation is InkAnnotation)
                    (parent.annotation as InkAnnotation).Settings.Thickness = 6;
				else if (parent.annotation is HandwrittenSignature)
					(parent.annotation as HandwrittenSignature).Settings.Thickness = 6;
                else if (parent.annotation is FreeTextAnnotation)
                {
                    (parent.annotation as FreeTextAnnotation).Settings.TextSize = 16;
                }
                else if (parent.annotation is ShapeAnnotation)
                {
                    (parent.annotation as ShapeAnnotation).Settings.Thickness = 6;
                }
            }
            parent.thicknessToolbar.RemoveFromSuperview();
            parent.isThicknessTouched = false;
        }
        internal void BoldColorBtn5_TouchUpInside(object sender, EventArgs e)
        {
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                parent.pdfViewerControl.AnnotationSettings.Ink.Thickness = 10;
            }
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
            {
                parent.pdfViewerControl.AnnotationSettings.FreeText.TextSize = 20;
            }
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line ||
                parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
            {

                if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                {
                    parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.Thickness = 8;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                {
                    parent.pdfViewerControl.AnnotationSettings.Circle.Settings.Thickness = 8;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                {
                    parent.pdfViewerControl.AnnotationSettings.Line.Settings.Thickness = 8;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                {
                    parent.pdfViewerControl.AnnotationSettings.Arrow.Settings.Thickness = 8;
                }
            }
            if (parent.annotation != null)
            {
                if (parent.annotation is InkAnnotation)
                    (parent.annotation as InkAnnotation).Settings.Thickness = 10;
				else if (parent.annotation is InkAnnotation)
                    (parent.annotation as InkAnnotation).Settings.Thickness = 4;
                else if (parent.annotation is FreeTextAnnotation)
                {
                    (parent.annotation as FreeTextAnnotation).Settings.TextSize = 20;
                }
                else if (parent.annotation is ShapeAnnotation)
                {
                    (parent.annotation as ShapeAnnotation).Settings.Thickness = 10;
                }
            }
            parent.thicknessToolbar.RemoveFromSuperview();
            parent.isThicknessTouched = false;
        }
        internal void CreateThicknessToolbar()
        {
            float x = 0;
            x = (float)(parent.Frame.Width - 310) / 2;
            parent.AutoresizingMask = UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleWidth;
            parent.BoldBtn1.Frame = new CGRect(x, 7, 54, 30);
            parent.BoldBtn1.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.BoldBtn1.BackgroundColor = UIColor.White;
            parent.BoldBtn1.Layer.BorderWidth = 1;
            parent.BoldBtn1.Layer.BorderColor = separatorgray;
            parent.thicknessToolbar.AddSubview(parent.BoldBtn1);
            parent.BoldColorBtn1.Frame = new CGRect((x + 9), 21, 36, 1);
            if (parent.annotation != null)
            {
                if (parent.annotation is InkAnnotation)
                    parent.BoldColorBtn1.BackgroundColor = (parent.annotation as InkAnnotation).Settings.Color;
				else if (parent.annotation is HandwrittenSignature)
					parent.BoldColorBtn1.BackgroundColor = (parent.annotation as HandwrittenSignature).Settings.Color;
                else if (parent.annotation is FreeTextAnnotation)
                {
                    parent.BoldColorBtn1.BackgroundColor = (parent.annotation as FreeTextAnnotation).Settings.TextColor;
                }
                else if (parent.annotation is ShapeAnnotation)
                {
                    if (parent.shapeView == AnnotationMode.Arrow)
                    {
                        nfloat r, g, b, a;
                        parent.pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                        UIColor color = new UIColor(r, g, b, (nfloat)1);
                        parent.BoldColorBtn1.BackgroundColor = color;
                    }
                    else if (parent.shapeView == AnnotationMode.Rectangle)
                    {
                        nfloat r, g, b, a;
                        parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                        UIColor color = new UIColor(r, g, b, (nfloat)1);
                        parent.BoldColorBtn1.BackgroundColor = color;
                    }
                    else if (parent.shapeView == AnnotationMode.Circle)
                    {
                        nfloat r, g, b, a;
                        parent.pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                        UIColor color = new UIColor(r, g, b, (nfloat)1);
                        parent.BoldColorBtn1.BackgroundColor = color;
                    }
                    else if (parent.shapeView == AnnotationMode.Line)
                    {
                        nfloat r, g, b, a;
                        parent.pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                        UIColor color = new UIColor(r, g, b, (nfloat)1);
                        parent.BoldColorBtn1.BackgroundColor = color;
                    }
                }
            }
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                parent.BoldColorBtn1.BackgroundColor = parent.pdfViewerControl.AnnotationSettings.Ink.Color;
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
            {
                parent.BoldColorBtn1.BackgroundColor = parent.pdfViewerControl.AnnotationSettings.FreeText.TextColor;
            }
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line ||
                 parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
            {
                if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                {
                    nfloat r, g, b, a;
                    parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                    UIColor color = new UIColor(r, g, b, (nfloat)1);
                    parent.BoldColorBtn1.BackgroundColor = color;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                {
                    nfloat r, g, b, a;
                    parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                    UIColor color = new UIColor(r, g, b, (nfloat)1);
                    parent.BoldColorBtn1.BackgroundColor = color;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                {
                    nfloat r, g, b, a;
                    parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                    UIColor color = new UIColor(r, g, b, (nfloat)1);
                    parent.BoldColorBtn1.BackgroundColor = color;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                {
                    nfloat r, g, b, a;
                    parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                    UIColor color = new UIColor(r, g, b, (nfloat)1);
                    parent.BoldColorBtn1.BackgroundColor = color;
                }
            }
            parent.BoldColorBtn1.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.thicknessToolbar.AddSubview(parent.BoldColorBtn1);
            parent.BoldBtn2.Frame = new CGRect((x + 64), 7, 54, 30);
            parent.BoldBtn2.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.BoldBtn2.BackgroundColor = UIColor.White;
            parent.BoldBtn2.Layer.BorderWidth = 1;
            parent.BoldBtn2.Layer.BorderColor = separatorgray;
            parent.thicknessToolbar.AddSubview(parent.BoldBtn2);
            parent.BoldColorBtn2.Frame = new CGRect((x + 73), 21, 36, 2);
            if (parent.annotation != null)
            {
                if (parent.annotation is InkAnnotation)
                    parent.BoldColorBtn2.BackgroundColor = (parent.annotation as InkAnnotation).Settings.Color;
				else if (parent.annotation is HandwrittenSignature)
					parent.BoldColorBtn2.BackgroundColor = (parent.annotation as HandwrittenSignature).Settings.Color;
                else if (parent.annotation is FreeTextAnnotation)
                {
                    parent.BoldColorBtn2.BackgroundColor = (parent.annotation as FreeTextAnnotation).Settings.TextColor;
                }
                else if (parent.annotation is ShapeAnnotation)
                {
                    if (parent.shapeView == AnnotationMode.Arrow)
                    {
                        nfloat r, g, b, a;
                        parent.pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                        UIColor color = new UIColor(r, g, b, (nfloat)1);
                        parent.BoldColorBtn2.BackgroundColor = color;
                    }
                    else if (parent.shapeView == AnnotationMode.Rectangle)
                    {
                        nfloat r, g, b, a;
                        parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                        UIColor color = new UIColor(r, g, b, (nfloat)1);
                        parent.BoldColorBtn2.BackgroundColor = color;
                    }
                    else if (parent.shapeView == AnnotationMode.Circle)
                    {
                        nfloat r, g, b, a;
                        parent.pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                        UIColor color = new UIColor(r, g, b, (nfloat)1);
                        parent.BoldColorBtn2.BackgroundColor = color;
                    }
                    else if (parent.shapeView == AnnotationMode.Line)
                    {
                        nfloat r, g, b, a;
                        parent.pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                        UIColor color = new UIColor(r, g, b, (nfloat)1);
                        parent.BoldColorBtn2.BackgroundColor = color;
                    }
                }
            }
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                parent.BoldColorBtn2.BackgroundColor = parent.pdfViewerControl.AnnotationSettings.Ink.Color;
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
            {
                parent.BoldColorBtn2.BackgroundColor = parent.pdfViewerControl.AnnotationSettings.FreeText.TextColor;
            }
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line ||
                 parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
            {
                if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                {
                    parent.BoldColorBtn2.BackgroundColor = parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                {
                    parent.BoldColorBtn2.BackgroundColor = parent.pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                {
                    parent.BoldColorBtn2.BackgroundColor = parent.pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                {
                    parent.BoldColorBtn2.BackgroundColor = parent.pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor;
                }
            }
            parent.BoldColorBtn2.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.thicknessToolbar.AddSubview(parent.BoldColorBtn2);
            parent.BoldBtn3.Frame = new CGRect((x + 128), 7, 54, 30);
            parent.BoldBtn3.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.BoldBtn3.BackgroundColor = UIColor.White;
            parent.BoldBtn3.Layer.BorderWidth = 1;
            parent.BoldBtn3.Layer.BorderColor = separatorgray;
            parent.thicknessToolbar.AddSubview(parent.BoldBtn3);
            parent.BoldColorBtn3.Frame = new CGRect((x + 137), 20, 36, 4);
            if (parent.annotation != null)
            {
                if (parent.annotation is InkAnnotation)
                    parent.BoldColorBtn3.BackgroundColor = (parent.annotation as InkAnnotation).Settings.Color;
				else if (parent.annotation is HandwrittenSignature)
					parent.BoldColorBtn3.BackgroundColor = (parent.annotation as HandwrittenSignature).Settings.Color;
                else if (parent.annotation is FreeTextAnnotation)
                {
                    parent.BoldColorBtn3.BackgroundColor = (parent.annotation as FreeTextAnnotation).Settings.TextColor;
                }
                else if (parent.annotation is ShapeAnnotation)
                {
                    if (parent.shapeView == AnnotationMode.Arrow)
                    {
                        nfloat r, g, b, a;
                        parent.pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                        UIColor color = new UIColor(r, g, b, (nfloat)1);
                        parent.BoldColorBtn3.BackgroundColor = color;
                    }
                    else if (parent.shapeView == AnnotationMode.Rectangle)
                    {
                        nfloat r, g, b, a;
                        parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                        UIColor color = new UIColor(r, g, b, (nfloat)1);
                        parent.BoldColorBtn3.BackgroundColor = color;
                    }
                    else if (parent.shapeView == AnnotationMode.Circle)
                    {
                        nfloat r, g, b, a;
                        parent.pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                        UIColor color = new UIColor(r, g, b, (nfloat)1);
                        parent.BoldColorBtn3.BackgroundColor = color;
                    }
                    else if (parent.shapeView == AnnotationMode.Line)
                    {
                        nfloat r, g, b, a;
                        parent.pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                        UIColor color = new UIColor(r, g, b, (nfloat)1);
                        parent.BoldColorBtn3.BackgroundColor = color;
                    }
                }
            }
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                parent.BoldColorBtn3.BackgroundColor = parent.pdfViewerControl.AnnotationSettings.Ink.Color;
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
            {
                parent.BoldColorBtn3.BackgroundColor = parent.pdfViewerControl.AnnotationSettings.FreeText.TextColor;
            }
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line ||
                parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
            {
                if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                {
                    nfloat r, g, b, a;
                    parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                    UIColor color = new UIColor(r, g, b, (nfloat)1);
                    parent.BoldColorBtn3.BackgroundColor = color;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                {
                    nfloat r, g, b, a;
                    parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                    UIColor color = new UIColor(r, g, b, (nfloat)1);
                    parent.BoldColorBtn3.BackgroundColor = color;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                {
                    nfloat r, g, b, a;
                    parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                    UIColor color = new UIColor(r, g, b, (nfloat)1);
                    parent.BoldColorBtn3.BackgroundColor = color;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                {
                    nfloat r, g, b, a;
                    parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                    UIColor color = new UIColor(r, g, b, (nfloat)1);
                    parent.BoldColorBtn3.BackgroundColor = color;
                }
            }
            parent.BoldColorBtn3.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.thicknessToolbar.AddSubview(parent.BoldColorBtn3);
            parent.BoldBtn4.Frame = new CGRect((x + 192), 7, 54, 30);
            parent.BoldBtn4.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.BoldBtn4.BackgroundColor = UIColor.White;
            parent.BoldBtn4.Layer.BorderWidth = 1;
            parent.BoldBtn4.Layer.BorderColor = separatorgray;
            parent.thicknessToolbar.AddSubview(parent.BoldBtn4);
            parent.BoldColorBtn4.Frame = new CGRect((x + 201), 19, 36, 6);
            if (parent.annotation != null)
            {
                if (parent.annotation is InkAnnotation)
                    parent.BoldColorBtn4.BackgroundColor = (parent.annotation as InkAnnotation).Settings.Color;
				else if (parent.annotation is HandwrittenSignature)
					parent.BoldColorBtn4.BackgroundColor = (parent.annotation as HandwrittenSignature).Settings.Color;
                else if (parent.annotation is FreeTextAnnotation)
                {
                    parent.BoldColorBtn4.BackgroundColor = (parent.annotation as FreeTextAnnotation).Settings.TextColor;
                }
                else if (parent.annotation is ShapeAnnotation)
                {
                    if (parent.shapeView == AnnotationMode.Arrow)
                    {
                        nfloat r, g, b, a;
                        parent.pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                        UIColor color = new UIColor(r, g, b, (nfloat)1);
                        parent.BoldColorBtn4.BackgroundColor = color;
                    }
                    else if (parent.shapeView == AnnotationMode.Rectangle)
                    {
                        nfloat r, g, b, a;
                        parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                        UIColor color = new UIColor(r, g, b, (nfloat)1);
                        parent.BoldColorBtn4.BackgroundColor = color;
                    }
                    else if (parent.shapeView == AnnotationMode.Circle)
                    {
                        nfloat r, g, b, a;
                        parent.pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                        UIColor color = new UIColor(r, g, b, (nfloat)1);
                        parent.BoldColorBtn4.BackgroundColor = color;
                    }
                    else if (parent.shapeView == AnnotationMode.Line)
                    {

                        nfloat r, g, b, a;
                        parent.pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                        UIColor color = new UIColor(r, g, b, (nfloat)1);
                        parent.BoldColorBtn4.BackgroundColor = color;
                    }
                }
            }
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                parent.BoldColorBtn4.BackgroundColor = parent.pdfViewerControl.AnnotationSettings.Ink.Color;
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
            {
                parent.BoldColorBtn4.BackgroundColor = parent.pdfViewerControl.AnnotationSettings.FreeText.TextColor;
            }
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
            {
                nfloat r, g, b, a;
                parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                UIColor color = new UIColor(r, g, b, (nfloat)1);
                parent.BoldColorBtn4.BackgroundColor = color;
            }
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
            {
                nfloat r, g, b, a;
                parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                UIColor color = new UIColor(r, g, b, (nfloat)1);
                parent.BoldColorBtn4.BackgroundColor = color;
            }
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line)
            {
                nfloat r, g, b, a;
                parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                UIColor color = new UIColor(r, g, b, (nfloat)1);
                parent.BoldColorBtn4.BackgroundColor = color;
            }
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
            {
                nfloat r, g, b, a;
                parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                UIColor color = new UIColor(r, g, b, (nfloat)1);
                parent.BoldColorBtn4.BackgroundColor = color;
            }
            parent.BoldColorBtn4.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.thicknessToolbar.AddSubview(parent.BoldColorBtn4);

            parent.BoldBtn5.Frame = new CGRect((x + 256), 7, 54, 30);
            parent.BoldBtn5.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.BoldBtn5.BackgroundColor = UIColor.White;
            parent.BoldBtn5.Layer.BorderWidth = 1;
            parent.BoldBtn5.Layer.BorderColor = separatorgray;
            parent.thicknessToolbar.AddSubview(parent.BoldBtn5);

            if (parent.annotation != null)
            {
                if (parent.annotation is InkAnnotation)
                    parent.BoldColorBtn5.BackgroundColor = (parent.annotation as InkAnnotation).Settings.Color;
				else if (parent.annotation is HandwrittenSignature)
					parent.BoldColorBtn5.BackgroundColor = (parent.annotation as HandwrittenSignature).Settings.Color;
                else if (parent.annotation is FreeTextAnnotation)
                {
                    parent.BoldColorBtn5.BackgroundColor = (parent.annotation as FreeTextAnnotation).Settings.TextColor;
                }
                else if (parent.annotation is ShapeAnnotation)
                {
                    if (parent.shapeView == AnnotationMode.Arrow)
                    {
                        nfloat r, g, b, a;
                        parent.pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                        UIColor color = new UIColor(r, g, b, (nfloat)1);
                        parent.BoldColorBtn5.BackgroundColor = color;
                    }
                    else if (parent.shapeView == AnnotationMode.Rectangle)
                    {
                        nfloat r, g, b, a;
                        parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                        UIColor color = new UIColor(r, g, b, (nfloat)1);
                        parent.BoldColorBtn5.BackgroundColor = color;
                    }
                    else if (parent.shapeView == AnnotationMode.Circle)
                    {
                        nfloat r, g, b, a;
                        parent.pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                        UIColor color = new UIColor(r, g, b, (nfloat)1);
                        parent.BoldColorBtn5.BackgroundColor = color;
                    }
                    else if (parent.shapeView == AnnotationMode.Line)
                    {
                        nfloat r, g, b, a;
                        parent.pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                        UIColor color = new UIColor(r, g, b, (nfloat)1);
                        parent.BoldColorBtn5.BackgroundColor = color;
                    }
                }
            }
            if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                parent.BoldColorBtn5.BackgroundColor = parent.pdfViewerControl.AnnotationSettings.Ink.Color;
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
            {
                parent.BoldColorBtn5.BackgroundColor = parent.pdfViewerControl.AnnotationSettings.FreeText.TextColor;
            }
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
            {
                nfloat r, g, b, a;
                parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                UIColor color = new UIColor(r, g, b, (nfloat)1);
                parent.BoldColorBtn5.BackgroundColor = color;
            }
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
            {
                nfloat r, g, b, a;
                parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                UIColor color = new UIColor(r, g, b, (nfloat)1);
                parent.BoldColorBtn5.BackgroundColor = color;
            }
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line)
            {
                nfloat r, g, b, a;
                parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                UIColor color = new UIColor(r, g, b, (nfloat)1);
                parent.BoldColorBtn5.BackgroundColor = color;
            }
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
            {
                nfloat r, g, b, a;
                parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor.GetRGBA(out r, out g, out b, out a);
                UIColor color = new UIColor(r, g, b, (nfloat)1);
                parent.BoldColorBtn5.BackgroundColor = color;
            }
            parent.BoldColorBtn5.Frame = new CGRect((x + 265), 18, 36, 8);
            parent.BoldColorBtn5.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.thicknessToolbar.AddSubview(parent.BoldColorBtn5);
            parent.Add(parent.thicknessToolbar);
        }
        internal void Opacitybutton_TouchUpInside(object sender, EventArgs e)
        {
            parent.isThicknessTouched = false;
            parent.opacitySlider.RemoveFromSuperview();
            parent.opacitySliderValue.RemoveFromSuperview();
            parent.opacityFrame = parent.Frame;
            parent.opacityFrame.Height = DefaultToolbarHeight + 16;
            parent.opacityFrame.Y = parent.parentView.Frame.Height - (DefaultToolbarHeight + (parent.colorFrame.Height * 2) + 10);
            parent.opacityFrame.Width = parent.parentView.Frame.Width;
            parent.opacityPanel.Frame = parent.opacityFrame;
            parent.opacityPanel.BackgroundColor = UIColor.FromRGB(249, 249, 249);
            parent.opacitySlider = new UISlider();
            parent.opacitySlider.Frame = new CGRect(5, 0, parent.opacityFrame.Width - 54, parent.opacityFrame.Height);
            parent.opacitySlider.MinValue = 0;
            parent.opacitySlider.MaxValue = 1;
            parent.opacitySlider.Continuous = true;
            parent.opacityPanel.Add(parent.opacitySlider);
            if (parent.annotation != null)
            {
				if (parent.annotation is ShapeAnnotation)
				{
					parent.opacitySlider.Value = (float)(parent.annotation as ShapeAnnotation).Settings.Opacity;
				}
				else if (parent.annotation is InkAnnotation)
					parent.opacitySlider.Value = (parent.annotation as InkAnnotation).Settings.Opacity;
				else if (parent.annotation is HandwrittenSignature)
					parent.opacitySlider.Value = (parent.annotation as HandwrittenSignature).Settings.Opacity;
            }
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                parent.opacitySlider.Value = parent.pdfViewerControl.AnnotationSettings.Ink.Opacity;
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                parent.opacitySlider.Value = (float)parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.Opacity;
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                parent.opacitySlider.Value = (float)parent.pdfViewerControl.AnnotationSettings.Circle.Settings.Opacity;
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                parent.opacitySlider.Value = (float)parent.pdfViewerControl.AnnotationSettings.Line.Settings.Opacity;
            else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                parent.opacitySlider.Value = (float)parent.pdfViewerControl.AnnotationSettings.Arrow.Settings.Opacity;
            parent.opacitySlider.TouchUpInside += OpacitySlider_TouchUpInside;
            parent.opacitySlider.TouchUpOutside += OpacitySlider_TouchUpOutside;
            parent.opacitySliderValue = new UILabel();
            parent.opacitySliderValue.Frame = new CGRect(parent.opacityFrame.Width - 45, 0, 55, parent.opacityFrame.Height);
            parent.opacitySliderValue.Text = ((int)(parent.opacitySlider.Value * 100)).ToString() + "%";
            parent.opacityPanel.Add(parent.opacitySliderValue);
            parent.opacityPanel.Layer.BorderColor = new CGColor(0.2f, 0.2f);
            parent.opacityPanel.Layer.BorderWidth = 1;
            if (!parent.isOpacitySelected)
            {
                parent.Add(parent.opacityPanel);
                parent.isOpacitySelected = true;
            }
            else
            {
                parent.opacityPanel.RemoveFromSuperview();
                parent.isOpacitySelected = false;
            }
        }
    }
}
