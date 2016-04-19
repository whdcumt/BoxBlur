namespace Pencil
{
    unsafe partial class FrmTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTest));
            this.CmdOpen = new System.Windows.Forms.Button();
            this.CmdSave = new System.Windows.Forms.Button();
            this.PicSrc = new System.Windows.Forms.PictureBox();
            this.CmdPureC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.KerSize = new System.Windows.Forms.HScrollBar();
            this.LblKerSize = new System.Windows.Forms.Label();
            this.LblInfo = new System.Windows.Forms.Label();
            this.CmdSSE = new System.Windows.Forms.Button();
            this.PicDest = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicSrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicDest)).BeginInit();
            this.SuspendLayout();
            // 
            // CmdOpen
            // 
            this.CmdOpen.Location = new System.Drawing.Point(4, 6);
            this.CmdOpen.Name = "CmdOpen";
            this.CmdOpen.Size = new System.Drawing.Size(75, 29);
            this.CmdOpen.TabIndex = 21;
            this.CmdOpen.Text = "打开图像";
            this.CmdOpen.UseVisualStyleBackColor = true;
            this.CmdOpen.Click += new System.EventHandler(this.CmdOpen_Click);
            // 
            // CmdSave
            // 
            this.CmdSave.Location = new System.Drawing.Point(85, 6);
            this.CmdSave.Name = "CmdSave";
            this.CmdSave.Size = new System.Drawing.Size(75, 29);
            this.CmdSave.TabIndex = 35;
            this.CmdSave.Text = "保存图像";
            this.CmdSave.UseVisualStyleBackColor = true;
            this.CmdSave.Click += new System.EventHandler(this.CmdSave_Click);
            // 
            // PicSrc
            // 
            this.PicSrc.Image = ((System.Drawing.Image)(resources.GetObject("PicSrc.Image")));
            this.PicSrc.Location = new System.Drawing.Point(12, 50);
            this.PicSrc.Name = "PicSrc";
            this.PicSrc.Size = new System.Drawing.Size(661, 688);
            this.PicSrc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicSrc.TabIndex = 33;
            this.PicSrc.TabStop = false;
            // 
            // CmdPureC
            // 
            this.CmdPureC.Location = new System.Drawing.Point(166, 6);
            this.CmdPureC.Name = "CmdPureC";
            this.CmdPureC.Size = new System.Drawing.Size(75, 29);
            this.CmdPureC.TabIndex = 37;
            this.CmdPureC.Text = "纯C版本";
            this.CmdPureC.UseVisualStyleBackColor = true;
            this.CmdPureC.Click += new System.EventHandler(this.CmdPureC_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(342, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 38;
            this.label1.Text = "核大小";
            // 
            // KerSize
            // 
            this.KerSize.LargeChange = 1;
            this.KerSize.Location = new System.Drawing.Point(386, 14);
            this.KerSize.Maximum = 400;
            this.KerSize.Minimum = 1;
            this.KerSize.Name = "KerSize";
            this.KerSize.Size = new System.Drawing.Size(465, 16);
            this.KerSize.TabIndex = 39;
            this.KerSize.Value = 5;
            this.KerSize.Scroll += new System.Windows.Forms.ScrollEventHandler(this.KerSize_Scroll);
            // 
            // LblKerSize
            // 
            this.LblKerSize.AutoSize = true;
            this.LblKerSize.Location = new System.Drawing.Point(869, 18);
            this.LblKerSize.Name = "LblKerSize";
            this.LblKerSize.Size = new System.Drawing.Size(11, 12);
            this.LblKerSize.TabIndex = 40;
            this.LblKerSize.Text = "5";
            // 
            // LblInfo
            // 
            this.LblInfo.AutoSize = true;
            this.LblInfo.Location = new System.Drawing.Point(901, 18);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(95, 12);
            this.LblInfo.TabIndex = 301;
            this.LblInfo.Text = "迭代100次用时：";
            // 
            // CmdSSE
            // 
            this.CmdSSE.Location = new System.Drawing.Point(250, 6);
            this.CmdSSE.Name = "CmdSSE";
            this.CmdSSE.Size = new System.Drawing.Size(75, 29);
            this.CmdSSE.TabIndex = 302;
            this.CmdSSE.Text = "SSE版本";
            this.CmdSSE.UseVisualStyleBackColor = true;
            this.CmdSSE.Click += new System.EventHandler(this.CmdSSE_Click);
            // 
            // PicDest
            // 
            this.PicDest.Image = ((System.Drawing.Image)(resources.GetObject("PicDest.Image")));
            this.PicDest.Location = new System.Drawing.Point(688, 50);
            this.PicDest.Name = "PicDest";
            this.PicDest.Size = new System.Drawing.Size(661, 688);
            this.PicDest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicDest.TabIndex = 303;
            this.PicDest.TabStop = false;
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.PicDest);
            this.Controls.Add(this.CmdSSE);
            this.Controls.Add(this.LblInfo);
            this.Controls.Add(this.LblKerSize);
            this.Controls.Add(this.KerSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmdPureC);
            this.Controls.Add(this.CmdSave);
            this.Controls.Add(this.PicSrc);
            this.Controls.Add(this.CmdOpen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BoxFilter测试";
            this.Load += new System.EventHandler(this.FrmTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicSrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicDest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CmdOpen;
        private System.Windows.Forms.PictureBox PicSrc;
        private System.Windows.Forms.Button CmdSave;
        private System.Windows.Forms.Button CmdPureC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.HScrollBar KerSize;
        private System.Windows.Forms.Label LblKerSize;
        private System.Windows.Forms.Label LblInfo;
        private System.Windows.Forms.Button CmdSSE;
        private System.Windows.Forms.PictureBox PicDest;

    }
}

