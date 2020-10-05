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
	public class SampleView : UIView
	{
        #region ctor

        public SampleView()
		{
		}

        #endregion

        #region properties

        public UIView OptionView { get; set; }

		public static CGSize PopoverSize
		{
			get { return new CGSize(320.0, 400.0); }
		}

        public UINavigationController NavigationController { get; set; }

        #endregion

        #region methods

        public virtual void OnOptionsViewClosed()
        {
        }

		public virtual void ViewWillAppear()
		{
		}

		public virtual void ViewWillDisappear()
		{
		}

        #endregion
    }
}
