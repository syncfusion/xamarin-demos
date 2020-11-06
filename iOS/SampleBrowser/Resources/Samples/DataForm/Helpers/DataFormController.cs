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
using Syncfusion.iOS.DataForm;
using CoreGraphics;

namespace SampleBrowser
{
    public class DataFormController : UIViewController
    {
        internal bool refreshLayout = false;
        internal SfDataForm dataForm;
        private UIImageView image;
        private UILabel label;
        UITableView tableView;
        UIView uIView;

        private UIBarButtonItem editButton;
        private UIButton moreFields;

        UIScrollView scrollView;
        public DataFormController(SfDataForm dataForm, UITableView tableView) : base()
        {
            this.dataForm = dataForm;
            InitializeViews();
            UpdateView();
            this.tableView = tableView;
        }

        /// <summary>
        /// Initialize views and add to DataFormController.
        /// </summary>
        private void InitializeViews()
        {
            scrollView = new UIScrollView();
            scrollView.Frame = new CGRect(0, 160, this.View.Frame.Width, this.View.Frame.Height - 160);

            uIView = new UIView(new CGRect(0, 0, this.View.Frame.Width, 160));
            this.View.AddSubview(uIView);
            this.View.AddSubview(scrollView);
            uIView.BackgroundColor = UIColor.FromRGB(242.0f / 255.0f, 242.0f / 255.0f, 242.0f / 255.0f);

            image = new UIImageView(new CGRect(10, 70, 80, 80));
            uIView.AddSubview(image);
            label = new UILabel(new CGRect(100, 70, this.View.Frame.Width - 80, 80));
            label.Font.WithSize(12);
            uIView.AddSubview(label);
            editButton = new UIBarButtonItem();
            editButton.Title = "Edit";
            editButton.Clicked += EditButton_Clicked;

            dataForm.CommitMode = CommitMode.Explicit;
            dataForm.ValidationMode = ValidationMode.LostFocus;
            dataForm.AutoGeneratingDataFormItem += DataForm_AutoGeneratingDataFormItem;

            dataForm.Frame = new CGRect(10, 0, this.View.Frame.Width - 10, this.View.Frame.Height - (160 + 30));
            scrollView.AddSubview(dataForm);
            this.View.BackgroundColor = UIColor.White;

            moreFields = new UIButton(new CGRect(10, this.scrollView.Frame.Height - 30, dataForm.Frame.Width, 30));

            moreFields.SetTitle("More Fields", UIControlState.Normal);
            moreFields.SetTitleColor(this.View.TintColor, UIControlState.Normal);
            moreFields.TouchDown += MoreFields_TouchDown;
        }

        private void MoreFields_TouchDown(object sender, EventArgs e)
        {
            refreshLayout = true;
            dataForm.RefreshLayout(false);
            moreFields.RemoveFromSuperview();
            dataForm.Frame = new CGRect(10, 0, this.View.Frame.Width - 10, this.View.Frame.Height - 160);
        }

        /// <summary>
        /// DataObject update to set ReadOnly, UIBarButton title update to show edit or done.
        /// </summary>
        /// <param name="contactInfo"></param>
        /// <param name="isAdding"></param>
        internal void UpDateDataFormView(ContactInfo contactInfo, bool isAdding = false)
        {
            dataForm.DataObject = contactInfo;
            // Setting edit button
            if (!isAdding)
            {
                if (editButton.Title.Equals("Edit"))
                {
                    dataForm.IsReadOnly = true;
                    editButton.Title = "Edit";
                }
                else
                {
                    dataForm.IsReadOnly = false;
                    bool isValid = dataForm.Validate();
                    if (!isValid)
                        return;
                    dataForm.Commit();
                    editButton.Title = "Done";
                }
                this.NavigationItem.SetRightBarButtonItem(editButton, true);
            }
            else
            {
                var okButton = new UIBarButtonItem();
                okButton.Title = "OK";
                dataForm.IsReadOnly = false;
                refreshLayout = false;
                this.dataForm.DataObject = contactInfo;
                okButton.Clicked += OnOK;
                this.NavigationItem.SetRightBarButtonItem(okButton, true);
            }
        }

