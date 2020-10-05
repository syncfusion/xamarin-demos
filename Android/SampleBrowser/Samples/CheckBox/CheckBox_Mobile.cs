#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Widget;
using Android.OS;
using Syncfusion.Android.Buttons;
using Android.Graphics;
using Android.Views;
using Android.Content;
using Android.Util;
using System;


namespace SampleBrowser
{
    public class CheckBox_Mobile
    {
        private bool skip = false;
        SfCheckBox selectAllBox, grilledBox, tikkaBox, beefBox, sausaga;
        Button button;
        AlertDialog.Builder resultsDialog;
        public CheckBox_Mobile()
        {

        }
        public View GetSampleContent(Context con)
        {
            LinearLayout linear = new LinearLayout(con);
            linear.Orientation = Orientation.Vertical;

            LinearLayout.LayoutParams linearLayoutParams = new LinearLayout.LayoutParams(
                    LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent, (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 3, con.Resources.DisplayMetrics));
            int margin;
            if (IsTabletDevice(con))
                margin = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 15, con.Resources.DisplayMetrics);
            else
                margin = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 9.5f, con.Resources.DisplayMetrics);

            linearLayoutParams.SetMargins(margin, margin, margin, margin);

            ImageView imageView = new ImageView(con);
            imageView.SetScaleType(ImageView.ScaleType.FitStart);
            imageView.SetAdjustViewBounds(true);
            imageView.SetImageResource(Resource.Drawable.Pizzaimage);
            linear.AddView(imageView);

