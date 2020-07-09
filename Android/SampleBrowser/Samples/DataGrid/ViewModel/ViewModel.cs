#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using IncrementalLoading.NorthwindService;
using Syncfusion.SfDataGrid;
using System.Data.Services.Client;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Android.App;
using Android.Content;
using Android.Views;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Syncfusion.Data;
using System.Timers;
using System.Text;
using Android.Widget;
using Syncfusion.Data.Extensions;
using Syncfusion.Android.ProgressBar;
using Syncfusion.Android.PopupLayout;

namespace SampleBrowser
{
    public class GettingStartedViewModel
    {
        #region Fields

        private Random random = new Random();
        private OrderInfoRepository order;

        #endregion

        public GettingStartedViewModel()
        {
            SetRowstoGenerate(100);
        }

        #region ItemsSource

        private ObservableCollection<OrderInfo> ordersInfo;

        public ObservableCollection<OrderInfo> OrdersInfo
        {
            get { return ordersInfo; }
            set { this.ordersInfo = value; }
        }

        #endregion

        #region ItemSource Generator

        public void SetRowstoGenerate(int count)
        {
            order = new OrderInfoRepository();
            ordersInfo = order.GetOrderDetails(count);
        }

        #endregion

        internal void ItemsSourceRefresh()
        {
            var count = random.Next(1, 6);

            for (int i = 11000; i < 11000 + count; i++)
            {
                int val = i + random.Next(100, 150);
                this.OrdersInfo.Insert(0, order.RefreshItemsource(val));
            }
        }

    }

    public class SortingViewModel
    {
        public SortingViewModel()
        {

        }

        #region ItemsSource

        private ObservableCollection<Products> products;

        public ObservableCollection<Products> Products
        {
            get { return products; }
            set { this.products = value; }
        }

        #endregion

        #region ItemSource Generator

        public void SetRowstoGenerate(int count)
        {
            ProductRepository product = new ProductRepository();
            products = product.GetProductDetails(100);
        }

        #endregion
    }

    public class IncrementalLoadingViewModel : INotifyPropertyChanged
    {
        #region Members

        NorthwindEntities northwindEntity;
        private SfLinearProgressBar progress;
        private SfPopupLayout popup;

        #endregion

        #region Constructor

        public IncrementalLoadingViewModel(Context context)
        {
            progress = new SfLinearProgressBar(context);
            popup = new SfPopupLayout(context);
            string uri = "http://services.odata.org/Northwind/Northwind.svc/";
            if (CheckConnection(uri).Result)
            {


                popup.PopupView.ContentView = progress;
                popup.PopupView.HeaderTitle = "Fetching Data... ";
                popup.PopupView.ShowCloseButton = false;
                popup.PopupView.ShowFooter = false;
                popup.PopupView.HeightRequest = 125;
                popup.StaysOpen = true;
                progress.Progress = 100;
                progress.IsIndeterminate = true;
                popup.Show();

                gridSource = new IncrementalList<Order>(LoadMoreItems) { MaxItemsCount = 1000 };
                northwindEntity = new NorthwindEntities(new Uri(uri));
            }
            else
            {
                NoNetwork = true;
                IsBusy = false;
            }
        }

        #endregion

        #region Properties

        private IncrementalList<Order> gridSource;

        public IncrementalList<Order> GridSource
        {
            get { return gridSource; }
            set
            {
                gridSource = value;
                RaisePropertyChanged("GridSource");
            }
        }

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;

