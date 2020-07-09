#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "GettingStartedModel.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion

namespace SampleBrowser.SfDataGrid
{
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A class contains properties and notifies clients that a property value has changed.
    /// </summary>  
    public class GettingStartedModel : INotifyPropertyChanged
    {
        #region Private Members

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string team;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string location;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int wins;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int losses;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string image;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private double pct;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private double gb;

        #endregion

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        
        #region Public properties

        /// <summary>
        /// Gets or sets the Team.
        /// </summary>
        /// <value>The Team.</value>
        public string Team
        {
            get
            {
                return this.team;
            }

            set
            {
                this.team = value;
                this.RaisePropertyChanged("Team");
            }
        }

        /// <summary>
        /// Gets or sets the PCT.
        /// </summary>
        /// <value>The PCT.</value>
        public double PCT
        {
            get
            {
                return this.pct;
            }

            set
            {
                this.pct = value;
                this.RaisePropertyChanged("PCT");
            }
        }

        /// <summary>
        /// Gets or sets the GB.
        /// </summary>
        /// <value>The GB.</value>
        public double GB
        {
            get
            {
                return this.gb;
            }

            set
            {
                this.gb = value;
                this.RaisePropertyChanged("GB");
            }
        }

        /// <summary>
        /// Gets or sets the Wins.
        /// </summary>
        /// <value>The Wins.</value>
        public int Wins
        {
            get
            {
                return this.wins;
            }

            set
            {
                this.wins = value;
                this.RaisePropertyChanged("Wins");
            }
        }

        /// <summary>
        /// Gets or sets the Losses.
        /// </summary>
        /// <value>The Losses.</value>
        public int Losses
        {
            get
            {
                return this.losses;
            }

            set
            {
                this.losses = value;
                this.RaisePropertyChanged("Losses");
            }
        }

        /// <summary>
        /// Gets or sets the team image source.
        /// </summary>
        /// <value>The image source for team.</value>
        public string Image
        {
            get
            {
                return this.image;
            }

            set
            {
                this.image = value;
                this.RaisePropertyChanged("Image");
            }
        }

        /// <summary>
        /// Gets or sets the Location.
        /// </summary>
        /// <value>The Location.</value>
        public string Location
        {
            get
            {
                return this.location;
            }

            set
            {
                this.location = value;
                this.RaisePropertyChanged("Location");
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="propertyName">string type of parameter propertyName</param>
        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}