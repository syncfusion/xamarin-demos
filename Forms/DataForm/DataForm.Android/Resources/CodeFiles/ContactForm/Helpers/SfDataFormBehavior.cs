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
using SampleBrowser.Core;

namespace SampleBrowser.SfDataForm
{
    public class SfDataFormBehavior : Behavior<ContentPage>
    {
        private Syncfusion.XForms.DataForm.SfDataForm dataForm;
        private ListViewGroupingViewModel viewModel;
        private Button contactLabel;
        private Button editAndDoneButton;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            dataForm = bindable.FindByName<Syncfusion.XForms.DataForm.SfDataForm>("dataForm");
            dataForm.LayoutManager = new DataFormLayoutManagerExt(dataForm);
            contactLabel = bindable.FindByName<Button>("contactLabel");
            editAndDoneButton = bindable.FindByName<Button>("editButton");
            dataForm.BindingContextChanged += OnBindingContextChanged;
            viewModel = bindable.BindingContext as ListViewGroupingViewModel;            
            dataForm.AutoGeneratingDataFormItem += OnAutoGeneratingDataFormItem;
            dataForm.Validating += OnValidating;
            base.OnAttachedTo(bindable);
        }

        private void OnValidating(object sender, ValidatingEventArgs e)
        {
            if(e.PropertyName.Equals("ContactNumber"))
            {
                if (e.Value != null && e.Value.ToString().Length > 10)
                {
                    e.ErrorMessage = "Phone number should not exceed 10 digits.";
                    e.IsValid = false;
                }
            }
        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            viewModel = dataForm.BindingContext as ListViewGroupingViewModel;
            viewModel.RefreshLayout = false;
            viewModel.IsVisible = true;
            if (viewModel.IsNewContact)
            {
                dataForm.IsReadOnly = false;
                contactLabel.Text = "Add Contact";                
                viewModel.IsNewContact = false;
                editAndDoneButton.Text = "Done";            
            }
        }

        /// <summary>
        /// Raised to set read only property and cancel the some properties.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {
            if (e.DataFormItem != null)
            {
                if (!viewModel.RefreshLayout)
                {
                    if (e.DataFormItem.Name.Equals("MiddleName") || e.DataFormItem.Name.Equals("LastName"))
                        e.Cancel = true;
                }
                if (e.DataFormItem.Name.Equals("ContactNumber"))
                {
                    (e.DataFormItem as DataFormTextItem).KeyBoard = Keyboard.Numeric;
                    e.DataFormItem.ImageSource = ImagePathConverter.GetImageSource("SampleBrowser.SfDataForm.DataForm_Phone.png");
                }
                else if (e.DataFormItem.Name.Equals("Email"))
                {
                    (e.DataFormItem as DataFormTextItem).KeyBoard = Keyboard.Email;
                    e.DataFormItem.ImageSource = ImagePathConverter.GetImageSource("SampleBrowser.SfDataForm.Email.png");
                }
                else if (e.DataFormItem.Name.Equals("ContactName"))
                {
                    e.DataFormItem.ImageSource = ImagePathConverter.GetImageSource("SampleBrowser.SfDataForm.LabelContactName.png");
                }
                else if (e.DataFormItem.Name.Equals("ContactImage"))
                {
                    e.Cancel = true;
                }
                else if (e.DataFormItem.Name.Equals("BirthDate"))
                {
                    e.DataFormItem.ImageSource = ImagePathConverter.GetImageSource("SampleBrowser.SfDataForm.BirthDate.png");
                }
                else if (e.DataFormItem.Name.Equals("GroupName"))
                {
                    e.DataFormItem.ImageSource = ImagePathConverter.GetImageSource("SampleBrowser.SfDataForm.Group.png");
                }
                else if (e.DataFormItem.Name.Equals("Address"))
                {
                    e.DataFormItem.ImageSource = ImagePathConverter.GetImageSource("SampleBrowser.SfDataForm.Address.png");
                }
            }
            if (e.DataFormGroupItem != null)
                e.DataFormGroupItem.AllowExpandCollapse = false;
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            this.contactLabel.Text = "EditContact";            
            dataForm.AutoGeneratingDataFormItem -= OnAutoGeneratingDataFormItem;
            dataForm.BindingContextChanged -= OnBindingContextChanged;
			dataForm.Validating -= OnValidating;
        }
    }
}
