#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Text.Style;
using System;
using Android.Graphics;
using Org.Json;
using Android.Widget;
using Android.Views;
using Android.Content;
using Syncfusion.SfPullToRefresh;
using System.Collections.Generic;
using Java.Text;
using Java.Util;
using Android.Text;
using Android.OS;
using System.Threading.Tasks;

namespace SampleBrowser
{
	public class PullToRefreshDemo: SamplePage
	{
		SfPullToRefresh pull;
		LinearLayout linearLayout,linearLayoutChild, selectedLayout;
		List<WeatherData> dataSource;
		Handler handler;
		TextView textView,textView1,degreetext;
		ImageView imageView3;
		WeatherData selectedData;
		View view ;
        Java.Lang.Runnable run;

        public PullToRefreshDemo()
        {


        }
	    public override View GetSampleContent (Context context)
		{

			handler = new Handler ();

			LayoutInflater layoutInflater = LayoutInflater.From(context);
			view = layoutInflater.Inflate(Resource.Layout.pulltorefresh, null);

			Calendar cal = Calendar.GetInstance(Java.Util.TimeZone.Default);
			SimpleDateFormat dateformat = new SimpleDateFormat("EEEE, MMMM dd ");
			String strDate = dateformat.Format(cal.Time);
			linearLayout = (LinearLayout) view;
			linearLayout.SetBackgroundColor(Color.ParseColor("#039be5"));
			linearLayoutChild = (LinearLayout) view.FindViewById(Resource.Id.pullscroller);
			dataSource= GetData();

			TextView textView3= (TextView) view.FindViewById(Resource.Id.text);

			String s= ""+dataSource[0].Temperature+ (char) 0x00B0 + "/12";
			SpannableString ss1=  new SpannableString(s);
			ss1.SetSpan(new RelativeSizeSpan(2f), 0, 4, SpanTypes.ExclusiveExclusive);
			textView3.SetText(ss1,TextView.BufferType.Normal);
			ImageView imageView= (ImageView) view.FindViewById(Resource.Id.imageview);
			imageView.SetImageResource(dataSource[0].Type);
			TextView textView6= (TextView) view.FindViewById(Resource.Id.text1);
			textView6.Text=strDate;

			for (int i = 0; i <dataSource.Count; i++) {

				LinearLayout lay = (LinearLayout)layoutInflater.Inflate(Resource.Layout.pulltorefreshtemplate, null);
				textView= (TextView) lay.FindViewById(Resource.Id.text3);
				textView.Text=dataSource[i].Day;

				textView1= (TextView) lay.FindViewById(Resource.Id.text4);
				textView1.Text="" + (int) dataSource[i].Temperature+(char) 0x00B0 ;

				imageView= (ImageView) lay.FindViewById(Resource.Id.imageview1);

				imageView.SetImageResource(dataSource[i].Type);

				if(i==0)
				{
					textView.SetTextColor(Color.ParseColor("#fbb03b"));
					textView1.SetTextColor(Color.ParseColor("#fbb03b"));
					imageView.SetImageResource(dataSource[i].SelectedType);
					selectedData = dataSource[i];
					selectedLayout = lay;
				}
				setOnClick(lay, i);

				linearLayoutChild.AddView(lay);

			}
			pull = new SfPullToRefresh (context);
            pull.RefreshContentThreshold = 0;
            pull.PullableContent=linearLayout;
            pull.Refreshing += (sender, e) =>
            {
			    if(selectedLayout!=null){
			     run = new Java.Lang.Runnable(() =>
					{
						Java.Util.Random rnd = new Java.Util.Random();
						int	i = rnd.NextInt(6 - 0 + 1) + 0;
						imageView3 = (ImageView) linearLayout.FindViewById(Resource.Id.imageview);
						imageView3.SetImageResource(dataSource[i].Type);
						degreetext = (TextView) linearLayout.FindViewById(Resource.Id.text);
					   String s1= "" + dataSource[i].Temperature + (char) 0x00B0 + "/12";
						SpannableString ss3 = new SpannableString(s1);
						ss3.SetSpan(new RelativeSizeSpan(2f),0,4,SpanTypes.ExclusiveExclusive); 
						degreetext.SetText(ss3,TextView.BufferType.Normal);
                        e.Refreshed = true;
                    });
				handler.PostDelayed(run, 3000);
                }
            };
		return pull;
		}

