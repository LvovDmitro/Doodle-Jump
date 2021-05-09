using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Дополнительное_задание_1_Dooudle_jump_.Classes
{
   public class Transform
    {
        public PointF position;   //храним координату и размер какого-либо объекта, + подлкючаем графические функции
        public Size size;

        public Transform(PointF position, Size size)
        {
            this.position = position;
            this.size = size;
        }
        
    }
}
