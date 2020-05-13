#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.TreeView.Engine;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XFSfTreeView = Syncfusion.XForms.TreeView.SfTreeView;

namespace SampleBrowser.SfTreeView
{
    #region AutoFitContentBehavior

    [Preserve(AllMembers = true)]
    public class AutoFitTreeViewBehavior : Behavior<Syncfusion.XForms.TreeView.SfTreeView>
    {
        private XFSfTreeView TreeView;
        #region Overrides
        protected override void OnAttachedTo(XFSfTreeView bindable)
        {          
            bindable.Loaded += Bindable_Loaded;
            bindable.QueryNodeSize += TreeView_QueryNodeSize;
            base.OnAttachedTo(bindable);
        }

        private void Bindable_Loaded(object sender, Syncfusion.XForms.TreeView.TreeViewLoadedEventArgs e)
        {
            this.TreeView = sender as XFSfTreeView;
            this.WireEvents();
        }

        private void ChatInfo_ConversationAdded(object sender, ChatEventArgs e)
        {
            TreeView.BringIntoView(e.Conversation, true, true, Syncfusion.XForms.TreeView.ScrollToPosition.MakeVisible);
        }

        private void WireEvents()
        {
            var viewModel = this.TreeView.BindingContext as ChatInfo;
            viewModel.ConversationAdded += ChatInfo_ConversationAdded;
            viewModel.ReplyTapped += Conversation_ReplyTapped;
            viewModel.ReplyAdded += ChatInfo_ReplyAdded;
        }

        private void UnWireEvents()
        {
            var viewModel = this.TreeView.BindingContext as ChatInfo;
            viewModel.ConversationAdded -= ChatInfo_ConversationAdded;
            viewModel.ReplyTapped -= Conversation_ReplyTapped;
            viewModel.ReplyAdded -= ChatInfo_ReplyAdded;
        }

        private void TreeView_QueryNodeSize(object sender, Syncfusion.XForms.TreeView.QueryNodeSizeEventArgs e)
        {
            e.Height = e.GetActualNodeHeight();
            e.Handled = true;
        }

        private void ChatInfo_ReplyAdded(object sender, ChatEventArgs e)
        {
            this.TreeView.BringIntoView(e.Conversation.Replies[e.Conversation.Replies.Count - 1], true, true, Syncfusion.XForms.TreeView.ScrollToPosition.MakeVisible);
        }

        private void Conversation_ReplyTapped(object sender, ReplyEditEventArgs e)
        {
            this.TreeView.BringIntoView(e.Content, true, true, Syncfusion.XForms.TreeView.ScrollToPosition.MakeVisible);
        }
        
        protected override void OnDetachingFrom(XFSfTreeView bindable)
        {
            bindable.Loaded -= Bindable_Loaded;
            bindable.QueryNodeSize -= TreeView_QueryNodeSize;
            this.UnWireEvents();
            base.OnDetachingFrom(bindable);
        }

        #endregion
    }

    #endregion

    #region AutoFitContentTriggers
    public class FocusTriggerAction : TriggerAction<Entry>
    {
        protected override async void Invoke(Entry entry)
        {
            await Task.Delay(100);
            entry.Focus();
        }
    }
    #endregion
}