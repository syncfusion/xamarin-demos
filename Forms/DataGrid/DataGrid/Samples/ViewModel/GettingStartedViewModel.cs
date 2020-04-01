#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "GettingStartedViewModel.cs" company="Syncfusion.com">
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
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Syncfusion.Data;
    using Syncfusion.Data.Extensions;
    using Syncfusion.SfDataGrid.XForms;
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    /// A ViewModel for GettingStarted sample.
    /// </summary>
    public class GettingStartedViewModel : INotifyPropertyChanged
    {
        #region Fields

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ObservableCollection<GettingStartedModel> data;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private List<string> stockSymbols = new List<string>();
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] location = new string[]
        {
            "East",
            "West",
            "Central",
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] teamName = new string[]
        {
            "Cavaliers",
            "Clippers",
            "DenverNuggets",
            "DetroitPistons",
            "GoldenState",
            "Hornets",
            "LosAngeles",
            "Mavericks",
            "Memphis",
            "Miami",
            "Milwakke",
            "NewYork",
            "Orlando",
            "Thunder",
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int[] wins = new int[]
       {
           93, 82, 76, 77, 52,
           84, 82, 81, 70, 65,
           97, 77, 72, 68, 66
       };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int[] losses = new int[]
        {
           58, 67, 72, 73, 98,
           66, 68, 69, 81, 85,
           54, 74, 78, 82, 85,
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private double[] pct = new double[]
       {
           .616, .550, .514, .513, .347,
           .560, .547, .540, .464, .433,
           .642, .510, .480, .453, .437
       };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private double[] gb = new double[]
        {
            0, 10, 15.5, 15.5, 40.5,
            0, 2, 3, 14.5, 19,
            0, 20, 24.5, 28.5, 31,
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] l10 = new string[]
        {
            "6-4", "4-6", "4-6", "5-5", "2-8",
            "5-5", "6-4", "9-1", "4-6", "4-6",
            "6-4", "3-7", "5-5", "4-6", "7-3"
        };

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the GettingStartedViewModel class. 
        /// </summary>
        public GettingStartedViewModel()
        {
            this.data = new ObservableCollection<GettingStartedModel>();
            this.AddRows(14);
        }

        #endregion
        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the Data.
        /// </summary>
        /// <value>The Data.</value>
        public ObservableCollection<GettingStartedModel> Data
        {
            get { return this.data; }
        }

        #region updating code

        /// <summary>
        /// Adds the rows.
        /// </summary>
        /// <param name="count">The given count.</param>
        private void AddRows(int count)
        {
            for (int i = 1; i < count; i++)
            {
                this.data.Add(this.GetTeamDetail(i));
            }
        }

        /// <summary>
        /// Get the Employee details.
        /// </summary>
        /// <param name="i">record index</param>
        /// <returns>team details</returns>
        private GettingStartedModel GetTeamDetail(int i)
        {
            return new GettingStartedModel()
            {
                Team = this.teamName[i],
                PCT = this.pct[i],
                GB = this.gb[i],
                Wins = this.wins[i],
                Losses = this.losses[i],
                Image = this.teamName[i] == "Thunder" ? this.teamName[i] + "_Logo.png" : this.teamName[i] + ".png",
                Location = this.location[i % 3]
            };
        }

        #endregion

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="name">string type of name</param>
        private void RaisePropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}
