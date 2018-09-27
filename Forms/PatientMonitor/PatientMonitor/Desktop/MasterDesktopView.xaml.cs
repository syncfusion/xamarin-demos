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

namespace PatientMonitor
{
    public partial class MasterDesktopView : ContentPage
    {
        public MasterDesktopView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            btn_Home.BackgroundColor = Color.FromHex("#8e1313");
            this.BindingContext = new HomeViewModel();
        }

        protected override void OnAppearing()
        {
            schedule_View.IsVisible = false;
            base.OnAppearing();
           
        }


        private void button_clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            btn_Home.BackgroundColor = Color.FromHex("#B51110");
            btn_Event.BackgroundColor = Color.FromHex("#B51110");
            if (button.Text == "My Patients")
            {
                grid_View.IsVisible = true;
                schedule_View.IsVisible = false;
            }

            else if (button.Text == "My Appointments")
            {
                grid_View.IsVisible = false;
                schedule_View.IsVisible = true;
            }
            button.BackgroundColor = Color.FromHex("#8e1313");
        }

    }
}
