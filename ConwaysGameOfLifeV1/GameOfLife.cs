using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLifeV1
{
    class GameOfLife
    {
        // Possible states of the each cell in the game.
        public enum CellState
        {
            Dead = 0,
            Alive = 1,
        }

        // Grid size.
        private int Rows { get; set; }
        private int Columns { get; set; }

        // Create grids of cellstates for the game board.
        public CellState[,] Grid { get; set; }
        private CellState[,] NextGenGrid { get; set; }

        public GameOfLife()
        {
            Rows = 400;
            Columns = 400;

            Grid = new CellState[Rows, Columns];

            var random = new Random();

            // Randomly fill game board states.
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    Grid[row, column] = (CellState) random.Next(Enum.GetNames(typeof(CellState)).Length);
                }
            }
        }

        public void NextGeneration()
        {
            NextGenGrid = new CellState[Rows, Columns];

            for (var row = 1; row < Rows - 1; row++)
            {
                for (var column = 1; column < Columns - 1; column++)
                {
                    var countLivingNeighbors = 0;

                    // Check a 9 cell area surrounding the current index. Sum the living cells.
                    for (var i = -1; i <= 1; i++)
                    {
                        for (var j = -1; j <= 1; j++)
                        {
                            countLivingNeighbors += Grid[row + i, column + j] == CellState.Alive ? 1 : 0;
                        }
                    }

                    // Store current cell for logic checks.
                    var current = Grid[row, column];

                    // Remove the current cell if it was included in the count.
                    if (current == CellState.Alive)
                    {
                        countLivingNeighbors -= 1;
                    }

                    // Play the rules of the game of life.
                    // Any live cell with two or three live neighbours survives.
                    // Any dead cell with three live neighbours becomes a live cell.
                    // All other live cells die in the next generation.Similarly, all other dead cells stay dead.

                    if (current == CellState.Alive && countLivingNeighbors < 2)
                    {
                        NextGenGrid[row, column] = CellState.Dead;
                    }
                    else if (current == CellState.Dead && countLivingNeighbors == 3)
                    {
                        NextGenGrid[row, column] = CellState.Alive;
                    }
                    else if (current == CellState.Alive && (countLivingNeighbors == 2 || countLivingNeighbors == 3))
                    {
                        NextGenGrid[row, column] = CellState.Alive;
                    }
                    else
                    {
                        NextGenGrid[row, column] = CellState.Dead;
                    }
                }
            }
            // Assign the next generation of cells.
            Grid = NextGenGrid;
        }
    }
}
