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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LoadGame = new System.Windows.Forms.Button();
            this.SolveAStar = new System.Windows.Forms.Button();
            this.SolveIDDFS = new System.Windows.Forms.Button();
            this.IDDFSDepth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.SolveCSP = new System.Windows.Forms.Button();
            this.PlayBackSpeed = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDDFSDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayBackSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(584, 399);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.TabStop = false;
            // 
            // LoadGame
            // 
            this.LoadGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.SolveAStar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.SolveIDDFS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.IDDFSDepth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(602, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Max Depth:";
            // 
            // SolveCSP
            // 
            this.SolveCSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SolveCSP.Enabled = false;
            this.SolveCSP.Location = new System.Drawing.Point(602, 158);
            this.SolveCSP.Name = "SolveCSP";
            this.SolveCSP.Size = new System.Drawing.Size(125, 23);
            this.SolveCSP.TabIndex = 4;
            this.SolveCSP.Text = "Constraint Satisfaction";
            this.SolveCSP.UseVisualStyleBackColor = true;
            this.SolveCSP.Click += new System.EventHandler(this.SolveCSP_Click);
            // 
            // PlayBackSpeed
            // 
            this.PlayBackSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayBackSpeed.Enabled = false;
            this.PlayBackSpeed.LargeChange = 50;
            this.PlayBackSpeed.Location = new System.Drawing.Point(602, 207);
            this.PlayBackSpeed.Maximum = 1000;
            this.PlayBackSpeed.Minimum = 1;
            this.PlayBackSpeed.Name = "PlayBackSpeed";
            this.PlayBackSpeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PlayBackSpeed.RightToLeftLayout = true;
            this.PlayBackSpeed.Size = new System.Drawing.Size(125, 45);
            this.PlayBackSpeed.TabIndex = 5;
            this.PlayBackSpeed.TickFrequency = 50;
            this.PlayBackSpeed.Value = 500;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(602, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Playback Speed";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(739, 423);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PlayBackSpeed);
            this.Controls.Add(this.SolveCSP);
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
            ((System.ComponentModel.ISupportInitialize)(this.PlayBackSpeed)).EndInit();
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
        private System.Windows.Forms.Button SolveCSP;
        private System.Windows.Forms.TrackBar PlayBackSpeed;
        private System.Windows.Forms.Label label2;
    }
}

