using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Дополнительное_задание_1_Dooudle_jump_.Classes
{
  public  class Platform
    {
        Image sprite; //отрисованная картинка
        public Transform transform;
        public int sizeX;
        public int sizeY; //размер платформы
        public bool isTouchedByPLayer;
        
        public Platform(PointF pos)
        {
            sprite = Properties.Resources.platform;
            sizeX = 60;
            sizeY = 12;
            transform = new Transform(pos, new Size(sizeX, sizeY));
            isTouchedByPLayer = false;
        }

        public void DrawSprite(Graphics g) //отрисовка текущей платформы
        {
            g.DrawImage(sprite, transform.position.X, transform.position.Y, transform.size.Width, transform.size.Height);
        }
    }
}
