#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using System.Diagnostics;
using Syncfusion.SfSchedule.XForms;
using Syncfusion.SfDataGrid.XForms;

namespace PatientMonitor
{
	public partial class GridViewPage : ContentPage
    {
		HomeViewModel viewModel;

	    #region Constructor

		public GridViewPage()
		{
			InitializeComponent ();
            dataGrid.HorizontalOptions = LayoutOptions.FillAndExpand;
            dataGrid.VerticalOptions = LayoutOptions.FillAndExpand;
           
            dataGrid.SelectionChanged += DataGrid_SelectionChanged;
            dataGrid.GridStyle = new Custom_GridStyle();
			this.Icon = "mypatient.png";
        }

		#endregion

		#region events

    
		async void DataGrid_SelectionChanged (object sender, Syncfusion.SfDataGrid.XForms.GridSelectionChangedEventArgs e)
		{
            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this, true);
           
            LiveHistoryViewModel viewModel = new LiveHistoryViewModel(e.AddedItems[0] as Patient);
            await Navigation.PushAsync(new HistoryView() { BindingContext = viewModel, Title=(e.AddedItems[0] as Patient).Name });
            
        }
			
		#endregion
		 
    }

	public class Custom_GridStyle : DataGridStyle
	{
		public override Color GetBordercolor ()
		{
			return Color.Transparent;
		}

		public override Color GetRecordBackgroundColor ()
		{
			return Color.FromRgb (249, 249, 249);
		}

		public override Color GetRecordForegroundColor ()
		{
			return Color.Black;
		}

		public override Color GetHeaderForegroundColor ()
		{
			return Color.FromHex ("#5b5b5b");
		}

		public override Color GetSelectionForegroundColor ()
		{
			return Color.FromHex ("#5b5b5b");
		}
	} 

}
