#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Syncfusion.SfDiagram.XForms;
using SampleBrowser.Core;
using System.Collections.ObjectModel;

namespace SampleBrowser.SfDiagram
{
    public partial class Connectors : SampleView
    {
        private float size = 1;
        private Node RootNode;

        public Connectors()
        {
            InitializeComponent();
            diagram.ContextMenuSettings.Visibility = false;
            diagram.IsReadOnly = true;
            if (Device.RuntimePlatform == Device.Android)
                Xamarin.Forms.DependencyService.Get<IText>().GenerateFactor();
            if (Device.RuntimePlatform == Device.UWP)
            {
                diagram.PageSettings.PageWidth = 1600;
                diagram.BackgroundColor = Color.White;
            }
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
            employees.Add(new Employee() { Name = "Elizabeth", EmpId = "1", ParentId = "", Designation = "CEO" });
            employees.Add(new Employee() { Name = "Christina", EmpId = "2", ParentId = "1", Designation = "Manager" });
            employees.Add(new Employee() { Name = "Yang", EmpId = "3", ParentId = "1", Designation = "Manager" });
            employees.Add(new Employee() { Name = "Yoshi", EmpId = "4", ParentId = "2", Designation = "Team Lead" });
            employees.Add(new Employee() { Name = "Yoshi", EmpId = "5", ParentId = "2", Designation = "Co-ordinator" });
            employees.Add(new Employee() { Name = "Philip", EmpId = "6", ParentId = "4", Designation = "Developer" });
            employees.Add(new Employee() { Name = "Philip", EmpId = "7", ParentId = "4", Designation = "Testing Engineer" });
            employees.Add(new Employee() { Name = "Roland", EmpId = "8", ParentId = "3", Designation = "Team Lead" });
            employees.Add(new Employee() { Name = "Yoshi", EmpId = "9", ParentId = "3", Designation = "Co-ordinator" });
            employees.Add(new Employee() { Name = "Yuonne", EmpId = "10", ParentId = "8", Designation = "Developer" });
            employees.Add(new Employee() { Name = "Philip", EmpId = "10", ParentId = "8", Designation = "Testing Engineer" });
            //Initializes the DataSourceSettings
            diagram.DataSourceSettings = new DataSourceSettings() { DataSource = employees, Id = "EmpId", ParentId = "ParentId" };
            //Initializes the Layout
            DirectedTreeLayout treelayout = new DirectedTreeLayout() { HorizontalSpacing = 80, VerticalSpacing = 50 * DiagramUtility.currentDensity, TreeOrientation = TreeOrientation.TopToBottom };
            diagram.LayoutManager = new LayoutManager() { Layout = treelayout };
            for (int i = 0; i < diagram.Connectors.Count; i++)
            {
                diagram.Connectors[i].TargetDecoratorType = DecoratorType.None;
                diagram.Connectors[i].Style.StrokeWidth = 1 * DiagramUtility.currentDensity;
            }
            diagram.BeginNodeRender += Diagram_BeginNodeRender;
            diagram.Loaded += Diagram_Loaded;
            strokeStyle.Items.Add("Default");
            strokeStyle.Items.Add("Dashed");
            strokeStyle.Items.Add("Dotted");
            strokeStyle.SelectedIndex = 0;
            strokeStyle.SelectedIndexChanged += StrokeStyle_SelectedIndexChanged;
        }
        private Node GetParent(string parentId)
        {
            foreach (Node node in diagram.Nodes)
            {
                if ((node.Content as Employee).EmpId == parentId)
                {
                    return node;
                }
            }
            return RootNode;
        }
        private void StrokeStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            switch (picker.SelectedItem.ToString())
            {
                case "Default":
                    foreach (Connector connector in diagram.Connectors)
                    {
                        connector.Style.StrokeStyle = StrokeStyle.Default;
                    }
                    break;
                case "Dashed":
                    foreach (Connector connector in diagram.Connectors)
                    {
                        connector.Style.StrokeStyle = StrokeStyle.Dashed;
                    }
                    break;
                case "Dotted":
                    foreach (Connector connector in diagram.Connectors)
                    {
                        connector.Style.StrokeStyle = StrokeStyle.Dotted;
                    }
                    break;
            }
        }


        private void OnGridSizeSubtract(object sender, EventArgs e)
        {
            if (size > 1)
            {
                size--;
                if (Device.RuntimePlatform == Device.Android)
                {
                    foreach (Connector connector in diagram.Connectors)
                    {
                        connector.Style.StrokeWidth = size * (1 * DiagramUtility.currentDensity);
                    }
                }
                else
                    foreach (Connector connector in diagram.Connectors)
                    {
                        connector.Style.StrokeWidth = size;
                    }
                GridtThickness.Text = size.ToString();
            }
        }

