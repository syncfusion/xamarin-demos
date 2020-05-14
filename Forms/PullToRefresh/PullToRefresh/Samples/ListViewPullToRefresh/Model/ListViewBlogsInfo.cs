#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "ListViewBlogsInfo.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPullToRefresh
{
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A class contains Properties and Notifies that a property value has changed 
    /// </summary>
    public class ListViewBlogsInfo : INotifyPropertyChanged
    {
        #region Fields

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string blogTitle;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string blogCategory;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string blogAuthor;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ImageSource categoryIcon;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ImageSource autherIcon;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ImageSource blogFacebookIcon;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ImageSource blogTwitterIcon;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ImageSource blogGooglePlusIcon;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ImageSource blogLinkedInIcon;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string readMoreContent;

        #endregion

        #region Constructor

        #endregion

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

        /// <summary>
        /// Gets or sets the BlogTitle and notifies user when collection value gets changed.
        /// </summary>
        public string BlogTitle
        {
            get
            {
                return this.blogTitle;
            }

            set
            {
                this.blogTitle = value;
                this.OnPropertyChanged("BlogTitle");
            }
        }

        /// <summary>
        /// Gets or sets the BlogCategory and notifies user when collection value gets changed.
        /// </summary>
        public string BlogCategory
        {
            get
            {
                return this.blogCategory;
            }

            set
            {
                this.blogCategory = value;
                this.OnPropertyChanged("BlogCategory");
            }
        }

        /// <summary>
        /// Gets or sets the BlogAuthor and notifies user when collection value gets changed.
        /// </summary>
        public string BlogAuthor
        {
            get
            {
                return this.blogAuthor;
            }

            set
            {
                this.blogAuthor = value;
                this.OnPropertyChanged("BlogAuthor");
            }
        }

        /// <summary>
        /// Gets or sets the BlogAuthorIcon and notifies user when collection value gets changed.
        /// </summary>
        public ImageSource BlogAuthorIcon
        {
            get
            {
                return this.autherIcon; 
            }

            set
            {
                this.autherIcon = value;
                this.OnPropertyChanged("BlogAuthorIcon");
            }
        }

        /// <summary>
        /// Gets or sets the BlogCategoryIcon and notifies user when collection value gets changed.
        /// </summary>
        public ImageSource BlogCategoryIcon
        {
            get
            {
                return this.categoryIcon; 
            }

            set
            {
                this.categoryIcon = value;
                this.OnPropertyChanged("BlogCategoryIcon");
            }
        }

        /// <summary>
        /// Gets or sets the BlogFacebookIcon and notifies user when collection value gets changed.
        /// </summary>
        public ImageSource BlogFacebookIcon
        {
            get
            {
                return this.blogFacebookIcon; 
            }

            set
            {
                this.blogFacebookIcon = value;
                this.OnPropertyChanged("BlogFacebookIcon");
            }
        }

        /// <summary>
        /// Gets or sets the BlogTwitterIcon and notifies user when collection value gets changed.
        /// </summary>
        public ImageSource BlogTwitterIcon
        {
            get
            {
                return this.blogTwitterIcon; 
            }

            set
            {
                this.blogTwitterIcon = value;
                this.OnPropertyChanged("BlogTwitterIcon");
            }
        }

        /// <summary>
        /// Gets or sets the BlogGooglePlusIcon and notifies user when collection value gets changed.
        /// </summary>
        public ImageSource BlogGooglePlusIcon
        {
            get
            {
                return this.blogGooglePlusIcon; 
            }
           
            set
            {
                this.blogGooglePlusIcon = value;
                this.OnPropertyChanged("BlogGooglePlusIcon");
            }
        }

        /// <summary>
        /// Gets or sets the BlogLinkedInIcon and notifies user when collection value gets changed.
        /// </summary>
        public ImageSource BlogLinkedInIcon
        {
            get
            {
                return this.blogLinkedInIcon;
            }

            set
            {
                this.blogLinkedInIcon = value;
                this.OnPropertyChanged("BlogLinkedInIcon");
            }
        }

        /// <summary>
        /// Gets or sets the ReadMoreContent and notifies user when collection value gets changed.
        /// </summary>
        public string ReadMoreContent
        {
            get
            {
                return this.readMoreContent;
            }

            set
            {
                this.readMoreContent = value;
                this.OnPropertyChanged("ReadMoreContent");
            }
        }

        #endregion

        #region Interface Member

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="name">string type parameter named as name represents property name</param>
        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}