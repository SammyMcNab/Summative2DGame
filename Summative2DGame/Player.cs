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
        public int x, y, size, speed, startY, startX;
        public Boolean playerDirection;

        public Image shipImage;
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
        //public Ship(int _x, int _y, Image _image)
        //{
        //    x = _x;
        //    y = _y;
        //    startX = _x;
        //    startY = _y;
        //    shipImage = _image
        //}
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
        //public void Move(string direction)
        //{
        //    switch (direction)
        //    {
        //        case "up":
        //            y -= playerSpeed;
        //            break;
        //        case "down":
        //            y += playerSpeed;
        //            break;
        //        case "right":
        //            x += playerSpeed;
        //            break;
        //        case "left":
        //            x -= playerSpeed;
        //            break;
        //    }
        //}
        public void Power(string power)
        {
            switch (power)
            {
                case "Green":
                    break;
                case "Purple":
                    break;
            }
        }
    }
}
