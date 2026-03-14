namespace MyTetris.Figures
{
    internal class S : Figure
    {
        private int _condition = 0;
        public S(int x, int y)
        {
            x--;
            y--;
            x *= 2;
            x += 19;

            Blocks[0] = new Block(x, y);
            Blocks[1] = new Block(x + 2, y);
            Blocks[2] = new Block(x - 2, y + 1);
            Blocks[3] = new Block(x, y + 1);
            Color = Color.GREEN;
        }
        internal override void TryRotate()
        {
            switch (_condition)
            {
                case 0:
                    Blocks[0].Y += 2;
                    Blocks[1].X -= 4;
                    _condition = 1;
                    break;
                case 1:
                    Blocks[0].Y -= 2;
                    Blocks[1].X += 4;
                    _condition = 0;
                    break;
            }
        }
        public override void RotateReverse()
        {
            TryRotate();
        }

    }
}
