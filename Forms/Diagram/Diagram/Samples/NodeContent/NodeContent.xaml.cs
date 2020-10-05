#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfDiagram.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfDiagram
{
    public partial class NodeContent : SampleView
    {
        public NodeContent()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.Android)
                Xamarin.Forms.DependencyService.Get<IText>().GenerateFactor();
            //set background color
            diagram.PageSettings.PageBackGround = Color.White;
            if (Device.RuntimePlatform == Device.UWP)
            {
                diagram.PageSettings.PageWidth = 1600;
                diagram.PageSettings.PageHeight = 700;
                diagram.BackgroundColor = Color.White;
            }
            diagram.IsReadOnly = true;
            diagram.EnableSelectors = false;
            //NodeCollection nodes = new NodeCollection();

            var node1 = DrawNode(((float)(280)) * DiagramUtility.factor, 150 * DiagramUtility.factor, 165 * DiagramUtility.factor, 50 * DiagramUtility.factor, ShapeType.RoundedRectangle);
            node1.Style.StrokeBrush = new SolidBrush(Color.FromRgb(206, 98, 9));
            node1.Annotations.Add(new Annotation() { Content = "Establish Project and Team", TextBrush = new SolidBrush(Color.White), FontSize = 10 * DiagramUtility.factor });// CreateLabel("Establish Project and Team", 12) });
            diagram.AddNode(node1);

            var node2 = DrawNode(((float)(280)) * DiagramUtility.factor, (float)(node1.OffsetY + (90 * DiagramUtility.factor)), 165 * DiagramUtility.factor, 50 * DiagramUtility.factor, ShapeType.RoundedRectangle);
            node2.Style.StrokeBrush = new SolidBrush(Color.FromRgb(206, 98, 9));
            if (Device.RuntimePlatform == Device.UWP)
            {
                node2.Style.Brush = new SolidBrush(Color.FromRgb(255, 129, 0));
            }
            else
                node2.Style.Brush = new LinearGradientBrush(0, 30, 150, 30, new Color[] { Color.FromRgb(255, 130, 0), Color.FromRgb(255, 37, 0) });
            node2.Style.StrokeWidth = 0;
            node2.Annotations.Add(new Annotation() { Content = "Define Scope", TextBrush = new SolidBrush(Color.White), FontSize = 10 * DiagramUtility.factor });// Content = CreateLabel("Define Scope", 12) });
            diagram.AddNode(node2);

            var node3 = DrawNode(((float)(280)) * DiagramUtility.factor, (float)(node2.OffsetY + (90 * DiagramUtility.factor)), 165 * DiagramUtility.factor, 50 * DiagramUtility.factor, ShapeType.RoundedRectangle);
            node3.Style.StrokeBrush = new SolidBrush(Color.FromRgb(206, 98, 9));
            node3.Style.StrokeStyle = StrokeStyle.Dashed;
            node3.Annotations.Add(new Annotation() { Content = "Analyze process As-Is", TextBrush = new SolidBrush(Color.White), FontSize = 10 * DiagramUtility.factor });// Content = CreateLabel("Analyze process As-Is", 12) });
            diagram.AddNode(node3);

            var node4 = DrawNode(((float)(280)) * DiagramUtility.factor, (float)(node3.OffsetY + (90 * DiagramUtility.factor)), 165 * DiagramUtility.factor, 50 * DiagramUtility.factor, ShapeType.RoundedRectangle);
            node4.Style.StrokeBrush = new SolidBrush(Color.FromRgb(206, 98, 9));
            node4.Style.StrokeWidth = 0;
            node4.Annotations.Add(new Annotation() { Content = "Identify Opportunities", VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center, TextBrush = new SolidBrush(Color.White), FontSize = 10 * DiagramUtility.factor });// Content = CreateLabel("Identify opportunities for improvement", 12) });
            diagram.AddNode(node4);

            var node5 = DrawNode(((float)(280)) * DiagramUtility.factor, (float)(node4.OffsetY + (90 * DiagramUtility.factor)), 165 * DiagramUtility.factor, 50 * DiagramUtility.factor, ShapeType.RoundedRectangle);
            node5.Style.StrokeBrush = new SolidBrush(Color.FromRgb(206, 98, 9));
            node5.Style.StrokeWidth = 0;
            node5.Annotations.Add(new Annotation() { Content = "Design and Implement", TextBrush = new SolidBrush(Color.White), FontSize = 10 * DiagramUtility.factor });// Content = CreateLabel("Design and implement improved processess", 12) });
            diagram.AddNode(node5);

            var node6 = DrawCustomShape(53, 153.22f);
            node6.Ports.Add(new Port() { NodeOffsetX = 1, NodeOffsetY = 0.5, IsVisible = false });
            diagram.AddNode(node6);
            Node labelnode6 = null;
            if (Device.RuntimePlatform == Device.Android)
            {
                labelnode6 = new Node(37 * DiagramUtility.factor, 200 * DiagramUtility.factor, 80 * DiagramUtility.factor, 35 * DiagramUtility.factor);
                labelnode6.Annotations.Add(new Annotation() { Content = "Sponsor", FontSize = 16 * DiagramUtility.factor, HorizontalAlignment = HorizontalAlignment.Center });
            }
            else
            {
                labelnode6 = new Node(33.5f * DiagramUtility.factor, 195 * DiagramUtility.factor, 80 * DiagramUtility.factor, 35 * DiagramUtility.factor);
                labelnode6.Annotations.Add(new Annotation() { Content = "Sponsor", FontSize = 10 * DiagramUtility.factor, });
            }
            labelnode6.Style = new Syncfusion.SfDiagram.XForms.Style()
            {
                StrokeBrush = new SolidBrush(Color.Transparent),
                Brush = new SolidBrush(Color.Transparent)
            };
            diagram.AddNode(labelnode6);

            var node7 = DrawCustomShape(53, 347);
            node7.Ports.Add(new Port() { NodeOffsetX = 1, NodeOffsetY = 0, IsVisible = false });
            node7.Ports.Add(new Port() { NodeOffsetX = 1, NodeOffsetY = 0.3, IsVisible = false });
            node7.Ports.Add(new Port() { NodeOffsetX = 1, NodeOffsetY = 0.6, IsVisible = false });
            node7.Ports.Add(new Port() { NodeOffsetX = 1, NodeOffsetY = 1, IsVisible = false });
            diagram.AddNode(node7);
            Node labelnode7 = null;
            if (Device.RuntimePlatform == Device.Android)
            {
                labelnode7 = new Node(50 * DiagramUtility.factor, 395 * DiagramUtility.factor, 60 * DiagramUtility.factor, 50 * DiagramUtility.factor);
                labelnode7.Annotations.Add(new Annotation() { Content = "Domain Experts", FontSize = 15 * DiagramUtility.factor, HorizontalAlignment = HorizontalAlignment.Center });
            }
            else
            {
                labelnode7 = new Node(55 * DiagramUtility.factor, 393 * DiagramUtility.factor, 60 * DiagramUtility.factor, 50 * DiagramUtility.factor);
                labelnode7.Annotations.Add(new Annotation() { Content = "Domain Experts", FontSize = 10 * DiagramUtility.factor, });
            }
            labelnode7.Style = new Syncfusion.SfDiagram.XForms.Style()
            {
                StrokeBrush = new SolidBrush(Color.Transparent),
                Brush = new SolidBrush(Color.Transparent)
            };
            diagram.AddNode(labelnode7);

            var node8 = DrawCustomShape(590, 153.22f);
            node8.Ports.Add(new Port() { NodeOffsetX = 0, NodeOffsetY = 0.5, IsVisible = false });
            diagram.AddNode(node8);
            Node labelnode8 = null;
            if (Device.RuntimePlatform == Device.Android)
            {
                labelnode8 = new Node(590.5f * DiagramUtility.factor, 205 * DiagramUtility.factor, 65 * DiagramUtility.factor, 39 * DiagramUtility.factor);
                labelnode8.Annotations.Add(new Annotation() { Content = "Project Manager", FontSize = 15 * DiagramUtility.factor, HorizontalAlignment = HorizontalAlignment.Center });
            }
            else
            {
                labelnode8 = new Node(590.5f * DiagramUtility.factor, 200 * DiagramUtility.factor, 65 * DiagramUtility.factor, 39 * DiagramUtility.factor);
                labelnode8.Annotations.Add(new Annotation() { Content = "Project Manager", FontSize = 10 * DiagramUtility.factor, });
            }
            labelnode8.Style = new Syncfusion.SfDiagram.XForms.Style()
            {
                StrokeBrush = new SolidBrush(Color.Transparent),
                Brush = new SolidBrush(Color.Transparent)
            };
            diagram.AddNode(labelnode8);

            var node9 = DrawCustomShape(590, 347);
            node9.Ports.Add(new Port() { NodeOffsetX = 0, NodeOffsetY = 0, IsVisible = false });
            node9.Ports.Add(new Port() { NodeOffsetX = 0, NodeOffsetY = 0.3, IsVisible = false });
            node9.Ports.Add(new Port() { NodeOffsetX = 0, NodeOffsetY = 0.6, IsVisible = false });
            node9.Ports.Add(new Port() { NodeOffsetX = 0, NodeOffsetY = 1, IsVisible = false });
            diagram.AddNode(node9);
            Node labelnode9 = null;
            if (Device.RuntimePlatform == Device.Android)
            {
                labelnode9 = new Node(589 * DiagramUtility.factor, 399.5f * DiagramUtility.factor, 62 * DiagramUtility.factor, 39 * DiagramUtility.factor);
                labelnode9.Annotations.Add(new Annotation() { Content = "Business Analyst", FontSize = 15 * DiagramUtility.factor, HorizontalAlignment = HorizontalAlignment.Center });
            }
            else
            {
                labelnode9 = new Node(591 * DiagramUtility.factor, 398.5f * DiagramUtility.factor, 65 * DiagramUtility.factor, 39 * DiagramUtility.factor);
                labelnode9.Annotations.Add(new Annotation() { Content = "Business Analyst", FontSize = 10 * DiagramUtility.factor, });
            }
            labelnode9.Style = new Syncfusion.SfDiagram.XForms.Style()
            {
                StrokeBrush = new SolidBrush(Color.Transparent),
                Brush = new SolidBrush(Color.Transparent)
            };

            diagram.AddConnector(DrawConnector(node1, node2, node1.Ports[2], node2.Ports[0], SegmentType.OrthoSegment, Color.FromRgb(127, 132, 133), StrokeStyle.Default, DecoratorType.Filled45Arrow, Color.FromRgb(127, 132, 133), Color.FromRgb(127, 132, 133), 8));

            diagram.AddConnector(DrawConnector(node2, node3, node2.Ports[2], node3.Ports[0], SegmentType.OrthoSegment, Color.FromRgb(127, 132, 133), StrokeStyle.Default, DecoratorType.Filled45Arrow, Color.FromRgb(127, 132, 133), Color.FromRgb(127, 132, 133), 8));

            diagram.AddConnector(DrawConnector(node3, node4, node3.Ports[2], node4.Ports[0], SegmentType.OrthoSegment, Color.FromRgb(127, 132, 133), StrokeStyle.Default, DecoratorType.Filled45Arrow, Color.FromRgb(127, 132, 133), Color.FromRgb(127, 132, 133), 8));

            diagram.AddConnector(DrawConnector(node4, node5, node4.Ports[2], node5.Ports[0], SegmentType.OrthoSegment, Color.FromRgb(127, 132, 133), StrokeStyle.Default, DecoratorType.Filled45Arrow, Color.FromRgb(127, 132, 133), Color.FromRgb(127, 132, 133), 8));

            diagram.AddConnector(DrawConnector(node6, node1, node6.Ports[0], node1.Ports[3], SegmentType.StraightSegment, Color.FromRgb(127, 132, 133), StrokeStyle.Dashed, DecoratorType.Filled45Arrow, Color.FromRgb(127, 132, 133), Color.FromRgb(127, 132, 133), 8));

            diagram.AddConnector(DrawConnector(node8, node1, node8.Ports[0], node1.Ports[1], SegmentType.StraightSegment, Color.FromRgb(127, 132, 133), StrokeStyle.Dashed, DecoratorType.Filled45Arrow, Color.FromRgb(127, 132, 133), Color.FromRgb(127, 132, 133), 8));

            diagram.AddConnector(DrawConnector(node7, node2, node7.Ports[0], node2.Ports[3], SegmentType.StraightSegment, Color.Black, StrokeStyle.Default, DecoratorType.Square, Color.Black, Color.Black, 6));

            diagram.AddConnector(DrawConnector(node7, node3, node7.Ports[1], node3.Ports[3], SegmentType.StraightSegment, Color.Black, StrokeStyle.Default, DecoratorType.Square, Color.Black, Color.Black, 6));

            diagram.AddConnector(DrawConnector(node7, node4, node7.Ports[2], node4.Ports[3], SegmentType.StraightSegment, Color.Black, StrokeStyle.Default, DecoratorType.Square, Color.Black, Color.Black, 6));

            diagram.AddConnector(DrawConnector(node7, node5, node7.Ports[3], node5.Ports[3], SegmentType.StraightSegment, Color.Black, StrokeStyle.Default, DecoratorType.Square, Color.Black, Color.Black, 6));

            diagram.AddConnector(DrawConnector(node9, node2, node9.Ports[0], node2.Ports[1], SegmentType.StraightSegment, Color.Black, StrokeStyle.Default, DecoratorType.Circle, Color.Black, Color.Black, 6));

            diagram.AddConnector(DrawConnector(node9, node3, node9.Ports[1], node3.Ports[1], SegmentType.StraightSegment, Color.Black, StrokeStyle.Default, DecoratorType.Circle, Color.Black, Color.Black, 6));

            diagram.AddConnector(DrawConnector(node9, node4, node9.Ports[2], node4.Ports[1], SegmentType.StraightSegment, Color.Black, StrokeStyle.Default, DecoratorType.Circle, Color.Black, Color.Black, 6));

            diagram.AddConnector(DrawConnector(node9, node5, node9.Ports[3], node5.Ports[1], SegmentType.StraightSegment, Color.Black, StrokeStyle.Default, DecoratorType.Circle, Color.Black, Color.Black, 6));

            diagram.AddNode(labelnode9);
            diagram.Loaded += Diagram_Loaded;
        }
        private void Diagram_Loaded(object sender)
        {
            diagram.BringToView(diagram.Nodes[0]);
        }

        Node DrawNode(float x, float y, float w, float h, ShapeType shape)
        {
            var node = new Node();
            node.OffsetX = x;
            node.OffsetY = y;
            node.Width = w;
            node.Height = h;
            node.ShapeType = shape;
            node.Style.StrokeWidth = 1 * DiagramUtility.factor;
            node.Style.Brush = new SolidBrush(Color.FromRgb(255, 129, 0));
            node.Ports.Add(new Port() { NodeOffsetX = 0.5, NodeOffsetY = 0, IsVisible = false });
            node.Ports.Add(new Port() { NodeOffsetX = 1, NodeOffsetY = 0.5, IsVisible = false });
            node.Ports.Add(new Port() { NodeOffsetX = 0.5, NodeOffsetY = 1, IsVisible = false });
            node.Ports.Add(new Port() { NodeOffsetX = 0, NodeOffsetY = 0.5, IsVisible = false });
            return node;
        }
        Connector DrawConnector(Node Src, Node Trgt, Port srcport, Port trgtport, SegmentType type, Color strokeColor, StrokeStyle style, DecoratorType decorator, Color fillColor, Color strokeFill, float sw)
        {
            var Conn = new Connector();
            Conn.SourceNode = Src;
            Conn.TargetNode = Trgt;
            Conn.SourcePort = srcport;
            Conn.TargetPort = trgtport;
            Conn.SegmentType = type;
            Conn.TargetDecoratorType = decorator;
            Conn.TargetDecoratorStyle.Fill = fillColor;
            Conn.TargetDecoratorStyle.Stroke = strokeFill;
            Conn.Style.StrokeWidth = 1 * DiagramUtility.factor;
            Conn.Style.StrokeBrush = new SolidBrush(strokeColor);
            Conn.Style.StrokeStyle = style;
            Conn.TargetDecoratorStyle.Width = sw * DiagramUtility.factor;
            Conn.TargetDecoratorStyle.StrokeThickness = 1 * DiagramUtility.factor;
            return Conn;
        }
        Node DrawCustomShape(float x, float y)
        {
            var node = new Node();
            if (Device.RuntimePlatform == Device.Android)
            {
                node.Width = 50 * DiagramUtility.factor; node.Height = 40 * DiagramUtility.factor;
            }
            else
                node.Width = node.Height = 40 * DiagramUtility.factor;
            node.OffsetX = x * DiagramUtility.factor; node.OffsetY = y * DiagramUtility.factor;
            if (Device.RuntimePlatform == Device.UWP)
            {
                node.Style.Brush = new SolidBrush(Color.Transparent);
                node.Style.StrokeBrush = new SolidBrush(Color.FromRgb(24, 161, 237));
                node.Style.StrokeWidth = 3 * DiagramUtility.factor;
            }
            SfGraphicsPath sfpath4 = new SfGraphicsPath();
            SfGraphics grap = new SfGraphics();
            Pen stroke = new Pen();
            stroke.Brush = new SolidBrush(Color.Transparent);
            stroke.StrokeWidth = 3;
            stroke.StrokeBrush = new SolidBrush(Color.FromRgb(24, 161, 237));
            grap.DrawEllipse(stroke, new Rectangle(10, 0, 20, 20));
            if (Device.RuntimePlatform == Device.UWP)
                grap.DrawArc(stroke, 0, 20, 40, 40, 0, 180);
            else
                grap.DrawArc(stroke, 0, 20, 40, 40, 180, 180);
            node.UpdateSfGraphics(grap);
            return node;
        }

        StackLayout CreateLabel(string text, int Size)
        {
            StackLayout contentLayout = new StackLayout()
            {
                WidthRequest = 150,
                HeightRequest = 45,
                Orientation = StackOrientation.Vertical
            };
            var label = new Label();
            label.WidthRequest = 150;
            label.HeightRequest = 45;
            label.VerticalTextAlignment = TextAlignment.Center;
            label.HorizontalTextAlignment = TextAlignment.Center;
            label.Text = text;
            label.FontSize = Size;
            label.TextColor = Color.White;
            contentLayout.Children.Add(label);
            return contentLayout;
        }
    }
}