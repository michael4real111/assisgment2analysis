using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assisgment2analysis
{
    public class Edge
    {
        public Vertex From { get; set; }
        public Vertex To { get; set; }
        public double Distance { get; set; }

        public Edge(Vertex from, Vertex to, double distance)
        {
            From = from;
            To = to;
            Distance = distance;
        }
    }
}
