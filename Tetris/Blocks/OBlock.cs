﻿using Tetris.Game;

namespace Tetris.Blocks
{
    public class OBlock : Block
    {
        public override int Id => 4;
        protected override Position[][] Tiles => m_tiles;
        protected override Position StartOffset => new Position(0, 4);

        #region private fields and constants
        private readonly Position[][] m_tiles = new Position[][]
        {
            new Position[] { new(0, 0), new(0, 1), new(1, 0), new(1, 1) },
        };
        #endregion
    }
}