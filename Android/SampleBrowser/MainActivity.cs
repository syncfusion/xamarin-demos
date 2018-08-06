#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using System.Xml;
using System.Collections.Generic;
using Android.Support.V4.Widget;
using Android.Support.V4.View;
using Android.Telephony;
using Android.Content.PM;
using Android.Content.Res;
using System.Linq;

namespace SampleBrowser
{
	[Activity(Label = "Essential Studio", ScreenOrientation = ScreenOrientation.Portrait, Theme = "@style/PropertyApp", Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		public static Activity context;
		public static Intent SelectedIntent;
		List<SampleBase> aSamples;
		internal static List<SampleBase> FeatureSamples;
		static internal bool isFeatureSamples;
		private DrawerLayout mDrawerLayout;
		public static MainActivity mainActivity;
		GridView listView;
		LinearLayout drawer;
		ImageView imageView;
		private LinearLayout productpage, documentation, whatsNew;
		static internal bool isTablet;
		public static float factor;

		protected override void OnCreate(Bundle bundle)
		{
			
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("");
			
			float staticDensity = 2.55f;
			float deviceDenstiy = Resources.DisplayMetrics.Density;
			factor = deviceDenstiy / staticDensity;
			base.OnCreate(bundle);
			ParseXML();
			if (Android.OS.Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.Lollipop)
			{
				aSamples.Remove(aSamples.First(x => x.Title == "PDFViewer"));
			}
			SetContentView(Resource.Layout.HomeScreen);
			ActionBar.Hide();
			listView = FindViewById<GridView>(Resource.Id.List);
			context = mainActivity = this;

			listView.Adapter = new HomeScreenAdapter(this, aSamples);
			listView.ItemClick += OnListItemClick;

			var manager = this.GetSystemService(Context.TelephonyService)
					   as TelephonyManager;
			isTablet = GetDeviceType(this);
			if (isTablet)
			{
				listView.SetNumColumns(2);
				isTablet = true;
			}
			else
			{
				listView.SetNumColumns(1);
				isTablet = false;
			}

			mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			drawer = FindViewById<LinearLayout>(Resource.Id.left_drawer);
			imageView = FindViewById<ImageView>(Resource.Id.navDrawIcon);
			productpage = FindViewById<LinearLayout>(Resource.Id.productpagelayout);
			documentation = FindViewById<LinearLayout>(Resource.Id.documentlayout);
			whatsNew = FindViewById<LinearLayout>(Resource.Id.whatsnewlayout);
			TextView versionText = FindViewById<TextView>(Resource.Id.versionText);
			versionText.Text = versionText.Text + Resources.GetString(Resource.String.version);
			drawer.BringToFront();
			int width = Resources.DisplayMetrics.WidthPixels * 3 / 4;
			if (isTablet)
			{
				width = Int32.Parse((Resources.DisplayMetrics.WidthPixels * 0.5f).ToString());
			}

			drawer.LayoutParameters.Width = (int)width;

			imageView.Click += delegate
			{
				mDrawerLayout.OpenDrawer(GravityCompat.Start);
			};

			productpage.Click += delegate
			{
				goToUrl("https://www.syncfusion.com/products/xamarin");
			};

			documentation.Click += delegate
			{               
				goToUrl("https://help.syncfusion.com/xamarin-android/introduction/overview");
			};

			whatsNew.Click += delegate
			{
				goToUrl("https://www.syncfusion.com/products/whatsnew/xamarin-android");
			};
		}

		public static bool GetDeviceType(Context context)
		{
			return (context.Resources.Configuration.ScreenLayout
					& ScreenLayout.SizeMask)
					>= ScreenLayout.SizeLarge;
		}

		private void goToUrl(String url)
		{
			var uri = Android.Net.Uri.Parse(url);
			var intent = new Intent(Intent.ActionView, uri);
			StartActivity(intent);
		}

		protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
		{
			var sample = aSamples[e.Position];

			Intent intent = new Intent(this, typeof(AllControlsSamplePage));
			SelectedIntent = intent;
			intent.PutExtra("sample", sample);
			StartActivity(intent);
		}

		void ParseXML()
		{
			XmlReader xtr = Resources.GetXml(Resource.Xml.samplelist);
			xtr.Read();
			FeatureSamples = new List<SampleBase>();
			bool featuresamplescompleted = false;
			bool controlsamplecompleted = false;
			while (!xtr.EOF && xtr.Name != null)
			{
				List<SampleBase> groups = new List<SampleBase>();
				xtr.Read();

				if (xtr.Name == "FeatureSamples" && !xtr.IsStartElement()) break;
				xtr.Read();

				while (!featuresamplescompleted)
				{
					if (xtr.Name == "Sample" && xtr.IsStartElement())
					{
						Sample tc = new Sample();
						SetSample(tc, xtr);
						FeatureSamples.Add(tc);
						xtr.Read();
						xtr.Read();

					}
					if (xtr.Name == "FeatureSamples" && !xtr.IsStartElement())
					{
						featuresamplescompleted = true;
						xtr.Read();
					}

				}
				if (xtr.Name == "ControlSamples" && xtr.IsStartElement())
				{
					xtr.Read();
					while (!controlsamplecompleted)
					{


						bool isGroup = false;
						while (!isGroup)
						{
							if (xtr.Name == "Group" && xtr.IsStartElement())
							{
								Group group = new Group();

								SetSample(group, xtr);
								xtr.Read();

								List<SampleBase> samples = new List<SampleBase>();
								List<SampleBase> features = new List<SampleBase>();
								bool samplescompleted = false;
								bool featurescompleted = false;
								while (!samplescompleted || !featurescompleted)
								{
									if (xtr.Name == "Samples" && xtr.IsStartElement())
									{
										xtr.Read();
										while (!samplescompleted)
										{
											if (xtr.Name == "Sample" && xtr.IsStartElement())
											{
												Sample tc = new Sample();
												SetSample(tc, xtr);
												samples.Add(tc);
												xtr.Read();
												xtr.Read();
											}
											if (xtr.Name == "Samples" && !xtr.IsStartElement())
											{
												samplescompleted = true;
												xtr.Read();
											}
										}

									}
									if (xtr.Name == "Features" && xtr.IsStartElement())
									{
										xtr.Read();
										while (!featurescompleted)
										{
											if (xtr.Name == "Feature" && xtr.IsStartElement())
											{
												Feature tc = new Feature();
												SetSample(tc, xtr);
												features.Add(tc);
												xtr.Read();
												xtr.Read();
											}
											if (xtr.Name == "Features" && !xtr.IsStartElement())
											{
												featurescompleted = true;
												xtr.Read();
											}
										}
									}
									if (xtr.Name == "Group" && !xtr.IsStartElement())
									{
										isGroup = true;
										groups.Add(group);
										xtr.Read();
										featurescompleted = true;
										samplescompleted = true;
										group.samples = samples;
										group.Features = features;
									}
									if (xtr.Name == "ControlSamples" && !xtr.IsStartElement())
									{
										controlsamplecompleted = true;
									}
								}

							}
						}
					}
				}

				xtr.Read();
				if (xtr.Name == "SampleList" && !xtr.IsStartElement())
				{
					xtr.Read();
				}
				this.aSamples = groups;
			}
			xtr.Close();
		}


		void SetSample(SampleBase sample, XmlReader reader)
		{
			reader.MoveToAttribute("Name");
			sample.Name = getValueFromReader(reader);
			reader.MoveToAttribute("Title");
			sample.Title = getValueFromReader(reader);
			reader.MoveToAttribute("Description");
			sample.Description = getValueFromReader(reader);
			reader.MoveToAttribute("Type");
			if (reader.Name == "Type")
			{
				sample.Type = getValueFromReader(reader);
			}

			reader.MoveToAttribute("ImageId");
			if (reader.Name == "ImageId")
			{
				sample.ImageId = getValueFromReader(reader);
			}

		}

		string getValueFromReader(XmlReader reader)
		{
			return reader.Value != null ? reader.Value : null;
		}

		protected override void OnSaveInstanceState(Bundle outState)
		{
			outState.PutInt("tab", this.ActionBar.SelectedNavigationIndex);

			base.OnSaveInstanceState(outState);
		}

		void AddTab(string tabText, Fragment view)
		{
			var tab = this.ActionBar.NewTab();
			tab.SetText(tabText);

			tab.TabSelected += delegate (object sender, Android.App.ActionBar.TabEventArgs e)
			{
				var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragment_content);
				if (fragment != null)
					e.FragmentTransaction.Remove(fragment);
				e.FragmentTransaction.Add(Resource.Id.fragment_content, view);
			};

			tab.TabUnselected += delegate (object sender, Android.App.ActionBar.TabEventArgs e)
			{
				e.FragmentTransaction.Remove(view);
			};

			this.ActionBar.AddTab(tab);
		}

		public override void OnBackPressed()
		{
			Finish();
			base.OnBackPressed();
		}
	}
}