        private void EditButton_Clicked(object sender, EventArgs e)
        {
            var item = dataForm.DataObject as ContactInfo;
            if (editButton.Title.Equals("Edit"))
            {
                dataForm.IsReadOnly = false;
                editButton.Title = "Done";
            }
            else
            {
                bool isValid = dataForm.Validate();
                if (!isValid)
                    return;
                dataForm.Commit();

                dataForm.IsReadOnly = true;
                editButton.Title = "Edit";
                var itemIndex = (tableView.Source as ContactTableSource).TableItems.IndexOf(item);
                if (itemIndex == -1)
                    return;
                NSIndexPath[] rowsToReload = new NSIndexPath[] { NSIndexPath.FromRowSection(itemIndex, 0) };
                tableView.ReloadRows(rowsToReload, UITableViewRowAnimation.None);
            }
        }

        private void OnOK(object sender, EventArgs e)
        {
            // TableView update
            var tableSource = (this.tableView.Source as ContactTableSource);
            var item = dataForm.DataObject as ContactInfo;
            var itemIndex = tableSource.TableItems.IndexOf(item);
            if (item.ContactImage == null)
                item.ContactImage = UIImage.FromBundle("ContactName.png");


            // DataForm update            
            bool isValid = dataForm.Validate();
            if (!isValid)
                return;
            dataForm.Commit();
            if (itemIndex == -1)
            {
                (tableView.Source as ContactTableSource).TableItems.Add(item);
                tableView.ReloadData();
            }

            this.NavigationItem.SetRightBarButtonItem(null, true);
            var navigationController = UIApplication.SharedApplication.KeyWindow.RootViewController as UINavigationController;
            navigationController.PopViewController(false);
        }

        /// <summary>
        /// Updates title bar of DataFormViewController - Contact Image and ConatctName updates.
        /// </summary>
        internal void UpdateView()
        {
            if (dataForm.DataObject == null)
                return;

            scrollView.AddSubview(moreFields);
            dataForm.Frame = new CGRect(10, 0, this.View.Frame.Width - 10, this.View.Frame.Height - (160 + 30));

            var contactInfo = dataForm.DataObject as ContactInfo;
            if (contactInfo.ContactImage == null)
            {
                image.Image = UIImage.FromBundle("ContactName1.png");
                var frame = image.Frame;
                frame.X = (dataForm.Frame.Width / 2) - 40;
                image.Frame = frame;
            }
            else
            {
                image.Image = contactInfo.ContactImage;
                var frame = image.Frame;
                frame.X = 10;
                frame.Width = 80;
                frame.Height = 80;
                image.Frame = frame;
            }
            label.Text = contactInfo.ContactName;
        }

        /// <summary>
        /// Event to cancel the COnatctImage DataFormItem and setting IsReadOnly property.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DataForm_AutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {
            if (e.DataFormItem != null)
            {
                if (!refreshLayout)
                {
                    if (e.DataFormItem.Name.Equals("MiddleName") || e.DataFormItem.Name.Equals("LastName"))
                        e.Cancel = true;
                }

                if (e.DataFormItem.Name.Equals("ContactNumber"))
                    (e.DataFormItem as DataFormTextItem).KeyBoardType = UIKeyboardType.NumberPad;
                else if (e.DataFormItem.Name.Equals("Email"))
                    (e.DataFormItem as DataFormTextItem).KeyBoardType = UIKeyboardType.EmailAddress;
            }
            if (e.DataFormGroupItem != null)
                e.DataFormGroupItem.AllowExpandCollapse = false;
        }
        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            editButton.Title = "Edit";
        }
    }
}