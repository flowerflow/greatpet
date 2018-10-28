namespace WaveTable
{
    partial class WTMainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WTMainForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.变大ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.变小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.变大ToolStripMenuItem,
            this.变小ToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 82);
            // 
            // 变大ToolStripMenuItem
            // 
            this.变大ToolStripMenuItem.Name = "变大ToolStripMenuItem";
            this.变大ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.变大ToolStripMenuItem.Text = "变大";
            this.变大ToolStripMenuItem.Click += new System.EventHandler(this.变大ToolStripMenuItem_Click_1);
            // 
            // 变小ToolStripMenuItem
            // 
            this.变小ToolStripMenuItem.Name = "变小ToolStripMenuItem";
            this.变小ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.变小ToolStripMenuItem.Text = "变小";
            this.变小ToolStripMenuItem.Click += new System.EventHandler(this.变小ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(105, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // WTMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 315);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WTMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "GreatPet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WTMainForm_FormClosing);
            this.Load += new System.EventHandler(this.WTMainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WTMainForm_MouseDown);
            this.MouseEnter += new System.EventHandler(this.WTMainForm_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.WTMainForm_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WTMainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WTMainForm_MouseUp);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 变大ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 变小ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
    }
}

