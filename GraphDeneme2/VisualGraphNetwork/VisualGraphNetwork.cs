using System.Linq;
using Microsoft.Msagl.Drawing;
using Graph = NetworkOptimizationProblem.Network.Graph;

namespace NetworkOptimizationProblem.VisualGraphNetwork
{
    public class VisualGraphNetwork
    {
        private readonly Graph _graph;

        public VisualGraphNetwork(Graph graph)
        {
            _graph = graph;
        }


        public Microsoft.Msagl.Drawing.Graph CreateFlowGraph()
        {
            var msaglGraph = this.CreateGraph();

            foreach (var edge in this._graph.Edges)
            {
                var addedge = msaglGraph.AddEdge(
                    edge.NodeFrom.Name,
                    string.Format("{0}/{1}", edge.Flow, edge.Capacity),
                    edge.NodeTo.Name);
                addedge.Attr.LineWidth = 1;

                if (edge.IsVisited)
                {
                    addedge.Attr.Color = Color.Blue;
                    if (edge.IsFullUsed)
                    {
                        addedge.Attr.LineWidth = 3;
                    }
                }

                if (edge.IsMinCut)
                {
                    addedge.Attr.Color = Color.Red;
                    addedge.Attr.AddStyle(Style.Dashed);
                    addedge.SourceNode.Attr.Color = Color.Red;
                }

                addedge.SourceNode.Attr.Shape = Shape.Box;
                addedge.TargetNode.Attr.Shape = Shape.Box;
            }

            return msaglGraph;
        }

        public Microsoft.Msagl.Drawing.Graph CreateResidualGraph()
        {
            var msaglGraph = this.CreateGraph();

            foreach (var edge in this._graph.Edges.Where(e => e.Capacity > 0))
            {
                var addedge = msaglGraph.AddEdge(
                    edge.NodeFrom.Name,
                    string.Format("{0}", edge.Capacity),
                    edge.NodeTo.Name);

                addedge.Attr.Color = edge.IsPathMarked ? Color.Orange : Color.Black;

                addedge.SourceNode.Attr.Shape = Shape.Circle;
                addedge.TargetNode.Attr.Shape = Shape.Circle;
            }

            return msaglGraph;
        }

        private Microsoft.Msagl.Drawing.Graph CreateGraph()
        {
            var msaglGraph = new Microsoft.Msagl.Drawing.Graph();
            msaglGraph.Attr.OptimizeLabelPositions = true;
            msaglGraph.Attr.LayerDirection = LayerDirection.LR;

            return msaglGraph;
        }
    }
}
