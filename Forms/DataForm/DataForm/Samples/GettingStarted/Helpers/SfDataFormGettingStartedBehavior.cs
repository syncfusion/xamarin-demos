#region Copyright
// <copyright file="SfDataFormGettingStartedBehavior.cs" company="Syncfusion"> 
//  Copyright (c) Syncfusion Inc. 2001 - 2020. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace SampleBrowser.SfDataForm
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Syncfusion.XForms.DataForm;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    /// <summary>
    /// Represents the behavior of the data form getting started sample.
    /// </summary>
    public class SfDataFormGettingStartedBehavior : Behavior<Syncfusion.XForms.DataForm.SfDataForm>
    {
        /// <summary>
        /// DataForm control to edit the data fields of any data object
        /// </summary>
        private Syncfusion.XForms.DataForm.SfDataForm dataForm;

        /// <summary>
        /// Attaches to the superclass and then calls the OnAttachedTo method on this object.
        /// </summary>
        /// <param name="bindable">The bindable object to which the behavior was attached.</param>
        protected override void OnAttachedTo(Syncfusion.XForms.DataForm.SfDataForm bindable)
        {
            this.dataForm = bindable;
            this.dataForm.AutoGeneratingDataFormItem += this.OnAutoGeneratingDataFormItem;
            this.dataForm.BindingContextChanged += this.OnBindingContextChanged;
            base.OnAttachedTo(bindable);
        }

        /// <summary>
        /// Calls the OnDetachingFrom method and then detaches from the superclass.
        /// </summary>
        /// <param name="bindable">The bindable object from which the behavior was detached.</param>
        protected override void OnDetachingFrom(Syncfusion.XForms.DataForm.SfDataForm bindable)
        {
            base.OnDetachingFrom(bindable);
            this.dataForm.AutoGeneratingDataFormItem -= this.OnAutoGeneratingDataFormItem;
            (this.dataForm.DataObject as INotifyPropertyChanged).PropertyChanged -= this.OnPropertyChanged;
            this.dataForm.BindingContextChanged -= this.OnBindingContextChanged;
            this.dataForm = null;
        }

        /// <summary>
        /// Occurs when binding context of the data form is changed.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments of binding context.</param>
        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            (this.dataForm.DataObject as INotifyPropertyChanged).PropertyChanged += this.OnPropertyChanged;
        }

        /// <summary>
        /// Occurs during the auto generation of the data form item.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Data form item event arguments.</param>
        private void OnAutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {
            if (e.DataFormItem != null)
            {
                if (e.DataFormItem.Name.Equals("HasErrors"))
                {
                    e.Cancel = true;
                }
                else if (e.DataFormItem.Name.Equals("AccountNumber") || e.DataFormItem.Name.Equals("AccountNumber1"))
                {
                    (e.DataFormItem as DataFormTextItem).KeyBoard = Keyboard.Numeric;
                }
                else if (e.DataFormItem.Name.Equals("Email"))
                {
                    (e.DataFormItem as DataFormTextItem).KeyBoard = Keyboard.Email;
                }
                else if (e.DataFormItem.Name.Equals("Agree"))
                {
                    e.DataFormItem.LayoutOptions = LayoutType.Default;
                    (e.DataFormItem as DataFormCheckBoxItem).IsThreeState = false;
                    (e.DataFormItem as DataFormCheckBoxItem).Text = "I agree to the Terms & Conditions";
                }

                if (!e.DataFormItem.Name.Equals("AccountType"))
                {
                    e.DataFormItem.TextInputLayoutSettings = new TextInputLayoutSettings()
                    {
                        ReserveSpaceForAssistiveLabels = true
                    };
                }
            }
        }

        /// <summary>
        /// Occurs when propery value is changed.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Property changed event arguments.</param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("AccountNumber"))
            {
                var value = (string)sender.GetType().GetProperty("AccountNumber1").GetValue(sender);
                if (!string.IsNullOrEmpty(value))
                {
                    this.dataForm.Validate("AccountNumber1");
                }
            }
            else if (e.PropertyName.Equals("AccountNumber1"))
            {
                var value = (string)sender.GetType().GetProperty("AccountNumber").GetValue(sender);
                if (!string.IsNullOrEmpty(value))
                {
                    this.dataForm.Validate("AccountNumber");
                }
            }
        }
    }
}