#region Copyright
// <copyright file="FloatingActionButtonImage.cs" company="Syncfusion"> 
//  Copyright (c) Syncfusion Inc. 2001 - 2020. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace SampleBrowser.SfDataForm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using SampleBrowser.Core;
    using Xamarin.Forms;

    /// <summary>
    /// View that holds floating action button image
    /// </summary>
    public class FloatingActionButtonImage : Image
    {
        /// <summary>
        /// Command property is a bindable property to allow the property binding on BindableObject.
        /// </summary>
        public static readonly BindableProperty CommandProperty = 
            BindableProperty.Create("Command", typeof(ICommand), typeof(FloatingActionButtonImage), null);

        /// <summary>
        /// Command parameter property is a bindable property to allow the property binding on BindableObject.
        /// </summary>
        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(FloatingActionButtonImage), null);

        /// <summary>
        /// Initializes a new instance of the <see cref="FloatingActionButtonImage"/> class.
        /// </summary>
        public FloatingActionButtonImage()
        {
            this.Initialize();
        }

        /// <summary>
        /// Represents the method that will handle item tap.
        /// </summary>
        public event EventHandler ItemTapped = (e, a) => { };

        /// <summary>
        /// Gets or sets the command property value of the command to execute an action.
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { this.SetValue(CommandProperty, value); }
        }

        /// <summary>
        /// Gets or sets the parameter value of the command.
        /// </summary>
        public object CommandParameter
        {
            get { return this.GetValue(CommandParameterProperty); }
            set { this.SetValue(CommandParameterProperty, value); }
        }

        /// <summary>
        /// Gets the value of the command after transition.
        /// </summary>
        private ICommand TransitionCommand
        {
            get
            {
                return new Command(async () =>
                {
                    AnchorX = 0.48;
                    AnchorY = 0.48;
                    await this.ScaleTo(0.8, 50, Easing.Linear);
                    await Task.Delay(100);
                    await this.ScaleTo(1, 50, Easing.Linear);
                    Command?.Execute(CommandParameter);

                    ItemTapped(this, EventArgs.Empty);
                });
            }
        }

        /// <summary>
        /// Initializes and sets the initial value for the floating action button image.
        /// </summary>
        public void Initialize()
        {
            this.VerticalOptions = LayoutOptions.EndAndExpand;
            this.WidthRequest = 40;
            this.HeightRequest = 40;
            this.Source = "Add.png";
            this.HorizontalOptions = LayoutOptions.EndAndExpand;
            GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = this.TransitionCommand
            });
        }
    }
}
