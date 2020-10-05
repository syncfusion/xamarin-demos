#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
    using Syncfusion.XForms.DataForm;
using Syncfusion.XForms.DataForm.Editors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Syncfusion.XForms.ComboBox;

namespace SampleBrowser.SfDataForm
{
    /// <summary>
    /// Represents the behavior of the data form getting started sample.
    /// </summary>
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class SfDataFormDynamicFormBehavior : Behavior<Syncfusion.XForms.DataForm.SfDataForm>
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
            this.dataForm.SourceProvider = new SourceProviderExt();
            this.dataForm.ColumnCount = 4;

            dataForm.RegisterEditor("Team", "DropDown");
            dataForm.RegisterEditor("Trackhours", "Switch");
            dataForm.RegisterEditor("Country", "AutoComplete");
            dataForm.RegisterEditor("EcommerceCountry", "AutoComplete");
            dataForm.RegisterEditor("OrganizationCountry", "AutoComplete");
            dataForm.AutoGeneratingDataFormItem += DataForm_AutoGeneratingDataFormItem;
            base.OnAttachedTo(bindable);
        }

        /// <summary>
        /// Occurs during the auto generation of the data form item.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Data form item event arguments.</param>
        private void DataForm_AutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {
            if(e.DataFormItem != null) 
            {
                if (e.DataFormItem.Name.Equals("Trackhours"))
                {
                   e.DataFormItem.LayoutOptions = LayoutType.Default;

                }
                else if (e.DataFormItem.Name.Equals("CCV"))
                {
                    var maskedItem = e.DataFormItem as DataFormMaskedEditTextItem;
                    maskedItem.Mask = "000";
                    maskedItem.PromptChar = '*';
                    maskedItem.KeyBoard = Keyboard.Numeric;
                }
                else if (e.DataFormItem.Name.Equals("CardNumber"))
                {
                    var maskedItem = e.DataFormItem as DataFormMaskedEditTextItem;
                    maskedItem.Mask = "0000-0000-0000-0000";
                    maskedItem.KeyBoard = Keyboard.Numeric;
                }
                else if (e.DataFormItem.Name.Equals("ExpirationDate"))
                {
                    var maskedItem = e.DataFormItem as DataFormMaskedEditTextItem;
                    maskedItem.Mask = "00/00";
                    maskedItem.KeyBoard = Keyboard.Numeric;
                }
                else if (e.DataFormItem.Name.Equals("EmployeeZip") || e.DataFormItem.Name.Equals("Zip") || e.DataFormItem.Name.Equals("ZipCode"))
                {
                    var maskedItem = e.DataFormItem as DataFormMaskedEditTextItem;
                    maskedItem.Mask = "000000";
                    maskedItem.PromptChar = '_';
                    maskedItem.KeyBoard = Keyboard.Numeric;
                }
                else if (e.DataFormItem.Name.Equals("Code"))
                {
                    var maskedItem = e.DataFormItem as DataFormMaskedEditTextItem;
                    maskedItem.Mask = "000";
                    maskedItem.PromptChar = '_';
                    maskedItem.KeyBoard = Keyboard.Numeric;
                }
                else if (e.DataFormItem.Name.Equals("PhoneNumber") || e.DataFormItem.Name.Equals("Phone"))
                {
                    var item = (e.DataFormItem as DataFormMaskedEditTextItem);
                    item.Mask = "+(00)0000000000";
                    item.KeyBoard = Keyboard.Telephone;
                }
                else if (e.DataFormItem.Name.Equals("ContactEmail"))
                {
                    var textItem = e.DataFormItem as DataFormTextItem;
                    textItem.KeyBoard = Keyboard.Email;
                }
                else if (e.DataFormItem.Name.Equals("Country") || e.DataFormItem.Name.Equals("EcommerceCountry") || e.DataFormItem.Name.Equals("OrganizationCountry"))
                {
                    var autoCompleteItem = e.DataFormItem as DataFormAutoCompleteItem;
                    autoCompleteItem.TextHighlightMode = Syncfusion.XForms.DataForm.OccurrenceMode.FirstOccurrence;
                    autoCompleteItem.HighlightedTextColor = Color.Red;
                }


                if (this.dataForm.DataObject is EmployeeForm)
                {
                    e.DataFormItem.TextInputLayoutSettings = new TextInputLayoutSettings()
                    {
                        OutlineCornerRadius = 30,
                        ReserveSpaceForAssistiveLabels = false,
                        ShowHelperText = false,
                    };
                    e.DataFormItem.HintLabelStyle = new LabelStyle()
                    {
                        FontSize = 18
                    };
                }
                else
                {
                    e.DataFormItem.TextInputLayoutSettings = new TextInputLayoutSettings()
                    {
                        ReserveSpaceForAssistiveLabels = false,
                        ShowHelperText = false
                    };
                }

                if(e.DataFormItem.Name.Equals("OrganizationName") || e.DataFormItem.Name.Equals("AddressLine1") || e.DataFormItem.Name.Equals("AddressLine2") || (e.DataFormItem.Name.Equals("ContactEmail") || (e.DataFormItem.Name.Equals("OrganizationCountry"))))
                {
                    e.DataFormItem.ColumnSpan = 4;
                }
            }
        }

        /// <summary>
        /// Calls the OnDetachingFrom method and then detaches from the superclass.
        /// </summary>
        /// <param name="bindable">The bindable object from which the behavior was detached.</param>
        protected override void OnDetachingFrom(Syncfusion.XForms.DataForm.SfDataForm bindable)
        {
            base.OnDetachingFrom(bindable);
            dataForm.AutoGeneratingDataFormItem -= DataForm_AutoGeneratingDataFormItem;
            this.dataForm = null;
        }
    }


}
