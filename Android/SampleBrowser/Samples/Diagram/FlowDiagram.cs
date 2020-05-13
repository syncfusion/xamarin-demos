#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;
using Syncfusion.SfDiagram.Android;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SampleBrowser
{
    public partial class FlowDiagram : SamplePage
    {
        SfDiagram diagram;
        private TextView label;
        private Switch snapToGridSwitch;
        private LinearLayout scrollLayout;
        internal static float currentDensity = 1;

        public override View GetSampleContent(Context context)
        {
            currentDensity = context.Resources.DisplayMetrics.Density;
            //Initialize the SfDiagram instance and set background.
            diagram = new SfDiagram(context);
            diagram.ContextMenuSettings.Visibility = false;
            diagram.BackgroundColor = Color.White;
            diagram.EnableTextEditing = false;
            //Create nodes and set the offset, size and other properties.
            Node n1 = new Node(context);
            n1.ShapeType = ShapeType.RoundedRectangle;
            n1.CornerRadius = 90 * MainActivity.Factor;
            n1.OffsetX = 185 * MainActivity.Factor;
            n1.OffsetY = 80 * MainActivity.Factor;
            n1.Width = 320 * MainActivity.Factor;
            n1.Height = 110 * MainActivity.Factor;
            n1.Style.Brush = new SolidBrush(Color.Rgb(49, 162, 255));
            n1.Style.StrokeBrush = new SolidBrush(Color.Rgb(23, 132, 206));
            TextView content1 = CreateLabel(context, "New idea identified", (int)n1.Width, Color.Rgb(255, 255, 255));
            n1.Annotations.Add(new Annotation() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Content = content1 });
            diagram.AddNode(n1);

            Node n2 = new Node(context);
            n2.OffsetX = 185 * MainActivity.Factor;
            n2.OffsetY = 280 * MainActivity.Factor;
            n2.Width = 320 * MainActivity.Factor;
            n2.Height = 110 * MainActivity.Factor;
            n2.ShapeType = ShapeType.RoundedRectangle;
            n2.CornerRadius = 15 * MainActivity.Factor;
            n2.Style.Brush = new SolidBrush(Color.Rgb(49, 162, 255));
            n2.Style.StrokeBrush = new SolidBrush(Color.Rgb(23, 132, 206));
            TextView content2 = CreateLabel(context, "Meeting With Boards", (int)n2.Width, Color.Rgb(255, 255, 255));
            n2.Annotations.Add(new Annotation() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Content = content2 });
            diagram.AddNode(n2);

            Node n3 = new Node(context);
            n3.ShapeType = ShapeType.Diamond;
            n3.OffsetX = 195 * MainActivity.Factor;
            n3.OffsetY = 480 * MainActivity.Factor;
            n3.Width = 300 * MainActivity.Factor;
            n3.Height = 300 * MainActivity.Factor;
            n3.Style.Brush = new SolidBrush(Color.Rgb(0, 194, 192));
            n3.Style.StrokeBrush = new SolidBrush(Color.Rgb(4, 142, 135));
            TextView content3 = CreateLabel(context, "Board decides" + "\n" + "whether to" + "\n" + "proceed", (int)n3.Width, Color.Rgb(255, 255, 255));
            n3.Annotations.Add(new Annotation() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Content = content3 });
            diagram.AddNode(n3);

            Node n4 = new Node(context);
            n4.ShapeType = ShapeType.Diamond;
            n4.OffsetX = 195 * MainActivity.Factor;
            n4.OffsetY = 870 * MainActivity.Factor;
            n4.Width = 300 * MainActivity.Factor;
            n4.Height = 300 * MainActivity.Factor;
            n4.Style.Brush = new SolidBrush(Color.Rgb(0, 194, 192));
            n4.Style.StrokeBrush = new SolidBrush(Color.Rgb(4, 142, 135));
            TextView content4 = CreateLabel(context, "Find Project" + "\n" + "Manager, write" + "\n" + "specification", (int)n4.Width, Color.Rgb(255, 255, 255));
            n4.Annotations.Add(new Annotation() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Content = content4 });
            diagram.AddNode(n4);

            Node n5 = new Node(context);
            n5.Style.Brush = new SolidBrush(Color.Rgb(49, 162, 255));
            n5.Style.StrokeBrush = new SolidBrush(Color.Rgb(23, 132, 206));
            n5.OffsetX = 185 * MainActivity.Factor;
            n5.OffsetY = 1260 * MainActivity.Factor;
            n5.Width = 320 * MainActivity.Factor;
            n5.Height = 110 * MainActivity.Factor;
            n5.ShapeType = ShapeType.RoundedRectangle;
            n5.CornerRadius = 90 * MainActivity.Factor;
            TextView content5 = CreateLabel(context, "Implement and deliver", (int)n5.Width, Color.Rgb(255, 255, 255));
            n5.Annotations.Add(new Annotation() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Content = content5 });
            diagram.AddNode(n5);

            Node n6 = new Node(context);
            n6.Style.Brush = new SolidBrush(Color.Rgb(239, 75, 93));
            n6.Style.StrokeBrush = new SolidBrush(Color.Rgb(201, 32, 61));
            n6.OffsetX = 674 * MainActivity.Factor;
            n6.OffsetY = 575 * MainActivity.Factor;
            n6.Width = 320 * MainActivity.Factor;
            n6.Height = 110 * MainActivity.Factor;
            n6.ShapeType = ShapeType.RoundedRectangle;
            n6.CornerRadius = 15 * MainActivity.Factor;
            TextView content6 = CreateLabel(context, "Reject and report the reason", (int)n6.Width, Color.Rgb(255, 255, 255));
            n6.Annotations.Add(new Annotation() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Content = content6 });
            diagram.AddNode(n6);

            Node n7 = new Node(context);
            n7.Style.Brush = new SolidBrush(Color.Rgb(239, 75, 93));
            n7.Style.StrokeBrush = new SolidBrush(Color.Rgb(201, 32, 61));
            n7.OffsetX = 674 * MainActivity.Factor;
            n7.OffsetY = 965.599f * MainActivity.Factor;
            n7.Width = 320 * MainActivity.Factor;
            n7.Height = 110 * MainActivity.Factor;
            n7.ShapeType = ShapeType.RoundedRectangle;
            n7.CornerRadius = 15 * MainActivity.Factor;
            TextView content7 = CreateLabel(context, "Hire new resources", (int)n7.Width, Color.Rgb(255, 255, 255));
            n7.Annotations.Add(new Annotation() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Content = content7 });
            diagram.AddNode(n7);

            //Create connector with its source and target node.
            Connector c1 = new Connector(context, n1, n2);
            diagram.AddConnector(c1);

            Connector c2 = new Connector(context, n2, n3);
            diagram.AddConnector(c2);

            Connector c3 = new Connector(context, n3, n4);
            //Create label for the connector.
            c3.Annotations.Add(new Annotation() { Content = "Yes", HorizontalAlignment = HorizontalAlignment.Left, FontSize = 20 * MainActivity.Factor, TextBrush = new SolidBrush(Color.Rgb(127, 132, 133)) });
            diagram.AddConnector(c3);

            Connector c4 = new Connector(context, n4, n5);
            c4.Annotations.Add(new Annotation() { Content = "Yes", HorizontalAlignment = HorizontalAlignment.Left, FontSize = 20 * MainActivity.Factor, TextBrush = new SolidBrush(Color.Rgb(127, 132, 133)) });
            diagram.AddConnector(c4);
            diagram.IsReadOnly = false;
            Connector c5 = new Connector(context, n3, n6);
            c5.Annotations.Add(new Annotation() { Content = "No", FontSize = 20 * MainActivity.Factor, TextBrush = new SolidBrush(Color.Rgb(127, 132, 133)) });
            diagram.AddConnector(c5);

            Connector c6 = new Connector(context, n4, n7);
            c6.Annotations.Add(new Annotation() { Content = "No", FontSize = 20 * MainActivity.Factor, TextBrush = new SolidBrush(Color.Rgb(127, 132, 133)) });
            diagram.AddConnector(c6);

            //Set the stroke color for the connector.
            for (int i = 0; i < diagram.Connectors.Count; i++)
            {
                //Diagram.Connectors[i].TargetDecoratorType = DecoratorType.None;
                diagram.Connectors[i].Style.StrokeBrush = new SolidBrush(Color.Rgb(127, 132, 133));
                diagram.Connectors[i].TargetDecoratorStyle.Fill = (Color.Rgb(127, 132, 133));
                diagram.Connectors[i].TargetDecoratorStyle.StrokeColor = (Color.Rgb(127, 132, 133));
                diagram.Connectors[i].TargetDecoratorStyle.StrokeWidth = 4 * MainActivity.Factor;
                diagram.Connectors[i].TargetDecoratorStyle.Size = 14 * MainActivity.Factor;
                diagram.Connectors[i].Style.StrokeWidth = 2 * MainActivity.Factor;
            }
            //Set the stroke size for node.
            for (int i = 0; i < diagram.Nodes.Count; i++)
            {
                diagram.Nodes[i].Style.StrokeWidth = 1;
            }
            diagram.Loaded += Diagram_Loaded;
            diagram.ConnectorClicked += Diagram_ConnectorClicked;
            diagram.PageSettings.GridSize = 12 * currentDensity;
            diagram.PageSettings.GridColor = Color.Rgb(230, 230, 230);
            return diagram;
        }

        private void Diagram_Loaded(object sender)
        {
            diagram.BringToView(diagram.Nodes[0]);
            HideSelectors();
        }

        private void HideSelectors()
        {
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
        }

        private void Diagram_ConnectorClicked(object sender, ConnectorClickedEventArgs args)
        {
            diagram.ClearSelection();
        }

        public override void Destroy()
        {
            if (diagram != null)
                diagram.Dispose();
            base.Destroy();
        }


        public override View GetPropertyWindowLayout(Context context)
        {
            LinearLayout gridLinearLayout = new LinearLayout(context) { Orientation = Android.Widget.Orientation.Vertical };

            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);

            layoutParams.TopMargin = (int)(25 * currentDensity);
            gridLinearLayout.LayoutParameters = layoutParams;
            gridLinearLayout.SetBackgroundResource(Resource.Drawable.LinearLayout_Border);

            int width = (int)(context.Resources.DisplayMetrics.WidthPixels - context.Resources.DisplayMetrics.Density) / 3;

            LinearLayout linearLayout4 = new LinearLayout(context);
            linearLayout4.Orientation = Android.Widget.Orientation.Vertical;
            linearLayout4.SetMinimumHeight((int)(70 * currentDensity));
            linearLayout4.SetMinimumWidth(width);

            TextView selectText = new TextView(context)
            {
                Text = "Grid Color",
                Gravity = GravityFlags.Start,
                TextSize = 5 * currentDensity
            };
            selectText.SetMinimumHeight((int)(20 * currentDensity));
            selectText.SetWidth((int)(width * 0.4 * currentDensity));

            HorizontalScrollView horizontalScroll = new HorizontalScrollView(context);
            horizontalScroll.SetPadding(0, (int)(10 * currentDensity), 0, (int)(10 * currentDensity));
            horizontalScroll.FillViewport = true;
            horizontalScroll.HorizontalScrollBarEnabled = true;
            horizontalScroll.SetMinimumHeight((int)(60 * currentDensity));
            horizontalScroll.Layout(0, (int)(20 * currentDensity), (int)(80 * currentDensity * 14), (int)(60 * currentDensity));
            scrollLayout = new LinearLayout(context);
            scrollLayout.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
            horizontalScroll.AddView(scrollLayout);

            AddColors();

            linearLayout4.AddView(selectText);
            linearLayout4.AddView(horizontalScroll);

            LinearLayout linearLayout1 = new LinearLayout(context);
            linearLayout1.SetPadding(0, (int)(10 * currentDensity), 0, (int)(10 * currentDensity));
            linearLayout1.SetMinimumHeight((int)(30 * currentDensity));

            TextView showGrid = new TextView(context)
            {
                Text = "Show Grid",
                Gravity = GravityFlags.Start,
                TextSize = 5 * currentDensity
            };
            showGrid.SetMinimumHeight((int)(20 * currentDensity));
            showGrid.SetWidth((int)(width * 0.4 * currentDensity));

            Switch showGridSwitch = new Switch(context);
            showGridSwitch.CheckedChange += ShowGridSwitch_CheckedChange;
            showGridSwitch.Gravity = GravityFlags.Right;
            showGridSwitch.SetMinimumHeight((int)(20 * currentDensity));
            showGridSwitch.SetWidth((int)(width * 0.4 * currentDensity));

            linearLayout1.AddView(showGrid);
            linearLayout1.AddView(showGridSwitch);

            LinearLayout linearLayout2 = new LinearLayout(context);
            linearLayout2.SetPadding(0, (int)(10 * currentDensity), 0, (int)(10 * currentDensity));
            linearLayout2.SetMinimumHeight((int)(30 * currentDensity));

            TextView snapToGrid = new TextView(context)
            {
                Text = "Snap To Grid",
                Gravity = GravityFlags.Start,
                TextSize = 5 * currentDensity
            };
            snapToGrid.SetMinimumHeight((int)(20 * currentDensity));
            snapToGrid.SetWidth((int)(width * 0.4 * currentDensity));

            snapToGridSwitch = new Switch(context);
            snapToGridSwitch.Enabled = false;
            snapToGridSwitch.CheckedChange += SnapToGridSwitch_CheckedChange;
            snapToGridSwitch.Gravity = GravityFlags.Right;
            snapToGridSwitch.SetMinimumHeight((int)(20 * currentDensity));
            snapToGridSwitch.SetWidth((int)(width * 0.4 * currentDensity));

            linearLayout2.AddView(snapToGrid);
            linearLayout2.AddView(snapToGridSwitch);

            LinearLayout linearLayout3 = new LinearLayout(context);
            linearLayout3.SetPadding(0, (int)(10 * currentDensity), 0, (int)(10 * currentDensity));
            linearLayout3.SetMinimumHeight((int)(60 * currentDensity));

            TextView connectorSize = new TextView(context)
            {
                Text = "Size",
                Gravity = GravityFlags.CenterVertical,
                TextSize = 5 * currentDensity
            };
            connectorSize.SetMinimumHeight((int)(20 * currentDensity));
            connectorSize.SetWidth((int)(width * 0.4 * currentDensity));

            LinearLayout plusMinus = new LinearLayout(context);
            plusMinus.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.MatchParent);
            plusMinus.SetMinimumHeight((int)(40 * currentDensity));
            plusMinus.SetMinimumWidth((int)((width - (int)(width * 0.4)) * currentDensity));

            ImageButton minusButton = new ImageButton(context);
            minusButton.SetMinimumHeight((int)(20 * currentDensity));
            minusButton.Click += MinusButton_Click;
            string imageId = "diagramsub.png";
            if (imageId != null)
            {
                var imageData = LoadResource(imageId).ToArray();
                minusButton.SetImageBitmap(BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length));
            }
            plusMinus.AddView(minusButton);

            label = new TextView(context);
            label.Text = "12";
            label.TextAlignment = TextAlignment.Center;
            label.Gravity = GravityFlags.Center;
            label.SetMinimumHeight((int)(60 * currentDensity));
            label.SetWidth((int)(50 * currentDensity));
            plusMinus.AddView(label);

            ImageButton plusButton = new ImageButton(context);
            imageId = "diagramplus.png";
            plusButton.Click += PlusButton_Click;
            plusButton.TextAlignment = TextAlignment.ViewEnd;
            if (imageId != null)
            {
                var imageData = LoadResource(imageId).ToArray();
                plusButton.SetImageBitmap(BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length));
            }
            plusMinus.AddView(plusButton);

            linearLayout3.AddView(connectorSize);
            linearLayout3.AddView(plusMinus);

            gridLinearLayout.AddView(linearLayout4);
            gridLinearLayout.AddView(linearLayout1);
            gridLinearLayout.AddView(linearLayout2);
            gridLinearLayout.AddView(linearLayout3);

            return gridLinearLayout;
        }

        private void AddColors()
        {
            AddColor(Color.Red);
            AddColor(Color.Orange);
            AddColor(Color.Green);
            AddColor(Color.Blue);
            AddColor(Color.Purple);
            AddColor(Color.Aqua);
            AddColor(Color.Fuchsia);
            AddColor(Color.Gray);
            AddColor(Color.Lime);
            AddColor(Color.Maroon);
            AddColor(Color.Navy);
            AddColor(Color.Olive);
            AddColor(Color.Silver);
            AddColor(Color.Teal);
        }

        private void AddColor(Color color)
        {
            ColorCircle colorCircle = new ColorCircle(diagram.Context, color);
            colorCircle.Click += ColorCircle_Click;
            colorCircle.LayoutParameters = new ViewGroup.LayoutParams((int)(60 * currentDensity), (int)(60 * currentDensity));
            scrollLayout.AddView(colorCircle);
        }

        private void ColorCircle_Click(object sender, EventArgs e)
        {
            if (!diagram.PageSettings.ShowGrid) return;
            ColorCircle circle = (ColorCircle)sender;
            diagram.PageSettings.GridColor = circle.m_color;
            circle.Selected = true;
            circle.SetWillNotDraw(true);
            circle.SetWillNotDraw(false);
            for (int i = 0; i < scrollLayout.ChildCount; i++)
            {
                ColorCircle colorCircle = scrollLayout.GetChildAt(i) as ColorCircle;
                if (colorCircle.m_color.ToString().Equals(circle.m_color.ToString()))
                    continue;
                else if (colorCircle.Selected)
                {
                    colorCircle.Selected = false;
                    colorCircle.SetWillNotDraw(true);
                    colorCircle.SetWillNotDraw(false);
                }
            }
        }

        private void SnapToGridSwitch_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            diagram.PageSettings.SnapToGrid = e.IsChecked;
        }

        private void ShowGridSwitch_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            diagram.PageSettings.ShowGrid = e.IsChecked;
            snapToGridSwitch.Enabled = e.IsChecked;
            if (!e.IsChecked)
            {
                for (int i = 0; i < scrollLayout.ChildCount; i++)
                {
                    ColorCircle circle = scrollLayout.GetChildAt(i) as ColorCircle;
                    if (circle.Selected)
                    {
                        circle.Selected = false;
                        circle.SetWillNotDraw(true);
                        circle.SetWillNotDraw(false);
                    }
                }
                diagram.PageSettings.SnapToGrid = false;
                snapToGridSwitch.Checked = false;
            }
        }

        internal class ColorCircle : ViewGroup
        {
            internal Color m_color;

            internal ColorCircle(Context context, Color color) : base(context)
            {
                SetBackgroundColor(Color.Transparent);
                m_color = color;
            }

            internal new bool Selected { get; set; }

            protected override void OnLayout(bool changed, int l, int t, int r, int b)
            {
            }

            protected override void OnDraw(Canvas canvas)
            {
                Paint strokePaint = new Paint();
                strokePaint.SetStyle(Paint.Style.Stroke);
                strokePaint.StrokeWidth = 5 * currentDensity;
                Paint fillPaint = new Paint();
                fillPaint.Color = m_color;
                if (Selected)
                {
                    strokePaint.Color = Color.Rgb(30, 144, 255);
                    strokePaint.StrokeWidth = 5 * currentDensity;
                }
                else
                    strokePaint.Color = Color.White;
                fillPaint.SetStyle(Paint.Style.Fill);
                canvas.DrawCircle(Width / 2, Height / 2, Width / 3, strokePaint);
                canvas.DrawCircle(Width / 2, Height / 2, Width / 3, fillPaint);
                base.OnDraw(canvas);
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

        private void PlusButton_Click(object sender, EventArgs e)
        {
            int value = int.Parse(label.Text);
            if (value < 20)
            {
                diagram.PageSettings.GridSize = (value + 1) * currentDensity;
                label.Text = (value + 1).ToString();
            }
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            int value = int.Parse(label.Text);
            if (value > 5)
            {
                diagram.PageSettings.GridSize = (value - 1) * currentDensity;
                label.Text = (value - 1).ToString();
            }
        }

        internal static TextView CreateLabel(Context context, string text, int width, Color color)
        {
            //Create a text view and assign its properties.
            TextView label = new TextView(context);
            label.Typeface = Typeface.Create(".SF UI Text", TypefaceStyle.Normal);
            label.SetText(text, TextView.BufferType.Normal);
            label.SetTextSize(ComplexUnitType.Px, 28 * MainActivity.Factor);
            label.Gravity = GravityFlags.Center;
            int widthMeasureSpec = View.MeasureSpec.MakeMeasureSpec(
                (int)width, MeasureSpecMode.AtMost);
            int heightMeasureSpec = View.MeasureSpec.MakeMeasureSpec(
            0, MeasureSpecMode.Unspecified);

            label.Measure(widthMeasureSpec, heightMeasureSpec);
            label.Left = label.Top = 0;
            label.Bottom = label.MeasuredHeight;
            label.Right = label.MeasuredWidth;
            label.SetTextColor(color);
            return label;
        }
    }
}