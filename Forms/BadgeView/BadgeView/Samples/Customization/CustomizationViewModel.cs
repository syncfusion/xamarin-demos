#region Copyright Syncfusion Inc. 2001-2019.
// ------------------------------------------------------------------------------------
// <copyright file = "CustomizationViewModel.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfBadgeView
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using Syncfusion.XForms.BadgeView;
    using Syncfusion.XForms.Buttons;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    /// <summary>
	/// Customization View Model class.
	/// </summary>
	[Preserve(AllMembers = true)]
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1027:TabsMustNotBeUsed", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
    public class CustomizationViewModel : INotifyPropertyChanged
    {
        #region Fields

        private BadgeIcon badgeIcon;

        private BadgeType badgeType;

        private Color backgroundColor = Color.FromHex("#F25B8E");

        #endregion

        #region Event

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        #region BadgeIcon

        /// <summary>
        /// Gets or sets the badge icon
        /// </summary>
        public BadgeIcon BadgeIcon
        {
            get
            {
                return this.badgeIcon;
            }

            set
            {
                this.badgeIcon = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("BadgeIcon"));
                }
            }
        }

        #endregion BadgeIcon

        #region BadgeType

        /// <summary>
        /// Gets or sets the badge type
        /// </summary>
        public BadgeType BadgeType
        {
            get
            {
                return this.badgeType;
            }

            set
            {
                this.badgeType = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("BadgeType"));
                }
            }
        }
        #endregion BadgeType

        /// <summary>
        /// Gets or sets the background color of button.
        /// </summary>
        /// <value>The background color of button</value>
        public Color BackgroundColor
        {
            get
            {
                return backgroundColor;
            }
            set
            {
                backgroundColor = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("BackgroundColor"));
                }
            }
        }

        public ObservableCollection<Color> Colors { get; set; }

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:button.buttonViewModel"/> class.
        /// </summary>
        public CustomizationViewModel()
        {
            this.Colors = new ObservableCollection<Color>();
            Colors.Add(Color.FromHex("#F25B8E"));
            Colors.Add(Color.FromHex("#EE80F0"));
            Colors.Add(Color.FromHex("#F0A043"));
            Colors.Add(Color.FromHex("#7C7FF1"));
            Colors.Add(Color.FromHex("#5BBBDD"));
        }
                #endregion
    }
  
}
