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
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfDiagram
{
    public partial class OrganizationChart : SampleView
    {
        Dictionary<string, Color> FillColor;
        Dictionary<string, Color> StrokeColor;
        Frame Notifier;
        bool IsOverviewEnabled;
        public OrganizationChart()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.Android)
            {
                Xamarin.Forms.DependencyService.Get<IText>().GenerateFactor();
                diagram.IsReadOnly = true;
            }
            if (Device.RuntimePlatform == Device.UWP)
            {
                diagram.IsReadOnly = true;
                diagram.BackgroundColor = Color.White;
            }
            diagram.EnableSelectors = false;
            diagram.PageSettings.PageBackGround = Color.White;
            diagram.NodeClicked += Diagram_NodeClicked;
            diagram.DiagramClicked += Diagram_DiagramClicked;
            FillColor = new Dictionary<string, Color>();
            FillColor.Add("Managing Director", Color.FromRgb(239, 75, 93));
            FillColor.Add("Project Manager", Color.FromRgb(49, 162, 255));
            FillColor.Add("Senior Manager", Color.FromRgb(49, 162, 255));
            FillColor.Add("Project Lead", Color.FromRgb(0, 194, 192));
            FillColor.Add("Senior S/W Engg", Color.FromRgb(0, 194, 192));
            FillColor.Add("Software Engg", Color.FromRgb(0, 194, 192));
            FillColor.Add("Team Lead", Color.FromRgb(0, 194, 192));
            FillColor.Add("Project Trainee", Color.FromRgb(255, 129, 0));

            StrokeColor = new Dictionary<string, Color>();
            StrokeColor.Add("Managing Director", Color.FromRgb(201, 32, 61));
            StrokeColor.Add("Project Manager", Color.FromRgb(23, 132, 206));
            StrokeColor.Add("Senior Manager", Color.FromRgb(23, 132, 206));
            StrokeColor.Add("Project Lead", Color.FromRgb(4, 142, 135));
            StrokeColor.Add("Senior S/W Engg", Color.FromRgb(4, 142, 135));
            StrokeColor.Add("Software Engg", Color.FromRgb(4, 142, 135));
            StrokeColor.Add("Team Lead", Color.FromRgb(4, 142, 135));
            StrokeColor.Add("Project Trainee", Color.FromRgb(206, 98, 9));
            DataModel datamodel = new DataModel();
            DataSourceSettings settings = new DataSourceSettings();
            datamodel.Data();
            settings.ParentId = "ReportingPerson";
            settings.Id = "Name";
            settings.DataSource = datamodel.employee;
            diagram.DataSourceSettings = settings;

            //To Represent LayoutManager Properties
            if (Device.RuntimePlatform == Device.UWP)
            {
                diagram.LayoutManager = new LayoutManager()
                {
                    Layout = new DirectedTreeLayout()
                    {
                        Type = LayoutType.Hierarchical,
                        HorizontalSpacing = 35,
                    }
                };
            }
            else
            {
                diagram.LayoutManager = new LayoutManager()
                {
                    Layout = new DirectedTreeLayout()
                    {
                        Type = LayoutType.Organization,
                        HorizontalSpacing = 35,
                    }
                };
            }
            for (int i = 0; i < diagram.Connectors.Count; i++)
            {
                diagram.Connectors[i].TargetDecoratorType = DecoratorType.None;
                diagram.Connectors[i].Style.StrokeBrush = new SolidBrush(Color.FromRgb(127, 132, 133));
                diagram.Connectors[i].Style.StrokeWidth = 1;
            }
            if (Device.RuntimePlatform != Device.UWP)
                overview.PreventRefresh = true;
            diagram.BeginNodeRender += Diagram_BeginNodeRender;
            diagram.BeginNodeLayout += Diagram_BeginNodeLayout;
            diagram.ItemLongPressed += Diagram_ItemLongPressed;
            diagram.Loaded += Diagram_Loaded;
            diagram.LayoutNodeDropped += Diagram_OnLayoutNodeDropped;
            diagram.OverviewPanel = overview;
            if (Device.RuntimePlatform == Device.iOS)
            {
                overview.Width = 200;
                overview.Height = 200;
            }
            diagram.EndNodeLayout += Diagram_EndNodeLayout;
            ToggleOverview(true);
            if (Device.RuntimePlatform != Device.UWP && Device.Idiom != TargetIdiom.Tablet)
            {
                ToggleOverview(false);
                IsOverviewEnabled = false;
                overviewSwitch.IsVisible = false;
                LayoutTextLabel.IsVisible = false;
            }
            if(Device.RuntimePlatform == Device.UWP)
            {
                LayoutNodeDrag.IsVisible = false;
                LayoutNodeDragLabel.IsVisible = false;
            }
        }

        private void Diagram_EndNodeLayout(object sender, EventArgs e)
        {
            UpdateOverviewPanel();
        }

        private void UpdateOverviewPanel()
        {
            if (diagram.OverviewPanel != null && IsOverviewEnabled)
            {
                diagram.OverviewPanel.ForceRefresh();
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
                    Connector con; bool hasChild = false;
                    for (int i = 0; i < connectors.Count; i++)
                    {
                        con = connectors[i];
                        con.SourceNode = droppedNode;
                        hasChild = true;

                    }
                    if (hasChild)
                    {
                        Node PrevParentNode = GetParent((draggedNode.Content as DiagramEmployee).ReportingPerson);
                        if (PrevParentNode != null && PrevParentNode.OutConnectors.Count == 0)
                        {
                            (PrevParentNode.Content as DiagramEmployee).HasChild = false;
                            if (Device.RuntimePlatform == Device.iOS)
                                DrawTemplate(PrevParentNode);
                            else
                                UpdateTemplate(PrevParentNode, "");
                        }
                        DiagramEmployee ParentEmployee = (droppedNode.Content as DiagramEmployee);
                        (draggedNode.Content as DiagramEmployee).ReportingPerson = ParentEmployee.Name;
                        ParentEmployee.HasChild = true;
                        UpdateTemplate(droppedNode, "-");

                        ExpandAll(draggedNode);                        
                        droppedNode.IsExpanded = true;
                        diagram.LayoutManager.Layout.UpdateLayout();
                        UpdateOverviewPanel();
                    }
                }
            }
        }
        private void ExpandAll(Node node)
        {
            if ((node.Content as DiagramEmployee).HasChild)
            {
                node.IsExpanded = true;
                UpdateTemplate(node, "-");
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
        void LayoutNodeDrag_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            if (LayoutNodeDrag.IsToggled)
            {
                (diagram.LayoutManager.Layout as DirectedTreeLayout).IsDraggable = true;
            }
            else
            {
                (diagram.LayoutManager.Layout as DirectedTreeLayout).IsDraggable = false;

            }
        }

        private void Diagram_Loaded(object sender)
        {
            var RootNode = diagram.Nodes[0];
            diagram.BringToView(RootNode);
            UpdateOverviewPanel();
        }
        private void ToggleOverview(bool isShow)
        {
            if (isShow)
            {
                if(Device.RuntimePlatform == Device.UWP)
                    parent.RowDefinitions[1].Height = GridLength.Star;
                ToggleOverviewPanel(isShow, 200);
            }
            else
            {
                if (Device.RuntimePlatform == Device.UWP)
                    parent.RowDefinitions[1].Height = GridLength.Auto;
                ToggleOverviewPanel(isShow, 0);
            }
        }

        private void ToggleOverviewPanel(bool state, int heightReq)
        {
            IsOverviewEnabled = state;
            OverviewPanel.IsVisible = state;
            OverviewPanel.HeightRequest = heightReq;
        }

        private void Diagram_ItemLongPressed(object sender, ItemLongPressedEventArgs args)
        {
            if (args.Item is Node && !LayoutNodeDrag.IsToggled)
                DisplayInfo(args.Item as Node);
        }

        void Diagram_NodeClicked(object sender, NodeClickedEventArgs args)
        {
            if ((args.Item.Content as DiagramEmployee).HasChild && args.Item.IsExpanded)
            {
                UpdateTemplate(args.Item, "+");
                args.Item.IsExpanded = false;
            }
            else if ((args.Item.Content as DiagramEmployee).HasChild && !args.Item.IsExpanded)
            {
                UpdateTemplate(args.Item, "-");
                args.Item.IsExpanded = true;
            }
            if (Device.RuntimePlatform == Device.iOS)
                diagram.OverviewPanel.ForceRefresh();
        }

        private void Diagram_BeginNodeRender(object sender, BeginNodeRenderEventArgs args)
        {
            var node = (args.Item as Node);
            UpdateTemplate(node, "-");
        }

        private void Diagram_BeginNodeLayout(object sender, BeginNodeLayoutEventArgs args)
        {
            if (!args.HasChildNodes)
            {
                args.Type = ChartType.Left;
                args.Orientation = Orientation.Vertical;
            }
        }
        void overview_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            ToggleOverview(overviewSwitch.IsToggled);
        }

        private void DrawTemplate(Node node)
        {
            node.Style.StrokeWidth = 1;
            StackLayout root;
            var NodeTemplate = new DataTemplate(() =>
            {
                root = new StackLayout()
                {
                    WidthRequest = node.Width,
                    HeightRequest = node.Height,
                    Orientation = StackOrientation.Horizontal,
                    BackgroundColor = Color.Transparent
                };
                Image image = new Image();
                image.WidthRequest = 35;
                image.HeightRequest = 35;
                image.Margin = new Thickness(8);
                image.Source = (node.Content as DiagramEmployee).ImageUrl;
                root.Children.Add(image);
                StackLayout content = new StackLayout()
                {
                    WidthRequest = 100,
                    HeightRequest = 40,
                    Orientation = StackOrientation.Vertical
                };
                Label name = new Label()
                {
                    TextColor = Color.FromRgb(255, 255, 255),
                    Margin = new Thickness(0, 8, 0, 0),
                    Text = (node.Content as DiagramEmployee).Name,
                    FontSize = 10,
                    HorizontalOptions = LayoutOptions.StartAndExpand
                };
                Label designation = new Label()
                {
                    Text = (node.Content as DiagramEmployee).Designation,
                    TextColor = Color.FromRgb(255, 255, 255),
                    FontSize = 10,
                    HorizontalOptions = LayoutOptions.StartAndExpand
                };
                content.Children.Add(name);
                content.Children.Add(designation);
                root.Children.Add(content);
                Frame style = new Frame();
                style.Content = root;
                style.Padding = new Thickness(0);
                style.CornerRadius = 5;
                style.BackgroundColor = FillColor[(node.Content as DiagramEmployee).Designation];
                style.BorderColor = StrokeColor[((node.Content as DiagramEmployee).Designation)];
                style.HasShadow = false;
                return style;
            });
            node.Template = NodeTemplate;
        }
        private void UpdateTemplate(Node node, string state)
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                node.Width = 150;
                node.Height = 50;
            }
            node.Style.StrokeWidth = 1;
            StackLayout root;
            var NodeTemplate = new DataTemplate(() =>
            {
                root = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    BackgroundColor = Color.Transparent
                };
                Image image = new Image();
                image.WidthRequest = 35;
                image.HeightRequest = 35;
                image.Margin = new Thickness(8);
                if (Device.RuntimePlatform == Device.UWP)
                {
                    image.Source = ImagePathConverter.GetImageSource((node.Content as DiagramEmployee).ImageUrl);
                }
                else
                {
                    image.Source = (node.Content as DiagramEmployee).ImageUrl;
                }
                root.Children.Add(image);
                StackLayout content = new StackLayout()
                {
                    WidthRequest = 100,
                    HeightRequest = 40,
                    Orientation = StackOrientation.Vertical
                };
                Label name = new Label()
                {
                    TextColor = Color.FromRgb(255, 255, 255),
                    Margin = new Thickness(0, 8, 0, 0),
                    Text = (node.Content as DiagramEmployee).Name,
                    FontSize = 10,
                    HorizontalOptions = LayoutOptions.StartAndExpand
                };
                // name.SetBinding(Label.TextProperty, new Binding((node.Content as Employee).Name));
                Label designation = new Label()
                {
                    Text = (node.Content as DiagramEmployee).Designation,
                    TextColor = Color.FromRgb(255, 255, 255),
                    FontSize = 10,
                    HorizontalOptions = LayoutOptions.StartAndExpand
                };
                // designation.SetBinding(Label.TextProperty, new Binding((node.Content as Employee).Designation));
                content.Children.Add(name);
                content.Children.Add(designation);
                root.Children.Add(content);
                if (Device.RuntimePlatform != Device.UWP)
                    if ((node.Content as DiagramEmployee).HasChild)
                    {
                        root.WidthRequest = 180;
                        Label Expand = new Label()
                        {
                            TextColor = Color.White,
                            Text = state,
                            FontSize = 35,
                            VerticalOptions = LayoutOptions.Center
                        };
                        Expand.Margin = new Thickness(0, 0, 5, 3);
                        root.Children.Add(Expand);
                    }
                if (Device.RuntimePlatform == Device.Android)
                    return root;
                else
                {
                    Frame style = new Frame();
                    style.Content = root;
                    style.Padding = new Thickness(0);
                    style.CornerRadius = 5;
                    style.BackgroundColor = FillColor[(node.Content as DiagramEmployee).Designation];
                    style.BorderColor = StrokeColor[((node.Content as DiagramEmployee).Designation)];
                    style.HasShadow = false;
                    return style;
                }
            });
            if (Device.RuntimePlatform == Device.Android)
            {
                node.Style.Brush = new SolidBrush(FillColor[(node.Content as DiagramEmployee).Designation]);
                node.Style.StrokeBrush = new SolidBrush(StrokeColor[((node.Content as DiagramEmployee).Designation)]);
            }
            node.Template = NodeTemplate;
        }

        void Diagram_DiagramClicked(object sender, DiagramClickedEventArgs args)
        {
            if (Notifier != null)
            {
                parent.Children.Remove(Notifier);
                Notifier = null;
                diagram.EnableZoomAndPan = true;
                diagram.NodeClicked += Diagram_NodeClicked;
                diagram.ItemLongPressed += Diagram_ItemLongPressed;
            }
        }

        void Ok_Clicked(object sender, EventArgs e)
        {
            parent.Children.Remove(Notifier);
            Notifier = null;
            diagram.EnableZoomAndPan = true;
            diagram.NodeClicked += Diagram_NodeClicked;
            diagram.ItemLongPressed += Diagram_ItemLongPressed;
        }
        void DisplayInfo(Node node)
        {
            diagram.EnableZoomAndPan = false;
            diagram.NodeClicked -= Diagram_NodeClicked;
            diagram.ItemLongPressed -= Diagram_ItemLongPressed;
            StackLayout root;
            root = new StackLayout();

            Image image = new Image();
            image.WidthRequest = 120;
            image.HeightRequest = 120;
            image.VerticalOptions = LayoutOptions.Start;
            image.HorizontalOptions = LayoutOptions.Center;
            image.Source = (node.Content as DiagramEmployee).ImageUrl;
            root.Children.Add(image);

            Label Name = new Label { Text = (node.Content as DiagramEmployee).Name, HorizontalOptions = LayoutOptions.CenterAndExpand };
            Name.TextColor = Color.Black;
            Name.FontAttributes = FontAttributes.Bold;
            root.Children.Add(Name);

            Grid grid = new Grid();
            grid.RowSpacing = 12;
            grid.HorizontalOptions = LayoutOptions.CenterAndExpand;
            grid.Margin = new Thickness(0, 22, 0, 0);
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            var Designation = new Label { Text = "Designation:", HorizontalOptions = LayoutOptions.End };
            var DesignationValue = new Label { Text = (node.Content as DiagramEmployee).Designation, HorizontalOptions = LayoutOptions.Start, FontAttributes = FontAttributes.Bold, TextColor = Color.Black };
            var ID = new Label { Text = "ID:", HorizontalOptions = LayoutOptions.End };
            var IDValue = new Label { Text = (node.Content as DiagramEmployee).ID, HorizontalOptions = LayoutOptions.Start, FontAttributes = FontAttributes.Bold, TextColor = Color.Black };
            var DOJ = new Label { Text = "DOJ:", HorizontalOptions = LayoutOptions.End };
            var DOJValue = new Label { Text = (node.Content as DiagramEmployee).DOJ, HorizontalOptions = LayoutOptions.Start, FontAttributes = FontAttributes.Bold, TextColor = Color.Black };
            grid.Children.Add(Designation, 0, 0);
            grid.Children.Add(DesignationValue, 1, 0);
            grid.Children.Add(ID, 0, 1);
            grid.Children.Add(IDValue, 1, 1);
            grid.Children.Add(DOJ, 0, 2);
            grid.Children.Add(DOJValue, 1, 2);
            if ((node.Content as DiagramEmployee).ReportingPerson != null)
            {
                var Supervisor = new Label { Text = "Supervisor:", HorizontalOptions = LayoutOptions.End };
                var SupervisorValue = new Label { Text = (node.Content as DiagramEmployee).ReportingPerson, HorizontalOptions = LayoutOptions.Start, FontAttributes = FontAttributes.Bold, TextColor = Color.Black };
                grid.Children.Add(Supervisor, 0, 3);
                grid.Children.Add(SupervisorValue, 1, 3);
            }


            BoxView line = new BoxView() { BackgroundColor = Color.Gray, VerticalOptions = LayoutOptions.Start, HorizontalOptions = LayoutOptions.FillAndExpand, HeightRequest = 1 };
            grid.Children.Add(line, 0, 4);
            Grid.SetColumnSpan(line, 2);

            Button button = new Button { Text = "CLOSE", BackgroundColor = Color.White, HorizontalOptions = LayoutOptions.FillAndExpand, WidthRequest = 300, Margin = new Thickness(0, 2, 0, 2) };
            button.Clicked += Ok_Clicked;
            grid.Children.Add(button, 0, 4);
            Grid.SetColumnSpan(button, 2);

            root.Children.Add(grid);

            Notifier = new Frame();
            Notifier.WidthRequest = 300;
            if (Device.RuntimePlatform == Device.Android)
                Notifier.HeightRequest = 350;
            else
                Notifier.HeightRequest = 350;
            Notifier.Content = root;
            Notifier.VerticalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Center };
            Notifier.HorizontalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Center };
            Notifier.CornerRadius = 5;
            Notifier.BackgroundColor = Color.White;
            Notifier.BorderColor = FillColor[(node.Content as DiagramEmployee).Designation];
            parent.Children.Add(Notifier);
        }
    }

    [Preserve(AllMembers = true)]
    public class OverviewPanelBorderHelper : Frame
    {

    }
}
