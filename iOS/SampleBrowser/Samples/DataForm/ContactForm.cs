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
    public class ContactForm : SampleView
    {
        #region Fields

        SfDataForm dataForm;
        UITableView tableView;
        UIButton button;
        DataFormController dataFormController;
        #endregion

        UIView uIView;
        public ContactForm()
        {
            dataForm = new SfDataForm();
            dataForm.LayoutManager = new DataFormLayoutManagerExt(dataForm);
            tableView = new UITableView();
            
            tableView.RowHeight = 50;          

            tableView.SeparatorColor = UIColor.Clear;
            dataFormController = new DataFormController(dataForm, tableView);

            tableView.Source = new ContactTableSource(dataFormController, new ListViewGroupingViewModel().ContactsInfo);
            this.AddSubview(tableView);

            button = new UIButton();
            uIView = new UIView();
            uIView.AddSubview(button);

            uIView.BackgroundColor = UIColor.FromRGB(242.0f / 255.0f, 242.0f / 255.0f, 242.0f / 255.0f);
            button.SetTitle("Add", UIControlState.Normal);
            button.SetTitleColor(this.TintColor, UIControlState.Normal);
            button.TouchDown += Button_TouchDown;            
            this.AddSubview(this.tableView);            
            this.AddSubview(uIView);
        }

        private void Button_TouchDown(object sender, EventArgs e)
        {
            var navigationController = UIApplication.SharedApplication.KeyWindow.RootViewController as UINavigationController;
            dataFormController.refreshLayout = false;
            dataFormController.UpDateDataFormView(new ContactInfo(), true);
            dataFormController.UpdateView();
            navigationController.PushViewController(dataFormController, false);
        }

        public override void LayoutSubviews()
        {
            button.Frame = new CGRect(this.Frame.Width - 100, 0, 100, 50);
            uIView.Frame = (new CGRect(0, 0, this.Frame.Width, 50));          
            this.tableView.Frame = new CGRect(0, uIView.Bounds.Height, this.Frame.Width, this.Frame.Height - 50);

            base.LayoutSubviews();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}