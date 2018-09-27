#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfMaps.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfMaps
{
    [Preserve(AllMembers = true)]
    public partial class DataLabels : SampleView
    {
        public DataLabels()
        {
            InitializeComponent();
            smartLabelPicker.SelectedIndex = 1;
            smartLabelPicker.SelectedIndexChanged += smartLabelPicker_SelectedIndexChanged;
            intersectActionPicker.SelectedIndex = 0;
            intersectActionPicker.SelectedIndexChanged += intersectActionPicker_SelectedIndexChanged;
            var shapeLayer = this.Map.Layers[0] as ShapeFileLayer;
            if (shapeLayer != null)
            {
                shapeLayer.ShapeSelectionChanged += ShapeLayer_ShapeSelectionChanged;
            }
        }

        private void ShapeLayer_ShapeSelectionChanged(object sender, ShapeSelectedEventArgs e)
        {
            AgricultureData data = e.Data as AgricultureData;
            if (data != null)
            {
                Toast.IsVisible = true;
                stateLabel.Text = data.Name;
                Device.StartTimer(new TimeSpan(0, 0, 3), () =>
                {
                    Toast.IsVisible = false;
                    return false;
                });
            }
        }

        private void smartLabelPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (smartLabelPicker.SelectedIndex)
            {
                case 0:
                    layer.DataLabelSettings.SmartLabelMode = IntersectAction.None;
                    break;
                case 1:
                    layer.DataLabelSettings.SmartLabelMode = IntersectAction.Trim;
                    break;
                case 2:
                    layer.DataLabelSettings.SmartLabelMode = IntersectAction.Hide;
                    break;
            }
        }

        private void intersectActionPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (intersectActionPicker.SelectedIndex)
            {
                case 0:
                    layer.DataLabelSettings.IntersectionAction = IntersectAction.None;
                    break;
                case 1:
                    layer.DataLabelSettings.IntersectionAction = IntersectAction.Trim;
                    break;
                case 2:
                    layer.DataLabelSettings.IntersectionAction = IntersectAction.Hide;
                    break;
            }
        }

    }
}


