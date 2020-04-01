#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;
using Syncfusion.iOS.DataForm;
using System.ComponentModel;

namespace SampleBrowser
{
    public class FormGettingStarted : SampleView
    {
        #region Field

        SfDataForm dataForm;
        UIButton button;
        UIScrollView scrollView;

        #endregion

        #region Constructor

        public FormGettingStarted()
        {
            dataForm = new SfDataForm();
            dataForm.AutoGeneratingDataFormItem += DataForm_AutoGeneratingDataFormItem;
            dataForm.DataObject = new RecipientInfo();
            (dataForm.DataObject as INotifyPropertyChanged).PropertyChanged += DataFormGettingStarted_PropertyChanged;
            dataForm.LabelPosition = LabelPosition.Top;
            button = new UIButton();

            button.SetTitle("Transfer Money", UIControlState.Normal);
            button.SetTitleColor(this.TintColor, UIControlState.Normal);
            button.TouchDown += Button_TouchDown;

            scrollView = new UIScrollView();
            scrollView.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
            this.AddSubview(scrollView);
            scrollView.AddSubview(this.dataForm);
            scrollView.AddSubview(button);          
        }

        private void DataFormGettingStarted_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("AccountNumber"))
            {
                var value = (string)sender.GetType().GetProperty("AccountNumber1").GetValue(sender);
                if (!string.IsNullOrEmpty(value))
                    dataForm.Validate("AccountNumber1");
            }
            else if (e.PropertyName.Equals("AccountNumber1"))
            {
                var value = (string)sender.GetType().GetProperty("AccountNumber").GetValue(sender);
                if (!string.IsNullOrEmpty(value))
                    dataForm.Validate("AccountNumber");
            }
        }

        private void DataForm_AutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {
            if (e.DataFormItem != null)
            {
                if (e.DataFormItem.Name.Equals("AccountNumber") || e.DataFormItem.Name.Equals("AccountNumber1"))
                    (e.DataFormItem as DataFormTextItem).KeyBoardType = UIKeyboardType.NumberPad;
                else if (e.DataFormItem.Name.Equals("Email"))
                    (e.DataFormItem as DataFormTextItem).KeyBoardType = UIKeyboardType.EmailAddress;
                else if (e.DataFormItem.Name.Equals("SWIFT"))
                    (e.DataFormItem as DataFormTextItem).AutocapitalizationType = UITextAutocapitalizationType.AllCharacters;
            }
        }

        private void Button_TouchDown(object sender, EventArgs e)
        {
            var isValid = dataForm.Validate();
            dataForm.Commit();

            if (!isValid)
                return;

            dataForm.IsReadOnly = true;
            button.Hidden = true;
        }

        #endregion

        public override void LayoutSubviews()
        {
            scrollView.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
            this.dataForm.Frame = new CGRect(0, 0, this.scrollView.Frame.Width, this.scrollView.Frame.Height - 30);
            this.button.Frame = new CGRect(0, this.scrollView.Frame.Height - 30, this.scrollView.Frame.Width, 30);
            base.LayoutSubviews();
        }
    }
}
