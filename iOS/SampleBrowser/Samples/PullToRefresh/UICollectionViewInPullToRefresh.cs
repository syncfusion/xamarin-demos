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
using Syncfusion.SfPullToRefresh;
using System.Threading.Tasks;
using CoreGraphics;

namespace SampleBrowser
{
    public class UICollectionViewInPullToRefresh : SampleView
    {
        SfPullToRefresh pullToRefresh;
        UICollectionView collectionView;
        CollectionViewSource collectionViewSource;
        UICollectionViewFlowLayout collectionViewFlowLayout;

        public UICollectionViewInPullToRefresh()
        {
            this.pullToRefresh = new SfPullToRefresh();
            this.pullToRefresh.Refreshing += PullToRefresh_Refreshing;
            this.pullToRefresh.TransitionType = TransitionType.Push;

            this.collectionViewFlowLayout = new UICollectionViewFlowLayout()
            {
                MinimumLineSpacing = 0.5f,
                ScrollDirection = UICollectionViewScrollDirection.Vertical,
            };

            this.collectionView = new UICollectionView(CGRect.Empty, collectionViewFlowLayout);
            this.collectionView.ShowsHorizontalScrollIndicator = false;
            this.collectionViewSource = new CollectionViewSource();
            this.collectionView.DataSource = this.collectionViewSource;
            this.collectionView.RegisterClassForCell(typeof(CollectionViewCell), CollectionViewCell.CellID);
            this.pullToRefresh.PullableContent = this.collectionView;
            this.pullToRefresh.PullableContent.BackgroundColor = UIColor.LightGray;
            this.AddSubview(this.pullToRefresh);
            this.OptionView = new Options(pullToRefresh);
        }

        private async void PullToRefresh_Refreshing(object sender, RefreshingEventArgs e)
        {
            await Task.Delay(3000);
            this.collectionViewSource.repository.RefreshItemSource();
            this.collectionView.ReloadData();
            e.Refreshed = true;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            this.pullToRefresh.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
            this.collectionViewFlowLayout.ItemSize = new CGSize(this.Frame.Width, 70);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (pullToRefresh != null)
                {
                    this.pullToRefresh.Refreshing -= PullToRefresh_Refreshing;
                    this.pullToRefresh.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}