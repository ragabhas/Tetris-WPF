﻿namespace Tetris.Blocks
{
    public class TBlock : Block
    {
        public override int Id => 6;
        protected override Position[][] Tiles => m_tiles;
        protected override Position StartOffset => new Position(0, 3);

        #region private fields and constants
        private readonly Position[][] m_tiles = new Position[][]
        {
            new Position[] { new(0, 1), new(1, 0), new(1, 1), new(1, 2) },
            new Position[] { new(0, 1), new(1, 1), new(1, 2), new(2, 1) },
            new Position[] { new(1, 0), new(1, 1), new(1, 2), new(2, 1) },
            new Position[] { new(0, 1), new(1, 0), new(1, 1), new(2, 1) },
        };
        #endregion
    }
}