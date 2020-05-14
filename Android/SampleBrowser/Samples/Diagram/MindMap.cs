#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Syncfusion.SfDiagram.Android;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Point = System.Drawing.Point;

namespace SampleBrowser
{
    public partial class MindMap : SamplePage
    {
        SfDiagram diagram;
        Node RootNode;
        UserHandleCollection DefaultHandles;
        UserHandleCollection RightSideHandle=null;
        UserHandleCollection LeftSideHandles=null;
        internal Node SelectedNode;
        UserHandlePosition CurrentHandle;
        Random rnd = new Random();
        AlertBox CommentBoxEntry;
        List<Color> FColor = new List<Color>();
        List<Color> SColor = new List<Color>();
        int index;
        float currentDensity = 1;
        private LinearLayout scrollLayout;
        List<NodeStyle> nodeStyleCollection = new List<NodeStyle>();
        LineStyle lineStyle;
        object objShape1 = ShapeType.RoundedRectangle;
        object objShape2 = ShapeType.RoundedRectangle;
        object objShape3 = ShapeType.RoundedRectangle;
        object objShape4 = ShapeType.RoundedRectangle;
        object objShape5 = ShapeType.RoundedRectangle;
        SegmentType segment = SegmentType.CurveSegment;
        string simpleCurveTree = "default";
        SfGraphics gra = new SfGraphics();
        List<Point> point = new List<Point>();
        DecoratorType Dectype = DecoratorType.None;
        Color connColor = Color.Gray;
        ApplyColorFrom connLineApplyColorFrom = ApplyColorFrom.TargetBorder;
        ApplyColorFrom connDecApplyColorFrom = ApplyColorFrom.TargetBorder;

        public override View GetSampleContent(Context context)
        {
            //Create SfDiagram.
            currentDensity = context.Resources.DisplayMetrics.Density;
            diagram = new SfDiagram(context);
            diagram.ContextMenuSettings.Visibility = false;

            int width = 150;
            int height = 75;
            width = (int)(125 * MainActivity.Factor);
            height = (int)(60 * MainActivity.Factor);
            var node = AddNode(300, 400, width, height, "Goals");
            AddNodeStyle(node, GetColor("#d0ebff"), GetColor("#81bfea"));
            RootNode = node;
            diagram.AddNode(node);

            SColor.Add(GetColor("#d1afdf"));
            SColor.Add(GetColor("#90C8C2"));
            SColor.Add(GetColor("#8BC1B7"));
            SColor.Add(GetColor("#E2C180"));
            SColor.Add(GetColor("#BBBFD6"));
            SColor.Add(GetColor("#ACCBAA"));
            FColor.Add(GetColor("#e9d4f1"));
            FColor.Add(GetColor("#d4efed"));
            FColor.Add(GetColor("#c4f2e8"));
            FColor.Add(GetColor("#f7e0b3"));
            FColor.Add(GetColor("#DEE2FF"));
            FColor.Add(GetColor("#E5FEE4"));

            var ch1node = AddNode(100, 100, width, height, "Financial");
            index = rnd.Next(5);
            AddNodeStyle(ch1node, FColor[index], SColor[index]);
            diagram.AddNode(ch1node);

            var ch1childnode = AddNode(100, 100, width, height, "Investment");
            AddNodeStyle(ch1childnode, (ch1node.Style.Brush as SolidBrush).FillColor, (ch1node.Style.StrokeBrush as SolidBrush).FillColor);
            diagram.AddNode(ch1childnode);

            var ch2node = AddNode(100, 600, width, height, "Social");
            index = rnd.Next(5);
            AddNodeStyle(ch2node, FColor[index], SColor[index]);
            diagram.AddNode(ch2node);

            var ch2childnode1 = AddNode(100, 100, width, height, "Friends");
            AddNodeStyle(ch2childnode1, (ch2node.Style.Brush as SolidBrush).FillColor, (ch2node.Style.StrokeBrush as SolidBrush).FillColor);
            diagram.AddNode(ch2childnode1);

            var ch2childnode2 = AddNode(100, 100, width, height, "Family");
            AddNodeStyle(ch2childnode2, (ch2node.Style.Brush as SolidBrush).FillColor, (ch2node.Style.StrokeBrush as SolidBrush).FillColor);
            diagram.AddNode(ch2childnode2);

            var ch3node = AddNode(500, 100, width, height, "Personal");
            index = rnd.Next(5);
            AddNodeStyle(ch3node, FColor[index], SColor[index]);
            diagram.AddNode(ch3node);

            var ch3childnode1 = AddNode(500, 100, width, height, "Sports");
            AddNodeStyle(ch3childnode1, (ch3node.Style.Brush as SolidBrush).FillColor, (ch3node.Style.StrokeBrush as SolidBrush).FillColor);
            diagram.AddNode(ch3childnode1);

            var ch3childnode2 = AddNode(500, 100, width, height, "Food");
            AddNodeStyle(ch3childnode2, (ch3node.Style.Brush as SolidBrush).FillColor, (ch3node.Style.StrokeBrush as SolidBrush).FillColor);
            diagram.AddNode(ch3childnode2);

            var ch4node = AddNode(500, 600, width, height, "Work");
            index = rnd.Next(5);
            AddNodeStyle(ch4node, FColor[index], SColor[index]);
            diagram.AddNode(ch4node);

            var ch4childnode1 = AddNode(500, 100, width, height, "Project");
            AddNodeStyle(ch4childnode1, (ch4node.Style.Brush as SolidBrush).FillColor, (ch4node.Style.StrokeBrush as SolidBrush).FillColor);
            diagram.AddNode(ch4childnode1);

            var ch4childnode2 = AddNode(500, 100, width, height, "Career");
            AddNodeStyle(ch4childnode2, (ch4node.Style.Brush as SolidBrush).FillColor, (ch4node.Style.StrokeBrush as SolidBrush).FillColor);
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

            diagram.Clicked += Diagram_Clicked;
            diagram.Loaded += Diagram_Loaded;
            SelectedNode = node;
            diagram.ConnectorClicked += Diagram_ConnectorClicked;
            return diagram;
        }

