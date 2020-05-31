using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NetworkOptimizationProblem.Network;

namespace NetworkOptimizationProblem.Algorithm
{
    public class FordFulkerson
    {
        private readonly List<Node> minCutNodes = new List<Node>();
        private readonly string sourceNodeName;
        private readonly string terminalNodeName;
        private Graph flowGraph;
        private int maxFlow;
        private List<Edge> minCutEdges = new List<Edge>();
        private Graph residualGraph;
        public FordFulkerson(Graph inputGraph, string sourceNodeName, string terminalNodeName)
        {
            this.sourceNodeName = sourceNodeName;
            this.terminalNodeName = terminalNodeName;

            this.flowGraph = (Graph)inputGraph.Clone();
            this.residualGraph = (Graph)inputGraph.Clone();

            foreach (var edge in this.residualGraph.Edges.ToList())
            {
                var residualEdge = new Edge(edge.NodeTo, edge.NodeFrom, 0);
                edge.NodeTo.Edges.Add(residualEdge);
                this.residualGraph.Edges.Add(residualEdge);
            }
        }
        public int MaxFlow => this.maxFlow;
        public int MinCut
        {
            get
            {
                return minCutEdges.Sum(e => e.Capacity);
            }
        }
        private void FindMaxFlow(Node sourceNode, Node terminalNode)
        {
            this.maxFlow = 0;

            var path = this.BreadthFirstSearch(sourceNode, terminalNode);

            // color found path
            this.HighlightFoundPath(path);
            //this.graphHistory.AddGraphStep(this.flowGraph, this.residualGraph);
            this.ResetHighlight(path);

            while (path != null && path.Count > 0)
            {
                var minCapacity = path.Min(e => e.Capacity);

                this.AugmentPath(path, minCapacity);

                //this.graphHistory.AddGraphStep(this.flowGraph, this.residualGraph);

                this.maxFlow += minCapacity;
                path = this.BreadthFirstSearch(sourceNode, terminalNode);

                this.HighlightFoundPath(path);
                //this.graphHistory.AddGraphStep(this.flowGraph, this.residualGraph);
                this.ResetHighlight(path);
            }
        }
        private void FindMinCut(Node root)
        {
            var queuedNodes = new Queue<Node>();
            var discoveredNodes = new List<Node>();

            this.minCutNodes.Clear();
            this.minCutEdges.Clear();

            queuedNodes.Enqueue(root);

            while (queuedNodes.Count > 0)
            {
                var currentNode = queuedNodes.Dequeue();
                if (!discoveredNodes.Contains(currentNode))
                {
                    this.minCutNodes.Add(currentNode);
                    discoveredNodes.Add(currentNode);

                    var edges = currentNode.Edges;
                    foreach (var edge in edges)
                    {
                        var nodeTo = edge.NodeTo;
                        if (edge.Capacity > 0 && !discoveredNodes.Contains(nodeTo))
                        {
                            queuedNodes.Enqueue(nodeTo);
                            this.minCutEdges.Add(edge);
                        }
                    }
                }
            }

            this.minCutEdges = new List<Edge>();
            foreach (
                var node in this.flowGraph.Nodes.Where(p => this.minCutNodes.Any(r => r.Equals(p))).ToList())
            {
                var edges = node.Edges;
                foreach (var edge in edges)
                {
                    if (this.minCutNodes.Any(p => p.Equals(edge.NodeTo)))
                    {
                        continue;
                    }

                    if (edge.Capacity > 0 && !this.minCutEdges.Contains(edge))
                    {
                        this.minCutEdges.Add(edge);
                    }
                }
            }

            this.minCutNodes.ForEach(mcn => mcn.IsMinCut = true);
            this.minCutEdges.ForEach(mcn => mcn.IsMinCut = true);
        }
        private List<Edge> BreadthFirstSearch(Node sourceNode, Node targetNode)
        {
            sourceNode.ParentNode = null;
            targetNode.ParentNode = null;

            var queuedNodes = new Queue<Node>();
            var discoveredNodes = new List<Node>();
            queuedNodes.Enqueue(sourceNode);

            while (queuedNodes.Count > 0)
            {
                var currentNode = queuedNodes.Dequeue();
                discoveredNodes.Add(currentNode);

                if (currentNode.Name == targetNode.Name)
                {
                    return GetPath(currentNode);
                }

                var currentNodeEdges = currentNode.Edges;
                foreach (var edge in currentNodeEdges.OrderBy(e => e.NodeTo.Name))
                {
                    var nodeTo = edge.NodeTo;
                    if (edge.Capacity > 0 && !discoveredNodes.Contains(nodeTo))
                    {
                        nodeTo.ParentNode = currentNode;
                        queuedNodes.Enqueue(nodeTo);
                    }
                }
            }

            return null;
        }
        private void AugmentPath(IEnumerable<Edge> path, int minCapacity)
        {
            foreach (var edge in path)
            {
                var flowEdge = this.flowGraph.Edges.FirstOrDefault(e => e.Equals(edge));

                if (flowEdge != null)
                {
                    flowEdge.Flow += minCapacity;
                }

                edge.Capacity -= minCapacity;
                var residualEdge = edge.NodeTo.Edges.Find(e => e.NodeTo.Equals(edge.NodeFrom));
                residualEdge.Capacity += minCapacity;
            }
        }
        private static List<Edge> GetPath(Node currentNode)
        {
            var path = new List<Edge>();

            while (currentNode.ParentNode != null)
            {
                var parentEdge = currentNode.ParentNode.Edges.Find(e => e.NodeTo.Equals(currentNode));
                path.Add(parentEdge);
                currentNode = currentNode.ParentNode;
            }

            return path;
        }
        private void HighlightFoundPath(List<Edge> path)
        {
            if (path != null)
            {
                path.ForEach(edge => edge.IsPathMarked = true);
            }
        }
        private void ResetHighlight(List<Edge> path)
        {
            if (path != null)
            {
                path.ForEach(edge => edge.IsPathMarked = false);
            }
        }
        public Graph RunAlgorithm()
        {
            var sourceNode = this.residualGraph.Nodes.Find(n => n.Name.Equals(this.sourceNodeName));
            var terminalNode = this.residualGraph.Nodes.Find(n => n.Name.Equals(this.terminalNodeName));

            Debug.WriteLine("\n** FordFulkerson");

            // MAX-FLOW 
            this.FindMaxFlow(sourceNode, terminalNode);
            Debug.WriteLine("Max-Flow: {0}", this.MaxFlow);

            // MIN-CUT
            this.FindMinCut(sourceNode);

            Debug.WriteLine("Min-Cut: {0}", this.MinCut);

            Debug.WriteLine("Min-Cut-Nodes:");
            this.minCutNodes.ForEach(n => Debug.WriteLine(n.Name));

            Debug.WriteLine("Min-Cut-Edges:");
            this.minCutEdges.ForEach(e => Debug.WriteLine("{0}--{1}-->{2}", e.NodeFrom.Name, e.Capacity, e.NodeTo.Name));

            return this.flowGraph;
        }
    }
}
