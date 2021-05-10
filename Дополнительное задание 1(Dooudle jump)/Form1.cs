using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Дополнительное_задание_1_Dooudle_jump_.Classes;

namespace Дополнительное_задание_1_Dooudle_jump_
{
    public partial class DoudleJump : Form
    {
        Player player;
        Timer timer1;

        public DoudleJump()
        {
            InitializeComponent();
            Init();
            timer1 = new Timer();
            timer1.Interval = 15;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();
            this.KeyDown += new KeyEventHandler(OnKeyboardPressed);
            this.KeyUp += new KeyEventHandler(OnKeyboardUp);
            this.BackgroundImage = Properties.Resources.back;
            this.Height = 600;
            this.Width = 330;
            this.Paint += new PaintEventHandler(OnRepaint);
        }

        public void Init()
        {
            PlatformController.platforms = new System.Collections.Generic.List<Platform>();
            PlatformController.AddPlatform(new System.Drawing.PointF(100, 400));
            PlatformController.startPlatformPosY = 400;
            PlatformController.score = 0;
            PlatformController.GenerateStartSequence();
            player = new Player();
        }

        private void OnKeyboardUp(object sender, KeyEventArgs e)
        {
            player.physics.dx = 0; //остановка персонажа
        }

        private void OnKeyboardPressed(object sender, KeyEventArgs e ) //движение персонажа
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    player.physics.dx = 6;
                    break;
                case "Left":
                    player.physics.dx = -6;
                    break;
            }
        }

        private void Update(object sender, EventArgs e)
        {
            this.Text = "Doodle Jump: Score - " + PlatformController.score;

            if (player.physics.transform.position.Y >= PlatformController.platforms[0].transform.position.Y + 200) //условие поражение, начинаем заново
            {
                Init();
            }

            player.physics.ApplyPhysics();
            FollowPLayer();
            Invalidate(); //переделываем
        }

        public void FollowPLayer() //имитация камеры - движение игрока и платформ через цикл
        {
            int offset = 400 - (int)player.physics.transform.position.Y;
            player.physics.transform.position.Y += offset;
            for(int i = 0; i < PlatformController.platforms.Count; i++)
            {
                var platform = PlatformController.platforms[i];
                platform.transform.position.Y += offset;

            }
        }

        private void OnRepaint(object sender, PaintEventArgs e) //рисовка платформ, если они есть в списке
        {
            Graphics g = e.Graphics;
            if(PlatformController.platforms.Count > 0)
            {
                for (int i = 0; i < PlatformController.platforms.Count; i++)
                {
                    PlatformController.platforms[i].DrawSprite(g);
                }
            }
            player.DrawSprite(g);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
