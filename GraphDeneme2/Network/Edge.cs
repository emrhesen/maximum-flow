using System;

namespace NetworkOptimizationProblem.Network
{
    [Serializable]
    public class Edge
    {

        public Edge(Node nodeFrom , Node nodeTo,int capacity)
        {
            this.Id = Guid.NewGuid();
            this.NodeFrom = nodeFrom;
            this.NodeTo = nodeTo;
            this.Capacity = capacity;
        }

        public Guid Id { get; set; }
        public Node NodeFrom { get; set; }
        public Node NodeTo { get; set; }
        public int Capacity { get; set; }
        public int Flow { get; set; }
        public string Label { get; set; }
        public bool IsPathMarked { get; set; }

        public bool IsVisited
        {
            get
            {
                return this.Flow > 0;
            }
        }

        public bool IsFullUsed
        {
            get
            {
                return this.Flow == this.Capacity;
            }
        }

        public bool IsMinCut { get; set; }

        public bool Equals(Edge compareEdge)
        {
            return this.Id.Equals(compareEdge.Id);
        }
    }
}
