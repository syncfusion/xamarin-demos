#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Syncfusion.SfDiagram.Android;

namespace SampleBrowser
{
    public partial class NodeAnnotation : SamplePage
    {
        SfDiagram diagram;
        private const float DefaultToolbarHeight = 0f;
        private Context m_context;

        public override View GetSampleContent(Context context)
        {
            m_context = context;
            //Initialize the SfDiagram and set its background color.
            diagram = new SfDiagram(context);
            diagram.EnableSelection = false;
            diagram.BackgroundColor = Color.White;
            //Initialize the nodes and set its properties.
            var node1 = DrawNode(280 * 2 * MainActivity.Factor, 140 * 2 * MainActivity.Factor, 175 * 2 * MainActivity.Factor, 70 * 2 * MainActivity.Factor, ShapeType.RoundedRectangle);
            node1.Style.StrokeBrush = new SolidBrush(Color.Rgb(206, 98, 9));
            node1.Annotations.Add(new Annotation() { Content = FlowDiagram.CreateLabel(context, "Establish Project" + "\n" + "and Team", (int)node1.Width, Color.White), HorizontalAlignment = HorizontalAlignment.Center });
            diagram.AddNode(node1);

            var node2 = DrawNode(280 * 2 * MainActivity.Factor, node1.OffsetY + (140 * 2 * MainActivity.Factor), 175 * 2 * MainActivity.Factor, 70 * 2 * MainActivity.Factor, ShapeType.RoundedRectangle);
            node2.Style.StrokeBrush = new SolidBrush(Color.Rgb(206, 98, 9));
            node2.Style.Brush = new LinearGradientBrush(0, 30, 150, 30, new Color[] { Color.Rgb(255, 130, 0), Color.Rgb(255, 37, 0) }, null, GradientDrawingOptions.Clamp);
            node2.Style.StrokeWidth = 0;
            node2.Annotations.Add(new Annotation() { Content = FlowDiagram.CreateLabel(context, "Define Scope", (int)node2.Width, Color.White), HorizontalAlignment = HorizontalAlignment.Center });
            diagram.AddNode(node2);

            var node3 = DrawNode(280 * 2 * MainActivity.Factor, node2.OffsetY + (140 * 2 * MainActivity.Factor), 175 * 2 * MainActivity.Factor, 70 * 2 * MainActivity.Factor, ShapeType.RoundedRectangle);
            node3.Style.StrokeBrush = new SolidBrush(Color.Rgb(206, 98, 9));
            node3.Style.StrokeStyle = StrokeStyle.Dashed;
            node3.Annotations.Add(new Annotation() { Content = FlowDiagram.CreateLabel(context, "Analyze process As-Is", (int)node3.Width, Color.White), HorizontalAlignment = HorizontalAlignment.Center });
            diagram.AddNode(node3);

            var node4 = DrawNode(280 * 2 * MainActivity.Factor, node3.OffsetY + (140 * 2 * MainActivity.Factor), 175 * 2 * MainActivity.Factor, 70 * 2 * MainActivity.Factor, ShapeType.RoundedRectangle);
            node4.Style.StrokeBrush = new SolidBrush(Color.Rgb(206, 98, 9));
            node4.Style.StrokeWidth = 0;
            node4.Annotations.Add(new Annotation() { Content = FlowDiagram.CreateLabel(context, "Identify" + "\n" + "opportunities" + "\n" + "for improvement", (int)node4.Width, Color.White), HorizontalAlignment = HorizontalAlignment.Center });
            diagram.AddNode(node4);

            var node5 = DrawNode(280 * 2 * MainActivity.Factor, node4.OffsetY + (140 * 2 * MainActivity.Factor), 175 * 2 * MainActivity.Factor, 70 * 2 * MainActivity.Factor, ShapeType.RoundedRectangle);
            node5.Style.StrokeBrush = new SolidBrush(Color.Rgb(206, 98, 9));
            node5.Style.StrokeWidth = 0;
            node5.Annotations.Add(new Annotation() { Content = FlowDiagram.CreateLabel(context, "Design and" + "\n" + "implement improved" + "\n" + "processess", (int)node5.Width, Color.White), HorizontalAlignment = HorizontalAlignment.Center });
            diagram.AddNode(node5);

            var node6 = DrawCustomShape(53 * 2, 155 * 2);
            node6.Ports.Add(new Port() { NodeOffsetX = 1, NodeOffsetY = 0.5, IsVisible = false });
            diagram.AddNode(node6);
            var labelnode6 = new Node(context);
            labelnode6.OffsetX = 37.5f * 2 * MainActivity.Factor;
            labelnode6.OffsetY = 200 * 2 * MainActivity.Factor;
            labelnode6.Width = 80 * 2 * MainActivity.Factor;
            labelnode6.Height = 35 * 2 * MainActivity.Factor;
            labelnode6.Annotations.Add(new Annotation() { Content = "Sponsor", FontSize = 28 * MainActivity.Factor, HorizontalAlignment = HorizontalAlignment.Center });
            labelnode6.Style = new Style()
            {
                StrokeBrush = new SolidBrush(Color.Transparent),
                Brush = new SolidBrush(Color.Transparent)
            };
            diagram.AddNode(labelnode6);

            var node7 = DrawCustomShape(53 * 2, 497 * 2);
            node7.Ports.Add(new Port() { NodeOffsetX = 1, NodeOffsetY = 0, IsVisible = false });
            node7.Ports.Add(new Port() { NodeOffsetX = 1, NodeOffsetY = 0.3, IsVisible = false });
            node7.Ports.Add(new Port() { NodeOffsetX = 1, NodeOffsetY = 0.6, IsVisible = false });
            node7.Ports.Add(new Port() { NodeOffsetX = 1, NodeOffsetY = 1, IsVisible = false });
            diagram.AddNode(node7);
            var labelnode7 = new Node(context);
            labelnode7.OffsetX = 55 * 2 * MainActivity.Factor;
            labelnode7.OffsetY = 545 * 2 * MainActivity.Factor;
            labelnode7.Width = 60 * 2 * MainActivity.Factor;
            labelnode7.Height = 50 * 2 * MainActivity.Factor;
            labelnode7.Annotations.Add(new Annotation() { Content = "Domain Experts", FontSize = 28 * MainActivity.Factor, HorizontalAlignment = HorizontalAlignment.Center });
            labelnode7.Style = new Style()
            {
                StrokeBrush = new SolidBrush(Color.Transparent),
                Brush = new SolidBrush(Color.Transparent)
            };
            diagram.AddNode(labelnode7);

            var node8 = DrawCustomShape(590 * 2, 155 * 2);
            node8.Ports.Add(new Port() { NodeOffsetX = 0, NodeOffsetY = 0.5, IsVisible = false });
            diagram.AddNode(node8);
            var labelnode8 = new Node(context);
            labelnode8.OffsetX = 590.5f * 2 * MainActivity.Factor;
            labelnode8.OffsetY = 200 * 2 * MainActivity.Factor;
            labelnode8.Width = 78 * 2 * MainActivity.Factor;
            labelnode8.Height = 49 * 2 * MainActivity.Factor;
            labelnode8.Annotations.Add(new Annotation() { Content = "Project Manager", FontSize = 28 * MainActivity.Factor, HorizontalAlignment = HorizontalAlignment.Center });
            labelnode8.Style = new Style()
            {
                StrokeBrush = new SolidBrush(Color.Transparent),
                Brush = new SolidBrush(Color.Transparent)
            };
            diagram.AddNode(labelnode8);

            var node9 = DrawCustomShape(590 * 2, 497 * 2);
            node9.Ports.Add(new Port() { NodeOffsetX = 0, NodeOffsetY = 0, IsVisible = false });
            node9.Ports.Add(new Port() { NodeOffsetX = 0, NodeOffsetY = 0.3, IsVisible = false });
            node9.Ports.Add(new Port() { NodeOffsetX = 0, NodeOffsetY = 0.6, IsVisible = false });
            node9.Ports.Add(new Port() { NodeOffsetX = 0, NodeOffsetY = 1, IsVisible = false });
            diagram.AddNode(node9);
            var labelnode9 = new Node(context);

            labelnode9.OffsetX = 591 * 2 * MainActivity.Factor;
            labelnode9.OffsetY = 550 * 2 * MainActivity.Factor;
            labelnode9.Width = 65 * 2 * MainActivity.Factor;
            labelnode9.Height = 39 * 2 * MainActivity.Factor;
            labelnode9.Annotations.Add(new Annotation() { Content = "Business Analyst", FontSize = 28 * MainActivity.Factor, HorizontalAlignment = HorizontalAlignment.Center });
            labelnode9.Style = new Style()
            {
                StrokeBrush = new SolidBrush(Color.Transparent),
                Brush = new SolidBrush(Color.Transparent)
            };
            diagram.AddNode(labelnode9);

            diagram.AddConnector(DrawConnector(node1, node2, node1.Ports[2], node2.Ports[0], SegmentType.OrthoSegment, Color.Rgb(127, 132, 133), StrokeStyle.Default, DecoratorType.Filled45Arrow, Color.Rgb(127, 132, 133), Color.Rgb(127, 132, 133), 8));

            diagram.AddConnector(DrawConnector(node2, node3, node2.Ports[2], node3.Ports[0], SegmentType.OrthoSegment, Color.Rgb(127, 132, 133), StrokeStyle.Default, DecoratorType.Filled45Arrow, Color.Rgb(127, 132, 133), Color.Rgb(127, 132, 133), 8));

            diagram.AddConnector(DrawConnector(node3, node4, node3.Ports[2], node4.Ports[0], SegmentType.OrthoSegment, Color.Rgb(127, 132, 133), StrokeStyle.Default, DecoratorType.Filled45Arrow, Color.Rgb(127, 132, 133), Color.Rgb(127, 132, 133), 8));

            diagram.AddConnector(DrawConnector(node4, node5, node4.Ports[2], node5.Ports[0], SegmentType.OrthoSegment, Color.Rgb(127, 132, 133), StrokeStyle.Default, DecoratorType.Filled45Arrow, Color.Rgb(127, 132, 133), Color.Rgb(127, 132, 133), 8));

            diagram.AddConnector(DrawConnector(node6, node1, node6.Ports[0], node1.Ports[3], SegmentType.StraightSegment, Color.Rgb(127, 132, 133), StrokeStyle.Dashed, DecoratorType.Filled45Arrow, Color.Rgb(127, 132, 133), Color.Rgb(127, 132, 133), 8));

            diagram.AddConnector(DrawConnector(node8, node1, node8.Ports[0], node1.Ports[1], SegmentType.StraightSegment, Color.Rgb(127, 132, 133), StrokeStyle.Dashed, DecoratorType.Filled45Arrow, Color.Rgb(127, 132, 133), Color.Rgb(127, 132, 133), 8));

            diagram.AddConnector(DrawConnector(node7, node2, node7.Ports[0], node2.Ports[3], SegmentType.StraightSegment, Color.Black, StrokeStyle.Default, DecoratorType.Square, Color.Black, Color.Black, 6));

            diagram.AddConnector(DrawConnector(node7, node3, node7.Ports[1], node3.Ports[3], SegmentType.StraightSegment, Color.Black, StrokeStyle.Default, DecoratorType.Square, Color.Black, Color.Black, 6));

            diagram.AddConnector(DrawConnector(node7, node4, node7.Ports[2], node4.Ports[3], SegmentType.StraightSegment, Color.Black, StrokeStyle.Default, DecoratorType.Square, Color.Black, Color.Black, 6));

            diagram.AddConnector(DrawConnector(node7, node5, node7.Ports[3], node5.Ports[3], SegmentType.StraightSegment, Color.Black, StrokeStyle.Default, DecoratorType.Square, Color.Black, Color.Black, 6));

            diagram.AddConnector(DrawConnector(node9, node2, node9.Ports[0], node2.Ports[1], SegmentType.StraightSegment, Color.Black, StrokeStyle.Default, DecoratorType.Circle, Color.Black, Color.Black, 6));

            diagram.AddConnector(DrawConnector(node9, node3, node9.Ports[1], node3.Ports[1], SegmentType.StraightSegment, Color.Black, StrokeStyle.Default, DecoratorType.Circle, Color.Black, Color.Black, 6));

            diagram.AddConnector(DrawConnector(node9, node4, node9.Ports[2], node4.Ports[1], SegmentType.StraightSegment, Color.Black, StrokeStyle.Default, DecoratorType.Circle, Color.Black, Color.Black, 6));

            diagram.AddConnector(DrawConnector(node9, node5, node9.Ports[3], node5.Ports[1], SegmentType.StraightSegment, Color.Black, StrokeStyle.Default, DecoratorType.Circle, Color.Black, Color.Black, 6));
            diagram.Loaded += Diagram_Loaded;

            return diagram;
        }
        private void Diagram_Loaded(object sender)
        {
            diagram.BringToView(diagram.Nodes[0]);
        }

