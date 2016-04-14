using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace testproject2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private void LoadGame_Click(object sender, EventArgs e)
        {
            LoadGame.Enabled = false;
            SolveAStar.Enabled = true;
            Game.LoadGame("input.txt");
            InitializeMapGrid(Game.NodeGrid, Game.MapXSize, Game.MapYSize);
            dataGridView1.ClearSelection();
        }

        private void SolveAStar_Click(object sender, EventArgs e)
        {
            SolveAStar.Enabled = false;
            List<Node> path = Game.SolveAStar();
            new Thread (()=> {
                Point currentPosition = Game.InitialLocation;
                foreach (Node n in path)
                {
                    Dispatcher.CurrentDispatcher.Invoke(
                    DispatcherPriority.Send,
                    new Action(() =>
                    {
                        dataGridView1.Rows[currentPosition.Y].Cells[currentPosition.X].Style.BackColor = Color.White;
                        dataGridView1.Rows[n.Position.Y].Cells[n.Position.X].Style.BackColor = Color.Green;
                    }));
                    currentPosition.X = n.Position.X;
                    currentPosition.Y = n.Position.Y;
                    Thread.Sleep(500);
                }
            }).Start();
            
        }
    }
}
