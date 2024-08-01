using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace assisgment2analysis
{
    public partial class MainWindow : Window
    {
        private Graph _graph;
        private SearchAlgorithms _searchAlgorithms;

        public MainWindow()
        {
            InitializeComponent();
            _graph = new Graph();
            _searchAlgorithms = new SearchAlgorithms();
            InitializeGraph();
            InitializeParishComboBoxes();
        }

        private void InitializeGraph()
        {
            // Create vertices for each parish
            var kingston = new Vertex("Kingston");
            var saintAndrew = new Vertex("Saint Andrew");
            var saintCatherine = new Vertex("Saint Catherine");
            var clarendon = new Vertex("Clarendon");
            var manchester = new Vertex("Manchester");
            var saintElizabeth = new Vertex("Saint Elizabeth");
            var westmoreland = new Vertex("Westmoreland");
            var hanover = new Vertex("Hanover");
            var saintJames = new Vertex("Saint James");
            var trelawny = new Vertex("Trelawny");
            var saintAnn = new Vertex("Saint Ann");
            var saintMary = new Vertex("Saint Mary");
            var portland = new Vertex("Portland");
            var saintThomas = new Vertex("Saint Thomas");

            // Add vertices to the graph
            _graph.AddVertex(kingston);
            _graph.AddVertex(saintAndrew);
            _graph.AddVertex(saintCatherine);
            _graph.AddVertex(clarendon);
            _graph.AddVertex(manchester);
            _graph.AddVertex(saintElizabeth);
            _graph.AddVertex(westmoreland);
            _graph.AddVertex(hanover);
            _graph.AddVertex(saintJames);
            _graph.AddVertex(trelawny);
            _graph.AddVertex(saintAnn);
            _graph.AddVertex(saintMary);
            _graph.AddVertex(portland);
            _graph.AddVertex(saintThomas);

            // Add edges to the graph (example distances, these should be actual distances)
            _graph.AddEdge(kingston, saintAndrew, 5);
            _graph.AddEdge(saintAndrew, saintCatherine, 15);
            _graph.AddEdge(saintCatherine, clarendon, 20);
            _graph.AddEdge(clarendon, manchester, 25);
            _graph.AddEdge(manchester, saintElizabeth, 30);
            _graph.AddEdge(saintElizabeth, westmoreland, 35);
            _graph.AddEdge(westmoreland, hanover, 40);
            _graph.AddEdge(hanover, saintJames, 45);
            _graph.AddEdge(saintJames, trelawny, 50);
            _graph.AddEdge(trelawny, saintAnn, 55);
            _graph.AddEdge(saintAnn, saintMary, 60);
            _graph.AddEdge(saintMary, portland, 65);
            _graph.AddEdge(portland, saintThomas, 70);
            _graph.AddEdge(saintThomas, kingston, 75);
        }

        private void InitializeParishComboBoxes()
        {
                StartParishComboBox.Items.Add("Kingston");
                StartParishComboBox.Items.Add("Saint Andrew");
                StartParishComboBox.Items.Add("Saint Catherine");
                StartParishComboBox.Items.Add("Clarendon");
                StartParishComboBox.Items.Add("Manchester");
                StartParishComboBox.Items.Add("Saint Elizabeth");
                StartParishComboBox.Items.Add("Westmoreland");
                StartParishComboBox.Items.Add("Hanover");
                StartParishComboBox.Items.Add("Saint James");
                StartParishComboBox.Items.Add("Trelawny");
                StartParishComboBox.Items.Add("Saint Ann");
                StartParishComboBox.Items.Add("Saint Mary");
                StartParishComboBox.Items.Add("Portland");
                StartParishComboBox.Items.Add("Saint Thomas");

                EndParishComboBox.Items.Add("Kingston");
                EndParishComboBox.Items.Add("Saint Andrew");
                EndParishComboBox.Items.Add("Saint Catherine");
                EndParishComboBox.Items.Add("Clarendon");
                EndParishComboBox.Items.Add("Manchester");
                EndParishComboBox.Items.Add("Saint Elizabeth");
                EndParishComboBox.Items.Add("Westmoreland");
                EndParishComboBox.Items.Add("Hanover");
                EndParishComboBox.Items.Add("Saint James");
                EndParishComboBox.Items.Add("Trelawny");
                EndParishComboBox.Items.Add("Saint Ann");
                EndParishComboBox.Items.Add("Saint Mary");
                EndParishComboBox.Items.Add("Portland");
                EndParishComboBox.Items.Add("Saint Thomas");
        }

        private void AStarButton_Click(object sender, RoutedEventArgs e)
        {
            var startParish = StartParishComboBox.SelectedItem as string;
            var endParish = EndParishComboBox.SelectedItem as string;
            if (startParish != null && endParish != null)
            {
                var startVertex = _graph.Vertices.First(v => v.Parish == startParish);
                var endVertex = _graph.Vertices.First(v => v.Parish == endParish);
                var path = _searchAlgorithms.AStarSearch(_graph, startVertex, endVertex);
                VisualizePath(path);
            }
        }

        private void BestFirstButton_Click(object sender, RoutedEventArgs e)
        {
            var startParish = StartParishComboBox.SelectedItem as string;
            var endParish = EndParishComboBox.SelectedItem as string;
            if (startParish != null && endParish != null)
            {
                var startVertex = _graph.Vertices.First(v => v.Parish == startParish);
                var endVertex = _graph.Vertices.First(v => v.Parish == endParish);
                var path = _searchAlgorithms.BestFirstSearch(_graph, startVertex, endVertex);
                VisualizePath(path);
            }
        }

        private void GreedyButton_Click(object sender, RoutedEventArgs e)
        {
            var startParish = StartParishComboBox.SelectedItem as string;
            var endParish = EndParishComboBox.SelectedItem as string;
            if (startParish != null && endParish != null)
            {
                var startVertex = _graph.Vertices.First(v => v.Parish == startParish);
                var endVertex = _graph.Vertices.First(v => v.Parish == endParish);
                var path = _searchAlgorithms.GreedySearch(_graph, startVertex, endVertex);
                VisualizePath(path);
            }
        }

        private void VisualizePath(List<Vertex> path)
        {
            // Clear previous visualization
            GraphCanvas.Children.Clear();

            // Visualize the path on the canvas
            if (path != null)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    var start = path[i];
                    var end = path[i + 1];

                    // Draw line between start and end
                    var line = new Line
                    {
                        Stroke = Brushes.Black,
                        StrokeThickness = 2,
                        X1 = GetCanvasX(start),
                        Y1 = GetCanvasY(start),
                        X2 = GetCanvasX(end),
                        Y2 = GetCanvasY(end)
                    };
                    GraphCanvas.Children.Add(line);
                }
                var startEllipse = new Ellipse
                {
                    Width = 10,
                    Height = 10,
                    Fill = Brushes.Green,
                    Margin = new Thickness(GetCanvasX(path.First()) - 5, GetCanvasY(path.First()) - 5, 0, 0)
                };
                GraphCanvas.Children.Add(startEllipse);

                var endEllipse = new Ellipse
                {
                    Width = 10,
                    Height = 10,
                    Fill = Brushes.Red,
                    Margin = new Thickness(GetCanvasX(path.Last()) - 5, GetCanvasY(path.Last()) - 5, 0, 0)
                };
                GraphCanvas.Children.Add(endEllipse);
            }
        }

        private double GetCanvasX(Vertex vertex)
        {
            // Convert vertex coordinates to canvas X coordinate
            return 0;
        }

        private double GetCanvasY(Vertex vertex)
        {
            // Convert vertex coordinates to canvas Y coordinate
            return 0;
        }
    }
}