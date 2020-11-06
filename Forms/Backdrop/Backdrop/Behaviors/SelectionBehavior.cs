#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XForms.Backdrop;
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfBackdrop
{
    [Preserve(AllMembers = true)]
    public class SelectionBehavior : Behavior<Syncfusion.XForms.Buttons.SfSegmentedControl>
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(SelectionBehavior), null);

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(SelectionBehavior), null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public Syncfusion.XForms.Buttons.SfSegmentedControl AssociatedObject { get; private set; }

        protected override void OnAttachedTo(Syncfusion.XForms.Buttons.SfSegmentedControl bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;
            bindable.BindingContextChanged += OnBindingContextChanged;
            bindable.SelectionChanged += SelectionChanged;
        }

        protected override void OnDetachingFrom(Syncfusion.XForms.Buttons.SfSegmentedControl bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= OnBindingContextChanged;
            bindable.SelectionChanged -= SelectionChanged;
            AssociatedObject = null;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }

        private void SelectionChanged(object sender, Syncfusion.XForms.Buttons.SelectionChangedEventArgs e)
        {
            if (Command == null)
            {
                return;
            }

            var paramerter = new List<object> { e, CommandParameter };
            if (Command.CanExecute(paramerter))
            {
                Command.Execute(paramerter);
            }

        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }
    }
}
