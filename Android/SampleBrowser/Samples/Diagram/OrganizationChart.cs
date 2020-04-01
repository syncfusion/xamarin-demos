#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Syncfusion.SfDiagram.Android;
using System.IO;
using System.Reflection;
using Android.Util;

namespace SampleBrowser
{
    public partial class OrganizationChart : SamplePage
    {
        private bool isTablet;
        SfDiagram diagram;
        DataModel dataModel;
        Dictionary<string, Color> FillColor;
        Dictionary<string, Color> StrokeColor;
        private ExpandButton expanded;
        LinearLayout linearLayout4;
        float currentDensity = 1;
        public override View GetSampleContent(Context context)
        {
            Display display = ((Activity)context).WindowManager.DefaultDisplay;
            DisplayMetrics displayMetrics = new DisplayMetrics();
            display.GetMetrics(displayMetrics);

            var wInches = displayMetrics.WidthPixels / (double)displayMetrics.DensityDpi;
            var hInches = displayMetrics.HeightPixels / (double)displayMetrics.DensityDpi;

            double screenDiagonal = Math.Sqrt(Math.Pow(wInches, 2) + Math.Pow(hInches, 2));
            isTablet = screenDiagonal >= 7.0;

            //Create SfDiagram.
            diagram = new SfDiagram(context);
            diagram.EnableSelection = false;

            FillColor = new Dictionary<string, Color>();
            FillColor.Add("Managing Director", Color.Rgb(239, 75, 93));
            FillColor.Add("Project Manager", Color.Rgb(49, 162, 255));
            FillColor.Add("Senior Manager", Color.Rgb(49, 162, 255));
            FillColor.Add("Project Lead", Color.Rgb(0, 194, 192));
            FillColor.Add("Senior S/W Engg", Color.Rgb(0, 194, 192));
            FillColor.Add("Software Engg", Color.Rgb(0, 194, 192));
            FillColor.Add("Team Lead", Color.Rgb(0, 194, 192));
            FillColor.Add("Project Trainee", Color.Rgb(255, 129, 0));

            StrokeColor = new Dictionary<string, Color>();
            StrokeColor.Add("Managing Director", Color.Rgb(201, 32, 61));
            StrokeColor.Add("Project Manager", Color.Rgb(23, 132, 206));
            StrokeColor.Add("Senior Manager", Color.Rgb(23, 132, 206));
            StrokeColor.Add("Project Lead", Color.Rgb(4, 142, 135));
            StrokeColor.Add("Senior S/W Engg", Color.Rgb(4, 142, 135));
            StrokeColor.Add("Software Engg", Color.Rgb(4, 142, 135));
            StrokeColor.Add("Team Lead", Color.Rgb(4, 142, 135));
            StrokeColor.Add("Project Trainee", Color.Rgb(206, 98, 9));

            dataModel = new DataModel();
            diagram.BackgroundColor = Color.White;
            diagram.BeginNodeRender += Dia_BeginNodeRender;

            dataModel.Data();

            //To Represent DataSourceSttings Properties
            DataSourceSettings settings = new DataSourceSettings();
            settings.ParentId = "ReportingPerson";
            settings.Id = "Name";
            settings.DataSource = dataModel.employee;
            diagram.DataSourceSettings = settings;

            //(diagram.LayoutManager.Layout as DirectedTreeLayout).IsDraggable


            //To Represent LayoutManager Properties
            diagram.LayoutManager = new LayoutManager()
            {
                Layout = new DirectedTreeLayout()
                {
                    Type = LayoutType.Organization,
                    HorizontalSpacing = 70 * MainActivity.Factor,
                    VerticalSpacing = 70 * MainActivity.Factor
                }
            };

            for (int i = 0; i < diagram.Connectors.Count; i++)
            {
                diagram.Connectors[i].TargetDecoratorType = DecoratorType.None;
                diagram.Connectors[i].Style.StrokeBrush = new SolidBrush(Color.Rgb(127, 132, 133));
            }
            diagram.NodeClicked += Diagram_NodeClicked;
            diagram.ItemLongPressed += Diagram_ItemLongPressed;
            diagram.Loaded += Diagram_Loaded;

            int width = (int)(context.Resources.DisplayMetrics.WidthPixels - context.Resources.DisplayMetrics.Density) / 3;
            linearLayout4 = new LinearLayout(context);
            linearLayout4.Orientation = Android.Widget.Orientation.Vertical;
            linearLayout4.SetMinimumHeight((int)(190 * currentDensity));
            linearLayout4.SetMinimumWidth(width);
            diagram.LayoutNodeDropped += Diagram_OnLayoutNodeDropped;
            return diagram;
        }

