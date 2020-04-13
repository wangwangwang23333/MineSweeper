using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class 地图大小设置 : Form
    {
        public 地图大小设置()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number = int.Parse(numericUpDown1.Value.ToString());
            主窗体 fp = (主窗体)this.Owner;
            int bombNumber = fp.bombNumber;
            if (number*number <= bombNumber)
            {
                MessageBox.Show("地图过小，无法适应炸弹数量！");
                return;
            }
            //fp.Show();
            this.Hide();
            fp.RestartGame(bombNumber, number);
        }

        private void 地图大小设置_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { this.Owner.Show(); }
            catch { }
        }
    }
}
