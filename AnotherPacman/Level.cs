using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AnotherPacman
{
    class Level : PictureBox
    {
        public Level()
        {
            InitializeLevel();
        }

        private void InitializeLevel()
        {
            this.BackColor = Color.SteelBlue;
            this.Size = new System.Drawing.Size(300, 300);
            this.Location = new Point(20, 20);
            this.Name = "Level";
        }
    }
}
