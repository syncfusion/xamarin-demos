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

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Syncfusion.Android.DataForm;
using Android.Graphics;
using Android.Views.InputMethods;
using System.ComponentModel;

namespace SampleBrowser
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public class DataFormGettingStarted : SamplePage
    {
        private SfDataForm dataForm;
        private Context context;
        private Button transferButton;

        public override View GetSampleContent(Context context)
        {
            this.context = context;

            //// Get our button from the layout resource,
            //// and attach an event to it

            var dataFormParentViewLayout = new LinearLayout(context);
            dataFormParentViewLayout.Orientation = Orientation.Vertical;

            var titlebarLayout = LayoutInflater.From(context).Inflate(Resource.Layout.TitleBarLayout, null);
            titlebarLayout = titlebarLayout.FindViewById<RelativeLayout>(Resource.Id.titleRelativeLayout);

            dataForm = new SfDataForm(context);
            dataForm.AutoGeneratingDataFormItem += DataForm_AutoGeneratingDataFormItem;
            dataForm.RegisterEditor("AccountType", "DropDown");
            dataForm.LabelPosition = LabelPosition.Top;
            dataForm.CommitMode = CommitMode.LostFocus;
            dataForm.ValidationMode = ValidationMode.Explicit;
            dataForm.DataObject = new RecipientInfo();
            (dataForm.DataObject as INotifyPropertyChanged).PropertyChanged += DataFormGettingStarted_PropertyChanged;
            transferButton = titlebarLayout.FindViewById<Button>(Resource.Id.label);
            transferButton.Text = "TRANSFER MONEY";

            transferButton.SetBackgroundColor(Color.ParseColor("#2196F3"));
            transferButton.SetTextColor(Color.ParseColor("#FFFFFF"));
            transferButton.Click += Label_Click;
            dataFormParentViewLayout.AddView(dataForm);
            dataForm.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent, 1.0f);
            dataFormParentViewLayout.AddView(titlebarLayout, new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, 150));
            return dataFormParentViewLayout;
        }

        private void DataFormGettingStarted_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("AccountNumber"))
            {
                var value = (string)sender.GetType().GetProperty("AccountNumber1").GetValue(sender);
                if (!string.IsNullOrEmpty(value))
                {
                    dataForm.Validate("AccountNumber1");
                }
            }
            else if (e.PropertyName.Equals("AccountNumber1"))
            {
                var value = (string)sender.GetType().GetProperty("AccountNumber").GetValue(sender);
                if (!string.IsNullOrEmpty(value))
                {
                    dataForm.Validate("AccountNumber");
                }
            }
        }

        private void DataForm_AutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {
            if (e.DataFormItem != null)
            {
                if (e.DataFormItem.Name.Equals("AccountNumber") || e.DataFormItem.Name.Equals("AccountNumber1"))
                {
                    (e.DataFormItem as DataFormTextItem).InputType = Android.Text.InputTypes.ClassNumber;
                }
                else if (e.DataFormItem.Name.Equals("Email"))
                {
                    (e.DataFormItem as DataFormTextItem).InputType = Android.Text.InputTypes.TextVariationEmailAddress;
                }
                else if (e.DataFormItem.Name.Equals("SWIFT"))
                {
                    (e.DataFormItem as DataFormTextItem).InputType = Android.Text.InputTypes.TextFlagCapCharacters;
                }
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            var isValid = dataForm.Validate();
            dataForm.Commit();

            if (!isValid)
            {
                Toast.MakeText(context, "Please enter valid details", ToastLength.Long).Show();
                return;
            }

            Toast.MakeText(context, "Money Transferred", ToastLength.Long).Show();
            dataForm.IsReadOnly = true;
            transferButton.Enabled = false;
        }

        public override void Destroy()
        {
            if(this.dataForm != null)
            {
                (this.dataForm.DataObject as INotifyPropertyChanged).PropertyChanged -= DataFormGettingStarted_PropertyChanged;
                this.dataForm.AutoGeneratingDataFormItem -= DataForm_AutoGeneratingDataFormItem;
                this.dataForm.Dispose();
                this.dataForm = null;
            }
            
            if (this.transferButton != null)
            {
                this.transferButton.Dispose();
                this.transferButton = null;
            }
        }
    }
}