#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CoreGraphics;
using Foundation;
using Syncfusion.SfDiagram.iOS;
using UIKit;

namespace SampleBrowser
{
    public class Connectors : SampleView
    {
        SfDiagram diagram = new SfDiagram();
        UIPickerView selectionPicker1;
        UILabel connectorStyle;
        UIButton connectorStyleButton = new UIButton();
        UILabel connectorSize;
        UIButton doneButton = new UIButton();
        internal UIView HeaderBar = new UIView();
        UIButton straight;
        UIButton curve;
        UIButton ortho;
        UIButton plus;
        UIButton minus;
        UILabel sizeindicator;
        UIImageView plusimg;
        UIImageView minusimg;
        DiagramView diagramView = new DiagramView();
        public Connectors()
        {
            HeaderBar.BackgroundColor = UIColor.FromRGB(245, 245, 245);
            var label = new UILabel();
            label.Text = "Connector Types: ";
            label.TextColor = UIColor.Black;
            label.BackgroundColor = UIColor.Clear;
            label.TextAlignment = UITextAlignment.Center;
            string deviceType = UIDevice.CurrentDevice.Model;
            int offsetX;
            int space;
            if (deviceType == "iPhone" || deviceType == "iPod touch")
            {
                offsetX = 150;
                space = 10;
            }
            else
            {
                offsetX = 180;
                space = 40;

            }

            label.Frame = new CGRect(0, 0, offsetX, 60);

            HeaderBar.AddSubview(label);
            offsetX += space;
            straight = AddButton(offsetX, "Images/Diagram/CSStraight.png");
            straight.TouchUpInside += Straight_TouchUpInside;
            HeaderBar.AddSubview(straight);

            offsetX += space + 40;
            curve = AddButton(offsetX, "Images/Diagram/CSCurve.png");
            curve.TouchUpInside += Curve_TouchUpInside; ;
            HeaderBar.AddSubview(curve);

            offsetX += space + 40;
            ortho = AddButton(offsetX, "Images/Diagram/CSOrtho.png");
            ortho.TouchUpInside += Ortho_TouchUpInside;
            ortho.BackgroundColor = UIColor.FromRGB(30, 144, 255);
            HeaderBar.AddSubview(ortho);

            selectionPicker1 = new UIPickerView();
            this.OptionView = new UIView();

            PickerModel model = new PickerModel(verticalOrientationlist);
            selectionPicker1.Model = model;

            connectorStyle = new UILabel();
            connectorStyle.Text = "Connector Style";
            connectorStyle.TextColor = UIColor.Black;
            connectorStyle.TextAlignment = UITextAlignment.Left;

            connectorSize = new UILabel();
            connectorSize.Text = "Connector Size";
            connectorSize.TextColor = UIColor.Black;
            connectorSize.TextAlignment = UITextAlignment.Left;

            //Represent the vertical button
            connectorStyleButton = new UIButton();
            connectorStyleButton.SetTitle("Default", UIControlState.Normal);
            connectorStyleButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            connectorStyleButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
            connectorStyleButton.Layer.CornerRadius = 8;
            connectorStyleButton.Layer.BorderWidth = 2;
            connectorStyleButton.TouchUpInside += ShowPicker1;
            connectorStyleButton.BackgroundColor = UIColor.LightGray;
            connectorStyleButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

            plus = new UIButton();
            plus.BackgroundColor = UIColor.White;
            plus.Layer.CornerRadius = 8;
            plus.Layer.BorderWidth = 0.5f;
            plus.TouchUpInside += Plus_TouchUpInside;
            plusimg = new UIImageView();
            plusimg.Image = UIImage.FromBundle("Images/Diagram/CSplus.png");
            plus.AddSubview(plusimg);

            minus = new UIButton();
            minus.BackgroundColor = UIColor.White;
            minus.Layer.CornerRadius = 8;
            minus.Layer.BorderWidth = 0.5f;
            minus.TouchUpInside += Minus_TouchUpInside;
            minusimg = new UIImageView();
            minusimg.Image = UIImage.FromBundle("Images/Diagram/CSsub.png");
            minus.AddSubview(minusimg);

            sizeindicator = new UILabel();
            sizeindicator.Text = width.ToString();
            sizeindicator.BackgroundColor = UIColor.Clear;
            sizeindicator.TextColor = UIColor.Black;
            sizeindicator.TextAlignment = UITextAlignment.Center;

            //Represent the button
            doneButton.SetTitle("Done\t", UIControlState.Normal);
            doneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            doneButton.TouchUpInside += HidePicker;
            doneButton.Hidden = true;
            doneButton.BackgroundColor = UIColor.FromRGB(246, 246, 246);
            selectionPicker1.ShowSelectionIndicator = true;
            selectionPicker1.Hidden = true;

            ObservableCollection<EmployeeDetail> employees = new ObservableCollection<EmployeeDetail>();
            employees.Add(new EmployeeDetail() { Name = "Elizabeth", EmpId = "1", ParentId = "", Designation = "CEO" });
            employees.Add(new EmployeeDetail() { Name = "Christina", EmpId = "2", ParentId = "1", Designation = "Manager" });
            employees.Add(new EmployeeDetail() { Name = "Yang", EmpId = "3", ParentId = "1", Designation = "Manager" });
            employees.Add(new EmployeeDetail() { Name = "Yoshi", EmpId = "4", ParentId = "2", Designation = "Team Lead" });
            employees.Add(new EmployeeDetail() { Name = "Yoshi", EmpId = "5", ParentId = "2", Designation = "Co-ordinator" });
            employees.Add(new EmployeeDetail() { Name = "Philip", EmpId = "6", ParentId = "4", Designation = "Developer" });
            employees.Add(new EmployeeDetail() { Name = "Philip", EmpId = "7", ParentId = "4", Designation = "Testing Engineer" });
            employees.Add(new EmployeeDetail() { Name = "Roland", EmpId = "8", ParentId = "3", Designation = "Team Lead" });
            employees.Add(new EmployeeDetail() { Name = "Yoshi", EmpId = "9", ParentId = "3", Designation = "Co-ordinator" });
            employees.Add(new EmployeeDetail() { Name = "Yuonne", EmpId = "10", ParentId = "8", Designation = "Developer" });
            employees.Add(new EmployeeDetail() { Name = "Philip", EmpId = "10", ParentId = "8", Designation = "Testing Engineer" });
            //Initializes the DataSourceSettings
            diagram.DataSourceSettings = new DataSourceSettings() { DataSource = employees, Id = "EmpId", ParentId = "ParentId" };
            //Initializes the Layout
            DirectedTreeLayout treelayout = new DirectedTreeLayout() { HorizontalSpacing = 80, VerticalSpacing = 50, TreeOrientation = TreeOrientation.TopToBottom };
            diagram.LayoutManager = new LayoutManager() { Layout = treelayout };
            diagram.IsReadOnly = true;
            diagram.BeginNodeRender += Diagram_BeginNodeRender;
            diagram.Loaded += Diagram_Loaded;
            HeaderBar.Frame = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, 60);
            diagramView.Frame = new CGRect(0, 70, UIScreen.MainScreen.Bounds.Width + 40, UIScreen.MainScreen.Bounds.Height - HeaderBar.Frame.Height);
            diagramView.BackgroundColor = UIColor.Clear;
            diagram.Layer.BorderColor = UIColor.Clear.CGColor;
            diagram.Layer.BorderWidth = 0;
            diagramView.AddSubview(diagram);
            diagramView.MarginTop = HeaderBar.Frame.Height;
            this.AddSubview(diagramView);
            this.AddSubview(HeaderBar);
            model.PickerChanged += SelectedIndexChanged;
            for (int i = 0; i < diagram.Connectors.Count; i++)
            {
                diagram.Connectors[i].TargetDecoratorType = DecoratorType.None;
            }
            foreach (var view in this.Subviews)
            {
                connectorStyle.Frame = new CGRect(this.Frame.X + 10, 0, PopoverSize.Width - 20, 30);
                connectorStyleButton.Frame = new CGRect(this.Frame.X + 10, 40, PopoverSize.Width - 20, 30);
                connectorSize.Frame = new CGRect(this.Frame.X + 10, 80, PopoverSize.Width - 20, 30);
                plus.Frame = new CGRect(this.Frame.X + 60, 120, 30, 30);
                plusimg.Frame = new CGRect(0, 0, 30, 30);
                minus.Frame = new CGRect(this.Frame.X + 160, 120, 30, 30);
                minusimg.Frame = new CGRect(0, 0, 30, 30);
                sizeindicator.Frame = new CGRect(this.Frame.X + 110, 120, 30, 30);
                selectionPicker1.Frame = new CGRect(0, PopoverSize.Height / 2, PopoverSize.Width, PopoverSize.Height / 3);
                doneButton.Frame = new CGRect(0, PopoverSize.Height / 2.5, PopoverSize.Width, 40);
            }
            optionView();
            diagram.ContextMenuSettings.Visibility = false;
        }

