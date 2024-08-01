using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assisgment2analysis
{
    public class Vertex
    {
        public string Parish { get; set; }
        public List<Edge> Edges { get; set; }

        public Vertex(string parish)
        {
            Parish = parish;
            Edges = new List<Edge>();
        }
    }
}
