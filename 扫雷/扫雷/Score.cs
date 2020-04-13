using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Score
    {
        public string name;
        public int length;
        public int bombNumber;
        //构造函数
        public Score(string n,int l,int b)
        {
            this.name = n;
            this.length = l;
            this.bombNumber = b;
        }
    }
}
