#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using SampleBrowser.Core;
using System.Linq;
using Syncfusion.SfDiagram.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfDiagram
{
    [Preserve(AllMembers = true)]
    public partial class MindMap : SampleView
    {
        Node RootNode;
        UserHandleCollection DefaultHandles;
        internal Node SelectedNode;
        Frame Notifier;
        Entry textinput;
        UserHandlePosition CurrentHandle;
        Random rnd = new Random();
        List<Color> FColor;
        List<Color> SColor;
        int index;
        private DataTemplate m_collapseTemplate;
        private DataTemplate m_expandTemplate;
        List<NodeStyle> nodeStyleCollection;
        LineStyle lineStyle;
        object objShape1 = ShapeType.RoundedRectangle;
        object objShape2 = ShapeType.RoundedRectangle;
        object objShape3 = ShapeType.RoundedRectangle;
        object objShape4 = ShapeType.RoundedRectangle;
        object objShape5 = ShapeType.RoundedRectangle;
        SegmentType segment = SegmentType.CurveSegment;
        int themeIndex = 0;
        String simpleCurveTree = "default";
        SfGraphics gra;
        List<Point> point;
        DecoratorType Dectype = DecoratorType.None;
        Color connColor = Color.Gray;
        ApplyColorFrom connLineColorFrom = ApplyColorFrom.TargetBorder;
        ApplyColorFrom connDecColorFrom = ApplyColorFrom.TargetBorder;
        private bool m_isDiagramLoaded = true;
        public MindMap()
        {
            if (nodeStyleCollection == null)
                nodeStyleCollection = new List<NodeStyle>();
            if (gra == null)
            {
                gra = new SfGraphics();
            }
            if (point == null)
            {
                point = new List<Point>();
            }
            if (SColor == null)
            {
                SColor = new List<Color>();
            }
            if (FColor == null)
            {
                FColor = new List<Color>();
            }
            InitializeComponent();
            diagram.ContextMenuSettings.Visibility = false;
            if (Device.RuntimePlatform == Device.Android)
                Xamarin.Forms.DependencyService.Get<IText>().GenerateFactor();
            style.Items.Add("Default");
            style.Items.Add("Rainbow");
            style.Items.Add("Rosetta");
            style.Items.Add("Autumn");
            style.Items.Add("Woody");
            style.Items.Add("Ashes");
            style.Items.Add("Navy");
            style.SelectedIndex = 0;
            style.SelectedIndexChanged += style_SelectedIndexChanged;

            if (Device.RuntimePlatform == Device.UWP)
            {
                var label = new Label();
                label.Text = "Sample Not Supported !";
                label.HorizontalTextAlignment = TextAlignment.Center;
                label.VerticalTextAlignment = TextAlignment.Center;
                label.FontSize = 15;
                parent.Children.Add(label);
                diagram.IsReadOnly = true;
            }
            else
            {
                int width = 150;
                int height = 75;
                if (Device.RuntimePlatform == Device.Android)
                {
                    width = (int)(125 * DiagramUtility.factor);
                    height = (int)(60 * DiagramUtility.factor);
                }
                var node = AddNode(300, 400, width, height, "Goals");
                RootNode = node;
                diagram.AddNode(node);

                SColor.Add(Color.FromHex("#d1afdf"));
                SColor.Add(Color.FromHex("#90C8C2"));
                SColor.Add(Color.FromHex("#8BC1B7"));
                SColor.Add(Color.FromHex("#E2C180"));
                SColor.Add(Color.FromHex("#BBBFD6"));
                SColor.Add(Color.FromHex("#ACCBAA"));
                FColor.Add(Color.FromHex("#e9d4f1"));
                FColor.Add(Color.FromHex("#d4efed"));
                FColor.Add(Color.FromHex("#c4f2e8"));
                FColor.Add(Color.FromHex("#f7e0b3"));
                FColor.Add(Color.FromHex("#DEE2FF"));
                FColor.Add(Color.FromHex("#E5FEE4"));

                var ch1node = AddNode(100, 100, width, height, "Financial");
                index = rnd.Next(5);
                diagram.AddNode(ch1node);

                var ch1childnode = AddNode(100, 100, width, height, "Investment");
                diagram.AddNode(ch1childnode);

                var ch2node = AddNode(100, 600, width, height, "Social");
                index = rnd.Next(5);
                diagram.AddNode(ch2node);

                var ch2childnode1 = AddNode(100, 100, width, height, "Friends");
                diagram.AddNode(ch2childnode1);

                var ch2childnode2 = AddNode(100, 100, width, height, "Family");
                diagram.AddNode(ch2childnode2);

                var ch3node = AddNode(500, 100, width, height, "Personal");
                index = rnd.Next(5);
                diagram.AddNode(ch3node);

                var ch3childnode1 = AddNode(500, 100, width, height, "Sports");
                diagram.AddNode(ch3childnode1);

                var ch3childnode2 = AddNode(500, 100, width, height, "Food");
                diagram.AddNode(ch3childnode2);

                var ch4node = AddNode(500, 600, width, height, "Work");
                index = rnd.Next(5);
                diagram.AddNode(ch4node);

                var ch4childnode1 = AddNode(500, 100, width, height, "Project");
                diagram.AddNode(ch4childnode1);

                var ch4childnode2 = AddNode(500, 100, width, height, "Career");
                diagram.AddNode(ch4childnode2);

                diagram.AddConnector(AddConnector(node, ch1node));
                diagram.AddConnector(AddConnector(node, ch2node));
                diagram.AddConnector(AddConnector(node, ch3node));
                diagram.AddConnector(AddConnector(node, ch4node));
                diagram.AddConnector(AddConnector(ch1node, ch1childnode));
                diagram.AddConnector(AddConnector(ch2node, ch2childnode1));
                diagram.AddConnector(AddConnector(ch2node, ch2childnode2));
                diagram.AddConnector(AddConnector(ch3node, ch3childnode1));
                diagram.AddConnector(AddConnector(ch3node, ch3childnode2));
                diagram.AddConnector(AddConnector(ch4node, ch4childnode1));
                diagram.AddConnector(AddConnector(ch4node, ch4childnode2));

                diagram.UserHandleClicked += Diagram_UserHandleClicked;
                AddHandles();
                diagram.NodeClicked += Diagram_NodeClicked;

                diagram.DiagramClicked += Diagram_DiagramClicked;
                diagram.Loaded += Diagram_Loaded;
                SelectedNode = node;
                diagram.TextChanged += Diagram_TextChanged;
                diagram.ConnectorClicked += Diagram_ConnectorClicked;
            }
        }

        private void DefaultLayout(object sender, EventArgs e)
        {
            simpleCurveTree = "default";
            objShape1 = ShapeType.RoundedRectangle;
            objShape2 = ShapeType.RoundedRectangle;
            objShape3 = ShapeType.RoundedRectangle;
            objShape4 = ShapeType.RoundedRectangle;
            objShape5 = ShapeType.RoundedRectangle;
            segment = SegmentType.CurveSegment;
            fontVerticalAlignment = VerticalAlignment.Center;
            Dectype = DecoratorType.None;
            connColor = Color.Black;
            connLineColorFrom = ApplyColorFrom.TargetBorder;
            connDecColorFrom = ApplyColorFrom.TargetBorder;
            UpdateTheme(themeIndex);
        }

        void ManualLayout_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            if (ManualLayoutSwitch.IsToggled)
            {
                (diagram.LayoutManager.Layout as MindMapLayout).EnableFreeForm = true;
            }
            else
            {
                (diagram.LayoutManager.Layout as MindMapLayout).EnableFreeForm = false;
            }
        }

        private void SimpletreeCurvedLayout(object sender, EventArgs e)
        {
            simpleCurveTree = "simpleCurveTree";
            objShape1 = ShapeType.RoundedRectangle;
            objShape2 = ShapeType.RoundedRectangle;
            objShape3 = ShapeType.RoundedRectangle;
            objShape4 = ShapeType.RoundedRectangle;
            objShape5 = ShapeType.RoundedRectangle;
            segment = SegmentType.CurveSegment;
            fontVerticalAlignment = VerticalAlignment.Center;
            Dectype = DecoratorType.None;
            connColor = Color.FromHex("#949494");
            connLineColorFrom = ApplyColorFrom.Custom;
            connDecColorFrom = ApplyColorFrom.Custom;
            UpdateTheme(themeIndex);
        }
        private void OrthogonalLayout(object sender, EventArgs e)
        {
            simpleCurveTree = "orthotree";
            objShape1 = ShapeType.Rectangle;
            objShape2 = ShapeType.Rectangle;
            objShape3 = ShapeType.Rectangle;
            objShape4 = ShapeType.Rectangle;
            objShape5 = ShapeType.Rectangle;
            segment = SegmentType.OrthoSegment;
            fontVerticalAlignment = VerticalAlignment.Center;
            Dectype = DecoratorType.None;
            connColor = Color.Black;
            connLineColorFrom = ApplyColorFrom.TargetBorder;
            connDecColorFrom = ApplyColorFrom.TargetBorder;
            UpdateTheme(themeIndex);
        }
        VerticalAlignment fontVerticalAlignment = VerticalAlignment.Center;
        private void ContinuousTreeDefaultLayout(object sender, EventArgs e)
        {
            simpleCurveTree = "contCurveTree";
            SfGraphicsPath path = new SfGraphicsPath();
            if (Device.RuntimePlatform == Device.Android)
            {
                path.MoveTo(0, 0);
                path.MoveTo(0, 50);
                path.LineTo(100, 50);
                path.MoveTo(100, 100);
                gra.DrawPath(path);
                Pen pe = new Pen();
                pe.StrokeBrush = new SolidBrush(Color.Gray);
                pe.StrokeWidth = 5;
                point.Add(new Point(0, 50));
                point.Add(new Point(100, 50));
                gra.DrawLines(pe, point);
            }
            else
            {
                Pen pe = new Pen();
                pe.StrokeBrush = new SolidBrush(Color.Gray);
                pe.StrokeWidth = 3;
                point.Add(new Point(0, 37));
                point.Add(new Point(150, 37));
                gra.DrawLines(pe, point);
            }
            objShape1 = ShapeType.Ellipse;
            objShape2 = gra;
            objShape3 = gra;
            objShape4 = gra;
            objShape5 = gra;
            segment = SegmentType.CurveSegment;
            fontVerticalAlignment = VerticalAlignment.Top;
            Dectype = DecoratorType.None;
            connColor = Color.Black;
            connLineColorFrom = ApplyColorFrom.TargetBorder;
            connDecColorFrom = ApplyColorFrom.TargetBorder;
            UpdateTheme(themeIndex);
        }

        private void style_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTheme(style.SelectedIndex);
            themeIndex = style.SelectedIndex;
        }

        private void UpdateTheme(int themeIndex)
        {
            if (themeIndex == 0)
            {
                bool m_repeatmode = true;
                nodeStyleCollection.Clear();
                if (simpleCurveTree == "default")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#d7ebf6")), Color.FromHex("#d7ebf6"), objShape1, StrokeStyle.Default,
                    new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#ffebc4")), Color.FromHex("#ffebc4"), objShape2, StrokeStyle.Default,
                        new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#ffcdcd")), Color.FromHex("#ffcdcd"), objShape3, StrokeStyle.Default,
                     new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#e7eeb8")), Color.FromHex("#e7eeb8"), objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#d7ebf6")), Color.FromHex("#d7ebf6"), objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "orthotree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#d7ebf6")), Color.FromHex("#b4d6e8"), objShape1, StrokeStyle.Default,
                    new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#ffebc4")), Color.FromHex("#f2dcb1"), objShape2, StrokeStyle.Default,
                        new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#ffcdcd")), Color.FromHex("#ecb6b6"), objShape3, StrokeStyle.Default,
                     new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#e7eeb8")), Color.FromHex("#d6dda6"), objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#d7ebf6")), Color.FromHex("#b4d6e8"), objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "simpleCurveTree")
                {
                    m_repeatmode = false;
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#d7ebf6")), Color.FromHex("#b4d6e8"), objShape1, StrokeStyle.Default,
                    new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape2, StrokeStyle.Default,
                        new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape3, StrokeStyle.Default,
                     new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "contCurveTree")
                {
                    m_repeatmode = false;
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#d7ebf6")), Color.FromHex("#d7ebf6"), objShape1, StrokeStyle.Default,
                    new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#949494")), Color.FromHex("#949494"), objShape2, StrokeStyle.Default,
                        new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#949494")), Color.FromHex("#949494"), objShape3, StrokeStyle.Default,
                     new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#949494")), Color.FromHex("#949494"), objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#949494")), Color.FromHex("#949494"), objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                lineStyle = new LineStyle(segment, StrokeStyle.Default, 3, connLineColorFrom, Dectype, connDecColorFrom, connDecColorFrom) { Color = connColor };
                (diagram.LayoutManager.Layout as MindMapLayout).UpdateLayoutStyle(new LayoutStyle(nodeStyleCollection, lineStyle, ApplyNodeStyleBy.Branch, m_repeatmode));
            }
            if (themeIndex == 1)
            {
                nodeStyleCollection.Clear();
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#eea4af")), Color.FromHex("#ce2340"), objShape1, StrokeStyle.Default,
                    new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
                if (simpleCurveTree == "default")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#c6ebb4")), Color.FromHex("#7cea56"), objShape2, StrokeStyle.Default,
                        new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#a7c7ed")), Color.FromHex("#2f75d3"), objShape3, StrokeStyle.Default,
                         new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#eac4a1")), Color.FromHex("#ce7023"), objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#ede3a2")), Color.FromHex("#d6bb29"), objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "simpleCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape2, StrokeStyle.Default,
                    new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape3, StrokeStyle.Default,
                         new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "contCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape2, StrokeStyle.Default,
                        new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape3, StrokeStyle.Default,
                     new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                lineStyle = new LineStyle(segment, StrokeStyle.Default, 3, connLineColorFrom, Dectype, connDecColorFrom, connDecColorFrom) { Color = connColor };
                (diagram.LayoutManager.Layout as MindMapLayout).UpdateLayoutStyle(new LayoutStyle(nodeStyleCollection, lineStyle, ApplyNodeStyleBy.Level, true));
            }
            if (themeIndex == 2)
            {
                nodeStyleCollection.Clear();
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#f0a8e1")), Color.FromHex("#da2eb8"), objShape1, StrokeStyle.Default,
                    new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
                if (simpleCurveTree == "default")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#eec3eb")), Color.FromHex("#ae8fa7"), objShape2, StrokeStyle.Default,
                        new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#f0e8f0")), Color.FromHex("#ae8fa7"), objShape3, StrokeStyle.Default,
                         new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#9a88b7")), Color.FromHex("#716587"), objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#efa6c8")), Color.FromHex("#ae7893"), objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "simpleCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape2, StrokeStyle.Default,
                           new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape3, StrokeStyle.Default,
                         new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "contCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape2, StrokeStyle.Default,
                        new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape3, StrokeStyle.Default,
                     new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                lineStyle = new LineStyle(segment, StrokeStyle.Default, 3, connLineColorFrom, Dectype, connDecColorFrom, connDecColorFrom) { Color = connColor };
                (diagram.LayoutManager.Layout as MindMapLayout).UpdateLayoutStyle(new LayoutStyle(nodeStyleCollection, lineStyle, ApplyNodeStyleBy.Level, true));
            }
            if (themeIndex == 3)
            {
                nodeStyleCollection.Clear();
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#f3d8d6")), Color.FromHex("#e3a39f"), objShape1, StrokeStyle.Default,
                    new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
                if (simpleCurveTree == "default")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#e9afa4")), Color.FromHex("#cd3e24"), objShape2, StrokeStyle.Default,
                        new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#e6c6a7")), Color.FromHex("#c5752d"), objShape3, StrokeStyle.Default,
                         new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#e9d5b3")), Color.FromHex("#cc9d44"), objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#ebc3a2")), Color.FromHex("#cf7225"), objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "simpleCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape2, StrokeStyle.Default,
                              new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape3, StrokeStyle.Default,
                         new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "contCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape2, StrokeStyle.Default,
                        new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape3, StrokeStyle.Default,
                     new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                lineStyle = new LineStyle(segment, StrokeStyle.Default, 3, connLineColorFrom, Dectype, connDecColorFrom, connDecColorFrom) { Color = connColor };
                (diagram.LayoutManager.Layout as MindMapLayout).UpdateLayoutStyle(new LayoutStyle(nodeStyleCollection, lineStyle, ApplyNodeStyleBy.Level, true));
            }
            if (themeIndex == 4)
            {
                nodeStyleCollection.Clear();
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#dabeb7")), Color.FromHex("#a66757"), objShape1, StrokeStyle.Default,
                    new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
                if (simpleCurveTree == "default")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#c4b2a3")), Color.FromHex("#714621"), objShape2, StrokeStyle.Default,
                        new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#cec3cd")), Color.FromHex("#897386"), objShape3, StrokeStyle.Default,
                         new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#d2c2b9")), Color.FromHex("#977460"), objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#d1c4c0")), Color.FromHex("#92736e"), objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "simpleCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape2, StrokeStyle.Default,
                           new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape3, StrokeStyle.Default,
                         new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "contCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape2, StrokeStyle.Default,
                        new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape3, StrokeStyle.Default,
                     new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                lineStyle = new LineStyle(segment, StrokeStyle.Default, 3, connLineColorFrom, Dectype, connDecColorFrom, connDecColorFrom) { Color = connColor };
                (diagram.LayoutManager.Layout as MindMapLayout).UpdateLayoutStyle(new LayoutStyle(nodeStyleCollection, lineStyle, ApplyNodeStyleBy.Level, true));
            }
            if (themeIndex == 5)
            {
                nodeStyleCollection.Clear();
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#c5cacd")), Color.FromHex("#747f86"), objShape1, StrokeStyle.Default,
                    new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
                if (simpleCurveTree == "default")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#d3d2d6")), Color.FromHex("#96979f"), objShape2, StrokeStyle.Default,
                        new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#e7e8e7")), Color.FromHex("#c2bac1"), objShape3, StrokeStyle.Default,
                         new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#b3b9bb")), Color.FromHex("#475859"), objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#c9cfce")), Color.FromHex("#7f8d8a"), objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "simpleCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape2, StrokeStyle.Default,
                           new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape3, StrokeStyle.Default,
                         new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "contCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape2, StrokeStyle.Default,
                        new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape3, StrokeStyle.Default,
                     new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                lineStyle = new LineStyle(segment, StrokeStyle.Default, 3, connLineColorFrom, Dectype, connDecColorFrom, connDecColorFrom) { Color = connColor };
                (diagram.LayoutManager.Layout as MindMapLayout).UpdateLayoutStyle(new LayoutStyle(nodeStyleCollection, lineStyle, ApplyNodeStyleBy.Level, true));
            }
            if (themeIndex == 6)
            {
                nodeStyleCollection.Clear();
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#a1c6de")), Color.FromHex("#2174b1"), objShape1, StrokeStyle.Default,
                    new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
                if (simpleCurveTree == "default")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#a8c6ee")), Color.FromHex("#2f76da"), objShape2, StrokeStyle.Default,
                        new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#a4baef")), Color.FromHex("#285cda"), objShape3, StrokeStyle.Default,
                         new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#babaf3")), Color.FromHex("#585be4"), objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.FromHex("#b9dadf")), Color.FromHex("#57a5b3"), objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "simpleCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape2, StrokeStyle.Default,
                           new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape3, StrokeStyle.Default,
                         new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "contCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape2, StrokeStyle.Default,
                        new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape3, StrokeStyle.Default,
                     new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape4, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Gray), Color.Gray, objShape5, StrokeStyle.Default,
                       new Syncfusion.SfDiagram.XForms.TextStyle((int)(14 * DiagramUtility.factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                lineStyle = new LineStyle(segment, StrokeStyle.Default, 3, connLineColorFrom, Dectype, connDecColorFrom, connDecColorFrom) { Color = connColor };
                (diagram.LayoutManager.Layout as MindMapLayout).UpdateLayoutStyle(new LayoutStyle(nodeStyleCollection, lineStyle, ApplyNodeStyleBy.Level, true));
            }
        }

        private Connector AddConnector(Node node, Node ch1node)
        {
            var c1 = new Connector();
            c1.SourceNode = node;
            c1.TargetNode = ch1node;
            c1.SegmentType = SegmentType.CurveSegment;
            return c1;
        }

        Node AddNode(int x, int y, int w, int h, string text)
        {
            var node = new Node(x, y, w, h);
            node.ShapeType = ShapeType.RoundedRectangle;
            node.Style.StrokeWidth = 2;
            if (Device.RuntimePlatform == Device.Android)
                node.Annotations.Add(new Annotation() { Content = text, FontSize = 17 * DiagramUtility.factor, TextBrush = new SolidBrush(Color.Black) });
            else if (Device.RuntimePlatform == Device.iOS)
                node.Annotations.Add(new Annotation() { Content = text, FontSize = 15, TextBrush = new SolidBrush(Color.Black) });
            return node;
        }

        private void AddAnnotation(string headertext)
        {
            StackLayout root;
            root = new StackLayout();
            Label title = new Label();
            title.Margin = new Thickness(0, 2, 0, 0);
            title.Text = headertext;
            title.TextColor = Color.Black;
            title.FontSize = 15;
            title.FontAttributes = FontAttributes.Bold;
            title.VerticalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Start };
            title.HorizontalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Start };
            root.Children.Add(title);

            textinput = new Entry();
            textinput.Margin = new Thickness(0, 25, 0, 0);
            textinput.WidthRequest = 300;
            textinput.HeightRequest = 50;
            textinput.Focused += Textinput_Focused;
            textinput.Focus();
            textinput.Placeholder = "Text";
            textinput.VerticalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Center };
            textinput.HorizontalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Center };

            Button ok = new Button();
            ok.BackgroundColor = Color.Transparent;
            ok.Text = "OK";
            ok.TextColor = Color.FromHex("#e63375");
            ok.Margin = new Thickness(0, 0, 0, 0);
            ok.VerticalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Center };
            ok.HorizontalOptions = new LayoutOptions() { Alignment = LayoutAlignment.End };
            ok.Clicked += Ok_Clicked;
            root.Children.Add(textinput);

            Button cancel = new Button();
            cancel.Text = "       CANCEL";
            cancel.TextColor = Color.FromHex("#e63375");
            cancel.BackgroundColor = Color.Transparent;
            cancel.Margin = new Thickness(0, 0, 0, 0);
            cancel.VerticalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Center };
            cancel.HorizontalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Center };
            cancel.Clicked += Cancel_Clicked;

            Grid buttonGrid = new Grid();
            buttonGrid.Children.Add(cancel);
            buttonGrid.Children.Add(ok);
            root.Children.Add(buttonGrid);

            Notifier = new Frame();
            Notifier.WidthRequest = 300;
            Notifier.HeightRequest = 150;
            Notifier.Content = root;
            Notifier.VerticalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Center };
            Notifier.HorizontalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Center };
            Notifier.CornerRadius = 5;
            Notifier.BackgroundColor = Color.White;
            Notifier.BorderColor = Color.Black;
            diagram.PageSettings.PageBackGround = Color.DarkGray;
            diagram.Opacity = 0.2;
            parent.Children.Add(Notifier);
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            diagram.Opacity = 1;
            diagram.PageSettings.PageBackGround = Color.White;
            parent.Children.Remove(Notifier);
        }

        private void AddHandles()
        {
            var plusTemplate = GetTemplate("plus.png");
            var deleteTemplate = GetTemplate("delete.png");
            m_expandTemplate = GetTemplate("mindmapcollpase.png");
            m_collapseTemplate = GetTemplate("mindmapexpand.png");
            var moreTemplate = GetTemplate("more.png");
            DefaultHandles = new UserHandleCollection();
            DefaultHandles.Add(new UserHandle("Left", UserHandlePosition.Left, plusTemplate));
            DefaultHandles.Add(new UserHandle("Right", UserHandlePosition.Right, plusTemplate));
            DefaultHandles.Add(new UserHandle("ExpColl", UserHandlePosition.BottomLeft, m_expandTemplate));
            DefaultHandles.Add(new UserHandle("Delete", UserHandlePosition.Bottom, deleteTemplate) { Visible = false });
            DefaultHandles.Add(new UserHandle("info", UserHandlePosition.TopRight, moreTemplate));
            diagram.UserHandles = DefaultHandles;
        }

        private DataTemplate GetTemplate(string imageId)
        {
            return new DataTemplate(() =>
            {
                var root = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    BackgroundColor = Color.Transparent
                };
                Image image = new Image();
                image.WidthRequest = 25;
                image.HeightRequest = 25;
                image.Source = imageId;
                root.Children.Add(image);
                return root;
            });
        }

        private void Diagram_TextChanged(object sender, Syncfusion.SfDiagram.XForms.TextChangedEventArgs args)
        {
            args.Item.TextBrush = new SolidBrush(Color.Black);
            if (Device.RuntimePlatform == Device.Android)
                args.Item.FontSize = 17 * DiagramUtility.factor;
            else
                args.Item.FontSize = 15;
        }

        private void Diagram_Loaded(object sender)
        {
            if (m_isDiagramLoaded)
            {
                diagram.EnableDrag = false;
                diagram.ShowSelectorHandle(false, SelectorPosition.SourcePoint);
                diagram.ShowSelectorHandle(false, SelectorPosition.TargetPoint);
                diagram.ShowSelectorHandle(false, SelectorPosition.Rotator);
                diagram.ShowSelectorHandle(false, SelectorPosition.TopLeft);
                diagram.ShowSelectorHandle(false, SelectorPosition.TopRight);
                diagram.ShowSelectorHandle(false, SelectorPosition.MiddleLeft);
                diagram.ShowSelectorHandle(false, SelectorPosition.MiddleRight);
                diagram.ShowSelectorHandle(false, SelectorPosition.BottomCenter);
                diagram.ShowSelectorHandle(false, SelectorPosition.BottomLeft);
                diagram.ShowSelectorHandle(false, SelectorPosition.BottomRight);
                diagram.ShowSelectorHandle(false, SelectorPosition.TopCenter);
                diagram.LayoutManager = new LayoutManager()
                {
                    Layout = new MindMapLayout()
                    {
                        MindMapOrientation = Orientation.Horizontal,
                        HorizontalSpacing = 70,
                    }
                };
                if (Device.RuntimePlatform == Device.Android)
                {
                    (diagram.LayoutManager.Layout as MindMapLayout).HorizontalSpacing = 70 * DiagramUtility.factor;
                }
                if (!(diagram.LayoutManager.Layout as MindMapLayout).EnableFreeForm)
                {
                    diagram.LayoutManager.Layout.UpdateLayout();
                }
                diagram.Select(RootNode);
                diagram.BringToView(RootNode);
                UpdateTheme(0);
                m_isDiagramLoaded = false;
            }

        }

        private void Diagram_DiagramClicked(object sender, DiagramClickedEventArgs args)
        {
            diagram.Opacity = 1;
            diagram.PageSettings.PageBackGround = Color.White;
            if (Notifier != null && parent.Children.Contains(Notifier))
            {
                textinput.Unfocus();
                parent.Children.Remove(Notifier);
            }

            SelectedNode = null;
        }

        private void Diagram_UserHandleClicked(object sender, UserHandleClickedEventArgs args)
        {
            if (Notifier != null && parent.Children.Contains(Notifier))
            {
                parent.Children.Remove(Notifier);
                diagram.Opacity = 1;
                diagram.PageSettings.PageBackGround = Color.White;
            }
            else
            {
                if (args.Item.Name == "Delete")
                {
                    diagram.RemoveNode(SelectedNode, true);
                    if (!(diagram.LayoutManager.Layout as MindMapLayout).EnableFreeForm)
                        (diagram.LayoutManager.Layout as MindMapLayout).UpdateLayout();
                }
                else if (args.Item.Name == "ExpColl")
                {
                    diagram.ClearSelection();
                    if (SelectedNode.IsExpanded)
                    {
                        SelectedNode.IsExpanded = false;
                        args.Item.Content = m_collapseTemplate;
                    }
                    else
                    {
                        SelectedNode.IsExpanded = true;
                        args.Item.Content = m_expandTemplate;
                    }
                    if (!(diagram.LayoutManager.Layout as MindMapLayout).EnableFreeForm)
                        (diagram.LayoutManager.Layout as MindMapLayout).UpdateLayout();
                    UpdateHandle();
                    diagram.Select(SelectedNode);
                }
                else if (args.Item.Name == "info")
                {


                    ShowInfo();
                }
                else
                {
                    if (args.Item.Name == "Left")
                    {
                        CurrentHandle = UserHandlePosition.Left;
                        AddAnnotation("Add Topic");
                    }
                    else if (args.Item.Name == "Right")
                    {
                        CurrentHandle = UserHandlePosition.Right;
                        AddAnnotation("Add Topic");
                    }
                }
            }
        }
        async void ShowInfo()
        {
            var nav = new AddNote(this);
            NavigationPage.SetHasBackButton(nav, false);
            NavigationPage.SetHasNavigationBar(nav, false);
            await Navigation.PushAsync(nav);
        }

        private void Textinput_Focused(object sender, FocusEventArgs e)
        {
            Notifier.VerticalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Start };
            Notifier.Margin = new Thickness(0, 50, 0, 0);
            if (Device.RuntimePlatform == Device.iOS)
                Notifier.Margin = new Thickness(0, 200, 0, 0);
        }

        private void Ok_Clicked(object sender, EventArgs e)
        {
            diagram.Opacity = 1;
            diagram.PageSettings.PageBackGround = Color.White;
            parent.Children.Remove(Notifier);
            if (textinput.Text == null)
            {
                textinput.Text = "";
            }
            var node = new Node();
            if (CurrentHandle == UserHandlePosition.Left)
            {
                node.OffsetX = SelectedNode.OffsetX - SelectedNode.Width - 100;
                node.OffsetY = SelectedNode.OffsetY;
            }
            else if (CurrentHandle == UserHandlePosition.Right)
            {
                node.OffsetX = SelectedNode.OffsetX + SelectedNode.Width + 100;
                node.OffsetY = SelectedNode.OffsetY;
            }
            node.Width = SelectedNode.Width;
            node.Height = SelectedNode.Height;
            node.ShapeType = ShapeType.RoundedRectangle;
            node.Style.StrokeWidth = 2;
            if (SelectedNode == RootNode)
            {
                index = rnd.Next(5);
                node.Style.Brush = new SolidBrush(FColor[index]);
                node.Style.StrokeBrush = new SolidBrush(SColor[index]);
            }
            else
            {
                node.Style = SelectedNode.Style;
            }
            if (Device.RuntimePlatform == Device.Android)
                node.Annotations.Add(new Annotation() { Content = textinput.Text, FontSize = 17 * DiagramUtility.factor, TextBrush = new SolidBrush(Color.Black) });
            else if (Device.RuntimePlatform == Device.iOS)
                node.Annotations.Add(new Annotation() { Content = textinput.Text, FontSize = 15, TextBrush = new SolidBrush(Color.Black) });
            diagram.AddNode(node);
            var c1 = new Connector();
            c1.SourceNode = SelectedNode;
            c1.TargetNode = node;
            c1.Style.StrokeBrush = node.Style.StrokeBrush;
            c1.Style.StrokeWidth = 3;
            c1.TargetDecoratorStyle.Fill = (node.Style.StrokeBrush as SolidBrush).FillColor;
            c1.TargetDecoratorStyle.Stroke = (node.Style.StrokeBrush as SolidBrush).FillColor;
            c1.SegmentType = SegmentType.CurveSegment;
            c1.Style.StrokeStyle = StrokeStyle.Dashed;
            diagram.AddConnector(c1);
            if (CurrentHandle == UserHandlePosition.Left)
            {
                if (!(diagram.LayoutManager.Layout as MindMapLayout).EnableFreeForm)
                    (diagram.LayoutManager.Layout as MindMapLayout).UpdateLeftOrTop();
            }
            else if (CurrentHandle == UserHandlePosition.Right)
            {
                if (!(diagram.LayoutManager.Layout as MindMapLayout).EnableFreeForm)
                    (diagram.LayoutManager.Layout as MindMapLayout).UpdateRightOrBottom();
            }
            SelectedNode = node;
            UpdateHandle();
            diagram.UserHandles[2].Visible = false;
            diagram.Select(node);
            SelectedNode = node;
            diagram.BringToView(node);
        }

        private void Diagram_NodeClicked(object sender, NodeClickedEventArgs args)
        {
            SelectedNode = args.Item;
            diagram.Opacity = 1;
            diagram.PageSettings.PageBackGround = Color.White;
            if (Notifier != null && parent.Children.Contains(Notifier))
            {
                parent.Children.Remove(Notifier);
            }
            else
            {
                UpdateHandle();
            }
        }
        private String GetNodeDirection(Node node)
        {
            string side = null;
            if (node != RootNode && node.OffsetX > RootNode.OffsetX)
            {
                side = "Right";
            }
            else if (node != RootNode && node.OffsetX < RootNode.OffsetX)
            {
                side = "Left";
            }
            else if (node == RootNode)
            {
                side = "Center";
            }
            return side;
        }
        private void UpdateHandle()
        {
            var side = GetNodeDirection(SelectedNode);
            if (side == "Right")
            {
                //Left add
                diagram.UserHandles[0].Visible = false;
                //Right add
                diagram.UserHandles[1].Visible = true;
                //ExpColl
                if (SelectedNode.IsExpanded)
                {

                    diagram.UserHandles[2].Content = m_collapseTemplate;
                }
                else
                {

                    diagram.UserHandles[2].Content = m_expandTemplate;
                }
                diagram.UserHandles[2].Visible = true;
                //Delete
                diagram.UserHandles[3].Visible = true;
                //Info
                diagram.UserHandles[4].Visible = true;
                if (!SelectedNode.IsExpanded)
                {
                    diagram.UserHandles[1].Visible = false;
                }
            }
            else if (side == "Left")
            {
                //Left add
                diagram.UserHandles[0].Visible = true;
                //Right add
                diagram.UserHandles[1].Visible = false;
                //ExpColl
                if (SelectedNode.IsExpanded)
                {
                  
                    diagram.UserHandles[2].Content = m_expandTemplate;
                }
                else
                {
                   
                    diagram.UserHandles[2].Content = m_collapseTemplate;
                }
                diagram.UserHandles[2].Visible = true;
                //Delete
                diagram.UserHandles[3].Visible = true;
                //Info
                diagram.UserHandles[4].Visible = true;
                if (!SelectedNode.IsExpanded)
                {
                    diagram.UserHandles[0].Visible = false;
                }
            }
            else if (side == "Center")
            {
                //Left add
                diagram.UserHandles[0].Visible = true;
                //Right add
                diagram.UserHandles[1].Visible = true;
                //ExpColl
                diagram.UserHandles[2].Visible = true;
                //Delete
                diagram.UserHandles[3].Visible = false;
                //Info
                diagram.UserHandles[4].Visible = true;
                if (!SelectedNode.IsExpanded)
                {
                    diagram.UserHandles[0].Visible = false;
                    diagram.UserHandles[1].Visible = false;
                }
            }
            if (SelectedNode.Children.Any())
            {
                diagram.UserHandles[2].Visible = true;
            }
            else
            {
                diagram.UserHandles[2].Visible = false;
            }
        }

        void Diagram_ConnectorClicked(object sender, ConnectorClickedEventArgs args)
        {
            diagram.ClearSelection();
            if (Notifier != null && parent.Children.Contains(Notifier))
            {
                parent.Children.Remove(Notifier);
            }
        }

        public override void OnDisappearing()
        {
            if (nodeStyleCollection != null)
            {
                nodeStyleCollection = null;
            }
            if (gra != null)
            {
                gra = null;
            }
            if (point != null)
            {
                point = null;
            }
            if (SColor != null)
            {
                SColor = null;
            }
            if (FColor != null)
            {
                FColor = null;
            }

            GC.Collect();
            base.OnDisappearing();
        }
    }
}