        private void OnGridSizePlus(object sender, EventArgs e)
        {
            if (size < 5)
            {
                size++;
                if (Device.RuntimePlatform == Device.Android)
                {
                    foreach (Connector connector in diagram.Connectors)
                    {
                        connector.Style.StrokeWidth = size * (1 * DiagramUtility.currentDensity);
                    }
                }
                else
                    foreach (Connector connector in diagram.Connectors)
                    {
                        connector.Style.StrokeWidth = size;
                    }
                GridtThickness.Text = size.ToString();
            }
        }

        private void Diagram_Loaded(object sender)
        {
            diagram.BringToView(diagram.Nodes[0]);
        }
        private void Diagram_BeginNodeRender(object sender, BeginNodeRenderEventArgs args)
        {
            var node = args.Item;
            node.ShapeType = ShapeType.RoundedRectangle;
            node.Style.StrokeWidth = 0;
            if ((node.Content as Employee).Designation == "Manager")
                node.Style.Brush = new SolidBrush(Color.FromRgb(23, 132, 206));
            else if ((node.Content as Employee).Designation == "CEO")
            {
                node.Style.Brush = new SolidBrush(Color.FromRgb(201, 32, 61));
                RootNode = node;
            }
            else if ((node.Content as Employee).Designation == "Team Lead" || (node.Content as Employee).Designation == "Co-ordinator")
                node.Style.Brush = new SolidBrush(Color.FromRgb(4, 142, 135));
            else
                node.Style.Brush = new SolidBrush(Color.FromRgb(206, 98, 9));

            if (Device.RuntimePlatform == Device.UWP)
            {
                node.Width = 100;
                node.Height = 50;
            }
            else
            {
                node.Width = 144 * DiagramUtility.factor;
                node.Height = 60 * DiagramUtility.factor;
            }
            AnnotationCollection annotations = new AnnotationCollection();
            if (Device.RuntimePlatform == Device.Android)
                annotations.Add(new Annotation() { Content = (node.Content as Employee).Designation, FontSize = 14 * DiagramUtility.factor, TextBrush = new SolidBrush(Color.White) });
            else
                annotations.Add(new Annotation() { Content = (node.Content as Employee).Designation, FontSize = 15 * DiagramUtility.factor, TextBrush = new SolidBrush(Color.White) });
            node.Annotations = annotations;
        }

        private void OnStraight(object sender, EventArgs e)
        {
            OnSegmentChange(SegmentType.StraightSegment);
            StraightSegment.BackgroundColor = Color.DodgerBlue;
            CurveSegment.BackgroundColor = Color.FromHex("#fdfdfd");
            OrthoSegment.BackgroundColor = Color.FromHex("#fdfdfd");
            (StraightIcon.Source as FontImageSource).Color = Color.White;
            (CurveIcon.Source as FontImageSource).Color = Color.FromHex("#000000");
            (OrthoIcon.Source as FontImageSource).Color = Color.FromHex("#000000");


        }
        private void OnCurve(object sender, EventArgs e)
        {
            OnSegmentChange(SegmentType.CurveSegment);
            CurveSegment.BackgroundColor = Color.DodgerBlue;
            StraightSegment.BackgroundColor = Color.FromHex("#fdfdfd");
            OrthoSegment.BackgroundColor = Color.FromHex("#fdfdfd");
            (StraightIcon.Source as FontImageSource).Color = Color.FromHex("#000000");
            (CurveIcon.Source as FontImageSource).Color = Color.White;
            (OrthoIcon.Source as FontImageSource).Color = Color.FromHex("#000000");


        }
        private void OnOrtho(object sender, EventArgs e)
        {
            OnSegmentChange(SegmentType.OrthoSegment);
            OrthoSegment.BackgroundColor = Color.DodgerBlue;
            StraightSegment.BackgroundColor = Color.FromHex("#fdfdfd");
            CurveSegment.BackgroundColor = Color.FromHex("#fdfdfd");
            (StraightIcon.Source as FontImageSource).Color = Color.FromHex("#000000");
            (CurveIcon.Source as FontImageSource).Color = Color.FromHex("#000000");
            (OrthoIcon.Source as FontImageSource).Color = Color.White;


        }
        void OnSegmentChange(SegmentType segmenttype)
        {
            foreach (Connector connector in diagram.Connectors)
            {
                connector.SegmentType = segmenttype;
            }
        }
    }
    //Employee Business Object
    public class Employee
    {
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string EmpId { get; set; }
    }
    //Employee Collection
    public class Employees : ObservableCollection<Employee>
    {

    }
}
