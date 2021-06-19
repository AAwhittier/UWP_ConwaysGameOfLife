using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI;
using Microsoft.Graphics.Canvas.UI.Xaml;

namespace ConwaysGameOfLifeV1
{
    public sealed partial class MainPage : Page
    {
        private readonly GameOfLife game = new GameOfLife();
        private const int CellSize = 2;
        private const int BoardSize = 400;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void GameCanvas_CreateResources(CanvasControl sender, CanvasCreateResourcesEventArgs args)
        {
            args.TrackAsyncAction(CreateResourceAsyn(sender).AsAsyncAction());
        }

        async Task CreateResourceAsyn(CanvasControl sender)
        {
            //todo await
        }

        private void GameCanvas_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            // Remove any lingering living cell artifacts.
            args.DrawingSession.Clear(Colors.Red);

            // Take control away from the drawing session so the completed frame is drawn.
            sender.Invalidate();

            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    // Draw the cell grid with red being living cells and black being dead cells.
                    if (game.Grid[i, j] == GameOfLife.CellState.Alive)
                    {
                        args.DrawingSession.DrawRectangle(i * 4, j * 4, CellSize, CellSize, Colors.Red);
                    }
                    else
                    {
                        args.DrawingSession.DrawRectangle(i * 4, j * 4, CellSize, CellSize, Colors.Black);
                    }
                }
            }
            // Begin the next generation of cells.
            game.NextGeneration();
        }
    }
}
