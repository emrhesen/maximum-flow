using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NetworkOptimizationProblem.Network
{
    [Serializable]
    public class Graph : ICloneable
    {
        public Graph()
        {
            this.Nodes = new List<Node>();
            this.Edges = new List<Edge>();
        }

        public List<Node> Nodes { get; set; }
        public List<Edge> Edges { get; set; }

        public object Clone()
        {
            var binaryFormatter = new BinaryFormatter();
            var memoryStream = new MemoryStream();
            binaryFormatter.Serialize(memoryStream, this);
            memoryStream.Seek(0, SeekOrigin.Begin);
            var graph = (Graph)binaryFormatter.Deserialize(memoryStream);

            return graph;
        }
    }
}
