using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class FormCustom : Form
    {
        public int widthT,
                   heightT,
                   mine;
        public bool play = false;
        public FormCustom()
        {
            InitializeComponent();
            tmr.Start();
        }

        private void widthBar_ValueChanged(object sender, EventArgs e)
        {
            lbWidth.Text = widthBar.Value.ToString();
            mineBar.Maximum = (widthBar.Value - 1) * (heightBar.Value - 1);
            lbMines.Text = mineBar.Value.ToString();
        }

        private void heightBar_ValueChanged(object sender, EventArgs e)
        {
            lbHeight.Text = heightBar.Value.ToString();
            mineBar.Maximum = (widthBar.Value - 1) * (heightBar.Value - 1);
            lbMines.Text = mineBar.Value.ToString();
        }

        private void mineBar_ValueChanged(object sender, EventArgs e)
        {
            lbMines.Text = mineBar.Value.ToString();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            heightT = heightBar.Value;
            widthT = widthBar.Value;
            mine = mineBar.Value;
            this.Hide();
            play = true;
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            // Set giá trị mine luôn chẵn
            if (mineBar.Value % 2 != 0)
                mineBar.Value--;
        }
    }
}
