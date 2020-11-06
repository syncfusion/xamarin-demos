#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "FilteringViewModel.cs" company="Syncfusion.com">
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
    using System.Text;
    using System.Threading.Tasks;
    using Syncfusion.Data;
    using Syncfusion.Data.Extensions;
    using Syncfusion.SfDataGrid.XForms;
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    /// A ViewModel for Filtering sample.
    /// </summary>
    public class FilteringViewModel : INotifyPropertyChanged
    {
        #region Fields

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed")]
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Some fields must be public")]
        internal FilterChanged Filtertextchanged;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string filtertext = string.Empty;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string selectedcolumn = "All Columns";
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string selectedcondition = "Contains";
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private List<BookInfo> bookInfo;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the FilteringViewModel class.
        /// </summary>
        public FilteringViewModel()
        {
            this.SetRowstoGenerate(100);
        }

        #endregion

        /// <summary>
        /// Used to send a Notification while Filter Changed
        /// </summary>
        internal delegate void FilterChanged();

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region Filtering

        #region Property

        /// <summary>
        /// Gets or sets the value of FilterText and notifies user when value gets changed 
        /// </summary>
        public string FilterText
        {
            get
            {
                return this.filtertext;
            }

            set
            {
                this.filtertext = value;
                this.OnFilterTextChanged();
                this.RaisePropertyChanged("FilterText");
            }
        }

        /// <summary>
        /// Gets or sets the value of SelectedCondition
        /// </summary>
        public string SelectedCondition
        {
            get { return this.selectedcondition; }
            set { this.selectedcondition = value; }
        }

        /// <summary>
        /// Gets or sets the value of SelectedColumn
        /// </summary>
        public string SelectedColumn
        {
            get { return this.selectedcolumn; }
            set { this.selectedcolumn = value; }
        }

        #endregion

        #region ItemsSource  

        /// <summary>
        /// Gets or sets the value of BookInfo
        /// </summary>
        public List<BookInfo> BookInfo
        {
            get { return this.bookInfo; }
            set { this.bookInfo = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// used to decide generate records or not
        /// </summary>
        /// <param name="o">object type parameter</param>
        /// <returns>true or false value</returns>
        public bool FilerRecords(object o)
        {
            double res;
            bool checkNumeric = double.TryParse(this.FilterText, out res);
            var item = o as BookInfo;
            if (item != null && this.FilterText.Equals(string.Empty) && !string.IsNullOrEmpty(this.FilterText))
            {
                return true;
            }
            else
            {
                if (item != null)
                {
                    if (checkNumeric && !this.SelectedColumn.Equals("All Columns") && !this.SelectedCondition.Equals("Contains"))
                    {
                        bool result = this.MakeNumericFilter(item, this.SelectedColumn, this.SelectedCondition);
                        return result;
                    }
                    else if (this.SelectedColumn.Equals("All Columns"))
                    {
                        if (item.BookName.ToLower().Contains(this.FilterText.ToLower()) ||
                            item.FirstName.ToString().ToLower().Contains(this.FilterText.ToLower()) ||
                            item.LastName.ToString().ToLower().Contains(this.FilterText.ToLower()) ||
                            item.CustomerID.ToString().ToLower().Contains(this.FilterText.ToLower()) ||
                            item.BookID.ToString().ToLower().Contains(this.FilterText.ToLower()))
                        {
                            return true;
                        }

                        return false;
                    }
                    else
                    {
                        bool result = this.MakeStringFilter(item, this.SelectedColumn, this.SelectedCondition);
                        return result;
                    }
                }
            }

            return false;
        }

        #endregion

        #endregion

        #region ItemSource Generator

        /// <summary>
        /// Generates record rows with given count
        /// </summary>
        /// <param name="count">generates row count</param>
        public void SetRowstoGenerate(int count)
        {
            BookRepository bookrepository = new BookRepository();
            this.bookInfo = bookrepository.GetBookDetails(count);
        }

        #endregion

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="propertyName">string type parameter propertyName</param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1630:DocumentationTextMustContainWhitespace", Justification = "Reviewed.")]
        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Used to call the filter text changed()
        /// </summary>
        private void OnFilterTextChanged()
        {
            if (this.Filtertextchanged != null)
            {
                this.Filtertextchanged();
            }
        }

        /// <summary>
        /// Used decide to make the string filter
        /// </summary>
        /// <param name="o">o</param>
        /// <param name="option">option</param>
        /// <param name="condition">condition</param>
        /// <returns>true or false value</returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1630:DocumentationTextMustContainWhitespace", Justification = "Reviewed.")]
        private bool MakeStringFilter(BookInfo o, string option, string condition)
        {
            var value = o.GetType().GetProperty(option);
            var exactValue = value.GetValue(o, null);
            exactValue = exactValue.ToString().ToLower();
            string text = this.FilterText.ToLower();
            var methods = typeof(string).GetMethods();

            if (methods.Count() != 0)
            {
                if (condition == "Contains")
                {
                    var methodInfo = methods.FirstOrDefault(method => method.Name == condition);
                    bool result1 = (bool)methodInfo.Invoke(exactValue, new object[] { text });
                    return result1;
                }
                else if (exactValue.ToString() == text.ToString())
                {
                    bool result1 = string.Equals(exactValue.ToString(), text.ToString());
                    if (condition == "Equals")
                    {
                        return result1;
                    }
                    else if (condition == "NotEquals")
                    {
                        return false;
                    }
                }
                else if (condition == "NotEquals")
                {
                    return true;
                }

                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Used decide to make the numeric filter
        /// </summary>
        /// <param name="o">o</param>
        /// <param name="option">option</param>
        /// <param name="condition">condition</param>
        /// <returns>true or false value</returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1630:DocumentationTextMustContainWhitespace", Justification = "Reviewed.")]
        private bool MakeNumericFilter(BookInfo o, string option, string condition)
        {
            var value = o.GetType().GetProperty(option);
            var exactValue = value.GetValue(o, null);
            double res;
            bool checkNumeric = double.TryParse(exactValue.ToString(), out res);
            if (checkNumeric)
            {
                switch (condition)
                {
                    case "Equals":
                        try
                        {
                            if (exactValue.ToString() == this.FilterText)
                            {
                                if (Convert.ToDouble(exactValue) == Convert.ToDouble(this.FilterText))
                                {
                                    return true;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.Message);
                        }

                        break;
                    case "NotEquals":
                        try
                        {
                            if (Convert.ToDouble(this.FilterText) != Convert.ToDouble(exactValue))
                            {
                                return true;
                            }
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.Message);
                            return true;
                        }

                        break;
                }
            }

            return false;
        }

        #endregion
    }
}
