using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pacman
{
    public class Controller
    {
        private Pacman pacman;
        private Maze maze;
        private List<Bitmap> pacsprites;

        public Controller(Maze maze)
        {
            this.maze = maze;
            pacman = new Pacman(pacsprites, maze, new Point(5, 15));

            pacsprites = new List<Bitmap>();

            pacsprites.Add(Properties.Resources.pacman2right);
            pacsprites.Add(Properties.Resources.pacman1right);
            pacsprites.Add(Properties.Resources.pacman2left);
            pacsprites.Add(Properties.Resources.pacman1left);
            pacsprites.Add(Properties.Resources.pacman2up);
            pacsprites.Add(Properties.Resources.pacman1up);
            pacsprites.Add(Properties.Resources.pacman2down);
            pacsprites.Add(Properties.Resources.pacman1down);
        }

        public void Changepacmandirection(Enumdir direction)
        {
            pacman.Direction = direction;
        }
        

        public void PlayGame()
        {
            pacman.animateddirection();
            pacman.Draw();
            pacman.Move();
            if (pacman.Eatpellets())
            {
                
            }

        }
    }
}
