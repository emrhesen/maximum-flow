namespace NetworkOptimizationProblem
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation planeTransformation4 = new Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation();
            this.graphViewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.btn_CreateGraph = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNodeCount = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridNodes = new System.Windows.Forms.DataGridView();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMinCut = new System.Windows.Forms.TextBox();
            this.txtMaxFlow = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNodes)).BeginInit();
            this.SuspendLayout();
            // 
            // graphViewer
            // 
            this.graphViewer.ArrowheadLength = 10D;
            this.graphViewer.AsyncLayout = false;
            this.graphViewer.AutoScroll = true;
            this.graphViewer.BackwardEnabled = false;
            this.graphViewer.BuildHitTree = true;
            this.graphViewer.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.SugiyamaScheme;
            this.graphViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphViewer.EdgeInsertButtonVisible = true;
            this.graphViewer.FileName = "";
            this.graphViewer.ForwardEnabled = false;
            this.graphViewer.Graph = null;
            this.graphViewer.InsertingEdge = false;
            this.graphViewer.LayoutAlgorithmSettingsButtonVisible = true;
            this.graphViewer.LayoutEditingEnabled = true;
            this.graphViewer.Location = new System.Drawing.Point(0, 0);
            this.graphViewer.LooseOffsetForRouting = 0.25D;
            this.graphViewer.MouseHitDistance = 0.05D;
            this.graphViewer.Name = "graphViewer";
            this.graphViewer.NavigationVisible = true;
            this.graphViewer.NeedToCalculateLayout = true;
            this.graphViewer.OffsetForRelaxingInRouting = 0.6D;
            this.graphViewer.PaddingForEdgeRouting = 8D;
            this.graphViewer.PanButtonPressed = false;
            this.graphViewer.SaveAsImageEnabled = true;
            this.graphViewer.SaveAsMsaglEnabled = true;
            this.graphViewer.SaveButtonVisible = true;
            this.graphViewer.SaveGraphButtonVisible = true;
            this.graphViewer.SaveInVectorFormatEnabled = true;
            this.graphViewer.Size = new System.Drawing.Size(1014, 552);
            this.graphViewer.TabIndex = 0;
            this.graphViewer.TightOffsetForRouting = 0.125D;
            this.graphViewer.ToolBarIsVisible = true;
            this.graphViewer.Transform = planeTransformation4;
            this.graphViewer.UndoRedoButtonsVisible = true;
            this.graphViewer.WindowZoomButtonPressed = false;
            this.graphViewer.ZoomF = 1D;
            this.graphViewer.ZoomWindowThreshold = 0.05D;
            // 
            // btn_CreateGraph
            // 
            this.btn_CreateGraph.Location = new System.Drawing.Point(14, 396);
            this.btn_CreateGraph.Name = "btn_CreateGraph";
            this.btn_CreateGraph.Size = new System.Drawing.Size(98, 25);
            this.btn_CreateGraph.TabIndex = 3;
            this.btn_CreateGraph.Text = "Graph Oluştur";
            this.btn_CreateGraph.UseVisualStyleBackColor = true;
            this.btn_CreateGraph.Click += new System.EventHandler(this.btn_CreateGraph_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtMaxFlow);
            this.splitContainer1.Panel1.Controls.Add(this.txtMinCut);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Reset);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.cmbNodeCount);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btn_CreateGraph);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.graphViewer);
            this.splitContainer1.Size = new System.Drawing.Size(1249, 552);
            this.splitContainer1.SplitterDistance = 231;
            this.splitContainer1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Musluk Sayısı :";
            // 
            // cmbNodeCount
            // 
            this.cmbNodeCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodeCount.FormattingEnabled = true;
            this.cmbNodeCount.Items.AddRange(new object[] {
            "Seçiniz"});
            this.cmbNodeCount.Location = new System.Drawing.Point(91, 9);
            this.cmbNodeCount.Name = "cmbNodeCount";
            this.cmbNodeCount.Size = new System.Drawing.Size(95, 21);
            this.cmbNodeCount.TabIndex = 6;
            this.cmbNodeCount.SelectedIndexChanged += new System.EventHandler(this.cmbNodeCount_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridNodes);
            this.groupBox1.Location = new System.Drawing.Point(11, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 315);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Musluk ve Kapasiteleri";
            // 
            // gridNodes
            // 
            this.gridNodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridNodes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.gridNodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridNodes.Location = new System.Drawing.Point(3, 16);
            this.gridNodes.MultiSelect = false;
            this.gridNodes.Name = "gridNodes";
            this.gridNodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridNodes.Size = new System.Drawing.Size(196, 296);
            this.gridNodes.TabIndex = 0;
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(14, 427);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(98, 25);
            this.btn_Reset.TabIndex = 8;
            this.btn_Reset.Text = "Temizle";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 494);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Min-Cut :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 516);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Max-Flow :";
            // 
            // txtMinCut
            // 
            this.txtMinCut.Enabled = false;
            this.txtMinCut.Location = new System.Drawing.Point(75, 491);
            this.txtMinCut.Name = "txtMinCut";
            this.txtMinCut.Size = new System.Drawing.Size(98, 20);
            this.txtMinCut.TabIndex = 11;
            // 
            // txtMaxFlow
            // 
            this.txtMaxFlow.Enabled = false;
            this.txtMaxFlow.Location = new System.Drawing.Point(75, 513);
            this.txtMaxFlow.Name = "txtMaxFlow";
            this.txtMaxFlow.Size = new System.Drawing.Size(98, 20);
            this.txtMaxFlow.TabIndex = 12;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 552);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmMain";
            this.Text = "YazLab Odev";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridNodes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Msagl.GraphViewerGdi.GViewer graphViewer;
        private System.Windows.Forms.Button btn_CreateGraph;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNodeCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridNodes;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaxFlow;
        private System.Windows.Forms.TextBox txtMinCut;
    }
}

