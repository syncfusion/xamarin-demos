#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Syncfusion.DataSource;
using System.Collections.Specialized;
using Java.Lang;
using Android.Graphics;
using Syncfusion.DataSource.Extensions;

namespace SampleBrowser
{
    public class ContactsAdapter : BaseAdapter<object>, ISectionIndexer
    {
        private DataSource dataSource;
        private Context context;
        private Dictionary<string, int> alphaIndex;
        private Dictionary<string, int> decendingAlphaIndex;
        private string[] sections;
        private string[] decendingSection;
        private Java.Lang.Object[] sectionsObjects;
        private Java.Lang.Object[] decendingSectionsObjects;

        public ContactsAdapter(DataSource dataSource, Context cntxt) : base()
        {
            this.dataSource = dataSource;
            this.dataSource.DisplayItems.CollectionChanged += DisplayItems_CollectionChanged;
            context = cntxt;
            alphaIndex = new Dictionary<string, int>();
            for (int i = 0; i < this.Count; i++)
            {
                var key = (this[i] as Contacts).ContactName[0].ToString();
                if (!alphaIndex.ContainsKey(key))
                {
                    alphaIndex.Add(key, i);
                }
            }

            sections = new string[alphaIndex.Keys.Count];
            alphaIndex.Keys.CopyTo(sections, 0);
            sectionsObjects = new Java.Lang.Object[sections.Length];
            for (int i = 0; i < sections.Length; i++)
            {
                sectionsObjects[i] = new Java.Lang.String(sections[i]);
            }
        }

        private void DisplayItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset && this.dataSource.SortDescriptors.Count > 0 && this.dataSource.SortDescriptors[0].Direction == Syncfusion.DataSource.ListSortDirection.Descending)
            {
                if (decendingAlphaIndex == null)
                {
                    decendingAlphaIndex = new Dictionary<string, int>();
                    for (int i = 0; i < this.Count; i++)
                    {
                        var key = (this[i] as Contacts).ContactName[0].ToString();
                        if (!decendingAlphaIndex.ContainsKey(key))
                        {
                            decendingAlphaIndex.Add(key, i);
                        }
                    }

                    decendingSection = new string[decendingAlphaIndex.Keys.Count];
                    decendingAlphaIndex.Keys.CopyTo(decendingSection, 0);
                    decendingSectionsObjects = new Java.Lang.Object[decendingSection.Length];
                    for (int i = 0; i < sections.Length; i++)
                    {
                        decendingSectionsObjects[i] = new Java.Lang.String(decendingSection[i]);
                    }
                }
            }

            this.NotifyDataSetChanged();
        }

        public override int Count
        {
            get
            {
                return dataSource.DisplayItems.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override object this[int index]
        {
            get { return this.dataSource.DisplayItems[index]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            var contacttemplate = view as ConctactTemplate;
            if (this[position] is Contacts)
            {
                if (view == null || contacttemplate == null)
                {
                    view = new ConctactTemplate(this.context);
                }

                view.SetBackgroundColor(Color.Transparent);
                (view as ConctactTemplate).UpdateValue(this[position]);
            }
            else if (this[position] is GroupResult)
            {
                GroupResult group = (GroupResult)this[position];
                if (view == null || contacttemplate != null)
                {
                    var textView = new TextView(this.context);
                    textView.SetBackgroundColor(Color.Rgb(217, 217, 217));
                    textView.Gravity = GravityFlags.CenterVertical;
                    textView.TextSize = 18;
                    textView.SetTypeface(Typeface.DefaultBold, TypefaceStyle.Bold);
                    textView.SetPadding((int)(15 * context.Resources.DisplayMetrics.Density), 0, 0, 0);
                    textView.SetMinimumHeight((int)(40 * context.Resources.DisplayMetrics.Density));
                    textView.Text = group.Key.ToString();
                    view = textView;
                }
                else
                {
                    (view as TextView).Text = group.Key.ToString();
                }
            }

            return view;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.dataSource.Dispose();
            this.dataSource = null;
        }

        public Java.Lang.Object[] GetSections()
        {
            if (dataSource.SortDescriptors[0].Direction == Syncfusion.DataSource.ListSortDirection.Ascending)
            {
                return sectionsObjects;
            }
            else
            {
                return decendingSectionsObjects;
            }
        }

        public int GetPositionForSection(int section)
        {
            if (dataSource.SortDescriptors[0].Direction == Syncfusion.DataSource.ListSortDirection.Ascending)
            {
                return alphaIndex[sections[section]];
            }
            else
            {
                return decendingAlphaIndex[decendingSection[section]];
            }
        }

        public int GetSectionForPosition(int position)
        {      // this method isn't called in this example, but code is provided for completeness
            int prevSection = 0;
            for (int i = 0; i < sections.Length; i++)
            {
                if (GetPositionForSection(i) > position)
                {
                    break;
                }

                prevSection = i;
            }

            return prevSection;
        }
    }
}