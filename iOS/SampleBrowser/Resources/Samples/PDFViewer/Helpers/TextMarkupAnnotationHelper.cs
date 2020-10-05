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
        CustomToolbar m_parent;
        InkAnnotationHelper m_inkannot;
        AnnotationHelper m_annotHelper;
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

        private InkAnnotationHelper InkAnnot
        {
            get
            {
                return m_inkannot;
            }
            set
            {
                m_inkannot = value;
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

        public TextMarkupAnnotationHelper(CustomToolbar customtoolbar)
        {
            Parent = customtoolbar;
        }

        public TextMarkupAnnotationHelper(InkAnnotationHelper inkannottoolbar, CustomToolbar customtoolbar)
        {
            InkAnnot = inkannottoolbar;
            Parent = customtoolbar;
        }

        public TextMarkupAnnotationHelper(AnnotationHelper annottoolbar, CustomToolbar customtoolbar)
        {
            AnnotHelper = annottoolbar;
            Parent = customtoolbar;
        } 

        internal void AnnotationColor_TouchUpInside(object sender, EventArgs e)
        {
            if (Parent.annotation != null)
            {
                if (Parent.annotation is TextMarkupAnnotation)
                {
                    ((TextMarkupAnnotation)Parent.annotation).Settings.Color = (sender as UIButton).BackgroundColor;
                    Parent.colorButton.BackgroundColor = (sender as UIButton).BackgroundColor;
                }
                else if (Parent.annotation is InkAnnotation)
                {
                    ((InkAnnotation)Parent.annotation).Settings.Color = (sender as UIButton).BackgroundColor;
                    Parent.inkColorButton.BackgroundColor = (sender as UIButton).BackgroundColor;
                    Parent.opacitybutton.SetTitleColor((sender as UIButton).BackgroundColor, UIControlState.Normal);
                    Parent.inkThicknessButton.SetTitleColor((sender as UIButton).BackgroundColor, UIControlState.Normal);
                }
            }
            else
            {
                if (Parent.pdfViewerControl.AnnotationMode == AnnotationMode.Highlight)
                {
                    Parent.pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color = (sender as UIButton).BackgroundColor;
                    Parent.colorButton.BackgroundColor = (sender as UIButton).BackgroundColor;
                }
                else if (Parent.pdfViewerControl.AnnotationMode == AnnotationMode.Strikethrough)
                {
                    Parent.pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color = (sender as UIButton).BackgroundColor;
                    Parent.colorButton.BackgroundColor = (sender as UIButton).BackgroundColor;
                }
                else if (Parent.pdfViewerControl.AnnotationMode == AnnotationMode.Underline)
                {
                    Parent.pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color = (sender as UIButton).BackgroundColor;
                    Parent.colorButton.BackgroundColor = (sender as UIButton).BackgroundColor;
                }
                else if (Parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                {
                    Parent.pdfViewerControl.AnnotationSettings.Ink.Color = (sender as UIButton).BackgroundColor;
                    Parent.inkColorButton.BackgroundColor = (sender as UIButton).BackgroundColor;
                    Parent.opacitybutton.SetTitleColor((sender as UIButton).BackgroundColor, UIControlState.Normal);
                    Parent.inkThicknessButton.SetTitleColor((sender as UIButton).BackgroundColor, UIControlState.Normal);
                }
            }
            Parent.isColorSelected = false;
            Parent.colorToolbar.RemoveFromSuperview();
            Parent.opacityPanel.RemoveFromSuperview();
        }

        internal void HighlightAnnotationButton_TouchUpInside(object sender, EventArgs e)
        {
            Parent.pdfViewerControl.AnnotationMode = AnnotationMode.Highlight;
            Parent.textAnnotationToolbar.RemoveFromSuperview();
            Parent.isAnnotationToolbarVisible = true;
            Parent.deleteButton.RemoveFromSuperview();
            Parent.highlightToolbar = CreateSeparateAnnotationToolbar(Parent.highlightToolbar, Parent.highlightEnable, "\ue710", false, Parent.pdfViewerControl.AnnotationSettings.TextMarkup.Highlight.Color);
            Parent.Add(Parent.highlightToolbar);
        }

        internal void UnderlineAnnotationButton_TouchUpInside(object sender, EventArgs e)
        {
            Parent.pdfViewerControl.AnnotationMode = AnnotationMode.Underline;
            Parent.textAnnotationToolbar.RemoveFromSuperview();
            Parent.isAnnotationToolbarVisible = true;
            Parent.deleteButton.RemoveFromSuperview();
            Parent.underlineToolbar = CreateSeparateAnnotationToolbar(Parent.underlineToolbar, Parent.underlineEnable, "\ue70c", false, Parent.pdfViewerControl.AnnotationSettings.TextMarkup.Underline.Color);
            Parent.Add(Parent.underlineToolbar);
        }

        internal void StrikeOutAnnotationButton_TouchUpInside(object sender, EventArgs e)
        {
            Parent.pdfViewerControl.AnnotationMode = AnnotationMode.Strikethrough;
            Parent.textAnnotationToolbar.RemoveFromSuperview();
            Parent.isAnnotationToolbarVisible = true;
            Parent.deleteButton.RemoveFromSuperview();
            Parent.strikeOutToolbar = CreateSeparateAnnotationToolbar(Parent.strikeOutToolbar, Parent.strikeEnable, "\ue71e", false, Parent.pdfViewerControl.AnnotationSettings.TextMarkup.Strikethrough.Color);
            Parent.Add(Parent.strikeOutToolbar);
        }

        internal void TextMarkupAnnotationButton_TouchUpInside(object sender, EventArgs e)
        {
            Parent.annotationFrame = Parent.Frame;
            Parent.annotationFrame.Height = DefaultToolbarHeight;
            Parent.annotationFrame.Y = Parent.parentView.Frame.Height - Parent.annotationFrame.Height + 4;
            Parent.textAnnotationToolbar.Frame = Parent.annotationFrame;
            Parent.textAnnotationToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);

            Parent.toolbarBackbutton.Frame = new CGRect(15, 7, 35, 35);
            Parent.toolbarBackbutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.toolbarBackbutton.TouchUpInside += Parent.ToolbarBackbutton_TouchUpInside;
            Parent.toolbarBackbutton.Font = Parent.highFont;
            Parent.toolbarBackbutton.SetTitle("\ue708", UIControlState.Normal);
            Parent.toolbarBackbutton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            Parent.textAnnotationToolbar.Add(Parent.toolbarBackbutton);

            Parent.highlightAnnotationButton.Frame = new CGRect(Parent.parentView.Frame.Width / 2 - 100, 7, 35, 35);
            Parent.highlightAnnotationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.highlightAnnotationButton.TouchUpInside += HighlightAnnotationButton_TouchUpInside;
            Parent.highlightAnnotationButton.Font = Parent.highFont;
            Parent.highlightAnnotationButton.SetTitle("\ue710", UIControlState.Normal);
            Parent.highlightAnnotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            Parent.textAnnotationToolbar.Add(Parent.highlightAnnotationButton);

            Parent.underlineAnnotationButton.Frame = new CGRect(Parent.parentView.Frame.Width / 2, 7, 35, 35);
            Parent.underlineAnnotationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.underlineAnnotationButton.TouchUpInside += UnderlineAnnotationButton_TouchUpInside; ;
            Parent.underlineAnnotationButton.Font = Parent.highFont;
            Parent.underlineAnnotationButton.SetTitle("\ue70c", UIControlState.Normal);
            Parent.underlineAnnotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            Parent.textAnnotationToolbar.Add(Parent.underlineAnnotationButton);

            Parent.strikeOutAnnotationButton.Frame = new CGRect(Parent.parentView.Frame.Width / 2 + 100, 7, 35, 35);
            Parent.strikeOutAnnotationButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.strikeOutAnnotationButton.TouchUpInside += StrikeOutAnnotationButton_TouchUpInside; ;
            Parent.strikeOutAnnotationButton.Font = Parent.highFont;
            Parent.strikeOutAnnotationButton.SetTitle("\ue71e", UIControlState.Normal);
            Parent.strikeOutAnnotationButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            Parent.textAnnotationToolbar.Add(Parent.strikeOutAnnotationButton);

            Parent.textAnnotationToolbar = Parent.UpdateToolbarBorder(Parent.textAnnotationToolbar, Parent.annotationFrame);
            Parent.Add(Parent.textAnnotationToolbar);
        }

        internal void TextToolbarBackButton_TouchUpInside(object sender, EventArgs e)
        {
            Parent.pdfViewerControl.AnnotationMode = AnnotationMode.None;
            Parent.annotHelper.RemoveAllToolbars(false);
            Parent.Add(Parent.textAnnotationToolbar);
            Parent.isAnnotationToolbarVisible = true;
            Parent.textToolbarBackButton.RemoveFromSuperview();
        }

        internal void PdfViewerControl_TextMarkupSelected(object sender, TextMarkupSelectedEventArgs args)
        {
            Parent.annotation = sender as IAnnotation;
            if (args.AnnotationType == TextMarkupAnnotationType.Highlight)
            {
                Parent.highlightToolbar = CreateSeparateAnnotationToolbar(Parent.highlightToolbar, Parent.highlightEnable, "\ue710", true, (Parent.annotation as TextMarkupAnnotation).Settings.Color);
                Parent.Add(Parent.highlightToolbar);
            }
            else if (args.AnnotationType == TextMarkupAnnotationType.Underline)
            {
                Parent.underlineToolbar = CreateSeparateAnnotationToolbar(Parent.underlineToolbar, Parent.underlineEnable, "\ue70c", true, (Parent.annotation as TextMarkupAnnotation).Settings.Color);
                Parent.Add(Parent.underlineToolbar);
            }
            else
            {
                Parent.strikeOutToolbar = CreateSeparateAnnotationToolbar(Parent.strikeOutToolbar, Parent.strikeEnable, "\ue71e", true, (Parent.annotation as TextMarkupAnnotation).Settings.Color);
                Parent.Add(Parent.strikeOutToolbar);
            }
            Parent.toolbarBackbutton.RemoveFromSuperview();
            Parent.textAnnotationToolbar.RemoveFromSuperview();
            Parent.colorToolbar.RemoveFromSuperview();
            Parent.isAnnotationToolbarVisible = true;
        }

        internal void PdfViewerControl_TextMarkupDeselected(object sender, TextMarkupDeselectedEventArgs args)
        {
            if (args.AnnotationType == TextMarkupAnnotationType.Highlight)
                Parent.highlightToolbar.RemoveFromSuperview();
            else if (args.AnnotationType == TextMarkupAnnotationType.Underline)
                Parent.underlineToolbar.RemoveFromSuperview();
            else
                Parent.strikeOutToolbar.RemoveFromSuperview();
            Parent.colorToolbar.RemoveFromSuperview();
            Parent.textAnnotationToolbar.RemoveFromSuperview();
            Parent.isAnnotationToolbarVisible = false;
            Parent.annotation = null;
        }

        internal UIView CreateSeparateAnnotationToolbar(UIView separateToolbar, UIButton enableLabel, string imageName, bool isSelected, UIColor colorButtonColor)
        {
            Parent.isOpacityNeeded = false;
            Parent.separateAnnotationFrame = Parent.Frame;
            Parent.separateAnnotationFrame.Height = DefaultToolbarHeight;
            Parent.separateAnnotationFrame.Y = Parent.parentView.Frame.Height - Parent.separateAnnotationFrame.Height + 4;
            separateToolbar.Frame = Parent.separateAnnotationFrame;
            separateToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);

            enableLabel.Frame = new CGRect(45, 7, 35, 35);
            enableLabel.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            enableLabel.Font = Parent.highFont;
            enableLabel.SetTitle(imageName, UIControlState.Normal);
            enableLabel.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
            separateToolbar.Add(enableLabel);
            Parent.IsSelected = isSelected;
            if (!isSelected)
            {
                Parent.textToolbarBackButton.Frame = new CGRect(Parent.parentView.Frame.Width - 55, 7, 35, 35);
                Parent.textToolbarBackButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                Parent.textToolbarBackButton.TouchUpInside += TextToolbarBackButton_TouchUpInside; ; ;
                Parent.textToolbarBackButton.Font = Parent.highFont;
                Parent.textToolbarBackButton.SetTitle("\ue715", UIControlState.Normal);
                Parent.textToolbarBackButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
                separateToolbar.Add(Parent.textToolbarBackButton);
                Parent.colorButton.Frame = new CGRect(Parent.parentView.Frame.Width - 130, 7, 35, 35);
            }
            else
            {
                Parent.deleteButton.Frame = new CGRect(Parent.parentView.Frame.Width - 100, 7, 35, 35);
                Parent.deleteButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                Parent.deleteButton.TouchUpInside += DeleteButton_TouchUpInside; ;
                Parent.deleteButton.Font = Parent.highFont;
                Parent.deleteButton.SetTitle("\ue714", UIControlState.Normal);
                Parent.deleteButton.SetTitleColor(UIColor.FromRGB(0, 118, 255), UIControlState.Normal);
                separateToolbar.Add(Parent.deleteButton);
                Parent.colorButton.Frame = new CGRect(Parent.parentView.Frame.Width - 55, 7, 35, 35);
            }
            Parent.colorButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            Parent.colorButton.BackgroundColor = colorButtonColor;
            separateToolbar.Add(Parent.colorButton);
            separateToolbar = Parent.UpdateToolbarBorder(separateToolbar, Parent.separateAnnotationFrame);
            return separateToolbar;
        }

        internal void DeleteButton_TouchUpInside(object sender, EventArgs e)
        {
            Parent.pdfViewerControl.RemoveAnnotation(Parent.annotation);
            Parent.annotHelper.RemoveAllToolbars(false);
        }

        internal void ColorButton_TouchUpInside(object sender, EventArgs e)
        {
            Parent.isThicknessTouched = false;
            Parent.thicknessToolbar.RemoveFromSuperview();

            if (!Parent.isColorSelected)
            {
                Parent.isColorSelected = true;
                Parent.colorFrame = Parent.Frame;
                Parent.colorFrame.Height = DefaultToolbarHeight;
                Parent.colorFrame.Y = Parent.parentView.Frame.Height - (DefaultToolbarHeight + Parent.colorFrame.Height - 4);
                Parent.colorToolbar.Frame = Parent.colorFrame;
                Parent.colorToolbar.BackgroundColor = UIColor.FromRGB(249, 249, 249);

                Parent.redButton.Frame = new CGRect(Parent.parentView.Frame.Width - 50, 7, 30, 30);
                Parent.redButton.BackgroundColor = UIColor.Red;
                Parent.redButton.TouchUpInside += AnnotationColor_TouchUpInside;
                Parent.colorToolbar.AddSubview(Parent.redButton);

                Parent.blueButton.Frame = new CGRect(Parent.parentView.Frame.Width - 100, 7, 30, 30);
                Parent.blueButton.BackgroundColor = UIColor.Blue;
                Parent.blueButton.TouchUpInside += AnnotationColor_TouchUpInside;
                Parent.colorToolbar.AddSubview(Parent.blueButton);

                Parent.greenButton.Frame = new CGRect(Parent.parentView.Frame.Width - 150, 7, 30, 30);
                Parent.greenButton.BackgroundColor = UIColor.Green;
                Parent.greenButton.TouchUpInside += AnnotationColor_TouchUpInside;
                Parent.colorToolbar.AddSubview(Parent.greenButton);

                Parent.grayButton.Frame = new CGRect(Parent.parentView.Frame.Width - 200, 7, 30, 30);
                Parent.grayButton.BackgroundColor = UIColor.Gray;
                Parent.grayButton.TouchUpInside += AnnotationColor_TouchUpInside;
                Parent.colorToolbar.AddSubview(Parent.grayButton);

                Parent.blackButton.Frame = new CGRect(Parent.parentView.Frame.Width - 250, 7, 30, 30);
                Parent.blackButton.BackgroundColor = UIColor.Black;
                Parent.blackButton.TouchUpInside += AnnotationColor_TouchUpInside;
                Parent.colorToolbar.AddSubview(Parent.blackButton);

                Parent.yellowButton.Frame = new CGRect(Parent.parentView.Frame.Width - 300, 7, 30, 30);
                Parent.yellowButton.BackgroundColor = UIColor.Yellow;
                Parent.yellowButton.TouchUpInside += AnnotationColor_TouchUpInside;
                Parent.colorToolbar.AddSubview(Parent.yellowButton);

                Parent.whiteButton.Frame = new CGRect(Parent.parentView.Frame.Width - 350, 7, 30, 30);
                Parent.whiteButton.BackgroundColor = UIColor.White;
                Parent.whiteButton.TouchUpInside += AnnotationColor_TouchUpInside;
                Parent.colorToolbar.AddSubview(Parent.whiteButton);

                if (Parent.isOpacityNeeded)
                {
                    Parent.redButton.Frame = new CGRect(Parent.parentView.Frame.Width - 90, 7, 30, 30);
                    Parent.blueButton.Frame = new CGRect(Parent.parentView.Frame.Width - 130, 7, 30, 30);
                    Parent.greenButton.Frame = new CGRect(Parent.parentView.Frame.Width - 170, 7, 30, 30);
                    Parent.grayButton.Frame = new CGRect(Parent.parentView.Frame.Width - 220, 7, 30, 30);
                    Parent.blackButton.Frame = new CGRect(Parent.parentView.Frame.Width - 260, 7, 30, 30);
                    Parent.yellowButton.Frame = new CGRect(Parent.parentView.Frame.Width - 310, 7, 30, 30);
                    Parent.whiteButton.Frame = new CGRect(Parent.parentView.Frame.Width - 350, 7, 30, 30);
                    if (Parent.annotation is InkAnnotation || Parent.pdfViewerControl.AnnotationMode == AnnotationMode.Ink)
                    {
                        Parent.opacitybutton.Frame = new CGRect(Parent.parentView.Frame.Width - 50, 7, 35, 35);
                        Parent.opacitybutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
                        Parent.opacitybutton.Font = Parent.highFont;
                        Parent.opacitybutton.SetTitle("\ue71a", UIControlState.Normal);
                        if (Parent.annotation != null)
                            Parent.opacitybutton.SetTitleColor((Parent.annotation as InkAnnotation).Settings.Color, UIControlState.Normal);
                        else
                            Parent.opacitybutton.SetTitleColor(Parent.pdfViewerControl.AnnotationSettings.Ink.Color, UIControlState.Normal);
                        Parent.colorToolbar.AddSubview(Parent.opacitybutton);
                    }

                }
                else
                {
                    Parent.opacitybutton.RemoveFromSuperview();
                }
                Parent.colorToolbar = Parent.UpdateToolbarBorder(Parent.colorToolbar, Parent.colorFrame);
                Parent.opacityPanel.RemoveFromSuperview();
                Parent.isOpacitySelected = false;
                Parent.Add(Parent.colorToolbar);

            }
            else
            {
                Parent.opacitybutton.RemoveFromSuperview();
                Parent.colorToolbar.RemoveFromSuperview();
                Parent.opacityPanel.RemoveFromSuperview();
                Parent.isColorSelected = false;
                Parent.isOpacitySelected = false;
            }

        }
    }
}