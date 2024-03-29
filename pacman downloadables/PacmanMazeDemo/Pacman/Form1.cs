﻿/* C# Programming Assignment: Pacman
 * Due: the 15th of November 2019 (15/11/2019)
 * Completed by: Albert Jordaan
 * 
 * Software used to complete code: Microsoft Visual Studio 2019 Software, Github, Gitlab.
 * 
 * Aim of the Game:
 * Control Pacman (a circular sprite entity) using the arrow keys on computer keyboard 
 * moving Pacman safely through a maze full of pellets. 
 * The aim is to make Pacman eats all of the pellets and avoid the four maze wandering ghosts.
 * The ghosts are trying to catch Pacman, when one of them touches Pac-Man, a life is lost.
 * When all Pacman’s lives have been lost the game ends.
 * 
 * Deviations: Due to GiLab being unable to push to the server (because of server space issues) 
 * I have pushed up to GitHub instead of Gitlab and have done my commits also on github. 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Pacman
{
     /* This class is where I will display the game playing interface 
     * that contains the Pacman, ghosts, maze (that Pacman must traverse throughout), 
     * and displayed score. Within this class contains user interactables 
     * objects, images, and functionality 
     */ 

    public partial class Form1 : Form
    {
        //fields

        //constants
        private const int FORMHEIGHT = 640;
        private const int FORMWIDTH = 540;

        private Maze maze;
        private Controller controller;

        public Form1()
        {
            //when the start button is pressed it will intialise the form with its maze components and a timer set to an interval of 150;
            InitializeComponent();
            MessageBox.Show("You are Pacman, A yellow hungry circle.\nYou must manevouer throughout the maze avoiding the ghosts and eat all the kibble to win! Click on play game to play,\n and quit game to exit the application");
            // set the Properties of the form:
            Top = 0;
            Left = 0;
            Height = FORMHEIGHT;
            Width = FORMWIDTH;
            
            // create a Bitmap object for each image you want to display
            Bitmap k = Properties.Resources.kibble;
            Bitmap w = Properties.Resources.brickwall;
            Bitmap b = Properties.Resources.blank;

            // create an instance of a Maze:
            maze = new Maze(k, w, b);

            // important, need to add the maze object to the list of controls on the form
            Controls.Add(maze);
            controller = new Controller(maze);

            // remember the Timer Enabled Property is set to false as a default
            timer1.Interval = 50;
            timer1.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            /*clicking on "play game" in the menu, this hides the menu panel 
            and resets the game with a small delay to load into the new game. 
            Also brings in a 3,2,1 start timer before the game starts*/
            panel1.Visible = false;
            Thread.Sleep(1000);
        }

        //clicking on quit button in the menu exits application
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //each timer interval tick of the timer it will call these methods that draw the maze and the sprites movement and functionality. Also calls in the points 
        //accumulated to a label; showing off the score.
        private void timer1_Tick(object sender, EventArgs e)
        {
            maze.Draw();
            controller.PlayGame();

            label9.Text = controller.Points.ToString();
            if (controller.WinGame)
            {
                timer1.Enabled = false;
                MessageBox.Show("Well done you won! with a score of" + label9.Text);
                Application.Exit();
            }
        }

        //player inputs an arrow key then it detects which pacman animation it must use when producing that movement
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                controller.Changepacmandirection(Enumdir.Left);
            }
            if (e.KeyCode == Keys.Right)
            {
                controller.Changepacmandirection(Enumdir.Right);
            }
            if (e.KeyCode == Keys.Up)
            {
                controller.Changepacmandirection(Enumdir.Up);
            }
            if (e.KeyCode == Keys.Down)
            {
                controller.Changepacmandirection(Enumdir.Down);
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        //Click on the pause game button to pause the 
        private void button1_Click(object sender, EventArgs e)
        {
            if (!controller.WinGame)
            {
                timer1.Enabled = !timer1.Enabled;
            }
        }
    }
}