            int padding = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 7, con.Resources.DisplayMetrics);

            LinearLayout frameParent = new LinearLayout(con);
            frameParent.SetBackgroundColor(Color.White);
            frameParent.Orientation = Orientation.Vertical;
            frameParent.LayoutParameters = linearLayoutParams;

            LinearLayout frame = new LinearLayout(con);
            frame.Orientation = Orientation.Vertical;
            int currentapiVersion = (int)Build.VERSION.SdkInt;
            if (currentapiVersion > 21)
                frame.Background = con.Resources.GetDrawable(Resource.Drawable.shadow, con.Theme);

            TextView headLabel = new TextView(con);
            headLabel.SetPadding(padding, headLabel.PaddingTop, headLabel.PaddingRight, headLabel.PaddingBottom);
            headLabel.TextSize = 18;
            headLabel.SetTextColor(Color.ParseColor("#FF007DE6"));
            headLabel.Text = "Add Extra Toppings";
            frame.AddView(headLabel);

            #region Items Layout

            selectAllBox = new SfCheckBox(con);
            selectAllBox.Text = "Select All";
            selectAllBox.TextSize = 15;
            selectAllBox.SetTextColor(Color.ParseColor("#FF000000"));
            selectAllBox.StateChanged += SelectAll1_StateChanged;
            selectAllBox.LayoutParameters = linearLayoutParams;
            frame.AddView(selectAllBox);

            grilledBox = new SfCheckBox(con);
            grilledBox.Text = "Grilled Chicken";
            grilledBox.TextSize = 15;
            grilledBox.SetTextColor(Color.ParseColor("#FF000000"));
            grilledBox.StateChanged += NonvegToppingsChanged;
            grilledBox.LayoutParameters = linearLayoutParams;
            frame.AddView(grilledBox);

            tikkaBox = new SfCheckBox(con);
            tikkaBox.Text = "Chicken Tikka";
            tikkaBox.TextSize = 15;
            tikkaBox.SetTextColor(Color.ParseColor("#FF000000"));
            tikkaBox.StateChanged += NonvegToppingsChanged;
            tikkaBox.LayoutParameters = linearLayoutParams;
            frame.AddView(tikkaBox);

            sausaga = new SfCheckBox(con);
            sausaga.Text = "Chicken Sausage";
            sausaga.TextSize = 15;
            sausaga.SetTextColor(Color.ParseColor("#FF000000"));
            sausaga.StateChanged += NonvegToppingsChanged;
            sausaga.LayoutParameters = linearLayoutParams;
            frame.AddView(sausaga);

            beefBox = new SfCheckBox(con);
            beefBox.Text = "Beef";
            beefBox.TextSize = 15;
            beefBox.SetTextColor(Color.ParseColor("#FF000000"));
            beefBox.StateChanged += NonvegToppingsChanged;
            beefBox.LayoutParameters = linearLayoutParams;
            frame.AddView(beefBox);

            frameParent.AddView(frame);
            linear.AddView(frameParent);
            #endregion

            button = new Button(con);
            button.SetWidth(ActionBar.LayoutParams.MatchParent);
            button.SetHeight(43);
            button.TextSize = 21;
            button.Text = "Order Now";
            button.SetBackgroundColor(Color.ParseColor("#FF007DE6"));
            button.SetTextColor(Color.ParseColor("#73FFFFFF"));
            button.Click += SearchButton_Click;
            button.Enabled = false;

            linear.AddView(button);

            resultsDialog = new AlertDialog.Builder(con);
            resultsDialog.SetPositiveButton("OK", (object sender, DialogClickEventArgs e) =>
            {
            });

            resultsDialog.SetCancelable(true);
            return linear;
        }

        public static bool IsTabletDevice(Android.Content.Context context)
        {
            try
            {
                DisplayMetrics displayMetrics = context.Resources.DisplayMetrics;
                float screenWidth = displayMetrics.WidthPixels / displayMetrics.Xdpi;
                float screenHeight = displayMetrics.HeightPixels / displayMetrics.Ydpi;
                double size = Java.Lang.Math.Sqrt(Math.Pow(screenWidth, 2) + Math.Pow(screenHeight, 2));
                return size >= 6;
            }
            catch
            {
                return false;
            }
        }

        private void NonVegBox_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (e.IsChecked)
            {
                grilledBox.Visibility = tikkaBox.Visibility = sausaga.Visibility = beefBox.Visibility = ViewStates.Visible;
            }
            else
            {
                grilledBox.Visibility = tikkaBox.Visibility = sausaga.Visibility = beefBox.Visibility = ViewStates.Gone;
            }


            if (!e.IsChecked)
            {
                selectAllBox.Checked = false;
                grilledBox.Checked = tikkaBox.Checked = sausaga.Checked = beefBox.Checked = false;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

            bool? temp = ValidateNonVegToopings();
            if (!temp.HasValue || (temp.HasValue && temp.Value))
            {
                resultsDialog.SetMessage("Your order has been placed successfully !");
                selectAllBox.Checked = false;
            }

            resultsDialog.Create().Show();
        }

        private bool? ValidateNonVegToopings()
        {
            if (grilledBox.Checked.Value && tikkaBox.Checked.Value && sausaga.Checked.Value && beefBox.Checked.Value)
                return true;
            else if (!grilledBox.Checked.Value && !tikkaBox.Checked.Value && !sausaga.Checked.Value && !beefBox.Checked.Value)
                return false;
            else
                return null;
        }

        private void NonvegToppingsChanged(object sender, Syncfusion.Android.Buttons.StateChangedEventArgs eventArgs)
        {
            if (!skip)
            {
                skip = true;
                selectAllBox.Checked = ValidateNonVegToopings();
                if (!selectAllBox.Checked.HasValue || (selectAllBox.Checked.HasValue && selectAllBox.Checked.Value))
                {
                    button.Enabled = true;
                    button.SetTextColor(Color.ParseColor("#FFFFFF"));
                }
                else
                {
                    button.Enabled = false;
                    button.SetTextColor(Color.ParseColor("#73FFFFFF"));
                }
                   
                skip = false;
            }
        }

        private void SelectAll1_StateChanged(object sender, Syncfusion.Android.Buttons.StateChangedEventArgs eventArgs)
        {
            if (!skip)
            {
                skip = true;

                grilledBox.Checked = tikkaBox.Checked = sausaga.Checked = beefBox.Checked = eventArgs.IsChecked.Value;

                button.Enabled = eventArgs.IsChecked.Value;
                if (button.Enabled)
                {
                    button.SetTextColor(Color.ParseColor("#FFFFFF"));
                }
                else
                {
                    button.SetTextColor(Color.ParseColor("#73FFFFFF"));
                }

                skip = false;
            }
        }
    }
}