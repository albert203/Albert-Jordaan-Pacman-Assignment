using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pacman
{
    /*The controller class calls in all the other methods from the classes, 
     * such as pacman.Move(), and initializes them together in my Playgame() method. 
     * The controller class also calls in all the list of sprite entities (pacman and the four ghosts) 
     * and all its variations of bitmap images.
     */
    public class Controller
    {
        private List<Bitmap> pacsprites;
        private Pacman pacman;
        private Ghost ghost;
        private Maze maze;

        private List<Ghost> allghosts;
        private List<Bitmap> ghostgreensprites;
        private List<Bitmap> ghostorangesprites;
        private List<Bitmap> ghostpurplesprites;
        private List<Bitmap> ghostredsprites;

        private int points;
        private bool wingame;

        private const int GHOSTGREENX = 2;
        private const int GHOSTGREENY = 17;

        private const int GHOSTORANGEX = 16;
        private const int GHOSTORANGEY = 8;

        private const int GHOSTPURPLEX = 14;
        private const int GHOSTPURPLEY = 3;

        private const int GHOSTREDX = 7;
        private const int GHOSTREDY = 11;

        public Controller(Maze maze)
        {
            //Adding a list called pacsprites; of all the pacman sprites 
            //according to key press events that cause the image to look like they are changing direction.
            pacsprites = new List<Bitmap>();

            pacsprites.Add(Properties.Resources.pacman1right);
            pacsprites.Add(Properties.Resources.pacman2right);
            pacsprites.Add(Properties.Resources.pacman1left);
            pacsprites.Add(Properties.Resources.pacman2left);
            pacsprites.Add(Properties.Resources.pacman1up);
            pacsprites.Add(Properties.Resources.pacman2up);
            pacsprites.Add(Properties.Resources.pacman1down);
            pacsprites.Add(Properties.Resources.pacman2down);

            //adding the pacman to the form
            pacman = new Pacman(pacsprites, maze, new Point(10, 11));

            //adding the ghost list and its different variation images of each ghosts direction
            ghostgreensprites = new List<Bitmap>();
            ghostgreensprites.Add(Properties.Resources.green1__2_);
            ghostgreensprites.Add(Properties.Resources.green2__2_);

            ghostorangesprites = new List<Bitmap>();
            ghostorangesprites.Add(Properties.Resources.orange1);
            ghostorangesprites.Add(Properties.Resources.orange2);

            ghostpurplesprites = new List<Bitmap>();
            ghostpurplesprites.Add(Properties.Resources.purple1__2_);
            ghostpurplesprites.Add(Properties.Resources.purple2__2_);

            ghostredsprites = new List<Bitmap>();
            ghostredsprites.Add(Properties.Resources.red1__2_);
            ghostredsprites.Add(Properties.Resources.red2__2_);

            //new list of all fourghosts
            allghosts = new List<Ghost>();

            //adding each ghost to the form.
            allghosts.Add(new Ghost(ghostgreensprites, maze, new Point(GHOSTGREENX, GHOSTGREENY)));
            allghosts.Add(new Ghost(ghostorangesprites, maze, new Point(GHOSTORANGEX, GHOSTORANGEY)));
            allghosts.Add(new Ghost(ghostpurplesprites, maze, new Point(GHOSTPURPLEX, GHOSTPURPLEY)));
            allghosts.Add(new Ghost(ghostredsprites, maze, new Point(GHOSTREDX, GHOSTREDY)));

            //reseting score when new game occurs - starting at 0
            points = 0;
        }

        //when a new direction input has been detected it changes direction according to the latest keypress event.
        public void Changepacmandirection(Enumdir direction)
        {
            pacman.Direction = direction;
        }

        //Moves each ghost sprite out of the four sprites according to my move method
        public void GhostsMove()
        {
            //The purpose of the MoveGhosts method is to loop through all the ghosts and call their move method.
            foreach (Ghost ghost in allghosts)
            {
                ghost.Move();
            }
        }

        //draws each of the four ghosts and adjust the image variation to what it should be
        public void GhostsDraw()
        {
            //The purpose of the Draw ghosts method is to loop through the ghosts calling their animate and then draw methods.
            foreach (Ghost ghost in allghosts)
            {
                ghost.animateddirection();
                ghost.Draw();
            }
        }


        //calls in the important methods of drawing the pacman and ghosts sprites 
        //along with its movement scripts
        public void PlayGame()
        {
            pacman.animateddirection();
            pacman.Draw();
            pacman.Move();

            //calls in the foreach methods to draw and provide movement for the ghosts
            GhostsMove();
            GhostsDraw();

            //each time pacman eats a pellet it increases his score by 1;
            if (pacman.Eatpellets())
            {
                points++;
                if (points == 10)
                {
                    points += 1;
                }
                if (points == 25)
                {
                    points += 5;
                }
            }

            //if (maze.NKibbles == points)
            //{
            //    wingame = true;
            //}
        }
        public int Points { get => points; set => points = value; }
        public bool WinGame { get => wingame; set => wingame = value; }
    }
}
