using System;
using Tetris.Blocks;

namespace Tetris.Game
{
    public class BlockQueue
    {
        public BlockQueue()
        {
            NextBlock = GetRandomBlock();
        }

        public Block NextBlock { get; private set; }

        public Block GetAndUpdate()
        {
            var block = NextBlock;

            do
            {
                NextBlock = GetRandomBlock();
            } while (block.Id == NextBlock.Id);

            return block;
        }

        private Block GetRandomBlock()
        {
            return m_blocks[m_random.Next(m_blocks.Length)];
        }

        #region private fields and constants
        private readonly Block[] m_blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()
        };

        private readonly Random m_random = new Random();
        #endregion
    }
}