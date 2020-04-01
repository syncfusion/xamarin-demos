#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfGauge.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfLinearGauge
{
    [Preserve(AllMembers = true)]
    public partial class ScaleAndPointers : SampleView
    {
        public ScaleAndPointers()
        {
            InitializeComponent();
            opposedPosition.SelectedIndex = 1;
            opposedPosition.SelectedIndexChanged += opposedPosition_SelectedIndexChanged;
            rangeCap.SelectedIndex = 1;
            rangeCap.SelectedIndexChanged += RangeCap_SelectedIndexChanged;
            markerShape.SelectedIndex = 0;
            markerShape.SelectedIndexChanged += MarkerShape_SelectedIndexChanged;
        }

        private void MarkerShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if(gauge!=null)
            {
                switch (picker.SelectedIndex)
                {
                    case 0:
                        {
                            (gauge.Scales[0].Pointers[1] as SymbolPointer).MarkerShape = MarkerShape.Triangle;                    
                        }
                        break;
                    case 1:
                        {
                            (gauge.Scales[0].Pointers[1] as SymbolPointer).MarkerShape = MarkerShape.InvertedTriangle;
                        }
                        break;
                    case 2:
                        {
                            (gauge.Scales[0].Pointers[1] as SymbolPointer).MarkerShape = MarkerShape.Circle;
                        }
                        break;
                    case 3:
                        {
                            (gauge.Scales[0].Pointers[1] as SymbolPointer).MarkerShape = MarkerShape.Diamond;
                        }
                        break;
                    case 4:
                        {
                            (gauge.Scales[0].Pointers[1] as SymbolPointer).MarkerShape = MarkerShape.Rectangle;
                        }
                        break;
                    case 5:
                        {
                            (gauge.Scales[0].Pointers[1] as SymbolPointer).MarkerShape = MarkerShape.Image;
                            
                        }
                        break;
                }
            }
        
        }

        private void RangeCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if(gauge != null)
            {
                switch (picker.SelectedIndex)
                {
                    case 0:
                        {
                            gauge.Scales[0].CornerRadiusType = Syncfusion.SfGauge.XForms.CornerRadiusType.Start;
                            (gauge.Scales[0].Pointers[0] as BarPointer).CornerRadiusType = CornerRadiusType.Start;
                        }  
                        break;
                    case 1:
                        {
                            gauge.Scales[0].CornerRadiusType = Syncfusion.SfGauge.XForms.CornerRadiusType.End;
                            (gauge.Scales[0].Pointers[0] as BarPointer).CornerRadiusType = CornerRadiusType.End;
                        }
                        break;
                    case 2:
                        {
                            gauge.Scales[0].CornerRadiusType = CornerRadiusType.Both;
                            (gauge.Scales[0].Pointers[0] as BarPointer).CornerRadiusType = CornerRadiusType.Both;
                        }
                        break;
                    case 3:
                        {
                            gauge.Scales[0].CornerRadiusType = CornerRadiusType.None;
                            (gauge.Scales[0].Pointers[0] as BarPointer).CornerRadiusType = CornerRadiusType.None;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void opposedPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if (gauge != null)
            {
                switch (picker.SelectedIndex)
                {
                    case 0:
                        gauge.Scales[0].OpposedPosition = true;
                        break;
                    case 1:
                        gauge.Scales[0].OpposedPosition = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}