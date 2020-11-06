#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Drawing;

using CoreGraphics;
using Foundation;
using UIKit;

namespace SampleBrowser
{
    [Register("ActivityIndicator")]
    public class ActivityIndicator : UIView
    {
        UILabel m_messageLabel;
        UIActivityIndicatorView activityIndicator;
        internal UILabel MessageLabel
        {
            get
            {
                return m_messageLabel;
            }
            set
            {
                m_messageLabel = value;
            }
        }
        public ActivityIndicator(CGRect frame): base(frame)
        {
            m_messageLabel = new UILabel();
            Frame = frame;
            BackgroundColor = UIColor.FromRGBA(0, 0, 0, 0.3f);
            activityIndicator.Color = UIColor.Blue;
            Layer.CornerRadius = 20;
            Layer.BorderWidth = 10;                      
        }
        public ActivityIndicator()
        {
            m_messageLabel = new UILabel();
            activityIndicator = new UIActivityIndicatorView();
            BackgroundColor = UIColor.FromRGBA(0, 0, 0, 0.3f);
            activityIndicator.Color = UIColor.Blue;
            activityIndicator.Frame = new CGRect(this.Frame.X, this.Frame.Y+10, 100,50);
            m_messageLabel.Frame= new CGRect(this.Frame.X + 60, this.Frame.Y , 200, 75);
        }
        public void SetMessage(string message)
        {
            m_messageLabel.TextColor = UIColor.White;
            m_messageLabel.Text = message;                                
        }
        public  void StartAnimating()
        {
            this.AddSubview(m_messageLabel);
            this.AddSubview(activityIndicator);
            activityIndicator.StartAnimating();            
        }
        public void StopAnimating()
        {
            activityIndicator.StopAnimating();
            this.RemoveFromSuperview();
        }
        public bool IsAnimating
        {
            get
            {
                if(activityIndicator!=null)
                return activityIndicator.IsAnimating;
                return false;
            }            
        }
    }
}