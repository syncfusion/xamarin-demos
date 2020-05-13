#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfDiagram.XForms;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfDiagram
{
    public partial class DrawingTool : SampleView
    {
        public DrawingTool()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.Android)
                Xamarin.Forms.DependencyService.Get<IText>().GenerateFactor();
            diagram.IsReadOnly = true;
            Node n1 = DrawNode(145, 110, 100, 55, ShapeType.Rectangle, "Node1");
            if (Device.RuntimePlatform == Device.UWP)
            {
                n1.ShapeType = ShapeType.Rectangle;
            }
            n1.Style.Brush = new SolidBrush(Color.FromRgb(49, 162, 255));
            n1.Style.StrokeBrush = new SolidBrush(Color.FromRgb(23, 132, 206));
            PortCollection node1ports = new PortCollection();
            Port port1 = new Port() { Width = 10, Height = 10, NodeOffsetX = 0.5, NodeOffsetY = 0, ShapeType = ShapeType.Circle,IsVisible=true };
            Port port2 = new Port() { Width = 10, Height = 10, NodeOffsetX = 0, NodeOffsetY = 0.5, ShapeType = ShapeType.Circle ,IsVisible = true};
            Port port3 = new Port() { Width = 10, Height = 10, NodeOffsetX = 1, NodeOffsetY = 0.5, ShapeType = ShapeType.Circle ,IsVisible = true};
            Port port4 = new Port() { Width = 10, Height = 10, NodeOffsetX = 0.5, NodeOffsetY = 1, ShapeType = ShapeType.Circle ,IsVisible = true};
            node1ports.Add(port1);
            node1ports.Add(port2);
            node1ports.Add(port3);
            node1ports.Add(port4);
            n1.Ports = node1ports;
            Node n2 = DrawNode(30, 260, 100, 55, ShapeType.Rectangle, "Node2");
            if (Device.RuntimePlatform == Device.UWP)
            {
                n2.ShapeType = ShapeType.Rectangle;
            }
            n2.Style.Brush = new SolidBrush(Color.FromRgb(239, 75, 93));
            n2.Style.StrokeBrush = new SolidBrush(Color.FromRgb(201, 32, 61));
            PortCollection node2ports = new PortCollection();
            Port port5 = new Port() { Width = 10, Height = 10, NodeOffsetX = 0.5, NodeOffsetY = 0, ShapeType = ShapeType.Circle, IsVisible = true };
            Port port6 = new Port() { Width = 10, Height = 10, NodeOffsetX = 0, NodeOffsetY = 0.5, ShapeType = ShapeType.Circle, IsVisible = true };
            Port port7 = new Port() { Width = 10, Height = 10, NodeOffsetX = 1, NodeOffsetY = 0.5, ShapeType = ShapeType.Circle, IsVisible = true };
            Port port8 = new Port() { Width = 10, Height = 10, NodeOffsetX = 0.5, NodeOffsetY = 1, ShapeType = ShapeType.Circle, IsVisible = true };
            node2ports.Add(port5);
            node2ports.Add(port6);
            node2ports.Add(port7);
            node2ports.Add(port8);
            n2.Ports = node2ports;
            Node n3 = DrawNode(260, 260, 100, 55, ShapeType.Rectangle, "Node3");
            if (Device.RuntimePlatform == Device.UWP)
            {
                n3.ShapeType = ShapeType.Rectangle;
            }
            n3.Style.Brush = new SolidBrush(Color.FromRgb(0, 194, 192));
            n3.Style.StrokeBrush = new SolidBrush(Color.FromRgb(14, 142, 135));
            PortCollection node3ports = new PortCollection();
            Port port9 = new Port() { Width = 10, Height = 10, NodeOffsetX = 0.5, NodeOffsetY = 0, ShapeType = ShapeType.Circle, IsVisible = true };
            Port port10 = new Port() { Width = 10, Height = 10, NodeOffsetX = 0, NodeOffsetY = 0.5, ShapeType = ShapeType.Circle, IsVisible = true };
            Port port11 = new Port() { Width = 10, Height = 10, NodeOffsetX = 1, NodeOffsetY = 0.5, ShapeType = ShapeType.Circle, IsVisible = true };
            Port port12 = new Port() { Width = 10, Height = 10, NodeOffsetX = 0.5, NodeOffsetY = 1, ShapeType = ShapeType.Circle, IsVisible = true };
            node3ports.Add(port9);
            node3ports.Add(port10);
            node3ports.Add(port11);
            node3ports.Add(port12);
            n3.Ports = node3ports;
            Connector con1 = new Connector() { SourcePort = port4, TargetPort = port5 ,SegmentType=SegmentType.StraightSegment,TargetDecoratorType=DecoratorType.None};
            Connector con2 = new Connector() { SourcePort = port4, TargetPort = port9 ,SegmentType = SegmentType.StraightSegment,TargetDecoratorType = DecoratorType.None};
            Connector con3 = new Connector() { SourcePort = port7, TargetPort = port10 ,SegmentType = SegmentType.StraightSegment,TargetDecoratorType = DecoratorType.None};
            diagram.AddNode(n1);
            diagram.AddNode(n2);
            diagram.AddNode(n3);
            diagram.AddConnector(con1);
            diagram.AddConnector(con2);
            diagram.AddConnector(con3);

        }

        //Creates the Node with Specified input
        private Node DrawNode(float x, float y, float w, float h, ShapeType shape, string annotation)
        {
            var node = new Node();
            node.Style.StrokeWidth = 1;
            if (Device.RuntimePlatform == Device.Android)
            {
                node.OffsetX = x * DiagramUtility.factor;
                node.OffsetY = y * DiagramUtility.factor;
                node.Width = w * DiagramUtility.factor;
                node.Height = h * DiagramUtility.factor;
            }
            else
            {
                node.OffsetX = x;
                node.OffsetY = y;
                node.Width = w;
                node.Height = h;
            }
            node.ShapeType = shape;

            if (Device.RuntimePlatform == Device.Android)
            {
                node.Annotations.Add(new Annotation()
                {
                    Content = annotation,
                    TextBrush = new SolidBrush(Color.White),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 13 * DiagramUtility.factor
                });
            }
            else
            {
                node.Annotations.Add(new Annotation()
                {
                    Content = annotation,
                    TextBrush = new SolidBrush(Color.FromRgb(255, 255, 255)),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 13 * DiagramUtility.factor
                });
            }
            return node;
        }

        void None_Clicked(object sender, System.EventArgs e)
        {
            diagram.IsReadOnly = true;
            diagram.DrawingMode = DrawingMode.None;
            ColorChange(Color.DodgerBlue, Color.White, Color.White);
        }

        void Connector_Clicked(object sender, System.EventArgs e)
        {
            diagram.IsReadOnly = false;
			diagram.ClearSelection();
            diagram.DrawingMode = DrawingMode.Connector;
            ColorChange(Color.White, Color.DodgerBlue, Color.White);
        }

        void Textnode_Clicked(object sender, System.EventArgs e)
        {
            diagram.IsReadOnly = false;
			diagram.ClearSelection();
            diagram.DrawingMode = DrawingMode.TextNode;
            ColorChange(Color.White, Color.White, Color.DodgerBlue);
        }
        void ColorChange(Color none, Color connectortool, Color textnode)
        {
            if (none == Color.DodgerBlue)
            {
                None.Image = "PointerW";
                Connector.Image = "ConnectorTool1";
                Textnode.Image = "TextNodeNormal";
            }
            else if(connectortool==Color.DodgerBlue)
            {
                Connector.Image = "ConnectorToolW";
                None.Image = "Pointer1";
                Textnode.Image = "TextNodeNormal";
            }
            else if(textnode == Color.DodgerBlue)
            {
                Textnode.Image = "TextNodeW";
                Connector.Image = "ConnectorTool1";
                None.Image = "Pointer1";
            }
            None.BackgroundColor = none;
            Connector.BackgroundColor = connectortool;
            Textnode.BackgroundColor = textnode;
        }
    }
}
