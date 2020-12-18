#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Maps;
using Org.Json;

namespace SampleBrowser
{
	public class TicketBooking : SamplePage
	{
		GridLayout gridlayout;
		View view;
		LinearLayout linearLayoutChild;
		Button ClearSelection;
		TextView SelectedLabel, SelectedLabelCount;
		SfMaps maps;


		public override Android.Views.View GetSampleContent(Android.Content.Context context)
		{
			LayoutInflater layoutInflater = LayoutInflater.From(context);
			view = layoutInflater.Inflate(Resource.Layout.TicketBooking, null);
			gridlayout = (GridLayout)view;

			maps = new SfMaps(context);
			ShapeFileLayer layer = new ShapeFileLayer();
			layer.ShowItems = true;
			layer.EnableSelection = true;
			layer.Uri = "Custom.shp";
			layer.DataSource = GetDataSource();
			layer.SelectionMode = SelectionMode.Multiple;
			layer.ShapeSettings.SelectedShapeColor = Color.Rgb(98, 170, 95);
			layer.GeometryType = GeometryType.Points;

			layer.ShapeSelected += (object sender, ShapeFileLayer.ShapeSelectedEventArgs e) =>
			{
				JSONObject data = (JSONObject)e.P0;



				if (data != null)
				{
					UpdateSelection();
				}
			};

            layer.SelectedItems.CollectionChanged += SelectedItems_CollectionChanged;

			layer.ShapeSettings.ShapeStrokeThickess = 2;
			SetColorMapping(layer.ShapeSettings);
			layer.ShapeSettings.ShapeColorValuePath = "SeatNumber";
			layer.ShapeIdTableField = "seatno";
			layer.ShapeIdPath = "SeatNumber";


			maps.Layers.Add(layer);
			maps.SetPadding(10, 0, 0, 0);

			linearLayoutChild = (LinearLayout)view.FindViewById(Resource.Id.linear);
			ClearSelection = (Button)view.FindViewById(Resource.Id.ClearSelection);

			ClearSelection.Click += (object sender, EventArgs e) =>
			{
                if ((maps.Layers[0] as ShapeFileLayer).SelectedItems.Count != 0)
                {
                    (maps.Layers[0] as ShapeFileLayer).SelectedItems.Clear();
                    SelectedLabel.Text = "";
                    SelectedLabelCount.Text = "" + (maps.Layers[0] as ShapeFileLayer).SelectedItems.Count;
                    //ClearSelection.Visibility = ViewStates.Invisible;
                    ClearSelection.Alpha = 0.5f;
                    ClearSelection.Enabled = false;

                }
            };





			SelectedLabel = (TextView)view.FindViewById(Resource.Id.SelectedLabel);
			SelectedLabelCount=(TextView)view.FindViewById(Resource.Id.SelectedLabelCount);

			linearLayoutChild.AddView(maps);


			return gridlayout;
		}

        private void SelectedItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                UpdateSelection();
            }
        }

        void UpdateSelection()
		{



			string selected = "";

			string selectedSeat = "";


            if ((maps.Layers[0] as ShapeFileLayer).SelectedItems.Count == 0)
            {
                SelectedLabel.Text = "" + selected;
                SelectedLabelCount.Text = "" + (maps.Layers[0] as ShapeFileLayer).SelectedItems.Count;
                //ClearSelection.Visibility = ViewStates.Invisible;
                ClearSelection.Alpha = 0.5f;
                ClearSelection.Enabled = false;

            }
            else
            {

                for (int i = 0; i < (maps.Layers[0] as ShapeFileLayer).SelectedItems.Count; i++)
                {
                    JSONObject item = (JSONObject)(maps.Layers[0] as ShapeFileLayer).SelectedItems[i];


                    object SeatNo = item.Get("SeatNumber");
                    selectedSeat = SeatNo.ToString();

                    if (selectedSeat == "1" || selectedSeat == "2" || selectedSeat == "8" || selectedSeat == "9")
                    {
                        (maps.Layers[0] as ShapeFileLayer).SelectedItems.Remove(item);
                    }

                    else
                    {
                        if ((maps.Layers[0] as ShapeFileLayer).SelectedItems.Count <= 1)

                            selected += ("S" + selectedSeat);
                        else if (i == (maps.Layers[0] as ShapeFileLayer).SelectedItems.Count - 1)
                            selected += ("S" + selectedSeat);
                        else
                            selected += ("S" + selectedSeat + ", ");
                    }

                }
                //	ClearSelection.Visibility = ViewStates.Visible;

                ClearSelection.Alpha = 1f;
                ClearSelection.Enabled = true;

                SelectedLabel.Text = selected;
                SelectedLabelCount.Text = "" + (maps.Layers[0] as ShapeFileLayer).SelectedItems.Count;
            }

        }




		JSONArray GetDataSource()
		{
			JSONArray array = new JSONArray();
			for (int i = 1; i < 22; i++)
			{
				array.Put(getJsonObject(""+i));


			}
			return array;
		}


	JSONObject getJsonObject(String Seatnumber)
		{
			JSONObject obj = new JSONObject();
			obj.Put("SeatNumber", Seatnumber);

			return obj;
		}


		void SetColorMapping(ShapeSetting setting)
		{
			List<ColorMapping> colorMappings = new List<ColorMapping>();



			EqualColorMapping colorMapping2 = new EqualColorMapping();
			colorMapping2.Value = "1";
			colorMapping2.Color = Color.ParseColor("#FFA500");
			colorMappings.Add(colorMapping2);

			EqualColorMapping colorMapping3 = new EqualColorMapping();
			colorMapping3.Value = "2";
			colorMapping3.Color = Color.ParseColor("#FFA500");
			colorMappings.Add(colorMapping3);

			EqualColorMapping colorMapping4 = new EqualColorMapping();
			colorMapping4.Value = "8";
			colorMapping4.Color = Color.ParseColor("#FFA500");
			colorMappings.Add(colorMapping4);


			EqualColorMapping colorMapping1 = new EqualColorMapping();
			colorMapping1.Value = "9";
			colorMapping1.Color = Color.ParseColor("#FFA500");
			colorMappings.Add(colorMapping1);
			setting.ColorMapping = colorMappings;
		}


		 
	}
}
