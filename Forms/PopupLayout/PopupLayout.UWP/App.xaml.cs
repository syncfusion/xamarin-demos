#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "App.xaml.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPopupLayout.UWP
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using Core.UWP;
    using Syncfusion.ListView.XForms.UWP;
    using Syncfusion.SfDataGrid.XForms.UWP;
    using Syncfusion.SfRotator.XForms.UWP;
    using Syncfusion.XForms.UWP.PopupLayout;
    using Syncfusion.XForms.UWP.TextInputLayout;
    using Windows.ApplicationModel;
    using Windows.ApplicationModel.Activation;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Navigation;
    using Xamarin.Forms;
    using Application = Windows.UI.Xaml.Application;
    using Frame = Windows.UI.Xaml.Controls.Frame;

    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1400:AccessModifierMustBeDeclared", Justification = "Reviewed.")]
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the App class.
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        ///  will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = false;
            }
#endif

            var rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += this.OnNavigationFailed;

                List<Assembly> assembliesToInclude = new List<Assembly>();
                assembliesToInclude.Add(typeof(SfPopupLayoutRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(SfDataGridRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(SfListViewRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(SfRotatorRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(SfTextInputLayoutRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(SampleBrowserUWP).GetTypeInfo().Assembly);
                Forms.Init(e, assembliesToInclude);

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    ////TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }

            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        ///     Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        ///     Invoked when application execution is being suspended.  Application state is saved
        ///     without knowing whether the application will be terminated or resumed with the contents
        ///     of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            ////TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}