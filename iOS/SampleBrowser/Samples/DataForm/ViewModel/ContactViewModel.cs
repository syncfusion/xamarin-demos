using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
    public class ListViewGroupingViewModel
    {
        #region Fields

        private ObservableCollection<ContactInfo> contactsInfo;

        #endregion

        #region Constructor

        public ListViewGroupingViewModel()
        {
            GenerateSource(100);
        }

        #endregion

        #region Properties

        public ObservableCollection<ContactInfo> ContactsInfo
        {
            get { return contactsInfo; }
            set { this.contactsInfo = value; }
        }

        #endregion

        #region ItemSource

        public void GenerateSource(int count)
        {
            ContactsInfoRepository contactRepository = new ContactsInfoRepository();
            contactsInfo = contactRepository.GetContactDetails(count);
        }

        #endregion }
    }
}