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
            var calender = new MailFolder() { FolderName = "Calender" };
            var birthday = new MailFolder() { FolderName = "Birthdays" };
            var holiday = new MailFolder() { FolderName = "Holidays" };
            var groups = new MailFolder() { FolderName = "Groups" };
            var developmentTeam = new MailFolder() { FolderName = "Development Team", MailsCount = 11 };
            var salesTeam = new MailFolder() { FolderName = "Sales Team", MailsCount = 5 };
            var testingTeam = new MailFolder() { FolderName = "Testing Team", MailsCount = 33 };

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
            calender.SubFolder = new ObservableCollection<MailFolder>
            {
                birthday,
                holiday
            };

            groups.SubFolder = new ObservableCollection<MailFolder>
            {
                developmentTeam,
                salesTeam,
                testingTeam
            };

            this.Folders = new ObservableCollection<MailFolder>();
            Folders.Add(fav);
            Folders.Add(myFolder);
            Folders.Add(calender);
            Folders.Add(groups);
        }
    }
}