                if (progress != null)
                {
                    if (isBusy)
                    {
                    }
                    else
                    {
                        if (noNetwork)
                        {
                            popup.PopupView.ContentView = progress;
                            popup.PopupView.ShowCloseButton = false;
                            popup.PopupView.ShowFooter = false;
                            popup.PopupView.HeaderHeight = 90;
                            popup.PopupView.HeightRequest = 125;
                            popup.PopupView.HeaderTitle = "No Network Found..! \n\nSearching for a network...";
                            progress.Progress = 100;
                            progress.IsIndeterminate = true;
                            popup.Show();
                        }
                        else
                            popup.Dismiss();
                    }
                }
                RaisePropertyChanged("IsBusy");
            }
        }

        private bool noNetwork;

        public bool NoNetwork
        {
            get { return noNetwork; }
            set
            {
                noNetwork = value;
                RaisePropertyChanged("NoNetwork");
            }
        }


        #endregion

        #region Methods

        void LoadMoreItems(uint count, int baseIndex)
        {
            BackgroundWorker worker = new BackgroundWorker();
            //worker.RunWorkerAsync ();
            worker.DoWork += (o, ae) =>
            {
                DataServiceQuery<Order> query = northwindEntity.Orders.Expand("Customer");
                query = query.Skip<Order>(baseIndex).Take<Order>(50) as DataServiceQuery<Order>;
                IAsyncResult ar = query.BeginExecute(null, null);
                var items = query.EndExecute(ar);
                var list = items.ToList();

                Android.OS.Handler mainHandler = new Android.OS.Handler(Android.OS.Looper.MainLooper);
                Java.Lang.Runnable myRunnable = new Java.Lang.Runnable(() =>
                {
                    GridSource.LoadItems(list);
                });
                mainHandler.Post(myRunnable);
            };

            worker.RunWorkerCompleted += (o, ae) =>
            {
                IsBusy = false;
            };

            IsBusy = true;
            worker.RunWorkerAsync();
        }

        private async Task<bool> CheckConnection(String URL)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(URL));
                request.Timeout = 5000;
                request.Credentials = CredentialCache.DefaultNetworkCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                await Task.Delay(0);

                if (response.StatusCode == HttpStatusCode.OK)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            northwindEntity = null;
            popup = null;
            progress.Dispose();
            progress = null;
        }

        #endregion
    }

    public class SelectionViewModel : NotificationObject
    {
        public SelectionViewModel()
        {
            ProductInfoRespository products = new ProductInfoRespository();
            ProductDetails = products.GetProductDetails(100);
        }

        private List<ProductInfo> productDetails;

        /// <summary>
        /// Gets or sets the product details.
        /// </summary>
        /// <value>The product details.</value>
        public List<ProductInfo> ProductDetails
        {
            get { return productDetails; }
            set
            {
                productDetails = value;
                RaisePropertyChanged("ProductDetails");
            }
        }
    }

    public class FilteringViewModel : INotifyPropertyChanged
    {
        #region Fields

        Context context;

        #endregion

        #region Constructor

        public FilteringViewModel(Context context)
        {
            this.context = context;
        }

        #endregion

        #region Filtering

        #region Fields

        private string filtertext = "";
        private string selectedcolumn = "All Columns";
        private string selectedcondition = "Equals";

        internal delegate void FilterChanged();

        internal FilterChanged filtertextchanged;

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
            filtertextchanged();
        }

        private bool MakeStringFilter(BookInfo o, string option, string condition)
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
                        return result1;
                    else if (condition == "NotEquals")
                        return false;
                }
                else if (condition == "NotEquals")
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
                            Toast.MakeText(this.context, "Invalid input", ToastLength.Short).Show();
                        }
                        break;
                    case "NotEquals":
                        try
                        {
                            if (Convert.ToDouble(FilterText) != Convert.ToDouble(exactValue))
                                return true;
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
            var item = o as BookInfo;
            if (item != null && FilterText.Equals(""))
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
                            item.Country.ToLower().Contains(FilterText.ToLower()) ||
                            item.FirstName.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.LastName.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.CustomerID.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.Price.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.BookID.ToString().ToLower().Contains(FilterText.ToLower()))
                            return true;
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

    public class GroupingViewModel : NotificationObject
    {
        public GroupingViewModel()
        {
            ProductInfoRespository products = new ProductInfoRespository();
            ProductDetails = products.GetProductDetails(100);
        }

        private List<ProductInfo> productDetails;

        /// <summary>
        /// Gets or sets the product details.
        /// </summary>
        /// <value>The product details.</value>
        public List<ProductInfo> ProductDetails
        {
            get { return productDetails; }
            set
            {
                productDetails = value;
                RaisePropertyChanged("ProductDetails");
            }
        }
    }

    public class RenderingDynamicDataViewModel : INotifyPropertyChanged, IDisposable
    {
        #region Members

        ObservableCollection<StockData> data;
        Random r = new Random(123345345);
        internal Timer timer;
        private bool enableTimer = false;
        private double timerValue;
        private string buttonContent;
        private int noOfUpdates = 500;
        List<string> StockSymbols = new List<string>();
        string[] accounts = new string[] {
            "American Funds",
            "College Savings",
            "Day Trading",
            "Mountain Range",
            "Fidelity Funds",
            "Mortages",
            "Housing Loans"
        };

        string[] product = new string[]
        {
            "Crab",
            "Bag",
            "Cashew",
            "Syrup",
            "Meat",
            "Lax",
            "Filo"
        };

        #endregion

        /// <summary>
        /// Gets the stocks.
        /// </summary>
        /// <value>The stocks.</value>
        public ObservableCollection<StockData> Stocks
        {
            get { return this.data; }
        }

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="StocksViewModel"/> class.
        /// </summary>
        public RenderingDynamicDataViewModel()
        {
            this.data = new ObservableCollection<StockData>();
            this.AddRows(2000);
            this.timer = new Timer();
            this.ResetRefreshFrequency(2500);
            timer.Interval = (double)TimeSpan.FromMilliseconds(200).Milliseconds;
            ButtonContent = "Start Timer";
            timer.Elapsed += timer_Tick;
            ButtonClicked();
        }

        #endregion

        #region Timer and updating code

        /// <summary>
        /// Sets the interval.
        /// </summary>
        /// <param name="time">The time.</param>
        public void SetInterval(TimeSpan time)
        {
            this.timer.Interval = Convert.ToDouble(time);
        }

        /// <summary>
        /// Starts the timer.
        /// </summary>
        public void StartTimer()
        {
            if (!this.timer.Enabled)
            {
                this.timer.Start();
                this.ButtonContent = "Stop Timer";
            }
        }

        /// <summary>
        /// Gets or sets the timer value.
        /// </summary>
        /// <value>The timer value.</value>
        public double TimeSpanValue
        {
            get { return timerValue; }
            set
            {
                timerValue = value;
                this.timer.Interval = Convert.ToDouble(TimeSpan.FromMilliseconds(timerValue));
                RaisePropertyChanged("TimeSpanValue");
            }
        }

        /// <summary>
        /// Gets or sets the button contnt.
        /// </summary>
        /// <value>The button contnt.</value>
        public string ButtonContent
        {
            get { return buttonContent; }
            set
            {
                buttonContent = value;
                RaisePropertyChanged("ButtonContent");
            }
        }

        /// <summary>
        /// Determines whether this instance [can button click].
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance [can button click]; otherwise, <c>false</c>.
        /// </returns>
        bool CanButtonClick(object param)
        {
            return true;
        }

        /// <summary>
        /// Buttons the clicked.
        /// </summary> 
        public void ButtonClicked()
        {
            if (ButtonContent.Equals("Start Timer"))
            {
                this.EnableTimer = true;
                this.StartTimer();
                ButtonContent = "Stop Timer";
            }
            else
            {
                this.EnableTimer = false;
                this.StopTimer();
                ButtonContent = "Start Timer";
            }
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void StopTimer()
        {
            this.timer.Stop();
        }

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void timer_Tick(object sender, object e)
        {
            int startTime = DateTime.Now.Millisecond;
            noOfUpdates = 100;
            ChangeRows(noOfUpdates);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [enable timer].
        /// </summary>
        /// <value><c>true</c> if [enable timer]; otherwise, <c>false</c>.</value>
        public bool EnableTimer
        {
            get { return this.enableTimer; }
            set { this.enableTimer = value; }
        }

        /// <summary>
        /// Adds the rows.
        /// </summary>
        /// <param name="count">The count.</param>
        private void AddRows(int count)
        {
            for (int i = 0; i < count; ++i)
            {
                var newRec = new StockData();
                newRec.Symbol = ChangeSymbol();
                newRec.Account = ChangeAccount(i);
                newRec.Open = Math.Round(r.NextDouble() * 30, 2);
                newRec.LastTrade = Math.Round((1 + r.NextDouble() * 50));
                double d = r.NextDouble();
                if (d < .5)
                    newRec.StockChange = Math.Round(d, 2);
                else
                    newRec.StockChange = Math.Round(d, 2) * -1;

                newRec.PreviousClose = Math.Round(r.NextDouble() * 30, 2);
                newRec.Product = ChangeProduct(i);
                newRec.Volume = r.Next();
                data.Add(newRec);
            }
        }

        /// <summary>
        /// Changes the symbol.
        /// </summary>
        /// <returns></returns>
        private String ChangeSymbol()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;

            do
            {
                builder = new StringBuilder();
                for (int i = 0; i < 4; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    builder.Append(ch);
                }

            } while (StockSymbols.Contains(builder.ToString()));

            StockSymbols.Add(builder.ToString());
            return builder.ToString();
        }

        /// <summary>
        /// Changes the account.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        private String ChangeAccount(int index)
        {
            return accounts[index % accounts.Length];
        }

        /// <summary>
		/// Changes the Product.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		private String ChangeProduct(int index)
        {
            return product[index % product.Length];
        }

        /// <summary>
        /// Resets the refresh frequency.
        /// </summary>
        /// <param name="changesPerTick">The changes per tick.</param>
        public void ResetRefreshFrequency(int changesPerTick)
        {
            if (this.timer == null)
            {
                return;
            }

            if (!this.noOfUpdates.Equals(changesPerTick))
            {
                this.StopTimer();
                this.noOfUpdates = changesPerTick;
                if (enableTimer)
                    this.StartTimer();
            }
        }

        public object SelectedItem
        {
            get { return noOfUpdates; }
            set
            {
                noOfUpdates = 2;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public List<int> ComboCollection
        {
            get { return new List<int> { 500, 5000, 50000, 500000 }; }
        }

        /// <summary>
        /// Changes the rows.
        /// </summary>
        /// <param name="count">The count.</param>
        private void ChangeRows(int count)
        {
            if (data.Count < count)
                count = data.Count;
            for (int i = 0; i < count; ++i)
            {
                int recNo = r.Next(data.Count);
                StockData recRow = data[recNo];

                data[recNo].LastTrade = Math.Round((1 + r.NextDouble() * 50));

                double d = r.NextDouble();
                if (d < .5)
                {
                    data[recNo].StockChange = Math.Round(d, 2);
                }
                else
                {
                    data[recNo].StockChange = Math.Round(d, 2) * -1;
                }
                data[recNo].Open = Math.Round(r.NextDouble() * 50, 2);
                data[recNo].PreviousClose = Math.Round(r.NextDouble() * 30, 2);
                data[recNo].Volume = r.Next();
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

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this.timer != null)
            {
                this.timer.Elapsed -= timer_Tick;
                this.StopTimer();
            }
        }

        #endregion
    }

    public class FormattingViewModel
    {
        public FormattingViewModel()
        {
            SetRowstoGenerate(100);
        }

        #region ItemsSource

        private List<BankInfo> bankInfo;

        public List<BankInfo> BankInfo
        {
            get { return bankInfo; }
            set { this.bankInfo = value; }
        }

        #endregion

        #region ItemSource Generator

        public void SetRowstoGenerate(int count)
        {
            BankRepository bank = new BankRepository();
            bankInfo = bank.GetBankDetails(100);
        }

        #endregion
        public void Dispose()
        {
            foreach (var item in bankInfo)
            {
                item.CustomerImage.Recycle();
                item.CustomerImage.Dispose();
                item.CustomerImage = null;
            }
        }

    }

    public class StylesViewModel : NotificationObject
    {
        public StylesViewModel()
        {
            OrderInfoRepository order = new OrderInfoRepository();
            ordersInfo = order.GetOrderDetails(100);
        }

        #region ItemsSource

        private ObservableCollection<OrderInfo> ordersInfo;

        public ObservableCollection<OrderInfo> OrdersInfo
        {
            get { return ordersInfo; }
            set { this.ordersInfo = value; }
        }

        #endregion
    }

    public class AutoRowHeightViewModel : INotifyPropertyChanged
    {
        public AutoRowHeightViewModel()
        {
            ReleaseInfoRepository details = new ReleaseInfoRepository();
            releaseInformation = details.GetReleaseDetails(28);
        }

        #region ItemsSource

        private ObservableCollection<ReleaseInfo> releaseInformation;

        public ObservableCollection<ReleaseInfo> ReleaseInformation
        {
            get { return this.releaseInformation; }
            set { this.releaseInformation = value; }
        }

        #endregion

        #region Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion


    }

    public class CustomerViewModel
    {
        #region Constructor

        public CustomerViewModel()
        {
            CustomersRepository customerrep = new CustomersRepository();
            customerInformation = customerrep.GetCutomerDetails(100);
        }

        #endregion

        #region ItemsSource

        private ObservableCollection<CustomerDetails> customerInformation;

        public ObservableCollection<CustomerDetails> CustomerInformation
        {
            get { return this.customerInformation; }
            set { this.customerInformation = value; }
        }

        #endregion

        #region Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion
    }

    public class SalesInfoViewModel
    {
        #region Constructor

        public SalesInfoViewModel()
        {

        }

        #endregion

        #region ItemsSource

        private ObservableCollection<SalesByDate> dailySalesDetails = null;

        public ObservableCollection<SalesByDate> DailySalesDetails
        {
            get
            {
                if (dailySalesDetails == null)
                    return new SalesInfoRepository().GetSalesDetailsByDay(100);
                else
                    return dailySalesDetails;
            }
        }

        #endregion
    }

    public class FrozenViewViewModel
    {
        #region Constructor

        public FrozenViewViewModel()
        {
            SetRowstoGenerate(100);
        }

        #endregion

        #region ItemsSource

        private ObservableCollection<Products> products;

        public ObservableCollection<Products> Products
        {
            get { return products; }
            set { this.products = value; }
        }

        #endregion

        #region ItemSource Generator

        public void SetRowstoGenerate(int count)
        {
            ProductRepository product = new ProductRepository();
            products = product.GetProductDetails(count);
        }

        #endregion
    }

    public class ExportingViewModel
    {
        #region Constructor

        public ExportingViewModel()
        {
            OrderInfoRepository order = new OrderInfoRepository();
            OrdersInfo = order.GetOrderDetails(100);
        }

        #endregion

        #region ItemsSource

        private ObservableCollection<OrderInfo> _ordersInfo;

        public ObservableCollection<OrderInfo> OrdersInfo
        {
            get { return _ordersInfo; }
            set { this._ordersInfo = value; }
        }

        #endregion
    }

    public class PullToRefreshViewModel : INotifyPropertyChanged
    {
        public PullToRefreshViewModel()
        {
            SetRowstoGenerate(100);
        }

        #region ItemsSource

        private OrderInfoRepository order;

        private ObservableCollection<OrderInfo> ordersInfo;

        public ObservableCollection<OrderInfo> OrdersInfo
        {
            get { return ordersInfo; }
            set { this.ordersInfo = value; RaisePropertyChanged("OrdersInfo"); }
        }

        #endregion

        #region ItemSource Generator

        public void SetRowstoGenerate(int count)
        {
            order = new OrderInfoRepository();
            ordersInfo = order.GetOrderDetails(100);
        }

        #endregion

        private Random random = new Random();

        internal void ItemsSourceRefresh()
        {
            var count = random.Next(1, 6);

            for (int i = 11000; i < 11000 + count; i++)
            {
                int val = i + random.Next(100, 150);
                this.OrdersInfo.Insert(0, order.RefreshItemsource(val));
            }
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }

    public class LoadMoreViewModel : INotifyPropertyChanged
    {
        #region Fields

        private OrderInfoRepository order;
        private ObservableCollection<OrderInfo> ordersInfo;

        #endregion

        #region Constructor

        public LoadMoreViewModel()
        {
            SetRowstoGenerate(30);
        }

        #endregion

        #region ItemsSource

        public ObservableCollection<OrderInfo> OrdersInfo
        {
            get { return ordersInfo; }
            set
            {
                this.ordersInfo = value;
                RaisePropertyChanged("OrdersInfo");
            }
        }

        #endregion

        #region ItemSource Generator

        public void SetRowstoGenerate(int count)
        {
            order = new OrderInfoRepository();
            ordersInfo = order.GetOrderDetails(count);
        }

        #endregion

        #region LoadMore Generator

        internal void LoadMoreItems()
        {
            for (int i = 0; i < 20; i++)
                this.OrdersInfo.Add(order.GenerateOrder(OrdersInfo.Count + 1));
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

    public class PagingViewModel : INotifyPropertyChanged
    {
        public PagingViewModel()
        {
            SetRowstoGenerate(100);
        }

        #region ItemsSource

        private OrderInfoRepository order;

        private ObservableCollection<OrderInfo> ordersInfo;

        public ObservableCollection<OrderInfo> OrdersInfo
        {
            get { return ordersInfo; }
            set { this.ordersInfo = value; RaisePropertyChanged("OrdersInfo"); }
        }

        #endregion

        #region ItemSource Generator

        public void SetRowstoGenerate(int count)
        {
            order = new OrderInfoRepository();
            ordersInfo = order.GetOrderDetails(count);
        }

        #endregion

        private Random random = new Random();

        internal void ItemsSourceRefresh()
        {
            var count = random.Next(1, 6);

            for (int i = 11000; i < 11000 + count; i++)
            {
                int val = i + random.Next(100, 150);
                this.OrdersInfo.Insert(0, order.RefreshItemsource(val));
            }
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }

    public class SwipingViewModel : INotifyPropertyChanged
    {
        public SwipingViewModel()
        {
            SetRowstoGenerate(100);
        }

        #region ItemsSource

        private OrderInfoRepository order;

        private ObservableCollection<OrderInfo> ordersInfo;

        public ObservableCollection<OrderInfo> OrdersInfo
        {
            get { return ordersInfo; }
            set { this.ordersInfo = value; RaisePropertyChanged("OrdersInfo"); }
        }

        #endregion

        #region ItemSource Generator

        public void SetRowstoGenerate(int count)
        {
            order = new OrderInfoRepository();
            ordersInfo = order.GetOrderDetails(100);
        }

        #endregion

        private Random random = new Random();

        internal void ItemsSourceRefresh()
        {
            var count = random.Next(1, 6);

            for (int i = 11000; i < 11000 + count; i++)
            {
                int val = i + random.Next(100, 150);
                this.OrdersInfo.Insert(0, order.RefreshItemsource(val));
            }
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }

    public class DragAndDropViewModel : INotifyPropertyChanged
    {
        public DragAndDropViewModel()
        {
            SetRowstoGenerate(100);
        }

        #region ItemsSource

        private OrderInfoRepository order;

        private ObservableCollection<OrderInfo> ordersInfo;

        public ObservableCollection<OrderInfo> OrdersInfo
        {
            get { return ordersInfo; }
            set { this.ordersInfo = value; RaisePropertyChanged("OrdersInfo"); }
        }

        #endregion

        #region ItemSource Generator

        public void SetRowstoGenerate(int count)
        {
            order = new OrderInfoRepository();
            ordersInfo = order.GetOrderDetails(count);
        }

        #endregion

        private Random random = new Random();

        internal void ItemsSourceRefresh()
        {
            var count = random.Next(1, 6);

            for (int i = 11000; i < 11000 + count; i++)
            {
                int val = i + random.Next(100, 150);
                this.OrdersInfo.Insert(0, order.RefreshItemsource(val));
            }
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }

    public class UnboundColumnViewModel
    {
        public UnboundColumnViewModel()
        {

        }

        #region ItemsSource

        private ObservableCollection<Products> products;

        public ObservableCollection<Products> Products
        {
            get { return products; }
            set { this.products = value; }
        }

        #endregion

        #region ItemSource Generator

        public void SetRowstoGenerate(int count)
        {
            ProductRepository product = new ProductRepository();
            products = product.GetProductDetails(100);
        }

        #endregion
    }

    public class EditingViewModel : INotifyPropertyChanged
    {
        #region Constructor

        public EditingViewModel()
        {
            DealerRepository dealerrep = new DealerRepository();
            dealerInformation = dealerrep.GetDealerDetails(100);
            this.CustomerNames = dealerrep.Customers.ToObservableCollection();
        }

        #endregion

        #region ItemsSource

        private ObservableCollection<DealerInfo> dealerInformation;

        public ObservableCollection<DealerInfo> DealerInformation
        {
            get { return this.dealerInformation; }
            set { this.dealerInformation = value; }
        }

        public ObservableCollection<string> CustomerNames { get; set; }

        #endregion

        #region Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion
    }

    public class ContextMenuModel
    {

        #region ItemSource
        private ObservableCollection<OrderInfo> _orderInfo;

        public ObservableCollection<OrderInfo> OrderInfo
        {
            get
            {
                return _orderInfo;
            }
            set
            {
                this._orderInfo = value;
            }

        }
        #endregion 

        public ContextMenuModel()
        {
            OrderInfoRepository _orderInfoRepository = new OrderInfoRepository();
            OrderInfo = _orderInfoRepository.GetOrderDetails(100);
        }
    }
}

