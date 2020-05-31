using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using NetworkOptimizationProblem.Algorithm;
using NetworkOptimizationProblem.Model;
using NetworkOptimizationProblem.Network;

namespace NetworkOptimizationProblem
{
    public partial class frmMain : Form
    {
        private ObservableCollection<InputEdge> inputEdges = new ObservableCollection<InputEdge>();

        public frmMain()
        {
            InitializeComponent();
        }

        public ObservableCollection<InputEdge> InputEdges
        {
            get => this.inputEdges;
            set => this.inputEdges = value;
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            PopulateNodeCount();
            cmbNodeCount.SelectedIndex = 0;
        }

        private void btn_CreateGraph_Click(object sender, EventArgs e)
        {

            if (inputEdges.Count == 0)
            {
                MessageBox.Show("Musluk Sayısı seçimi yapınız !!!");
                return;
            }

            const string Source = "b";
            const string Target = "s";

            if (!inputEdges.Select(x => x.NodeFrom).Contains(Source))
            {
                MessageBox.Show("Başlangıç b olmalıdır.");
                return;
            }

            if (!inputEdges.Select(x => x.NodeTo).Contains(Target))
            {
                MessageBox.Show("Bitiş s olmalıdır.");
                return;
            }


            var fordFulkerson = new FordFulkerson(ConvertInputEdgesToGraph(InputEdges), Source, Target);

            var graph = fordFulkerson.RunAlgorithm();

            txtMaxFlow.Text = fordFulkerson.MaxFlow.ToString();
            txtMinCut.Text = fordFulkerson.MinCut.ToString();

            var visualGraphNetwork = new VisualGraphNetwork.VisualGraphNetwork(graph);
            this.graphViewer.Graph = visualGraphNetwork.CreateFlowGraph();

        }

        private Graph ConvertInputEdgesToGraph(IEnumerable<InputEdge> inputEdges)
        {
            var graph = new Graph();

            inputEdges = inputEdges.Where(x => x.NodeTo != null || x.NodeFrom != null);

            foreach (var inputEdge in inputEdges)
            {
                var nodeFrom = graph.Nodes.Find(n => n.Name.Equals(inputEdge.NodeFrom));
                if (nodeFrom == null)
                {
                    nodeFrom = new Node(inputEdge.NodeFrom);
                    graph.Nodes.Add(nodeFrom);
                }

                var nodeTo = graph.Nodes.Find(n => n.Name.Equals(inputEdge.NodeTo));
                if (nodeTo == null)
                {
                    nodeTo = new Node(inputEdge.NodeTo);
                    graph.Nodes.Add(nodeTo);
                }

                var edge = new Edge(nodeFrom, nodeTo, inputEdge.Capacity);
                nodeFrom.Edges.Add(edge);
                graph.Edges.Add(edge);
            }

            return graph;
        }

        private void PopulateNodeCount()
        {
            cmbNodeCount.Items.Clear();

            for (int i = 1; i < 51; i++)
            {
                cmbNodeCount.Items.Add(i.ToString());
            }
        }

        private void cmbNodeCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            InputEdges.Clear();

            if (cmbNodeCount.SelectedIndex == 0)
            {
                return;
            }

            //var selectedNodeCount = cmbNodeCount.SelectedItem.ToString();

            //for (int i = 1; i < Convert.ToInt32(selectedNodeCount) + 1; i++)
            //{
            //    InputEdges.Add(new InputEdge());
            //}


            InputEdges.Add(new InputEdge("b", "2", 10));
            InputEdges.Add(new InputEdge("b", "3", 5));
            InputEdges.Add(new InputEdge("b", "4", 15));

            InputEdges.Add(new InputEdge("2", "3", 4));
            InputEdges.Add(new InputEdge("2", "5", 9));
            InputEdges.Add(new InputEdge("2", "6", 15));

            InputEdges.Add(new InputEdge("3", "6", 8));
            InputEdges.Add(new InputEdge("3", "4", 4));

            InputEdges.Add(new InputEdge("4", "7", 30));

            InputEdges.Add(new InputEdge("5", "6", 15));
            InputEdges.Add(new InputEdge("5", "s", 10));

            InputEdges.Add(new InputEdge("6", "7", 15));
            InputEdges.Add(new InputEdge("6", "s", 10));

            InputEdges.Add(new InputEdge("7", "3", 6));
            InputEdges.Add(new InputEdge("7", "s", 10));

            gridNodes.DataSource = null;
            gridNodes.DataSource = InputEdges;

        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            gridNodes.DataSource = null;
            graphViewer.Graph = null;
            txtMinCut.Text = string.Empty;
            txtMaxFlow.Text = string.Empty;
            cmbNodeCount.SelectedIndex = 0;
            InputEdges.Clear();
        }
    }
}
