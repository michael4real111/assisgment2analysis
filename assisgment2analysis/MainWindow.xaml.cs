using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace assisgment2analysis
{
    public partial class MainWindow : Window
    {
        private Graph _graph;
        private SearchAlgorithms _searchAlgorithms;
        private Dictionary<string, Point> _parishCoordinates;

        public MainWindow()
        {
            InitializeComponent();
            _graph = new Graph();
            _searchAlgorithms = new SearchAlgorithms();
            InitializeGraph();
            InitializeParishComboBoxes();
            InitializeParishCoordinates();

            // Debugging Code to Verify Coordinates
            foreach (var vertex in _graph.Vertices)
            {
                if (!_parishCoordinates.ContainsKey(vertex.Parish))
                {
                    MessageBox.Show($"Parish {vertex.Parish} not found in coordinates dictionary.");
                }
            }
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

        private void InitializeParishCoordinates()
        {
            _parishCoordinates = new Dictionary<string, Point>
            {
                { "Kingston", new Point(150, 300) },
                { "Saint Andrew", new Point(170, 280) },
                { "Saint Catherine", new Point(130, 250) },
                { "Clarendon", new Point(90, 230) },
                { "Manchester", new Point(70, 210) },
                { "Saint Elizabeth", new Point(50, 190) },
                { "Westmoreland", new Point(30, 170) },
                { "Hanover", new Point(40, 150) },
                { "Saint James", new Point(60, 130) },
                { "Trelawny", new Point(80, 110) },
                { "Saint Ann", new Point(100, 90) },
                { "Saint Mary", new Point(120, 70) },
                { "Portland", new Point(140, 50) },
                { "Saint Thomas", new Point(160, 30) }
            };
        }

        private void AStarButton_Click(object sender, RoutedEventArgs e)
        {
            var startParish = StartParishComboBox.SelectedItem as string;
            var endParish = EndParishComboBox.SelectedItem as string;
            if (startParish != null && endParish != null)
            {
                var startVertex = _graph.Vertices.First(v => v.Parish == startParish);
                var endVertex = _graph.Vertices.First(v => v.Parish == endParish);

                // Debugging Code to Verify Coordinates
                if (!_parishCoordinates.ContainsKey(startVertex.Parish))
                {
                    MessageBox.Show($"Start Parish {startVertex.Parish} not found in coordinates dictionary.");
                    return;
                }
                if (!_parishCoordinates.ContainsKey(endVertex.Parish))
                {
                    MessageBox.Show($"End Parish {endVertex.Parish} not found in coordinates dictionary.");
                    return;
                }

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

                // Debugging Code to Verify Coordinates
                if (!_parishCoordinates.ContainsKey(startVertex.Parish))
                {
                    MessageBox.Show($"Start Parish {startVertex.Parish} not found in coordinates dictionary.");
                    return;
                }
                if (!_parishCoordinates.ContainsKey(endVertex.Parish))
                {
                    MessageBox.Show($"End Parish {endVertex.Parish} not found in coordinates dictionary.");
                    return;
                }

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

                // Optionally add markers for start and end points
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
            return _parishCoordinates[vertex.Parish].X;
        }

        private double GetCanvasY(Vertex vertex)
        {
            return _parishCoordinates[vertex.Parish].Y;
        }
    }
}