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
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SampleBrowser
{
    public partial class Connectors : SamplePage
    {
        SfDiagram diagram;
        private Context m_context;
        private float currentDensity;
        private LinearLayout buttons;
        private TextView label;

        public override View GetSampleContent(Context context)
        {
            m_context = context;
            currentDensity = m_context.Resources.DisplayMetrics.Density;
            //Initialize the SfDiagram and set its background color.
            diagram = new SfDiagram(context);
            diagram.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            diagram.IsReadOnly = true;
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
            DirectedTreeLayout treelayout = new DirectedTreeLayout() { HorizontalSpacing = 80, VerticalSpacing = 50 * currentDensity, TreeOrientation = TreeOrientation.TopToBottom };
            diagram.LayoutManager = new LayoutManager() { Layout = treelayout };

            diagram.BeginNodeRender += Diagram_BeginNodeRender;

            diagram.Loaded += Diagram_Loaded;

            LinearLayout linearLayout = new LinearLayout(context) { Orientation = Android.Widget.Orientation.Vertical };
            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            layoutParams.TopMargin = 25 * (int)MainActivity.Factor;
            linearLayout.LayoutParameters = layoutParams;

            LinearLayout typesBar = new LinearLayout(context);
            typesBar.SetBackgroundColor(Color.Rgb(245, 245, 245));
            layoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            typesBar.SetMinimumHeight(200 * (int)MainActivity.Factor);
            typesBar.SetPadding(0, 10 * (int)MainActivity.Factor, 0, 10 * (int)MainActivity.Factor);
            TextView selectText = new TextView(context)
            {
                LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.MatchParent),
                Text = "Connector Types:",
                TextAlignment = TextAlignment.Gravity,
                Gravity = GravityFlags.Center | GravityFlags.CenterVertical,
                TextSize = 15 * MainActivity.Factor
            };
            int width = (int)(context.Resources.DisplayMetrics.WidthPixels - context.Resources.DisplayMetrics.Density);

            selectText.SetMinimumWidth((int)(width * 0.4 * MainActivity.Factor));

            ImageButtonView straightButton = new ImageButtonView(context);
            straightButton.Click += ButtonTouch;
            straightButton.ImageId = "DiagramStraight";
            straightButton.LayoutParameters = new ViewGroup.LayoutParams(180 * (int)MainActivity.Factor, 180 * (int)MainActivity.Factor);

            ImageView straightImage = new ImageView(context);
            var imageId = straightButton.ImageId + ".png";
            if (imageId != null)
            {
                var imageData = LoadResource(imageId).ToArray();
                straightImage.SetImageBitmap(BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length));
            }
            straightImage.Layout((int)(40 * MainActivity.Factor), (int)(40 * MainActivity.Factor), (int)(110 * MainActivity.Factor), (int)(110 * MainActivity.Factor));

            straightButton.AddView(straightImage);

            ImageButtonView curveButton = new ImageButtonView(context);
            curveButton.Click += ButtonTouch;
            curveButton.ImageId = "DiagramCurve";
            curveButton.LayoutParameters = new ViewGroup.LayoutParams(180 * (int)MainActivity.Factor, 180 * (int)MainActivity.Factor);

            ImageView curveImage = new ImageView(context);
            imageId = curveButton.ImageId + ".png";
            if (imageId != null)
            {
                var imageData = LoadResource(imageId).ToArray();
                curveImage.SetImageBitmap(BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length));
            }
            curveImage.Layout((int)(40 * MainActivity.Factor), (int)(40 * MainActivity.Factor), (int)(110 * MainActivity.Factor), (int)(110 * MainActivity.Factor));

            curveButton.AddView(curveImage);

            ImageButtonView edgeButton = new ImageButtonView(context);
            edgeButton.Click += ButtonTouch;
            edgeButton.LayoutParameters = new ViewGroup.LayoutParams(180 * (int)MainActivity.Factor, 180 * (int)MainActivity.Factor);
            edgeButton.ImageId = "DiagramEdge";

            ImageView edgeImage = new ImageView(context);
            imageId = edgeButton.ImageId + ".png";
            if (imageId != null)
            {
                var imageData = LoadResource(imageId).ToArray();
                edgeImage.SetImageBitmap(BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length));
            }
            edgeImage.Layout((int)(40 * MainActivity.Factor), (int)(40 * MainActivity.Factor), (int)(110 * MainActivity.Factor), (int)(110 * MainActivity.Factor));

            edgeButton.AddView(edgeImage);

            buttons = new LinearLayout(context);
            buttons.SetMinimumWidth((int)(width - width * 0.4 * MainActivity.Factor));
            buttons.SetBackgroundColor(Color.Transparent);
            buttons.AddView(straightButton);
            TextView view = new TextView(context);
            view.SetWidth(30 * (int)MainActivity.Factor);
            view.SetBackgroundColor(Color.Transparent);
            buttons.AddView(view);
            buttons.AddView(curveButton);
            view = new TextView(context);
            view.SetWidth(30 * (int)MainActivity.Factor);
            view.SetBackgroundColor(Color.Transparent);
            buttons.AddView(view);
            buttons.AddView(edgeButton);

            typesBar.AddView(selectText);
            typesBar.AddView(buttons);

            linearLayout.AddView(typesBar);
            linearLayout.AddView(diagram);
            for (int i = 0; i < diagram.Connectors.Count; i++)
            {
                diagram.Connectors[i].TargetDecoratorType = DecoratorType.None;
                diagram.Connectors[i].Style.StrokeWidth = 1;
            }
            return linearLayout;
        }

        private void Diagram_BeginNodeRender(object sender, BeginNodeRenderEventArgs args)
        {
            var node = args.Item;
            node.ShapeType = ShapeType.RoundedRectangle;
            node.Style.StrokeWidth = 0;
            if ((node.Content as Employee).Designation == "Manager")
                node.Style.Brush = new SolidBrush(Color.Rgb(23, 132, 206));
            else if ((node.Content as Employee).Designation == "CEO")
                node.Style.Brush = new SolidBrush(Color.Rgb(201, 32, 61));
            else if ((node.Content as Employee).Designation == "Team Lead" || (node.Content as Employee).Designation == "Co-ordinator")
                node.Style.Brush = new SolidBrush(Color.Rgb(4, 142, 135));
            else
                node.Style.Brush = new SolidBrush(Color.Rgb(206, 98, 9));

            node.Width = 144 * MainActivity.Factor;
            node.Height = 60 * MainActivity.Factor;
            AnnotationCollection annotations = new AnnotationCollection(node);
            annotations.Add(new Annotation() { Content = (node.Content as Employee).Designation, FontSize = 14 * MainActivity.Factor, TextBrush = new SolidBrush(Color.White) });
            node.Annotations = annotations;
        }

        private void ButtonTouch(object sender, EventArgs e)
        {
            ImageButtonView button = (ImageButtonView)sender;
            for (int i = 0; i < buttons.ChildCount; i++)
            {
                ImageButtonView imageButton = buttons.GetChildAt(i) as ImageButtonView;
                if (imageButton == null || imageButton.ImageId.TrimEnd('1').Equals(button.ImageId.TrimEnd('1')))
                    continue;
                else if (imageButton.ImageId.EndsWith("1", StringComparison.InvariantCulture))
                {
                    imageButton.ImageId = imageButton.ImageId.TrimEnd('1');
                    ImageView image = imageButton.GetChildAt(0) as ImageView;
                    string imageId = imageButton.ImageId + ".png";
                    if (imageId != null)
                    {
                        var imageData = LoadResource(imageId).ToArray();
                        image.SetImageBitmap(BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length));
                    }
                    imageButton.SetWillNotDraw(true);
                    imageButton.SetWillNotDraw(false);
                }
            }
            if (!button.ImageId.EndsWith("1", StringComparison.InvariantCulture))
            {
                SegmentType type = SegmentType.OrthoSegment;
                switch (button.ImageId)
                {
                    case "DiagramStraight":
                        type = SegmentType.StraightSegment;
                        break;
                    case "DiagramCurve":
                        type = SegmentType.CurveSegment;
                        break;
                }
                foreach (Connector connector in diagram.Connectors)
                    connector.SegmentType = type;
                button.ImageId = button.ImageId + "1";
                ImageView image = button.GetChildAt(0) as ImageView;
                string imageId = button.ImageId + ".png";
                if (imageId != null)
                {
                    var imageData = LoadResource(imageId).ToArray();
                    image.SetImageBitmap(BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length));
                }
                button.SetWillNotDraw(true);
                button.SetWillNotDraw(false);
            }
        }

        internal static MemoryStream LoadResource(string name)
        {
            MemoryStream aMem = new MemoryStream();

            var assm = Assembly.GetExecutingAssembly();

            var path = string.Format("SampleBrowser.Resources.drawable.{0}", name);

            var aStream = assm.GetManifestResourceStream(path);

            aStream.CopyTo(aMem);

            return aMem;
        }

        internal class ImageButtonView : ViewGroup
        {

            internal ImageButtonView(Context context) : base(context)
            {
                SetBackgroundColor(Color.Transparent);
            }

            public string ImageId { get; internal set; }

            protected override void OnDraw(Canvas canvas)
            {
                Paint strokePaint = new Paint();
                strokePaint.SetStyle(Paint.Style.Stroke);
                strokePaint.StrokeWidth = 5 * MainActivity.Factor;
                strokePaint.Color = Color.Black;
                canvas.DrawCircle(Width / 2, Height / 2, Width / 3, strokePaint);
                Paint fillPaint = new Paint();
                if (ImageId.EndsWith("1"))
                    fillPaint.Color = Color.Rgb(30, 144, 255);
                else
                    fillPaint.Color = Color.White;
                fillPaint.SetStyle(Paint.Style.Fill);
                canvas.DrawCircle(Width / 2, Height / 2, Width / 3, fillPaint);
                base.OnDraw(canvas);
            }

            protected override void OnLayout(bool changed, int l, int t, int r, int b)
            {

            }
        }

        public override View GetPropertyWindowLayout(Context context)
        {
            LinearLayout gridLinearLayout = new LinearLayout(context) { Orientation = Android.Widget.Orientation.Vertical };

            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);

            layoutParams.TopMargin = 25;
            gridLinearLayout.LayoutParameters = layoutParams;
            gridLinearLayout.SetBackgroundResource(Resource.Drawable.LinearLayout_Border);

            int width = (int)(context.Resources.DisplayMetrics.WidthPixels - context.Resources.DisplayMetrics.Density) / 3;

            LinearLayout linearLayout4 = new LinearLayout(context);

            linearLayout4.Orientation = Android.Widget.Orientation.Horizontal;
            linearLayout4.SetPadding(0, (int)(10 * currentDensity), 0, 0);

            TextView selectText = new TextView(context)
            {
                Text = "Connector Style",
                Gravity = GravityFlags.Start,
                TextSize = 5 * currentDensity
            };
            selectText.SetWidth((int)(width * 0.4 * currentDensity));

            Spinner spinner = new Spinner(context, SpinnerMode.Dialog);
            spinner.SetMinimumHeight((int)(20 * currentDensity));
            spinner.SetBackgroundColor(Color.Gray);
            spinner.DropDownWidth = (int)(200 * currentDensity);

            List<string> list = new List<string>();
            list.Add("Default");
            list.Add("Dashed");
            list.Add("Dotted");
            ArrayAdapter<string> dataAdapter = new ArrayAdapter<string>(context, Android.Resource.Layout.SimpleSpinnerItem, list);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = dataAdapter;
            spinner.ItemSelected += sType_spinner_ItemSelected;

            spinner.SetGravity(GravityFlags.Start);
            spinner.SetMinimumWidth(width - (int)(width * 0.4));

            linearLayout4.AddView(selectText);
            linearLayout4.AddView(spinner);

            LinearLayout linearLayout3 = new LinearLayout(context);
            linearLayout3.SetPadding(0, (int)(10 * currentDensity), 0, 0);
            linearLayout3.SetMinimumHeight((int)(40 * currentDensity));

            TextView connectorSize = new TextView(context)
            {
                Text = "Connector Size",
                Gravity = GravityFlags.CenterVertical,
                TextSize = 5 * currentDensity
            };
            connectorSize.SetMinimumHeight((int)(40 * currentDensity));
            connectorSize.SetWidth((int)(width * 0.4 * currentDensity));

            LinearLayout plusMinus = new LinearLayout(context);
            plusMinus.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.MatchParent);
            plusMinus.SetMinimumWidth(width - (int)(width * 0.4));

            ImageButton minusButton = new ImageButton(context);
            minusButton.SetMinimumHeight((int)(40 * currentDensity));
            minusButton.Click += MinusButton_Click;
            string imageId = "diagramsub.png";
            if (imageId != null)
            {
                var imageData = LoadResource(imageId).ToArray();
                minusButton.SetImageBitmap(BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length));
            }
            plusMinus.AddView(minusButton);

            label = new TextView(context);
            label.Text = "1";
            label.TextAlignment = TextAlignment.Center;
            label.Gravity = GravityFlags.Center;
            label.SetMinimumHeight((int)(40 * currentDensity));
            label.SetWidth((int)(40 * currentDensity));
            plusMinus.AddView(label);

            ImageButton plusButton = new ImageButton(context);
            imageId = "diagramplus.png";
            plusButton.Click += PlusButton_Click;
            plusButton.SetMinimumHeight((int)(40 * currentDensity));
            if (imageId != null)
            {
                var imageData = LoadResource(imageId).ToArray();
                plusButton.SetImageBitmap(BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length));
            }
            plusMinus.AddView(plusButton);

            linearLayout3.AddView(connectorSize);
            linearLayout3.AddView(plusMinus);

            gridLinearLayout.AddView(linearLayout4);
            gridLinearLayout.AddView(linearLayout3);

            return gridLinearLayout;

        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            int value = int.Parse(label.Text);
            if (value < 5)
            {
                foreach (Connector connector in diagram.Connectors)
                    connector.Style.StrokeWidth = (value + 1) * MainActivity.Factor;
                label.Text = (value + 1).ToString();
            }
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            int value = int.Parse(label.Text);
            if (value > 1)
            {
                foreach (Connector connector in diagram.Connectors)
                    connector.Style.StrokeWidth = (value - 1) * MainActivity.Factor;
                label.Text = (value - 1).ToString();
            }
        }

        void sType_spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string selectedItem = spinner.GetItemAtPosition(e.Position).ToString();
            StrokeStyle strokeStyle = StrokeStyle.Default;
            switch (selectedItem)
            {
                case "Default":
                    strokeStyle = StrokeStyle.Default;
                    break;
                case "Dashed":
                    strokeStyle = StrokeStyle.Dashed;
                    break;
                case "Dotted":
                    strokeStyle = StrokeStyle.Dotted;
                    break;
            }
            foreach (Connector connector in diagram.Connectors)
            {
                connector.Style.StrokeStyle = strokeStyle;
            }
        }

        void sType_spinner_ItemSelected1(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string selectedItem = spinner.GetItemAtPosition(e.Position).ToString();
            int strokeWidth = int.Parse(selectedItem);
            if (strokeWidth > 0)
            {
                foreach (Connector connector in diagram.Connectors)
                {
                    connector.Style.StrokeWidth = strokeWidth;
                }
            }
        }

        private Connector AddConnector(Node sourceNode, Node targetNode)
        {
            var c1 = new Connector(m_context);
            c1.SourceNode = sourceNode;
            c1.TargetNode = targetNode;
            c1.Style.StrokeWidth = 1 * currentDensity;
            c1.Style.StrokeBrush = new SolidBrush(Color.Rgb(127, 132, 133));
            c1.TargetDecoratorType = DecoratorType.None;
            return c1;
        }

        Node AddNode(int x, int y, string text, Color nodeColor)
        {
            Node node = new Node(m_context);
            node = new Node(x * MainActivity.Factor, y * MainActivity.Factor, 144 * MainActivity.Factor, 108 * MainActivity.Factor, m_context);
            node.ShapeType = ShapeType.RoundedRectangle;
            node.Style.StrokeWidth = 1;
            node.Style.Brush = new SolidBrush(nodeColor);
            node.Style.StrokeBrush = new SolidBrush(Color.Rgb(127, 132, 133));
            node.Annotations.Add(new Annotation() { Content = text, FontSize = 20 * MainActivity.Factor, TextBrush = new SolidBrush(Color.White) });
            return node;
        }

        public override void Destroy()
        {
            if (diagram != null)
                diagram.Dispose();
            base.Destroy();
        }

        private void Diagram_Loaded(object sender)
        {
            diagram.BringToView(diagram.Nodes[0]);
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

        public class Employee
        {
            public string ParentId { get; set; }
            public string Name { get; set; }
            public string Designation { get; set; }
            public string EmpId { get; set; }
        }
    }
}