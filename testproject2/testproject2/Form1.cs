using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testproject2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Game.LoadGame("input.txt");
            InitializeMapGrid(Game.NodeGrid, Game.MapXSize, Game.MapYSize);
            List<Node> path = Game.SolveAStar();
            foreach (Node n in path)
            {
                dataGridView1.Rows[n.Position.Y].Cells[n.Position.X].Style.BackColor = Color.Blue;
            }
        }

        private void InitializeMapGrid(Node[,] NodeGrid, Int32 MapXSize, Int32 MapYSize)
        {
            dataGridView1.ColumnCount = MapXSize;
            dataGridView1.RowCount = MapYSize;
            for (int i = 0; i < MapXSize; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Value = (i + 1).ToString();
            }
            for (int i = 0; i < MapYSize; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            foreach(Node n in NodeGrid)
            {
                dataGridView1.Rows[n.Position.Y].Cells[n.Position.X].Style.BackColor = n.NodeColor;
            }
        }
    }
}
