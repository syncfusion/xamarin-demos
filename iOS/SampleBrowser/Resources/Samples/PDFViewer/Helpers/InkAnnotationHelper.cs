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
        CustomToolbar m_parent;
        TextMarkupAnnotationHelper m_textmarkupHelper;
        AnnotationHelper m_annotHelper;
        internal const float DefaultToolbarHeight = 50f;
        CGColor separatorgray = UIColor.FromRGBA(red: 0.86f, green: 0.86f, blue: 0.86f, alpha: 1.0f).CGColor;
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
        private TextMarkupAnnotationHelper TextmarkupHelper
        {
            get
            {
                return m_textmarkupHelper;
            }
            set
            {
                m_textmarkupHelper = value;
            }
        }

        private AnnotationHelper AnnotHelper
        {
            get
            {
                return m_annotHelper;
            }
            set
            {
                m_annotHelper = value;
            }
        }

        public InkAnnotationHelper(CustomToolbar customtoolbar)
        {
            Parent = customtoolbar;
        }

        public InkAnnotationHelper(TextMarkupAnnotationHelper helper, CustomToolbar customtoolbar)
        {
            TextmarkupHelper = helper;
            Parent = customtoolbar;
        }

        public InkAnnotationHelper(AnnotationHelper annottoolbar, CustomToolbar customtoolbar)
        {
            AnnotHelper = annottoolbar;
            Parent = customtoolbar;
        } 

        internal void PdfViewerControl_InkSelected(object sender, InkSelectedEventArgs args)
        {
            Parent.annotation = sender as InkAnnotation;
            if (Parent.annotation != null)
            {
                Parent.toolbarBackbutton.RemoveFromSuperview();
                Parent.isOpacityNeeded = true;
                Parent.inkThicknessButton.Frame = new CGRect(Parent.parentView.Frame.Width - 100, 7, 35, 35);
                Parent.inkAnnotationToolbar.Add(Parent.inkThicknessButton);
                Parent.inkColorButton.Frame = new CGRect(Parent.parentView.Frame.Width - 150, 7, 35, 35);
                Parent.inkAnnotationToolbar.Add(Parent.inkColorButton);
                Parent.inkdeleteButton.Frame = new CGRect(Parent.parentView.Frame.Width - 55, 7, 35, 35);
                Parent.inkdeleteButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                Parent.inkdeleteButton.TouchUpInside += InkdeleteButton_TouchUpInside;
                Parent.inkdeleteButton.Font = Parent.highFont;
                Parent.inkdeleteButton.SetTitle("\ue714", UIControlState.Normal);
                Parent.inkdeleteButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
                Parent.inkAnnotationToolbar.Add(Parent.inkdeleteButton);
            }
            Parent.Add(Parent.inkAnnotationToolbar);
        }

        internal void PdfViewerControl_InkDeselected(object sender, InkDeselectedEventArgs args)
        {
            Parent.annotation = null;
            Parent.inkThicknessButton.Frame = new CGRect(Parent.parentView.Frame.Width - 55, 7, 35, 35);
            Parent.inkAnnotationToolbar.Add(Parent.inkThicknessButton);
            Parent.inkColorButton.Frame = new CGRect(Parent.parentView.Frame.Width - 100, 7, 35, 35);
            Parent.inkAnnotationToolbar.Add(Parent.inkColorButton);
            Parent.inkdeleteButton.RemoveFromSuperview();
            Parent.inkAnnotationToolbar.RemoveFromSuperview();
            Parent.thicknessToolbar.RemoveFromSuperview();
            Parent.colorToolbar.RemoveFromSuperview();
            Parent.opacityPanel.RemoveFromSuperview();
            Parent.isOpacityNeeded = false;
        }

        internal void PdfViewerControl_CanUndoInkModified(object sender, CanUndoInkModifiedEventArgs args)
        {
            if (args.CanUndoInk)
            {
                Parent.inkUndoButton.SetTitle("\ue70a", UIControlState.Normal);
                Parent.inkUndoButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            }
            else
            {
                Parent.inkUndoButton.SetTitle("\ue70a", UIControlState.Normal);
                Parent.inkUndoButton.SetTitleColor(UIColor.LightGray, UIControlState.Normal);
            }
        }

        internal void PdfViewerControl_CanRedoInkModified(object sender, CanRedoInkModifiedEventArgs args)
        {
            if (args.CanRedoInk)
            {
                Parent.inkRedoButton.SetTitle("\ue716", UIControlState.Normal);
                Parent.inkRedoButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            }
            else
            {
                Parent.inkRedoButton.SetTitle("\ue716", UIControlState.Normal);
                Parent.inkRedoButton.SetTitleColor(UIColor.LightGray, UIControlState.Normal);
            }
        }
        internal void InkdeleteButton_TouchUpInside(object sender, EventArgs e)
        {
            Parent.pdfViewerControl.RemoveAnnotation(Parent.annotation);
            Parent.annotHelper.RemoveAllToolbars(false);
        } 

        internal void InkUndoButton_TouchUpInside(object sender, EventArgs e)
        {
            Parent.pdfViewerControl.UndoInk();
        }

        internal void InkRedoButton_TouchUpInside(object sender, EventArgs e)
        {
            Parent.pdfViewerControl.RedoInk();
        }

        internal void InkConfirmButton_TouchUpInside(object sender, EventArgs e)
        {
            Parent.pdfViewerControl.EndInkSession(true);
            Parent.pdfViewerControl.AnnotationMode = AnnotationMode.None;
            Parent.annotHelper.RemoveAllToolbars(false);
            Parent.Add(Parent.annotationToolbar);
        }

        internal void InkAnnotationButton_TouchUpInside(object sender, EventArgs e)
        {
            Parent.pdfViewerControl.AnnotationMode = AnnotationMode.Ink;
            Parent.isOpacityNeeded = true;
            Parent.annotationFrame = Parent.Frame;
            Parent.annotationFrame.Height = DefaultToolbarHeight;
            Parent.annotationFrame.Y = Parent.parentView.Frame.Height - Parent.annotationFrame.Height + 4;
            Parent.inkAnnotationToolbar.Frame = Parent.annotationFrame;
            Parent.inkAnnotationToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);

            Parent.toolbarBackbutton.Frame = new CGRect(15, 7, 35, 35);
            Parent.toolbarBackbutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.toolbarBackbutton.TouchUpInside += Parent.ToolbarBackbutton_TouchUpInside;
            Parent.toolbarBackbutton.Font = Parent.highFont;
            Parent.toolbarBackbutton.SetTitle("\ue708", UIControlState.Normal);
            Parent.toolbarBackbutton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            Parent.inkAnnotationToolbar.Add(Parent.toolbarBackbutton);

            Parent.inkButton.Frame = new CGRect(65, 7, 35, 35);
            Parent.inkButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.inkButton.Font = Parent.highFont;
            Parent.inkButton.SetTitle("\ue704", UIControlState.Normal);
            Parent.inkButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            Parent.inkAnnotationToolbar.Add(Parent.inkButton);

            Parent.inkThicknessButton.Frame = new CGRect(Parent.parentView.Frame.Width - 55, 7, 35, 35);
            Parent.inkThicknessButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.inkThicknessButton.Font = Parent.highFont;
            Parent.inkThicknessButton.SetTitle("\ue722", UIControlState.Normal);
            if (Parent.annotation != null)
                Parent.inkThicknessButton.SetTitleColor((Parent.annotation as InkAnnotation).Settings.Color, UIControlState.Normal);
            else
                Parent.inkThicknessButton.SetTitleColor(Parent.pdfViewerControl.AnnotationSettings.Ink.Color, UIControlState.Normal);
            Parent.inkAnnotationToolbar.Add(Parent.inkThicknessButton);

            Parent.inkColorButton.Frame = new CGRect(Parent.parentView.Frame.Width - 100, 7, 35, 35);
            Parent.inkColorButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.inkColorButton.BackgroundColor = Parent.pdfViewerControl.AnnotationSettings.Ink.Color;
            Parent.inkAnnotationToolbar.Add(Parent.inkColorButton);

            CreateInkSessionToolbar();
            Parent.inkAnnotationToolbar = Parent.UpdateToolbarBorder(Parent.inkAnnotationToolbar, Parent.annotationFrame);
            Parent.Add(Parent.inkAnnotationToolbar);

        }
              
        internal void CreateInkSessionToolbar()
        {
            Parent.toolBarFrame = Parent.Frame;
            Parent.toolBarFrame.Height = DefaultToolbarHeight;
            Parent.toolBarFrame.Y = 0;
            Parent.inkAnnotationSessionToolbar.Frame = Parent.toolBarFrame;
            Parent.inkAnnotationSessionToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);
            Parent.inkAnnotationSessionToolbar.AutoresizingMask = UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleWidth;

            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                Parent.inkUndoButton.Frame = new CGRect(Parent.parentView.Frame.Width / 2 - 25, 7, 35, 35);
            else
                Parent.inkUndoButton.Frame = new CGRect(130, 7, 35, 35);
            Parent.inkUndoButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.inkUndoButton.TouchUpInside += InkUndoButton_TouchUpInside; ; ;
            Parent.inkUndoButton.Font = Parent.highFont;
            Parent.inkUndoButton.SetTitle("\ue70a", UIControlState.Normal);
            Parent.inkUndoButton.SetTitleColor(UIColor.LightGray, UIControlState.Normal);
            Parent.inkAnnotationSessionToolbar.Add(Parent.inkUndoButton);

            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                Parent.inkRedoButton.Frame = new CGRect(Parent.parentView.Frame.Width / 2 + 10, 7, 35, 35);
            else
                Parent.inkRedoButton.Frame = new CGRect(175, 7, 35, 35);
            Parent.inkRedoButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.inkRedoButton.TouchUpInside += InkRedoButton_TouchUpInside;
            Parent.inkRedoButton.Font = Parent.highFont;
            Parent.inkRedoButton.SetTitle("\ue716", UIControlState.Normal);
            Parent.inkRedoButton.SetTitleColor(UIColor.LightGray, UIControlState.Normal);
            Parent.inkAnnotationSessionToolbar.Add(Parent.inkRedoButton);

            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                Parent.inkConfirmButton.Frame = new CGRect(Parent.parentView.Frame.Width - 50, 7, 35, 35);
            else
                Parent.inkConfirmButton.Frame = new CGRect(Parent.parentView.Frame.Width - 50, 7, 35, 35);
            Parent.inkConfirmButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.inkConfirmButton.TouchUpInside += InkConfirmButton_TouchUpInside;
            Parent.inkConfirmButton.Font = Parent.highFont;
            Parent.inkConfirmButton.SetTitle("\ue715", UIControlState.Normal);
            Parent.inkConfirmButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            Parent.inkAnnotationSessionToolbar.Add(Parent.inkConfirmButton);

            Parent.Add(Parent.inkAnnotationSessionToolbar);

        }
       
        internal void InkThicknessButton_TouchUpInside(object sender, EventArgs e)
        {
            Parent.isColorSelected = false;
            Parent.opacityPanel.RemoveFromSuperview();
            Parent.colorToolbar.RemoveFromSuperview();
            Parent.thicknessBar.RemoveFromSuperview();
            Parent.sliderValue.RemoveFromSuperview();
           
            if (!Parent.isThicknessTouched)
            {
                Parent.opacityFrame = Parent.Frame;
                Parent.opacityFrame.Height = DefaultToolbarHeight;
                Parent.opacityFrame.Y = Parent.parentView.Frame.Height - (DefaultToolbarHeight + Parent.opacityFrame.Height - 4);
                Parent.thicknessToolbar.Frame = Parent.opacityFrame;
                Parent.thicknessToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);
                ThicknessView();
                Parent.isThicknessTouched = true;
            }
            else
            {
                Parent.thicknessToolbar.RemoveFromSuperview();
                Parent.isThicknessTouched = false;
            }

        }

        internal void ThicknessBar_TouchUpInside(object sender, EventArgs e)
        {
            int value = (int)(sender as UISlider).Value;
            if (Parent.annotation != null)
                (Parent.annotation as InkAnnotation).Settings.Thickness = value;
            else
                Parent.pdfViewerControl.AnnotationSettings.Ink.Thickness = value;
            Parent.sliderValue.Text = value.ToString();
        }
        internal void OpacitySlider_TouchUpInside(object sender, EventArgs e)
        {
            float value = (sender as UISlider).Value;
            if (Parent.annotation != null)
                (Parent.annotation as InkAnnotation).Settings.Opacity = value;
            else
                Parent.pdfViewerControl.AnnotationSettings.Ink.Opacity = value;

            Parent.opacitySliderValue.Text = ((int)(value * 100)).ToString() + "%";
        }
        internal void OpacitySlider_TouchUpOutside(object sender, EventArgs e)
        {
            float value = (sender as UISlider).Value;
            if (Parent.annotation != null)
                (Parent.annotation as InkAnnotation).Settings.Opacity = value;
            else
                Parent.pdfViewerControl.AnnotationSettings.Ink.Opacity = value;

            Parent.opacitySliderValue.Text = ((int)(value * 100)).ToString() + "%";
        }
        internal void ThicknessView()
        {

            Parent.AutoresizingMask = UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleWidth;
            Parent.BoldBtn1.AutoresizingMask = UIViewAutoresizing.All;
            Parent.BoldBtn2.AutoresizingMask = UIViewAutoresizing.All;
            Parent.BoldBtn3.AutoresizingMask = UIViewAutoresizing.All;
            Parent.BoldBtn4.AutoresizingMask = UIViewAutoresizing.All;
            Parent.BoldBtn5.AutoresizingMask = UIViewAutoresizing.All;
            Parent.BoldColorBtn1.AutoresizingMask = UIViewAutoresizing.All;
            Parent.BoldColorBtn2.AutoresizingMask = UIViewAutoresizing.All;
            Parent.BoldColorBtn3.AutoresizingMask = UIViewAutoresizing.All;
            Parent.BoldColorBtn4.AutoresizingMask = UIViewAutoresizing.All;
            Parent.BoldColorBtn5.AutoresizingMask = UIViewAutoresizing.All;
            CreateThicknessToolbar();
        }

        internal void BoldColorBtn1_TouchUpInside(object sender, EventArgs e)
        {

            if (Parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                Parent.pdfViewerControl.AnnotationSettings.Ink.Thickness = 1;
            }
            if (Parent.annotation != null)
                (Parent.annotation as InkAnnotation).Settings.Thickness = 1;
            Parent.thicknessToolbar.RemoveFromSuperview();
            Parent.isThicknessTouched = false;

        }

        internal void BoldColorBtn2_TouchUpInside(object sender, EventArgs e)
        {
            if (Parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                Parent.pdfViewerControl.AnnotationSettings.Ink.Thickness = 2;
            }
            if (Parent.annotation != null)
                (Parent.annotation as InkAnnotation).Settings.Thickness = 2;
            Parent.thicknessToolbar.RemoveFromSuperview();
            Parent.isThicknessTouched = false;
        }

        internal void BoldColorBtn3_TouchUpInside(object sender, EventArgs e)
        {
            if (Parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                Parent.pdfViewerControl.AnnotationSettings.Ink.Thickness = 4;
            }
            if (Parent.annotation != null)
                (Parent.annotation as InkAnnotation).Settings.Thickness = 4;
            Parent.thicknessToolbar.RemoveFromSuperview();
            Parent.isThicknessTouched = false;
        }

        internal void BoldColorBtn4_TouchUpInside(object sender, EventArgs e)
        {
            if (Parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                Parent.pdfViewerControl.AnnotationSettings.Ink.Thickness = 6;
            }
            if (Parent.annotation != null)
                (Parent.annotation as InkAnnotation).Settings.Thickness = 6;
            Parent.thicknessToolbar.RemoveFromSuperview();
            Parent.isThicknessTouched = false;
        }

        internal void BoldColorBtn5_TouchUpInside(object sender, EventArgs e)
        {
            if (Parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
            {
                Parent.pdfViewerControl.AnnotationSettings.Ink.Thickness = 10;
            }
            if (Parent.annotation != null)
                (Parent.annotation as InkAnnotation).Settings.Thickness = 10;
            Parent.thicknessToolbar.RemoveFromSuperview();
            Parent.isThicknessTouched = false;
        }

        internal void CreateThicknessToolbar()
        {
            float x = 0;

            x = (float)(Parent.Frame.Width - 310) / 2;


            Parent.AutoresizingMask = UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleWidth;
            Parent.BoldBtn1.Frame = new CGRect(x, 7, 54, 30);
            Parent.BoldBtn1.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.BoldBtn1.BackgroundColor = UIColor.White;
            Parent.BoldBtn1.Layer.BorderWidth = 1;
            Parent.BoldBtn1.Layer.BorderColor = separatorgray;
            Parent.thicknessToolbar.AddSubview(Parent.BoldBtn1);

            Parent.BoldColorBtn1.Frame = new CGRect((x + 9), 21, 36, 1);
            if (Parent.annotation != null)
                Parent.BoldColorBtn1.BackgroundColor = (Parent.annotation as InkAnnotation).Settings.Color;
            if (Parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                Parent.BoldColorBtn1.BackgroundColor = Parent.pdfViewerControl.AnnotationSettings.Ink.Color;
            Parent.BoldColorBtn1.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.thicknessToolbar.AddSubview(Parent.BoldColorBtn1);

            Parent.BoldBtn2.Frame = new CGRect(((x + 54) + 10), 7, 54, 30);
            Parent.BoldBtn2.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.BoldBtn2.BackgroundColor = UIColor.White;
            Parent.BoldBtn2.Layer.BorderWidth = 1;
            Parent.BoldBtn2.Layer.BorderColor = separatorgray;
            Parent.thicknessToolbar.AddSubview(Parent.BoldBtn2);

            Parent.BoldColorBtn2.Frame = new CGRect((x + 54 + 10 + 9), 21, 36, 2);
            if (Parent.annotation != null)
                Parent.BoldColorBtn2.BackgroundColor = (Parent.annotation as InkAnnotation).Settings.Color;
            if (Parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                Parent.BoldColorBtn2.BackgroundColor = Parent.pdfViewerControl.AnnotationSettings.Ink.Color;
            Parent.BoldColorBtn2.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.thicknessToolbar.AddSubview(Parent.BoldColorBtn2);

            Parent.BoldBtn3.Frame = new CGRect(((x + 108) + 20), 7, 54, 30);
            Parent.BoldBtn3.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.BoldBtn3.BackgroundColor = UIColor.White;
            Parent.BoldBtn3.Layer.BorderWidth = 1;
            Parent.BoldBtn3.Layer.BorderColor = separatorgray;
            Parent.thicknessToolbar.AddSubview(Parent.BoldBtn3);

            Parent.BoldColorBtn3.Frame = new CGRect((x + 108 + 20 + 9), 20, 36, 4);
            if (Parent.annotation != null)
                Parent.BoldColorBtn3.BackgroundColor = (Parent.annotation as InkAnnotation).Settings.Color;
            if (Parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                Parent.BoldColorBtn3.BackgroundColor = Parent.pdfViewerControl.AnnotationSettings.Ink.Color;
            Parent.BoldColorBtn3.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.thicknessToolbar.AddSubview(Parent.BoldColorBtn3);

            Parent.BoldBtn4.Frame = new CGRect(((x + 162) + 30), 7, 54, 30);
            Parent.BoldBtn4.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.BoldBtn4.BackgroundColor = UIColor.White;
            Parent.BoldBtn4.Layer.BorderWidth = 1;
            Parent.BoldBtn4.Layer.BorderColor = separatorgray;
            Parent.thicknessToolbar.AddSubview(Parent.BoldBtn4);

            Parent.BoldColorBtn4.Frame = new CGRect((x + 162 + 30 + 9), 19, 36, 6);
            if (Parent.annotation != null)
                Parent.BoldColorBtn4.BackgroundColor = (Parent.annotation as InkAnnotation).Settings.Color;
            if (Parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                Parent.BoldColorBtn4.BackgroundColor = Parent.pdfViewerControl.AnnotationSettings.Ink.Color;
            Parent.BoldColorBtn4.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.thicknessToolbar.AddSubview(Parent.BoldColorBtn4);

           Parent.BoldBtn5.Frame = new CGRect(((x + 216) + 40), 7, 54, 30);
            Parent.BoldBtn5.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.BoldBtn5.BackgroundColor = UIColor.White;
            Parent.BoldBtn5.Layer.BorderWidth = 1;
            Parent.BoldBtn5.Layer.BorderColor = separatorgray;
            Parent.thicknessToolbar.AddSubview(Parent.BoldBtn5);

            if (Parent.annotation != null)
                Parent.BoldColorBtn5.BackgroundColor = (Parent.annotation as InkAnnotation).Settings.Color;
            if (Parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                Parent.BoldColorBtn5.BackgroundColor = Parent.pdfViewerControl.AnnotationSettings.Ink.Color;
            Parent.BoldColorBtn5.Frame = new CGRect((x + 216 + 40 + 9), 18, 36, 8);
            Parent.BoldColorBtn5.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.thicknessToolbar.AddSubview(Parent.BoldColorBtn5);
            Parent.Add(Parent.thicknessToolbar);

        }
        internal void Opacitybutton_TouchUpInside(object sender, EventArgs e)
        {
            Parent.isThicknessTouched = false;
            Parent.opacitySlider.RemoveFromSuperview();
            Parent.opacitySliderValue.RemoveFromSuperview();
            Parent.opacityFrame = Parent.Frame;
            Parent.opacityFrame.Height = DefaultToolbarHeight;
            Parent.opacityFrame.Y = Parent.parentView.Frame.Height - (DefaultToolbarHeight + (Parent.colorFrame.Height * 2) - 4);
            Parent.opacityFrame.X = Parent.parentView.Frame.Width / 2 - 5;
            Parent.opacityFrame.Width = Parent.parentView.Frame.Width / 2 - 15;
            Parent.opacityPanel.Frame = Parent.opacityFrame;
            Parent.opacityPanel.BackgroundColor = UIColor.FromRGB(249, 249, 249);

            Parent.opacitySlider = new UISlider();
            Parent.opacitySlider.Frame = new CGRect(5, 0, Parent.opacityFrame.Width - 54, Parent.opacityFrame.Height);
            Parent.opacitySlider.MinValue = 0;
            Parent.opacitySlider.MaxValue = 1;
            Parent.opacitySlider.Continuous = true;
            Parent.opacityPanel.Add(Parent.opacitySlider);
            if (Parent.annotation != null)
                Parent.opacitySlider.Value = (Parent.annotation as InkAnnotation).Settings.Opacity;
            else
                Parent.opacitySlider.Value = Parent.pdfViewerControl.AnnotationSettings.Ink.Opacity;
            Parent.opacitySlider.TouchUpInside += OpacitySlider_TouchUpInside;
            Parent.opacitySlider.TouchUpOutside += OpacitySlider_TouchUpOutside;
            Parent.opacitySliderValue = new UILabel();
            Parent.opacitySliderValue.Frame = new CGRect(Parent.opacityFrame.Width - 45, 0, 55, Parent.opacityFrame.Height);
            Parent.opacitySliderValue.Text = ((int)(Parent.opacitySlider.Value * 100)).ToString()+"%";
            Parent.opacityPanel.Add(Parent.opacitySliderValue);
            if (!Parent.isOpacitySelected)
            {
                Parent.Add(Parent.opacityPanel);
                Parent.isOpacitySelected = true;
            }
            else
            {
                Parent.opacityPanel.RemoveFromSuperview();
                Parent.isOpacitySelected = false;
            }
        }
    }
}
