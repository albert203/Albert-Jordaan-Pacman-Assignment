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
        private List<Bitmap> pacsprites;
        private Pacman pacman;
        private int points;
        

        public Controller(Maze maze)
        {
            
            
            //Adding a list called pacsprites; of all the pacman sprites 
            //according to key press events that cause the image to change.
            pacsprites = new List<Bitmap>();

            pacsprites.Add(Properties.Resources.pacman1right);
            pacsprites.Add(Properties.Resources.pacman2right);
            pacsprites.Add(Properties.Resources.pacman1left);
            pacsprites.Add(Properties.Resources.pacman2left);
            pacsprites.Add(Properties.Resources.pacman1up);
            pacsprites.Add(Properties.Resources.pacman2up);
            pacsprites.Add(Properties.Resources.pacman1down);
            pacsprites.Add(Properties.Resources.pacman2down);

            //adding the intial pacman 
            pacman = new Pacman(pacsprites, maze, new Point(10, 11));

            //reseting score when new game occurs - starting at 0
            points = 0;
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
                points++;
            }
        }
        public int Points { get => points; set => points = value; }
    }
}
