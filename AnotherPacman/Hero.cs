﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AnotherPacman
{
    class Hero : PictureBox
    {
        public int Step {get; set; } = 3;
        public int HorizontalVelocity { get; set; } = 0;
        public int VerticalVelocity { get; set; } = 0;

        public string Direction { get; set; } = "right";

        private Timer animationTimer = null;
        private int frameCounter = 1;


        private Timer pacmanMeltTimer = null;

        public Hero()
        {
            InitializeHero();
            InitializeAnimationTimer();
        }

        private void InitializeAnimationTimer()
        {
            animationTimer = new Timer();
            animationTimer.Interval = 200;
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (this.Top == -10)
            {
                this.Dispose();
            }
            else
            {
                Animate();
            }

        }
        public void Melt()
        {
            animationTimer.Stop();
            frameCounter = 1;
            InitializePacmanMeltTimer();
        }
        public void InitializePacmanMeltTimer()
        {
            pacmanMeltTimer = new Timer();
            pacmanMeltTimer.Tick += PacmanMeltTimer_Tick;
            pacmanMeltTimer.Interval = 100;
            pacmanMeltTimer.Start();
        }
        public void PacmanMeltTimer_Tick(object sender, EventArgs e)
        {
            MeltAnimate();
        }

        public void MeltAnimate()
        {
            string imageName = "pacman_melt" + "_" + frameCounter.ToString();
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            frameCounter++;
            if (frameCounter > 14)
            {
                pacmanMeltTimer.Stop();
            }
        }
        private void PacmanTimer_Tick(object sender, EventArgs e)
        {
            MeltAnimate();
        }

        private void Animate()
        {
            string imageName = "pacman_" + this.Direction + "_" + frameCounter.ToString();
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            frameCounter++;
            if (frameCounter > 4)
            {
                frameCounter = 1;
            }
        }

        private void InitializeHero()
        {
            this.BackColor = Color.Transparent;
            this.Size = new Size(30, 30);
            this.Location = new Point(200, 200);
            this.Name = "Pacman";
        }
    }
}
