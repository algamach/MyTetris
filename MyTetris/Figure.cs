﻿namespace MyTetris
{
    internal abstract class Figure
    {
        public const int LENGTH = 4;
        public Block[] Blocks = new Block[LENGTH];
        private Color _color;

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public void Draw()
        {
            foreach (var block in Blocks)
                block.Draw(Color);
        }
        public void Hide()
        {
            foreach (var block in Blocks)
                block.Hide();
        }
        public void FullyHide()
        {
            foreach (var block in Blocks)
                block.FullyHide();
        }
        public ValidationResult Validation()
        {
            ValidationResult result = ValidationResult.SUCCESS;

            foreach (var block in Blocks)
                switch (block.Validation())
                {
                    case ValidationResult.BORDER:
                        result = ValidationResult.BORDER;
                        break;
                    case ValidationResult.BLOCKS_OR_DOWN_BORDER:
                        if (result != ValidationResult.BORDER)
                            result = ValidationResult.BLOCKS_OR_DOWN_BORDER;
                        break;
                }

            return result;
        }
        public void Move(Direction direction)
        {
            Hide();

            foreach (var block in Blocks)
                block.Move(direction);

            switch (Validation())
            {
                case ValidationResult.BORDER:
                    foreach (var block in Blocks)
                        block.MoveReverse(direction);
                    break;
                case ValidationResult.BLOCKS_OR_DOWN_BORDER:
                    if (direction == Direction.DOWN)
                        foreach (var block in Blocks)
                        {
                            block.MoveReverse(direction);
                            block.AddBlockOnField(Color);
                        }
                    else goto case ValidationResult.BORDER;
                    break;
            }
            Draw();
        }
        public void Rotate()
        {
            Hide();
            TryRotate();
            if (Validation() != ValidationResult.SUCCESS)
                RotateReverse();
            Draw();
        }
        internal abstract void TryRotate();
        public abstract void RotateReverse();
        public static Figure GetRandomFigure(int x, int y)
        {
            Random random = new Random();
            int randomInt = random.Next(0, 7);
            switch (randomInt)
            {
                case 0:
                    return new Square(x, y);
                    break;
                case 1:
                    return new T(x, y);
                    break;
                case 2:
                    return new Z(x, y);
                    break;
                case 3:
                    return new S(x, y);
                    break;
                case 4:
                    return new L(x, y);
                    break;
                case 5:
                    return new J(x, y);
                    break;
                case 6:
                    return new Stick(x, y);
                    break;
                default:
                    return new Z(x, y);
                    break;
            }
        }
        public void MoveFromNextToCurrent()
        {
            foreach (var block in Blocks)
            {
                block.X -= 22;
                block.Y -= 4;
            }
        }

    }
}
