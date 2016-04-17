using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            MapGrid.ColumnCount = MapXSize;
            MapGrid.RowCount = MapYSize;
            for (int i = 0; i < MapXSize; i++)
            {
                MapGrid.Columns[i].HeaderCell.Value = (i + 1).ToString();
            }
            for (int i = 0; i < MapYSize; i++)
            {
                MapGrid.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            foreach(Node n in NodeGrid)
            {
                MapGrid.Rows[n.Position.Y].Cells[n.Position.X].Style.BackColor = n.NodeColor;
            }
        }

        private void LoadGame_Click(object sender, EventArgs e)
        {
            DialogResult result = openMapFile.ShowDialog();
            if (result == DialogResult.OK && File.Exists(openMapFile.FileName))
            {
                try
                {
                    CurrentDepth.Text = CurrentTemp.Text = "";
                    Game.NewInstance.LoadGame(openMapFile.FileName);
                    SolveAStar.Enabled = SolveIDDFS.Enabled = IDDFSDepth.Enabled = SolveCSP.Enabled = SolveSA.Enabled = SADecrement.Enabled = SATemperature.Enabled = PlayBackSpeed.Enabled = true;
                    InitializeMapGrid(Game.Instance.NodeGrid, Game.Instance.MapXSize, Game.Instance.MapYSize);
                    MapGrid.ClearSelection();
                }
                catch(Exception)
                {
                    MessageBox.Show("Error occurred while reading file.", "Diamonds", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }

        private void SolveAStar_Click(object sender, EventArgs e)
        {
            AnimatePath(Game.Instance.SolveAStar());
        }

        private void SolveIDDFS_Click(object sender, EventArgs e)
        {
            Animate2DIDDFSPath(Game.Instance.SolveIDDFS(Convert.ToInt32(IDDFSDepth.Value)));
        }

        private void SolveCSP_Click(object sender, EventArgs e)
        {
            AnimatePath(Game.Instance.SolveCSP());
        }

        private void SolveSA_Click(object sender, EventArgs e)
        {
            Animate2DSAPath(Game.Instance.SolveSA(Convert.ToDouble(SATemperature.Value), Convert.ToDouble(SADecrement.Value)));
        }

        private void AnimatePath(List<Node> path)
        {
            SolveAStar.Enabled = SolveIDDFS.Enabled = IDDFSDepth.Enabled = SolveSA.Enabled = SADecrement.Enabled = SATemperature.Enabled = SolveCSP.Enabled = false;
            new Thread(() =>
            {
                Point currentPosition = new Point(Game.Instance.InitialLocation.X, Game.Instance.InitialLocation.Y);
                Int32 speed = 0;
                foreach (Node n in path)
                {
                    Dispatcher.CurrentDispatcher.Invoke(
                    DispatcherPriority.Send,
                    new Action(() =>
                    {
                        MapGrid.Rows[currentPosition.Y].Cells[currentPosition.X].Style.BackColor = Color.White;
                        MapGrid.Rows[n.Position.Y].Cells[n.Position.X].Style.BackColor = Color.Green;
                        speed = GetTrackBarValue();
                    }));
                    currentPosition.X = n.Position.X;
                    currentPosition.Y = n.Position.Y;
                    Thread.Sleep(speed);
                }
                EnableLoadGame();
            }).Start();
        }

        private void Animate2DIDDFSPath(List<List<Node>> _2DPath)
        {
            SolveAStar.Enabled = SolveIDDFS.Enabled = IDDFSDepth.Enabled = SolveSA.Enabled = SADecrement.Enabled = SATemperature.Enabled = SolveCSP.Enabled = false;
            Int32 CurrentDepth = 1;
            new Thread(() =>
            {
                foreach (List<Node> temperaturePath in _2DPath)
                {
                    InitializeMapGrid(Game.Instance.NodeGrid, Game.Instance.MapXSize, Game.Instance.MapYSize);

                    SetCurrentDepthLabel(String.Format("Current Depth = {0}", CurrentDepth++));

                    Point currentPosition = new Point(Game.Instance.InitialLocation.X, Game.Instance.InitialLocation.Y);
                    foreach (Node n in temperaturePath)
                    {
                        Dispatcher.CurrentDispatcher.Invoke(
                        DispatcherPriority.Send,
                        new Action(() =>
                        {
                            MapGrid.Rows[currentPosition.Y].Cells[currentPosition.X].Style.BackColor = Color.White;
                            MapGrid.Rows[n.Position.Y].Cells[n.Position.X].Style.BackColor = Color.Green;
                        }));
                        currentPosition.X = n.Position.X;
                        currentPosition.Y = n.Position.Y;
                        Thread.Sleep(GetTrackBarValue());
                    }
                }
                EnableLoadGame();
            }).Start();
        }

        private void Animate2DSAPath(List<List<Node>> _2DPath)
        {
            SolveAStar.Enabled = SolveIDDFS.Enabled = IDDFSDepth.Enabled = SolveSA.Enabled = SADecrement.Enabled = SATemperature.Enabled = SolveCSP.Enabled = false;
            Decimal temperature = SATemperature.Value, decrement = SADecrement.Value;
            new Thread(() =>
            {
                foreach (List<Node> temperaturePath in _2DPath)
                {
                    InitializeMapGrid(Game.Instance.NodeGrid, Game.Instance.MapXSize, Game.Instance.MapYSize);

                    SetCurrentTemperatureLabel(String.Format("Current Temp = {0}", Math.Round(temperature, 2)));

                    Point currentPosition = new Point(Game.Instance.InitialLocation.X, Game.Instance.InitialLocation.Y);
                    foreach (Node n in temperaturePath)
                    {
                        Dispatcher.CurrentDispatcher.Invoke(
                        DispatcherPriority.Send,
                        new Action(() =>
                        {
                            MapGrid.Rows[currentPosition.Y].Cells[currentPosition.X].Style.BackColor = Color.White;
                            MapGrid.Rows[n.Position.Y].Cells[n.Position.X].Style.BackColor = Color.Green;
                        }));
                        currentPosition.X = n.Position.X;
                        currentPosition.Y = n.Position.Y;
                        Thread.Sleep(GetTrackBarValue());
                    }
                    temperature -= SADecrement.Value;
                }
                EnableLoadGame();
            }).Start();
        }
        
        delegate int GetTrackBarValueCallback();

        private int GetTrackBarValue()
        {
            if (PlayBackSpeed.InvokeRequired)
            {
                GetTrackBarValueCallback cb = new GetTrackBarValueCallback(GetTrackBarValue);
                return (int)PlayBackSpeed.Invoke(cb);
            }
            else
            {
                return (int)PlayBackSpeed.Value;
            }
        }

        public void SetCurrentTemperatureLabel(String value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(SetCurrentTemperatureLabel), new object[] { value });
                return;
            }
            CurrentTemp.Text = value;
        }

        public void SetCurrentDepthLabel(String value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(SetCurrentDepthLabel), new object[] { value });
                return;
            }
            CurrentDepth.Text = value;
        }

        public void EnableLoadGame()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(EnableLoadGame));
                return;
            }
            LoadGame.Enabled = true;
        }

        private void SATemperature_ValueChanged(object sender, EventArgs e)
        {
            if (SADecrement.Value > SATemperature.Value)
                SADecrement.Value = SATemperature.Value;
            SADecrement.Maximum = SATemperature.Value;
        }

    }
}
