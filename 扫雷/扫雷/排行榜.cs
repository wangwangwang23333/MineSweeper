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
    public partial class 排行榜 : Form
    {
        Score[] persons;
        public 排行榜()
        {
            InitializeComponent();
        }

        private void 排行榜_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void 排行榜_Load(object sender, EventArgs e)
        {
            StreamReader fp = new StreamReader("Achievements.txt");
            char[] deli = { ',', ' ', '\t' };
            int count = 0;
            while (fp.Peek()>0)
            {
                //只显示前十名
                //if (count >= 10)
                //   return;
                //string lines = fp.ReadLine();
                //string[] unit = lines.Split(deli, StringSplitOptions.RemoveEmptyEntries);
                
                fp.ReadLine();
                count++;
            }
            fp.Close();

            persons = new Score[count];
            //重新加载
            fp = new StreamReader("Achievements.txt");
            int temp = 0;
            while (fp.Peek() > 0)
            {
                //只显示前十名
                //if (count >= 10)
                //   return;
                string lines = fp.ReadLine();
                string[] unit = lines.Split(deli, StringSplitOptions.RemoveEmptyEntries);
                persons[temp] = new Score(unit[0], int.Parse(unit[1]), int.Parse(unit[2]));
                temp++;
            }
            fp.Close();

            sort(count);

            //显示数据
            for(int i=0;i<count;i++)
            {
                listBox1.Items.Add(persons[i].name);
                listBox2.Items.Add(persons[i].length+"X"+persons[i].length);
                listBox3.Items.Add(persons[i].bombNumber);
            }

        }

        //排序
        public void sort(int length)
        {
            //冒泡排序
            for (int i = length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    //bombNumber/(length*length)反映了炸弹密度，即难度
                    //使用乘法，避免浮点数运算
                    if (persons[j].bombNumber*persons[i].length * persons[i].length < persons[i].bombNumber * persons[j].length * persons[j].length)
                    {
                        Score s = persons[i];
                        persons[i] = persons[j];
                        persons[j] = s;
                    }
                }
            }
        }

    }
}
