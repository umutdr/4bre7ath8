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
            stopWatchElapsed = 0,
            secondsAl = 1,
            secondsTut = 1,
            secondsVer = 1,
            fontSize = 48,
            sizeChangeAl = 4,
            sizeChangeVer = 2,
            counter = 0;

        Font
            defFont;

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "4-7-8 Nefes Egzersizine\nBaşlamak İçin\nEnter Tuşuna Basınız";
            defFont = label1.Font;
            MessageBox.Show(defFont.Size+"");
        }

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
                label1.BackColor = Color.FromKnownColor(KnownColor.Control);
                secondsAl = 1;
                secondsTut = 1;
                secondsVer = 1;
                counter = 0;
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
            stopWatchElapsed = stopWatch.Elapsed.Seconds;
            if (stopWatchElapsed > 0 && stopWatchElapsed <= 4)
            {
                fontSize -= sizeChangeAl;
                label1.Text = "Nefes Al\n" + secondsAl++;
                label1.BackColor = Color.FromArgb(64, 0, 255,255);
            }
            else if (stopWatchElapsed > 4 && stopWatchElapsed <= 11)
            {
                label1.Text = "Nefes Tut\n" + secondsTut++;
                label1.BackColor = Color.FromArgb(96, 255, 128, 0);
            }
            else if (stopWatchElapsed > 11 && stopWatchElapsed <= 19)
            {
                fontSize += sizeChangeVer;
                label1.Text = "Nefes Ver\n" + secondsVer++;
                label1.BackColor = Color.FromArgb(64, 0, 255, 0);
            }
            else if (stopWatchElapsed > 19)
            {
                counter++;
                if (counter < 2)
                {
                    label1.Text = counter + ".\nTekrar\nTamam!";
                    stopWatch.Restart();
                    stopWatchElapsed = stopWatch.Elapsed.Seconds;
                }
                else
                {
                    stopWatch.Stop();
                    timer1.Stop();
                    label1.Text = counter + " Tekrar ile\nEgzersiz\nTamamlandı!";
                    counter = 0;
                }
                label1.BackColor = Color.FromKnownColor(KnownColor.Control);
                secondsAl = 1;
                secondsTut = 1;
                secondsVer = 1;
            }

            label1.Font = new Font(label1.Font.Name, fontSize);

        }
    }
}
