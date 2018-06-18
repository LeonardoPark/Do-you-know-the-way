namespace CodingGame_KOI
{
    partial class frmGame
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
            this.gameScreen = new System.Windows.Forms.PictureBox();
            this.picCodeblocks = new System.Windows.Forms.PictureBox();
            this.pnSerialSetting = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenSerial = new System.Windows.Forms.Button();
            this.txtSerialPortName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gameScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCodeblocks)).BeginInit();
            this.pnSerialSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameScreen
            // 
            this.gameScreen.BackColor = System.Drawing.Color.White;
            this.gameScreen.Location = new System.Drawing.Point(208, 0);
            this.gameScreen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gameScreen.Name = "gameScreen";
            this.gameScreen.Size = new System.Drawing.Size(600, 600);
            this.gameScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gameScreen.TabIndex = 0;
            this.gameScreen.TabStop = false;
            this.gameScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.gameScreen_Paint);
            // 
            // picCodeblocks
            // 
            this.picCodeblocks.Image = global::CodingGame_KOI.Properties.Resources.codeblocks;
            this.picCodeblocks.Location = new System.Drawing.Point(25, 15);
            this.picCodeblocks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picCodeblocks.Name = "picCodeblocks";
            this.picCodeblocks.Size = new System.Drawing.Size(159, 95);
            this.picCodeblocks.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCodeblocks.TabIndex = 1;
            this.picCodeblocks.TabStop = false;
            // 
            // pnSerialSetting
            // 
            this.pnSerialSetting.Controls.Add(this.label1);
            this.pnSerialSetting.Controls.Add(this.btnOpenSerial);
            this.pnSerialSetting.Controls.Add(this.txtSerialPortName);
            this.pnSerialSetting.Location = new System.Drawing.Point(328, 241);
            this.pnSerialSetting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnSerialSetting.Name = "pnSerialSetting";
            this.pnSerialSetting.Size = new System.Drawing.Size(425, 230);
            this.pnSerialSetting.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(466, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter the serial port name that bluetooth connected";
            // 
            // btnOpenSerial
            // 
            this.btnOpenSerial.BackColor = System.Drawing.Color.White;
            this.btnOpenSerial.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenSerial.Location = new System.Drawing.Point(57, 122);
            this.btnOpenSerial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOpenSerial.Name = "btnOpenSerial";
            this.btnOpenSerial.Size = new System.Drawing.Size(301, 44);
            this.btnOpenSerial.TabIndex = 1;
            this.btnOpenSerial.Text = "Start Coding";
            this.btnOpenSerial.UseVisualStyleBackColor = false;
            this.btnOpenSerial.Click += new System.EventHandler(this.btnOpenSerial_Click);
            // 
            // txtSerialPortName
            // 
            this.txtSerialPortName.Location = new System.Drawing.Point(57, 88);
            this.txtSerialPortName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSerialPortName.Name = "txtSerialPortName";
            this.txtSerialPortName.Size = new System.Drawing.Size(301, 25);
            this.txtSerialPortName.TabIndex = 0;
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1011, 852);
            this.Controls.Add(this.pnSerialSetting);
            this.Controls.Add(this.picCodeblocks);
            this.Controls.Add(this.gameScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmGame";
            this.Text = "Coding Game";
            this.Load += new System.EventHandler(this.frmGame_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGame_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gameScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCodeblocks)).EndInit();
            this.pnSerialSetting.ResumeLayout(false);
            this.pnSerialSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox gameScreen;
        private System.Windows.Forms.PictureBox picCodeblocks;
        private System.Windows.Forms.Panel pnSerialSetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenSerial;
        private System.Windows.Forms.TextBox txtSerialPortName;
    }
}

