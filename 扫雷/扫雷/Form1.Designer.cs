namespace WindowsFormsApp2
{
    partial class 主窗体
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.新游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.游戏设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.炸弹数目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.排行榜ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地图大小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.Location = new System.Drawing.Point(13, 32);
            this.pnlBoard.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(1323, 917);
            this.pnlBoard.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新游戏ToolStripMenuItem,
            this.游戏设置ToolStripMenuItem,
            this.排行榜ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(516, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            //this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 新游戏ToolStripMenuItem
            // 
            this.新游戏ToolStripMenuItem.Name = "新游戏ToolStripMenuItem";
            this.新游戏ToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.新游戏ToolStripMenuItem.Text = "新游戏";
            this.新游戏ToolStripMenuItem.Click += new System.EventHandler(this.新游戏ToolStripMenuItem_Click);
            // 
            // 游戏设置ToolStripMenuItem
            // 
            this.游戏设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.炸弹数目ToolStripMenuItem,
            this.地图大小ToolStripMenuItem});
            this.游戏设置ToolStripMenuItem.Name = "游戏设置ToolStripMenuItem";
            this.游戏设置ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.游戏设置ToolStripMenuItem.Text = "游戏设置";
            // 
            // 炸弹数目ToolStripMenuItem
            // 
            this.炸弹数目ToolStripMenuItem.Name = "炸弹数目ToolStripMenuItem";
            this.炸弹数目ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.炸弹数目ToolStripMenuItem.Text = "炸弹数目";
            this.炸弹数目ToolStripMenuItem.Click += new System.EventHandler(this.炸弹数目ToolStripMenuItem_Click);
            // 
            // 排行榜ToolStripMenuItem
            // 
            this.排行榜ToolStripMenuItem.Name = "排行榜ToolStripMenuItem";
            this.排行榜ToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.排行榜ToolStripMenuItem.Text = "排行榜";
            this.排行榜ToolStripMenuItem.Click += new System.EventHandler(this.排行榜ToolStripMenuItem_Click);
            // 
            // 地图大小ToolStripMenuItem
            // 
            this.地图大小ToolStripMenuItem.Name = "地图大小ToolStripMenuItem";
            this.地图大小ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.地图大小ToolStripMenuItem.Text = "地图大小";
            this.地图大小ToolStripMenuItem.Click += new System.EventHandler(this.地图大小ToolStripMenuItem_Click);
            // 
            // 主窗体
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 483);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pnlBoard);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "主窗体";
            this.Text = "扫雷";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 游戏设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 炸弹数目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 排行榜ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地图大小ToolStripMenuItem;
    }
}

