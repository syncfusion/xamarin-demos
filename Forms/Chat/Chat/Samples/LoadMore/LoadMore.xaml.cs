#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfChat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadMore : SampleView
    {
        private LoadMoreViewModel loadMoreViewModel;        
        public LoadMore()
        {
            InitializeComponent();
        }

        public override void OnDisappearing()
        {
            base.OnDisappearing();
            loadMoreViewModel = this.LoadMoreView.BindingContext as LoadMoreViewModel;
            loadMoreViewModel.IsDisposed = true;
            loadMoreViewModel.AuthorsCollection.Clear();
            loadMoreViewModel.AuthorMessageDataBase.Clear();
            loadMoreViewModel.Messages.Clear();
            this.Behaviors.Clear();
            LoadMoreView.Dispose();
        }

    }
}