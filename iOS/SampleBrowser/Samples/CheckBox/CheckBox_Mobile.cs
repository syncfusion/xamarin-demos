#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using CoreGraphics;
using System;
using UIKit;
using Syncfusion.iOS.Buttons;
using CoreAnimation;

namespace SampleBrowser
{
    public class CheckBox_Mobile : SampleView
    {
        bool skip = false;
        UIImageView image = new UIImageView();
        UIStackView mainStackView = new UIStackView();
        UILabel hedinglbl = new UILabel();
        SfCheckBox selectAll = new SfCheckBox();
        SfCheckBox grilledChicken = new SfCheckBox();
        SfCheckBox chickenTikka = new SfCheckBox();
        SfCheckBox chickenSausage = new SfCheckBox();
        SfCheckBox beef = new SfCheckBox();
        UIButton button = new UIButton();
        CALayer layer = new CALayer();
        UIAlertView alertView = new UIAlertView();

        public CheckBox_Mobile()
        {
            //Image 
            image.Image = UIImage.FromBundle("Images/Pizzaimage.png");
            AddSubview(image);

            //Main statck
            mainStackView.Axis = UILayoutConstraintAxis.Vertical;

            //Layer
            layer.BorderWidth = 1.5f;
            layer.BorderColor = UIColor.FromRGB(205, 205, 205).CGColor;
            layer.CornerRadius = 10;
            Layer.AddSublayer(layer);

            //heading
            hedinglbl.Text = "Add Extra Toppings";
            hedinglbl.TextColor = UIColor.FromRGB(0, 125, 230);
            hedinglbl.Font = UIFont.FromName(hedinglbl.Font.FamilyName, 20);
            mainStackView.AddSubview(hedinglbl);

            //Select All
            selectAll.SetTitle("Select All", UIControlState.Normal);
            selectAll.SetTitleColor(UIColor.Black, UIControlState.Normal);
            selectAll.StateChanged += SelectAll_StateChanged;
            mainStackView.AddSubview(selectAll);

            //GrilledChicken
            grilledChicken.SetTitle("Grilled Chicken", UIControlState.Normal);
            grilledChicken.SetTitleColor(UIColor.Black, UIControlState.Normal);
            grilledChicken.StateChanged += Toppings_StateChanged;
            mainStackView.AddSubview(grilledChicken);

            //ChickenTikka
            chickenTikka.SetTitle("Chicken Tikka", UIControlState.Normal);
            chickenTikka.SetTitleColor(UIColor.Black, UIControlState.Normal);
            chickenTikka.StateChanged += Toppings_StateChanged;
            mainStackView.AddSubview(chickenTikka);

            //ChickenSausage
            chickenSausage.SetTitle("Chicken Sausage", UIControlState.Normal);
            chickenSausage.SetTitleColor(UIColor.Black, UIControlState.Normal);
            chickenSausage.StateChanged += Toppings_StateChanged;
            mainStackView.AddSubview(chickenSausage);

            //Beef
            beef.SetTitle("Beef", UIControlState.Normal);
            beef.SetTitleColor(UIColor.Black, UIControlState.Normal);
            beef.StateChanged += Toppings_StateChanged;
            mainStackView.AddSubview(beef);

            //Button
            button.SetTitle("Order Now", UIControlState.Normal);
            button.SetTitleColor(UIColor.LightGray, UIControlState.Disabled);
            button.SetTitleColor(UIColor.White, UIControlState.Normal);
            button.BackgroundColor = UIColor.FromRGB(0, 125, 230);
            button.TouchDown += Button_Clicked;
            button.Enabled = false;
            AddSubview(button);

            //Alert
            alertView.Message = "Your order has been placed successfully !";

            alertView.AddButton("OK");

            AddSubview(mainStackView);
        }

        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    image.Frame = new CGRect(0, -2, Frame.Size.Width, 270);
                    mainStackView.Frame = new CGRect(25, 295, Frame.Size.Width - 45, 460);
                    layer.Frame = new CGRect(25, 295, Frame.Size.Width - 45, 460);
                    hedinglbl.Frame = new CGRect(10, 20, 350, 45);
                    selectAll.Frame = new CGRect(20, 110, 200, 30);
                    grilledChicken.Frame = new CGRect(20, 175, 200, 30);
                    chickenTikka.Frame = new CGRect(20,245 , 200, 30);
                    chickenSausage.Frame = new CGRect(20,315 , 200, 30);
                    beef.Frame = new CGRect(20, 380, 200, 30);
                    button.Frame = new CGRect(0, Frame.Size.Height - 40, Frame.Size.Width, 40);

                    hedinglbl.Font = UIFont.FromName(hedinglbl.Font.FamilyName, 30);
                    selectAll.Font = UIFont.FromName(hedinglbl.Font.FamilyName, 20);
                    grilledChicken.Font = UIFont.FromName(hedinglbl.Font.FamilyName, 20);
                    chickenTikka.Font = UIFont.FromName(hedinglbl.Font.FamilyName, 20);
                    chickenSausage.Font = UIFont.FromName(hedinglbl.Font.FamilyName, 20);
                    beef.Font = UIFont.FromName(hedinglbl.Font.FamilyName, 20);
                }
                else
                {
                    view.Frame = new CGRect(Frame.Location.X, 0.0f, Frame.Size.Width, Frame.Size.Height);
                    image.Frame = new CGRect(0, -2, Frame.Size.Width, 150);
                    mainStackView.Frame = new CGRect(15, 165, Frame.Size.Width - 30, 285);
                    layer.Frame = new CGRect(15, 165, Frame.Size.Width - 30, 285);
                    hedinglbl.Frame = new CGRect(10, 10, 250, 30);
                    selectAll.Frame = new CGRect(10, 55, 200, 30);
                    grilledChicken.Frame = new CGRect(10, 100, 200, 30);
                    chickenTikka.Frame = new CGRect(10, 145, 200, 30);
                    chickenSausage.Frame = new CGRect(10, 190, 200, 30);
                    beef.Frame = new CGRect(10, 235, 200, 30);
                    button.Frame = new CGRect(0, 465, Frame.Size.Width, 38);
                }
            }
            base.LayoutSubviews();
        }

        private void SelectAll_StateChanged(object sender, StateChangedEventArgs eventArgs)
        {
            if (!skip)
            {
                skip = true;
                grilledChicken.IsChecked = chickenTikka.IsChecked = chickenSausage.IsChecked = beef.IsChecked = eventArgs.IsChecked.Value;
                button.Enabled = eventArgs.IsChecked.Value;
                skip = false;
            }
        }

        private void Toppings_StateChanged(object sender, StateChangedEventArgs eventArgs)
        {
            if (!skip)
            {
                skip = true;
                selectAll.IsChecked = ValidateNonVegToopings();
                if (!selectAll.IsChecked.HasValue || (selectAll.IsChecked.HasValue && selectAll.IsChecked.Value))
                    button.Enabled = true;
                else
                    button.Enabled = false;
                skip = false;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            bool? temp = ValidateNonVegToopings();
            if (!temp.HasValue || (temp.HasValue && temp.Value))
            {
                alertView.Show();
                selectAll.IsChecked = false;
            }
        }

        private bool? ValidateNonVegToopings()
        {
            if (grilledChicken.IsChecked.Value && chickenTikka.IsChecked.Value && chickenSausage.IsChecked.Value && beef.IsChecked.Value)
                return true;
            else if (!grilledChicken.IsChecked.Value && !chickenTikka.IsChecked.Value && !chickenSausage.IsChecked.Value && !beef.IsChecked.Value)
                return false;
            else
                return null;
        }
    }
}
