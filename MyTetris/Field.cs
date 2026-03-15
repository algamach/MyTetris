namespace MyTetris
{
    internal class Field
    {
        private const int _width = 10;
        private const int _height = 20;
        public static int Width { get { return _width; } }
        public static int Height { get { return _height; } }
        public static Color[,] BlocksOnField = new Color[10, 20];
        public static bool IsBlockStrike(int x, int y)
        {
            if (BlocksOnField[(x - 19) / 2, y] != Color.GRAY)
                return true;
            else return false;
        }
        internal static void CheckDeleteLine()
        {
            int lines = 0;
            for (int j = 0; j < Height; j++)
            {
                int line = 0;
                for (int i = 0; i < Width; i++)
                {
                    if (BlocksOnField[i, j] != Color.GRAY)
                        line++;
                }
                if (line == Width)
                {
                    DeleteLine(j);
                    lines++;
                }
            }
            Score.UpdateScore(lines);
        }
        private static void DeleteLine(int line)
        {
            for (int j = line; j >= 0; j--)
            {
                if (j == 0)
                {
                    for (int i = 0; i < Width; i++)
                        BlocksOnField[i, j] = Color.GRAY;
                }
                else
                    for (int i = 0; i < Width; i++)
                        BlocksOnField[i, j] = BlocksOnField[i, j - 1];
            }
            Redraw();
        }
        internal static void Redraw()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (BlocksOnField[i, j] == Color.GRAY)
                        new Block(i * 2 + 19, j).Hide();
                    else
                        new Block(i * 2 + 19, j).Draw(BlocksOnField[i, j]);
                }
            }
        }
        internal static void WriteScore()
        {
            Console.SetCursorPosition(10, 2);
            Console.WriteLine(Score.Count);
        }
        public static void Inint(ref Figure currentFigure, ref Figure nextFigure)
        {
            GetFirstFigures(ref currentFigure, ref nextFigure);
            
            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(60, 22);
                Console.SetBufferSize(60, 22);
            }

            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 20; j++)
                    BlocksOnField[i, j] = Color.GRAY;

            for (int i = 0; i < Height + 1; i++)
            {
                Console.SetCursorPosition(17, i);
                Console.Write("<!");
                Console.SetCursorPosition(17 + 2 + Width * 2, i);
                Console.Write("!>");
            }
            for (int i = 1; i <= Width * 2; i++)
            {
                Console.SetCursorPosition(18 + i, Height);
                Console.Write("=");

                Console.SetCursorPosition(18 + i, Height + 1);
                if (i % 2 == 0)
                {
                    Console.Write("/");
                }
                else
                {
                    Console.Write("\\");
                }
            }
            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(19, i);
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(" .");
                }
            }
            Console.SetCursorPosition(4, 2);
            Console.Write("Счет: ");
            Score.UpdateScore(0);

            Console.SetCursorPosition(42, 2);
            Console.Write("Следующая фигура:");

            Console.SetCursorPosition(0, 0);
        }
        private static void GetFirstFigures(ref Figure currentFigure, ref Figure nextFigure)
        {
            currentFigure = Figure.GetRandomFigure(Field.Width / 2, 1);
            nextFigure = Figure.GetRandomFigure(16, 5);
            currentFigure.Draw();
            nextFigure.Draw();
        }

        internal static void GameOver()
        {
            Console.SetCursorPosition(21, 10);
            Console.WriteLine("G A M E  O V E R");
            Score.Game = false;
            Program.StopTimer();
        }
    }
}
