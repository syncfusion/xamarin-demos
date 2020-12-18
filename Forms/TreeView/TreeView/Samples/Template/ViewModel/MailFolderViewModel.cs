#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfTreeView
{
    [Preserve(AllMembers = true)]
    public class MailFolderViewModel
    {
        public ObservableCollection<MailFolder> Folders { get; set; }

        public ObservableCollection<SubFolder> SubFolders { get; set; }

        public MailFolderViewModel()
        {
            Folders=GenerateItems();
        }

        private ObservableCollection<MailFolder> GenerateItems()
        {

            var fav = new MailFolder() { FolderName = "Favorites" };
            var myFolder = new MailFolder() { FolderName = "My Folder" };
            var calender = new MailFolder() { FolderName = "Calender" };
            var groups = new MailFolder() { FolderName = "Groups" };

            var inbox = new SubFolder() { FolderName = "Inbox", MailsCount = 20 };
            var drafts = new SubFolder() { FolderName = "Drafts", MailsCount = 5 };
            var deleted = new SubFolder() { FolderName = "Deleted Items" };
            var sent = new SubFolder() { FolderName = "Sent Items" };
            var sales = new SubFolder() { FolderName = "Sales Report", MailsCount = 4 };
            var marketing = new SubFolder() { FolderName = "Marketing Reports", MailsCount = 6 };
            var outbox = new SubFolder() { FolderName = "Outbox" };
            var birthday = new SubFolder() { FolderName = "Birthdays" };
            var holiday = new SubFolder() { FolderName = "Holidays" };
            var developmentTeam = new SubFolder() { FolderName = "Development Team", MailsCount = 11 };
            var salesTeam = new SubFolder() { FolderName = "Sales Team", MailsCount = 5 };
            var testingTeam = new SubFolder() { FolderName = "Testing Team", MailsCount = 33 };
            fav.SubFolder = new ObservableCollection<SubFolder>
            {
                new SubFolder() { FolderName = "Sales Report", MailsCount = 4 },
                new SubFolder() { FolderName = "Sent Items" },
                new SubFolder() { FolderName = "Marketing Reports", MailsCount = 6 }
            };

            myFolder.SubFolder = new ObservableCollection<SubFolder>
            {
                inbox,
                drafts,
                deleted,
                sent,
                sales,
                marketing,
                outbox
            };

            calender.SubFolder = new ObservableCollection<SubFolder>
            {
                birthday,
                holiday
            };

            groups.SubFolder = new ObservableCollection<SubFolder>
            {
                developmentTeam,
                salesTeam,
                testingTeam
            };

            var folders = new ObservableCollection<MailFolder>();
            folders.Add(fav);
            folders.Add(myFolder);
            folders.Add(calender);
            folders.Add(groups);
            return folders;
        }
    }
}
