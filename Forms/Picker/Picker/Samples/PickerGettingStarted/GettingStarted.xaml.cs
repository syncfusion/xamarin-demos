#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using SampleBrowser.Core;
using Syncfusion.SfPicker.XForms;

namespace SampleBrowser.SfPicker
{
	public partial class PickerGettingStarted : SampleView
	{
		public PickerGettingStarted()
		{
			InitializeComponent();
            Color c = Color.Navy;
            
            SelectedRowTextColorPicker.Items.Add("Yellow");
            SelectedRowTextColorPicker.Items.Add("Green");
            SelectedRowTextColorPicker.Items.Add("Navy");
            SelectedRowTextColorPicker.Items.Add("Orange");
            SelectedRowTextColorPicker.Items.Add("Lime");
            SelectedRowTextColorPicker.Items.Add("Purple");
            SelectedRowTextColorPicker.Items.Add("Pink");
            SelectedRowTextColorPicker.Items.Add("Red");
            SelectedRowTextColorPicker.Items.Add("Gray");


            UnSelectedRowTextColorPicker.Items.Add("Yellow");
            UnSelectedRowTextColorPicker.Items.Add("Green");
            UnSelectedRowTextColorPicker.Items.Add("Navy");
            UnSelectedRowTextColorPicker.Items.Add("Orange");
            UnSelectedRowTextColorPicker.Items.Add("Lime");
            UnSelectedRowTextColorPicker.Items.Add("Purple");
            UnSelectedRowTextColorPicker.Items.Add("Pink");
            UnSelectedRowTextColorPicker.Items.Add("Red");
            UnSelectedRowTextColorPicker.Items.Add("Gray");

            BorderColorPicker.Items.Add("Yellow");
            BorderColorPicker.Items.Add("Green");
            BorderColorPicker.Items.Add("Navy");
            BorderColorPicker.Items.Add("Orange");
            BorderColorPicker.Items.Add("Lime");
            BorderColorPicker.Items.Add("Purple");
            BorderColorPicker.Items.Add("Pink");
            BorderColorPicker.Items.Add("Red");
            BorderColorPicker.Items.Add("Gray");


            var viewModel = new PickerGettingStartedViewModel();
			this.BindingContext = this.PropertyView.BindingContext = viewModel;

            if (Device.RuntimePlatform == Device.iOS)
            {
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    picker.WidthRequest = 250;
                }
                picker.BackgroundColor = Color.FromRgba(c.R, c.G, c.B, 0.2);
            }
            else if(Device.RuntimePlatform == Device.Android)
            {
                picker.BackgroundColor = Color.FromRgba(c.R, c.G, c.B, 0.2);
                picker.PickerHeight = 200;
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                ShowHeader.FontSize = 15;
                ShowColumnHeader.FontSize = 15;
              
                SelectedRowTextColorlbl.FontSize = 15;
                UnSelectedRowTextColorlbl.FontSize = 15;
                BorderColorlbl.FontSize = 15;
                if (Device.Idiom == TargetIdiom.Phone)
                {
					picker.ItemHeight = 50;
                    rowheight.Height = 280;
                    logname.Height = 25;
                }
                else
                {
                    grid_layout.HorizontalOptions = LayoutOptions.Start;
                    rowheight.Height = 322;
                }
            }


        }
		void Handle_Clicked(object sender, System.EventArgs e)
		{
			eventLogLayout.Children.Clear();
		}

        void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                picker.SelectionBackgroundColor = color;
            }
            else
                picker.SelectionBackgroundColor = Color.Transparent;
        }

        void Handle_TextChanged1(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
			if (e.NewTextValue != "")
				picker.HeaderHeight = Convert.ToDouble(e.NewTextValue);
			else
				picker.HeaderHeight=0;
		}

		void Handle_TextChanged2(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
			if (e.NewTextValue != "")
				picker.ColumnHeaderHeight = Convert.ToDouble(e.NewTextValue);
			else
				picker.ColumnHeaderHeight = 0;
		}



        void Handle_SelectedIndexChanged3(object sender, System.EventArgs e)
        {
            picker.SelectedItemTextColor = PickerHelper.GetColor(SelectedRowTextColorPicker.Items[SelectedRowTextColorPicker.SelectedIndex]);
        }


        void Handle_SelectedIndexChanged5(object sender, System.EventArgs e)
        {
            picker.BorderColor = PickerHelper.GetColor(BorderColorPicker.Items[BorderColorPicker.SelectedIndex]);
        }

        void Handle_SelectedIndexChanged4(object sender, System.EventArgs e)
        {
            picker.UnSelectedItemTextColor = PickerHelper.GetColor(UnSelectedRowTextColorPicker.Items[UnSelectedRowTextColorPicker.SelectedIndex]);
        }


        internal Color color;

        void Picker_SelectionChanged(object sender, Syncfusion.SfPicker.XForms.SelectionChangedEventArgs e)
		{
			if (e.NewValue != null)
			{
				Label lbl = new Label();
				lbl.Text = e.NewValue.ToString() + " " + "has been selected";
				eventLogLayout.Children.Insert(0, lbl);
				color =PickerHelper.GetColor(e.NewValue);
                if (Device.RuntimePlatform == Device.UWP)
                    picker.SelectionBackgroundColor = color;
                else
                    picker.BackgroundColor = Color.FromRgba(color.R, color.G, color.B, 0.2);
			}
		}
	}

    public class SfPickerBehavior:Behavior<Syncfusion.SfPicker.XForms.SfPicker>
    {
        protected override void OnAttachedTo(Syncfusion.SfPicker.XForms.SfPicker bindable)
        {
            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom(Syncfusion.SfPicker.XForms.SfPicker bindable)
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                (bindable as Syncfusion.SfPicker.XForms.SfPicker).Dispose();
            }
            base.OnDetachingFrom(bindable);
        }
    }
}
