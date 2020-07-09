#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using UIKit;
using Syncfusion.iOS.Buttons;
using CoreGraphics;
using CoreAnimation;

namespace SampleBrowser
{
    public class RadioButton_Mobile : SampleView
    {
        UIView View;
        UIStackView mainStackView = new UIStackView();
        UILabel hedinglbl = new UILabel();
        UILabel payamountlabl = new UILabel();
        UILabel amntLabl = new UILabel();
        UILabel selcetPaylbl = new UILabel();
        SfRadioGroup sfr = new SfRadioGroup();
        UIButton button = new UIButton();
        CALayer layer = new CALayer();
        CALayer innerLayer = new CALayer();
        UIAlertView alertView = new UIAlertView();
        SfRadioButton netBanking = new SfRadioButton();
        SfRadioButton debitCard = new SfRadioButton();
        SfRadioButton creditCard = new SfRadioButton();
        UIFontDescriptor descriptor = null;
        UIFontDescriptorSymbolicTraits traits = (UIFontDescriptorSymbolicTraits)0;

        public RadioButton_Mobile()
        {
            View = new UIView();

            //Main statck
            layer.BorderWidth = 1.5f;
            layer.CornerRadius = 10;
            layer.BorderColor = UIColor.FromRGB(205, 205, 205).CGColor;
			Layer.AddSublayer(layer);

            //inner layer
            innerLayer.BorderWidth = 1.5f;
            innerLayer.CornerRadius = 10;
            innerLayer.BorderColor = UIColor.FromRGB(205, 205, 205).CGColor;
            mainStackView.Layer.AddSublayer(innerLayer);

            descriptor = new UIFontDescriptor().CreateWithFamily(amntLabl.Font.FamilyName);
            traits = traits | UIFontDescriptorSymbolicTraits.Bold;
            descriptor = descriptor.CreateWithTraits(traits);

            //heading
            hedinglbl.Text = "Complete your Payment";
            hedinglbl.TextColor = UIColor.FromRGB(85, 85, 85);
            hedinglbl.Font = UIFont.FromDescriptor(descriptor, 20);
            mainStackView.AddSubview(hedinglbl);

            //payable
            payamountlabl.Text = "Total payable amount";
            payamountlabl.TextColor = UIColor.Black;
            mainStackView.AddSubview(payamountlabl);

            //amount
            amntLabl.Text = "$120";
            amntLabl.TextColor = UIColor.FromRGB(0, 125, 230);
            amntLabl.Font = UIFont.FromDescriptor(descriptor, 18);
            mainStackView.AddSubview(amntLabl);

            //amount
            selcetPaylbl.Text = "Select your payment mode";
            mainStackView.AddSubview(selcetPaylbl);

            //RadioGroup
            sfr.Axis = UILayoutConstraintAxis.Vertical;
            sfr.Spacing = 20;

            netBanking.SetTitle("Net banking", UIControlState.Normal);
            netBanking.StateChanged += paymentMode_StateChanged;
            sfr.AddArrangedSubview(netBanking);
            
            debitCard.SetTitle("Debit card", UIControlState.Normal);
            debitCard.StateChanged += paymentMode_StateChanged;
            sfr.AddArrangedSubview(debitCard);
            
            creditCard.SetTitle("Credit card", UIControlState.Normal);
            creditCard.StateChanged += paymentMode_StateChanged;
            sfr.AddArrangedSubview(creditCard);

            mainStackView.AddSubview(sfr);
            View.AddSubview(mainStackView);
            button.SetTitle("Pay Now", UIControlState.Normal);
            button.SetTitleColor(UIColor.LightGray, UIControlState.Disabled);
            button.SetTitleColor(UIColor.White, UIControlState.Normal);
            button.TouchDown += Button_Clicked;
            button.BackgroundColor = UIColor.FromRGB(0, 125, 230);
            button.Enabled = false;
            alertView.Message = "Payment Successfull !";
            alertView.AddButton("OK");
            View.AddSubview(button);
            AddSubview(View);
        }

        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                view.Frame = new CGRect(Frame.Location.X, 0.0f, Frame.Size.Width, Frame.Size.Height);
                if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    mainStackView.Frame = new CGRect(45, 110, Frame.Size.Width - 110, 550);
                    layer.Frame = new CGRect(45, 90, Frame.Size.Width - 110, 550);
                    hedinglbl.Frame = new CGRect(150, 20, 400, 45);
                    payamountlabl.Frame = new CGRect(20, 100, 350, 35);
                    amntLabl.Frame = new CGRect(580, 100, 350, 35);
                    innerLayer.Frame = new CGRect(17, 170, 625, 2);
                    selcetPaylbl.Frame = new CGRect(20, 205, 400, 35);
                    sfr.Frame = new CGRect(20, 275, 200, 200);
                    sfr.Spacing = 40;
                    button.Frame = new CGRect(0, Frame.Size.Height - 40, Frame.Size.Width, 40);
                    hedinglbl.Font = UIFont.FromDescriptor(descriptor, 30);
                    payamountlabl.Font = UIFont.FromName(payamountlabl.Font.FamilyName, 22);
                    amntLabl.Font = UIFont.FromDescriptor(descriptor, 22);
                    selcetPaylbl.Font = UIFont.FromName(selcetPaylbl.Font.FamilyName, 22);
                    netBanking.Font = UIFont.FromName(netBanking.Font.FamilyName, 20);
                    debitCard.Font = UIFont.FromName(netBanking.Font.FamilyName, 20);
                    creditCard.Font = UIFont.FromName(netBanking.Font.FamilyName, 20);
                    button.Font = UIFont.FromName(netBanking.Font.FamilyName, 25);
                }
                else
                {
                    mainStackView.Frame = new CGRect(20, 35, Frame.Size.Width - 40, 400);
                    layer.Frame = new CGRect(20, 35, Frame.Size.Width - 40, 400);
                    hedinglbl.Frame = new CGRect(20, 20, 260, 30);
                    payamountlabl.Frame = new CGRect(10, 75, 200, 35);
                    amntLabl.Frame = new CGRect(220, 75, 200, 35);
                    innerLayer.Frame = new CGRect(8, 140, 263, 1);
                    selcetPaylbl.Frame = new CGRect(10, 165, 250, 35);
                    sfr.Frame = new CGRect(10, 220, 200, 150);
                    button.Frame = new CGRect(0, 465, Frame.Size.Width, 38);
                }
            }
            base.LayoutSubviews();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            alertView.Show();
            debitCard.IsChecked = false;
            creditCard.IsChecked = false;
            netBanking.IsChecked = false;
            button.Enabled = false;
        }

        private void paymentMode_StateChanged(object sender, StateChangedEventArgs eventArgs)
        {
            button.Enabled = true;
        }
    }
}