        public override void Destroy()
        {
            if (diagram != null)
                diagram.Dispose();
            base.Destroy();
        }

        void Diagram_ConnectorClicked(object sender, ConnectorClickedEventArgs args)
        {
            diagram.ClearSelection();
        }

        private void Diagram_Clicked(object sender, DiagramClickedEventArgs args)
        {
            if (CommentBoxEntry != null && CommentBoxEntry.alertBuilder != null)
                CommentBoxEntry.alertBuilder.SetCancelable(true);
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
            linearLayout4.SetMinimumHeight((int)(190 * currentDensity));
            linearLayout4.SetMinimumWidth(width);

            TextView selectText = new TextView(context)
            {
                Text = "Layout Schema",
                Gravity = GravityFlags.Start,
                TextSize = 5 * currentDensity
            };
            selectText.SetMinimumHeight((int)(50 * currentDensity));
            selectText.SetWidth((int)(width * 0.4 * currentDensity));

          
            //Here theme styles starts
            HorizontalScrollView horizontalScroll = new HorizontalScrollView(context);
            //horizontalScroll.SetPadding(0, (int)(10 * currentDensity), 0, (int)(10 * currentDensity));
            horizontalScroll.FillViewport = true;
            horizontalScroll.HorizontalScrollBarEnabled = true;
            horizontalScroll.SetMinimumHeight((int)(205 * currentDensity));
            horizontalScroll.Layout(0, (int)(30 * currentDensity), (int)(175 * currentDensity * 4), (int)(180 * currentDensity));
            scrollLayout = new LinearLayout(context);
            scrollLayout.SetPadding((int)(10 * currentDensity), (int)(10 * currentDensity), (int)(10 * currentDensity), (int)(10 * currentDensity));
            scrollLayout.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
            horizontalScroll.AddView(scrollLayout);
          
            LinearLayout freeFormLinearLayout = new LinearLayout(context);
            freeFormLinearLayout.SetPadding(0, (int)(10 * currentDensity), 0, (int)(10 * currentDensity));
            freeFormLinearLayout.SetMinimumHeight((int)(30 * currentDensity));

            TextView freeFormLayout = new TextView(context)
            {
                Text = "Free Form",
                Gravity = GravityFlags.Start,
                TextSize = 5 * currentDensity
            };
            freeFormLayout.SetMinimumHeight((int)(25 * currentDensity));
            freeFormLayout.SetWidth((int)(width * 0.4 * currentDensity));

            Switch freeFormSwitch = new Switch(context);
            freeFormSwitch.CheckedChange += FreeFormSwitch_CheckedChange;
            freeFormSwitch.Gravity = GravityFlags.Right;
            freeFormSwitch.SetMinimumHeight((int)(25 * currentDensity));
            freeFormSwitch.SetWidth((int)(width * 0.4 * currentDensity));
            freeFormLinearLayout.AddView(freeFormLayout);
            freeFormLinearLayout.AddView(freeFormSwitch);
            linearLayout4.AddView(freeFormLinearLayout);
			linearLayout4.AddView(selectText);
			linearLayout4.AddView(horizontalScroll);
            AddThemes();

            gridLinearLayout.AddView(linearLayout4);

            return gridLinearLayout;

        }

