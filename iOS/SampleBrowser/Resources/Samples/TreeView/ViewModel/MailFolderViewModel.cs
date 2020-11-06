#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SampleBrowser
{
    public class MailFolderViewModel
    {
        public ObservableCollection<MailFolder> Folders { get; set; }

        public MailFolderViewModel()
        {
            GenerateItems();
        }

        private void GenerateItems()
        {
            var fav = new MailFolder() { FolderName = "Favorites" };
            var myFolder = new MailFolder() { FolderName = "My Folder" };
            var inbox = new MailFolder() { FolderName = "Inbox", MailsCount = 20 };
            var drafts = new MailFolder() { FolderName = "Drafts", MailsCount = 5 };
            var deleted = new MailFolder() { FolderName = "Deleted Items" };
            var sent = new MailFolder() { FolderName = "Sent Items" };
            var sales = new MailFolder() { FolderName = "Sales Report", MailsCount = 4 };
            var marketing = new MailFolder() { FolderName = "Marketing Reports", MailsCount = 6 };
            var outbox = new MailFolder() { FolderName = "Outbox" };

            fav.SubFolder = new ObservableCollection<MailFolder>
            {
                new MailFolder() { FolderName = "Sales Report", MailsCount = 4 },
                new MailFolder() { FolderName = "Sent Items" },
                new MailFolder() { FolderName = "Marketing Reports", MailsCount = 6 }
            };

            myFolder.SubFolder = new ObservableCollection<MailFolder>
            {
                inbox,
                drafts,
                deleted,
                sent,
                sales,
                marketing,
                outbox
            };

            this.Folders = new ObservableCollection<MailFolder>();
            Folders.Add(fav);
            Folders.Add(myFolder);
        }
    }
}