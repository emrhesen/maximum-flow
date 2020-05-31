using System;

namespace NetworkOptimizationProblem.Model
{
    public class InputEdge
    {

        private int capacity;
        private string nodeFrom;
        private string nodeTo;

        public InputEdge()
        {
            Capacity = 0;
        }

        public InputEdge(string nodeFrom,string nodeTo, int capacity)
        {
            NodeFrom = nodeFrom;
            NodeTo = nodeTo;
            Capacity = capacity;
        }

        public string NodeFrom
        {
            get => this.nodeFrom;

            set => nodeFrom = value.ToLower();
        }

        public string NodeTo
        {
            get => this.nodeTo;

            set => this.nodeTo = value.ToLower();
        }

        public int Capacity
        {
            get => this.capacity;

            set => this.capacity = Math.Max(value, 1);
        }
    }
}
