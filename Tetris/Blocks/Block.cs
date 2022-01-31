using System.Collections.Generic;
using Tetris.Game;

namespace Tetris.Blocks
{
    public abstract class Block
    {
        public Block()
        {
            m_offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        public abstract int Id { get; }

        public IEnumerable<Position> TilePositions()
        {
            foreach (var position in Tiles[m_rotationState])
            {
                yield return new Position(position.Row + m_offset.Row, position.Column + m_offset.Column);
            }
        }

        public void RotateClockWise()
        {
            m_rotationState = (m_rotationState + 1) % Tiles.Length;
        }

        public void RotateCounterClockWise()
        {
            if (m_rotationState == 0)
            {
                m_rotationState = Tiles.Length - 1;
            }
            else
            {
                m_rotationState--;
            }
        }

        public void Move(int rows, int columns)
        {
            m_offset.Row += rows;
            m_offset.Column += columns;
        }

        public void Reset()
        {
            m_rotationState = 0;
            m_offset.Row = StartOffset.Row;
            m_offset.Column = StartOffset.Column;
        }

        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffset { get; }

        #region private fields and constants
        private Position m_offset;

        private int m_rotationState;
        #endregion
    }
}