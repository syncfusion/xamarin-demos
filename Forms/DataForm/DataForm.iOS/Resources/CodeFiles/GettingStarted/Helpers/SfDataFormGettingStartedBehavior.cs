#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.XForms.DataForm;
using Xamarin.Forms;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfDataForm
{
    public class SfDataFormGettingStartedBehavior : Behavior<Syncfusion.XForms.DataForm.SfDataForm>
    {
        private Syncfusion.XForms.DataForm.SfDataForm dataForm;
        protected override void OnAttachedTo(Syncfusion.XForms.DataForm.SfDataForm bindable)
        {
            dataForm = bindable;
            dataForm.AutoGeneratingDataFormItem += OnAutoGeneratingDataFormItem;            
            dataForm.BindingContextChanged += OnBindingContextChanged;
            base.OnAttachedTo(bindable);            
        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            (dataForm.DataObject as INotifyPropertyChanged).PropertyChanged += OnPropertyChanged;
        }

        private void OnAutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {
            if (e.DataFormItem != null)
            {
                if (e.DataFormItem.Name.Equals("HasErrors"))
                    e.Cancel = true;
                else if (e.DataFormItem.Name.Equals("AccountNumber") || e.DataFormItem.Name.Equals("AccountNumber1"))
                    (e.DataFormItem as DataFormTextItem).KeyBoard = Keyboard.Numeric;
                else if (e.DataFormItem.Name.Equals("Email"))
                    (e.DataFormItem as DataFormTextItem).KeyBoard = Keyboard.Email;
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
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

        protected override void OnDetachingFrom(Syncfusion.XForms.DataForm.SfDataForm bindable)
        {
            base.OnDetachingFrom(bindable);
            dataForm.AutoGeneratingDataFormItem -= OnAutoGeneratingDataFormItem;
            (dataForm.DataObject as INotifyPropertyChanged).PropertyChanged -= OnPropertyChanged;
            dataForm.BindingContextChanged -= OnBindingContextChanged;
            dataForm = null;
        }
    }
}
 