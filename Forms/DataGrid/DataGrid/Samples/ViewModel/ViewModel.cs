#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Syncfusion.Data.Extensions;
using Syncfusion.Data;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;
namespace SampleBrowser.SfDataGrid
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class GridViewModel :INotifyPropertyChanged
	{
		public GridViewModel ()
		{
			SetRowstoGenerate (100);
		}

		#region ItemsSource

        private OrderInfoRepository order;

		private ObservableCollection<OrderInfo> ordersInfo;

		public ObservableCollection<OrderInfo> OrdersInfo {
			get { return ordersInfo; }
			set { this.ordersInfo = value; RaisePropertyChanged("OrdersInfo"); }
		}

		#endregion

		#region ItemSource Generator

		public void SetRowstoGenerate (int count)
		{
			order = new OrderInfoRepository ();
			ordersInfo = order.GetOrderDetails (count);
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

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class SortingViewModel : NotificationObject
    {
		public SortingViewModel ()
		{
			ProductRepository product = new ProductRepository ();
			products = product.GetProductDetails (100);
		}

		#region ItemsSource

		private List<Product> products;

		public List<Product> Products {
			get { return products; }
			set { this.products = value; }
		}
		#endregion

		#region ItemSource Generator

		public void SetRowstoGenerate (int count)
		{
			ProductRepository product = new ProductRepository ();
			products = product.GetProductDetails (100);
		}

		#endregion
	}

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class SelectionViewModel : NotificationObject
	{
		public SelectionViewModel ()
		{
            SetRowstoGenerate(200);
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
            OrderInfoRepository order = new OrderInfoRepository();
            ordersInfo = order.GetOrderDetails(100);
        }

        #endregion
	}

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class FilteringViewModel:INotifyPropertyChanged
	{

		#region Constructor

		public FilteringViewModel ()
		{
            SetRowstoGenerate (100);
		}

		#endregion

		#region Filtering

		#region Fields

		private string filtertext = "";
		private string selectedcolumn = "All Columns";
		private string selectedcondition = "Contains";

		internal delegate void FilterChanged ();

		internal FilterChanged filtertextchanged;

		#endregion

		#region Property

		public  string FilterText {
			get{ return filtertext; }
			set { 
				filtertext = value;
				OnFilterTextChanged ();
				RaisePropertyChanged ("FilterText");
			}

		}

		public string SelectedCondition { 
			get { return selectedcondition; }
			set { selectedcondition = value; }
		}

		public string SelectedColumn { 
			get { return selectedcolumn; }
			set { selectedcolumn = value; }
		}

		#endregion

		#region Private Methods

		private void OnFilterTextChanged ()
		{
            if (filtertextchanged != null)
                filtertextchanged();
		}

		private bool MakeStringFilter (BookInfo o, string option, string condition)
		{
			var value = o.GetType ().GetProperty (option);
			var exactValue = value.GetValue (o, null);
			exactValue = exactValue.ToString ().ToLower ();
			string text = FilterText.ToLower ();
			var methods = typeof(string).GetMethods ();

			if (methods.Count () != 0) {
				if (condition == "Contains") {
					var methodInfo = methods.FirstOrDefault (method => method.Name == condition);
					bool result1 = (bool)methodInfo.Invoke (exactValue, new object[] { text });
					return result1;
				} else if (exactValue.ToString () == text.ToString ()) {
					bool result1 = String.Equals (exactValue.ToString (), text.ToString ());
                    if (condition == "Equals")
                        return result1;
                    else if (condition == "NotEquals")
                        return false;
				} else if (condition == "NotEquals") {
					return true;
				}
				return  false;
			} else
				return false;
		}

		private bool MakeNumericFilter (BookInfo o, string option, string condition)
		{
			var value = o.GetType ().GetProperty (option);
			var exactValue = value.GetValue (o, null);
			double res;
			bool checkNumeric = double.TryParse (exactValue.ToString (), out res);
			if (checkNumeric) {
				switch (condition) {
				case "Equals":
					try {
						if (exactValue.ToString () == FilterText) {
							if (Convert.ToDouble (exactValue) == (Convert.ToDouble (FilterText)))
								return true;
						}
					} catch (Exception e) {
                        Debug.WriteLine (e.Message);
					}
					break;
				case "NotEquals":
					try {
						if (Convert.ToDouble (FilterText) != Convert.ToDouble (exactValue))
							return true;
					} catch (Exception e) {
                        Debug.WriteLine(e.Message);
						return true;
					}
					break;
				}
			}
			return false;
		}

		#endregion

		#region Public Methods

		public bool FilerRecords (object o)
		{
			double res;
			bool checkNumeric = double.TryParse (FilterText, out res);
			var item = o as BookInfo;
			if (item != null && FilterText.Equals ("") && ! string.IsNullOrEmpty(FilterText)) {
				return true;
			} else {
				if (item != null) {
					if (checkNumeric && !SelectedColumn.Equals ("All Columns") && !SelectedCondition.Equals("Contains")) {
						bool result = MakeNumericFilter (item, SelectedColumn, SelectedCondition);
						return result;
					} else if (SelectedColumn.Equals ("All Columns")) {
						if (item.BookName.ToLower ().Contains (FilterText.ToLower ()) ||
							item.FirstName.ToString ().ToLower ().Contains (FilterText.ToLower ()) ||
                            item.LastName.ToString().ToLower().Contains(FilterText.ToLower()) ||
							item.CustomerID.ToString ().ToLower ().Contains (FilterText.ToLower ()) ||
							item.BookID.ToString ().ToLower ().Contains (FilterText.ToLower ()))
							return true;
						return false;
					} else {
						bool result = MakeStringFilter (item, SelectedColumn, SelectedCondition);
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

		public List<BookInfo> BookInfo {
			get { return bookInfo; }
			set { this.bookInfo = value; }
		}

		#endregion

		#region ItemSource Generator

		public void SetRowstoGenerate (int count)
		{
			BookRepository bookrepository = new BookRepository ();
			bookInfo = bookrepository.GetBookDetails (count);
		}

		#endregion

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisePropertyChanged (string propertyName)
		{
			if (PropertyChanged != null)
				this.PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
		}

		#endregion
	}

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class GroupingViewModel: NotificationObject
	{
		public GroupingViewModel ()
		{
			ProductInfoRespository products = new ProductInfoRespository ();
			ProductDetails = products.GetProductDetails (100);
		}

		private List<ProductInfo> productDetails;

		/// <summary>
		/// Gets or sets the product details.
		/// </summary>
		/// <value>The product details.</value>
		public List<ProductInfo> ProductDetails {
			get { return productDetails; }
			set {
				productDetails = value;
				RaisePropertyChanged ("ProductDetails");
			}
		}
	}

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class RenderingDynamicDataViewModel : INotifyPropertyChanged
	{
		#region Members

		ObservableCollection<StockData> data;
		Random r = new Random (123345345);
		private int noOfUpdates = 500;
		List<string> StockSymbols = new List<string> ();
		string[] accounts = new string[] {
			"American Funds",
			"College Savings",
			"Day Trading",
			"Mountain Range",
			"Fidelity Funds",
			"Mortages",
			"Housing Loans"
		};

		#endregion

		/// <summary>
		/// Gets the stocks.
		/// </summary>
		/// <value>The stocks.</value>
		public ObservableCollection<StockData> Stocks {
			get { return this.data; }
		}

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="StocksViewModel"/> class.
		/// </summary>
		public RenderingDynamicDataViewModel ()
		{
			this.data = new ObservableCollection<StockData> ();
			this.AddRows (200);
			this.ResetRefreshFrequency (2500);
		}

		#endregion

		#region Timer and updating code

		/// <summary>
		/// Starts the timer.
		/// </summary>
		public void StartTimer ()
		{
			Device.StartTimer(TimeSpan.FromMilliseconds(200), () =>
				{
					timer_Tick();
					return true;
				});
		}

		/// <summary>
		/// Handles the Tick event of the timer control.
		/// </summary>
		void timer_Tick ()
		{
			int startTime = DateTime.Now.Millisecond;
			noOfUpdates = 100;
			ChangeRows (noOfUpdates);
		}

		/// <summary>
		/// Adds the rows.
		/// </summary>
		/// <param name="count">The count.</param>
		private void AddRows (int count)
		{
			for (int i = 0; i < count; ++i) {
				var newRec = new StockData ();
				newRec.Symbol = ChangeSymbol ();
				newRec.Account = ChangeAccount (i);
				newRec.Open = Math.Round (r.NextDouble () * 30, 2);
				newRec.LastTrade = Math.Round ((1 + r.NextDouble () * 50));
				double d = r.NextDouble ();
				if (d < .5)
					newRec.StockChange = Math.Round (d, 2);
				else
					newRec.StockChange = Math.Round (d, 2) * -1;

				newRec.PreviousClose = Math.Round (r.NextDouble () * 30, 2);
				newRec.Volume = r.Next ();
				data.Add (newRec);
			}
		}

		/// <summary>
		/// Changes the symbol.
		/// </summary>
		/// <returns></returns>
		private String ChangeSymbol ()
		{
			StringBuilder builder = new StringBuilder ();
			Random random = new Random ();
			char ch;

			do {
				builder = new StringBuilder ();
				for (int i = 0; i < 4; i++) {
					ch = Convert.ToChar (Convert.ToInt32 (Math.Floor (26 * random.NextDouble () + 65)));
					builder.Append (ch);
				}

			} while (StockSymbols.Contains (builder.ToString ()));

			StockSymbols.Add (builder.ToString ());
			return builder.ToString ();
		}

		/// <summary>
		/// Changes the account.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		private String ChangeAccount (int index)
		{
			return accounts [index % accounts.Length];
		}

		/// <summary>
		/// Resets the refresh frequency.
		/// </summary>
		/// <param name="changesPerTick">The changes per tick.</param>
		public void ResetRefreshFrequency (int changesPerTick)
		{
				this.noOfUpdates = changesPerTick;
					this.StartTimer ();
			
		}

			public object SelectedItem {
			get { return noOfUpdates; }
			set {
				noOfUpdates = 2;
				RaisePropertyChanged ("SelectedItem");
			}
		}

		public List<int> ComboCollection {
			get { return new List<int> { 500, 5000, 50000, 500000 }; }
		}

		/// <summary>
		/// Changes the rows.
		/// </summary>
		/// <param name="count">The count.</param>
		private void ChangeRows (int count)
		{
			if (data.Count < count)
				count = data.Count;
			for (int i = 0; i < count; ++i) {
				int recNo = r.Next (data.Count);
				StockData recRow = data [recNo];

				data [recNo].LastTrade = Math.Round ((1 + r.NextDouble () * 50));

				double d = r.NextDouble ();
				if (d < .5) {
					data [recNo].StockChange = Math.Round (d, 2);
				} else {
					data [recNo].StockChange = Math.Round (d, 2) * -1;
				}
				data [recNo].Open = Math.Round (r.NextDouble () * 50, 2);
				data [recNo].PreviousClose = Math.Round (r.NextDouble () * 30, 2);
				data [recNo].Volume = r.Next ();
			}
		}

		#endregion

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged (String name)
		{
			if (PropertyChanged != null)
				this.PropertyChanged (this, new PropertyChangedEventArgs (name));
		}

		#endregion

	}

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class StylesViewModel : NotificationObject
	{
		public StylesViewModel ()
		{
			OrderInfoRepository order = new OrderInfoRepository ();
			ordersInfo = order.GetOrderDetails (100);
		}

		#region ItemsSource

		private ObservableCollection<OrderInfo> ordersInfo;

		public ObservableCollection<OrderInfo> OrdersInfo {
			get { return ordersInfo; }
			set { this.ordersInfo = value; }
		}

		#endregion
	}

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class DataVirtualizationViewModel
	{
		public DataVirtualizationViewModel ()
		{
			var repository = new EmployeeInfoRespository ();
			viewSource = new GridVirtualizingCollectionView (repository.GetEmployeesDetails (100000));
		}

		#region ItemsSource

		private VirtualizingCollectionView viewSource;

		public VirtualizingCollectionView ViewSource {
			get { return viewSource; }
			set { viewSource = value; }
		}

		#endregion
	}

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class AutoRowHeightViewModel : INotifyPropertyChanged
	{
		public AutoRowHeightViewModel ()
		{
			ReleaseInfoRepository details = new ReleaseInfoRepository ();
			releaseInformation = details.GetReleaseDetails(28);
		}

		#region ItemsSource

		private ObservableCollection<ReleaseInfo> releaseInformation;

		public ObservableCollection<ReleaseInfo> ReleaseInformation {
			get { return this.releaseInformation; }
			set { this.releaseInformation = value; }
		}

		#endregion

		#region Property Changed

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged (string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) {
				var e = new PropertyChangedEventArgs (propertyName);
				handler (this, e);
			}
		}

		#endregion


	}

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class FrozenRowViewModel
    {
        public FrozenRowViewModel()
        {
            SetRowstoGenerate (100);
        }

        #region ItemsSource

		private List<Product> products;

		public List<Product> Products {
			get { return products; }
			set { this.products = value; }
		}

		#endregion

		#region ItemSource Generator

		public void SetRowstoGenerate (int count)
		{
			ProductRepository product = new ProductRepository ();
			products = product.GetProductDetails (count);
		}

		#endregion
    }

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class GridColumnsViewModel
    {
        #region Constructor

        public GridColumnsViewModel()
		{
			DealerRepository dealerrep = new DealerRepository ();
			dealerInformation = dealerrep.GetDealerDetails (100);
		}

        #endregion

        #region ItemsSource

        private ObservableCollection<DealerInfo> dealerInformation;

		public ObservableCollection<DealerInfo> DealerInformation {
			get { return this.dealerInformation; }
			set { this.dealerInformation = value; }
		}

		#endregion

		#region Property Changed

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged (string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) {
				var e = new PropertyChangedEventArgs (propertyName);
				handler (this, e);
			}
		}

		#endregion
	}

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class CustomerViewModel
    {
        #region Constructor

        public CustomerViewModel()
		{
			CustomersRepository customerrep = new CustomersRepository ();
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

		public void OnPropertyChanged (string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) {
				var e = new PropertyChangedEventArgs (propertyName);
				handler (this, e);
			}
		}

		#endregion
	}

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
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
			get {
				if (dailySalesDetails == null)
					return new SalesInfoRepository().GetSalesDetailsByDay(60);
				else
					return dailySalesDetails;
			}
        }

        #endregion
    }

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class CellTemplateViewModel
    {
        #region Constructor

        public CellTemplateViewModel()
        {
            CellTemplateModelRepository customerrep = new CellTemplateModelRepository();
            employeeInformation = customerrep.GetEmployeeDetails();
        }

        #endregion

        #region ItemsSource

        private List<CellTemplateModel> employeeInformation;

        public List<CellTemplateModel> EmployeeInformation
        {
            get { return this.employeeInformation; }
            set { this.employeeInformation = value; }
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

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class SalesViewModel
	{
		#region Constructor

		public SalesViewModel()
		{

		}

		#endregion

		#region ItemsSource

		private ObservableCollection<SalesByDate> dailySalesDetails = null;

		public ObservableCollection<SalesByDate> DailySalesDetails
		{
			get {
				if (dailySalesDetails == null)
					return new SalesRepository().GetSalesDetailsByDay(5);
				else
					return dailySalesDetails;
			}
		}

		#endregion
	}

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
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
            set { 
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

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class  ExportingViewModel : INotifyPropertyChanged
    {
        public ExportingViewModel()
        {
            SetRowstoGenerate(200);
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

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class DataPagerViewModel : INotifyPropertyChanged
    {
        public DataPagerViewModel()
        {
            SetRowstoGenerate(280);
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

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
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

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class UnBoundColumnViewModel
    {
        public UnBoundColumnViewModel()
        {
            ProductRepository product = new ProductRepository();
            products = product.GetProductDetails(100);
        }

        #region ItemsSource

        private List<Product> products;

        public List<Product> Products
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

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class ColumnDragAndDropViewModel
    {
        public ColumnDragAndDropViewModel()
        {
            ProductRepository product = new ProductRepository();
            products = product.GetProductDetails(100);
        }

        #region ItemsSource

        private List<Product> products;

        public List<Product> Products
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

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class RowDragAndDropViewModel : INotifyPropertyChanged
    {
        public RowDragAndDropViewModel()
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

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class GettingStartedViewModel : INotifyPropertyChanged
    {
        public GettingStartedViewModel()
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

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
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

}

