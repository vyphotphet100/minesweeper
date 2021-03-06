namespace Minesweeper
{
    partial class FormPlay2Player
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPlay2Player));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbMode = new System.Windows.Forms.Label();
            this.txb = new System.Windows.Forms.TextBox();
            this.btn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbYourNumber = new System.Windows.Forms.Label();
            this.btnGiveUp = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbMine = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbMinute = new System.Windows.Forms.TextBox();
            this.txbFlag2 = new System.Windows.Forms.TextBox();
            this.txbFlag1 = new System.Windows.Forms.TextBox();
            this.txbSecond = new System.Windows.Forms.TextBox();
            this.tmr1 = new System.Windows.Forms.Timer(this.components);
            this.panelBorder = new System.Windows.Forms.Panel();
            this.btnPlay = new System.Windows.Forms.Button();
            this.txbHeightT = new System.Windows.Forms.TextBox();
            this.txbWidthT = new System.Windows.Forms.TextBox();
            this.txbMines = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txbFlag = new System.Windows.Forms.TextBox();
            this.txbYourNumber = new System.Windows.Forms.TextBox();
            this.txbIP = new System.Windows.Forms.TextBox();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(859, 623);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(102, 70);
            this.panel1.TabIndex = 0;
            this.panel1.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 31);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 26);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(31, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 26);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.BackgroundImage = global::Minesweeper.Properties.Resources.flag_yellow_2;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 26);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // lbMode
            // 
            this.lbMode.AutoSize = true;
            this.lbMode.BackColor = System.Drawing.Color.Transparent;
            this.lbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMode.ForeColor = System.Drawing.SystemColors.Control;
            this.lbMode.Location = new System.Drawing.Point(44, 32);
            this.lbMode.Name = "lbMode";
            this.lbMode.Size = new System.Drawing.Size(137, 15);
            this.lbMode.TabIndex = 1;
            this.lbMode.Text = "Mode:        2 players";
            // 
            // txb
            // 
            this.txb.Location = new System.Drawing.Point(859, 535);
            this.txb.Multiline = true;
            this.txb.Name = "txb";
            this.txb.Size = new System.Drawing.Size(144, 82);
            this.txb.TabIndex = 2;
            this.txb.Visible = false;
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(859, 698);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(75, 23);
            this.btn.TabIndex = 3;
            this.btn.Text = "button2";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Visible = false;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.lbYourNumber);
            this.panel2.Controls.Add(this.btnGiveUp);
            this.panel2.Controls.Add(this.btnHome);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lbMine);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lbMode);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txbMinute);
            this.panel2.Controls.Add(this.txbFlag2);
            this.panel2.Controls.Add(this.txbFlag1);
            this.panel2.Controls.Add(this.txbSecond);
            this.panel2.Location = new System.Drawing.Point(861, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(245, 288);
            this.panel2.TabIndex = 4;
            // 
            // lbYourNumber
            // 
            this.lbYourNumber.AutoSize = true;
            this.lbYourNumber.BackColor = System.Drawing.Color.Transparent;
            this.lbYourNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbYourNumber.ForeColor = System.Drawing.SystemColors.Control;
            this.lbYourNumber.Location = new System.Drawing.Point(66, 214);
            this.lbYourNumber.Name = "lbYourNumber";
            this.lbYourNumber.Size = new System.Drawing.Size(105, 15);
            this.lbYourNumber.TabIndex = 5;
            this.lbYourNumber.Text = "Your number: 1";
            // 
            // btnGiveUp
            // 
            this.btnGiveUp.Location = new System.Drawing.Point(34, 244);
            this.btnGiveUp.Name = "btnGiveUp";
            this.btnGiveUp.Size = new System.Drawing.Size(75, 23);
            this.btnGiveUp.TabIndex = 4;
            this.btnGiveUp.Text = "Give up";
            this.btnGiveUp.UseVisualStyleBackColor = true;
            this.btnGiveUp.Click += new System.EventHandler(this.btnGiveUp_Click);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(130, 244);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(75, 23);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(140, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = ":";
            // 
            // lbMine
            // 
            this.lbMine.AutoSize = true;
            this.lbMine.BackColor = System.Drawing.Color.Transparent;
            this.lbMine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMine.ForeColor = System.Drawing.SystemColors.Control;
            this.lbMine.Location = new System.Drawing.Point(132, 95);
            this.lbMine.Name = "lbMine";
            this.lbMine.Size = new System.Drawing.Size(23, 15);
            this.lbMine.TabIndex = 1;
            this.lbMine.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(49, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Flag 2:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(49, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Flag 1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(44, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mines:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(44, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time:";
            // 
            // txbMinute
            // 
            this.txbMinute.Location = new System.Drawing.Point(88, 59);
            this.txbMinute.Name = "txbMinute";
            this.txbMinute.ReadOnly = true;
            this.txbMinute.Size = new System.Drawing.Size(51, 20);
            this.txbMinute.TabIndex = 2;
            this.txbMinute.Text = "00";
            this.txbMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbFlag2
            // 
            this.txbFlag2.Location = new System.Drawing.Point(125, 184);
            this.txbFlag2.Name = "txbFlag2";
            this.txbFlag2.ReadOnly = true;
            this.txbFlag2.Size = new System.Drawing.Size(51, 20);
            this.txbFlag2.TabIndex = 0;
            this.txbFlag2.Text = "5";
            this.txbFlag2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbFlag1
            // 
            this.txbFlag1.Location = new System.Drawing.Point(125, 158);
            this.txbFlag1.Name = "txbFlag1";
            this.txbFlag1.ReadOnly = true;
            this.txbFlag1.Size = new System.Drawing.Size(51, 20);
            this.txbFlag1.TabIndex = 0;
            this.txbFlag1.Text = "5";
            this.txbFlag1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbSecond
            // 
            this.txbSecond.Location = new System.Drawing.Point(154, 59);
            this.txbSecond.Name = "txbSecond";
            this.txbSecond.ReadOnly = true;
            this.txbSecond.Size = new System.Drawing.Size(51, 20);
            this.txbSecond.TabIndex = 0;
            this.txbSecond.Text = "00";
            this.txbSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tmr1
            // 
            this.tmr1.Interval = 1000;
            this.tmr1.Tick += new System.EventHandler(this.tmr1_Tick);
            // 
            // panelBorder
            // 
            this.panelBorder.AutoScroll = true;
            this.panelBorder.BackColor = System.Drawing.Color.Transparent;
            this.panelBorder.Location = new System.Drawing.Point(12, 7);
            this.panelBorder.Name = "panelBorder";
            this.panelBorder.Size = new System.Drawing.Size(842, 715);
            this.panelBorder.TabIndex = 5;
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(859, 429);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 6;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Visible = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // txbHeightT
            // 
            this.txbHeightT.Location = new System.Drawing.Point(859, 458);
            this.txbHeightT.Name = "txbHeightT";
            this.txbHeightT.Size = new System.Drawing.Size(48, 20);
            this.txbHeightT.TabIndex = 7;
            this.txbHeightT.Text = "10";
            this.txbHeightT.Visible = false;
            // 
            // txbWidthT
            // 
            this.txbWidthT.Location = new System.Drawing.Point(913, 458);
            this.txbWidthT.Name = "txbWidthT";
            this.txbWidthT.Size = new System.Drawing.Size(48, 20);
            this.txbWidthT.TabIndex = 7;
            this.txbWidthT.Text = "15";
            this.txbWidthT.Visible = false;
            // 
            // txbMines
            // 
            this.txbMines.Location = new System.Drawing.Point(859, 484);
            this.txbMines.Name = "txbMines";
            this.txbMines.Size = new System.Drawing.Size(48, 20);
            this.txbMines.TabIndex = 7;
            this.txbMines.Text = "10";
            this.txbMines.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(940, 429);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txbFlag
            // 
            this.txbFlag.Location = new System.Drawing.Point(913, 484);
            this.txbFlag.Name = "txbFlag";
            this.txbFlag.Size = new System.Drawing.Size(48, 20);
            this.txbFlag.TabIndex = 7;
            this.txbFlag.Text = "5";
            this.txbFlag.Visible = false;
            // 
            // txbYourNumber
            // 
            this.txbYourNumber.Location = new System.Drawing.Point(967, 484);
            this.txbYourNumber.Name = "txbYourNumber";
            this.txbYourNumber.Size = new System.Drawing.Size(48, 20);
            this.txbYourNumber.TabIndex = 7;
            this.txbYourNumber.Text = "1";
            this.txbYourNumber.Visible = false;
            // 
            // txbIP
            // 
            this.txbIP.Location = new System.Drawing.Point(859, 509);
            this.txbIP.Name = "txbIP";
            this.txbIP.Size = new System.Drawing.Size(144, 20);
            this.txbIP.TabIndex = 7;
            this.txbIP.Text = "192.168.1.1";
            this.txbIP.Visible = false;
            // 
            // tmr
            // 
            this.tmr.Interval = 1;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // FormPlay2Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1105, 731);
            this.ControlBox = false;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txbWidthT);
            this.Controls.Add(this.txbYourNumber);
            this.Controls.Add(this.txbFlag);
            this.Controls.Add(this.txbMines);
            this.Controls.Add(this.txbIP);
            this.Controls.Add(this.txbHeightT);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.txb);
            this.Controls.Add(this.panelBorder);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPlay2Player";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbMode;
        private System.Windows.Forms.TextBox txb;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbMine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbMinute;
        private System.Windows.Forms.TextBox txbSecond;
        private System.Windows.Forms.Panel panelBorder;
        public System.Windows.Forms.Button btnPlay;
        public System.Windows.Forms.TextBox txbHeightT;
        public System.Windows.Forms.TextBox txbWidthT;
        public System.Windows.Forms.TextBox txbMines;
        public System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txbFlag1;
        public System.Windows.Forms.TextBox txbFlag2;
        public System.Windows.Forms.Label lbYourNumber;
        public System.Windows.Forms.TextBox txbFlag;
        public System.Windows.Forms.TextBox txbYourNumber;
        public System.Windows.Forms.TextBox txbIP;
        public System.Windows.Forms.Timer tmr1;
        public System.Windows.Forms.Button btnHome;
        public System.Windows.Forms.Button btnGiveUp;
        private System.Windows.Forms.Timer tmr;
    }
}