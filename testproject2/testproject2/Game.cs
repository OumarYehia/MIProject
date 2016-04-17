using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace testproject2
{
    public class Game
    {
        // Singleton
        private static Game instance = null;
        private Game()
        {
        }

        public static Game Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new Game();
                }
                return instance;
            }
        }

        public static Game NewInstance
        {
            get
            {
                instance = new Game();
                return instance;
            }
        }

        // Fields
        private Int32 mapXSize = 0, mapYSize = 0;
        private Point initialLocation = new Point(0, 0);
        private List<Point> diamonds = new List<Point>() { }, rocks = new List<Point>() { }, walls = new List<Point>() { };
        private List<Node> goals = new List<Node>();
        private Node[,] nodeGrid = {};

        // Properties
        public Point InitialLocation
        {
            get
            {
                return initialLocation;
            }
        }
        public Int32 MapXSize
        {
            get
            {
                return mapXSize;
            }
        }
        public Int32 MapYSize
        {
            get
            {
                return mapYSize;
            }
        }
        public Node[,] NodeGrid
        {
            get
            {
                return nodeGrid;
            }
        }

        // Prep
        public void LoadGame(String filePath)
        {
            StreamReader input = new StreamReader(filePath);
            String line;
            String[] tokens;
            try
            {
                while ((line = input.ReadLine()) != null)
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
                            for (int i = 2; i < tokens.Length; i += 2)
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
            catch (Exception ex)
            {
                throw(ex);
            }            
        }

        // Algorithms
        public List<Node> SolveAStar()
        {
            List<Node> Goals = goals, path = new List<Node>();
            Node startingNode = nodeGrid[initialLocation.X, initialLocation.Y];

            while(Goals.Count > 0)
            {
                Node closestGoal = Goals[0];

                Int32 distanceToGoal = GetManhattanDistance(startingNode.Position, closestGoal.Position);

                for (int i = 1; i < Goals.Count; i++)
                {
                    Int32 distanceToClosestGoalCandidate = GetManhattanDistance(startingNode.Position, Goals[i].Position);
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

                    List<Node> neighbours = GetNodeWalkableNeighbours(currentNode.Position);

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

        public List<List<Node>> SolveIDDFS(Int32 maxDepth)
        {
            List<List<Node>> path = new List<List<Node>>();
            for (int currentDepth = 0; currentDepth < maxDepth; currentDepth++)
            {
                List<Node> currentDepthPath = new List<Node>();

                List<Node> visited = new List<Node>();
                Stack<Node> stack = new Stack<Node>();
 
                Node CurrentNode = nodeGrid[initialLocation.X, initialLocation.Y];

                CurrentNode.Visited = true;

                stack.Push(CurrentNode);
                visited.Add(CurrentNode);

                while(stack.Count > 0)
                {
                    CurrentNode = stack.Pop();
                    currentDepthPath.Add(CurrentNode);

                    List<Node> neighbours = GetNodeWalkableNeighbours(CurrentNode.Position, true);
                    foreach (Node neighbour in neighbours)
                    {
                        if (GetManhattanDistance(initialLocation,neighbour.Position) <= currentDepth)
                        {
                            neighbour.Visited = true;
                            stack.Push(neighbour);
                            currentDepthPath.Add(neighbour);
                            visited.Add(neighbour);
                        }
                    }
                }
                
                foreach (Node v in visited)
                {
                    v.Visited = false;
                }

                Node StartingNode = currentDepthPath[0];
                currentDepthPath.RemoveAt(0);
                currentDepthPath.Add(StartingNode);

                // Last iteration
                //path = currentDepthPath;
                // All iterations
                path.Add(currentDepthPath);
            }
            return path;
        }

        public List<Node> SolveCSP()
        {
            List<Node> path = new List<Node>();

            Stack<Node> stack = new Stack<Node>();

            Node CurrentNode = nodeGrid[initialLocation.X, initialLocation.Y];

            CurrentNode.Visited = true;

            stack.Push(CurrentNode);

            while (stack.Count > 0)
            {
                CurrentNode = stack.Peek();
                path.Add(CurrentNode);

                List<Node> neighbours = GetNodeWalkableNeighbours(CurrentNode.Position, true);
                if(neighbours.Count > 0)
                {
                    Node neighbour = neighbours.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                    neighbour.Visited = true;
                    stack.Push(neighbour);
                    path.Add(neighbour);
                }
                else
                {
                    CurrentNode = stack.Pop();
                }
            }
            return path;
        }

        public List<List<Node>> SolveSA(Double temperature, Double decrement)
        {
            Random random = new Random(DateTime.Now.Second);
            List<List<Node>> path = new List<List<Node>>();
            for (Double currentTemperature = temperature; currentTemperature >= 0 ; currentTemperature-=decrement)
            {
                List<Node> TemperatureRunPath = new List<Node>();

                List<Node> Goals = new List<Node>(goals);

                Node startingNode = nodeGrid[initialLocation.X, initialLocation.Y];

                while (Goals.Count > 0)
                {
                    Node closestGoal = Goals[0];

                    Int32 distanceToGoal = GetManhattanDistance(startingNode.Position, closestGoal.Position);

                    for (int i = 1; i < Goals.Count; i++)
                    {
                        Int32 distanceToClosestGoalCandidate = GetManhattanDistance(startingNode.Position, Goals[i].Position);
                        if (distanceToClosestGoalCandidate < distanceToGoal)
                        {
                            distanceToGoal = distanceToClosestGoalCandidate;
                            closestGoal = Goals[i];
                        }
                    }

                    Stack<Node> stack = new Stack<Node>();
                    List<Node> visited = new List<Node>();

                    Node currentNode = startingNode;

                    currentNode.Visited = true;
                    visited.Add(currentNode);

                    stack.Push(currentNode);

                    Boolean GoalReached = false;

                    while (stack.Count > 0)
                    {
                        currentNode = stack.Peek();
                        TemperatureRunPath.Add(currentNode);

                        if (currentNode == closestGoal)
                        {
                            GoalReached = true;
                            break;
                        }

                        if(Goals.Contains(currentNode))
                        {
                            Goals.Remove(currentNode);
                        }

                        List<Node> neighbours = GetNodeWalkableNeighbours(currentNode.Position, true);
                        if (neighbours.Count > 0)
                        {
                            Node neighbour = neighbours.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                            neighbour.SetHCost(closestGoal.Position);
                            if (neighbour.hCost < currentNode.hCost || (neighbour.hCost > currentNode.hCost && random.NextDouble() < temperature))
                            {
                                neighbour.Visited = true;
                                stack.Push(neighbour);
                                TemperatureRunPath.Add(neighbour);
                                visited.Add(neighbour);
                            }
                        }
                        else
                        {
                            currentNode = stack.Pop();
                        }
                    }

                    if (GoalReached)
                    {
                        startingNode = closestGoal;
                        foreach (Node v in visited)
                        {
                            v.Visited = false;
                        }
                    }
                    Goals.Remove(closestGoal);
                }
                path.Add(TemperatureRunPath);
            }
            return path;
        }

        // Helpers
        private List<Node> GetNodeWalkableNeighbours(Point nodePosition, Boolean removeVisitedNodes = false)
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
                    if (!nodeGrid[neighbourX, neighbourY].Visited || !removeVisitedNodes)
                        neighbours.Add(nodeGrid[neighbourX, neighbourY]);
            }
            return neighbours;
        }

        public static Int32 GetManhattanDistance(Point a, Point b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }

    }
}
