#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using CoreAnimation;
using CoreGraphics;
using Foundation;
using Syncfusion.Calculate;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace SampleBrowser
{
    public class FunctionsLibraryView : UIScrollView
    {
        #region Fields

        UIPickerView functionsPicker;
        UILabel titleLabel;
        UILabel descripLabel;
        UILabel functionLabel;
        UILabel formulaLabel;
        UILabel calculatedLabel;
        UILabel label00;
        UILabel labelA0;
        UILabel labelB0;
        UILabel labelC0;
        UILabel label01;
        UILabel label02;
        UILabel label03;
        UILabel label04;
        UILabel label05;
        UITextField textA1;
        UITextField textB1;
        UITextField textC1;
        UITextField textA2;
        UITextField textB2;
        UITextField textC2;
        UITextField textA3;
        UITextField textB3;
        UITextField textC3;
        UITextField textA4;
        UITextField textB4;
        UITextField textC4;
        UITextField textA5;
        UITextField textB5;
        UITextField textC5;
        UITextField formulaText = new UITextField();
        UILabel calculatedText;
        CALayer layer;
        UIButton calculateButton;
        UITextField pickerTextView;
        CalcData calcData;
        NSObject showNotification;
        NSObject hideNotification;

        #endregion

        #region Property

        internal CalcEngine Engine
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        public FunctionsLibraryView()
        {
            InitializeEngine();
            Initilizeview();
            RegisterForKeyboardNotifications();
        }

        #endregion

        #region Methods

        private void Initilizeview()
        {
            #region Header 

            titleLabel = new UILabel();
            titleLabel.Text = "Functions Library";
            titleLabel.Font = UIFont.FromName("Helvetica-Bold", 25f);
            titleLabel.TextAlignment = UITextAlignment.Center;

            descripLabel = new UILabel();
            descripLabel.Text = "This sample demonstrates the calculation using various Excel-like functions.";
            descripLabel.Lines = 0;
            descripLabel.LineBreakMode = UILineBreakMode.WordWrap;
            descripLabel.Font = UIFont.FromName("Helvetica", 12f);

            #endregion

            #region Functions

            functionLabel = new UILabel();
            functionLabel.Text = "Select a function";
            functionLabel.Font = UIFont.FromName("Helvetica", 14f);

            pickerTextView = new UITextField();
            pickerTextView.Text = "ABS";
            pickerTextView.Font = UIFont.FromName("Helvetica", 14f);
            FunctionsLibraryViewModel model = new FunctionsLibraryViewModel(formulaText, pickerTextView, this);
            functionsPicker = new UIPickerView();
            functionsPicker.Model = model;
            pickerTextView.InputView = functionsPicker;

            #endregion

            #region GridView 

            label00 = CreateLabel("");
            labelA0 = CreateLabel("A");
            labelB0 = CreateLabel("B");
            labelC0 = CreateLabel("C");
            label01 = CreateLabel("1");
            label02 = CreateLabel("2");
            label03 = CreateLabel("3");
            label04 = CreateLabel("4");
            label05 = CreateLabel("5");
            textA1 = CreateTextField("32");
            textB1 = CreateTextField("50");
            textC1 = CreateTextField("10");
            textA2 = CreateTextField("12");
            textB2 = CreateTextField("24");
            textC2 = CreateTextField("90");
            textA3 = CreateTextField("88");
            textB3 = CreateTextField("-22");
            textC3 = CreateTextField("37");
            textA4 = CreateTextField("73");
            textB4 = CreateTextField("91");
            textC4 = CreateTextField("21");
            textA5 = CreateTextField("63");
            textB5 = CreateTextField("29");
            textC5 = CreateTextField("44");

            #endregion

            #region Formula

            formulaLabel = new UILabel();
            formulaLabel.Text = "Formula";
            formulaLabel.Font = UIFont.FromName("Helvetica", 14f);

            formulaText.BorderStyle = UITextBorderStyle.Line;
            formulaText.Text = "=ABS(B3)";
            formulaText.Font = UIFont.FromName("Helvetica", 14f);
            formulaText.ResignFirstResponder();

            #endregion

            #region Compute

            calculateButton = new UIButton();
            calculateButton.SetTitle("Compute", UIControlState.Normal);
            calculateButton.Layer.BorderWidth = 1;
            calculateButton.Layer.CornerRadius = 4;
            calculateButton.SetTitleColor(UIColor.Black, UIControlState.Highlighted);
            calculateButton.BackgroundColor = UIColor.LightGray;
            calculateButton.TouchUpInside += CalculateButton_TouchUpInside;

            #endregion

            #region Result

            calculatedLabel = new UILabel();
            calculatedLabel.Text = "Computed Value";
            calculatedLabel.Font = UIFont.FromName("Helvetica", 14f);

            layer = new CALayer() { BorderWidth = 1, BorderColor = UIColor.Black.CGColor };

            calculatedText = new UILabel();
            calculatedText.Font = UIFont.FromName("Helvetica", 14f);
            calculatedText.Layer.AddSublayer(layer);

            #endregion

            AddSubview(titleLabel);
            AddSubview(descripLabel);
            AddSubview(functionLabel);
            AddSubview(pickerTextView);

            AddSubview(label00);
            AddSubview(labelA0);
            AddSubview(labelB0);
            AddSubview(labelC0);

            AddSubview(label01);
            AddSubview(textA1);
            AddSubview(textB1);
            AddSubview(textC1);

            AddSubview(label02);
            AddSubview(textA2);
            AddSubview(textB2);
            AddSubview(textC2);

            AddSubview(label03);
            AddSubview(textA3);
            AddSubview(textB3);
            AddSubview(textC3);

            AddSubview(label04);
            AddSubview(textA4);
            AddSubview(textB4);
            AddSubview(textC4);

            AddSubview(label05);
            AddSubview(textA5);
            AddSubview(textB5);
            AddSubview(textC5);

            AddSubview(formulaLabel);
            AddSubview(formulaText);

            AddSubview(calculateButton);
            AddSubview(calculatedLabel);
            AddSubview(calculatedText);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            var width = Frame.Width - 20;

            this.ContentSize = new CGSize(this.Frame.Width, 560);

            titleLabel.Frame = new CGRect(5, 15, width, 25);
            descripLabel.Frame = new CGRect(5, 45, width, 30);
            functionLabel.Frame = new CGRect(5, 70, width / 2, 40);
            pickerTextView.Frame = new CGRect((width / 2) + 5, 76, width / 2, 30);

            var startCellWidth = width * 0.1;
            var cellWidth = (width - startCellWidth) / 3;
            var xpos = 5;

            label00.Frame = new CGRect(xpos, 115, startCellWidth, 30);
            label01.Frame = new CGRect(xpos, 145, startCellWidth, 30);
            label02.Frame = new CGRect(xpos, 175, startCellWidth, 30);
            label03.Frame = new CGRect(xpos, 205, startCellWidth, 30);
            label04.Frame = new CGRect(xpos, 235, startCellWidth, 30);
            label05.Frame = new CGRect(xpos, 265, startCellWidth, 30);

            xpos += (int)startCellWidth;
            labelA0.Frame = new CGRect(xpos, 115, cellWidth, 30);
            textA1.Frame = new CGRect(xpos, 145, cellWidth, 30);
            textA2.Frame = new CGRect(xpos, 175, cellWidth, 30);
            textA3.Frame = new CGRect(xpos, 205, cellWidth, 30);
            textA4.Frame = new CGRect(xpos, 235, cellWidth, 30);
            textA5.Frame = new CGRect(xpos, 265, cellWidth, 30);

            xpos += (int)cellWidth;
            labelB0.Frame = new CGRect(xpos, 115, cellWidth, 30);
            textB1.Frame = new CGRect(xpos, 145, cellWidth, 30);
            textB2.Frame = new CGRect(xpos, 175, cellWidth, 30);
            textB3.Frame = new CGRect(xpos, 205, cellWidth, 30);
            textB4.Frame = new CGRect(xpos, 235, cellWidth, 30);
            textB5.Frame = new CGRect(xpos, 265, cellWidth, 30);

            xpos += (int)cellWidth;
            labelC0.Frame = new CGRect(xpos, 115, cellWidth, 30);
            textC1.Frame = new CGRect(xpos, 145, cellWidth, 30);
            textC2.Frame = new CGRect(xpos, 175, cellWidth, 30);
            textC3.Frame = new CGRect(xpos, 205, cellWidth, 30);
            textC4.Frame = new CGRect(xpos, 235, cellWidth, 30);
            textC5.Frame = new CGRect(xpos, 265, cellWidth, 30);

            formulaLabel.Frame = new CGRect(5, 305, width / 2, 30);
            formulaText.Frame = new CGRect((width / 2) + 5, 305, width / 2, 30);

            calculateButton.Frame = new CGRect(5, 350, width, 30);
            calculatedLabel.Frame = new CGRect(5, 390, width / 2, 30);
            calculatedText.Frame = new CGRect((width / 2) + 5, 390, width / 2, 30);
            layer.Frame = new CGRect(calculatedText.Bounds.Left, calculatedText.Bounds.Bottom - 5, calculatedText.Bounds.Right, 1);
        }

        private void InitializeEngine()
        {
            calcData = new CalcData();
            Engine = new CalcEngine(calcData);
            Engine.UseNoAmpersandQuotes = true;
            int i = CalcEngine.CreateSheetFamilyID();
            Engine.RegisterGridAsSheet("CalcData", calcData, i);

        }

        private UILabel CreateLabel(string text)
        {
            return new UILabel()
            {
                Text = text,
                TextAlignment = UITextAlignment.Center,
                Font = UIFont.FromName("Helvetica", 14f)
            };
        }

        private UITextField CreateTextField(string text)
        {
            return new UITextField()
            {
                Text = text,
                TextAlignment = UITextAlignment.Center,
                KeyboardType = UIKeyboardType.PhonePad,
                Font = UIFont.FromName("Helvetica", 14f)
            };
        }

        private void CalculateButton_TouchUpInside(object sender, EventArgs e)
        {
            this.EndEditing(true);

            calcData.SetValueRowCol(textA1.Text, 1, 1);
            calcData.SetValueRowCol(textA2.Text, 2, 1);
            calcData.SetValueRowCol(textA3.Text, 3, 1);
            calcData.SetValueRowCol(textA4.Text, 4, 1);
            calcData.SetValueRowCol(textA5.Text, 5, 1);
            calcData.SetValueRowCol(textB1.Text, 1, 2);
            calcData.SetValueRowCol(textB2.Text, 2, 2);
            calcData.SetValueRowCol(textB3.Text, 3, 2);
            calcData.SetValueRowCol(textB4.Text, 4, 2);
            calcData.SetValueRowCol(textB5.Text, 5, 2);
            calcData.SetValueRowCol(textC1.Text, 1, 3);
            calcData.SetValueRowCol(textC2.Text, 2, 3);
            calcData.SetValueRowCol(textC3.Text, 3, 3);
            calcData.SetValueRowCol(textC4.Text, 4, 3);
            calcData.SetValueRowCol(textC5.Text, 5, 3);

            calculatedText.Text = Engine.ParseAndComputeFormula(formulaText.Text);
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            this.EndEditing(true);
        }

        protected virtual void RegisterForKeyboardNotifications()
        {
            hideNotification = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, OnKeyboardNotification);
            showNotification = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification, OnKeyboardNotification);
        }

        private void OnKeyboardNotification(NSNotification notification)
        {
            var visible = notification.Name == UIKeyboard.WillShowNotification;
            var keyboardFrame = visible
                ? UIKeyboard.FrameEndFromNotification(notification)
                : UIKeyboard.FrameBeginFromNotification(notification);

            if (visible)
                this.SetContentOffset(new CGPoint(this.Frame.Left, (this.Frame.Height - keyboardFrame.Height) / 2), false);
            else
                this.SetContentOffset(new CGPoint(this.Frame.Left, this.Frame.Top), false);
        }

        protected override void Dispose(bool disposing)
        {
            calcData = null;
            if (Engine != null)
            {
                Engine.Dispose();
                Engine = null;
            }

            NSNotificationCenter.DefaultCenter.RemoveObserver(showNotification);
            NSNotificationCenter.DefaultCenter.RemoveObserver(hideNotification);

            base.Dispose(disposing);
        }

        #endregion
    }
}
