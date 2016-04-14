using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace testproject2
{
    public class Node
    {
        private static Color[] NodeColors = { Color.Green, Color.Yellow, Color.White, Color.Red, Color.Gray, Color.Black };
        private static Boolean[] Walkability = { true, true, true, true, false, false };

        public Point Position = new Point(0,0);
        public NodeType Type = NodeType.SAND;
        public Boolean IsDangerous = false;
        public Int32 gCost = 0, hCost = 0;

        public Node ParentNode = null;

        public Node(Point position, NodeType type, Point startPosition)
        {
            UpdateNode(position, type, startPosition);
        }

        public void UpdateNode(Point position, NodeType type, Point startPosition)
        {
            Type = type;
            Position = position;
            SetGCost(startPosition);
        }

        public Boolean IsWalkable {
            get
            {
                return Walkability[(int)Type];
            }
        }

        public Color NodeColor
        {
            get
            {
                return NodeColors[(int)Type];
            }
        }

        public Int32 fCost
        {
            get
            {
                return gCost + hCost;
            }
        }

        public void SetHCost(Point targetNodePosition)
        {
            hCost = Game.GetDistance(this.Position, targetNodePosition);
        }

        public void SetGCost(Point targetNodePosition)
        {
            gCost = Game.GetDistance(this.Position, targetNodePosition);
        }
        
    }

    public enum NodeType
    {
        PLAYER,
        SAND,
        CLEAR,
        DIAMOND,
        ROCK,
        WALL
    }
}
