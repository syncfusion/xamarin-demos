#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Android.Widget;
using Android.Content;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace SampleBrowser
{
    public class DataSourceGettingStartedViewModel : INotifyPropertyChanged
    {
        #region Fields

        private Context context;

        #endregion

        #region Constructor

        public DataSourceGettingStartedViewModel(Context context)
        {
            this.context = context;
        }

        #endregion

        #region Filtering

        #region Fields

        private string filtertext = string.Empty;
        private string selectedcolumn = "All Columns";
        private string selectedcondition = "Equals";

        internal delegate void FilterChanged();

        internal FilterChanged Filtertextchanged { get; set; }

        #endregion

        #region Property

        public string FilterText
        {
            get
            {
                return filtertext;
            }

            set
            {
                filtertext = value;
                OnFilterTextChanged();
                RaisePropertyChanged("FilterText");
            }
        }

        public string SelectedCondition
        {
            get { return selectedcondition; }
            set { selectedcondition = value; }
        }

        public string SelectedColumn
        {
            get { return selectedcolumn; }
            set { selectedcolumn = value; }
        }

        #endregion

        #region Private Methods

        private void OnFilterTextChanged()
        {
            Filtertextchanged();
        }

        private bool MakeStringFilter(BookDetails o, string option, string condition)
        {
            var value = o.GetType().GetProperty(option);
            var exactValue = value.GetValue(o, null);
            exactValue = exactValue.ToString().ToLower();
            string text = FilterText.ToLower();
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
                    bool result1 = String.Equals(exactValue.ToString(), text.ToString());
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

        private bool MakeNumericFilter(BookDetails o, string option, string condition)
        {
            var value = o.GetType().GetProperty(option);
            var exactValue = value.GetValue(o, null);
            exactValue = Regex.Replace(exactValue.ToString(), @"[^\d]", string.Empty);
            double res;
            bool checkNumeric = double.TryParse(exactValue.ToString(), out res);
            if (checkNumeric)
            {
                switch (condition)
                {
                    case "Equals":
                        try
                        {
                            if (exactValue.ToString() == FilterText)
                            {
                                if (Convert.ToDouble(exactValue) == Convert.ToDouble(FilterText))
                                {
                                    return true;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            Toast.MakeText(this.context, "Invalid input", ToastLength.Short).Show();
                        }

                        break;
                    case "NotEquals":
                        try
                        {
                            if (Convert.ToDouble(FilterText) != Convert.ToDouble(exactValue))
                            {
                                return true;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            Toast.MakeText(this.context, "Invalid input", ToastLength.Short).Show();
                            return true;
                        }

                        break;
                }
            }

            return false;
        }

        #endregion

        #region Public Methods

        public bool FilerRecords(object o)
        {
            double res;
            bool checkNumeric = double.TryParse(FilterText, out res);
            var item = o as BookDetails;
            if (item != null && string.IsNullOrEmpty(FilterText))
            {
                return true;
            }
            else
            {
                if (item != null)
                {
                    if (checkNumeric && !SelectedColumn.Equals("All Columns"))
                    {
                        bool result = MakeNumericFilter(item, SelectedColumn, SelectedCondition);
                        return result;
                    }
                    else if (SelectedColumn.Equals("All Columns"))
                    {
                        if (item.BookName.ToLower().Contains(FilterText.ToLower()) ||
                            item.Price.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.BookID.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.CustomerName.ToString().ToLower().Contains(FilterText.ToLower()))
                        {
                            return true;
                        }

                        return false;
                    }
                    else
                    {
                        bool result = MakeStringFilter(item, SelectedColumn, SelectedCondition);
                        return result;
                    }
                }
            }

            return false;
        }

        #endregion

        #endregion

        #region ItemsSource

        private ObservableCollection<BookDetails> bookInfo;

        public ObservableCollection<BookDetails> BookInfo
        {
            get { return bookInfo; }
            set { this.bookInfo = value; }
        }

        #endregion

        #region ItemSource Generator

        public void SetRowstoGenerate(int count)
        {
            BookDetailsRepository bookrepository = new BookDetailsRepository(context);
            bookInfo = bookrepository.GetBookDetails(count);
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}