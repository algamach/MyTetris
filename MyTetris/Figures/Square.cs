using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTetris.Figures
{
    internal class Square:Figure
    {
        public Square(int x, int y)
        {
            x--;
            y--;
            x *= 2;
            x += 19;

            Blocks[0] = new Block(x, y);
            Blocks[1] = new Block(x+2, y);
            Blocks[2] = new Block(x, y+1);
            Blocks[3] = new Block(x + 2, y+1);
            Color = Color.YELLOW;
        }

        public override void RotateReverse()
        {

        }

        internal override void TryRotate()
        {

        }
    }
}
