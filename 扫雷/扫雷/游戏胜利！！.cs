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

namespace WindowsFormsApp2
{
    public partial class 游戏胜利__ : Form
    {
        int length;
        int bombNumber;
        int useTime;
        public 游戏胜利__(int l,int b,int u)
        {
            length = l;
            bombNumber = b;
            useTime = u;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string names = textBox1.Text;
            if(names.Length==0)
            {
                MessageBox.Show("留下你的尊姓大名吧！！");
                return;
            }
            FileStream fp2 = new FileStream("Achievements.txt", FileMode.Append);
            StreamWriter fp = new StreamWriter(fp2);
            fp.Write(names + " " + length + " " + bombNumber + " " + useTime + "\r\n");
            fp.Close();
            主窗体 fps = (主窗体)this.Owner;
            //this.Close();
            this.Hide();
            fps.RestartGame(bombNumber, length);
        }

        private void 游戏胜利___FormClosed(object sender, FormClosedEventArgs e)
        {
            try { this.Owner.Show(); }
            catch { }
        }

        private void 游戏胜利___Load(object sender, EventArgs e)
        {

        }
    }
}
