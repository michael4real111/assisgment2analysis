using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assisgment2analysis
{
    public class Graph
    {
        public List<Vertex> Vertices { get; set; }

        public Graph()
        {
            Vertices = new List<Vertex>();
        }

        public void AddVertex(Vertex vertex)
        {
            Vertices.Add(vertex);
        }

        public void AddEdge(Vertex from, Vertex to, double distance)
        {
            from.Edges.Add(new Edge(from, to, distance));
            to.Edges.Add(new Edge(to, from, distance)); // For undirected graph
        }
    }
}