        private void FreeFormSwitch_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (e.IsChecked)
            {
                (diagram.LayoutManager.Layout as MindMapLayout).EnableFreeForm = true;
            }

            else
            {
                (diagram.LayoutManager.Layout as MindMapLayout).EnableFreeForm = false;
            }
        }

        private void AddThemes()
        {
            AddColor("mindmapDefault.png");
            AddColor("mindmapconttree.png");
            AddColor("mindmaportho.png");
            AddColor("mindmapsimpletree.png");
        }

        private void AddColor(string imageId)
        {
            ImageButtonView imageButton = new ImageButtonView(diagram.Context);
            imageButton.Click += ButtonTouch;
            imageButton.ImageId = imageId;
            //imageButton.SetPadding((int)(10 * currentDensity), 0, (int)(10 * currentDensity), 0);
            imageButton.LayoutParameters = new ViewGroup.LayoutParams((int)(220 * currentDensity), (int)(200 * currentDensity));

            ImageView image = new ImageView(diagram.Context);
            if (imageId != null)
            {
                var imageData = LoadResource(imageId).ToArray();
                image.SetImageBitmap(BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length));
            }
            image.Layout((int)(15 * currentDensity), (int)(15 * currentDensity), (int)(520 * MainActivity.Factor), (int)(500 * MainActivity.Factor));

            imageButton.AddView(image);

