using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _4bre7ath8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Stopwatch stopWatch = new Stopwatch();
        int
            swElapsed = 0,
            secondsAl = 1,
            secondsTut = 1,
            secondsVer = 1,
            fontSize = 48,
            sizeChangeAl = 4,
            sizeChangeVer = 2,
            counter = 0;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak İstiyor musunuz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                label1.Font = new Font(label1.Font.Name, 48);
                fontSize = Convert.ToInt32(label1.Font.Size);
                label1.Text = "HAZIR OL!";
                timer1.Start();
                stopWatch.Restart();
            }
            else if (e.KeyChar == (char)Keys.Space)
            {
                MessageBox.Show("Space");
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            swElapsed = stopWatch.Elapsed.Seconds;
            if (swElapsed > 0 && swElapsed <= 4)
            {
                fontSize -= sizeChangeAl;
                label1.Font = new Font(label1.Font.Name, fontSize);
                label1.Text = "Nefes Al\n" + secondsAl++;
            }
            else if (swElapsed > 4 && swElapsed <= 11)
            {
                label1.Text = "Nefes Tut\n" + secondsTut++;
            }
            else if (swElapsed > 11 && swElapsed <= 19)
            {
                fontSize += sizeChangeVer;
                label1.Font = new Font(label1.Font.Name, fontSize);
                label1.Text = "Nefes Ver\n" + secondsVer++;
            }
            else if (swElapsed > 19)
            {
                counter++;
                if (counter < 2)
                {
                    label1.Text = counter + ". Tekrar Tamam!";
                    stopWatch.Restart();
                    swElapsed = stopWatch.Elapsed.Seconds;
                }
                else
                {
                    stopWatch.Stop();
                    timer1.Stop();
                    label1.Text = counter + " Tekrar Tamamlandı!";
                    counter = 0;
                }
                secondsAl = 1;
                secondsTut = 1;
                secondsVer = 1;
            }
        }
    }
}
