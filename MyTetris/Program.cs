﻿using MyTetris;

internal class Program
{
    private static void Main(string[] args)
    {
        Field.Inint();
        Test();
    }
    private static void MoveByButton(ConsoleKeyInfo cki, Figure figure)
    {
        switch (cki.Key)
        {
            case ConsoleKey.Spacebar:
                figure.Rotate(); break;
            case ConsoleKey.UpArrow:
                figure.Move(Direction.UP); break;
            case ConsoleKey.DownArrow:
                figure.Move(Direction.DOWN); break;
            case ConsoleKey.RightArrow:
                figure.Move(Direction.RIGHT); break;
            case ConsoleKey.LeftArrow:
                figure.Move(Direction.LEFT); break;
        }
    }
    static void Test()
    {
        Figure currenFigure = Figure.GetRandomFigure(Field.Width / 2, 1);

        while (true)
        {
            Figure nextFigure = Figure.GetRandomFigure(16, 5);
            nextFigure.Draw();
            currenFigure.Draw();

            ConsoleKeyInfo cki;
            while (currenFigure.Life)
            {
                cki = Console.ReadKey();
                MoveByButton(cki, currenFigure);
            }
            nextFigure.FullyHide();
            currenFigure = nextFigure;
            currenFigure.MoveFromNextToCurrent();
            nextFigure = Figure.GetRandomFigure(16, 5);
        }
    }
    static void TestSquare()
    {
        Square currenFigure = new Square(Field.Width / 2, 1);

        while (true)
        {
            Square nextFigure =new Square(16, 5);
            nextFigure.Draw();
            currenFigure.Draw();

            ConsoleKeyInfo cki;
            while (currenFigure.Life)
            {
                cki = Console.ReadKey();
                MoveByButton(cki, currenFigure);
            } 

            nextFigure.FullyHide();
            currenFigure = nextFigure;
            currenFigure.MoveFromNextToCurrent();
            nextFigure = new Square(16, 5);
        }
    }
}