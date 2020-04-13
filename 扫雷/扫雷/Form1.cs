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
    public partial class 主窗体 : Form
    {
        //按钮组件
        Button[] btns;
        //记录每一个格子的数据(-1:地雷,-2:已被点击过
        private int[,] numbers;
        //地雷信息
        private bool[,] isBomb;
        //是否点击过
        private bool[,] isClicked;
        //是否被插旗
        private bool[,] isFlaged;
        //难度
        public int length;
        //地雷数量
        public int bombNumber;
        //插旗数量
        int flagNumber;
        //点击过的数量
        int clickNumber;
        //判断是否为第一次点击
        bool firstClick = true;
        int initialX;
        int initialY;
        //游戏花费的时间
        int startTime;
        int endTime;
        //炸弹图片路径
        public static string bombPath = "BombImage.png";
        //旗子图片路径
        public static string flagPath = "FlagImage.png";

        public 主窗体(int newBombNumber = 10, int newLength = 10)
        {
            //地雷数量
            bombNumber = newBombNumber;
            //新地图
            length = newLength;
            //加载组件
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //初始化数据
            numbers = new int[length, length];
            isBomb = new bool[length, length];
            isClicked = new bool[length, length];
            isFlaged = new bool[length, length];
            startTime = 0;
            endTime = 0;
            clickNumber = 0;
            this.Text = "扫雷(大小:" + length + ",雷数:" + bombNumber + ")";
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    numbers[i, j] = 0;
                    isBomb[i, j] = false;
                    isClicked[i, j] = false;
                    isFlaged[i, j] = false;
                }
            }
            //初始化按钮
            btns = new Button[length * length];
            //旗子数量
            flagNumber = 0;
            //显示按钮
            int x0 = 5, y0 = 5, w = 30, d = w + 5;

            for (int i = 0; i < btns.Length; i++)
            {
                Button btn = new Button();

                int r = i / length;  //行
                int c = i % length;  //列

                btn.Left = x0 + c * d;
                btn.Top = y0 + r * d;
                btn.Width = w;
                btn.Height = w;
                btn.Font = new Font("楷体", 14);

                btn.Visible = true;
                btns[i] = btn;
                this.pnlBoard.Controls.Add(btn);

                btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UpdateClick);

                btn.Name = i.ToString();
            }
        }


        protected void UpdateClick(object sender, MouseEventArgs e)
        {
            //获取按钮
            Button button = (Button)sender;

            //获取该位置数据
            int placeMouse = int.Parse(button.Name);

            //获取坐标
            int x = placeMouse / length;
            int y = placeMouse % length;

            if (e.Button == MouseButtons.Left)
            {
                //MessageBox.Show(button.Name+" ("+x+","+y+")");

                //等价于对button操作
                //判断是否为初次点击
                if (firstClick)
                {
                    initialX = x;
                    initialY = y;

                    //将该位置更改为有地雷再进行生成
                    isBomb[x, y] = true;

                    //随机生成地图
                    GenerateMap();

                    //这个位置不可能是地雷啊喂！
                    isBomb[x, y] = false;

                    //不再是初次点击
                    firstClick = false;
                }

                //处理当前点击的按钮的信息

                //按钮已被点击过
                if (isClicked[x, y])
                    return;//直接返回

                //点击了一次
                clickNumber++;

                //如果该位置是地雷
                if (isBomb[x, y])
                {
                    GameOver();//游戏结束
                    return;
                }

                //其他情况，特别对待

                //被点击过了
                isClicked[x, y] = true;

                //更改色调，以区分点击与未点击
                button.BackColor = Color.DarkGray;

                //显示地图
                if (numbers[x, y] != 0)
                    button.Text = numbers[x, y].ToString();

                spreadMap(x, y);

                //点击获胜
                if(clickNumber==length*length-bombNumber)
                {
                    GameWin();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                //点击过了，就直接跳过
                if (isClicked[x, y] == true)
                    return;

                if(isFlaged[x,y]==false)
                {
                    // 显示炸弹图
                    button.BackgroundImage = Image.FromFile(flagPath);

                    //标记
                    isFlaged[x, y] = true;

                    //插旗数量++
                    flagNumber++;
                }
                else
                {
                    //撤回标记
                    button.BackgroundImage = null;
                    isFlaged[x, y] = false;

                    flagNumber--;
                }

                //判断是否能通过插旗获得游戏胜利
                if (flagNumber==bombNumber)
                {
                    for (int i = 0; i < length; i++)
                    {
                        for (int j = 0; j < length; j++)
                        {
                            if (isFlaged[i, j] == false)
                                continue;
                            if (isBomb[i, j] == false)
                                return;//插旗错误，无法获得游戏胜利
                        }
                    }
                    //执行到这个语句表明找对了
                    GameWin();
                }
            }

        }

        //随机生成地图
        public void GenerateMap()
        {
            Random r = new Random();
            int x, y;
            //随机产生length个地雷
            for (int i = 0; i < bombNumber; i++)
            {
                do
                {
                    //随机坐标
                    x = r.Next(length);
                    y = r.Next(length);
                }
                while (isBomb[x, y] == true);
                //该位置更改为地雷
                isBomb[x, y] = true;

                //左上
                if (x != 0 && y != 0)
                    numbers[x - 1, y - 1]++;
                //正上方
                if (x != 0)
                    numbers[x - 1, y]++;
                //右上方
                if (x != 0 && y != length - 1)
                    numbers[x - 1, y + 1]++;
                //正左方
                if (y != 0)
                    numbers[x, y - 1]++;
                //正右方
                if (y != length - 1)
                    numbers[x, y + 1]++;
                //左下方
                if (x != length - 1 && y != 0)
                    numbers[x + 1, y - 1]++;
                //正下方
                if (x != length - 1)
                    numbers[x + 1, y]++;
                //右下方
                if (x != length - 1 && y != length - 1)
                    numbers[x + 1, y + 1]++;
            }

        }

        public void GameOver()
        {
            //显示地图全貌
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    //如果之前被插了旗子
                    if (isFlaged[i, j] == true)
                    {
                        isFlaged[i, j] = false;
                        btns[i * length + j].BackgroundImage = null;
                    }

                    if (isClicked[i, j] == true)
                        continue;

                    //更改色调，以区分点击与未点击
                    btns[i*length+j].BackColor = Color.DarkGray;

                    //全部设置为完成点击
                    isClicked[i, j] = true;

                    //如果是炸弹
                    if (isBomb[i, j])
                    {
                        btns[i * length + j].BackgroundImage = Image.FromFile(bombPath,true);
                        continue;
                    }

                    //显示地图
                    if (numbers[i, j] != 0)
                        btns[i * length + j].Text = numbers[i, j].ToString();
                }
            }

            MessageBox.Show("你输了！");

            RestartGame(bombNumber, length);
        }

        public void GameWin()
        {
            //显示地图全貌
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    //如果之前被插了旗子
                    if (isFlaged[i, j] == true)
                    {
                        isFlaged[i, j] = false;
                        btns[i * length + j].BackgroundImage = null;
                    }

                    if (isClicked[i, j] == true)
                        continue;

                    //更改色调，以区分点击与未点击
                    btns[i * length + j].BackColor = Color.DarkGray;

                    //全部设置为完成点击
                    isClicked[i, j] = true;

                    //如果是炸弹
                    if (isBomb[i, j])
                    {
                        btns[i * length + j].BackgroundImage = Image.FromFile(bombPath, true);
                        continue;
                    }

                    //显示地图
                    if (numbers[i, j] != 0)
                        btns[i * length + j].Text = numbers[i, j].ToString();
                }
            }

            游戏胜利__ fp = new 游戏胜利__(length, bombNumber, endTime - startTime);
            fp.Owner = this;
            this.Hide();
            fp.ShowDialog();

        }

        //以x,y为起点扩展地图
        public void spreadMap(int x,int y)
        {
            //判断该位置的八个方向
            //左上
            if (x != 0 && y != 0 && isBomb[x - 1, y - 1] == false && isClicked[x - 1, y - 1] == false)
            {
                //点击过了
                isClicked[x - 1, y - 1] = true;

                //更改色调，以区分点击与未点击
                btns[(x - 1) * length + y - 1].BackColor = Color.DarkGray;

                //点击次数
                clickNumber++;

                if (isFlaged[x-1, y-1] == true)
                {
                    isFlaged[x-1, y-1] = false;
                    btns[(x - 1) * length + y - 1].BackgroundImage = null;
                }

                if (numbers[x - 1, y - 1] != 0)
                    btns[(x - 1) * length + y - 1].Text = numbers[x - 1, y - 1].ToString();
                else
                {
                    //非零需要继续拓展
                    spreadMap(x - 1, y - 1);
                }
            }
            //正上
            if (x != 0 && isBomb[x - 1, y] == false && isClicked[x - 1, y ] == false)
            {
                //点击过了
                isClicked[x - 1, y] = true;

                //更改色调，以区分点击与未点击
                btns[(x - 1) * length + y].BackColor = Color.DarkGray;

                //点击次数
                clickNumber++;

                if (isFlaged[x - 1, y ] == true)
                {
                    isFlaged[x - 1, y - 1] = false;
                    btns[(x - 1) * length + y ].BackgroundImage = null;
                }

                if (numbers[x - 1, y] != 0)
                    btns[(x - 1) * length + y].Text = numbers[x - 1, y].ToString();
                else
                {
                    //非零需要继续拓展
                    spreadMap(x - 1, y);
                }
            }
            //右上
            if (x != 0 && y!=length-1&&isBomb[x - 1, y+1] == false && isClicked[x - 1, y + 1] == false)
            {
                //点击过了
                isClicked[x - 1, y + 1] = true;

                //更改色调，以区分点击与未点击
                btns[(x - 1) * length + y + 1].BackColor = Color.DarkGray;

                //点击次数
                clickNumber++;

                if (isFlaged[x - 1, y + 1] == true)
                {
                    isFlaged[x - 1, y + 1] = false;
                    btns[(x - 1) * length + y + 1].BackgroundImage = null;
                }

                if (numbers[x - 1, y + 1] != 0)
                    btns[(x - 1) * length + y + 1].Text = numbers[x - 1, y + 1].ToString();
                else
                {
                    //非零需要继续拓展
                    spreadMap(x - 1, y + 1);
                }
            }
            //正左方
            if (y != 0 && isBomb[x, y - 1] == false && isClicked[x , y - 1] == false)
            {
                //点击过了
                isClicked[x, y - 1] = true;

                //更改色调，以区分点击与未点击
                btns[x * length + y - 1].BackColor = Color.DarkGray;

                //点击次数
                clickNumber++;

                if (isFlaged[x , y - 1] == true)
                {
                    isFlaged[x , y - 1] = false;
                    btns[x * length + y - 1].BackgroundImage = null;
                }

                if (numbers[x, y - 1] != 0)
                    btns[x * length + y - 1].Text = numbers[x, y - 1].ToString();
                else
                {
                    //非零需要继续拓展
                    spreadMap(x, y - 1);
                }
            }
            //正右方
            if (y != length - 1 && isBomb[x, y + 1] == false && isClicked[x, y + 1] == false)
            {
                //点击过了
                isClicked[x, y + 1] = true;

                //更改色调，以区分点击与未点击
                btns[x * length + y + 1].BackColor = Color.DarkGray;

                //点击次数
                clickNumber++;

                if (isFlaged[x, y + 1] == true)
                {
                    isFlaged[x, y + 1] = false;
                    btns[x * length + y + 1].BackgroundImage = null;
                }

                if (numbers[x, y + 1] != 0)
                    btns[x * length + y + 1].Text = numbers[x, y + 1].ToString();
                else
                {
                    //非零需要继续拓展
                    spreadMap(x, y + 1);
                }
            }
            //左下方
            if (x != length - 1 && y != 0 && isBomb[x + 1, y - 1] == false && isClicked[x + 1, y - 1] == false)
            {
                //点击过了
                isClicked[x + 1, y - 1] = true;

                //更改色调，以区分点击与未点击
                btns[(x + 1) * length + y - 1].BackColor = Color.DarkGray;

                //点击次数
                clickNumber++;

                if (isFlaged[x + 1, y - 1] == true)
                {
                    isFlaged[x + 1, y - 1] = false;
                    btns[(x + 1) * length + y - 1].BackgroundImage = null;
                }

                if (numbers[x + 1, y - 1] != 0)
                    btns[(x + 1) * length + y - 1].Text = numbers[x + 1, y - 1].ToString();
                else
                {
                    //非零需要继续拓展
                    spreadMap(x + 1, y - 1);
                }
            }
            //正下方
            if (x != length - 1 && isBomb[x + 1, y] == false && isClicked[x + 1, y] == false)
            {
                //点击过了
                isClicked[x + 1, y] = true;

                //更改色调，以区分点击与未点击
                btns[(x + 1) * length + y].BackColor = Color.DarkGray;

                //点击次数
                clickNumber++;

                if (isFlaged[x + 1, y ] == true)
                {
                    isFlaged[x + 1, y ] = false;
                    btns[(x + 1) * length + y ].BackgroundImage = null;
                }

                if (numbers[x + 1, y] != 0)
                    btns[(x + 1) * length + y].Text = numbers[x + 1, y].ToString();
                else
                {
                    //非零需要继续拓展
                    spreadMap(x + 1, y);
                }
            }
            //右下方
            if (x != length - 1 && y != length - 1 && isBomb[x + 1, y + 1] == false && isClicked[x + 1, y + 1] == false)
            {
                //点击过了
                isClicked[x + 1, y + 1] = true;

                //更改色调，以区分点击与未点击
                btns[(x + 1) * length + y + 1].BackColor = Color.DarkGray;

                //点击次数
                clickNumber++;

                if (isFlaged[x + 1, y + 1] == true)
                {
                    isFlaged[x + 1, y + 1] = false;
                    btns[(x + 1) * length + y + 1].BackgroundImage = null;
                }

                if (numbers[x + 1, y + 1] != 0)
                    btns[(x + 1) * length + y + 1].Text = numbers[x + 1, y + 1].ToString();
                else
                {
                    //非零需要继续拓展
                    spreadMap(x + 1, y + 1);
                }
            }

            //返回
            return;
        }

        private void 新游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show()
            RestartGame(bombNumber, length);
        }

        public void RestartGame(int newBombNumber,int newLength)
        {
            this.Hide();   //先隐藏主窗体
            主窗体 form1 = new 主窗体(newBombNumber, newLength); //重新实例化此窗体
            form1.Height = 35 * newLength + 80;
            form1.Width = 35 * newLength + 60;
            form1.ShowDialog();//已模式窗体的方法重新打开

            this.Close();
        }

        private void 炸弹数目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //此时主窗体禁止修改
            this.Hide();
            炸弹数量设置 fp = new 炸弹数量设置();
            fp.Owner = this;
            fp.ShowDialog();
            
        }

        private void 排行榜ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            排行榜 fp = new 排行榜();
            this.Hide();
            fp.Owner = this;
            fp.ShowDialog();
        }

        private void 地图大小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //此时主窗体禁止修改
            this.Hide();
            地图大小设置 fp = new 地图大小设置();
            fp.Owner = this;
            fp.ShowDialog();
        }
    }
}
