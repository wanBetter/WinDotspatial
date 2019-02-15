namespace WinSpatialControl
{
    partial class UCMapControl
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ctr3DToolBar1 = new WinSpatialControl.UI.Ctr3DToolBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 512);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // ctr3DToolBar1
            // 
            this.ctr3DToolBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.ctr3DToolBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ctr3DToolBar1.Location = new System.Drawing.Point(0, 0);
            this.ctr3DToolBar1.Margin = new System.Windows.Forms.Padding(0);
            this.ctr3DToolBar1.MaximumSize = new System.Drawing.Size(392, 44);
            this.ctr3DToolBar1.MinimumSize = new System.Drawing.Size(392, 44);
            this.ctr3DToolBar1.Name = "ctr3DToolBar1";
            this.ctr3DToolBar1.Size = new System.Drawing.Size(392, 44);
            this.ctr3DToolBar1.TabIndex = 0;
            // 
            // UCMapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctr3DToolBar1);
            this.Name = "UCMapControl";
            this.Size = new System.Drawing.Size(798, 524);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UI.Ctr3DToolBar ctr3DToolBar1;
        private System.Windows.Forms.Label label1;
    }
}
