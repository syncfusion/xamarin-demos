#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfDataGrid;
using CoreFoundation;
using IncrementalLoading.NorthwindService;
using System.Data.Services.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using UIKit;
using CoreGraphics;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Timers;
using Syncfusion.Data;

namespace SampleBrowser
{
	public class IncrementalLoadingViewModel : INotifyPropertyChanged
	{
		#region Members

		NorthwindEntities northwindEntity;

		#endregion

		#region Ctor

		public UIActivityIndicatorView LoaderIndicator;
		public UILabel LoaderLable;
		public UIView LoaderBorder;

		public IncrementalLoadingViewModel ()
		{
			LoaderBorder = new UIView ();
			this.LoaderLable = new UILabel ();
			this.LoaderIndicator = new UIActivityIndicatorView ();
			this.LoaderIndicator.Color = UIColor.FromRGB (255, 255, 255);
            LoaderBorder.BackgroundColor = UIColor.FromRGB(70, 183, 118);
			LoaderBorder.Add (LoaderLable);
			LoaderBorder.Add (LoaderIndicator);

			string uri = "http://services.odata.org/Northwind/Northwind.svc/";
			if (CheckConnection (uri).Result) {
				gridSource = new IncrementalList<Order> (LoadMoreItems) { MaxItemsCount = 1000 };
				northwindEntity = new NorthwindEntities (new Uri (uri));
			} else {
				NoNetwork = true;
				IsBusy = false;
			}
		}

		#endregion

		#region Properties

		private IncrementalList<Order> gridSource;

		public IncrementalList<Order> GridSource {
			get { return gridSource; }
			set {
				gridSource = value;
				RaisePropertyChanged ("GridSource");
			}
		}

		private bool isBusy;

		public bool IsBusy {
			get { return isBusy; }
			set {
				isBusy = value;
				if (isBusy) {
					this.LoaderLable.Text = "Fetching Data... ";
				} else {
					if (noNetwork) {
						LoaderLable.LineBreakMode = UILineBreakMode.WordWrap;
						LoaderLable.Lines = 0;
						this.LoaderLable.Text = "No Network Found..! \nSearching for a network...";
					}
				}
				RaisePropertyChanged ("IsBusy");
			}
		}

		private bool noNetwork;

		public bool NoNetwork {
			get { return noNetwork; }
			set {
				noNetwork = value;
				RaisePropertyChanged ("NoNetwork");
			}
		}


		#endregion

		#region INotifyPropertyChanged Member

		public event PropertyChangedEventHandler PropertyChanged;

		void RaisePropertyChanged (string propertyName)
		{
			if (PropertyChanged != null) {
				PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
			}
		}

		#endregion

		#region Methods

		void LoadMoreItems (uint count, int baseIndex)
		{
			BackgroundWorker worker = new BackgroundWorker ();

			worker.DoWork += (o, ae) => {
				DataServiceQuery<Order> query = northwindEntity.Orders.Expand ("Customer");
				query = query.Skip<Order> (baseIndex).Take<Order> (15) as DataServiceQuery<Order>;
				IAsyncResult ar = query.BeginExecute (null, null);
				var items = query.EndExecute (ar);
				var list = items.ToList ();

				DispatchQueue.MainQueue.DispatchAsync (new Action (() => {
					GridSource.LoadItems (list);
				}));
			};

			worker.RunWorkerCompleted += (o, ae) => {
				IsBusy = false;
				UIView.Animate (2, () => {
					for (int i = 5; i < 0; i--) {
						LoaderBorder.Alpha = i - 0.1f;
					}

					LoaderBorder.Hidden = true;
				});
				this.LoaderIndicator.StopAnimating ();
				this.LoaderIndicator.HidesWhenStopped = true;
				this.LoaderLable.Hidden = true;
			};
            
			IsBusy = true;
			{
				this.LoaderLable.Hidden = false;
				LoaderBorder.Hidden = false;
				UIView.Animate (2, () => {

					this.LoaderIndicator.StartAnimating ();
				});

			}
			worker.RunWorkerAsync ();
		}

		private async Task<bool> CheckConnection (String url)
		{
			try {
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create (url);
				request.Timeout = 5000;
				request.Credentials = CredentialCache.DefaultNetworkCredentials;
				HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
				await Task.Delay(0);

				if (response.StatusCode == HttpStatusCode.OK)
					return true;
				else
					return false;
			} catch {
				return false;
			}
		}

		#endregion
	}
}