		private void setOnClick( LinearLayout lay,   int i){
			lay.Click += (object sender, EventArgs e) => {

				if (selectedLayout != null) {
					TextView oldTextView1 = (TextView)selectedLayout.FindViewById (Resource.Id.text3);
					TextView oldTextView2 = (TextView)selectedLayout.FindViewById (Resource.Id.text4);
					ImageView newImageView = (ImageView)selectedLayout.FindViewById (Resource.Id.imageview1);
					oldTextView1.SetTextColor (Color.ParseColor ("#ffffff"));
					oldTextView2.SetTextColor (Color.ParseColor ("#ffffff"));
					newImageView.SetImageResource (selectedData.Type);
				}
				TextView newTextView1 = (TextView)lay.FindViewById (Resource.Id.text3);
				TextView newTextView12 = (TextView)lay.FindViewById (Resource.Id.text4);
				ImageView newimageView = (ImageView)lay.FindViewById (Resource.Id.imageview1);

				WeatherData data = dataSource[i];
				newTextView1.SetTextColor (Color.ParseColor ("#fbb03b"));
				newTextView12.SetTextColor (Color.ParseColor ("#fbb03b"));
				newimageView.SetImageResource (data.SelectedType);
				ImageView imageView = (ImageView)linearLayout.FindViewById (Resource.Id.imageview);
				imageView.SetImageResource (data.Type);
				TextView degreeText = (TextView)linearLayout.FindViewById (Resource.Id.text);

			
				String s2 = "" + data.Temperature + (char) 0x00B0 + "/12";
				SpannableString ss2=  new SpannableString(s2);
				ss2.SetSpan(new RelativeSizeSpan(2f),0,4,SpanTypes.ExclusiveExclusive);
				degreeText.SetText(ss2,TextView.BufferType.Normal);
				TextView dayText = (TextView)linearLayout.FindViewById (Resource.Id.text1);
				dayText.Text=dataSource[i].Date;
				selectedData = data;
				selectedLayout = lay;
			};
		}

