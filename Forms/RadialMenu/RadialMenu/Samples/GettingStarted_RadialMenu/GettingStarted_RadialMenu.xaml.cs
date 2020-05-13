#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Syncfusion.SfRadialMenu.XForms;
using Xamarin.Forms;
using SampleBrowser.Core;
using System.ComponentModel;

namespace SampleBrowser.SfRadialMenu
{
    public partial class GettingStarted_RadialMenu : SampleView, INotifyPropertyChanged
    {
        ObservableCollection<string> list;
        public GettingStarted_RadialMenu()
        {
            InitializeComponent();
            this.BindingContext = this;
            list = new ObservableCollection<string>();

            #region Event with Handlers
            list.CollectionChanged += (sender, e) =>
            {
                Label lbl = new Label();
                lbl.FontSize = 14;
                lbl.Text = e.NewItems[0].ToString();
                eventLogLayout.Children.Insert(0, lbl);
            };

            slider.ValueChanging += (sender, e) =>
            {
                radial_Menu.Close();
                radial_Menu.RimRadius = e.Value;
            };
            rotationSwitch.Toggled += (sender, e) =>
            {
                radial_Menu.EnableRotation = e.Value;
            };
            dragSwitch.Toggled += (sender, e) =>
            {
                radial_Menu.IsDragEnabled = e.Value;
            };
            #endregion

            if (Device.RuntimePlatform == Device.Android)
            {
                eventLogsLabel.FontSize = 18;
                eventLogsLabel.HeightRequest = 40;
                clearLogsButton.HeightRequest = 35;
                clearLogsButton.FontSize = 12;
                logRow.Height = 35;
            }
        }

        #region Event Handlers
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            eventLogLayout.Children.Clear();
        }

        void Handle_ItemTapped(object sender, Syncfusion.SfRadialMenu.XForms.ItemTappedEventArgs e)
        {
            var tempItem = (sender as SfRadialMenuItem);
            if (tempItem.FontIconText == "")
                list.Add("Spectrum range one is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Spectrum range two is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Spectrum range three is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Spectrum range four is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Notification mode one is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Notification mode two is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Notification mode three is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Slient mode is activated");
            else if (tempItem.FontIconText == "")
                list.Add("Vibrate mode is activated");
            else if (tempItem.FontIconText == "")
                list.Add("Normal mode is activated");
            else if (tempItem.FontIconText == "")
                list.Add("Brightness level is adjusted");
            else if (tempItem.FontIconText == "")
                list.Add("Battery mode one is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Battery mode two is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Battery mode three is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Power saver mode one is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Power saver mode two is selected");
            else if (tempItem.FontIconText == "")
                list.Add("Power saver mode three is selected");
        }
        void Radial_Menu_Opening(object sender, OpeningEventArgs e)
        {
            list.Add("RadialMenu is Opening");
        }

        void Radial_Menu_Opened(object sender, OpenedEventArgs e)
        {
            list.Add("RadialMenu is Opened");
        }

        void Radial_Menu_Closed(object sender, ClosedEventArgs e)
        {
            list.Add("RadialMenu is Closed");
        }

        void Radial_Menu_Closing(object sender, ClosingEventArgs e)
        {
            list.Add("RadialMenu is Closing");
        }

        void Radial_Menu_Navigating(object sender, NavigatingEventArgs e)
        {
            list.Add("RadialMenu is Navigating");
        }

        void Radial_Menu_Navigated(object sender, NavigatedEventArgs e)
        {
            list.Add("RadialMenu is Navigated");
        }

        void Radial_Menu_CenterButtonTapped(object sender, CenterButtonBackTappedEventArgs e)
        {
            list.Add("CenterButtonBack is Tapped");
        }

        void Handle_DragBegin(object sender, Syncfusion.SfRadialMenu.XForms.DragBeginEventArgs e)
        {
            list.Add("RadialMenu is began to drag" + "\n Start Position :" + " \t X = " + e.Position.X + " \t Y =" + e.Position.Y);
        }

        void Handle_DragEnd(object sender, Syncfusion.SfRadialMenu.XForms.DragEndEventArgs e)
        {
            if (radial_Menu.CenterButtonPlacement == SfRadialMenuCenterButtonPlacement.Center)

            {
                if (e.NewValue.X >= (radial_Menu.Width / 2 - radial_Menu.CenterButtonRadius / 2) || e.NewValue.X <= -(radial_Menu.Width / 2 - radial_Menu.CenterButtonRadius / 2))
                {
                    e.Handled = true;
                }
                if (e.NewValue.Y >= (radial_Menu.Height / 2 - radial_Menu.CenterButtonRadius / 2) || e.NewValue.Y <= -(radial_Menu.Height / 2 - radial_Menu.CenterButtonRadius / 2))
                {
                        e.Handled = true;
                }
            }

            list.Add("RadialMenu is stopped dragging" + "\n Start Position :" + " \t X = " + e.OldValue.X + " \t Y =" + e.OldValue.Y + "\n End Position :" + "\t X = " + e.NewValue.X + "\t Y =" + e.NewValue.Y);
        }

		#endregion

		bool visibility = true;
		public bool Visible
		{
			get
			{
				return visibility;
			}
			set
			{
				visibility = value;
				RaisePropertyChanged("Visible");
			}
		}

		#region INotifyPropertyChanged implementation

		public new event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged(String name)
		{
			if (PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(name));
		}

		#endregion

		public override void OnDisappearing()
        {
            if(Device.RuntimePlatform == Device.UWP)
            {
                radial_Menu.Dispose();
            }
            base.OnDisappearing();
        }

		double oldHeight, oldWidth;
		protected override void OnSizeAllocated(double width, double height)
		{
			if (height != oldHeight && width != oldWidth)
			{
				oldWidth = width;
				oldHeight = height;
                if (Device.RuntimePlatform != Device.UWP)
                {
                    if (width < height)
                    {
                        Visible = true;
                        Grid.SetRowSpan(firstRow, 1);
                        radial_Menu.Point = new Point(0, 0);
                    }
                    else
                    {
                        Visible = false;
                        Grid.SetRowSpan(firstRow, 3);
                        radial_Menu.Point = new Point(1, 0);
                    }
                }
			}
			base.OnSizeAllocated(width, height);
		}
    }
}

