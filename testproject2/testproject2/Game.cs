using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace testproject2
{
    public static class Game
    {
        private static Int32 mapXSize = 0, mapYSize = 0;
        private static Point initialLocation = new Point(0, 0);
        private static List<Point> diamonds = new List<Point>() { }, rocks = new List<Point>() { }, walls = new List<Point>() { };
        private static List<Node> goals = new List<Node>();
        private static Node[,] nodeGrid = {};

        public static Int32 MapXSize
        {
            get
            {
                return mapXSize;
            }
        }

        public static Int32 MapYSize
        {
            get
            {
                return mapYSize;
            }
        }

        public static Node[,] NodeGrid
        {
            get
            {
                return nodeGrid;
            }
        }

        public static void LoadGame(String filePath)
        {
            StreamReader input = new StreamReader(filePath);
            String line;
            String[] tokens;
            while( (line = input.ReadLine()) != null )
            {
                tokens = line.Split(' ');
                switch (tokens[0])
                {
                    case "size":
                        mapXSize = Int32.Parse(tokens[1]);
                        mapYSize = Int32.Parse(tokens[2]);
                        break;
                    case "initiallocation":
                        initialLocation.X = Int32.Parse(tokens[1]);
                        initialLocation.Y = Int32.Parse(tokens[2]);
                        nodeGrid = new Node[mapXSize, mapYSize];
                        for (int i = 0; i < mapXSize; i++)
                        {
                            for (int j = 0; j < mapYSize; j++)
                            {
                                nodeGrid[i, j] = new Node(new Point(i, j), NodeType.SAND, initialLocation);
                            }
                        }
                        nodeGrid[initialLocation.X, initialLocation.Y].UpdateNode(initialLocation, NodeType.PLAYER, initialLocation);
                        break;
                    case "diamonds":
                        for (int i = 2; i < tokens.Length; i+= 2)
                        {
                            Point diamond = new Point(Int32.Parse(tokens[i]), Int32.Parse(tokens[i + 1]));
                            diamonds.Add(diamond);
                            nodeGrid[diamond.X, diamond.Y].UpdateNode(diamond, NodeType.DIAMOND, initialLocation);
                            goals.Add(nodeGrid[diamond.X, diamond.Y]);
                        }
                        break;
                    case "rocks":
                        for (int i = 2; i < tokens.Length; i += 2)
                        {
                            Point rock = new Point(Int32.Parse(tokens[i]), Int32.Parse(tokens[i + 1]));
                            rocks.Add(rock);
                            nodeGrid[rock.X, rock.Y].UpdateNode(rock, NodeType.ROCK, initialLocation);
                            if (rock.Y + 1 < mapYSize)
                                nodeGrid[rock.X, rock.Y + 1].IsDangerous = true;
                        }
                        break;
                    case "walls":
                        for (int i = 2; i < tokens.Length; i += 2)
                        {
                            Point wall = new Point(Int32.Parse(tokens[i]), Int32.Parse(tokens[i + 1]));
                            walls.Add(wall);
                            nodeGrid[wall.X, wall.Y].UpdateNode(wall, NodeType.WALL, initialLocation);
                        }
                        break;
                }
            }
        }

        public static List<Node> SolveAStar()
        {
            List<Node> Goals = goals, path = new List<Node>();
            Node startingNode = nodeGrid[initialLocation.X, initialLocation.Y];

            while(Goals.Count > 0)
            {
                Node closestGoal = Goals[0];

                Int32 distanceToGoal = GetDistance(startingNode.Position, closestGoal.Position);

                for (int i = 1; i < Goals.Count; i++)
                {
                    Int32 distanceToClosestGoalCandidate = GetDistance(startingNode.Position,Goals[i].Position);
                    if (distanceToClosestGoalCandidate < distanceToGoal)
                    {
                        distanceToGoal = distanceToClosestGoalCandidate;
                        closestGoal = Goals[i];
                    }
                }

                List<Node> openSet = new List<Node>();
                HashSet<Node> closedSet = new HashSet<Node>();

                openSet.Add(startingNode);
                Node currentNode;

                Boolean GoalReached = false;

                while (openSet.Count > 0)
                {
                    currentNode = openSet[0];

                    for (int i = 1; i < openSet.Count; i++)
                    {
                        if (openSet[i].fCost < currentNode.fCost || (openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost))
                        {
                            currentNode = openSet[i];
                        }
                    }

                    openSet.Remove(currentNode);
                    closedSet.Add(currentNode);

                    if (currentNode == closestGoal)
                    {
                        List<Node> pathToClosestGoal = new List<Node>();
                        GoalReached = true;
                        while (currentNode != startingNode)
                        {
                            pathToClosestGoal.Add(currentNode);
                            currentNode = currentNode.ParentNode;
                        }
                        pathToClosestGoal.Reverse();
                        path.AddRange(pathToClosestGoal);
                        break;
                    }

                    List<Node> neighbours = Game.GetNodeWalkableNeighbours(currentNode.Position);

                    foreach (Node neighbour in neighbours)
                    {
                        if (closedSet.Contains(neighbour))
                            continue;

                        if (currentNode.gCost + 1 < neighbour.gCost || !openSet.Contains(neighbour))
                        {
                            neighbour.gCost = currentNode.gCost + 1;
                            neighbour.ParentNode = currentNode;

                            if (!openSet.Contains(neighbour))
                            {
                                neighbour.SetHCost(closestGoal.Position);
                                openSet.Add(neighbour);
                            }
                        }
                    }
                }

                if (GoalReached)
                {
                    startingNode = closestGoal;
                    for (int i = 0; i < mapXSize; i++)
                    {
                        for (int j = 0; j < mapYSize; j++)
                        {
                            nodeGrid[i, j].SetGCost(startingNode.Position);
                        }
                    }
                }
                Goals.Remove(closestGoal);
            }
            return path;
        }

        private static List<Node> GetNodeWalkableNeighbours(Point nodePosition)
        {
            List<Node> neighbours = new List<Node>();
            int neighbourX = 0, neighbourY = 0;
            for (int i = 0; i < 4; i++)
            {
                switch (i)
	            {
                    case 0:
                        // Left
                        neighbourX = nodePosition.X - 1;
                        neighbourY = nodePosition.Y;
                        break;
                    case 1:
                        // Right
                        neighbourX = nodePosition.X + 1;
                        neighbourY = nodePosition.Y;
                        break;
                    case 2:
                        // Top
                        neighbourX = nodePosition.X;
                        neighbourY = nodePosition.Y - 1;
                        break;
                    case 3:
                        // Bottom
                        neighbourX = nodePosition.X;
                        neighbourY = nodePosition.Y + 1;
                        break;
	            }
                if (neighbourX > -1 && neighbourX < mapXSize && neighbourY > -1 && neighbourY < mapYSize && nodeGrid[neighbourX, neighbourY].IsWalkable && !nodeGrid[neighbourX, neighbourY].IsDangerous)
                    neighbours.Add(nodeGrid[neighbourX, neighbourY]);
            }
            return neighbours;
        }

        public static Int32 GetDistance(Point a, Point b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }
    }
}
