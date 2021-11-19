namespace Minesweeper
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnEasy = new System.Windows.Forms.Button();
            this.btnMedium = new System.Windows.Forms.Button();
            this.btnExpert = new System.Windows.Forms.Button();
            this.btnCustom = new System.Windows.Forms.Button();
            this.ModePlay = new System.Windows.Forms.TabControl();
            this.Mode1 = new System.Windows.Forms.TabPage();
            this.txb = new System.Windows.Forms.TextBox();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.btn = new System.Windows.Forms.Button();
            this.dtScore = new System.Windows.Forms.DataGridView();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txbName = new System.Windows.Forms.TextBox();
            this.lbYourName = new System.Windows.Forms.Label();
            this.ModePlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtScore)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEasy
            // 
            this.btnEasy.BackColor = System.Drawing.Color.SlateBlue;
            this.btnEasy.BackgroundImage = global::Minesweeper.Properties.Resources.Easy9x9;
            this.btnEasy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEasy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEasy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEasy.Location = new System.Drawing.Point(12, 31);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(201, 198);
            this.btnEasy.TabIndex = 0;
            this.btnEasy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEasy.UseVisualStyleBackColor = false;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);
            // 
            // btnMedium
            // 
            this.btnMedium.BackgroundImage = global::Minesweeper.Properties.Resources.Medium16x16;
            this.btnMedium.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMedium.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedium.Location = new System.Drawing.Point(238, 32);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Size = new System.Drawing.Size(201, 198);
            this.btnMedium.TabIndex = 0;
            this.btnMedium.UseVisualStyleBackColor = true;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);
            // 
            // btnExpert
            // 
            this.btnExpert.BackgroundImage = global::Minesweeper.Properties.Resources.Expert30x16;
            this.btnExpert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExpert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpert.Location = new System.Drawing.Point(12, 246);
            this.btnExpert.Name = "btnExpert";
            this.btnExpert.Size = new System.Drawing.Size(201, 207);
            this.btnExpert.TabIndex = 0;
            this.btnExpert.UseVisualStyleBackColor = true;
            this.btnExpert.Click += new System.EventHandler(this.btnExpert_Click);
            // 
            // btnCustom
            // 
            this.btnCustom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCustom.BackgroundImage")));
            this.btnCustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustom.Location = new System.Drawing.Point(238, 246);
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(201, 207);
            this.btnCustom.TabIndex = 0;
            this.btnCustom.UseVisualStyleBackColor = true;
            this.btnCustom.Click += new System.EventHandler(this.btnCustom_Click);
            // 
            // ModePlay
            // 
            this.ModePlay.Controls.Add(this.Mode1);
            this.ModePlay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ModePlay.Location = new System.Drawing.Point(12, 4);
            this.ModePlay.Name = "ModePlay";
            this.ModePlay.SelectedIndex = 0;
            this.ModePlay.Size = new System.Drawing.Size(427, 20);
            this.ModePlay.TabIndex = 2;
            // 
            // Mode1
            // 
            this.Mode1.Location = new System.Drawing.Point(4, 22);
            this.Mode1.Name = "Mode1";
            this.Mode1.Padding = new System.Windows.Forms.Padding(3);
            this.Mode1.Size = new System.Drawing.Size(419, 0);
            this.Mode1.TabIndex = 0;
            this.Mode1.Text = "1 player";
            this.Mode1.UseVisualStyleBackColor = true;
            // 
            // txb
            // 
            this.txb.Location = new System.Drawing.Point(16, 478);
            this.txb.Multiline = true;
            this.txb.Name = "txb";
            this.txb.Size = new System.Drawing.Size(423, 46);
            this.txb.TabIndex = 3;
            // 
            // tmr
            // 
            this.tmr.Interval = 1;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(445, 501);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(75, 23);
            this.btn.TabIndex = 5;
            this.btn.Text = "button1";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // dtScore
            // 
            this.dtScore.AllowUserToAddRows = false;
            this.dtScore.AllowUserToDeleteRows = false;
            this.dtScore.AllowUserToResizeColumns = false;
            this.dtScore.AllowUserToResizeRows = false;
            this.dtScore.BackgroundColor = System.Drawing.Color.Indigo;
            this.dtScore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtScore.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtScore.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dtScore.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtScore.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtScore.ColumnHeadersHeight = 30;
            this.dtScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtScore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmName,
            this.clmScore,
            this.clmTime});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtScore.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtScore.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtScore.GridColor = System.Drawing.Color.GhostWhite;
            this.dtScore.Location = new System.Drawing.Point(468, 32);
            this.dtScore.MultiSelect = false;
            this.dtScore.Name = "dtScore";
            this.dtScore.ReadOnly = true;
            this.dtScore.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtScore.RowHeadersWidth = 4;
            this.dtScore.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtScore.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtScore.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtScore.Size = new System.Drawing.Size(411, 420);
            this.dtScore.TabIndex = 9;
            this.dtScore.TabStop = false;
            // 
            // clmName
            // 
            this.clmName.HeaderText = "Name";
            this.clmName.Name = "clmName";
            this.clmName.ReadOnly = true;
            this.clmName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmName.Width = 200;
            // 
            // clmScore
            // 
            this.clmScore.HeaderText = "Score";
            this.clmScore.Name = "clmScore";
            this.clmScore.ReadOnly = true;
            this.clmScore.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // clmTime
            // 
            this.clmTime.HeaderText = "Time";
            this.clmTime.Name = "clmTime";
            this.clmTime.ReadOnly = true;
            this.clmTime.Width = 105;
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(294, 9);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(145, 20);
            this.txbName.TabIndex = 1;
            this.txbName.Text = "Anonymous";
            this.txbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbYourName
            // 
            this.lbYourName.AutoSize = true;
            this.lbYourName.BackColor = System.Drawing.Color.Transparent;
            this.lbYourName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbYourName.Location = new System.Drawing.Point(223, 12);
            this.lbYourName.Name = "lbYourName";
            this.lbYourName.Size = new System.Drawing.Size(71, 13);
            this.lbYourName.TabIndex = 10;
            this.lbYourName.Text = "Your name:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(894, 461);
            this.Controls.Add(this.lbYourName);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.dtScore);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.txb);
            this.Controls.Add(this.ModePlay);
            this.Controls.Add(this.btnCustom);
            this.Controls.Add(this.btnMedium);
            this.Controls.Add(this.btnExpert);
            this.Controls.Add(this.btnEasy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Minesweeper";
            this.ModePlay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Button btnExpert;
        private System.Windows.Forms.Button btnCustom;
        private System.Windows.Forms.TabControl ModePlay;
        private System.Windows.Forms.TabPage Mode1;
        private System.Windows.Forms.TextBox txb;
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.DataGridView dtScore;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Label lbYourName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTime;
    }
}

