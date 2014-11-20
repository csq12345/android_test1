namespace CWTrack
{
    partial class UserControl1
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxShow = new System.Windows.Forms.PictureBox();
            this.pictureBoxTrack1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTrack1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxShow
            // 
            this.pictureBoxShow.BackgroundImage = global::CWTrack.Resource1.back;
            this.pictureBoxShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxShow.Location = new System.Drawing.Point(6, 20);
            this.pictureBoxShow.Name = "pictureBoxShow";
            this.pictureBoxShow.Size = new System.Drawing.Size(317, 15);
            this.pictureBoxShow.TabIndex = 2;
            this.pictureBoxShow.TabStop = false;
            // 
            // pictureBoxTrack1
            // 
            this.pictureBoxTrack1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTrack1.BackgroundImage = global::CWTrack.Resource1.track1;
            this.pictureBoxTrack1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxTrack1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxTrack1.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTrack1.Name = "pictureBoxTrack1";
            this.pictureBoxTrack1.Size = new System.Drawing.Size(12, 20);
            this.pictureBoxTrack1.TabIndex = 1;
            this.pictureBoxTrack1.TabStop = false;
            this.pictureBoxTrack1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTrack1_MouseDown);
            this.pictureBoxTrack1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTrack1_MouseMove);
            this.pictureBoxTrack1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTrack1_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBoxTrack1);
            this.panel1.Controls.Add(this.pictureBoxShow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 40);
            this.panel1.TabIndex = 3;
            this.panel1.SizeChanged += new System.EventHandler(this.panel1_SizeChanged);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(326, 40);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.SizeChanged += new System.EventHandler(this.UserControl1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTrack1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxTrack1;
        private System.Windows.Forms.PictureBox pictureBoxShow;
        private System.Windows.Forms.Panel panel1;
    }
}
