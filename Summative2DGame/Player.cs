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
        public int x, y, size,speed;
        public Boolean playerDirection;

        //player configurations
        public static int playerSize = 20;
        public static int playerSpeed = 15;



        public Player(int _x, int _y, int _size, int _speed)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
        }
        public void Move(int playerSpeed, Boolean playerDirection)
        {
            //true means moving right
            if (playerDirection == true) 
            { 
                x += playerSpeed; 
            }
            else 
            { 
                x -= playerSpeed; 
            }
        }
    }
}
