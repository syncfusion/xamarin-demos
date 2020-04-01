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
    public class TextMarkupAnnotationHelper
    {
        CustomToolbar parent;
        InkAnnotationHelper inkAnnot;
        AnnotationHelper annotHelper;
        internal const float DefaultToolbarHeight = 50f;
        public TextMarkupAnnotationHelper(CustomToolbar customtoolbar)
        {
            parent = customtoolbar;
        }
        public TextMarkupAnnotationHelper(InkAnnotationHelper inkannottoolbar, CustomToolbar customtoolbar)
        {
            inkAnnot = inkannottoolbar;
            parent = customtoolbar;
        }
        public TextMarkupAnnotationHelper(AnnotationHelper annottoolbar, CustomToolbar customtoolbar)
        {
            annotHelper = annottoolbar;
            parent = customtoolbar;
        }
        internal void AnnotationColor_TouchUpInside(object sender, EventArgs e)
        {
            if (parent.annotation != null)
            {
                if (parent.annotation is TextMarkupAnnotation)
                {
                    ((TextMarkupAnnotation)parent.annotation).Settings.Color = (sender as UIButton).BackgroundColor;
                    parent.colorButton.BackgroundColor = (sender as UIButton).BackgroundColor;
                }
                else if (parent.annotation is InkAnnotation)
                {
                    ((InkAnnotation)parent.annotation).Settings.Color = (sender as UIButton).BackgroundColor;
                    parent.inkColorButton.BackgroundColor = (sender as UIButton).BackgroundColor;

                    parent.opacitybutton.SetTitleColor((sender as UIButton).BackgroundColor, UIControlState.Normal);
                    parent.inkThicknessButton.SetTitleColor((sender as UIButton).BackgroundColor, UIControlState.Normal);
                }
				else if (parent.annotation is HandwrittenSignature)
                {
					((HandwrittenSignature)parent.annotation).Settings.Color = (sender as UIButton).BackgroundColor;
                    parent.inkColorButton.BackgroundColor = (sender as UIButton).BackgroundColor;

                    parent.opacitybutton.SetTitleColor((sender as UIButton).BackgroundColor, UIControlState.Normal);
                    parent.inkThicknessButton.SetTitleColor((sender as UIButton).BackgroundColor, UIControlState.Normal);
                }
                else if (parent.annotation is FreeTextAnnotation)
                {
                    ((FreeTextAnnotation)parent.annotation).Settings.TextColor = (sender as UIButton).BackgroundColor;
                    parent.edittextColorButton.BackgroundColor = (sender as UIButton).BackgroundColor;

                    parent.edittextThicknessButton.SetTitleColor((sender as UIButton).BackgroundColor, UIControlState.Normal);
                }
                else if (parent.annotation is ShapeAnnotation)
                {
                    ((ShapeAnnotation)parent.annotation).Settings.StrokeColor = (sender as UIButton).BackgroundColor;
                    parent.shapeColorButton.BackgroundColor = (sender as UIButton).BackgroundColor;

                    parent.opacitybutton.SetTitleColor((sender as UIButton).BackgroundColor, UIControlState.Normal);
                }
            }
            else
            {
                if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
                {
                    parent.pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = (sender as UIButton).BackgroundColor;
                    parent.colorButton.BackgroundColor = (sender as UIButton).BackgroundColor;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
                {
                    parent.pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = (sender as UIButton).BackgroundColor;
                    parent.colorButton.BackgroundColor = (sender as UIButton).BackgroundColor;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
                {
                    parent.pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = (sender as UIButton).BackgroundColor;
                    parent.colorButton.BackgroundColor = (sender as UIButton).BackgroundColor;
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                {
                    parent.pdfViewerControl.AnnotationSettings.Ink.Color = (sender as UIButton).BackgroundColor;
                    parent.inkColorButton.BackgroundColor = (sender as UIButton).BackgroundColor;
                    parent.opacitybutton.SetTitleColor((sender as UIButton).BackgroundColor, UIControlState.Normal);
                    
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.FreeText)
                {
                    parent.pdfViewerControl.AnnotationSettings.FreeText.TextColor = (sender as UIButton).BackgroundColor;
                    parent.edittextColorButton.BackgroundColor = (sender as UIButton).BackgroundColor;
                    
                }
                else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                {

                    if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                    {
                        parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor = (sender as UIButton).BackgroundColor;
                        parent.shapeColorButton.BackgroundColor = (sender as UIButton).BackgroundColor;
                        parent.opacitybutton.SetTitleColor((sender as UIButton).BackgroundColor, UIControlState.Normal);
                    }
                    else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                    {
                        parent.pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor = (sender as UIButton).BackgroundColor;
                        parent.shapeColorButton.BackgroundColor = (sender as UIButton).BackgroundColor;
                        parent.opacitybutton.SetTitleColor((sender as UIButton).BackgroundColor, UIControlState.Normal);
                    }
                    else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                    {
                        parent.pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor = (sender as UIButton).BackgroundColor;
                        parent.shapeColorButton.BackgroundColor = (sender as UIButton).BackgroundColor;
                        parent.opacitybutton.SetTitleColor((sender as UIButton).BackgroundColor, UIControlState.Normal);
                    }
                    else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                    {
                        parent.pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor = (sender as UIButton).BackgroundColor;
                        parent.shapeColorButton.BackgroundColor = (sender as UIButton).BackgroundColor;
                        parent.opacitybutton.SetTitleColor((sender as UIButton).BackgroundColor, UIControlState.Normal);
                    }

                }
            }
            parent.isColorSelected = false;
            parent.colorToolbar.RemoveFromSuperview();
            parent.opacityPanel.RemoveFromSuperview();
        }
        internal void HighlightAnnotationButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.pdfViewerControl.AnnotationMode = AnnotationMode.Highlight;
            parent.textAnnotationToolbar.RemoveFromSuperview();
            parent.isAnnotationToolbarVisible = true;
            parent.deleteButton.RemoveFromSuperview();
            parent.highlightToolbar = CreateSeparateAnnotationToolbar(parent.highlightToolbar, parent.highlightEnable, "\ue710", false, parent.pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color);
            parent.Add(parent.highlightToolbar);
        }
        internal void UnderlineAnnotationButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.pdfViewerControl.AnnotationMode = AnnotationMode.Underline;
            parent.textAnnotationToolbar.RemoveFromSuperview();
            parent.isAnnotationToolbarVisible = true;
            parent.deleteButton.RemoveFromSuperview();
            parent.underlineToolbar = CreateSeparateAnnotationToolbar(parent.underlineToolbar, parent.underlineEnable, "\ue70c", false, parent.pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);
            parent.Add(parent.underlineToolbar);
        }
        internal void StrikeOutAnnotationButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.pdfViewerControl.AnnotationMode = AnnotationMode.Strikethrough;
            parent.textAnnotationToolbar.RemoveFromSuperview();
            parent.isAnnotationToolbarVisible = true;
            parent.deleteButton.RemoveFromSuperview();
            parent.strikeOutToolbar = CreateSeparateAnnotationToolbar(parent.strikeOutToolbar, parent.strikeEnable, "\ue71e", false, parent.pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
            parent.Add(parent.strikeOutToolbar);
        }
        internal void TextMarkupAnnotationButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.annotationFrame = parent.Frame;
            parent.annotationFrame.Height = DefaultToolbarHeight;
            parent.annotationFrame.Y = parent.parentView.Frame.Height - parent.annotationFrame.Height + 4;
            parent.textAnnotationToolbar.Frame = parent.annotationFrame;
            parent.textAnnotationToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);

            parent.toolbarBackbutton.Frame = new CGRect(15, 7, 35, 35);
            parent.toolbarBackbutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.toolbarBackbutton.TouchUpInside += parent.ToolbarBackbutton_TouchUpInside;
            parent.toolbarBackbutton.Font = parent.highFont;
            parent.toolbarBackbutton.SetTitle("\ue708", UIControlState.Normal);
            parent.toolbarBackbutton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            parent.textAnnotationToolbar.Add(parent.toolbarBackbutton);

            parent.highlightAnnotationButton.Frame = new CGRect(parent.parentView.Frame.Width / 2 - 100, 7, 35, 35);
            parent.highlightAnnotationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.highlightAnnotationButton.TouchUpInside += HighlightAnnotationButton_TouchUpInside;
            parent.highlightAnnotationButton.Font = parent.highFont;
            parent.highlightAnnotationButton.SetTitle("\ue710", UIControlState.Normal);
            parent.highlightAnnotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            parent.textAnnotationToolbar.Add(parent.highlightAnnotationButton);

            parent.underlineAnnotationButton.Frame = new CGRect(parent.parentView.Frame.Width / 2, 7, 35, 35);
            parent.underlineAnnotationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.underlineAnnotationButton.TouchUpInside += UnderlineAnnotationButton_TouchUpInside; ;
            parent.underlineAnnotationButton.Font = parent.highFont;
            parent.underlineAnnotationButton.SetTitle("\ue70c", UIControlState.Normal);
            parent.underlineAnnotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            parent.textAnnotationToolbar.Add(parent.underlineAnnotationButton);

            parent.strikeOutAnnotationButton.Frame = new CGRect(parent.parentView.Frame.Width / 2 + 100, 7, 35, 35);
            parent.strikeOutAnnotationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            parent.strikeOutAnnotationButton.TouchUpInside += StrikeOutAnnotationButton_TouchUpInside; ;
            parent.strikeOutAnnotationButton.Font = parent.highFont;
            parent.strikeOutAnnotationButton.SetTitle("\ue71e", UIControlState.Normal);
            parent.strikeOutAnnotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            parent.textAnnotationToolbar.Add(parent.strikeOutAnnotationButton);

            parent.textAnnotationToolbar = parent.UpdateToolbarBorder(parent.textAnnotationToolbar, parent.annotationFrame);
            parent.Add(parent.textAnnotationToolbar);
        }
        internal void TextToolbarBackButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.pdfViewerControl.AnnotationMode = AnnotationMode.None;
            parent.annotHelper.RemoveAllToolbars(false);
            parent.Add(parent.textAnnotationToolbar);
            parent.isAnnotationToolbarVisible = true;
            parent.textToolbarBackButton.RemoveFromSuperview();
        }
        internal void PdfViewerControl_TextMarkupSelected(object sender, TextMarkupSelectedEventArgs args)
        {
            parent.annotation = sender as IAnnotation;
            if (args.AnnotationType == TextMarkupAnnotationType.Highlight)
            {
                parent.highlightToolbar = CreateSeparateAnnotationToolbar(parent.highlightToolbar, parent.highlightEnable, "\ue710", true, (parent.annotation as TextMarkupAnnotation).Settings.Color);
                parent.Add(parent.highlightToolbar);
            }
            else if (args.AnnotationType == TextMarkupAnnotationType.Underline)
            {
                parent.underlineToolbar = CreateSeparateAnnotationToolbar(parent.underlineToolbar, parent.underlineEnable, "\ue70c", true, (parent.annotation as TextMarkupAnnotation).Settings.Color);
                parent.Add(parent.underlineToolbar);
            }
            else
            {
                parent.strikeOutToolbar = CreateSeparateAnnotationToolbar(parent.strikeOutToolbar, parent.strikeEnable, "\ue71e", true, (parent.annotation as TextMarkupAnnotation).Settings.Color);
                parent.Add(parent.strikeOutToolbar);
            }
            parent.toolbarBackbutton.RemoveFromSuperview();
            parent.textAnnotationToolbar.RemoveFromSuperview();
            parent.colorToolbar.RemoveFromSuperview();
            parent.isAnnotationToolbarVisible = true;
        }
        internal void PdfViewerControl_TextMarkupDeselected(object sender, TextMarkupDeselectedEventArgs args)
        {
            if (args.AnnotationType == TextMarkupAnnotationType.Highlight)
                parent.highlightToolbar.RemoveFromSuperview();
            else if (args.AnnotationType == TextMarkupAnnotationType.Underline)
                parent.underlineToolbar.RemoveFromSuperview();
            else
                parent.strikeOutToolbar.RemoveFromSuperview();
            parent.colorToolbar.RemoveFromSuperview();
            parent.textAnnotationToolbar.RemoveFromSuperview();
            parent.isAnnotationToolbarVisible = false;
            parent.annotation = null;
        }

        internal void PdfViewerControl_StampAnnotationDeselected(object sender, StampAnnotationDeselectedEventArgs args)
        {
            parent.editStampAnnotationToolbar.RemoveFromSuperview();
            parent.colorToolbar.RemoveFromSuperview();
            parent.textAnnotationToolbar.RemoveFromSuperview();
            parent.isAnnotationToolbarVisible = false;
            parent.annotation = null;
        }

        internal void PdfViewerControl_StampAnnotationSelected(object sender, StampAnnotationSelectedEventArgs args)
        {
            parent.editStampAnnotationToolbar = CreateSeparateAnnotationToolbar(parent.editStampAnnotationToolbar, parent.editStampButton, "\ue701", true, null);
            parent.Add(parent.editStampAnnotationToolbar);
            parent.annotation = sender as IAnnotation;
            parent.toolbarBackbutton.RemoveFromSuperview();
            parent.textAnnotationToolbar.RemoveFromSuperview();
            parent.colorToolbar.RemoveFromSuperview();
            parent.isAnnotationToolbarVisible = true;
        }


        internal UIView CreateSeparateAnnotationToolbar(UIView separateToolbar, UIButton enableLabel, string imageName, bool isSelected, UIColor colorButtonColor)
        {
            parent.isOpacityNeeded = false;
            parent.separateAnnotationFrame = parent.Frame;
            parent.separateAnnotationFrame.Height = DefaultToolbarHeight;
            parent.separateAnnotationFrame.Y = parent.parentView.Frame.Height - parent.separateAnnotationFrame.Height + 4;
            separateToolbar.Frame = parent.separateAnnotationFrame;
            separateToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);

            enableLabel.Frame = new CGRect(45, 7, 35, 35);
            enableLabel.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            if (separateToolbar != parent.editStampAnnotationToolbar)
                enableLabel.Font = parent.highFont;
            else
                enableLabel.Font = parent.stampFont;
            enableLabel.SetTitle(imageName, UIControlState.Normal);
            enableLabel.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            separateToolbar.Add(enableLabel);
            parent.IsSelected = isSelected;
            if (!isSelected)
            {
                parent.textToolbarBackButton.Frame = new CGRect(parent.parentView.Frame.Width - 55, 7, 35, 35);
                parent.textToolbarBackButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                parent.textToolbarBackButton.TouchUpInside += TextToolbarBackButton_TouchUpInside; ; ;
                parent.textToolbarBackButton.Font = parent.highFont;
                parent.textToolbarBackButton.SetTitle("\ue715", UIControlState.Normal);
                parent.textToolbarBackButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
                separateToolbar.Add(parent.textToolbarBackButton);
                if(colorButtonColor != null)
                    parent.colorButton.Frame = new CGRect(parent.parentView.Frame.Width - 130, 7, 30, 30);
            }
            else
            {
                parent.deleteButton.Frame = new CGRect(parent.parentView.Frame.Width - 100, 7, 35, 35);
                parent.deleteButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                parent.deleteButton.TouchUpInside += DeleteButton_TouchUpInside; ;
                parent.deleteButton.Font = parent.highFont;
                parent.deleteButton.SetTitle("\ue714", UIControlState.Normal);
                parent.deleteButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
                separateToolbar.Add(parent.deleteButton);
                if(colorButtonColor != null)
                    parent.colorButton.Frame = new CGRect(parent.parentView.Frame.Width - 55, 7, 30, 30);
            }
            if (colorButtonColor != null)
            {
                parent.colorButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                parent.colorButton.BackgroundColor = colorButtonColor;
                separateToolbar.Add(parent.colorButton);
            }
            separateToolbar = parent.UpdateToolbarBorder(separateToolbar, parent.separateAnnotationFrame);
            return separateToolbar;
        }
        internal void DeleteButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.pdfViewerControl.RemoveAnnotation(parent.annotation);
            parent.annotHelper.RemoveAllToolbars(false);
        }
        internal void ColorButton_TouchUpInside(object sender, EventArgs e)
        {
            parent.isThicknessTouched = false;
            parent.thicknessToolbar.RemoveFromSuperview();
            parent.FontSizePanel.RemoveFromSuperview();
            parent.rangeSlider.RemoveFromSuperview();
            if (!parent.isColorSelected)
            {
                parent.isColorSelected = true;
                parent.colorFrame = parent.Frame;
                parent.colorFrame.Height = DefaultToolbarHeight;
                parent.colorFrame.Y = parent.parentView.Frame.Height - (DefaultToolbarHeight + parent.colorFrame.Height - 4);
                parent.colorToolbar.Frame = parent.colorFrame;
                parent.colorToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);

                parent.redButton.Frame = new CGRect(parent.parentView.Frame.Width - 50, 7, 30, 30);
                parent.redButton.BackgroundColor = UIColor.Red;
                parent.redButton.TouchUpInside += AnnotationColor_TouchUpInside;
                parent.colorToolbar.AddSubview(parent.redButton);

                parent.blueButton.Frame = new CGRect(parent.parentView.Frame.Width - 100, 7, 30, 30);
                parent.blueButton.BackgroundColor = UIColor.Blue;
                parent.blueButton.TouchUpInside += AnnotationColor_TouchUpInside;
                parent.colorToolbar.AddSubview(parent.blueButton);

                parent.greenButton.Frame = new CGRect(parent.parentView.Frame.Width - 150, 7, 30, 30);
                parent.greenButton.BackgroundColor = UIColor.Green;
                parent.greenButton.TouchUpInside += AnnotationColor_TouchUpInside;
                parent.colorToolbar.AddSubview(parent.greenButton);

                parent.grayButton.Frame = new CGRect(parent.parentView.Frame.Width - 200, 7, 30, 30);
                parent.grayButton.BackgroundColor = UIColor.Gray;
                parent.grayButton.TouchUpInside += AnnotationColor_TouchUpInside;
                parent.colorToolbar.AddSubview(parent.grayButton);

                parent.blackButton.Frame = new CGRect(parent.parentView.Frame.Width - 250, 7, 30, 30);
                parent.blackButton.BackgroundColor = UIColor.Black;
                parent.blackButton.TouchUpInside += AnnotationColor_TouchUpInside;
                parent.colorToolbar.AddSubview(parent.blackButton);

                parent.yellowButton.Frame = new CGRect(parent.parentView.Frame.Width - 300, 7, 30, 30);
                parent.yellowButton.BackgroundColor = UIColor.Yellow;
                parent.yellowButton.TouchUpInside += AnnotationColor_TouchUpInside;
                parent.colorToolbar.AddSubview(parent.yellowButton);

                parent.whiteButton.Frame = new CGRect(parent.parentView.Frame.Width - 350, 7, 30, 30);
                parent.whiteButton.BackgroundColor = UIColor.White;
                parent.whiteButton.TouchUpInside += AnnotationColor_TouchUpInside;
                parent.colorToolbar.AddSubview(parent.whiteButton);
                if (parent.isOpacityNeeded)
                {
                    parent.redButton.Frame = new CGRect(parent.parentView.Frame.Width - 90, 7, 30, 30);
                    parent.blueButton.Frame = new CGRect(parent.parentView.Frame.Width - 130, 7, 30, 30);
                    parent.greenButton.Frame = new CGRect(parent.parentView.Frame.Width - 170, 7, 30, 30);
                    parent.grayButton.Frame = new CGRect(parent.parentView.Frame.Width - 220, 7, 30, 30);
                    parent.blackButton.Frame = new CGRect(parent.parentView.Frame.Width - 260, 7, 30, 30);
                    parent.yellowButton.Frame = new CGRect(parent.parentView.Frame.Width - 310, 7, 30, 30);
                    parent.whiteButton.Frame = new CGRect(parent.parentView.Frame.Width - 350, 7, 30, 30);
					if (parent.annotation is HandwrittenSignature || parent.annotation is InkAnnotation || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink || parent.annotation is ShapeAnnotation || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle
                        || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle || parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                    {
                        parent.opacitybutton.Frame = new CGRect(parent.parentView.Frame.Width - 50, 7, 35, 35);
                        parent.opacitybutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                        parent.opacitybutton.Font = parent.highFont;
                        parent.opacitybutton.SetTitle("\ue71a", UIControlState.Normal);
                        if (parent.annotation != null)
                        {
                            if (parent.annotation is ShapeAnnotation)
                                parent.opacitybutton.SetTitleColor((parent.annotation as ShapeAnnotation).Settings.StrokeColor, UIControlState.Normal);
                            else if(parent.annotation is InkAnnotation)
                                parent.opacitybutton.SetTitleColor((parent.annotation as InkAnnotation).Settings.Color, UIControlState.Normal);
							else if(parent.annotation is HandwrittenSignature)
								parent.opacitybutton.SetTitleColor((parent.annotation as HandwrittenSignature).Settings.Color, UIControlState.Normal);
                        }
                        else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                            parent.opacitybutton.SetTitleColor(parent.pdfViewerControl.AnnotationSettings.Ink.Color, UIControlState.Normal);
                        else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Circle)
                            parent.opacitybutton.SetTitleColor(parent.pdfViewerControl.AnnotationSettings.Circle.Settings.StrokeColor, UIControlState.Normal);
                        else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Rectangle)
                            parent.opacitybutton.SetTitleColor(parent.pdfViewerControl.AnnotationSettings.Rectangle.Settings.StrokeColor, UIControlState.Normal);
                        else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Arrow)
                            parent.opacitybutton.SetTitleColor(parent.pdfViewerControl.AnnotationSettings.Arrow.Settings.StrokeColor, UIControlState.Normal);
                        else if (parent.pdfViewerControl.AnnotationMode == AnnotationMode.Line)
                            parent.opacitybutton.SetTitleColor(parent.pdfViewerControl.AnnotationSettings.Line.Settings.StrokeColor, UIControlState.Normal);
                        parent.colorToolbar.AddSubview(parent.opacitybutton);
                    }
                }
                else
                {
                    parent.opacitybutton.RemoveFromSuperview();
                }
                parent.colorToolbar = parent.UpdateToolbarBorder(parent.colorToolbar, parent.colorFrame);
                parent.opacityPanel.RemoveFromSuperview();
                parent.isOpacitySelected = false;
                parent.colorToolbar.AutosizesSubviews = true;
                parent.Add(parent.colorToolbar);
            }
            else
            {
                parent.opacitybutton.RemoveFromSuperview();
                parent.colorToolbar.RemoveFromSuperview();
                parent.opacityPanel.RemoveFromSuperview();
                parent.isColorSelected = false;
                parent.isOpacitySelected = false;
            }
        }
    }
}