        int width = 2;

        void Plus_TouchUpInside(object sender, EventArgs e)
        {
            if (width < 5)
            {
                width = (int)diagram.Connectors[0].Style.StrokeWidth + 1;
                sizeindicator.Text = width.ToString();
                for (int i = 0; i < diagram.Connectors.Count; i++)
                    diagram.Connectors[i].Style.StrokeWidth += 1;
            }
        }

        void Minus_TouchUpInside(object sender, EventArgs e)
        {
            if (width > 1)
            {
                width = (int)diagram.Connectors[0].Style.StrokeWidth - 1;
                sizeindicator.Text = width.ToString();
                for (int i = 0; i < diagram.Connectors.Count; i++)
                    diagram.Connectors[i].Style.StrokeWidth -= 1;
            }
        }

        void HidePicker(object sender, EventArgs e)
        {
            doneButton.Hidden = true;
            selectionPicker1.Hidden = true;
        }

        private void SelectedIndexChanged(object sender, PickerChangedEventArgs e)
        {
            //this.selectedType = selectedorientation + e.SelectedValue;
            if (e.SelectedValue == "Default")
            {
                for (int i = 0; i < diagram.Connectors.Count; i++)
                    diagram.Connectors[i].Style.StrokeStyle = StrokeStyle.Default;
            }
            else if (e.SelectedValue == "Dashed")
            {
                for (int i = 0; i < diagram.Connectors.Count; i++)
                    diagram.Connectors[i].Style.StrokeStyle = StrokeStyle.Dashed;
            }
            else if (e.SelectedValue == "Dotted")
            {
                for (int i = 0; i < diagram.Connectors.Count; i++)
                    diagram.Connectors[i].Style.StrokeStyle = StrokeStyle.Dotted;
            }
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            diagramView.LayoutSubviews();
            diagram.LayoutSubviews();
            HeaderBar.Frame = new CGRect(0, 0, Frame.Width, 60);

        }
        public void optionView()
        {
            this.OptionView.AddSubview(connectorStyle);
            this.OptionView.AddSubview(connectorStyleButton);
            this.OptionView.AddSubview(connectorSize);
            this.OptionView.AddSubview(plus);
            this.OptionView.AddSubview(minus);
            this.OptionView.AddSubview(sizeindicator);
            this.OptionView.AddSubview(selectionPicker1);
            this.OptionView.AddSubview(doneButton);
        }
        private void ShowPicker1(object sender, EventArgs e)
        {
            (sender as UIButton).BackgroundColor = UIColor.LightGray;

            doneButton.Hidden = false;
            selectionPicker1.Hidden = false;
        }

