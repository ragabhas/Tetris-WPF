using Tetris.Blocks;

namespace Tetris.Game
{
    public class GameState
    {
        public GameState()
        {
            GameGrid = new GameGrid(22, 10);
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
        }

        public Block CurrentBlock
        {
            get => m_currentBlock;
            set
            {
                m_currentBlock = value;
                m_currentBlock.Reset();
            }
        }

        public GameGrid GameGrid { get; }
        public BlockQueue BlockQueue { get; }
        public bool GameOver { get; private set; }

        public void RotateBlockClockWise()
        {
            CurrentBlock.RotateClockWise();

            if (!BlockFits())
            {
                CurrentBlock.RotateCounterClockWise();
            }
        }

        public void RotateBlockCounterClockWise()
        {
            CurrentBlock.RotateCounterClockWise();

            if (!BlockFits())
            {
                CurrentBlock.RotateClockWise();
            }
        }

        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }

        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }

        public void MoveDown()
        {
            CurrentBlock.Move(1,0);

            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }
        private bool BlockFits()
        {
            foreach (var position in CurrentBlock.TilePositions())
            {
                if (!GameGrid.IsEmpty(position.Row, position.Column))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0)) && !(GameGrid.IsRowEmpty(1));
        }

        private void PlaceBlock()
        {
            foreach (var position in CurrentBlock.TilePositions())
            {
                GameGrid[position.Row, position.Column] = CurrentBlock.Id;
            }

            GameGrid.ClearFullRows();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
        }

        #region private fields and constants
        private Block m_currentBlock;
        #endregion
    }
}