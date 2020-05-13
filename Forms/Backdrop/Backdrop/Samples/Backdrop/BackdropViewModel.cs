#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XForms.Backdrop;
using Syncfusion.XForms.Buttons;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using System.Reflection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace SampleBrowser.SfBackdrop
{
    [Preserve(AllMembers = true)]
    public class BackdropViewModel : INotifyPropertyChanged
    {
        #region fields

        private ObservableCollection<BackdropModel> frontViewData;

        private double leftcornerRadius;

        private double rightcornerRadius;

        private double currentRadius;

        private bool isBackLayerRevealed;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region public properties

        public ObservableCollection<BackdropModel> FrontViewData
        {
            get { return frontViewData; }
            set
            {
                frontViewData = value;
                RaisePropetyChanged("FrontViewData");
            }
        }

        public double LeftCornerRadius
        {
            get { return leftcornerRadius; }
            set
            {
                leftcornerRadius = value;
                RaisePropetyChanged("LeftCornerRadius");
                if (value > 0)
                {
                    this.currentRadius = value;
                }
            }
        }

        public double RightCornerRadius
        {
            get { return rightcornerRadius; }
            set
            {
                rightcornerRadius = value;
                RaisePropetyChanged("RightCornerRadius");
                if (value > 0)
                {
                    this.currentRadius = value;
                }
            }
        }

        public bool IsBackLayerRevealed
        {
            get { return isBackLayerRevealed; }
            set
            {
                isBackLayerRevealed = value;
                RaisePropetyChanged("IsBackLayerRevealed");
            }
        }



        public ICommand EdgeShapeCommand { get; set; }

        public ICommand CornerTyeCommand { get; set; }

        public ICommand ExpandModeCommand { get; set; }

        public ICommand CornerRadiusCommand { get; set; }

        #endregion

        #region Constructor

        public BackdropViewModel()
        {
            FrontViewData = new ObservableCollection<BackdropModel>()
            {
                new BackdropModel(){ ImageSource = "Brownie.jpg"},
                new BackdropModel(){ ImageSource = "Cupcake.jpg" },
                new BackdropModel(){ ImageSource = "Cake.jpg" },
                new BackdropModel(){ ImageSource = "Icecake.jpg"},
                new BackdropModel(){ ImageSource = "Cookie.jpg"},
                new BackdropModel(){ ImageSource = "Biscuits.jpg"},
            };

            var cornerRadius = 16;
            LeftCornerRadius = cornerRadius;
            RightCornerRadius = cornerRadius;

            EdgeShapeCommand = new Command(EdgeShapeChanged);
            CornerTyeCommand = new Command(CornerTyeChanged);
            ExpandModeCommand = new Command(ExpandModeChanged);
            CornerRadiusCommand = new Command(CornerRadiusChanged);
        }

#endregion

#region private methods

        private void RaisePropetyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void EdgeShapeChanged(object attachedObject)
        {
            var list = attachedObject as List<object>;
            Syncfusion.XForms.Buttons.SelectionChangedEventArgs selectionChangedEventArgs = list[0] as Syncfusion.XForms.Buttons.SelectionChangedEventArgs;
            var frontLayer = (list[1] as SfBackdropPage)?.FrontLayer;
            if (selectionChangedEventArgs == null || frontLayer == null)
            {
                return;
            }

            var selectedIndex = selectionChangedEventArgs.Index;
            if (selectedIndex > -1)
            {
                frontLayer.EdgeShape = selectedIndex == 0 ? EdgeShape.Curve : EdgeShape.Flat;
            }
        }

        private void CornerTyeChanged(object attachedObject)
        {
            var list = attachedObject as List<object>;
            Syncfusion.XForms.Buttons.SelectionChangedEventArgs selectionChangedEventArgs = list[0] as Syncfusion.XForms.Buttons.SelectionChangedEventArgs;
            if (selectionChangedEventArgs == null)
            {
                return;
            }

            var selectedIndex = selectionChangedEventArgs.Index;
            switch (selectedIndex)
            {
                case 0:
                    this.LeftCornerRadius = this.currentRadius;
                    this.RightCornerRadius = this.currentRadius;
                    break;
                case 1:
                    this.LeftCornerRadius = this.currentRadius;
                    this.RightCornerRadius = 0;
                    break;
                case 2:
                    this.LeftCornerRadius = 0;
                    this.RightCornerRadius = this.currentRadius;
                    break;
            }
        }

        private void ExpandModeChanged(object attachedObject)
        {
            var list = attachedObject as List<object>;
            Syncfusion.XForms.Buttons.SelectionChangedEventArgs selectionChangedEventArgs = list[0] as Syncfusion.XForms.Buttons.SelectionChangedEventArgs;
            var backdrop = list[1] as SfBackdropPage;
            if (selectionChangedEventArgs == null || backdrop == null)
            {
                return;
            }

            var selectedIndex = selectionChangedEventArgs.Index;
            switch (selectedIndex)
            {
                case 0:
                    backdrop.BackLayerRevealOption = RevealOption.Auto;
                    break;
                case 1:
                    backdrop.BackLayerRevealOption = RevealOption.Fill;
                    break;
            }
        }

        private void CornerRadiusChanged(object attachedObject)
        {
            ValueChangedEventArgs eventArgs = attachedObject as ValueChangedEventArgs;
            if (eventArgs == null)
            {
                return;
            }

            var value = eventArgs.NewValue;
            if (this.LeftCornerRadius == 0 && this.RightCornerRadius > 0)
            {
                this.RightCornerRadius = value;
            }
            else if (this.LeftCornerRadius > 0 && this.RightCornerRadius == 0)
            {
                this.LeftCornerRadius = value;
            }
            else
            {
                this.LeftCornerRadius = value;
                this.RightCornerRadius = value;
            }
        }
        
#endregion
    }
}