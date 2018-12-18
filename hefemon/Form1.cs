using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hefemon
{
    public partial class Hefemon : Form
    {
        int timerTickForSeconds = -1;
        int currentPlayer = -1;
        Image currentPlayerDotColor;

        private void dotClicked(object sender, EventArgs e)
        { 
            PictureBox clickedOne = sender as PictureBox;
            putMark(clickedOne);
            changeCurrentPlayer();
        } 

        void defineWhoPlaysFirst()
        {
            Random random = new Random();
            currentPlayer = random.Next(2);
            
            if (currentPlayer == 0)
            {
                timerTickForSeconds = 13;
                arrow.Image = hefemon.Properties.Resources.arrow_left;
                currentPlayerDotColor = hefemon.Properties.Resources.red;

            } else {
                timerTickForSeconds = 12;
                arrow.Image = hefemon.Properties.Resources.arrow_right;
                currentPlayerDotColor = hefemon.Properties.Resources.blue;
            }

        }

        void changeCurrentPlayer()
        {
            if (currentPlayer == 0)
            {
                currentPlayer = 1;
                currentPlayerDotColor = hefemon.Properties.Resources.blue;
                arrow.Image = hefemon.Properties.Resources.arrow_right;
            }
            else
            {
                currentPlayer = 0;
                currentPlayerDotColor = hefemon.Properties.Resources.red;
                arrow.Image = hefemon.Properties.Resources.arrow_left;
            }

        }

        void clearGameTable()
        {
            PictureBox[] dots = { dot1, dot2, dot3, dot4, dot5, dot6, dot7,dot8,dot9, dot10,dot11,dot12, dot13, dot14, dot15, dot16, dot17, dot18, dot19,
                                    dot20, dot21, dot22, dot23, dot24, dot25, dot26, dot27, dot28, dot29, dot30, dot31, dot32, dot33, dot34, dot35, dot36, dot37, dot38, dot39, dot40, dot41, dot42};
            for (int i = 0; i < 42; i++)
            {
                dots[i].Image = hefemon.Properties.Resources.white;
                dots[i].Click += dotClicked;
            }

        }

        public void putMark(PictureBox clickedOne)
        {
            clickedOne.Image = currentPlayerDotColor;
        }

        void startGame()
        {
            clearGameTable();
            defineWhoPlaysFirst();
            defineWhoPlaysFirstTimer.Interval = 100;
            defineWhoPlaysFirstTimer.Start();
        }

        public Hefemon()
        {
            InitializeComponent();
            startGame();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Hefemon_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void yeniOyunBaşlatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startGame();
        }

        private void defineWhoPlaysFirstTimer_Tick(object sender, EventArgs e)
        {
            timerTickForSeconds--;

            if (timerTickForSeconds != 0)
            {
                if (timerTickForSeconds % 2 == 0) {
                    arrow.Image = hefemon.Properties.Resources.arrow_left;
                }
                else
                {
                    arrow.Image = hefemon.Properties.Resources.arrow_right;
                }
            }
            else
            {
                if (currentPlayer == 0)
                {
                    arrow.Image = hefemon.Properties.Resources.arrow_left;
                }
                else
                {
                    arrow.Image = hefemon.Properties.Resources.arrow_right;
                }
                defineWhoPlaysFirstTimer.Stop();
            }

           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