            scrollLayout.AddView(imageButton);
        }

        VerticalAlignment TextStyleVerticalAlignment = VerticalAlignment.Center;
        private void ButtonTouch(object sender, EventArgs e)
        {
            ImageButtonView view = sender as ImageButtonView;
            view.ButtonSelected = true;
            switch (view.ImageId)
            {
                case "mindmapconttree.png":
                    simpleCurveTree = "contCurveTree";
                    SfGraphicsPath path = new SfGraphicsPath();
                    path.MoveTo(0, 0);
                    path.MoveTo(0, 50);
                    path.LineTo(100, 50);
                    path.MoveTo(100, 100);
                    gra.DrawPath(path);
                    Pen pe = new Pen();
                    pe.StrokeBrush = new SolidBrush(Color.ParseColor("#949494"));
                    pe.StrokeWidth = 5;
                    point.Add(new Point(0, 50));
                    point.Add(new Point(100, 50));
                    gra.DrawLines(pe, point);
                    objShape1 = ShapeType.Ellipse;
                    objShape2 = gra;
                    objShape3 = gra;
                    objShape4 = gra;
                    objShape5 = gra;
                    segment = SegmentType.CurveSegment;
                    TextStyleVerticalAlignment = VerticalAlignment.Top;
                    Dectype = DecoratorType.None;
                    connColor = Color.Black;
                    connLineApplyColorFrom = ApplyColorFrom.TargetBorder;
                    connDecApplyColorFrom = ApplyColorFrom.TargetBorder;
                    break;

                case "mindmapDefault.png":
                    simpleCurveTree = "default";
                    objShape1 = ShapeType.RoundedRectangle;
                    objShape2 = ShapeType.RoundedRectangle;
                    objShape3 = ShapeType.RoundedRectangle;
                    objShape4 = ShapeType.RoundedRectangle;
                    objShape5 = ShapeType.RoundedRectangle;
                    segment = SegmentType.CurveSegment;
                    TextStyleVerticalAlignment = VerticalAlignment.Center;
                    Dectype = DecoratorType.None;
                    connColor = Color.Black;
                    connLineApplyColorFrom = ApplyColorFrom.TargetBorder;
                    connDecApplyColorFrom = ApplyColorFrom.TargetBorder;
                    break;

                case "mindmaportho.png":
                    simpleCurveTree = "orthotree";
                    objShape1 = ShapeType.Rectangle;
                    objShape2 = ShapeType.Rectangle;
                    objShape3 = ShapeType.Rectangle;
                    objShape4 = ShapeType.Rectangle;
                    objShape5 = ShapeType.Rectangle;
                    segment = SegmentType.OrthoSegment;
                    TextStyleVerticalAlignment = VerticalAlignment.Center;
                    Dectype = DecoratorType.None;
                    connColor = Color.Black;
                    connLineApplyColorFrom = ApplyColorFrom.TargetBorder;
                    connDecApplyColorFrom = ApplyColorFrom.TargetBorder;
                    break;

                case "mindmapsimpletree.png":
                    simpleCurveTree = "simpleCurveTree";
                    objShape1 = ShapeType.RoundedRectangle;
                    objShape2 = ShapeType.RoundedRectangle;
                    objShape3 = ShapeType.RoundedRectangle;
                    objShape4 = ShapeType.RoundedRectangle;
                    objShape5 = ShapeType.RoundedRectangle;
                    segment = SegmentType.CurveSegment;
                    TextStyleVerticalAlignment = VerticalAlignment.Center;
                    Dectype = DecoratorType.None;
                    connColor = Color.ParseColor("#949494");
                    connLineApplyColorFrom = ApplyColorFrom.Custom;
                    connDecApplyColorFrom = ApplyColorFrom.Custom;
                    break;
            }
            UpdateTheme();

            for (int i = 0; i < scrollLayout.ChildCount; i++)
            {
                ImageButtonView childView = (ImageButtonView)scrollLayout.GetChildAt(i);
                if (childView.ImageId == view.ImageId) continue;
                childView.ButtonSelected = false;
            }
        }

        internal void UpdateTheme()
        {
            bool m_repeatmode = true;
            nodeStyleCollection.Clear();
            if (simpleCurveTree == "default")
            {
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.ParseColor("#d7ebf6")), Color.ParseColor("#d7ebf6"), objShape1, StrokeStyle.Default,
                new Syncfusion.SfDiagram.Android.TextStyle((int)(14 * MainActivity.Factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.ParseColor("#ffebc4")), Color.ParseColor("#ffebc4"), objShape2, StrokeStyle.Default,
                    new Syncfusion.SfDiagram.Android.TextStyle((int)(14 * MainActivity.Factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, TextStyleVerticalAlignment)));
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.ParseColor("#ffcdcd")), Color.ParseColor("#ffcdcd"), objShape3, StrokeStyle.Default,
                 new Syncfusion.SfDiagram.Android.TextStyle((int)(14 * MainActivity.Factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, TextStyleVerticalAlignment)));
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.ParseColor("#e7eeb8")), Color.ParseColor("#e7eeb8"), objShape4, StrokeStyle.Default,
                   new Syncfusion.SfDiagram.Android.TextStyle((int)(14 * MainActivity.Factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, TextStyleVerticalAlignment)));
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.ParseColor("#d7ebf6")), Color.ParseColor("#d7ebf6"), objShape5, StrokeStyle.Default,
                   new Syncfusion.SfDiagram.Android.TextStyle((int)(14 * MainActivity.Factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, TextStyleVerticalAlignment)));
            }
            else if (simpleCurveTree == "orthotree")
            {
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.ParseColor("#d7ebf6")), Color.ParseColor("#b4d6e8"), objShape1, StrokeStyle.Default,
                new Syncfusion.SfDiagram.Android.TextStyle((int)(14 * MainActivity.Factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.ParseColor("#ffebc4")), Color.ParseColor("#f2dcb1"), objShape2, StrokeStyle.Default,
                    new Syncfusion.SfDiagram.Android.TextStyle((int)(14 * MainActivity.Factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, TextStyleVerticalAlignment)));
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.ParseColor("#ffcdcd")), Color.ParseColor("#ecb6b6"), objShape3, StrokeStyle.Default,
                 new Syncfusion.SfDiagram.Android.TextStyle((int)(14 * MainActivity.Factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, TextStyleVerticalAlignment)));
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.ParseColor("#e7eeb8")), Color.ParseColor("#d6dda6"), objShape4, StrokeStyle.Default,
                   new Syncfusion.SfDiagram.Android.TextStyle((int)(14 * MainActivity.Factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, TextStyleVerticalAlignment)));
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.ParseColor("#d7ebf6")), Color.ParseColor("#b4d6e8"), objShape5, StrokeStyle.Default,
                   new Syncfusion.SfDiagram.Android.TextStyle((int)(14 * MainActivity.Factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, TextStyleVerticalAlignment)));
            }
            else if (simpleCurveTree == "simpleCurveTree")
            {
                m_repeatmode = false;
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.ParseColor("#d7ebf6")), Color.ParseColor("#b4d6e8"), objShape1, StrokeStyle.Default,
                new Syncfusion.SfDiagram.Android.TextStyle((int)(14 * MainActivity.Factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape2, StrokeStyle.Default,
                    new Syncfusion.SfDiagram.Android.TextStyle((int)(14 * MainActivity.Factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, TextStyleVerticalAlignment)));
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape3, StrokeStyle.Default,
                 new Syncfusion.SfDiagram.Android.TextStyle((int)(14 * MainActivity.Factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, TextStyleVerticalAlignment)));
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape4, StrokeStyle.Default,
                   new Syncfusion.SfDiagram.Android.TextStyle((int)(14 * MainActivity.Factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, TextStyleVerticalAlignment)));
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.Transparent), Color.Transparent, objShape5, StrokeStyle.Default,
                   new Syncfusion.SfDiagram.Android.TextStyle((int)(14 * MainActivity.Factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, TextStyleVerticalAlignment)));
            }
            else if (simpleCurveTree == "contCurveTree")
            {
                m_repeatmode = false;
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.ParseColor("#d7ebf6")), Color.ParseColor("#d7ebf6"), objShape1, StrokeStyle.Default,
                new Syncfusion.SfDiagram.Android.TextStyle((int)(14 * MainActivity.Factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.ParseColor("#949494")), Color.ParseColor("#949494"), objShape2, StrokeStyle.Default,
                    new Syncfusion.SfDiagram.Android.TextStyle((int)(14 * MainActivity.Factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, TextStyleVerticalAlignment)));
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.ParseColor("#949494")), Color.ParseColor("#949494"), objShape3, StrokeStyle.Default,
                 new Syncfusion.SfDiagram.Android.TextStyle((int)(14 * MainActivity.Factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, TextStyleVerticalAlignment)));
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.ParseColor("#949494")), Color.ParseColor("#949494"), objShape4, StrokeStyle.Default,
                   new Syncfusion.SfDiagram.Android.TextStyle((int)(14 * MainActivity.Factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, TextStyleVerticalAlignment)));
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(Color.ParseColor("#949494")), Color.ParseColor("#949494"), objShape5, StrokeStyle.Default,
                   new Syncfusion.SfDiagram.Android.TextStyle((int)(14 * MainActivity.Factor), Color.Black, ".SF UI Text", HorizontalAlignment.Center, TextStyleVerticalAlignment)));
            }
            lineStyle = new LineStyle(segment, StrokeStyle.Default, 2, connLineApplyColorFrom, Dectype, connDecApplyColorFrom, connDecApplyColorFrom) { Color = connColor };
            (diagram.LayoutManager.Layout as MindMapLayout).UpdateLayoutStyle(new LayoutStyle(nodeStyleCollection, lineStyle, ApplyNodeStyleBy.Branch, m_repeatmode));
        }

        internal class ImageButtonView : ViewGroup
        {
            private bool m_buttonSelected;

            internal ImageButtonView(Context context) : base(context)
            {
                SetBackgroundColor(Color.Transparent);
            }

            public bool ButtonSelected
            {
                get
                {
                    return m_buttonSelected;
                }
                set
                {
                    m_buttonSelected = value;
                    SetWillNotDraw(true);
                    SetWillNotDraw(false);
                }
            }

            public string ImageId { get; internal set; }

            protected override void OnDraw(Canvas canvas)
            {
                base.OnDraw(canvas);
                if (ButtonSelected)
                {
                    Paint paint = new Paint();
                    paint.SetStyle(Paint.Style.Stroke);
                    paint.Color = Color.Rgb(30, 144, 255);
                    paint.StrokeWidth = 3 * Resources.DisplayMetrics.Density;
                    canvas.DrawRect(GetChildAt(0).Left - 10 * Resources.DisplayMetrics.Density, GetChildAt(0).Top, GetChildAt(0).Right + 10 * Resources.DisplayMetrics.Density, GetChildAt(0).Bottom, paint);
                }
                else
                {
                    Paint paint = new Paint();
                    paint.SetStyle(Paint.Style.Stroke);
                    paint.Color = Color.Transparent;
                    paint.StrokeWidth = 3 * Resources.DisplayMetrics.Density;
                    canvas.DrawRect(GetChildAt(0).Left - 10 * Resources.DisplayMetrics.Density, GetChildAt(0).Top, GetChildAt(0).Right + 10 * Resources.DisplayMetrics.Density, GetChildAt(0).Bottom, paint);
                }
            }

            protected override void OnLayout(bool changed, int l, int t, int r, int b)
            {

            }
        }

        private void Diagram_NodeClicked(object sender, NodeClickedEventArgs args)
        {
            SelectedNode = args.Item;
            diagram.Alpha = 1;
            diagram.PageSettings.BackgroundColor = Color.White;
            UpdateHandle();
        }

        private void AddExpCollHandle()
        {
            if (GetExpCollHandle(LeftSideHandles) == null)
            {
                LeftSideHandles.Add(new UserHandle("ExpColl", UserHandlePosition.BottomLeft, GetHandleImage("mindmapcollpase.png")));
            }
            if (GetExpCollHandle(RightSideHandle) == null)
            {
                RightSideHandle.Add(new UserHandle("ExpColl", UserHandlePosition.BottomLeft, GetHandleImage("mindmapcollpase.png")));
            }
            if (GetExpCollHandle(DefaultHandles) == null)
            {
                DefaultHandles.Add(new UserHandle("ExpColl", UserHandlePosition.BottomLeft, GetHandleImage("mindmapexpand.png")));
            }
        }

        private UserHandle GetExpCollHandle(UserHandleCollection handleCollection)
        {
            for (int i = 0; i < handleCollection.Count; i++)
            {
                UserHandle handle = handleCollection[i];
                if (handle.Name == "ExpColl")
                {
                    return handle;
                }
            }
            return null;
        }

        internal MemoryStream LoadResource(string name)
        {
            MemoryStream aMem = new MemoryStream();

            var assm = Assembly.GetExecutingAssembly();

            var path = string.Format("SampleBrowser.Resources.drawable.{0}", name);

            var aStream = assm.GetManifestResourceStream(path);

            aStream.CopyTo(aMem);

            return aMem;
        }

        private void AddHandles()
        {
            DefaultHandles = new UserHandleCollection(diagram);
            DefaultHandles.Add(new UserHandle("Left", UserHandlePosition.Left, GetHandleImage("mindmapplus.png")));
            DefaultHandles.Add(new UserHandle("Right", UserHandlePosition.Right, GetHandleImage("mindmapplus.png")));
            DefaultHandles.Add(new UserHandle("ExpColl", UserHandlePosition.BottomLeft, GetHandleImage("mindmapexpand.png")));
            DefaultHandles.Add(new UserHandle("Delete", UserHandlePosition.Bottom, GetHandleImage("mindmapdelete.png")) { Visible = false });
            DefaultHandles.Add(new UserHandle("info", UserHandlePosition.TopRight, GetHandleImage("mindmapmore.png")));
            diagram.UserHandles = DefaultHandles;


        }

        private ImageView GetHandleImage(string imageId)
        {
            var defExpandTemplate = new ImageView(diagram.Context);
            defExpandTemplate.Layout(0, 0, 25, 25);

            if (imageId != null)
            {
                var imageData = LoadResource(imageId).ToArray();
                defExpandTemplate.SetImageBitmap(BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length));
            }
            defExpandTemplate.SetPadding(0, (int)(10 * MainActivity.Factor), 0, 0);
            return defExpandTemplate;
        }

        private void Diagram_UserHandleClicked(object sender, UserHandleClickedEventArgs args)
        {
            SelectedNode = diagram.SelectedItems[0] as Node;
            if (args.Item.Name == "Delete")
            {
                diagram.RemoveNode(SelectedNode, true);
               if (!(diagram.LayoutManager.Layout as MindMapLayout).EnableFreeForm)
                    (diagram.LayoutManager.Layout as MindMapLayout).UpdateLayout();
            }
            else if (args.Item.Name == "ExpColl")
            {
                if (SelectedNode.IsExpanded)
                {
                    SelectedNode.IsExpanded = false;
                    args.Item.Content = GetHandleImage("mindmapcollpase.png");

                }
                else
                {
                    SelectedNode.IsExpanded = true;
                    args.Item.Content = GetHandleImage("mindmapexpand.png");

                }
               if (!(diagram.LayoutManager.Layout as MindMapLayout).EnableFreeForm)
                    (diagram.LayoutManager.Layout as MindMapLayout).UpdateLayout();
                UpdateHandle();
                diagram.Select(SelectedNode);
            }
            else if (args.Item.Name == "info")
            {
                AddInfo();
            }
            else
            {
                if (args.Item.Name == "Left")
                {
                    CurrentHandle = UserHandlePosition.Left;
                    ShowInfo();
                }
                else if (args.Item.Name == "Right")
                {
                    CurrentHandle = UserHandlePosition.Right;
                    ShowInfo();
                }
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
        internal void UpdateHandle()
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
                    diagram.UserHandles[2].Content = GetHandleImage("mindmapexpand.png");
			    }
                else
                {
                    diagram.UserHandles[2].Content = GetHandleImage("mindmapcollpase.png");
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
                    diagram.UserHandles[2].Content = GetHandleImage("mindmapcollpase.png");
			    }
                else
                {
                    diagram.UserHandles[2].Content = GetHandleImage("mindmapexpand.png");
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
            if (SelectedNode.Children.Count() > 0)
            {
                diagram.UserHandles[2].Visible = true;
            }
            else
            {
                diagram.UserHandles[2].Visible = false;
            }
        }
        private void AddInfo()
        {
            string content = "";
            if (SelectedNode.Content != null)
            {
                content = SelectedNode.Content as string;
            }
            CommentBoxEntry = new AlertBox(diagram.Context, this, content, diagram, CurrentHandle, SelectedNode, RootNode, index, rnd, LeftSideHandles, RightSideHandle, SColor, FColor);
            CommentBoxEntry.editText.Text = content;
            CommentBoxEntry.editText.SetPadding(0, 8, 0, 0);
            CommentBoxEntry.ShowPopUpForComments("Okay", "Cancel");
        }

        void ShowInfo()
        {
            CommentBoxEntry = new AlertBox(diagram.Context, this, "", diagram, CurrentHandle, SelectedNode, RootNode, index, rnd, LeftSideHandles, RightSideHandle, SColor, FColor);

            CommentBoxEntry.editText.SetPadding(0, 8, 0, 0);
            CommentBoxEntry.ShowPopUp("Okay", "Cancel");
        }

        void Ok_Clicked1(object sender, EventArgs e)
        {
            if (CommentBoxEntry.editText.Text != null)
            {
                SelectedNode.Content = CommentBoxEntry.editText.Text;
            }
        }

        private Color GetColor(string hex)
        {
            int r = Convert.ToInt32(hex.Substring(1, 2), 16);
            int g = Convert.ToInt32(hex.Substring(3, 2), 16);
            int b = Convert.ToInt32(hex.Substring(5, 2), 16);
            return new Color(r, g, b);
        }

        private Connector AddConnector(Node node, Node ch1node)
        {
            var c1 = new Connector(diagram.Context);
            c1.SourceNode = node;
            c1.TargetNode = ch1node;
            c1.Style.StrokeBrush = new SolidBrush((c1.TargetNode.Style.StrokeBrush as SolidBrush).FillColor);
            c1.Style.StrokeStyle = StrokeStyle.Dashed;
            c1.Style.StrokeWidth = 3;
            c1.TargetDecoratorStyle.Fill = (c1.TargetNode.Style.StrokeBrush as SolidBrush).FillColor;
            c1.TargetDecoratorStyle.StrokeColor = (node.Style.StrokeBrush as SolidBrush).FillColor;
            c1.SegmentType = SegmentType.CurveSegment;
            return c1;
        }

        private void AddNodeStyle(Node node, Color fill, Color Stroke)
        {
            node.Style.Brush = new SolidBrush(fill);
            node.Style.StrokeBrush = new SolidBrush(Stroke);
        }

        Node AddNode(int x, int y, int w, int h, string text)
        {
            var node = new Node(x, y, w, h, diagram.Context);
            node.ShapeType = ShapeType.RoundedRectangle;
            node.Style.StrokeWidth = 2;
            node.Annotations.Add(new Annotation() { Content = text, FontSize = 16 * MainActivity.Factor, TextBrush = new SolidBrush(Color.Black) });
            return node;
        }

        private void Diagram_Loaded(object sender)
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
                    MindMapOrientation = Syncfusion.SfDiagram.Android.Orientation.Horizontal,
                    HorizontalSpacing = 70,
                }
            };
            (diagram.LayoutManager.Layout as MindMapLayout).HorizontalSpacing = 70 * MainActivity.Factor;
            if (!(diagram.LayoutManager.Layout as MindMapLayout).EnableFreeForm)
            {
                diagram.LayoutManager.Layout.UpdateLayout();
            }
            SelectedNode = RootNode;
            diagram.Select(RootNode);
            diagram.BringToView(RootNode);
            UpdateTheme();
        }
    }


    internal class AlertBox
    {
        internal string _inputstring;
        internal AlertDialog.Builder alertBuilder;
        internal EditText editText;
        private SfDiagram diagram;
        private UserHandlePosition CurrentHandle;
        private Node SelectedNode;
        private Node RootNode;
        private int index;
        private Random rnd;
        private UserHandleCollection LeftSideHandles;
        private UserHandleCollection RightSideHandle;
        private List<Color> SColor;
        private List<Color> FColor;
        private MindMap m_mindmap;

        internal AlertBox(Context context, MindMap mindmap, string content, SfDiagram sfDiagram, UserHandlePosition CurrentHandle, Node selectedNode, Node rootNode, int index, Random rnd, UserHandleCollection left, UserHandleCollection right, List<Color> SColor, List<Color> FColor)
        {
            alertBuilder = new AlertDialog.Builder(context);
            m_mindmap = mindmap;
            editText = new EditText(context);
            _inputstring = content;
            diagram = sfDiagram;
            this.CurrentHandle = CurrentHandle;
            SelectedNode = selectedNode;
            RootNode = rootNode;
            this.index = index;
            this.rnd = rnd;
            LeftSideHandles = left;
            RightSideHandle = right;
            this.SColor = SColor;
            this.FColor = FColor;
        }

        internal void ShowPopUp(string positive, string negative)
        {
            alertBuilder.SetTitle("Enter Text");
            editText.Text = _inputstring;
            editText.FocusableInTouchMode = true;
            editText.RequestFocus();
            editText.SetBackgroundColor(Color.WhiteSmoke);
            editText.SetTextColor(Color.Black);
            alertBuilder.SetView(editText);
            alertBuilder.SetCancelable(false);

            alertBuilder.SetPositiveButton(positive, (senderAlert, args) =>
            {
                diagram.Alpha = 1;
                diagram.PageSettings.BackgroundColor = Color.White;
                if (editText.Text == null)
                {
                    editText.Text = "";
                }
                var node = new Node(diagram.Context);
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
                node.Style.StrokeWidth = 3;
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
                node.Annotations.Add(new Annotation() { Content = editText.Text, FontSize = 14 * MainActivity.Factor, TextBrush = new SolidBrush(Color.Black) });
                diagram.AddNode(node);
                var c1 = new Connector(diagram.Context);
                c1.SourceNode = SelectedNode;
                c1.TargetNode = node;
                //c1.Style.StrokeBrush = node.Style.StrokeBrush;
                //c1.Style.StrokeWidth = 3;
                //c1.TargetDecoratorStyle.Fill = (node.Style.StrokeBrush as SolidBrush).FillColor;
                //c1.TargetDecoratorStyle.StrokeColor = (c1.TargetNode.Style.StrokeBrush as SolidBrush).FillColor;
                //c1.SegmentType = SegmentType.CurveSegment;
                //c1.Style.StrokeStyle = StrokeStyle.Dashed;
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
                m_mindmap.SelectedNode = node;
                m_mindmap.UpdateHandle();
                diagram.Select(node);

                diagram.BringToView(node);
                m_mindmap.UpdateTheme();
            });
            alertBuilder.SetNegativeButton(negative, (senderAlert, args) =>
            {
                alertBuilder.SetCancelable(true);
            });
            alertBuilder.Show();
        }

        internal void ShowPopUpForComments(string positive, string negative)
        {
            alertBuilder.SetTitle("Enter Comments");
            editText.Text = _inputstring;
            editText.FocusableInTouchMode = true;
            editText.RequestFocus();
            editText.SetBackgroundColor(Color.WhiteSmoke);
            editText.SetTextColor(Color.Black);
            alertBuilder.SetView(editText);
            alertBuilder.SetCancelable(false);
            alertBuilder.SetPositiveButton(positive, (senderAlert, args) =>
            {
                (diagram.SelectedItems[0] as Node).Content = editText.Text;
            });
            alertBuilder.SetNegativeButton(negative, (senderAlert, args) =>
            {
                alertBuilder.SetCancelable(true);
            });
            alertBuilder.Show();
        }
    }
}