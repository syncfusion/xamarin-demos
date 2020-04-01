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
using CoreGraphics;

namespace SampleBrowser
{
    public class CollectionViewCell : UICollectionViewCell
    {
        public static NSString CellID = new NSString("userCell");

        public CircleView imageView { get; set; }

        public UILabel senderLabel { get; set; }

        public UILabel dateLabel { get; set; }

        public UILabel subjectLabel { get; set; }

        public UILabel detailsLabel { get; set; }

        public CollectionViewCell(IntPtr handle) : base(handle)
        {
        
        }

        [Export("initWithFrame:")]
        public CollectionViewCell(CGRect frame) : base(frame)
        {
            InitializeViews();
        }

        private void InitializeViews()
        {
            imageView = new CircleView(new CGRect(5, 10, 45, 50));
            
            senderLabel = new UILabel(new CGRect(55, 5, this.Frame.Width - 60, 20));
            senderLabel.Lines = 1;
            senderLabel.Font = UIFont.BoldSystemFontOfSize(16);

            dateLabel = new UILabel(new CGRect(senderLabel.Frame.Width, 5, 40, 20));
            dateLabel.Font = UIFont.BoldSystemFontOfSize(10);
            dateLabel.TextColor = UIColor.FromRGB(0, 121, 255);

            subjectLabel = new UILabel(new CGRect(55, 25, this.Frame.Width - 70, 20));
            subjectLabel.Lines = 1;
            subjectLabel.LineBreakMode = UILineBreakMode.TailTruncation;
            subjectLabel.Font = UIFont.BoldSystemFontOfSize(13);

            detailsLabel = new UILabel(new CGRect(55, 45, this.Frame.Width - 70, 20));
            detailsLabel.Lines = 1;
            detailsLabel.LineBreakMode = UILineBreakMode.TailTruncation;
            detailsLabel.Font = UIFont.SystemFontOfSize(12);

            ContentView.AddSubview(imageView);
            ContentView.AddSubview(senderLabel);
            ContentView.AddSubview(dateLabel);
            ContentView.AddSubview(subjectLabel);
            ContentView.AddSubview(detailsLabel);
        }

        public void UpdateRow(Mail data)
        {
            senderLabel.Text = data.Sender;
            subjectLabel.Text = data.Subject;
            detailsLabel.Text = data.Details;
            dateLabel.Text = "20 Oct";
            imageView.ViewColor = data.BackgroundColor;
            imageView.text = data.Sender[0].ToString();
            imageView.SetNeedsDisplay();
        }
    }
}