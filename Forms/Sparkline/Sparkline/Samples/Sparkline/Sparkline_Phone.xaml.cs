#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfSparkline.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfSparkline
{
    [Preserve(AllMembers = true)]
    public partial class Sparkline_Phone : SampleView
    {
		SfAreaSparkline area;
		SfLineSparkline line;
		SfColumnSparkline column;
		SfWinLossSparkline winLoss;
		Label columnLabel, areaLabel, lineLabel, winLossLabel;
		public Sparkline_Phone()
		{
			InitializeComponent();
			var dataModel = new SparkViewModel();
			stack.BindingContext = dataModel;

			area = new SfAreaSparkline
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions  = LayoutOptions.FillAndExpand
			};
			area.ItemsSource = dataModel.Datas;
			area.YBindingPath = "Performance";

			areaLabel = new Label
			{
				Text = "Area",
				FontSize = 14,
				HorizontalOptions = LayoutOptions.Center,
				FontAttributes = FontAttributes.Bold

			};

			stack.Children.Add(area);
			stack.Children.Add(areaLabel);

			line = new SfLineSparkline
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand     
			};
			line.ItemsSource = dataModel.Datas;
			line.YBindingPath = "Performance";

			lineLabel = new Label
			{
				Text = "Line",
				FontSize = 14,
				HorizontalOptions = LayoutOptions.Center,
				FontAttributes = FontAttributes.Bold
			};

			stack.Children.Add(line);
			stack.Children.Add(lineLabel);

			column = new SfColumnSparkline
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			column.ItemsSource = dataModel.ColumnDatas;
			column.YBindingPath = "YearPerformance";

			columnLabel = new Label
			{
				Text = "Column",
				FontSize = 14,
				HorizontalOptions = LayoutOptions.Center,
				FontAttributes = FontAttributes.Bold
			};
			stack.Children.Add(column);
			stack.Children.Add(columnLabel);

			winLoss = new SfWinLossSparkline
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			winLoss.ItemsSource = dataModel.ColumnDatas;
			winLoss.YBindingPath = "YearPerformance";

			winLossLabel = new Label
			{
				Text = "Win/Loss",
				FontSize = 14,
				HorizontalOptions = LayoutOptions.Center,
				FontAttributes = FontAttributes.Bold
			};

			stack.Children.Add(winLoss);
			stack.Children.Add(winLossLabel);

            if (Device.RuntimePlatform == Device.iOS)
                stack.SizeChanged += Layout_SizeChanged;
            else
            {
                area.Margin = new Thickness(0, 5, 0, 5);
                line.Margin = new Thickness(0, 5, 0, 5);
                column.Margin = new Thickness(0, 5, 0, 5);
                winLoss.Margin = new Thickness(0, 5, 0, 5);
            }

		}
		public View getContent()
		{
			return Content;
		}

		public View getPropertyView()
		{
			return this.PropertyView;
		}


        protected void Layout_SizeChanged(object sender, System.EventArgs e)
        {
            var size = areaLabel.Bounds.Height;
            var labelHeight = size * 4;
            double controlPadding = 6;
            var height = stack.Height - (labelHeight + (controlPadding * 8));
            var width = stack.Width;

            MeasureSparkline(width, height);
        }

		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);
            MeasureSparkline(width, height);
		}

        private void MeasureSparkline(double width, double height)
        {
            if (height > 0 && width > 0)
            {
                area.HeightRequest = 0.20 * height;
                line.HeightRequest = 0.20 * height;
                column.HeightRequest = 0.20 * height;
                winLoss.HeightRequest = 0.20 * height;
                lineLabel.HeightRequest = 0.05 * height;
                areaLabel.HeightRequest = 0.05 * height;
                columnLabel.HeightRequest = 0.05 * height;
                winLossLabel.HeightRequest = 0.05 * height;
                area.WidthRequest = width;
                line.WidthRequest = width;
                column.WidthRequest = width;
                winLoss.WidthRequest = width;
            }
        }
	}
}