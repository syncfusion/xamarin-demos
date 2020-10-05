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
using CoreGraphics;
using Foundation;
using UIKit;

namespace SampleBrowser
{
	public static class Utility
	{
        #region interface

        public interface ISpecialDisposable
        {
            void SpecialDispose();
        }

        #endregion

        #region properties

        public static UIColor ThemeColor { get; set; } = UIColor.FromRGB(3.0f / 255.0f, 126.0f / 255.0f, 249.0f / 255.0f);

        public static UIColor BackgroundColor { get; set; } = UIColor.FromRGB(242.0f / 255.0f, 242.0f / 255.0f, 242.0f / 255.0f);

		public static UIFont TitleFont { get; set; } = UIFont.FromName("Helvetica", 14f);

		public static UIFont SmallFont { get; set; } = UIFont.FromName("Helvetica", 10f);

        public static bool IsIPad
		{
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad; }
		}

        #endregion

        #region methods

        public static CGSize SizeForStringWithFont(string text, UIFont font)
		{
			NSString value = new NSString(text);
            UIStringAttributes attribs = new UIStringAttributes { Font = font };
			CGSize size = value.GetSizeUsingAttributes(attribs);

			return size;
		}

		public static void DisposeEx(UIView view)
		{
			try
			{
				var disposeView = true;
				var disconnectFromSuperView = true;
				var disposeSubviews = true;
				var removeGestureRecognizers = false; 
				var removeLayerAnimations = true;
				var associatedViewsToDispose = new List<UIView>();
				var otherDisposables = new List<IDisposable>();

                var activityIndicatorView = view as UIActivityIndicatorView;
                var tableView = view as UITableView;
                var tableViewCell = view as UITableViewCell;
                var collectionView = view as UICollectionView;
                var collectionViewCell = view as UICollectionViewCell;
                var webView = view as UIWebView;
                var imageView = view as UIImageView;

                if (activityIndicatorView != null)
                {
                    if (activityIndicatorView.IsAnimating)
                    {
                        activityIndicatorView.StopAnimating();
                    }
                }
                else if (tableView != null)
				{
					if (tableView.DataSource != null)
					{
						otherDisposables.Add(tableView.DataSource);
					}

					if (tableView.BackgroundView != null)
					{
						associatedViewsToDispose.Add(tableView.BackgroundView);
					}

					tableView.Source = null;
					tableView.Delegate = null;
					tableView.DataSource = null;
					tableView.WeakDelegate = null;
					tableView.WeakDataSource = null;
					associatedViewsToDispose.AddRange(tableView.VisibleCells ?? new UITableViewCell[0]);
				}
                else if (tableViewCell != null)
				{
					disposeView = false;
					disconnectFromSuperView = false;
					if (tableViewCell.ImageView != null)
					{
						associatedViewsToDispose.Add(tableViewCell.ImageView);
					}
				}
                else if (collectionView != null)
				{
					disposeView = false;
					if (collectionView.DataSource != null)
					{
						otherDisposables.Add(collectionView.DataSource);
					}

					if (!(collectionView.BackgroundView == null))
					{
						associatedViewsToDispose.Add(collectionView.BackgroundView);
					}

					collectionView.Source = null;
					collectionView.Delegate = null;
					collectionView.DataSource = null;
					collectionView.WeakDelegate = null;
					collectionView.WeakDataSource = null;
				}
                else if (collectionViewCell != null)
				{
					disposeView = false;
					disconnectFromSuperView = false;
					if (collectionViewCell.BackgroundView != null)
					{
						associatedViewsToDispose.Add(collectionViewCell.BackgroundView);
					}
				}
                else if (webView != null)
				{
                    if (webView.IsLoading)
                    {
                        webView.StopLoading();
                    }

					webView.LoadHtmlString(string.Empty, null); // clear display
					webView.Delegate = null;
					webView.WeakDelegate = null;
				}
                else if (imageView != null)
				{
					if (imageView.Image != null)
					{
						otherDisposables.Add(imageView.Image);
						imageView.Image = null;
					}
				}
				
				var gestures = view.GestureRecognizers;
				if (removeGestureRecognizers && gestures != null)
				{
					foreach (var gr in gestures)
					{
						view.RemoveGestureRecognizer(gr);
						gr.Dispose();
					}
				}

				if (removeLayerAnimations && view.Layer != null)
				{
					view.Layer.RemoveAllAnimations();
				}

				if (disconnectFromSuperView && view.Superview != null)
				{
					view.RemoveFromSuperview();
				}

				var constraints = view.Constraints;
				if (constraints != null && constraints.Any() && constraints.All(c => c.Handle != IntPtr.Zero))
				{
					view.RemoveConstraints(constraints);
					foreach (var constraint in constraints)
					{
						constraint.Dispose();
					}
				}

				foreach (var otherDisposable in otherDisposables)
				{
					otherDisposable.Dispose();
				}

				foreach (var otherView in associatedViewsToDispose)
				{
					DisposeEx(otherView);
				}

				var subViews = view.Subviews;
				if (disposeSubviews && subViews != null)
				{
                    foreach (UIView subview in subViews)
                    {
                        DisposeEx(subview);
                    }
				}

                var disposableView = view as ISpecialDisposable;
                if (disposableView != null)
				{
                    disposableView.SpecialDispose();
				}
				else 
					if (disposeView)
				{
                    if (view.Handle != IntPtr.Zero)
                    {
                        view.Dispose();
                    }
				}
			}
			catch
			{
			}
		}

		public static bool IsDisposedOrNull(UIView view)
		{
            if (view == null)
            {
                return true;
            }

            if (view.Handle == IntPtr.Zero)
            {
                return true;
            }

			return false;
		}

        #endregion
    }
}
