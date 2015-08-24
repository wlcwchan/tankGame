using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Battlefield.GameLogic
{
    class GameBoard
    {

        public const String MARKER_FOG_OF_WAR = "~";
        public const String MARKER_TANK_HIT = "X";
        public const String MARKER_TANK_MISS = ".";
        public const String MARKER_TANK = "t";
        public const String MARKER_END_GAME_SPACE = " ";

        private const int ASCII_CONVERSION_TO_LETTER = 97;
        private int numTanks;
        private static int boardSize;
        private int tankSize;

        private String[,] grid;
        private String[,] tankGrid;
        private ArrayList enemyTanks = new ArrayList();
        private Random rand = new Random();

        public GameBoard(int numTanks, int boardSize, int tankSize)
        {
            this.numTanks = numTanks;
            this.tankSize = tankSize;
            GameBoard.boardSize = boardSize;
            initalizeBoard();
            populateTanks();
            printGrid();
        }

        private void initalizeBoard()
        {
            grid = new String[boardSize, boardSize];
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    grid[i, j] = MARKER_FOG_OF_WAR;
                }
            }

            tankGrid = new String[boardSize, boardSize];
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    tankGrid[i, j] = MARKER_FOG_OF_WAR;
                }
            }
        }

        private void populateTanks()
        {
            int numTanksLeft = numTanks;
            while (numTanksLeft > 0)
            {
                numTanksLeft = generateTetrominoTanks(numTanksLeft);
            }
        }

        private void possiblePositions(ArrayList list, int currX, int currY)
        {
            if (currX > 0)
            {
                String left = String.Format("{0},{1}", currX - 1, currY);
                list.Add(left);
            }

            if (currX < boardSize - 1)
            {
                String right = String.Format("{0},{1}", currX + 1, currY);
                list.Add(right);
            }

            if (currY > 0)
            {
                String up = String.Format("{0},{1}", currX, currY - 1);
                list.Add(up);
            }

            if (currY < boardSize - 1)
            {
                String down = String.Format("{0},{1}", currX, currY + 1);
                list.Add(down);
            }
        }

        private int generateTetrominoTanks(int numTanksLeft)
        {
            int xCord = rand.Next(0, boardSize - 1);
            int yCord = rand.Next(0, boardSize - 1);

            int numBlocks = 0;
            int tempCordIndex = 0;
            String[] tempContainer = new String[tankSize];
            ArrayList posLoc = new ArrayList();

            if (tankGrid[xCord, yCord] == MARKER_FOG_OF_WAR)
            {
                Console.WriteLine(String.Format("{0},{1}", xCord, yCord));
                tempContainer[tempCordIndex] = String.Format("{0},{1}", xCord, yCord);
                tempCordIndex += 1;
                possiblePositions(posLoc, xCord, yCord);
                numBlocks += 1;

                while (numBlocks < tankSize)
                {
                    if (posLoc.Count == 0)
                    {
                        return numTanksLeft;
                    }

                    int ranBlock = rand.Next(0, posLoc.Count - 1);

                    String[] cordRanBlock = posLoc[ranBlock].ToString().Split(',');
                    int xCordRanBlock = Int32.Parse(cordRanBlock[0]);
                    int yCordRanBlock = Int32.Parse(cordRanBlock[1]);
                    posLoc.RemoveAt(ranBlock);

                    bool existingBlock = !tempContainer.Contains(String.Format("{0},{1}", xCordRanBlock, yCordRanBlock));
                    bool notFogOfWar = tankGrid[xCordRanBlock, yCordRanBlock] == MARKER_FOG_OF_WAR;

                    if (existingBlock && notFogOfWar)
                    {
                        tempContainer[tempCordIndex] = String.Format("{0},{1}", xCordRanBlock, yCordRanBlock);
                        tempCordIndex += 1;
                        possiblePositions(posLoc, xCordRanBlock, yCordRanBlock);
                        numBlocks += 1;
                    }
                }
                updateTankGrid(tempContainer, numTanksLeft);
                return numTanksLeft - 1;
            }
            return numTanksLeft;
        }

        private void updateTankGrid(String[] tankList, int marker)
        {
            ArrayList tetroTank = new ArrayList();
            foreach (String tank in tankList)
            {
                if (tank != null)
                {
                    Console.WriteLine(String.Format("Tank#{0} loc-{1}", marker, tank));
                    String[] cordTank = tank.ToString().Split(',');
                    int xCordTank = Int32.Parse(cordTank[0]);
                    int yCordTank = Int32.Parse(cordTank[1]);
                    tankGrid[xCordTank, yCordTank] = marker.ToString();
                    tetroTank.Add(tank);
                }
            }
            enemyTanks.Add(new Tank(tetroTank));
        }

        private void printGrid()
        {
            int newLine = boardSize;
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (newLine == 1)
                    {
                        Console.WriteLine(tankGrid[i, j]);
                        newLine = boardSize;
                    }
                    else
                    {
                        Console.Write(tankGrid[j, i]);
                        newLine -= 1;
                    }
                }

            }
        }

        public ArrayList getEnemyTanks()
        {
            return enemyTanks;
        }

        public String[,] getGrid()
        {
            return grid;
        }

        public String[,] getTankGrid()
        {
            return tankGrid;
        }

        public void updateGrid(String coordinate, bool isHit)
        {
            int xCord = getXcoordinate(coordinate);
            int yCord = getYcoordinate(coordinate);
            if (grid[xCord, yCord] == MARKER_TANK_HIT)
            {
                grid[xCord, yCord] = MARKER_TANK_HIT;
            }
            else
            {
                grid[xCord, yCord] = isHit ? MARKER_TANK_HIT : MARKER_TANK_MISS;
            }
        }

        public String[,] getLosingGrid()
        {
            foreach (Tank tank in enemyTanks)
            {
                foreach (String coordinate in tank.getTankLocations())
                {
                    int xCord = getXcoordinate(coordinate);
                    int yCord = getYcoordinate(coordinate);
                    if (grid[xCord, yCord] == MARKER_TANK_HIT)
                    {
                        grid[xCord, yCord] = MARKER_TANK_HIT;
                    }
                    else
                    {
                        grid[xCord, yCord] = MARKER_TANK;
                    }
                }
            }

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (grid[i, j] == MARKER_FOG_OF_WAR)
                    {
                        grid[i, j] = MARKER_END_GAME_SPACE;
                    }
                }
            }
            return grid;
        }

        private int getXcoordinate(String coordinate)
        {
            String[] x = coordinate.Split(',');
            return Int32.Parse(x[0]);
        }

        private int getYcoordinate(String coordinate)
        {
            String[] y = coordinate.Split(',');

            return Int32.Parse(y[1]);
        }

        public static int getBoardSize()
        {
            return boardSize;
        }
    }
}
