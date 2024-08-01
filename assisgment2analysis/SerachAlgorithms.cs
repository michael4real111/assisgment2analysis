using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assisgment2analysis
{
    public class SearchAlgorithms
    {
        public List<Vertex> AStarSearch(Graph graph, Vertex start, Vertex goal)
        {
            var closedSet = new HashSet<Vertex>();
            var openSet = new SortedSet<Vertex>(Comparer<Vertex>.Create((a, b) => GetFScore(a).CompareTo(GetFScore(b))));
            var cameFrom = new Dictionary<Vertex, Vertex>();
            var gScore = new Dictionary<Vertex, double>();
            var fScore = new Dictionary<Vertex, double>();

            openSet.Add(start);
            gScore[start] = 0;
            fScore[start] = Heuristic(start, goal);

            while (openSet.Count > 0)
            {
                var current = openSet.First();
                if (current == goal)
                    return ReconstructPath(cameFrom, current);

                openSet.Remove(current);
                closedSet.Add(current);

                foreach (var edge in current.Edges)
                {
                    var neighbor = edge.To;
                    if (closedSet.Contains(neighbor))
                        continue;

                    var tentativeGScore = gScore[current] + edge.Distance;
                    if (!openSet.Contains(neighbor))
                        openSet.Add(neighbor);
                    else if (tentativeGScore >= gScore[neighbor])
                        continue;

                    cameFrom[neighbor] = current;
                    gScore[neighbor] = tentativeGScore;
                    fScore[neighbor] = gScore[neighbor] + Heuristic(neighbor, goal);
                }
            }

            return null;
        }

        public List<Vertex> BestFirstSearch(Graph graph, Vertex start, Vertex goal)
        {
            var closedSet = new HashSet<Vertex>();
            var openSet = new SortedSet<Vertex>(Comparer<Vertex>.Create((a, b) => Heuristic(a, goal).CompareTo(Heuristic(b, goal))));
            var cameFrom = new Dictionary<Vertex, Vertex>();

            openSet.Add(start);

            while (openSet.Count > 0)
            {
                var current = openSet.First();
                if (current == goal)
                    return ReconstructPath(cameFrom, current);

                openSet.Remove(current);
                closedSet.Add(current);

                foreach (var edge in current.Edges)
                {
                    var neighbor = edge.To;
                    if (closedSet.Contains(neighbor))
                        continue;

                    if (!openSet.Contains(neighbor))
                        openSet.Add(neighbor);

                    cameFrom[neighbor] = current;
                }
            }

            return null;
        }

        public List<Vertex> GreedySearch(Graph graph, Vertex start, Vertex goal)
        {
            var closedSet = new HashSet<Vertex>();
            var openSet = new SortedSet<Vertex>(Comparer<Vertex>.Create((a, b) => Heuristic(a, goal).CompareTo(Heuristic(b, goal))));
            var cameFrom = new Dictionary<Vertex, Vertex>();

            openSet.Add(start);

            while (openSet.Count > 0)
            {
                var current = openSet.First();
                if (current == goal)
                    return ReconstructPath(cameFrom, current);

                openSet.Remove(current);
                closedSet.Add(current);

                foreach (var edge in current.Edges)
                {
                    var neighbor = edge.To;
                    if (closedSet.Contains(neighbor))
                        continue;

                    if (!openSet.Contains(neighbor))
                        openSet.Add(neighbor);

                    cameFrom[neighbor] = current;
                }
            }

            return null;
        }

        private double Heuristic(Vertex a, Vertex b)
        {
            // Implement heuristic function here (e.g., straight-line distance)
            return 0;
        }

        private double GetFScore(Vertex v)
        {
            // Return fScore for vertex
            return 0;
        }

        private List<Vertex> ReconstructPath(Dictionary<Vertex, Vertex> cameFrom, Vertex current)
        {
            var totalPath = new List<Vertex> { current };
            while (cameFrom.ContainsKey(current))
            {
                current = cameFrom[current];
                totalPath.Add(current);
            }
            totalPath.Reverse();
            return totalPath;
        }
    }
}
