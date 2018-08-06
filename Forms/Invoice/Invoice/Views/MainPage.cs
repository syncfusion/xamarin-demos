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
    #region MainPage

    public class MainPage : TabbedPage
    {
        #region Constructor

        public MainPage()
        {
            this.Title = "Invoice";

            this.Children.Add(new ItemView
            {
                Title = "Items",
                Icon = "items.png"
            });
            this.Children.Add(new UserView
            {
                Title = "User",
                billInfo =(this.Children[0] as ItemView).billInfo,
                Icon = "user.png"
            });
            this.Children.Add(new InfoView
            {
                Title = "Info",
                Icon = "info.png"
            });

        }

        #endregion
    }

    # endregion
}
