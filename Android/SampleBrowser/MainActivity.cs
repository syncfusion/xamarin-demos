#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
        #region fields
        
        private GridView listView;

		private LinearLayout drawer;

		private ImageView imageView;

        private List<SampleModel> controls;

        private DrawerLayout drawerLayout;

		private LinearLayout productpage, documentationPage, whatsNewPage;

        #endregion

        #region properties

        public static Intent SelectedIntent { get; set; }

        public static MainActivity BaseActivity { get; set; }

        public static float Factor { get; set; }

        public static float Density { get; set; }

        internal static bool IsTablet { get; set; }

        #endregion

        #region methods

        public static bool GetDeviceType(Context context)
		{
			return (context.Resources.Configuration.ScreenLayout
					& ScreenLayout.SizeMask)
					>= ScreenLayout.SizeLarge;
        }

        public override void OnBackPressed()
        {
            Finish();
            base.OnBackPressed();
        }

		protected void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			var intent = new Intent(this, typeof(AllControlsSamplePage));
			SelectedIntent = intent;
            intent.PutExtra("sample", controls[e.Position]);
			StartActivity(intent);
		}

        protected override void OnCreate(Bundle bundle)
		{
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(string.Empty);
			
			float deviceDenstiy = Resources.DisplayMetrics.Density;
            Density = deviceDenstiy;
            Factor = deviceDenstiy / 2.55f;

			base.OnCreate(bundle);

			ParseXML();
			if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop)
			{
				controls.Remove(controls.First(x => x.Title == "PDFViewer"));
			}

			SetContentView(Resource.Layout.HomeScreen);
			ActionBar.Hide();
			listView = FindViewById<GridView>(Resource.Id.List);
			BaseActivity = this;

			listView.Adapter = new HomeScreenAdapter(this, controls);
			listView.ItemClick += OnListItemClick;

			IsTablet = GetDeviceType(this);
            if (IsTablet)
            {
                listView.SetNumColumns(2);
            }
            else
            {
                listView.SetNumColumns(1);
            }

			drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			drawer = FindViewById<LinearLayout>(Resource.Id.left_drawer);
			imageView = FindViewById<ImageView>(Resource.Id.navDrawIcon);
			productpage = FindViewById<LinearLayout>(Resource.Id.productpagelayout);
			documentationPage = FindViewById<LinearLayout>(Resource.Id.documentlayout);
			whatsNewPage = FindViewById<LinearLayout>(Resource.Id.whatsnewlayout);

			var versionText = FindViewById<TextView>(Resource.Id.versionText);
			versionText.Text = versionText.Text + Resources.GetString(Resource.String.version);
			drawer.BringToFront();
			int width = Resources.DisplayMetrics.WidthPixels * 3 / 4;

            if (IsTablet)
            {
                width = int.Parse((Resources.DisplayMetrics.WidthPixels * 0.5f).ToString());
            }

			drawer.LayoutParameters.Width = (int)width;

			imageView.Click += delegate
			{
				drawerLayout.OpenDrawer(GravityCompat.Start);
			};

			productpage.Click += delegate
			{
				GoToUrl("https://www.syncfusion.com/products/xamarin");
			};

			documentationPage.Click += delegate
			{               
				GoToUrl("https://help.syncfusion.com/xamarin-android/introduction/overview");
			};

			whatsNewPage.Click += delegate
			{
				GoToUrl("https://www.syncfusion.com/products/whatsnew/xamarin-android");
			};
		}

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("tab", this.ActionBar.SelectedNavigationIndex);

            base.OnSaveInstanceState(outState);
        }

        private void GoToUrl(string url)
        {
            var intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse(url));
            StartActivity(intent);
        }

        private void ParseXML()
		{
			var xtr = Resources.GetXml(Resource.Xml.samplelist);
			xtr.Read();
            bool featuresamplescompleted = false, controlsamplecompleted = false;
			while (!xtr.EOF && xtr.Name != null)
			{
				var groups = new List<SampleModel>();
				xtr.Read();

                if (xtr.Name == "FeatureSamples" && !xtr.IsStartElement())
                {
                    break;
                }

				xtr.Read();

				while (!featuresamplescompleted)
				{
					if (xtr.Name == "Sample" && xtr.IsStartElement())
					{
						var tc = new SampleModel();
						SetSample(tc, xtr);
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
                        bool grouped = false;
						while (!grouped)
						{
							if (xtr.Name == "Group" && xtr.IsStartElement())
							{
								var group = new ControlModel();

								SetSample(group, xtr);
								xtr.Read();

								var samples = new List<SampleModel>();
								var features = new List<SampleModel>();
								bool samplescompleted = false, featurescompleted = false;
								while (!samplescompleted || !featurescompleted)
								{
									if (xtr.Name == "Samples" && xtr.IsStartElement())
									{
										xtr.Read();
										while (!samplescompleted)
										{
											if (xtr.Name == "Sample" && xtr.IsStartElement())
											{
												var tc = new SampleModel();
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
												var tc = new SampleModel();
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
										grouped = true;
										groups.Add(group);
										xtr.Read();
										featurescompleted = true;
										samplescompleted = true;
										group.Samples = samples;
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

				controls = groups;
			}

			xtr.Close();
		}

        private static void SetSample(SampleModel sample, XmlReader reader)
		{
			reader.MoveToAttribute("Name");
			sample.Name = GetValueFromReader(reader);
			reader.MoveToAttribute("Title");
			sample.Title = GetValueFromReader(reader);
			reader.MoveToAttribute("Description");
			sample.Description = GetValueFromReader(reader);
			reader.MoveToAttribute("Type");
            if (reader.Name == "Type")
            {
                sample.Type = GetValueFromReader(reader);
            }

			reader.MoveToAttribute("ImageId");
            if (reader.Name == "ImageId")
            {
                sample.ImageId = GetValueFromReader(reader);
            }
		}

        private static string GetValueFromReader(XmlReader reader)
        {
            return reader.Value ?? null;
        }

        #endregion
    }
}