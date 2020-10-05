using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Summative2DGame
{
    public class Player
    {
        public int playerSpeed, playerHealth, x, y, size;
        Boolean playerDirection;

        public Player(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;
        }
        //public void Move(int playerSpeed, Boolean playerDirection)
        //{
        //    //true means moving right
        //    if (playerDirection == true) { x += playerSpeed; }
        //    else { x -= playerSpeed; }
        //}
        public void Move(int speed, string direction)
        {
            //true represents right
            if (direction == "right")
            {
                x += speed;
            }
            else
            {
                x -= speed;
            }
        }
    }
}
