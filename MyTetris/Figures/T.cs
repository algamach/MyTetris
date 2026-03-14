namespace MyTetris.Figures
{
    internal class T : Figure
    {
        private int _condition = 0;
        public T(int x, int y)
        {
            x--;
            y--;
            x *= 2;
            x += 19;

            Blocks[0] = new Block(x, y);
            Blocks[1] = new Block(x - 2, y + 1);
            Blocks[2] = new Block(x, y + 1);
            Blocks[3] = new Block(x + 2, y + 1);
            Color = Color.MAGENTA;
        }
        internal override void TryRotate()
        {
            switch (_condition)
            {
                case 0:
                    Blocks[1].X += 2;
                    Blocks[1].Y += 1;
                    _condition = 1;
                    break;
                case 1:
                    Blocks[0].X -= 2;
                    Blocks[0].Y += 1;
                    _condition = 2;
                    break;
                case 2:
                    Blocks[3].X -= 2;
                    Blocks[3].Y -= 1;
                    _condition = 3;
                    break;
                case 3:
                    Blocks[0].X += 2;
                    Blocks[0].Y -= 1;
                    Blocks[1].X -= 2;
                    Blocks[1].Y -= 1;
                    Blocks[3].X += 2;
                    Blocks[3].Y += 1;
                    _condition = 0;
                    break;
            }
        }
        public override void RotateReverse()
        {
            switch (_condition)
            {
                case 1:
                    Blocks[1].X -= 2;
                    Blocks[1].Y -= 1;
                    _condition = 0;
                    break;
                case 2:
                    Blocks[0].X += 2;
                    Blocks[0].Y -= 1;
                    _condition = 1;
                    break;
                case 3:
                    Blocks[3].X += 2;
                    Blocks[3].Y += 1;
                    _condition = 2;
                    break;
                case 0:
                    Blocks[0].X -= 2;
                    Blocks[0].Y += 1;
                    Blocks[1].X += 2;
                    Blocks[1].Y += 1;
                    Blocks[3].X -= 2;
                    Blocks[3].Y -= 1;
                    _condition = 3;
                    break;
            }
        }
    }
}
