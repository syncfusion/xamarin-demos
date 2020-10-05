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
using System.Collections.ObjectModel;

namespace SampleBrowser
{
    public class CollectionViewSource : UICollectionViewDataSource
    {
        private ObservableCollection<Mail> items;
        public InboxRepositiory repository;

        public CollectionViewSource() : base()
        {
            repository = new InboxRepositiory();
            items = repository.InboxItems;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return items.Count;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.DequeueReusableCell(CollectionViewCell.CellID, indexPath) as CollectionViewCell;

            Mail mail = items[indexPath.Row];
            cell.UpdateRow(mail);
            cell.BackgroundColor = UIColor.White;
            return cell;
        }

    }
}