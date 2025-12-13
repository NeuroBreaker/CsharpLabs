using System;
using System.Threading;

namespace FifthLab.Tetris
{

    /// <summary>
    /// Содержит в себе код реализации тетриса
    /// </summary>
    class TetrisGame
    {

        const int BoardWidth = 10;
        const int BoardHeight = 10;
        int[,] board = new int[BoardHeight, BoardWidth]; 

        Random random = new Random();

        int[,] _currentPiece;
        int _currentColor;
        int _currentX;
        int _currentY;

        bool _gameOver = false;
        int _score = 0;

        int[][,] Pieces = {
            new int[,] { {1,1,1,1} },
            new int[,] { {1,1}, {1,1} },
            new int[,] { {0,1,0}, {1,1,1} },
            new int[,] { {0,1,1}, {1,1,0} },
            new int[,] { {1,1,0}, {0,1,1} },
            new int[,] { {1,0,0}, {1,1,1} },
            new int[,] { {0,0,1}, {1,1,1} }
        };

        bool CheckCollision(int x, int y, int[,] piece)
        {
            for (int row = 0; row < piece.GetLength(0); row++)
            {
                for (int col = 0; col < piece.GetLength(1); col++)
                {
                    if (piece[row, col] == 1)
                    {
                        int boardX = x + col;
                        int boardY = y + row;
                        
                        if (boardX < 0 || boardX >= BoardWidth || 
                            boardY >= BoardHeight || 
                            (boardY >= 0 && board[boardY, boardX] != 0))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        void SpawnPiece()
        {
            int pieceIndex = random.Next(Pieces.Length);
            _currentPiece = (int[,])Pieces[pieceIndex].Clone();
            _currentColor = pieceIndex + 1;
            _currentX = BoardWidth / 2 - _currentPiece.GetLength(1) / 2;
            _currentY = -1;
            
            if (CheckCollision(_currentX, _currentY, _currentPiece))
            {
                _gameOver = true;
            }
        }

        ConsoleColor GetColor(int colorNum)
        {
            switch (colorNum)
            {
                case 1: return ConsoleColor.Cyan;
                case 2: return ConsoleColor.Yellow;
                case 3: return ConsoleColor.Magenta;
                case 4: return ConsoleColor.Green;
                case 5: return ConsoleColor.Red;
                case 6: return ConsoleColor.Blue;
                case 7: return ConsoleColor.DarkYellow;
                default: return ConsoleColor.White;
            }
        }

        void DrawHorizontal(char left, char right)
        {
            Console.Write(left);
            for (int i = 0; i < board.GetLength(1) * 2; i++)
                Console.Write('═');
            Console.WriteLine(right);
        }

        void DrawTop() => DrawHorizontal('╔', '╗');
        void DrawBottom() => DrawHorizontal('╚', '╝');

        void Draw()
        {
            Console.Clear();
            int[,] drawBoard = (int[,])board.Clone();

            for (int row = 0; row < _currentPiece.GetLength(0); row++)
            {
                for (int col = 0; col < _currentPiece.GetLength(1); col++)
                {
                    if (_currentPiece[row, col] == 1)
                    {
                        int y = _currentY + row;
                        int x = _currentX + col;

                        if (y >= 0 && y < BoardHeight && x >= 0 && x < BoardWidth)
                        {
                            drawBoard[y, x] = _currentColor;
                        }
                    }
                }
            }

            DrawTop();            
            
            // Рисуем поле
            for (int row = 0; row < board.GetLength(0); row++)
            {
                Console.Write('║');
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    int cell = drawBoard[row, col];
                    if (cell == 0)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.ForegroundColor = GetColor(cell);
                        Console.Write("██");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine('║');
            }

            DrawBottom();

            Console.WriteLine($"\n  Счёт: {_score}");
            Console.WriteLine("\n  Управление:");
            Console.WriteLine("  ← → или A D - движение");
            Console.WriteLine("  ↑ или W - поворот");
            Console.WriteLine("  ↓ или S - ускорить");
            Console.WriteLine("  Пробел - сброс");
            Console.WriteLine("  Esc - выход");
        }

        int[,] RotatedPiece(int[,] piece)
        {
            int rows = piece.GetLength(0);
            int columns = piece.GetLength(1);
            int[,] rotatedPiece = new int[columns, rows];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    rotatedPiece[col, rows - 1 - row] = piece[row, col];
                }
            }

            return rotatedPiece;
        }

        void ClearLines()
        {
            int linesCleared = 0;

            for (int row = BoardHeight - 1; row >= 0; row--)
            {
                bool fullLine = true;

                for (int col = 0; col < BoardWidth; col++)
                {
                    if (board[row, col] == 0)
                    {
                        fullLine = false;
                        break;
                    }
                }

                if (fullLine)
                {
                    linesCleared++;
                    for (int r = row; r > 0; r--)
                    {
                        for (int c = 0; c < BoardWidth; c++)
                        {
                            board[r, c] = board[r - 1, c];
                        }
                    }
                    row++;
                }
            }

            if (linesCleared > 0)
            {
                _score += linesCleared * linesCleared * 100;
            }
        }

        void PlacePiece()
        {
            for (int row = 0; row < _currentPiece.GetLength(0); row++)
            {
                for (int column = 0; column < _currentPiece.GetLength(1); column++)
                {
                    if (_currentPiece[row, column] == 1 && _currentY + row >= 0)
                    {
                        board[_currentY + row, _currentX + column] = _currentColor;
                    }
                }
            }

            ClearLines();
            SpawnPiece();
        }

        // Обработка ввода
        void HandleInput()
        {
            while (!_gameOver)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.A:
                            if (!CheckCollision(_currentX - 1, _currentY, _currentPiece))
                            {
                                _currentX--;
                            }
                            Draw();
                            break;

                        case ConsoleKey.RightArrow:
                        case ConsoleKey.D:
                            if (!CheckCollision(_currentX + 1, _currentY, _currentPiece))
                            {
                                _currentX++;
                            }
                            Draw();
                            break;

                        case ConsoleKey.UpArrow:
                        case ConsoleKey.W:
                            int[,] rotated = RotatedPiece(_currentPiece);
                            if (!CheckCollision(_currentX, _currentY, rotated))
                            {
                                _currentPiece = rotated;
                            }
                            Draw();
                            break;

                        case ConsoleKey.DownArrow:
                        case ConsoleKey.S:
                            if (!CheckCollision(_currentX, _currentY + 1, _currentPiece))
                                _currentY++;
                            Draw();
                            break;

                        case ConsoleKey.Spacebar:
                        case ConsoleKey.Enter:
                            while (!CheckCollision(_currentX, _currentY + 1, _currentPiece))
                                _currentY++;
                            PlacePiece();
                            Draw();
                            break;

                        case ConsoleKey.Escape:
                            _gameOver = true;
                            break;
                    }
                }
                Thread.Sleep(16);
            }
        }

        void NewGame()
        {
            _gameOver = false;
            board = new int[BoardHeight, BoardWidth];
            _score = 0;
        }

        /// <summary>
        /// Главный публичный метод, можно назвать точкой входа для тетриса
        /// </summary>
        public void Tetris()
        {
            Console.Clear();

            NewGame();
            SpawnPiece();

            Thread inputThread = new Thread(HandleInput);
            inputThread.Start();

            while (!_gameOver)
            {
                if (!CheckCollision(_currentX, _currentY + 1, _currentPiece))
                {
                    _currentY++;
                }
                else
                {
                    PlacePiece();
                }
                Draw();
                Thread.Sleep(750);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n╔═══════════════════════╗");
            Console.WriteLine($"║   ИГРА ОКОНЧЕНА!      ║");
            Console.WriteLine($"║   Счёт: {_score,-14}║");
            Console.WriteLine($"╚═══════════════════════╝");
            Console.ResetColor();
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
