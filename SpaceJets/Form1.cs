using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace SpaceJets
{
    public partial class GameWindow : Form
    {
        WindowsMediaPlayer gameMedia;
        WindowsMediaPlayer shootgMedia;
        WindowsMediaPlayer boom;

        PictureBox[] EnemyMunition;
        int enemyMunitionSpeed;

        PictureBox[] stars;
        int backgroundspeed;
        int playerSpeed;

        PictureBox[] munitions;
        int munitionsSpeed;

        PictureBox[] enemies;
        int enemiesSpeed;

        Random rnd;

        int score;
        int level;
        int dificulty;
        bool pause;
        bool GameIsOver;

        public GameWindow()
        {
            InitializeComponent();
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            pause = false;
            GameIsOver = false;
            score = 0;
            level = 1;
            dificulty = 9;

            backgroundspeed = 4;
            playerSpeed = 4;
            enemiesSpeed = 4;
            munitionsSpeed = 20;
            enemyMunitionSpeed = 4;

            munitions = new PictureBox[3];

            //Load image
            Image munition = Image.FromFile(@"C:\Users\Jhony\source\repos\zdravko-jel.github.io\SpaceJets\asserts\munition.png");

            //Load enemies
            Image enemy1 = Image.FromFile(@"C:\Users\Jhony\source\repos\zdravko-jel.github.io\SpaceJets\asserts\E1.png");
            Image enemy2 = Image.FromFile(@"C:\Users\Jhony\source\repos\zdravko-jel.github.io\SpaceJets\asserts\E2.png");
            Image enemy3 = Image.FromFile(@"C:\Users\Jhony\source\repos\zdravko-jel.github.io\SpaceJets\asserts\E3.png");
            Image boss1 = Image.FromFile(@"C:\Users\Jhony\source\repos\zdravko-jel.github.io\SpaceJets\asserts\Boss1.png");
            Image boss2 = Image.FromFile(@"C:\Users\Jhony\source\repos\zdravko-jel.github.io\SpaceJets\asserts\Boss2.png");

            enemies = new PictureBox[10];

            //Initialize enemy PictureBoxes
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new PictureBox();
                enemies[i].Size = new Size(40, 40);
                enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                enemies[i].BorderStyle = BorderStyle.None;
                enemies[i].Visible = false;
                this.Controls.Add(enemies[i]);
                enemies[i].Location = new Point((i + 1) * 50, -50);
            }

            enemies[0].Image = boss1;
            enemies[1].Image = enemy2;
            enemies[2].Image = enemy3;
            enemies[3].Image = enemy3;
            enemies[4].Image = enemy1;
            enemies[5].Image = enemy3;
            enemies[6].Image = enemy2;
            enemies[7].Image = enemy3;
            enemies[8].Image = enemy2;
            enemies[9].Image = boss2;

            for (int i = 0; i < munitions.Length; i++)
            {
                munitions[i] = new PictureBox();
                munitions[i].Size = new Size(8, 8);
                munitions[i].Image = munition;
                munitions[i].SizeMode = PictureBoxSizeMode.Zoom;
                munitions[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(munitions[i]);
            }
            
            // create WMP
            gameMedia = new WindowsMediaPlayer();
            shootgMedia = new WindowsMediaPlayer();
            boom = new WindowsMediaPlayer();

            //Load songs
            gameMedia.URL = "C:\\Users\\Jhony\\source\\repos\\zdravko-jel.github.io\\SpaceJets\\songs\\GameSong.mp3";
            shootgMedia.URL = "C:\\Users\\Jhony\\source\\repos\\zdravko-jel.github.io\\SpaceJets\\songs\\shoot.mp3";
            boom.URL = "C:\\Users\\Jhony\\source\\repos\\zdravko-jel.github.io\\SpaceJets\\songs\\boom.mp3";

            //Setup Songs
            gameMedia.settings.setMode("loop", true);
            gameMedia.settings.volume = 5;
            shootgMedia.settings.volume = 1;
            boom.settings.volume = 6;

            stars = new PictureBox[10];
            rnd = new Random();

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(rnd.Next(20, 580), rnd.Next(-10, 400));

                if (i % 2 == 1)
                {
                    stars[i].Size = new Size(2, 2);
                    stars[i].BackColor = Color.Wheat;
                }
                else
                {
                    stars[i].Size = new Size(3, 3);
                    stars[i].BackColor = Color.DarkGray;
                }

                this.Controls.Add(stars[i]);
            }

            //Eneny Munition
            EnemyMunition = new PictureBox[10];

            for (int i = 0; i < EnemyMunition.Length; i++)
            {
                EnemyMunition[i] = new PictureBox();
                EnemyMunition[i].Size = new Size(2, 25);
                EnemyMunition[i].Visible = false;
                EnemyMunition[i].BackColor = Color.Yellow;
                int x = rnd.Next(0, 10);
                EnemyMunition[i].Location = new Point(enemies[x].Location.X, enemies[x].Location.Y - 20);
                this.Controls.Add(EnemyMunition[i]);
            }

            gameMedia.controls.play();
        }

        private void BackgroundMoveTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < stars.Length / 2; i++)
            {
                stars[i].Top += backgroundspeed;

                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }

            for (int i = stars.Length / 2; i < stars.Length; i++)
            {
                stars[i].Top += backgroundspeed - 2;

                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
        }

        private void LeftMoveTimer_Tick(object sender, EventArgs e)
        {
            if (player.Left > 10)
            {
                player.Left -= playerSpeed;
            }
        }

        private void RightMoveTimer_Tick(object sender, EventArgs e)
        {
            if (player.Right < 580)
            {
                player.Left += playerSpeed;
            }
        }

        private void UpMoveTimer_Tick(object sender, EventArgs e)
        {
            if (player.Top > 10)
            {
                player.Top -= playerSpeed;
            }
        }

        private void DownMoveTimer_Tick(object sender, EventArgs e)
        {
            if (player.Top < 400)
            {
                player.Top += playerSpeed;
            }
        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (!pause)
            {
                if (e.KeyCode == Keys.Right)
                {
                    RightMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Left)
                {
                    LeftMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Down)
                {
                    DownMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Up)
                {
                    UpMoveTimer.Start();
                }
            }
            
        }

        private void GameWindow_KeyUp(object sender, KeyEventArgs e)
        {
            RightMoveTimer.Stop();
            LeftMoveTimer.Stop();
            DownMoveTimer.Stop();
            UpMoveTimer.Stop();

            if (e.KeyCode == Keys.Space)
            {
                if (!GameIsOver)
                {
                    if (pause)
                    {
                        StartTimers();
                        name.Visible = false;
                        gameMedia.controls.play();
                        pause = false;
                    }
                    else
                    {
                        name.Location = new Point((this.Width/2) - 120, 150);
                        name.Text = "PAUSED";
                        name.Visible = true;
                        gameMedia.controls.pause();
                        StopTimers();
                        pause = true;
                    }
                }
            }
        }

        private void MunitionMoveTimer_Tick(object sender, EventArgs e)
        {
            shootgMedia.controls.play();

            for (int i = 0; i < munitions.Length; i++)
            {
                if (munitions[i].Top > 0)
                {
                    munitions[i].Visible = true;
                    munitions[i].Top -= munitionsSpeed;

                    Collision();
                }
                else
                {
                    munitions[i].Visible = false;
                    munitions[i].Location = new Point(player.Location.X + 20, player.Location.Y - (i * 30));
                }
            }
        }

        private void EnemyMoveTimer_Tick(object sender, EventArgs e)
        {
            MoveEnemy(enemies, enemiesSpeed);
        }

        private void MoveEnemy(PictureBox[] array, int speed)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Visible = true;
                array[i].Top += speed;

                if (array[i].Top > this.Height)
                {
                    array[i].Location = new Point((i + 1) * 50, -200);
                }
            }
        }

        private void Collision()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (munitions[0].Bounds.IntersectsWith(enemies[i].Bounds)
                    || munitions[1].Bounds.IntersectsWith(enemies[i].Bounds) || munitions[2].Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    boom.controls.play();

                    score += 1;
                    scorelbl.Text = (score < 10) ? "0" + score.ToString() : score.ToString();

                    if (score % 30 == 0)
                    {
                        level += 1;
                        levellbl.Text = (level < 10) ? "0" + level.ToString() : level.ToString();

                        if (enemiesSpeed <= 10 && enemyMunitionSpeed <= 10 && dificulty >= 0)
                        {
                            dificulty--;
                            enemiesSpeed++;
                            enemyMunitionSpeed++;
                        }

                        if (level == 10)
                        {
                            GameOver("Nicely done, sir!");
                        }
                    }

                    enemies[i].Location = new Point((i + 1) * 50, -100);
                }

                if (player.Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    boom.settings.volume = 30;
                    boom.controls.play();
                    player.Visible = false;
                    GameOver("");
                }
            }
        }

        private void GameOver(String str)
        {
            name.Text = str;
            name.Location = new Point(120, 120);
            name.Visible = true;
            ReplayBtn.Visible = true;
            ExitBtn.Visible = true;

            gameMedia.controls.stop();
            StopTimers();
        }

        //Stop Timers
        private void StopTimers()
        {
            BackgroundMoveTimer.Stop();
            EnemyMoveTimer.Stop();
            MunitionMoveTimer.Stop();
            EnemyMunitionTimer.Stop();
        }

        //Start Timers
        private void StartTimers()
        {
            BackgroundMoveTimer.Start();
            EnemyMoveTimer.Start();
            MunitionMoveTimer.Start();
            EnemyMunitionTimer.Start();
        }

        private void EnemyMunitionTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < (EnemyMunition.Length - dificulty); i++)
            {
                if (EnemyMunition[i].Top < this.Height)
                {
                    EnemyMunition[i].Visible = true;
                    EnemyMunition[i].Top += enemyMunitionSpeed;

                    CollisionWithEnemyMonition();
                }
                else
                {
                    EnemyMunition[i].Visible = false;
                    int x = rnd.Next(0,10);
                    EnemyMunition[i].Location = new Point(enemies[x].Location.X + 20, enemies[x].Location.Y + 30);
                }
            }
        }

        private void CollisionWithEnemyMonition()
        {
            for (int i = 0; i < EnemyMunition.Length; i++)
            {
                if (EnemyMunition[i].Bounds.IntersectsWith(player.Bounds))
                {
                    EnemyMunition[i].Visible = false;
                    boom.settings.volume = 30;
                    boom.controls.play();
                    player.Visible = false;
                    GameOver("It's Over");
                }
            }
        }

        private void ReplayBtn_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            GameWindow_Load(e, e);
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