		List<WeatherData> GetData()
		{
			List<WeatherData> list = new List<WeatherData>();
			SimpleDateFormat dateformat = new SimpleDateFormat("EEEE, MMMM dd ");
			SimpleDateFormat dateformat1=new SimpleDateFormat("EEEE");

			Calendar cal = Calendar.GetInstance(Java.Util.TimeZone.Default);
			String strDate = dateformat.Format(cal.Time);
			String strDay = dateformat1.Format(cal.Time);
			Calendar cal1 = Calendar.GetInstance(Java.Util.TimeZone.Default);
			cal1.Add(CalendarField.Date,+1);
			String strDate1 = dateformat.Format(cal1.Time);
			String strDay1 = dateformat1.Format(cal1.Time);
			Calendar cal2 = Calendar.GetInstance(Java.Util.TimeZone.Default);
			cal2.Add(CalendarField.Date,+2);
			String strDate2 = dateformat.Format(cal2.Time);
			String strDay2 = dateformat1.Format(cal2.Time);
			Calendar cal3 = Calendar.GetInstance(Java.Util.TimeZone.Default);
			cal3.Add(CalendarField.Date,+3);
			String strDate3 = dateformat.Format(cal3.Time);
			String strDay3 = dateformat1.Format(cal3.Time);
			Calendar cal4 = Calendar.GetInstance(Java.Util.TimeZone.Default);
			cal4.Add(CalendarField.Date,+4);
			String strDate4 = dateformat.Format(cal4.Time);
			String strDay4 = dateformat1.Format(cal4.Time);
			Calendar cal5 = Calendar.GetInstance(Java.Util.TimeZone.Default);
			cal5.Add(CalendarField.Date,+5);
			String strDate5 = dateformat.Format(cal5.Time);
			String strDay5 = dateformat1.Format(cal5.Time);
			Calendar cal6 = Calendar.GetInstance(Java.Util.TimeZone.Default);
			cal6.Add(CalendarField.Date,+6);
			String strDate6 = dateformat.Format(cal6.Time);
			String strDay6 = dateformat1.Format(cal6.Time);
			list.Add(new WeatherData(strDay,strDate,21,Resource.Drawable.humid,Resource.Drawable.humidselected ));
			list.Add(new WeatherData(strDay1,strDate1,24, Resource.Drawable.cloudy,Resource.Drawable.cloudyselected ));
			list.Add(new WeatherData(strDay2,strDate2,26,Resource.Drawable.humid,Resource.Drawable.humidselected ));
			list.Add(new WeatherData(strDay3,strDate3,23,Resource.Drawable.rainy,Resource.Drawable.rainyselected  ));
			list.Add(new WeatherData(strDay4,strDate4,32,Resource.Drawable.warm,Resource.Drawable.warmselected ));
			list.Add(new WeatherData(strDay5,strDate5,12,Resource.Drawable.windy,Resource.Drawable.windyselected ));
			list.Add(new WeatherData(strDay6,strDate6,30, Resource.Drawable.cloudy,Resource.Drawable.cloudyselected));
			return  list;
		}
		public override View GetPropertyWindowLayout(Context context)
		{
			FrameLayout propertyLayout = new FrameLayout(context);
		    LinearLayout layout = new LinearLayout(context);
			layout.Orientation = Orientation.Vertical;
			layout.SetBackgroundColor(Color.White);
			layout.SetPadding(15, 15, 15, 20);
			TextView transitiontype = new TextView(context);
			transitiontype.Text="Tranisition Type";
			transitiontype.TextSize = 20;
			transitiontype.SetPadding(0, 0, 0, 10);
			transitiontype.SetTextColor(Color.Black);
			Spinner sType_spinner = new Spinner(context,SpinnerMode.Dialog);
			sType_spinner.SetMinimumHeight(60);
			sType_spinner.SetBackgroundColor(Color.Gray);
			sType_spinner.DropDownWidth = 600;
			sType_spinner.SetPadding(10, 10, 0, 10);
			sType_spinner.SetGravity(GravityFlags.CenterHorizontal);
			layout.AddView(transitiontype);
			layout.AddView(sType_spinner);
			List<String> list = new List<String>();
			list.Add("SlideOnTop");
			list.Add("Push");
			ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, list);
			dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			sType_spinner.Adapter = dataAdapter;
            sType_spinner.ItemSelected += sType_spinner_ItemSelected;
            if (pull.TransitionType == TransitionType.SlideOnTop)
                sType_spinner.SetSelection(0);
            else
                sType_spinner.SetSelection(1);
            propertyLayout.AddView(layout);
			return propertyLayout;

		}
		void sType_spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{

			Spinner spinner = (Spinner)sender;
			String selectedItem = spinner.GetItemAtPosition(e.Position).ToString();

			if (pull != null)
			{
				if (selectedItem.Equals("SlideOnTop"))
				{
					pull.TransitionType = TransitionType.SlideOnTop;
                    pull.RefreshContentThreshold = 0;
				}
				else if (selectedItem.Equals("Push"))
				{
					pull.TransitionType = TransitionType.Push;
                    pull.RefreshContentThreshold = 25;
				}
			}
		}

        public override void Destroy()
        {
            handler.RemoveCallbacks(run);
            pull.Dispose();
            pull = null;
        }
    }


	public class WeatherData
	{
		public WeatherData(String day,String date,int temperature,int type,int selectedType)
		{
			Day = day;
			Date = date;
			Temperature = temperature;
			SelectedType=selectedType;
			Type=type;
			id=type;
		}
		public String Day;
		public int SelectedType;
		public String Date;
		public int Temperature;
		public  int Type;
		public  int id;
	}
}