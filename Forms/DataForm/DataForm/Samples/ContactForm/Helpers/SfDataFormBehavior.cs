#region Copyright
// <copyright file="SfDataFormBehavior.cs" company="Syncfusion"> 
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
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SampleBrowser.Core;
    using Syncfusion.XForms.DataForm;
    using Xamarin.Forms;

    /// <summary>
    /// User defined behaviour to respond arbitrary conditions and events of DataForm.
    /// </summary>
    public class SfDataFormBehavior : Behavior<ContentPage>
    {
        /// <summary>
        /// DataForm control to edit the data fields of any data object
        /// </summary>
        private Syncfusion.XForms.DataForm.SfDataForm dataForm;

        /// <summary>
        /// Represents the view model of the <see cref="ContactListViewModel" /> class.
        /// </summary>
        private ContactListViewModel viewModel;

        /// <summary>
        /// Represents the contact label button.
        /// </summary>
        private Button contactLabel;

        /// <summary>
        /// Represents the edit and done button.
        /// </summary>
        private Button editAndDoneButton;

        /// <summary>
        /// Attaches to the superclass and then calls the OnAttachedTo method on this object.
        /// </summary>
        /// <param name="bindable">The bindable object to which the behavior was attached.</param>
        protected override void OnAttachedTo(ContentPage bindable)
        {
            this.dataForm = bindable.FindByName<Syncfusion.XForms.DataForm.SfDataForm>("dataForm");
            this.dataForm.LayoutManager = new DataFormLayoutManagerExt(this.dataForm);
            this.contactLabel = bindable.FindByName<Button>("contactLabel");
            this.editAndDoneButton = bindable.FindByName<Button>("editButton");
            this.dataForm.RegisterEditor("SaveTo", "Segment");
            this.dataForm.RegisterEditor("EmailType", "DropDown");
            this.dataForm.RegisterEditor("ContactType", "DropDown");
            this.dataForm.RegisterEditor("AddressTypes", "DropDown");
            this.dataForm.BindingContextChanged += this.OnBindingContextChanged;
            this.viewModel = bindable.BindingContext as ContactListViewModel;
            this.dataForm.AutoGeneratingDataFormItem += this.OnAutoGeneratingDataFormItem;
            this.dataForm.Validating += this.OnValidating;
            base.OnAttachedTo(bindable);
        }

        /// <summary>
        /// Calls the OnDetachingFrom method and then detaches from the superclass.
        /// </summary>
        /// <param name="bindable">The bindable object from which the behavior was detached.</param>
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            this.contactLabel.Text = "EditContact";
            this.dataForm.AutoGeneratingDataFormItem -= this.OnAutoGeneratingDataFormItem;
            this.dataForm.BindingContextChanged -= this.OnBindingContextChanged;
            this.dataForm.Validating -= this.OnValidating;
        }

        /// <summary>
        /// Occurs when Binding context of the data form is changed. 
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments of binding context changed event.</param>
        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            this.viewModel = this.dataForm.BindingContext as ContactListViewModel;
            this.viewModel.RefreshLayout = false;
            this.viewModel.IsVisible = true;
            if (this.viewModel.IsNewContact)
            {
                this.dataForm.IsReadOnly = false;
                this.contactLabel.Text = "Add Contact";
                this.viewModel.IsNewContact = false;
                this.editAndDoneButton.Text = "Done";
            }
        }

        /// <summary>
        /// Validates the value in the data form fields.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments of OnValidating event.</param>
        private void OnValidating(object sender, ValidatingEventArgs e)
        {
            if (e.PropertyName.Equals("ContactNumber"))
            {
                if (e.Value != null && e.Value.ToString().Length > 10)
                {
                    e.ErrorMessage = "Phone number should not exceed 10 digits.";
                    e.IsValid = false;
                }
            }
        }

        /// <summary>
        /// Raised to set read only property and cancel the some properties.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Contains arguments of auto generating data form event</param>
        private void OnAutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {
            if (e.DataFormItem != null)
            {
                if (!this.viewModel.RefreshLayout)
                {
                    if (e.DataFormItem.Name.Equals("MiddleName") || e.DataFormItem.Name.Equals("LastName") || e.DataFormItem.Name.Equals("Notes"))
                    {
                        e.Cancel = true;
                    }
                }

                if (e.DataFormItem.Name.Equals("ContactNumber"))
                {
                    var dataFormMaskedItem = e.DataFormItem as DataFormMaskedEditTextItem;
                    dataFormMaskedItem.KeyBoard = Keyboard.Telephone;
                    dataFormMaskedItem.CutCopyMaskFormat = Syncfusion.XForms.MaskedEdit.MaskFormat.ExcludePromptAndLiterals;
                    dataFormMaskedItem.SkipLiterals = true;
                    dataFormMaskedItem.ValueMaskFormat = Syncfusion.XForms.MaskedEdit.MaskFormat.ExcludePromptAndLiterals;
                    e.DataFormItem.TextInputLayoutSettings = new TextInputLayoutSettings()
                    {
                        LeadingView = new Label()
                        {
                            VerticalTextAlignment = Device.RuntimePlatform == Device.iOS ? TextAlignment.Center : TextAlignment.Start,
                            FontSize = Device.RuntimePlatform == Device.iOS ? 18 : 24,
                            Text = "F",
                            FontFamily = Device.RuntimePlatform == Device.iOS ? "ContactsIcons" :
                                                                   Device.RuntimePlatform == Device.Android ? "ContactsIcons.ttf#ContactsIcons" : "Assets/Fonts/ContactsIcons.ttf#ContactsIcons"
                        },
                        ReserveSpaceForAssistiveLabels = true
                    };
                }
                else if (e.DataFormItem.Name.Equals("Email"))
                {
                    (e.DataFormItem as DataFormTextItem).KeyBoard = Keyboard.Email;
                    e.DataFormItem.TextInputLayoutSettings = new TextInputLayoutSettings()
                    {
                        LeadingView = new Label()
                        {
                            FontSize = Device.RuntimePlatform == Device.iOS ? 18 : 24,
                            Text = "G",
                            FontFamily = Device.RuntimePlatform == Device.iOS ? "ContactsIcons" :
                                                                  Device.RuntimePlatform == Device.Android ? "ContactsIcons.ttf#ContactsIcons" : "Assets/Fonts/ContactsIcons.ttf#ContactsIcons"
                        }
                    };
                }
                else if (e.DataFormItem.Name.Equals("ContactName"))
                {
                    e.DataFormItem.TextInputLayoutSettings = new TextInputLayoutSettings()
                    {
                        LeadingView = new Label()
                        {
                            VerticalTextAlignment = Device.RuntimePlatform == Device.iOS ? TextAlignment.Center : TextAlignment.Start,
                            FontSize = Device.RuntimePlatform == Device.iOS ? 18 : 24,
                            Text = "A",
                            FontFamily = Device.RuntimePlatform == Device.iOS ? "ContactsIcons":Device.RuntimePlatform == Device.Android ? "ContactsIcons.ttf#ContactsIcons" : "Assets/Fonts/ContactsIcons.ttf#ContactsIcons"
                        }
                    };
                }
                else if (e.DataFormItem.Name.Equals("MiddleName"))
                {
                    e.DataFormItem.TextInputLayoutSettings = new TextInputLayoutSettings()
                    {
                        LeadingView = new Label()
                        {
                            VerticalTextAlignment = Device.RuntimePlatform == Device.iOS ? TextAlignment.Center : TextAlignment.Start,
                            FontSize = Device.RuntimePlatform == Device.iOS ? 18 : 24,
                            Text = "A",
                            FontFamily = Device.RuntimePlatform == Device.iOS ? "ContactsIcons":Device.RuntimePlatform == Device.Android ? "ContactsIcons.ttf#ContactsIcons" : "Assets/Fonts/ContactsIcons.ttf#ContactsIcons"
                        }
                    };
                }
                else if (e.DataFormItem.Name.Equals("LastName"))
                {
                    e.DataFormItem.TextInputLayoutSettings = new TextInputLayoutSettings()
                    {
                        LeadingView = new Label()
                        {
                            VerticalTextAlignment = Device.RuntimePlatform == Device.iOS ? TextAlignment.Center : TextAlignment.Start,
                            FontSize = Device.RuntimePlatform == Device.iOS ? 18 : 24,
                            Text = "A",
                            FontFamily = Device.RuntimePlatform == Device.iOS ? "ContactsIcons" :
                                                                   Device.RuntimePlatform == Device.Android ? "ContactsIcons.ttf#ContactsIcons" : "Assets/Fonts/ContactsIcons.ttf#ContactsIcons"
                        }
                    };
                }
                else if (e.DataFormItem.Name.Equals("ContactImage"))
                {
                    e.Cancel = true;
                }
                else if (e.DataFormItem.Name.Equals("BirthDate"))
                {
                    e.DataFormItem.TextInputLayoutSettings = new TextInputLayoutSettings()
                    {
                        LeadingView = new Label()
                        {

                            FontSize = Device.RuntimePlatform == Device.iOS ? 18 : 24,
                            Text = "H",
                            FontFamily = Device.RuntimePlatform == Device.iOS ? "ContactsIcons" :
                                                                   Device.RuntimePlatform == Device.Android ? "ContactsIcons.ttf#ContactsIcons" : "Assets/Fonts/ContactsIcons.ttf#ContactsIcons"
                        }
                    };
                }
                else if (e.DataFormItem.Name.Equals("GroupName"))
                {
                    e.DataFormItem.TextInputLayoutSettings = new TextInputLayoutSettings()
                    {
                        LeadingView = new Label()
                        {
                            FontSize = Device.RuntimePlatform == Device.iOS ? 18 : 24,
                            Text = "B",
                            FontFamily = Device.RuntimePlatform == Device.iOS ? "ContactsIcons" :
                                                                                      Device.RuntimePlatform == Device.Android ? "ContactsIcons.ttf#ContactsIcons" : "Assets/Fonts/ContactsIcons.ttf#ContactsIcons"
                        }
                    };
                }
                else if (e.DataFormItem.Name.Equals("Address"))
                {
                    e.DataFormItem.TextInputLayoutSettings = new TextInputLayoutSettings()
                    {
                        LeadingView = new Label()
                        {
                            VerticalTextAlignment = Device.RuntimePlatform == Device.iOS ? TextAlignment.Center : TextAlignment.Start,
                            FontSize = Device.RuntimePlatform == Device.iOS ? 18 : 24,
                            Text = "I",
                            FontFamily = Device.RuntimePlatform == Device.iOS ? "ContactsIcons" :
                                                                  Device.RuntimePlatform == Device.Android ? "ContactsIcons.ttf#ContactsIcons" : "Assets/Fonts/ContactsIcons.ttf#ContactsIcons"
                        }
                    };
                }
                else if (e.DataFormItem.Name.Equals("Notes"))
                {
                    e.DataFormItem.TextInputLayoutSettings = new TextInputLayoutSettings()
                    {
                        LeadingView = new Label()
                        {
                            VerticalTextAlignment = Device.RuntimePlatform == Device.iOS ? TextAlignment.Center : TextAlignment.Start,
                            FontSize = Device.RuntimePlatform == Device.iOS ? 18 : 24,
                            Text = "C",
                            FontFamily = Device.RuntimePlatform == Device.iOS ? "ContactsIcons" :
                                                                                      Device.RuntimePlatform == Device.Android ? "ContactsIcons.ttf#ContactsIcons" : "Assets/Fonts/ContactsIcons.ttf#ContactsIcons"
                        }
                    };
                }
                else if (e.DataFormItem.Name.Equals("ContactType"))
                {
                    e.DataFormItem.LayoutOptions = LayoutType.Default;
                }
                else if (e.DataFormItem.Name.Equals("EmailType"))
                {
                    e.DataFormItem.LayoutOptions = LayoutType.Default;
                }
                else if (e.DataFormItem.Name.Equals("AddressTypes"))
                {
                    e.DataFormItem.LayoutOptions = LayoutType.Default;
                }
                else if (e.DataFormItem.Name.Equals("SaveTo"))
                {
                    e.DataFormItem.LayoutOptions = LayoutType.Default;
                }

                this.ChangeItemOrder(e.DataFormItem);
            }

            if (e.DataFormGroupItem != null)
            {
                e.DataFormGroupItem.AllowExpandCollapse = false;
            }
        }

        private void ChangeItemOrder(DataFormItem dataFormItem)
        {
            if(dataFormItem.Name == "ContactNumber")
            {
                dataFormItem.Order = App.Current.MainPage.FlowDirection != FlowDirection.RightToLeft ? 4 : 5;
            }
            if (dataFormItem.Name == "ContactType")
            {
                dataFormItem.Order = App.Current.MainPage.FlowDirection != FlowDirection.RightToLeft ? 5 : 4;
            }
            if (dataFormItem.Name == "Email")
            {
                dataFormItem.Order = App.Current.MainPage.FlowDirection != FlowDirection.RightToLeft ? 6 : 7;
            }
            if (dataFormItem.Name == "EmailType")
            {
                dataFormItem.Order = App.Current.MainPage.FlowDirection != FlowDirection.RightToLeft ? 7 : 6;
            }
            if (dataFormItem.Name == "Address")
            {
                dataFormItem.Order = App.Current.MainPage.FlowDirection != FlowDirection.RightToLeft ? 8 : 9;
            }
            if (dataFormItem.Name == "AddressTypes")
            {
                dataFormItem.Order = App.Current.MainPage.FlowDirection != FlowDirection.RightToLeft ? 9 : 8;
            }
        }
    }
}