        public override void Destroy()
        {
            if (diagram != null)
                diagram.Dispose();
            base.Destroy();
        }
        OverviewPanel overview;

        private void Diagram_Loaded(object sender)
        {
            diagram.BringToView(diagram.Nodes[0]);
            if (isTablet)
            {
                overview = new CustomOverview(diagram.Context);
                diagram.OverviewPanel = overview;
                overview.PreventRefresh = true;
                overview.Layout(0, 0, 400, 400);
                diagram.AddView(overview);
                overview.ForceRefresh();
            }
        }

        internal class CustomOverview : OverviewPanel
        {
            internal CustomOverview(Context context) : base(context)
            {

            }
            protected override void OnDraw(Canvas canvas)
            {
                base.OnDraw(canvas);
                Paint paint = new Paint();
                paint.SetStyle(Paint.Style.Stroke);
                paint.StrokeWidth = 3 * Resources.DisplayMetrics.Density;
                paint.Color = Color.Orange;
                SetPadding(10, 10, 10, 10);
                canvas.DrawRect(new Rect(Left, Top, Right, Bottom), paint);
            }
        }

        public override View GetPropertyWindowLayout(Context context)
        {
            LinearLayout gridLinearLayout = new LinearLayout(context) { Orientation = Android.Widget.Orientation.Vertical };

            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);

            layoutParams.TopMargin = (int)(25 * currentDensity);
            gridLinearLayout.LayoutParameters = layoutParams;
            gridLinearLayout.SetBackgroundResource(Resource.Drawable.LinearLayout_Border);

            int width = (int)(context.Resources.DisplayMetrics.WidthPixels - context.Resources.DisplayMetrics.Density);

            LinearLayout linearLayout = new LinearLayout(context);
            linearLayout.Orientation = Android.Widget.Orientation.Vertical;
            linearLayout.SetMinimumHeight((int)(190 * currentDensity));
            linearLayout.SetMinimumWidth(width);

            LinearLayout overviewLayout = new LinearLayout(context);
            overviewLayout.SetPadding(0, (int)(10 * currentDensity), 0, (int)(10 * currentDensity));
            overviewLayout.SetMinimumHeight((int)(30 * currentDensity));

            TextView overviewLabel = new TextView(context)
            {
                Text = "Enable Overview",
                Gravity = GravityFlags.Start,
                TextSize = 15 * currentDensity
            };
            overviewLabel.SetMinimumHeight((int)(25 * currentDensity));
            overviewLabel.SetWidth((int)(width * 0.4 * currentDensity));

            Switch overviewSwitch = new Switch(context);
            overviewSwitch.Checked = true;
            overviewSwitch.CheckedChange += OverviewSwitch_CheckedChange;
            overviewSwitch.Gravity = GravityFlags.Right;
            overviewSwitch.SetMinimumHeight((int)(25 * currentDensity));
            overviewSwitch.SetWidth((int)(width * 0.4 * currentDensity));
            overviewLayout.AddView(overviewLabel);
            overviewLayout.AddView(overviewSwitch);

            LinearLayout interactionLayout = new LinearLayout(context);
            interactionLayout.SetPadding(0, (int)(10 * currentDensity), 0, (int)(10 * currentDensity));
            interactionLayout.SetMinimumHeight((int)(30 * currentDensity));

            TextView interactionLabel = new TextView(context)
            {
                Text = "Change Hierarchy",
                Gravity = GravityFlags.Start,
                TextSize = 15 * currentDensity
            };
            interactionLabel.SetMinimumHeight((int)(25 * currentDensity));
            interactionLabel.SetWidth((int)(width * 0.4 * currentDensity));

            Switch interactionSwitch = new Switch(context);
            interactionSwitch.CheckedChange += LayoutNodeDragSwitch_CheckedChange;
            interactionSwitch.Gravity = GravityFlags.Right;
            interactionSwitch.SetMinimumHeight((int)(25 * currentDensity));
            interactionSwitch.SetWidth((int)(width * 0.4 * currentDensity));
            interactionLayout.AddView(interactionLabel);
            interactionLayout.AddView(interactionSwitch);

