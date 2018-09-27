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
using Xamarin.Forms;

namespace XamarinIOInvoice.Views
{

    #region UserView

    public partial class UserView
    {
        public BillInfo billInfo;
        #region Constructor

        public UserView()
        {
            InitializeComponent();
			this.UserLayout.Padding = Device.OnPlatform(iOS: new Thickness(0, 25, 0, 0), Android: new Thickness(0, 0, 0, 0), WinPhone: new Thickness(0, 0, 0, 0));

            this.DateValueLabel.Text = DateTime.Today.Month + "/" + DateTime.Today.Day+ "/" + DateTime.Today.Year ;
            this.NameValueLabel.TextChanged += NameValueLabel_TextChanged;
            this.AdressValueLabel.TextChanged += AdressValueLabel_TextChanged;
            this.NumberValueLabel.TextChanged += NumberValueLabel_TextChanged;
            this.DateValueLabel.TextChanged += DateValueLabel_TextChanged;
            this.NameLabelLayout.Padding = this.DateLabelLayout.Padding = this.NumberLabelLayout.Padding = this.AdressLabelLayout.Padding = Device.OnPlatform(iOS: new Thickness(2, 10, 0, 0), Android: new Thickness(2, 10, 0, 0), WinPhone: new Thickness(15, 10, 0, 0));
            this.NameValueLayout.Padding = this.DateValueLayout.Padding = this.NumberValueLayout.Padding = this.AdressValueLayout.Padding = Device.OnPlatform(iOS: new Thickness(0, 0, 0, 0), Android: new Thickness(0, 0, 0, 0), WinPhone: new Thickness(0, -10, 0, 0));
            this.NameLayout.Padding = this.DateLayout.Padding = this.NumberLayout.Padding = this.AdressLayout.Padding = Device.OnPlatform(iOS: new Thickness(10, 10, 10, 0), Android: new Thickness(10, 10, 10, 0), WinPhone: new Thickness(10, 10, 10, 0));
        }

        #endregion

        # region Events / Methods

        void DateValueLabel_TextChanged(object sender, TextChangedEventArgs e)
        {
            billInfo.Date = this.DateValueLabel.Text;
        }

        void NumberValueLabel_TextChanged(object sender, TextChangedEventArgs e)
        {
            billInfo.InvoiceNumber = this.NumberValueLabel.Text;
        }

        void AdressValueLabel_TextChanged(object sender, TextChangedEventArgs e)
        {
            billInfo.Address = this.AdressValueLabel.Text;
        }

        void NameValueLabel_TextChanged(object sender, TextChangedEventArgs e)
        {
            billInfo.Name = this.NameValueLabel.Text;
        }

        #endregion
    }

    #endregion
}
