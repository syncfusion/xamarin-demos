#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    public class ListViewBlogsInfo : INotifyPropertyChanged
    {
        #region Fields

        private string blogTitle;
        private string blogCategory;
        private string blogAuthor;
        private string readMoreContent;

        #endregion

        #region Constructor

        public ListViewBlogsInfo()
        {

        }

        #endregion

        #region Properties

        public string BlogTitle
        {
            get { return blogTitle; }
            set
            {
                blogTitle = value;
                OnPropertyChanged("BlogTitle");
            }
        }

        public string BlogCategory
        {
            get { return blogCategory; }
            set
            {
                blogCategory = value;
                OnPropertyChanged("BlogCategory");
            }
        }

        public string BlogAuthor
        {
            get { return blogAuthor; }
            set
            {
                blogAuthor = value;
                OnPropertyChanged("BlogAuthor");
            }
        }

        public string ReadMoreContent
        {
            get { return readMoreContent; }
            set
            {
                readMoreContent = value;
                OnPropertyChanged("ReadMoreContent");
            }
        }

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