            if (isTablet)
                linearLayout.AddView(overviewLayout);
            linearLayout.AddView(interactionLayout);

            gridLinearLayout.AddView(linearLayout);

            return gridLinearLayout;

        }

        private void OverviewSwitch_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (e.IsChecked)
            {
                overview.Visibility = ViewStates.Visible;
            }
            else
            {
                overview.Visibility = ViewStates.Invisible;
            }
        }

        private void Diagram_OnLayoutNodeDropped(object sender, LayoutNodeDroppedEventArgs args)
        {
            Node draggedNode = args.DraggedItem as Node;
            Node droppedNode = args.DroppedItem as Node;
            bool contain = true;
            if (draggedNode != null && draggedNode != droppedNode)
            {
                Node ParentNode = GetParent((droppedNode.Content as DiagramEmployee).ReportingPerson);
                do
                {

                    if (ParentNode != draggedNode)
                    {
                        contain = false;
                    }
                    else
                    {
                        contain = true;
                        break;

                    }
                    ParentNode = GetParent((ParentNode.Content as DiagramEmployee).ReportingPerson);
                } while (ParentNode != null);

                if (!contain)
                {
                    List<Connector> connectors = draggedNode.InConnectors as List<Connector>;
                    Connector con;
                    bool hasChild = false;
                    for (int i = 0; i < connectors.Count; i++)
                    {
                        con = connectors[i];
                        con.SourceNode = droppedNode;
                        hasChild = true;

                    }
                    if (hasChild)
                    {
                        Node PrevParentNode = GetParent((draggedNode.Content as DiagramEmployee).ReportingPerson);
                        if (PrevParentNode != null && PrevParentNode.OutConnectors.Count() == 0)
                        {
                            (PrevParentNode.Content as DiagramEmployee).HasChild = false;
                            DrawTemplate(PrevParentNode);
                        }
                        DiagramEmployee ParentEmployee = (droppedNode.Content as DiagramEmployee);
                        (draggedNode.Content as DiagramEmployee).ReportingPerson = ParentEmployee.Name;
                        ParentEmployee.HasChild = true;
                        DrawTemplate(droppedNode);

                        ExpandAll(draggedNode);
                    }
                    (draggedNode.Content as DiagramEmployee).ReportingPerson = (droppedNode.Content as DiagramEmployee).Name;
                    droppedNode.IsExpanded = true;
                    diagram.LayoutManager.Layout.UpdateLayout();
                    if (overview != null)
                        overview.ForceRefresh();
                }
            }
        }
        private void ExpandAll(Node node)
        {
            if ((node.Content as DiagramEmployee).HasChild)
            {
                node.IsExpanded = true;
                DrawTemplate(node);
                if (node.OutConnectors.Count() > 0)
                {
                    foreach (var c in node.OutConnectors)
                    {
                        if (c.TargetNode != null)
                        {
                            ExpandAll(c.TargetNode);
                        }
                    }
                }
            }
        }
        private Node GetParent(string parentId)
        {
            foreach (Node node in diagram.Nodes)
            {
                if ((node.Content as DiagramEmployee).Name == parentId)
                {
                    return node;
                }
            }
            return null;
        }

        private void LayoutNodeDragSwitch_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (e.IsChecked)
            {
                (diagram.LayoutManager.Layout as DirectedTreeLayout).IsDraggable = true;
            }
            else
            {
                (diagram.LayoutManager.Layout as DirectedTreeLayout).IsDraggable = false;

            }
        }

        private void Diagram_ItemLongPressed(object sender, ItemLongPressedEventArgs args)
        {
            if (args.Item is Node)
            {
                DisplayInfo(args.Item as Node);
                diagram.NodeClicked -= Diagram_NodeClicked;
            }
        }

        private void Diagram_NodeClicked(object sender, NodeClickedEventArgs args)
        {
            Node node = args.Item;

            if (node.IsExpanded)
            {
                node.IsExpanded = false;
                if ((node.Content as DiagramEmployee).HasChild)
                    (node.Template.GetChildAt(0) as TextView).Text = "+";
            }
            else
            {
                node.IsExpanded = true;
                if ((node.Content as DiagramEmployee).HasChild)
                    (node.Template.GetChildAt(0) as TextView).Text = "-";
            }
            expanded.Invalidate();
        }

        internal MemoryStream LoadResource(String name)
        {
            MemoryStream aMem = new MemoryStream();

            var assm = Assembly.GetExecutingAssembly();

            var path = String.Format("SampleBrowser.Resources.drawable.{0}", name);

            var aStream = assm.GetManifestResourceStream(path);

            aStream.CopyTo(aMem);

            return aMem;
        }

        ViewGroup DrawTemplate(Node node)
        {
            if ((node.Content as DiagramEmployee).HasChild)
                node.Width = 470 * MainActivity.Factor;
            else
                node.Width = 370 * MainActivity.Factor;
            node.Height = 120 * MainActivity.Factor;
            node.Style.StrokeWidth = 2 * MainActivity.Factor;
            node.Style.StrokeBrush = new SolidBrush(Color.Black);
            node.ShapeType = ShapeType.RoundedRectangle;
            node.CornerRadius = 10 * MainActivity.Factor;
            //TEMPLATE
            var template = new Shape(this, diagram.Context, node, dataModel, FillColor, StrokeColor);
            template.Layout(0, 0, (int)node.Width, (int)node.Height);
            //EMP IMAGE
            var img = new ImageView(diagram.Context);
            var imageId = (node.Content as DiagramEmployee).ImageUrl;
            if (imageId != null)
            {
                var imageData = LoadResource(imageId).ToArray();
                img.SetImageBitmap(BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length));
            }
            img.SetPadding(0, (int)(10 * MainActivity.Factor), 0, 0);
            img.Layout((int)(10 * MainActivity.Factor), (int)(10 * MainActivity.Factor), (int)(100 * MainActivity.Factor), (int)(100 * MainActivity.Factor));
            //Name of the employee.
            var name = new TextView(diagram.Context);
            name.Text = (node.Content as DiagramEmployee).Name;
            name.SetTextSize(Android.Util.ComplexUnitType.Px, 28 * MainActivity.Factor);
            name.SetTextColor(Color.White);
            name.SetPadding(0, (int)(10 * MainActivity.Factor), 0, 0);
            name.Layout((int)(110 * MainActivity.Factor), (int)(10 * MainActivity.Factor), (int)node.Width, (int)node.Height);
            //Designation of the employee.
            var designation = new TextView(diagram.Context);
            designation.Text = (node.Content as DiagramEmployee).Designation;
            designation.SetTextSize(Android.Util.ComplexUnitType.Px, 28 * MainActivity.Factor);
            designation.SetTextColor(Color.White);
            designation.SetPadding(0, (int)(10 * MainActivity.Factor), 0, 0);
            designation.Layout((int)(110 * MainActivity.Factor), (int)(50 * MainActivity.Factor), (int)node.Width, (int)node.Height);

            if ((node.Content as DiagramEmployee).HasChild)
            {
                expanded = new ExpandButton(diagram.Context, node, FillColor);
                template.SetExpanded(expanded);
                expanded.Text = "-";
                expanded.Typeface = Typeface.Create("Times New Roman", TypefaceStyle.Bold);
                expanded.TextAlignment = TextAlignment.Center;
                expanded.Gravity = GravityFlags.Center;
                expanded.SetTextSize(Android.Util.ComplexUnitType.Px, 54 * MainActivity.Factor);
                expanded.SetTextColor(Color.White);
                expanded.SetPadding(0, (int)(10 * MainActivity.Factor), 0, 0);
                expanded.SetColor(template.m_color);
                expanded.SetStrokeColor(template.m_strokeColor);
                expanded.Layout((int)(350 * MainActivity.Factor), 0, (int)(node.Width - 10 * MainActivity.Factor), (int)node.Height);
                template.AddView(expanded);

            }
            //Add the view to the template instance.
            template.AddView(img);
            template.AddView(name);
            template.AddView(designation);
            node.Template = template;
            return template;
        }

        private void DisplayInfo(Node node)
        {
            AlertDialog.Builder alertBuilder = new AlertDialog.Builder(diagram.Context);
            var employee = (node.Content as DiagramEmployee);
            EditText editText = new EditText(diagram.Context);
            editText.Text = "Name : " + employee.Name + "\n\n" + "Designation : " + employee.Designation + "\n\n" + "ID : " + employee.ID + "\n\n" + "DOJ : " + employee.DOJ;
            editText.SetBackgroundColor(Color.WhiteSmoke);
            editText.SetTextColor(Color.Black);
            editText.Enabled = false;
            alertBuilder.SetView(editText);
            alertBuilder.SetCancelable(false);

            alertBuilder.SetPositiveButton("OK", (senderAlert, args) =>
            {
                diagram.NodeClicked += Diagram_NodeClicked;
            });
            alertBuilder.Show();
        }

        internal class ExpandButton : TextView
        {
            private Node m_node;
            private Color m_strokeColor;
            private Paint paint;
            private Dictionary<string, Color> m_fillColor;

            internal ExpandButton(Context context, Node node, Dictionary<string, Color> fillColor) : base(context)
            {
                m_node = node;
                SetWillNotDraw(false);
                SetBackgroundColor(Color.Transparent);
                m_fillColor = fillColor;
            }

            protected override void OnDraw(Canvas canvas)
            {
                paint = new Android.Graphics.Paint();
                paint.AntiAlias = true;
                paint.SetStyle(Android.Graphics.Paint.Style.Stroke);
                paint.Color = m_strokeColor;
                paint.StrokeWidth = 2 * MainActivity.Factor;
                canvas.DrawLine(0, 0, 0, m_node.Height, paint);
                base.OnDraw(canvas);
            }

            internal void SetColor(Color color)
            {
                SetBackgroundColor(color);
            }

            internal void SetStrokeColor(Color strokeColor)
            {
                m_strokeColor = strokeColor;
            }
        }

        void Dia_BeginNodeRender(object sender, BeginNodeRenderEventArgs args)
        {
            //Set the node size and its properties.
            var node = (args.Item as Node);
            DrawTemplate(node);
        }

        public override void OnApplyChanges()
        {
            //Applies the changes to the layout.
            (diagram.LayoutManager.Layout as DirectedTreeLayout).UpdateLayout();
        }


        internal class Shape : ViewGroup
        {
            internal Color m_color;
            internal Color m_strokeColor;
            private ExpandButton m_expanded;
            private Node m_node;
            private Dictionary<string, Color> m_fillColor;
            private OrganizationChart m_chart;

            internal Shape(OrganizationChart chart, Context context, Node node, DataModel dataModel, Dictionary<string, Color> fillColor, Dictionary<string, Color> strokeColor) : base(context)
            {
                m_chart = chart;
                SetX(0);
                SetY(0);
                if (LayoutParameters == null)
                    LayoutParameters = new ViewGroup.LayoutParams((int)node.Width, (int)node.Height);
                else
                {
                    LayoutParameters.Height = (int)node.Width;
                    LayoutParameters.Width = (int)node.Height;
                }
                m_node = node;
                SetBackgroundColor(Color.Transparent);
                m_fillColor = fillColor;
                SetColor(fillColor[(node.Content as DiagramEmployee).Designation]);
                SetStrokeColor(strokeColor[(node.Content as DiagramEmployee).Designation]);
            }

            protected override void OnDraw(Canvas canvas)
            {
                float cornerRadius = 20 * MainActivity.Factor;
                Paint paint = new Paint();
                paint.SetStyle(Paint.Style.Stroke);
                paint.StrokeWidth = 2 * MainActivity.Factor;
                paint.Color = m_strokeColor;
                paint.AntiAlias = true;
                canvas.DrawRoundRect(Left, Top, Right, Bottom, cornerRadius, cornerRadius, paint);
                paint = new Paint();
                paint.SetStyle(Paint.Style.Fill);
                paint.AntiAlias = true;
                paint.Color = m_color;
                canvas.DrawRoundRect(Left, Top, Right, Bottom, cornerRadius, cornerRadius, paint);
                base.OnDraw(canvas);
            }

            protected override void OnLayout(bool changed, int l, int t, int r, int b)
            {
            }

            internal void SetColor(Color color)
            {
                m_color = color;
            }

            internal void SetStrokeColor(Color color)
            {
                m_strokeColor = color;
            }

            internal void SetExpanded(ExpandButton expanded)
            {
                m_expanded = expanded;
            }
        }
    }
}