using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Дополнительное_задание_1_Dooudle_jump_.Classes
{
   public static class PlatformController //управление платформой без слздания экземпляра(удаление добавление)
    {
        public static List<Platform> platforms; //хранение платформ на карте(список)
        public static int startPlatformPosY = 400;
        public static int score = 0;

        public static void AddPlatform(PointF position) //создаем и добавляем платформу в лист
        {
            Platform platform = new Platform(position);
            platforms.Add(platform);
        }

        public static void GenerateStartSequence() //создание рандомного количества платформ на карте(10шт)
        {
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                int x = r.Next(0, 270); //рандомные координаты 
                int y = r.Next(30, 40);
                startPlatformPosY -= y; // платформы буду подниматься выше с каждым созданием
                PointF position = new PointF(x, startPlatformPosY);
                Platform platform = new Platform(position); //создаем с готовыми координатами платформу и добавляем в лист
                platforms.Add(platform);
            }
        }

        public static void GenerateRandomPlatform() //добавление платформ на форму
        {
            CLearPLatforms();
            Random r = new Random();
            int x = r.Next(0, 270);
            PointF posistion = new PointF(x, startPlatformPosY);
            Platform platform = new Platform(posistion);
            platforms.Add(platform);
        }

        public static void CLearPLatforms() // удаление платформ, если они находятся далеко от игрока
        {
            for(int i =0; i < platforms.Count; i++)
            {
                if(platforms[i].transform.position.Y >= 700)
                {
                    platforms.RemoveAt(i);
                }
            }
        }    
    }
}
