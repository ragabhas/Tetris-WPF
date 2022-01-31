// ------------------------------------------------------------------
// © Copyright 2022 Thermo Fisher Scientific Inc. All rights reserved.
// ------------------------------------------------------------------
namespace Tetris
{
    public class GameGrid
    {
        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            m_grid = new int[rows, columns];
        }

        public int Rows { get; }
        public int Columns { get; }

        public int this[int row, int column]
        {
            get => m_grid[row, column];
            set => m_grid[row, column] = value;
        }

        public bool IsInside(int row, int column)
        {
            return row >= 0 && row < Rows && column >= 0 && column < Columns;
        }

        public bool IsEmpty(int row, int column)
        {
            return IsInside(row, column) && m_grid[row, column] == 0;
        }

        public bool IsRowFull(int row)
        {
            for (var column = 0; column < Columns; column++)
            {
                if (m_grid[row, column] == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsRowEmpty(int row)
        {
            for (var column = 0; column < Columns; column++)
            {
                if (m_grid[row, column] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public int ClearFullRows()
        {
            int clearedRows = 0;

            for (var row = Rows - 1; row >= 0; row--)
            {
                if (IsRowFull(row))
                {
                    ClearRow(row);
                    clearedRows++;
                }
                else if (clearedRows > 0)
                {
                    MoveDown(row, clearedRows);
                }
            }

            return clearedRows;
        }

        private void ClearRow(int row)
        {
            for (var column = 0; column < Columns; column++)
            {
                m_grid[row, column] = 0;
            }
        }

        private void MoveDown(int row, int numberOfRows)
        {
            for (var column = 0; column < Columns; column++)
            {
                m_grid[row + numberOfRows, column] = m_grid[row, column];
                m_grid[row, column] = 0;
            }
        }

        #region private fields and constants
        private readonly int[,] m_grid;
        #endregion
    }
}