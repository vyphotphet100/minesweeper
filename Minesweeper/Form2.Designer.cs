namespace Minesweeper
{
    partial class FormCustom
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.lbWidth = new System.Windows.Forms.Label();
            this.lbHeight = new System.Windows.Forms.Label();
            this.lbMines = new System.Windows.Forms.Label();
            this.txb = new System.Windows.Forms.TextBox();
            this.widthBar = new System.Windows.Forms.TrackBar();
            this.heightBar = new System.Windows.Forms.TrackBar();
            this.mineBar = new System.Windows.Forms.TrackBar();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.widthBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mineBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(42, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose custom board parameters:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(54, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Width: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(54, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Height:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(54, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Mines:";
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(57, 307);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(138, 307);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(75, 23);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // lbWidth
            // 
            this.lbWidth.AutoSize = true;
            this.lbWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWidth.ForeColor = System.Drawing.SystemColors.Control;
            this.lbWidth.Location = new System.Drawing.Point(424, 100);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(15, 15);
            this.lbWidth.TabIndex = 1;
            this.lbWidth.Text = "9";
            // 
            // lbHeight
            // 
            this.lbHeight.AutoSize = true;
            this.lbHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeight.ForeColor = System.Drawing.SystemColors.Control;
            this.lbHeight.Location = new System.Drawing.Point(424, 163);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new System.Drawing.Size(15, 15);
            this.lbHeight.TabIndex = 1;
            this.lbHeight.Text = "9";
            // 
            // lbMines
            // 
            this.lbMines.AutoSize = true;
            this.lbMines.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMines.ForeColor = System.Drawing.SystemColors.Control;
            this.lbMines.Location = new System.Drawing.Point(424, 232);
            this.lbMines.Name = "lbMines";
            this.lbMines.Size = new System.Drawing.Size(23, 15);
            this.lbMines.TabIndex = 1;
            this.lbMines.Text = "10";
            // 
            // txb
            // 
            this.txb.Location = new System.Drawing.Point(12, 365);
            this.txb.Name = "txb";
            this.txb.Size = new System.Drawing.Size(100, 20);
            this.txb.TabIndex = 4;
            // 
            // widthBar
            // 
            this.widthBar.LargeChange = 1;
            this.widthBar.Location = new System.Drawing.Point(57, 89);
            this.widthBar.Maximum = 30;
            this.widthBar.Minimum = 9;
            this.widthBar.Name = "widthBar";
            this.widthBar.Size = new System.Drawing.Size(355, 45);
            this.widthBar.TabIndex = 5;
            this.widthBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.widthBar.Value = 9;
            this.widthBar.ValueChanged += new System.EventHandler(this.widthBar_ValueChanged);
            // 
            // heightBar
            // 
            this.heightBar.LargeChange = 1;
            this.heightBar.Location = new System.Drawing.Point(57, 153);
            this.heightBar.Maximum = 24;
            this.heightBar.Minimum = 9;
            this.heightBar.Name = "heightBar";
            this.heightBar.Size = new System.Drawing.Size(355, 45);
            this.heightBar.TabIndex = 5;
            this.heightBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.heightBar.Value = 9;
            this.heightBar.ValueChanged += new System.EventHandler(this.heightBar_ValueChanged);
            // 
            // mineBar
            // 
            this.mineBar.LargeChange = 2;
            this.mineBar.Location = new System.Drawing.Point(57, 223);
            this.mineBar.Maximum = 64;
            this.mineBar.Minimum = 10;
            this.mineBar.Name = "mineBar";
            this.mineBar.Size = new System.Drawing.Size(355, 45);
            this.mineBar.SmallChange = 2;
            this.mineBar.TabIndex = 5;
            this.mineBar.TickFrequency = 9999;
            this.mineBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.mineBar.Value = 10;
            this.mineBar.ValueChanged += new System.EventHandler(this.mineBar_ValueChanged);
            // 
            // tmr
            // 
            this.tmr.Interval = 1;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // FormCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(526, 343);
            this.ControlBox = false;
            this.Controls.Add(this.mineBar);
            this.Controls.Add(this.heightBar);
            this.Controls.Add(this.widthBar);
            this.Controls.Add(this.txb);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbMines);
            this.Controls.Add(this.lbHeight);
            this.Controls.Add(this.lbWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCustom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.widthBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mineBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.Label lbMines;
        private System.Windows.Forms.TextBox txb;
        private System.Windows.Forms.TrackBar widthBar;
        private System.Windows.Forms.TrackBar heightBar;
        private System.Windows.Forms.TrackBar mineBar;
        private System.Windows.Forms.Timer tmr;
    }
}