using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTetris.Figures
{
    internal class Stick : Figure
    {
        private int _condition = 0;
        public Stick(int x, int y)
        {
            x--;
            y--;
            x *= 2;
            x += 19;
            
            Blocks[0] = new Block(x, y);
            Blocks[1] = new Block(x, y + 1);
            Blocks[2] = new Block(x, y + 2);
            Blocks[3] = new Block(x, y + 3);
            Color = Color.CYAN;
        }
        internal override void TryRotate()
        {
            switch (_condition)
            {
                case 0:
                    Blocks[0].X += 2;
                    Blocks[0].Y += 1;
                    Blocks[2].X -= 2;
                    Blocks[2].Y -= 1;
                    Blocks[3].X -= 4;
                    Blocks[3].Y -= 2;
                    _condition = 1;
                    break;
                case 1:
                    Blocks[0].X -= 2;
                    Blocks[0].Y -= 1;
                    Blocks[2].X += 2;
                    Blocks[2].Y += 1;
                    Blocks[3].X += 4;
                    Blocks[3].Y += 2;
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
