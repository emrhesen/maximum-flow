using System;
using System.Collections.Generic;

namespace NetworkOptimizationProblem.Network
{
    [Serializable]
    public class Node
    {
        public Node(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Edges = new List<Edge>();
        }

        public Guid Id { get; set; }
        public List<Edge> Edges { get; set; }
        public string Name { get; set; }
        public Node ParentNode { get; set; }
        public bool IsMinCut { get; set; }

        public bool Equals(Node compareMode)
        {
            return this.Id.Equals(compareMode.Id);
        }
    }
}
