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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MapGrid = new System.Windows.Forms.DataGridView();
            this.LoadGame = new System.Windows.Forms.Button();
            this.SolveAStar = new System.Windows.Forms.Button();
            this.SolveIDDFS = new System.Windows.Forms.Button();
            this.IDDFSDepth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.SolveCSP = new System.Windows.Forms.Button();
            this.PlayBackSpeed = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.SolveSA = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CurrentTemp = new System.Windows.Forms.Label();
            this.SADecrement = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.SATemperature = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.openMapFile = new System.Windows.Forms.OpenFileDialog();
            this.CurrentDepth = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MapGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDDFSDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayBackSpeed)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SADecrement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SATemperature)).BeginInit();
            this.SuspendLayout();
            // 
            // MapGrid
            // 
            this.MapGrid.AllowUserToAddRows = false;
            this.MapGrid.AllowUserToDeleteRows = false;
            this.MapGrid.AllowUserToResizeColumns = false;
            this.MapGrid.AllowUserToResizeRows = false;
            this.MapGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MapGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.MapGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.MapGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.MapGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MapGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MapGrid.Enabled = false;
            this.MapGrid.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.MapGrid.Location = new System.Drawing.Point(12, 12);
            this.MapGrid.MultiSelect = false;
            this.MapGrid.Name = "MapGrid";
            this.MapGrid.ReadOnly = true;
            this.MapGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            this.MapGrid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.MapGrid.Size = new System.Drawing.Size(692, 508);
            this.MapGrid.TabIndex = 0;
            this.MapGrid.TabStop = false;
            // 
            // LoadGame
            // 
            this.LoadGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadGame.Location = new System.Drawing.Point(710, 12);
            this.LoadGame.Name = "LoadGame";
            this.LoadGame.Size = new System.Drawing.Size(162, 23);
            this.LoadGame.TabIndex = 1;
            this.LoadGame.Text = "Load Game";
            this.LoadGame.UseVisualStyleBackColor = true;
            this.LoadGame.Click += new System.EventHandler(this.LoadGame_Click);
            // 
            // SolveAStar
            // 
            this.SolveAStar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SolveAStar.Enabled = false;
            this.SolveAStar.Location = new System.Drawing.Point(6, 16);
            this.SolveAStar.Name = "SolveAStar";
            this.SolveAStar.Size = new System.Drawing.Size(149, 23);
            this.SolveAStar.TabIndex = 1;
            this.SolveAStar.Text = "A*";
            this.SolveAStar.UseVisualStyleBackColor = true;
            this.SolveAStar.Click += new System.EventHandler(this.SolveAStar_Click);
            // 
            // SolveIDDFS
            // 
            this.SolveIDDFS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SolveIDDFS.Enabled = false;
            this.SolveIDDFS.Location = new System.Drawing.Point(6, 58);
            this.SolveIDDFS.Name = "SolveIDDFS";
            this.SolveIDDFS.Size = new System.Drawing.Size(148, 38);
            this.SolveIDDFS.TabIndex = 1;
            this.SolveIDDFS.Text = "Iterative Deepening DFS";
            this.SolveIDDFS.UseVisualStyleBackColor = true;
            this.SolveIDDFS.Click += new System.EventHandler(this.SolveIDDFS_Click);
            // 
            // IDDFSDepth
            // 
            this.IDDFSDepth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IDDFSDepth.Enabled = false;
            this.IDDFSDepth.Location = new System.Drawing.Point(6, 32);
            this.IDDFSDepth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IDDFSDepth.Name = "IDDFSDepth";
            this.IDDFSDepth.Size = new System.Drawing.Size(148, 20);
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
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Max Depth:";
            // 
            // SolveCSP
            // 
            this.SolveCSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SolveCSP.Enabled = false;
            this.SolveCSP.Location = new System.Drawing.Point(6, 16);
            this.SolveCSP.Name = "SolveCSP";
            this.SolveCSP.Size = new System.Drawing.Size(149, 23);
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
            this.PlayBackSpeed.Location = new System.Drawing.Point(706, 475);
            this.PlayBackSpeed.Maximum = 1000;
            this.PlayBackSpeed.Name = "PlayBackSpeed";
            this.PlayBackSpeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PlayBackSpeed.RightToLeftLayout = true;
            this.PlayBackSpeed.Size = new System.Drawing.Size(166, 45);
            this.PlayBackSpeed.TabIndex = 5;
            this.PlayBackSpeed.TickFrequency = 50;
            this.PlayBackSpeed.Value = 500;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(709, 459);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Playback Speed";
            // 
            // SolveSA
            // 
            this.SolveSA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SolveSA.Enabled = false;
            this.SolveSA.Location = new System.Drawing.Point(6, 97);
            this.SolveSA.Name = "SolveSA";
            this.SolveSA.Size = new System.Drawing.Size(149, 23);
            this.SolveSA.TabIndex = 7;
            this.SolveSA.Text = "Simulated Annealing";
            this.SolveSA.UseVisualStyleBackColor = true;
            this.SolveSA.Click += new System.EventHandler(this.SolveSA_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.SolveAStar);
            this.groupBox1.Location = new System.Drawing.Point(711, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 45);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "A*";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.CurrentDepth);
            this.groupBox2.Controls.Add(this.SolveIDDFS);
            this.groupBox2.Controls.Add(this.IDDFSDepth);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(710, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(161, 147);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "IDDFS";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.SolveCSP);
            this.groupBox3.Location = new System.Drawing.Point(711, 245);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(161, 45);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CSP";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.CurrentTemp);
            this.groupBox4.Controls.Add(this.SADecrement);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.SATemperature);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.SolveSA);
            this.groupBox4.Location = new System.Drawing.Point(711, 296);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(161, 160);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "SA";
            // 
            // CurrentTemp
            // 
            this.CurrentTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentTemp.AutoSize = true;
            this.CurrentTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentTemp.ForeColor = System.Drawing.Color.Red;
            this.CurrentTemp.Location = new System.Drawing.Point(8, 130);
            this.CurrentTemp.Name = "CurrentTemp";
            this.CurrentTemp.Size = new System.Drawing.Size(0, 18);
            this.CurrentTemp.TabIndex = 12;
            // 
            // SADecrement
            // 
            this.SADecrement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SADecrement.DecimalPlaces = 2;
            this.SADecrement.Enabled = false;
            this.SADecrement.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.SADecrement.Location = new System.Drawing.Point(6, 71);
            this.SADecrement.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            this.SADecrement.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.SADecrement.Name = "SADecrement";
            this.SADecrement.Size = new System.Drawing.Size(148, 20);
            this.SADecrement.TabIndex = 10;
            this.SADecrement.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Decrement:";
            // 
            // SATemperature
            // 
            this.SATemperature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SATemperature.DecimalPlaces = 2;
            this.SATemperature.Enabled = false;
            this.SATemperature.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.SATemperature.Location = new System.Drawing.Point(6, 32);
            this.SATemperature.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SATemperature.Name = "SATemperature";
            this.SATemperature.Size = new System.Drawing.Size(148, 20);
            this.SATemperature.TabIndex = 8;
            this.SATemperature.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            this.SATemperature.ValueChanged += new System.EventHandler(this.SATemperature_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Starting Temperature:";
            // 
            // openMapFile
            // 
            this.openMapFile.FileName = "Map.txt";
            this.openMapFile.Filter = "Text Files|*.txt";
            // 
            // CurrentDepth
            // 
            this.CurrentDepth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentDepth.AutoSize = true;
            this.CurrentDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentDepth.ForeColor = System.Drawing.Color.Red;
            this.CurrentDepth.Location = new System.Drawing.Point(6, 111);
            this.CurrentDepth.Name = "CurrentDepth";
            this.CurrentDepth.Size = new System.Drawing.Size(0, 18);
            this.CurrentDepth.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(884, 532);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PlayBackSpeed);
            this.Controls.Add(this.LoadGame);
            this.Controls.Add(this.MapGrid);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 528);
            this.Name = "Form1";
            this.Text = "Diamonds";
            ((System.ComponentModel.ISupportInitialize)(this.MapGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDDFSDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayBackSpeed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SADecrement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SATemperature)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MapGrid;
        private System.Windows.Forms.Button LoadGame;
        private System.Windows.Forms.Button SolveAStar;
        private System.Windows.Forms.Button SolveIDDFS;
        private System.Windows.Forms.NumericUpDown IDDFSDepth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SolveCSP;
        private System.Windows.Forms.TrackBar PlayBackSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SolveSA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown SADecrement;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown SATemperature;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label CurrentTemp;
        private System.Windows.Forms.OpenFileDialog openMapFile;
        private System.Windows.Forms.Label CurrentDepth;
    }
}

