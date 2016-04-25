using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MI
{
    public class Node
    {
        private static Texture2D[] NodeTiles = { Resources.playerTile, Resources.dirtTile, Resources.emptyTile, Resources.diamondTile, Resources.rockTile, Resources.wallTile };
        private static Boolean[] Walkability = { true, true, true, true, false, false };

        // Fields
        public Point Position = new Point(0,0);
        public Rectangle Rectangle = new Rectangle();
        public NodeType Type = NodeType.SAND;
        public Boolean IsDangerous = false, Visited = false;
        public Int32 gCost = 0, hCost = 0;

        public Node ParentNode = null;

        // Constructor
        public Node(Point position, Rectangle rectangle, NodeType type, Point startPosition)
        {
            UpdateNode(position, type, startPosition);
            Rectangle = rectangle;
        }

        public void UpdateNode(Point position, NodeType type, Point startPosition)
        {
            Type = type;
            Position = position;
            SetGCost(startPosition);
        }

        // Properties
        public Boolean IsWalkable {
            get
            {
                return Walkability[(int)Type];
            }
        }

        public Texture2D NodeTile
        {
            get
            {
                return NodeTiles[(int)Type];
            }
        }

        public Int32 fCost
        {
            get
            {
                return gCost + hCost;
            }
        }

        // Cost Setters
        public void SetHCost(Point targetNodePosition)
        {
            hCost = GetManhattanDistance(this.Position, targetNodePosition);
        }

        public void SetGCost(Point targetNodePosition)
        {
            gCost = GetManhattanDistance(this.Position, targetNodePosition);
        }
        public static Int32 GetManhattanDistance(Point a, Point b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
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