        public override void Destroy()
        {
            if (diagram != null)
                diagram.Dispose();
            base.Destroy();
        }

        //Creates the Node with Specified input
        Node DrawNode(float x, float y, float w, float h, ShapeType shape)
        {
            var node = new Node(m_context);
            node.OffsetX = x;
            node.OffsetY = y;
            node.Width = w;
            node.Height = h;
            node.ShapeType = shape;
            node.Style.StrokeWidth = 1 * 2 * MainActivity.Factor;
            node.CornerRadius = 30 * 2 * MainActivity.Factor;
            node.Style.Brush = new SolidBrush(Color.Rgb(255, 129, 0));
            node.Ports.Add(new Port() { NodeOffsetX = 0.5, NodeOffsetY = 0, IsVisible = false });
            node.Ports.Add(new Port() { NodeOffsetX = 1, NodeOffsetY = 0.5, IsVisible = false });
            node.Ports.Add(new Port() { NodeOffsetX = 0.5, NodeOffsetY = 1, IsVisible = false });
            node.Ports.Add(new Port() { NodeOffsetX = 0, NodeOffsetY = 0.5, IsVisible = false });
            return node;
        }

        Node DrawCustomShape(float x, float y)
        {
            var node = new Node(m_context);
            node.OffsetX = x * MainActivity.Factor;
            node.OffsetY = y * MainActivity.Factor;
            node.Width = 50 * 2 * MainActivity.Factor; node.Height = 40 * 2 * MainActivity.Factor;
            SfGraphics grap = new SfGraphics();
            Pen stroke = new Pen();
            stroke.Brush = new SolidBrush(Color.Transparent);
            stroke.StrokeWidth = 3 * MainActivity.Factor;
            stroke.StrokeBrush = new SolidBrush(Color.Rgb(24, 161, 237));
            grap.DrawEllipse(stroke, new System.Drawing.Rectangle(10, 0, 20, 20));
            grap.DrawArc(stroke, 0, 20, 40, 40, 180, 180);
            node.UpdateSfGraphics(grap);
            return node;
        }
        Connector DrawConnector(Node Src, Node Trgt, Port srcport, Port trgtport, SegmentType type, Color strokeColor, StrokeStyle style, DecoratorType decorator, Color fillColor, Color strokeFill, float sw)
        {
            var Conn = new Connector(m_context, Src, Trgt);
            Conn.SourcePort = srcport;
            Conn.TargetPort = trgtport;
            Conn.SegmentType = type;
            Conn.TargetDecoratorType = decorator;
            Conn.TargetDecoratorStyle.Fill = fillColor;
            Conn.TargetDecoratorStyle.StrokeColor = strokeFill;
            Conn.Style.StrokeWidth = 1 * 2 * MainActivity.Factor;
            Conn.Style.StrokeBrush = new SolidBrush(strokeColor);
            Conn.Style.StrokeStyle = style;
            Conn.TargetDecoratorStyle.Size = sw;
            Conn.TargetDecoratorStyle.StrokeWidth = 2 * 2 * MainActivity.Factor;
            return Conn;
        }
    }
}