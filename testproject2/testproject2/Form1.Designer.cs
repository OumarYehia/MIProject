namespace testproject2
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LoadGame = new System.Windows.Forms.Button();
            this.SolveAStar = new System.Windows.Forms.Button();
            this.SolveIDDFS = new System.Windows.Forms.Button();
            this.IDDFSDepth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDDFSDepth)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(584, 399);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.TabStop = false;
            // 
            // LoadGame
            // 
            this.LoadGame.Location = new System.Drawing.Point(602, 12);
            this.LoadGame.Name = "LoadGame";
            this.LoadGame.Size = new System.Drawing.Size(125, 23);
            this.LoadGame.TabIndex = 1;
            this.LoadGame.Text = "Load Game";
            this.LoadGame.UseVisualStyleBackColor = true;
            this.LoadGame.Click += new System.EventHandler(this.LoadGame_Click);
            // 
            // SolveAStar
            // 
            this.SolveAStar.Enabled = false;
            this.SolveAStar.Location = new System.Drawing.Point(602, 41);
            this.SolveAStar.Name = "SolveAStar";
            this.SolveAStar.Size = new System.Drawing.Size(125, 23);
            this.SolveAStar.TabIndex = 1;
            this.SolveAStar.Text = "A*";
            this.SolveAStar.UseVisualStyleBackColor = true;
            this.SolveAStar.Click += new System.EventHandler(this.SolveAStar_Click);
            // 
            // SolveIDDFS
            // 
            this.SolveIDDFS.Enabled = false;
            this.SolveIDDFS.Location = new System.Drawing.Point(602, 114);
            this.SolveIDDFS.Name = "SolveIDDFS";
            this.SolveIDDFS.Size = new System.Drawing.Size(125, 38);
            this.SolveIDDFS.TabIndex = 1;
            this.SolveIDDFS.Text = "Iterative Deepening DFS";
            this.SolveIDDFS.UseVisualStyleBackColor = true;
            this.SolveIDDFS.Click += new System.EventHandler(this.SolveIDDFS_Click);
            // 
            // IDDFSDepth
            // 
            this.IDDFSDepth.Enabled = false;
            this.IDDFSDepth.Location = new System.Drawing.Point(602, 88);
            this.IDDFSDepth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IDDFSDepth.Name = "IDDFSDepth";
            this.IDDFSDepth.Size = new System.Drawing.Size(125, 20);
            this.IDDFSDepth.TabIndex = 2;
            this.IDDFSDepth.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(602, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Max Depth:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(739, 423);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IDDFSDepth);
            this.Controls.Add(this.SolveIDDFS);
            this.Controls.Add(this.SolveAStar);
            this.Controls.Add(this.LoadGame);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDDFSDepth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button LoadGame;
        private System.Windows.Forms.Button SolveAStar;
        private System.Windows.Forms.Button SolveIDDFS;
        private System.Windows.Forms.NumericUpDown IDDFSDepth;
        private System.Windows.Forms.Label label1;
    }
}

