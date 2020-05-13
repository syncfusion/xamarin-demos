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
    public class TaskInfo : INotifyPropertyChanged
    {
        #region Fields

        private string _Title;
        private string _Description;
        private string _Tag;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value that indicates Task's header. 
        /// </summary>
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
                this.RaisePropertyChanged("Title");
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates Task's description. 
        /// </summary>
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
                this.RaisePropertyChanged("Description");
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates Task's tag collection. 
        /// </summary>
        public string Tag
        {
            get
            {
                return _Tag;
            }
            set
            {
                _Tag = value;
                this.RaisePropertyChanged("Tag");
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
