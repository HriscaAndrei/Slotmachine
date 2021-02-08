using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slotmachine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // declarareacreditelor, totalului si betului
        public static long credits = 100;
        public static long total = 0;
        public static int bet = 1;

        // declararea fiecarui item
        public static int p1;
        public static int p2;
        public static int p3;
        public static int p4;

        private void Form1_Load_1(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("2.png");
            pictureBox2.Image = Image.FromFile("3.png");
            pictureBox3.Image = Image.FromFile("1.png");
            pictureBox4.Image = Image.FromFile("4.png");

        }

        // generea numere random
        public static class IntUtil
        {
            private static Random random;

            private static void Init()
            {
                if (random == null) random = new Random();
            }
            public static int Random(int min, int max)
            {
                Init();
                return random.Next(min, max);
            }
        } 
        private void button1_Click_1(object sender, EventArgs e)
        {
                if (credits >= bet)
                {
                    credits = credits - bet;
                    label2.Text = "Credits: " + credits.ToString();

                    for (var i = 0; i < 10; i++)
                    {
                        p1 = IntUtil.Random(1, 4);
                        p2 = IntUtil.Random(1, 4);
                        p3 = IntUtil.Random(1, 4);
                        p4 = IntUtil.Random(1, 4);
                    }

                    if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                    pictureBox1.Image = Image.FromFile(p1.ToString() + ".png");

                    if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
                    pictureBox2.Image = Image.FromFile(p2.ToString() + ".png");

                    if (pictureBox3.Image != null) pictureBox3.Image.Dispose();
                    pictureBox3.Image = Image.FromFile(p3.ToString() + ".png");

                    if (pictureBox4.Image != null) pictureBox4.Image.Dispose();
                    pictureBox4.Image = Image.FromFile(p4.ToString() + ".png");

                    total = 0;

                    // verifica daca 1, 2, 3 sau 4 coincid

                    if (p1 == 1 & p2 == 1 & p3 == 1 & p4 == 1) total = total + 50;
                    if (p1 == 2 & p2 == 2 & p3 == 2 & p4 == 2) total = total + 20;
                    if (p1 == 3 & p2 == 3 & p3 == 3 & p4 == 3) total = total + 100;
                    if (p1 == 4 & p2 == 4 & p3 == 4 & p4 == 4) total = total + 10;

                    credits = credits + total;
                    label1.Text = "Win: " + total.ToString();
                    label2.Text = "Credits: " + credits.ToString();
                }
            }
        }
    }
