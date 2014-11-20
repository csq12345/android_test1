namespace SeePoint
{
    partial class FormViewPlane
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormViewPlane));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除区域ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建区域ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建区域ToolStripMenuItem,
            this.删除区域ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // 删除区域ToolStripMenuItem
            // 
            this.删除区域ToolStripMenuItem.CheckOnClick = true;
            this.删除区域ToolStripMenuItem.Name = "删除区域ToolStripMenuItem";
            this.删除区域ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除区域ToolStripMenuItem.Text = "删除区域";
            this.删除区域ToolStripMenuItem.Click += new System.EventHandler(this.删除区域ToolStripMenuItem_Click);
            // 
            // 新建区域ToolStripMenuItem
            // 
            this.新建区域ToolStripMenuItem.CheckOnClick = true;
            this.新建区域ToolStripMenuItem.Name = "新建区域ToolStripMenuItem";
            this.新建区域ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.新建区域ToolStripMenuItem.Text = "新建区域";
            this.新建区域ToolStripMenuItem.Click += new System.EventHandler(this.新建区域ToolStripMenuItem_Click);
            // 
            // FormViewPlane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 166);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(150, 150);
            this.Name = "FormViewPlane";
            this.Text = "平面";
            this.Load += new System.EventHandler(this.FormViewPlane_Load);
            this.SizeChanged += new System.EventHandler(this.FormViewPlane_SizeChanged);
            this.Resize += new System.EventHandler(this.FormViewPlane_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除区域ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 新建区域ToolStripMenuItem;


    }
}