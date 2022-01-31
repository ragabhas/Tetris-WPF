﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Tetris.Blocks;
using Tetris.Game;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            m_imagesControl = SetupGameCanvas(m_gameState.GameGrid);
        }

        private void DrawGrid(GameGrid gameGrid)
        {
            for (var row = 0; row < gameGrid.Rows; row++)
            {
                for (var column = 0; column < gameGrid.Columns; column++)
                {
                    var id = gameGrid[row, column];
                    m_imagesControl[row, column].Source = m_tileImages[id];
                }
            }
        }

        private void DrawBlock(Block block)
        {
            foreach (var position in block.TilePositions())
            {
                m_imagesControl[position.Row, position.Column].Source = m_tileImages[block.Id];
            }
        }

        private void Draw(GameState gameState)
        {
            DrawGrid(gameState.GameGrid);
            DrawBlock(gameState.CurrentBlock);
        }

        private Image[,] SetupGameCanvas(GameGrid gameGrid)
        {
            var imageControls = new Image[gameGrid.Rows, gameGrid.Columns];

            var cellSize = 25;

            for (var row = 0; row < gameGrid.Rows; row++)
            {
                for (var column = 0; column < gameGrid.Columns; column++)
                {
                    var imageControl = new Image
                    {
                        Height = cellSize, Width = cellSize
                    };
                    Canvas.SetTop(imageControl, (row - 2) * cellSize);
                    Canvas.SetLeft(imageControl, column * cellSize);
                    GameCanvas.Children.Add(imageControl);
                    imageControls[row, column] = imageControl;
                }
            }

            return imageControls;
        }

        private void Windows_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GameCanvas_OnLoaded(object sender, RoutedEventArgs e)
        {
            Draw(m_gameState);
        }

        private void Play_Again(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #region private fields and constants
        private readonly ImageSource[] m_blockImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-I.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-J.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-L.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-O.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-S.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-T.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-Z.png", UriKind.Relative)),
        };

        private readonly Image[,] m_imagesControl;

        private readonly ImageSource[] m_tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/TileEmpty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileCyan.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileBlue.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileOrange.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileYello.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileGreen.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TilePurple.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileRed.png", UriKind.Relative))
        };

        private GameState m_gameState = new GameState();
        #endregion
    }
}