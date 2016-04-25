using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace MI
{
    public static class GameHandler
    {
        // Fields
        private static Int32 mapXSize = 0, mapYSize = 0;
        private static Point initialLocation = new Point(0, 0);
        private static List<Point> diamonds = new List<Point>() { }, rocks = new List<Point>() { }, walls = new List<Point>() { };
        private static List<Node> goals = new List<Node>();
        private static Node[,] nodeGrid = { };
        private static Int32 rectangleDimension = 0;
        private static Int32 mapXStartPosition, mapYStartPosition;
        private static Int32 mapXInitialPosition = 10, mapYInitialPosition = 130;
        private static Int32 mapXMaxPosition = 560, mapYMaxPosition = 580;
        private static Point currentPlayerPosition= new Point(0,0);
        private static Int32 pathIndex = 0, multiPathIndex = 0;
        private static Double startingTemperature = 1, temperatureDecrement = 0.01;
        private static Int32 maxDepth = 10;
        private static Int32 collectedDiamonds = 0;
        private static Boolean gameOver = false;
        private static Int32 diamondFrameCounter = 0, currentDiamondFrame = 0;
        private static Int32 playerFrameCounter = 0, currentPlayerFrame = 0;

        private static List<Node> path = null;
        private static List<List<Node>> multiPath= null;

        private static GameTime prevGameTime;

        //  Positions: Buttons, Buttons Texts
        private static Vector2 backButtonPosition = new Vector2(600, 525);
        private static Vector2 backButtonTextPosition = new Vector2(650.0f, 547.5f), gameOverTextPosition = new Vector2(580, 130), currentLevelTextPosition = new Vector2(580, 130), currentLevelNumberTextPosition = new Vector2(580, 180), scoreTextPosition = new Vector2(580, 260), scoreNumberTextPosition = new Vector2(580, 310);
        
        // Previous Mouse State: Used for detecting single clicks
        private static MouseState prevMouseState = Mouse.GetState();
        
        // Buttons Hover Booleans
        private static Boolean backHover = false;

        // Manual Mode Stuff
        private static KeyboardState oldKeyboardState;
        private static KeyboardState newkeyboardState = Keyboard.GetState();

        // Played Flipped Flag
        private static bool isPlayerFlipped = false;

        // Prep
        private static void LoadMap()
        {
            StreamReader input = new StreamReader(@"..\..\..\Map.txt");
            String line;
            String[] tokens;
            Resources.backgroundMusicInstance.Play();
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
                            rectangleDimension = Math.Min(550 / mapXSize, 450 / mapYSize);
                            mapXStartPosition = (((mapXMaxPosition - mapXInitialPosition) - (rectangleDimension * mapXSize)) / 2) + mapXInitialPosition;
                            mapYStartPosition = (((mapYMaxPosition - mapYInitialPosition) - (rectangleDimension * mapYSize)) / 2) + mapYInitialPosition;
                            break;
                        case "initiallocation":
                            initialLocation.X = Int32.Parse(tokens[1]);
                            initialLocation.Y = Int32.Parse(tokens[2]);
                            currentPlayerPosition = new Point(initialLocation.X, initialLocation.Y);
                            nodeGrid = new Node[mapXSize, mapYSize];
                            for (int i = 0; i < mapXSize; i++)
                            {
                                for (int j = 0; j < mapYSize; j++)
                                {
                                    nodeGrid[i, j] = new Node(new Point(i, j), new Rectangle(i * rectangleDimension + mapXStartPosition, j * rectangleDimension + mapYStartPosition, rectangleDimension, rectangleDimension), NodeType.SAND, initialLocation);
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
                throw (ex);
            }
        }

        public static void Update(GameTime gameTime, Game1 game, GameState gameState)
        {
            if (prevGameTime == null)
                prevGameTime = new GameTime(gameTime.TotalGameTime, gameTime.ElapsedGameTime);

            if (nodeGrid.Length == 0)
                LoadMap();

            switch (gameState)
            {
                case GameState.MANUAL_MODE:
                    if (!gameOver)
                        ManualMode(gameTime);
                    break;
                case GameState.ASTAR_MODE:
                    if (path == null)
                        path = SolveAStar();
                    if(!gameOver)
                        MovePlayerFromPath(gameTime);
                    break;
                case GameState.IDDFS_MODE:
                    if (multiPath == null)
                        multiPath = SolveIDDFS(maxDepth);
                    if (!gameOver)
                        MovePlayerFrom2DPath(gameTime);
                    break;
                case GameState.CSP_MODE:
                    if (path == null)
                        path = SolveCSP();
                    if (!gameOver)
                        MovePlayerFromPath(gameTime);
                    break;
                case GameState.SA_MODE:
                    if (multiPath == null)
                        multiPath = SolveSA(startingTemperature, temperatureDecrement);
                    if (!gameOver)
                        MovePlayerFrom2DPath(gameTime, true);
                    break;
            }

            if (gameOver)
                Resources.backgroundMusicInstance.Stop();
            
            MouseState mouseState = Mouse.GetState();

            if (mouseState.X < backButtonPosition.X || mouseState.Y < backButtonPosition.Y || mouseState.X > backButtonPosition.X + Resources.buttonBackground.Width || mouseState.Y > backButtonPosition.Y + Resources.buttonBackground.Height)
                backHover = false;
            else
            {
                backHover = true;
                if (mouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
                {
                    game.gameState = GameState.MAIN_MENU;
                    Resources.backgroundMusicInstance.Stop();
                    Reset();
                }
            }

            if (game.gameState != GameState.MAIN_MENU && game.gameState != GameState.SCORES)
                prevMouseState = mouseState;
        }

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch, GameState gameState)
        {
            spriteBatch.Draw(Resources.gameMapBackground, new Vector2(0, 0), Color.White);

            foreach (Node n in nodeGrid)
            {
                switch (n.Type)
                {
                    case NodeType.PLAYER:
                        if(!gameOver)
                        {
                            playerFrameCounter += (Int32)gameTime.ElapsedGameTime.TotalMilliseconds;
                            if (playerFrameCounter > 100)
                            {
                                currentPlayerFrame += 140;
                                playerFrameCounter = 0;
                                if (currentPlayerFrame == 840)
                                    currentPlayerFrame = 0;
                            }
                        }
                        Rectangle playerRectangle = new Rectangle(currentPlayerFrame, 0, 140, 180);
                        if(isPlayerFlipped)
                            spriteBatch.Draw(Flip(n.NodeTile), n.Rectangle, playerRectangle, Color.White);
                        else
                            spriteBatch.Draw(n.NodeTile, n.Rectangle, playerRectangle, Color.White);
                        break;
                    case NodeType.DIAMOND:
                        diamondFrameCounter += (Int32)gameTime.ElapsedGameTime.TotalMilliseconds;
                        if(diamondFrameCounter > 350)
                        {
                            currentDiamondFrame += 140;
                            diamondFrameCounter = 0;
                            if (currentDiamondFrame == 280)
                                currentDiamondFrame = 0;
                        }
                        Rectangle diamondRectangle = new Rectangle(currentDiamondFrame, 0, 140, 140);
                        spriteBatch.Draw(n.NodeTile, n.Rectangle, diamondRectangle, Color.White);
                        break;
                    default:
                        spriteBatch.Draw(n.NodeTile, n.Rectangle, Color.White);
                        break;
                }
            }

            if(gameOver)
                spriteBatch.DrawString(Resources.menuButtonsFont, "game over", gameOverTextPosition, Resources.hoverFontColor);
            else
            {
                switch (gameState)
                {
                    case GameState.IDDFS_MODE:
                        spriteBatch.DrawString(Resources.menuButtonsFont, "current d", currentLevelTextPosition, Resources.normalFontColor);
                        spriteBatch.DrawString(Resources.menuButtonsFont, (multiPathIndex + 1).ToString(), currentLevelNumberTextPosition, Resources.normalFontColor);
                        break;
                    case GameState.SA_MODE:
                        spriteBatch.DrawString(Resources.menuButtonsFont, "current temp", currentLevelTextPosition, Resources.normalFontColor);
                        spriteBatch.DrawString(Resources.menuButtonsFont, String.Format("{0:N2}", (startingTemperature - (temperatureDecrement * multiPathIndex))), currentLevelNumberTextPosition, Resources.normalFontColor);
                        break;
                }
            }

            spriteBatch.DrawString(Resources.menuButtonsFont, "diamonds", scoreTextPosition, Resources.normalFontColor);
            spriteBatch.DrawString(Resources.menuButtonsFont, collectedDiamonds.ToString(), scoreNumberTextPosition, Resources.normalFontColor);

            // BackButton
            spriteBatch.Draw(Resources.buttonBackground, backButtonPosition, Color.White);
            spriteBatch.DrawString(Resources.menuButtonsFont, "back", backButtonTextPosition, backHover ? Resources.hoverFontColor : Resources.normalFontColor);
        }

        private static void ManualMode(GameTime gameTime)
        {
            // Make Mario follow Keyboard
            oldKeyboardState = newkeyboardState;
            newkeyboardState = Keyboard.GetState();

            Point nextMove = null;

            if (newkeyboardState.IsKeyDown(Keys.Left) && oldKeyboardState.IsKeyUp(Keys.Left))
                nextMove = new Point(currentPlayerPosition.X - 1, currentPlayerPosition.Y);
            else if (newkeyboardState.IsKeyDown(Keys.Right) && oldKeyboardState.IsKeyUp(Keys.Right))
                nextMove = new Point(currentPlayerPosition.X + 1, currentPlayerPosition.Y);
            else if (newkeyboardState.IsKeyDown(Keys.Up) && oldKeyboardState.IsKeyUp(Keys.Up))
                nextMove = new Point(currentPlayerPosition.X , currentPlayerPosition.Y - 1);
            else if (newkeyboardState.IsKeyDown(Keys.Down) && oldKeyboardState.IsKeyUp(Keys.Down))
                nextMove = new Point(currentPlayerPosition.X, currentPlayerPosition.Y + 1);

            if (nextMove != null && nextMove.X > -1 && nextMove.X < mapXSize && nextMove.Y > -1 && nextMove.Y < mapYSize && nodeGrid[nextMove.X, nextMove.Y].IsWalkable)
            {

                if (currentPlayerPosition.X + 1 == nextMove.X) // Right
                    isPlayerFlipped = true;
                else if (currentPlayerPosition.X - 1 == nextMove.X) // Left
                    isPlayerFlipped = false;

                nodeGrid[currentPlayerPosition.X, currentPlayerPosition.Y].Type = NodeType.CLEAR;
                currentPlayerPosition = nextMove;
                if (nodeGrid[nextMove.X, nextMove.Y].IsDangerous)
                {
                    nodeGrid[nextMove.X, nextMove.Y - 1].Type = NodeType.CLEAR;
                    nodeGrid[nextMove.X, nextMove.Y].Type = NodeType.DEAD;
                    gameOver = true;
                    Resources.death.Play();
                }
                else
                    nodeGrid[nextMove.X, nextMove.Y].Type = NodeType.PLAYER;
            }

            if (diamonds.Contains(new Point(currentPlayerPosition.X, currentPlayerPosition.Y)))
            {
                collectedDiamonds++;
                Resources.pickupDiamond.Play();
                diamonds.Remove(new Point(currentPlayerPosition.X, currentPlayerPosition.Y));
                if (diamonds.Count == 0)
                {
                    gameOver = true;
                    Resources.tada.Play();
                }
            }
        }

        private static void MovePlayerFromPath(GameTime gameTime)
        {
            if (pathIndex < path.Count && gameTime.TotalGameTime.TotalSeconds - prevGameTime.TotalGameTime.TotalSeconds > 0.1)
            {
                nodeGrid[currentPlayerPosition.X, currentPlayerPosition.Y].Type = NodeType.CLEAR;
                Node nextMove = path[pathIndex++];
                nodeGrid[nextMove.Position.X, nextMove.Position.Y].Type = NodeType.PLAYER;

                if (currentPlayerPosition.X + 1 == nextMove.Position.X) // Right
                    isPlayerFlipped = true;
                else if (currentPlayerPosition.X - 1 == nextMove.Position.X) // Left
                    isPlayerFlipped = false;

                    currentPlayerPosition = nextMove.Position;
                if(diamonds.Contains(new Point(currentPlayerPosition.X,currentPlayerPosition.Y)))
                {
                    collectedDiamonds++;
                    diamonds.Remove(new Point(currentPlayerPosition.X, currentPlayerPosition.Y));
                }
                prevGameTime = new GameTime(gameTime.TotalGameTime, gameTime.ElapsedGameTime);
            }
            else if (pathIndex == path.Count)
            {
                gameOver = true;
                Resources.tada.Play();
            }
        }

        private static void MovePlayerFrom2DPath(GameTime gameTime, Boolean reset = false)
        {   
            if (multiPathIndex < multiPath.Count && gameTime.TotalGameTime.TotalSeconds - prevGameTime.TotalGameTime.TotalSeconds > 0.1)
            {
                if (pathIndex < multiPath[multiPathIndex].Count)
                {
                    nodeGrid[currentPlayerPosition.X, currentPlayerPosition.Y].Type = NodeType.CLEAR;
                    Node nextMove = multiPath[multiPathIndex][pathIndex++];
                    nodeGrid[nextMove.Position.X, nextMove.Position.Y].Type = NodeType.PLAYER;

                    if (currentPlayerPosition.X + 1 == nextMove.Position.X) // Right
                        isPlayerFlipped = true;
                    else if (currentPlayerPosition.X - 1 == nextMove.Position.X) // Left
                        isPlayerFlipped = false;

                    currentPlayerPosition = nextMove.Position;
                    if (diamonds.Contains(new Point(currentPlayerPosition.X, currentPlayerPosition.Y)))
                    {
                        collectedDiamonds++;
                        diamonds.Remove(new Point(currentPlayerPosition.X, currentPlayerPosition.Y));
                    }
                    prevGameTime = new GameTime(gameTime.TotalGameTime, gameTime.ElapsedGameTime);
                }
                else if(pathIndex == multiPath[multiPathIndex].Count)
                {
                    multiPathIndex++;
                    currentPlayerPosition = new Point(initialLocation.X, initialLocation.Y);
                    pathIndex = 0;
                    if(reset)
                    {
                        LoadMap();
                        collectedDiamonds = 0;
                    }
                }
            }
            else if (multiPathIndex == multiPath.Count)
            {
                gameOver = true;
                Resources.tada.Play();
            }
        }

        public static void Reset()
        {
            backHover = false;
            gameOver = false;
            isPlayerFlipped = false;
            diamonds = new List<Point>() { };
            rocks = new List<Point>() { };
            walls = new List<Point>() { };
            goals = new List<Node>();
            nodeGrid = new Node[0,0]{};
            pathIndex = 0;
            multiPathIndex = 0;
            startingTemperature = 1;
            collectedDiamonds = 0;
            diamondFrameCounter = 0;
            path = null;
            multiPath= null;
            prevGameTime = null;
            prevMouseState = new MouseState(0, 0, 0, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
        }

        // Game Solver
        // Algorithms
        public static List<Node> SolveAStar()
        {
            List<Node> Goals = goals, path = new List<Node>();
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

        public static List<List<Node>> SolveIDDFS(Int32 maxDepth)
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

                while (stack.Count > 0)
                {
                    CurrentNode = stack.Pop();
                    currentDepthPath.Add(CurrentNode);

                    List<Node> neighbours = GetNodeWalkableNeighbours(CurrentNode.Position, true);
                    foreach (Node neighbour in neighbours)
                    {
                        if (GetManhattanDistance(initialLocation, neighbour.Position) <= currentDepth)
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

        public static List<Node> SolveCSP()
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
                if (neighbours.Count > 0)
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

        public static List<List<Node>> SolveSA(Double temperature, Double decrement)
        {
            Random random = new Random(DateTime.Now.Second);
            List<List<Node>> path = new List<List<Node>>();
            for (Double currentTemperature = temperature; currentTemperature >= 0; currentTemperature -= decrement)
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

                        if (Goals.Contains(currentNode))
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
        private static List<Node> GetNodeWalkableNeighbours(Point nodePosition, Boolean removeVisitedNodes = false)
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

        private static Int32 GetManhattanDistance(Point a, Point b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }

        public static Texture2D Flip(Texture2D source)
        {
            bool horizontal = true, vertical = false;
            Texture2D flipped = new Texture2D(source.GraphicsDevice, source.Width, source.Height);
            Color[] data = new Color[source.Width * source.Height];
            Color[] flippedData = new Color[data.Length];

            source.GetData<Color>(data);

            for (int x = 0; x < source.Width; x++)
                for (int y = 0; y < source.Height; y++)
                {
                    int idx = (horizontal ? source.Width - 1 - x : x) + ((vertical ? source.Height - 1 - y : y) * source.Width);
                    flippedData[x + y * source.Width] = data[idx];
                }

            flipped.SetData<Color>(flippedData);

            return flipped;
        }  

    }
}
