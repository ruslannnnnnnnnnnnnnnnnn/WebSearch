using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace WebSearch
{
    public partial class Form1 : Form
    {
        Task task;
        WebRobot webRobot;

        public Form1()
        {
            InitializeComponent();                   
        }

        private void PauseSecond_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                webRobot.SecondsPause =  int.Parse(PauseSecond.Value.ToString());
            } 
            catch
            {
                return;
            }
        }

        private void PauseBt_Click(object sender, EventArgs e)
        {
            if (webRobot.ValuePause = !webRobot.ValuePause)
            {
                PauseBt.Text = "продолжить";
            }
            else
                PauseBt.Text = "пауза";
        }

        private void Begin_Click(object sender, EventArgs e)
        {
            string host = HostBox.Text;
            if (host == null || host == "") host = @"ru.wikibooks.org";

            int num = 0;
            if (!int.TryParse(NumericBox.Text, out num)) num = 0;

            string path = @"D:\текст";
            if (PathBox.Text != null && PathBox.Text != "") path = PathBox.Text;

            webRobot = new WebRobot(host, 2, path, num);
            task = new Task(() => webRobot.BeginSite());
            task.Start();
            
            BeginBox.Visible = false;
            PauseBox.Visible = true;
        }
        
        private void SerialezeBt_Click(object sender, EventArgs e)
        {
            webRobot.ValuePause = true;

            PauseBt.Text = "продолжить";

            while (!webRobot.TruePause)
            {
                Thread.Sleep(100);
            }

            webRobot.Serialize();

            webRobot.ValuePause = false;
            webRobot.TruePause = false;

            PauseBt.Text = "пауза";
        }

        private void DeserialezeBt_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\текст";
                if (PathBox.Text != null && PathBox.Text != "") path = PathBox.Text;

                webRobot = new WebRobot(path, 2);
                task = new Task(() => webRobot.BeginSite());
                task.Start();

                BeginBox.Visible = false;
                PauseBox.Visible = true;
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