        private UIButton AddButton(int v1, string v2)
        {
            UIButton straight = new UIButton();
            straight.BackgroundColor = UIColor.White;
            straight.TouchUpInside += Straight_TouchUpInside;
            straight.Frame = new CGRect(v1, 10, 40, 40);
            straight.Layer.CornerRadius = 20;
            straight.Layer.BorderColor = UIColor.Black.CGColor;
            straight.Layer.BorderWidth = 1.5f;
            UIImageView img = new UIImageView();
            img.Frame = new CGRect(10, 10, 20, 20);
            img.BackgroundColor = UIColor.Clear;
            img.Image = UIImage.FromBundle(v2);
            straight.AddSubview(img);
            return straight;
        }

        private readonly IList<string> verticalOrientationlist = new List<string>
        {
            "Default",
            "Dashed",
            "Dotted"
        };

        private void Diagram_Loaded(object sender)
        {
            diagram.BringToView(diagram.Nodes[0]);
        }

        private void Diagram_BeginNodeRender(object sender, BeginNodeRenderEventArgs args)
        {
            var node = args.Item;
            node.Width = 144;
            node.Height = 60;
            node.ShapeType = ShapeType.RoundedRectangle;
            node.Style.StrokeWidth = 0;
            if ((node.Content as EmployeeDetail).Designation == "Manager")
                node.Style.Brush = new SolidBrush(UIColor.FromRGB(23, 132, 206));
            else if ((node.Content as EmployeeDetail).Designation == "CEO")
            {
                node.Style.Brush = new SolidBrush(UIColor.FromRGB(201, 32, 61));
            }
            else if ((node.Content as EmployeeDetail).Designation == "Team Lead" || (node.Content as EmployeeDetail).Designation == "Co-ordinator")
                node.Style.Brush = new SolidBrush(UIColor.FromRGB(4, 142, 135));
            else
                node.Style.Brush = new SolidBrush(UIColor.FromRGB(206, 98, 9));

            node.Annotations.Add(new Annotation() { Content = (node.Content as EmployeeDetail).Designation, FontSize = 15, TextBrush = new SolidBrush(UIColor.White) });
        }

