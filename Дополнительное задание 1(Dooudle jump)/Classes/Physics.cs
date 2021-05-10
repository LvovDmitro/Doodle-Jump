using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Дополнительное_задание_1_Dooudle_jump_.Classes
{
   public class Physics
    {
        public Transform transform;
        float gravity; //для прыжка
        float a; //ускорение
        public float dx; //смещение в стороны

        public Physics(PointF position, Size size)
        {
            transform = new Transform(position, size);
            gravity = 0;
            a = 0.4f; //скорость
            dx = 0;
        }

        public void ApplyPhysics()
        {
            CalculatePhysics();
        }

        public void CalculatePhysics() //передвижение в стороны и реализация прыжка
        {
            if(dx != 0 )
            {
                transform.position.X += dx; //смещение
            }
            if(transform.position.Y < 700)
            {
                transform.position.Y += gravity;
                gravity += a;
                Collide();
            }
        }

        public void Collide() //пробегаемся по платформам
        {
            for(int i = 0; i < PlatformController.platforms.Count; i++)
            {
                var platform = PlatformController.platforms[i];
                if(transform.position.X + transform.size.Width/2 >= platform.transform.position.X && transform.position.X + transform.size.Width/2 <= platform.transform.position.X + platform.transform.size.Width) //если середина игрока находится по х в пределах платформы
                {
                    if(transform.position.Y + transform.size.Height >= platform.transform.position.Y && transform.position.Y + transform.size.Height <= platform.transform.position.Y + platform.transform.size.Height)
                    {
                        if(gravity > 0) //игрок подлетел на платформу
                        {
                            AddForce();
                            if(!platform.isTouchedByPLayer) // до этой платформы еще не касался
                            {
                                PlatformController.score += 20;
                                PlatformController.GenerateRandomPlatform();
                                platform.isTouchedByPLayer = true;
                            }
                        }
                    }
                }
            }
        }

        public void AddForce() //прыжок
        {
            gravity = -10;
        }
    }
}
