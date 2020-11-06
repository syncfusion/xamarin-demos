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

namespace SampleBrowser
{
    public class FilterViewModel : INotifyPropertyChanged
    {
        public FilterViewModel()
        {
            this.SetRowstoGenerate(100);
        }

        #region Filtering

        internal delegate void FilterChanged();

        internal FilterChanged filtertextchanged;

        #region Fields

        private string filtertext;

        private string selectedcolumn = "All Columns";
        private string selectedcondition = "Equals";

        #endregion

        #region Property

        public string FilterText
        {
            get { return filtertext; }
            set
            {
                filtertext = value;
                OnFilterTextChanged();
                RaisePropertyChanged("FilterText");

            }

        }

        public string SelectedCondition
        {
            get
            {
                return selectedcondition;
            }
            set
            {
                selectedcondition = value;
            }
        }

        public string SelectedColumn
        {
            get
            {
                return selectedcolumn;
            }
            set
            {
                selectedcolumn = value;
            }

        }

        #endregion

        void OnFilterTextChanged()
        {
            filtertextchanged();
        }

        private bool MakeStringFilter(BookInfo o, string option, string condition)
        {
            var value = o.GetType().GetProperty(option);
            var exactValue = value.GetValue(o, null);
            exactValue = exactValue.ToString().ToLower();
            string text = FilterText.ToLower();
            var methods = typeof(string).GetMethods();



            if (methods.Any())
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
                        return result1;
                    else if (condition == "NotEquals")
                        return false;
                }
                else if (condition == "Not Equals")
                {
                    return true;
                }
                return false;
            }
            else
                return false;
        }

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
                            if (exactValue.ToString() == FilterText)
                            {
                                if (Convert.ToDouble(exactValue) == (Convert.ToDouble(FilterText)))
                                    return true;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case "Not Equals":
                        try
                        {
                            if (Convert.ToDouble(FilterText) != Convert.ToDouble(exactValue))
                                return true;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                }
            }
            return false;
        }

        public bool FilerRecords(object o)
        {
            double res;
            bool checkNumeric = double.TryParse(FilterText, out res);
            var item = o as BookInfo;
            if (item != null && FilterText.Equals(""))
            {
                return true;
            }
            else {
                if (item != null)
                {
                    if (checkNumeric && !SelectedColumn.Equals("All Columns") && SelectedCondition != "Contains")
                    {
                        bool result = MakeNumericFilter(item, SelectedColumn, SelectedCondition);
                        return result;
                    }
                    else if (SelectedColumn.Equals("All Columns"))
                    {
                        if (item.BookName.ToLower().Contains(FilterText.ToLower()) ||
                            item.Country.ToLower().Contains(FilterText.ToLower()) ||
                            item.FirstName.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.LastName.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.CustomerID.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.Price.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.BookID.ToString().ToLower().Contains(FilterText.ToLower()))
                            return true;
                        return false;
                    }
                    else {
                        //					if (SelectedCondition == null || SelectedCondition.Equals("NotEquals") || SelectedCondition.Equals("Equals"))
                        //						SelectedCondition = "Contains";
                        bool result = MakeStringFilter(item, SelectedColumn, SelectedCondition);
                        return result;
                    }
                }
            }
            return false;
        }


        #endregion

        #region ItemsSource

        private List<BookInfo> bookInfo;

        public List<BookInfo> BookInfo
        {
            get { return bookInfo; }
            set { this.bookInfo = value; }
        }

        #endregion

        #region ItemSource Generator

        public void SetRowstoGenerate(int count)
        {
            BookRepository bookrepository = new BookRepository();
            bookInfo = bookrepository.GetBookDetails(count);
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
