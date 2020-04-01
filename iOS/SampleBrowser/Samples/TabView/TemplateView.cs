#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using UIKit;

namespace SampleBrowser
{
    internal class TemplateView : UIView
    {
        UIImageView imageView;
        UILabel imageLabel;
        UILabel ratingLabel;
        UILabel ratingTextLabel;
        UILabel priceLabel;
        UILabel offerLabel;
        UILabel descriptionLabel;
        UIView ratingView;

        public TemplateView()
        {
           

           
                this.BackgroundColor = UIColor.White;
                imageView = new UIImageView();
                imageView.BackgroundColor = UIColor.Red;

                imageLabel = new UILabel();
                imageLabel.LineBreakMode = UILineBreakMode.WordWrap;
                imageLabel.Lines = 2;
                imageLabel.Font = UIFont.SystemFontOfSize(17);

                ratingView = new UIView();
                ratingView.Layer.CornerRadius = 9;
                ratingView.ClipsToBounds = true;
                ratingView.BackgroundColor = UIColor.FromRGB(77, 146, 223);

                ratingLabel = new UILabel();
                ratingLabel.TextColor = UIColor.White;
                ratingLabel.Text = "\uE735";
                ratingLabel.TextAlignment = UITextAlignment.Center;
                ratingLabel.Font = UIFont.FromName("Segoe MDL2 Assets", 10);

                ratingTextLabel = new UILabel();
                ratingTextLabel.TextColor = UIColor.White;
                ratingTextLabel.TextAlignment = UITextAlignment.Center;
                ratingTextLabel.Font = UIFont.SystemFontOfSize(10);

                ratingView.Add(ratingLabel);
                ratingView.Add(ratingTextLabel);

                descriptionLabel = new UILabel();
                descriptionLabel.LineBreakMode = UILineBreakMode.WordWrap;
                descriptionLabel.Lines = 10;
                descriptionLabel.TextColor = UIColor.FromRGB(134, 134, 134);
                descriptionLabel.Font = UIFont.SystemFontOfSize((nfloat)8.5);


                priceLabel = new UILabel();
                priceLabel.TextColor = UIColor.FromRGB(128, 207, 53); ;
                priceLabel.LineBreakMode = UILineBreakMode.WordWrap;
                priceLabel.Font = UIFont.SystemFontOfSize((nfloat)13);

                offerLabel = new UILabel();
                offerLabel.TextColor = UIColor.FromRGB(128, 207, 53);
                offerLabel.LineBreakMode = UILineBreakMode.WordWrap;
                offerLabel.Font = UIFont.SystemFontOfSize((nfloat)13);

            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            { 
                imageLabel.Font = UIFont.SystemFontOfSize(22);

                priceLabel.Font = UIFont.SystemFontOfSize(18);

                offerLabel.Font = UIFont.SystemFontOfSize(18);

                descriptionLabel.Font = UIFont.SystemFontOfSize(14);
                descriptionLabel.LineBreakMode = UILineBreakMode.WordWrap;
                descriptionLabel.Lines = 3;

            }
           

            Add(imageView);
            Add(imageLabel);
            Add(ratingView);
            Add(priceLabel);
            Add(offerLabel);
            Add(descriptionLabel);
        }

        public override void LayoutSubviews()
        {
            if(this.Frame.Width > 0 && this.Frame.Height > 0)
            {
              
                if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    imageView.Frame = new CGRect(10, 10, 150, 140);
                    imageLabel.Frame = new CGRect(168, 0, 550, 50);
                    ratingView.Frame = new CGRect(375, 49, 35, 20);
                    priceLabel.Frame = new CGRect(168, 49, 275, 20);
                    offerLabel.Frame = new CGRect(270, 49, 275, 20);
                    descriptionLabel.Frame = new CGRect(168, 69, 570, 85);
                    ratingLabel.Frame = new CGRect(0, 0, 15, ratingView.Frame.Height);
                    ratingTextLabel.Frame = new CGRect(8, 0, 30, ratingView.Frame.Height);
                }
                else
                {
                    imageView.Frame = new CGRect(10, 10, 150, 140);
                    imageLabel.Frame = new CGRect(168, 0, 90, 50);
                    ratingView.Frame = new CGRect(this.Frame.Width / 2 + 110, 5, 35, 20);

                    priceLabel.Frame = new CGRect(168, 49, 53, 20);
                    offerLabel.Frame = new CGRect(235, 49, 80, 20);

                    descriptionLabel.Frame = new CGRect(168, 69, 125, 85);

                    ratingLabel.Frame = new CGRect(0, 0, 15, ratingView.Frame.Height);
                    ratingTextLabel.Frame = new CGRect(8, 0, 30, ratingView.Frame.Height);
                }

            }
            base.LayoutSubviews();
        }

        internal void UpdateContent(string image, string title, string price, string offer, string rating,string description)
        {
            imageView.Image = UIImage.FromBundle(image);
            imageLabel.Text = title;
            priceLabel.Text = price;
            offerLabel.Text = offer+" Offer";
            ratingTextLabel.Text = rating;
            descriptionLabel.Text = description;
        }
    }
}
