#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "PopupThemeBehavior.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPopupLayout
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Core;
    using Syncfusion.XForms.Themes;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    /// Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the PopupThemeBehavior samples
    /// </summary>
    public class PopupThemeBehavior : Behavior<SampleView>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Syncfusion.XForms.PopupLayout.SfPopupLayout popupLayout;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private GettingStartedViewModel viewModel;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Button alertWithTitle;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Color contentBackGroundColor;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Color contentTextColor;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Color headerTextColor;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">SampleView type parameter named as bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            base.OnAttachedTo(bindAble);

            this.popupLayout = bindAble.FindByName<Syncfusion.XForms.PopupLayout.SfPopupLayout>("popupLayout");
            this.viewModel = new GettingStartedViewModel();

            this.alertWithTitle = bindAble.FindByName<Button>("AlertTitle");
            this.alertWithTitle.Clicked += this.AlertWithTitle_Clicked;

            this.contentBackGroundColor = Color.White;
            this.contentTextColor = Color.Gray;
            this.headerTextColor = Color.Black;

            bindAble.BindingContext = this.viewModel;
        }       

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">SampleView type parameter named as bindAble</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            this.popupLayout = null;
            this.alertWithTitle.Clicked -= this.AlertWithTitle_Clicked;
            base.OnDetachingFrom(bindAble);
        }

        /// <summary>
        /// Fired when <see cref="Button"/> has been clicked.
        /// </summary>
        /// <param name="sender">A <see cref="Button"/>.</param>
        /// <param name="e">A <see cref="Button"/> event properties.</param>
        private void AlertWithTitle_Clicked(object sender, EventArgs e)
        {
            ICollection<ResourceDictionary> mergedDictionaries = null;
#if COMMONSB
            var parent = ((((sender as Button).Parent as StackLayout).Parent as ScrollView).Parent as Syncfusion.XForms.PopupLayout.SfPopupLayout).Parent;
            while (parent != null)
            {
                if (parent is ThemesPage)
                {
                    mergedDictionaries = (parent as Page).Resources.MergedDictionaries;
                    break;
                }
                parent = parent.Parent;
            }
            parent = null;
#else
            mergedDictionaries = (((((sender as Button).Parent as StackLayout).Parent as ScrollView).Parent as Syncfusion.XForms.PopupLayout.SfPopupLayout).Parent as SampleView).Resources.MergedDictionaries;
#endif
            // Fix for XAMARIN-35079 Theming does not apply properly when change dark to light in Popup sample Browser
            var darkTheme = (mergedDictionaries != null) ? mergedDictionaries.OfType<DarkTheme>().FirstOrDefault() : null;
            var lightTheme = (mergedDictionaries != null) ? mergedDictionaries.OfType<LightTheme>().FirstOrDefault() : null;
            var darkThemeIndex = mergedDictionaries.IndexOf(darkTheme);
            var lightThemeIndex = mergedDictionaries.IndexOf(lightTheme);

            if (darkTheme != null && darkThemeIndex > lightThemeIndex) 
            {
                this.popupLayout.PopupView.PopupStyle.BorderColor = Color.Transparent;
                this.popupLayout.PopupView.BackgroundColor = Color.FromHex("#232323");
                this.contentBackGroundColor = Color.FromHex("#232323");
                this.contentTextColor = Color.FromHex("#707070");
                this.headerTextColor = Color.FromHex("#D1D1D1");
            }
            else
            {
                this.popupLayout.PopupView.PopupStyle.BorderColor = Color.Transparent;
                this.popupLayout.PopupView.BackgroundColor = Color.White;
                this.contentBackGroundColor = Color.White;
                this.contentTextColor = Color.FromHex("#414141");
                this.headerTextColor = Color.FromHex("#414141");
            }

            this.popupLayout.PopupView.AcceptButtonText = "AGREE";
            this.popupLayout.PopupView.DeclineButtonText = "DECLINE";
            this.popupLayout.PopupView.AppearanceMode = Syncfusion.XForms.PopupLayout.AppearanceMode.TwoButton;
            this.popupLayout.PopupView.HeaderHeight = 70;
            this.popupLayout.PopupView.FooterHeight = 70;

            //// HeaderTemplate
            var alertWithTitleHeader = new DataTemplate(() =>
            {
                var headerStack = new StackLayout();
                if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                {
                    headerStack.Padding = new Thickness(18, 17, 20, 5);
                }
                else
                {
                    headerStack.Padding = new Thickness(19, 20, 20, 5);
                }

                var label = new Label()
                {
                    LineBreakMode = LineBreakMode.WordWrap,
                    Text = "Use Google's location service?",
                    FontSize = 18,
                    HorizontalOptions = LayoutOptions.Center,
                    TextColor = headerTextColor,
                    FontAttributes = FontAttributes.Bold
                };
                headerStack.Children.Add(label);
                return headerStack;
            });

            //// ContentTemplate
            var alertWithTitleContent = new DataTemplate(() =>
            {
                var ContentStack = new StackLayout();
                ContentStack.Orientation = StackOrientation.Horizontal;
                if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                {
                    ContentStack.Padding = new Thickness(20, 0, 5, 0);
                }
                else
                {
                    ContentStack.Padding = new Thickness(20, 5, 5, 8);
                }

                var label = new Label()
                {
                    Text = "Let Google help apps determine location. This means sending anonymous location date to Google, even when no apps are running.",
                    FontSize = 16.5,
                    BackgroundColor = contentBackGroundColor,
                    TextColor = contentTextColor
                };
                ContentStack.Children.Add(label);
                return ContentStack;
            });

            this.popupLayout.PopupView.HeaderTemplate = alertWithTitleHeader;
            this.popupLayout.PopupView.ContentTemplate = alertWithTitleContent;
            this.popupLayout.Show();
            mergedDictionaries = null;
        }
    }
}
