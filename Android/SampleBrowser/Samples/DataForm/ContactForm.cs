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
using Syncfusion.Android.DataForm;
using Android.Graphics;
using Android.Views.InputMethods;

namespace SampleBrowser
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public class ContactForm : SamplePage
    {
        private bool refreshLayout = false;
        private RelativeLayout linearLayout;
        private ListView listView;
        private SfDataForm dataForm;
        private bool isReadOnly = true;
        private TextView editButton;
        private ImageButton addButton;
        private TextView contactLabel;
        private Button refreshButton;
        private View dataFormView;
        private Context context;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "contactList")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "_contactList", Justification = "Used Locals")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "titleRelativeLayout", Justification = "Used Locals")]
        public override View GetSampleContent(Context context)
        {
            this.context = context;

            //// Get our button from the layout resource,
            //// and attach an event to it

            var view = LayoutInflater.From(context).Inflate(Resource.Layout.ContactsLayout, null);
            linearLayout = view.FindViewById<RelativeLayout>(Resource.Id.linearLayout);
            listView = linearLayout.FindViewById<ListView>(Resource.Id.listView);
            var contactList = new ListViewGroupingViewModel().ContactsInfo;
            listView.ChoiceMode = ChoiceMode.Single;
            listView.Divider = null;
            listView.DividerHeight = 0;
            listView.ItemClick += OnItemSelect;
            listView.Adapter = new ListViewCustomAdapter(context as Activity);

            dataFormView = LayoutInflater.From(context).Inflate(Resource.Layout.DataFormLayout, null);

            var titleRelativeLayout = dataFormView.FindViewById<RelativeLayout>(Resource.Id.titleRelativeLayout);

            var backButton = dataFormView.FindViewById<TextView>(Resource.Id.back);
            backButton.SetBackgroundColor(Color.Transparent);
            backButton.Click += OnBack;

            contactLabel = dataFormView.FindViewById<TextView>(Resource.Id.label);

            editButton = dataFormView.FindViewById<TextView>(Resource.Id.right);
            editButton.SetBackgroundColor(Color.Transparent);
            editButton.Click += OnEditAndDone;

            // SfDataForm settings
            dataForm = new SfDataForm(context);
            dataForm.ColumnCount = 2;
            dataForm.LayoutManager = new DataFormLayoutManagerExt(dataForm);
            dataForm.AutoGeneratingDataFormItem += DataForm_AutoGeneratingDataFormItem;

            var dataFormLinearLayout = dataFormView.FindViewById<LinearLayout>(Resource.Id.dataFormLinearLayout);
            dataFormLinearLayout.AddView(dataForm);

            refreshButton = dataFormView.FindViewById<Button>(Resource.Id.moreFields);
            refreshButton.Text = "More Fields";
            refreshButton.SetBackgroundColor(Color.Transparent);
            refreshButton.SetTextColor(Color.Blue);
            refreshButton.Click += RefreshButton_Click;

            addButton = linearLayout.FindViewById<ImageButton>(Resource.Id.add);
            addButton.SetImageResource(Resource.Drawable.AddContact);
            addButton.SetBackgroundColor(Color.Transparent);
            addButton.Click += OnAdd;

            linearLayout.AddView(dataFormView, WindowManagerLayoutParams.MatchParent, WindowManagerLayoutParams.MatchParent);

            dataFormView.Visibility = ViewStates.Gone;
            return linearLayout;
        }

        /// <summary>
        /// Raised to refresh the layout to show the fields that were canceled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            refreshLayout = true;
            HideKeyboard(context as Activity);
            dataForm.RefreshLayout();
            refreshButton.Visibility = ViewStates.Gone;
        }

        /// <summary>
        /// Hide key board when refresh layout.
        /// </summary>
        /// <param name="activity"></param>
        public static void HideKeyboard(Activity activity)
        {
            InputMethodManager imm = (InputMethodManager)activity.GetSystemService(Activity.InputMethodService);
            ////Find the currently focused view, so we can grab the correct window token from it.
            View view = activity.CurrentFocus;
            ////If no view currently has focus, create a new one, just so we can grab a window token from it
            if (view == null)
            {
                view = new View(activity);
            }

            imm.HideSoftInputFromWindow(view.WindowToken, 0);
        }

        /// <summary>
        /// Raised to add the item to list view through data form if the form is valid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAdd(object sender, EventArgs e)
        {
            contactLabel.Text = "Add Contact";
            refreshButton.Visibility = ViewStates.Visible;
            dataFormView.Visibility = ViewStates.Visible;

            // Setting data object for DataForm and update the read only property.
            var item = new ContactsInfo();
            if (item.ContactImage == 0)
            {
                item.ContactImage = Resource.Drawable.ContactName;
            }

            refreshLayout = false;
            dataForm.DataObject = item;
            isReadOnly = true;
            UpdateDataFormView(false);

            linearLayout.GetChildAt(0).Visibility = ViewStates.Gone;
            linearLayout.GetChildAt(1).Visibility = ViewStates.Gone;
        }

        /// <summary>
        /// Raised to update the data form view which will update the read only and edit bar caption.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEditAndDone(object sender, EventArgs e)
        {
            UpdateDataFormView();
        }

        /// <summary>
        /// Raise to invisible the data form layout.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBack(object sender, EventArgs e)
        {
            contactLabel.Text = "Edit Contact";
            dataFormView.Visibility = ViewStates.Gone;
            listView.Visibility = ViewStates.Visible;
            addButton.Visibility = ViewStates.Visible;
        }

        /// <summary>
        /// Updates read only property and 
        /// </summary>
        private void UpdateDataFormView(bool commit = true)
        {
            var item = dataForm.DataObject as ContactsInfo;
            var index = (listView.Adapter as ListViewCustomAdapter).ContactList.IndexOf(item);
            if (isReadOnly)
            {
                isReadOnly = false;
                dataForm.IsReadOnly = false;
                editButton.Text = "Done";
            }
            else
            {
                isReadOnly = true;
                if (commit)
                {
                    var isValid = dataForm.Validate();
                    if (!isValid)
                    {
                        return;
                    }

                    dataForm.Commit();
                }

                dataForm.IsReadOnly = true;
                if (index != -1)
                {
                    editButton.Text = "Edit";
                    (listView.Adapter as ListViewCustomAdapter).ContactList[index] = item;
                    (listView.Adapter as ListViewCustomAdapter).NotifyDataSetChanged();
                }
                else
                {
                    dataForm.DataObject = item;
                    (listView.Adapter as ListViewCustomAdapter).ContactList.Add(item);
                    HideKeyboard(this.context as Activity);
                    contactLabel.Text = "Edit Contact";
                    dataFormView.Visibility = ViewStates.Gone;
                    listView.Visibility = ViewStates.Visible;
                    addButton.Visibility = ViewStates.Visible;
                }
            }
        }

        /// <summary>
        /// Raised to set read only property and cancel the some properties.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataForm_AutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {
            if (e.DataFormItem != null)
            {
                if (!refreshLayout)
                {
                    if (e.DataFormItem.Name.Equals("MiddleName") || e.DataFormItem.Name.Equals("LastName"))
                    {
                        e.Cancel = true;
                    }
                }

                if (e.DataFormItem.Name.Equals("ContactNumber"))
                {
                    (e.DataFormItem as DataFormTextItem).InputType = Android.Text.InputTypes.ClassNumber;
                }
                else if (e.DataFormItem.Name.Equals("Email"))
                {
                    (e.DataFormItem as DataFormTextItem).InputType = Android.Text.InputTypes.TextVariationEmailAddress;
                }
            }

            if (e.DataFormGroupItem != null)
            {
                e.DataFormGroupItem.AllowExpandCollapse = false;
            }
        }

        /// <summary>
        /// Event raised to show the data form with selected item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnItemSelect(object sender, AdapterView.ItemClickEventArgs e)
        {
            refreshLayout = false;
            dataFormView.Visibility = ViewStates.Visible;
            refreshButton.Visibility = ViewStates.Visible;

            var item = (listView.Adapter as ListViewCustomAdapter).ContactList[e.Position];
            if (item == dataForm.DataObject)
            {
                dataForm.DataObject = null;
            }

            dataForm.DataObject = item;
            isReadOnly = false;
            UpdateDataFormView(false);

            linearLayout.GetChildAt(0).Visibility = ViewStates.Gone;
            linearLayout.GetChildAt(1).Visibility = ViewStates.Gone;
        }

        public override void Destroy()
        {
            listView.Dispose();
            listView = null;
            dataForm.AutoGeneratingDataFormItem -= DataForm_AutoGeneratingDataFormItem;
            dataForm.Dispose();
            dataForm = null;
        }
    }
}