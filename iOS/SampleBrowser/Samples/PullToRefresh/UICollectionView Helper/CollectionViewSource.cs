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