        void Straight_TouchUpInside(object sender, EventArgs e)
        {
            (sender as UIButton).BackgroundColor = UIColor.FromRGB(30, 144, 255);
            ((sender as UIButton).Subviews[0] as UIImageView).Image = UIImage.FromBundle("Images/Diagram/CSStraight1");
            for (int i = 0; i < diagram.Connectors.Count; i++)
                diagram.Connectors[i].SegmentType = SegmentType.StraightSegment;
            curve.BackgroundColor = UIColor.White;
            ortho.BackgroundColor = UIColor.White;
            (curve.Subviews[0] as UIImageView).Image = UIImage.FromBundle("Images/Diagram/CSCurve");
            (ortho.Subviews[0] as UIImageView).Image = UIImage.FromBundle("Images/Diagram/CSOrtho");
        }

        void Ortho_TouchUpInside(object sender, EventArgs e)
        {
            (sender as UIButton).BackgroundColor = UIColor.FromRGB(30, 144, 255);
            ((sender as UIButton).Subviews[0] as UIImageView).Image = UIImage.FromBundle("Images/Diagram/CSOrtho1");
            for (int i = 0; i < diagram.Connectors.Count; i++)
                diagram.Connectors[i].SegmentType = SegmentType.OrthoSegment;
            curve.BackgroundColor = UIColor.White;
            (curve.Subviews[0] as UIImageView).Image = UIImage.FromBundle("Images/Diagram/CSCurve");
            straight.BackgroundColor = UIColor.White;
            (straight.Subviews[0] as UIImageView).Image = UIImage.FromBundle("Images/Diagram/CSStraight");
        }

        void Curve_TouchUpInside(object sender, EventArgs e)
        {
            (sender as UIButton).BackgroundColor = UIColor.FromRGB(30, 144, 255);
            ((sender as UIButton).Subviews[0] as UIImageView).Image = UIImage.FromBundle("Images/Diagram/CSCurve1");
            for (int i = 0; i < diagram.Connectors.Count; i++)
                diagram.Connectors[i].SegmentType = SegmentType.CurveSegment;
            straight.BackgroundColor = UIColor.White;
            ortho.BackgroundColor = UIColor.White;
            (ortho.Subviews[0] as UIImageView).Image = UIImage.FromBundle("Images/Diagram/CSOrtho");
            (straight.Subviews[0] as UIImageView).Image = UIImage.FromBundle("Images/Diagram/CSStraight");
        }
    }
    //Connector_Employee Business Object
    [Preserve(AllMembers = true)]
    public class EmployeeDetail
    {
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string EmpId { get; set; }
    }
    //Connector_Employee Collection
    public class Employees : System.Collections.ObjectModel.ObservableCollection<EmployeeDetail>
    {

    }
    public class DiagramView : UIView
    {
        internal nfloat MarginTop;
        public DiagramView()
        {

        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            this.Frame = new CGRect(Frame.X, Frame.Y, (float)this.Superview.Frame.Width,
                                    (float)this.Superview.Frame.Height - MarginTop);
        }
    }
}