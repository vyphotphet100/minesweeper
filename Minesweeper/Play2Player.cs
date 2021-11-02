using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class FormPlay2Player : Form
    {
        MessBox frmMessBox = new MessBox();
        public int widthT,
                   heightT,
                   mine,
                   flag1, flag2,
                   yourNumber, 
                   enemyNumber,
                   numberWon = 0,
                   xWon, yWon;

        Random rand = new Random();
        Panel panelBoard;
        int[,] board; // bảng chơi 
        int[,] hashBoardButton; // Dùng để lưu hashcode của các button
        Button[,] btnBox; // Tạo các button

        bool enemyPlay = false;

        public bool clickHome = false;
        public bool clickGiveUp = false;

        // Dùng để truyền dữ liệu khi người này thực hiện chọn ô
        public int signal = 0;
        public int xPlay = 0;
        public int yPlay = 0;

        private void btn_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                button1.Visible = false;
        }



        public FormPlay2Player()
        {
            InitializeComponent();
            tmr1.Start();
            tmr.Start();
        }

        public void Play()
        {
            heightT = int.Parse(txbHeightT.Text);
            widthT = int.Parse(txbWidthT.Text);
            mine = int.Parse(txbMines.Text);
            flag1 = int.Parse(txbFlag.Text);
            flag2 = int.Parse(txbFlag.Text);
            yourNumber = int.Parse(txbYourNumber.Text);
            if (yourNumber == 1)
                enemyNumber = 2;
            else
                enemyNumber = 1;

            this.Text = "Play: " + heightT + "x" + widthT;

            board = new int[heightT, widthT];
            hashBoardButton = new int[heightT, widthT];
            btnBox = new Button[heightT, widthT];

            txbMinute.Text = "00";
            txbSecond.Text = "00";
            lbMine.Text = mine.ToString();
            lbYourNumber.Text = "Your number: " + yourNumber;
            txbFlag1.Text = flag1.ToString();
            txbFlag2.Text = flag2.ToString();

            CreateBoard();
        }

        public void Clear()
        {
            this.Text = "Play";
            tmr1.Stop();

            txbMinute.Text = "00";
            txbSecond.Text = "00";
            lbMine.Text = "0";
            txbFlag1.Text = "0";

            // Xóa hết các button và panel trên màn hình
            for (int i = 0; i < heightT; i++)
            {
                for (int j = 0; j < widthT; j++)
                {
                    hashBoardButton[i, j] = 0;
                    panelBoard.Controls.Remove(btnBox[i, j]);
                }
            }

            board = null;
            hashBoardButton = null;
            btnBox = null;
            panelBorder.Controls.Remove(panelBoard);
            panelBoard = null;
        }

        void CreateBoard()
        {
            int[,] mineIdx = new int[mine, 2]; // vị trí của mìn
            panelBoard = new Panel();

            // Set tất cả giá trị của mảng mineIdx về -1
            for (int i = 0; i < mine; i++)
            {
                mineIdx[i, 0] = -1;
                mineIdx[i, 1] = -1;
            }

            // Lấy chuỗi lưu vị trí của mìn
            using (WebClient wbClient = new WebClient())
            {
                string strIdxMine = wbClient.DownloadString("http://" + txbIP.Text + "/minesweeper/getIdxMine.php").Replace('\r', '.');
                strIdxMine = strIdxMine.Replace('\n', '.');
                strIdxMine = strIdxMine.Replace(' ', '-');
                strIdxMine = ".." + strIdxMine;


                int order = 0;
                for (int k = 0; k < strIdxMine.Length - 1; k++)
                {
                    if (strIdxMine[k] == '.')
                    {
                        k++;
                        string strTmp1 = "";
                        int i = 1;
                        while (k + i < strIdxMine.Length && strIdxMine[k + i] != '-')
                        {
                            strTmp1 += strIdxMine[k + i];
                            i++;
                        }
                        if (strTmp1 != "")
                            mineIdx[order, 0] = int.Parse(strTmp1);

                        string strTmp2 = "";
                        i++;
                        while (k + i < strIdxMine.Length && strIdxMine[k + i] != '.')
                        {
                            strTmp2 += strIdxMine[k + i];
                            i++;
                        }
                        if (strTmp2 != "")
                            mineIdx[order, 1] = int.Parse(strTmp2);
                        order++;
                    }
                }
            }

            // Thêm mìn vào bảng
            for (int i = 0; i < mine; i++)
                board[mineIdx[i, 0], mineIdx[i, 1]] = -1;

            // Điền các số còn lại vào mảng
            for (int i = 0; i < heightT; i++)
            {
                for (int j = 0; j < widthT; j++)
                {
                    if (board[i, j] != -1)
                    {
                        if (i - 1 >= 0 && j - 1 >= 0 && board[i - 1, j - 1] == -1) board[i, j]++;
                        if (i - 1 >= 0 && board[i - 1, j] == -1) board[i, j]++;
                        if (i - 1 >= 0 && j + 1 < widthT && board[i - 1, j + 1] == -1) board[i, j]++;
                        if (j + 1 < widthT && board[i, j + 1] == -1) board[i, j]++;
                        if (i + 1 < heightT && j + 1 < widthT && board[i + 1, j + 1] == -1) board[i, j]++;
                        if (i + 1 < heightT && board[i + 1, j] == -1) board[i, j]++;
                        if (i + 1 < heightT && j - 1 >= 0 && board[i + 1, j - 1] == -1) board[i, j]++;
                        if (j - 1 >= 0 && board[i, j - 1] == -1) board[i, j]++;
                    }
                }
            }

            // Tạo board 
            int heiBox = 45;
            int widBox = 45;

            panelBoard.Size =
                new Size(widthT * widBox + 8 + 2 * (widthT - 1), heightT * heiBox + 8 + 2 * (heightT - 1));
            int tmpLocX = panelBorder.Width / 2 - panelBoard.Width / 2 - 3;
            int tmpLocY = panelBorder.Height / 2 - panelBoard.Height / 2 - 3;

            while (tmpLocX <= 5 || tmpLocY <= 5)
            {
                heiBox--;
                widBox--;
                panelBoard.Size =
                    new Size(widthT * widBox + 8 + 2 * (widthT - 1), heightT * heiBox + 8 + 2 * (heightT - 1));
                tmpLocX = panelBorder.Width / 2 - panelBoard.Width / 2 - 3;
                tmpLocY = panelBorder.Height / 2 - panelBoard.Height / 2 - 3;
            }
            panelBoard.Location = new Point(tmpLocX, tmpLocY);

            panelBoard.BackColor = Color.Transparent;
            panelBoard.BorderStyle = BorderStyle.FixedSingle;
            panelBoard.Name = "panelBoard";
            panelBorder.Controls.Add(panelBoard);

            // Set thuộc tính cho các button Box
            for (int i = 0; i < heightT; i++)
            {
                for (int j = 0; j < widthT; j++)
                {
                    btnBox[i, j] = new Button();
                    btnBox[i, j].BackgroundImage = Properties.Resources.box_background;
                    btnBox[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    btnBox[i, j].FlatStyle = FlatStyle.Flat;
                    btnBox[i, j].ForeColor = SystemColors.InactiveCaptionText;
                    btnBox[i, j].Size = new Size(widBox, heiBox);
                    btnBox[i, j].Name = "nonFlag";
                    btnBox[i, j].UseVisualStyleBackColor = false;
                    btnBox[i, j].Click += new EventHandler(this.getXY_click); // Đào 
                    btnBox[i, j].MouseUp += new MouseEventHandler(this.getXY_RightClick); // Đặt cờ
                    hashBoardButton[i, j] = btnBox[i, j].GetHashCode();

                    btnBox[i, j].Location = new Point(3 + (2 * j) + (btnBox[i, j].Width * j), 3 + (2 * i) + (btnBox[i, j].Width * i));
                    panelBoard.Controls.Add(btnBox[i, j]);
                }
            }
        }


        public void box_click(int xClick, int yClick)
        {
            if (btnBox[xClick, yClick].Name == "nonFlag")
            {
                if (board[xClick, yClick] == -1) // Khi đào phải mìn
                {
                    xWon = xClick;
                    yWon = yClick;
                    if (!enemyPlay)
                        numberWon = enemyNumber;
                        
                    else
                        numberWon = yourNumber;

                }
                else // Nếu không
                {
                    //Mở ô
                    if (board[xClick, yClick] != 0)
                        btnBox[xClick, yClick].Text = board[xClick, yClick].ToString();
                    btnBox[xClick, yClick].BackgroundImage = Properties.Resources.box_background_open;
                    btnBox[xClick, yClick].Name = "opened";

                    // Mở rộng vùng xung quanh
                    if (yClick - 1 >= 0 &&
                        btnBox[xClick, yClick - 1].Name == "nonFlag" &&
                        board[xClick, yClick - 1] == 0)
                        box_click(xClick, yClick - 1);
                    if (xClick - 1 >= 0 &&
                        btnBox[xClick - 1, yClick].Name == "nonFlag" &&
                        board[xClick - 1, yClick] == 0)
                        box_click(xClick - 1, yClick);
                    if (yClick + 1 < widthT &&
                        btnBox[xClick, yClick + 1].Name == "nonFlag" &&
                        board[xClick, yClick + 1] == 0)
                        box_click(xClick, yClick + 1);
                    if (xClick + 1 < heightT &&
                        btnBox[xClick + 1, yClick].Name == "nonFlag" &&
                        board[xClick + 1, yClick] == 0)
                        box_click(xClick + 1, yClick);

                    if (xClick - 1 >= 0 && yClick - 1 >= 0 &&
                        btnBox[xClick - 1, yClick - 1].Name == "nonFlag" &&
                        board[xClick - 1, yClick - 1] == 0)
                        box_click(xClick - 1, yClick - 1);
                    if (xClick - 1 >= 0 && yClick + 1 < widthT &&
                        btnBox[xClick - 1, yClick + 1].Name == "nonFlag" &&
                        board[xClick - 1, yClick + 1] == 0)
                        box_click(xClick - 1, yClick + 1);
                    if (xClick + 1 < heightT && yClick + 1 < widthT &&
                        btnBox[xClick + 1, yClick + 1].Name == "nonFlag" &&
                        board[xClick + 1, yClick + 1] == 0)
                        box_click(xClick + 1, yClick + 1);
                    if (xClick + 1 < heightT && yClick - 1 >= 0 &&
                        btnBox[xClick + 1, yClick - 1].Name == "nonFlag" &&
                        board[xClick + 1, yClick - 1] == 0)
                        box_click(xClick + 1, yClick - 1);

                    if (board[xClick, yClick] == 0)
                    {
                        if (yClick - 1 >= 0 &&
                        btnBox[xClick, yClick - 1].Name == "nonFlag")
                            box_click(xClick, yClick - 1);
                        if (xClick - 1 >= 0 &&
                            btnBox[xClick - 1, yClick].Name == "nonFlag")
                            box_click(xClick - 1, yClick);
                        if (yClick + 1 < widthT &&
                            btnBox[xClick, yClick + 1].Name == "nonFlag")
                            box_click(xClick, yClick + 1);
                        if (xClick + 1 < heightT &&
                            btnBox[xClick + 1, yClick].Name == "nonFlag")
                            box_click(xClick + 1, yClick);

                        if (xClick - 1 >= 0 && yClick - 1 >= 0 &&
                        btnBox[xClick - 1, yClick - 1].Name == "nonFlag")
                            box_click(xClick - 1, yClick - 1);
                        if (xClick - 1 >= 0 && yClick + 1 < widthT &&
                            btnBox[xClick - 1, yClick + 1].Name == "nonFlag")
                            box_click(xClick - 1, yClick + 1);
                        if (xClick + 1 < heightT && yClick + 1 < widthT &&
                            btnBox[xClick + 1, yClick + 1].Name == "nonFlag")
                            box_click(xClick + 1, yClick + 1);
                        if (xClick + 1 < heightT && yClick - 1 >= 0 &&
                            btnBox[xClick + 1, yClick - 1].Name == "nonFlag")
                            box_click(xClick + 1, yClick - 1);
                    }

                    // Đếm số cờ được đặt
                    CountFlag(xClick, yClick);
                }
            }
            else if (btnBox[xClick, yClick].Name == "flag" ||
                     btnBox[xClick, yClick].Name == "flag2")
                UnSetFlag(xClick, yClick);
        }
        void getXY_click(object sender, EventArgs e)
        {
            // Lấy tọa độ của button được click
            int xClick = -1;
            int yClick = -1;
            for (int i = 0; i < heightT; i++)
            {
                for (int j = 0; j < widthT; j++)
                    if (hashBoardButton[i, j] == sender.GetHashCode())
                    {
                        xClick = i;
                        yClick = j;
                    }
            }

            // Truyền dữ liệu đi
            xPlay = xClick;
            yPlay = yClick;
            signal = 1;

            box_click(xClick, yClick);

        }

        public void box_RightClick(int xClick, int yClick)
        {
            if (btnBox[xClick, yClick].Name == "nonFlag")
            {
                if (enemyPlay)
                    SetFlag_2(xClick, yClick);
                else
                    SetFlag(xClick, yClick);
            }
            else if (btnBox[xClick, yClick].Name == "flag" ||
                     btnBox[xClick, yClick].Name == "flag2")
                UnSetFlag(xClick, yClick);

            // Đếm số cờ được đặt
            CountFlag(xClick, yClick);
        }
        void getXY_RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Lấy tọa độ của button được click
                int xClick = -1;
                int yClick = -1;
                for (int i = 0; i < heightT; i++)
                {
                    for (int j = 0; j < widthT; j++)
                        if (hashBoardButton[i, j] == sender.GetHashCode())
                        {
                            xClick = i;
                            yClick = j;
                        }
                }

                // Truyền dữ liệu đi
                xPlay = xClick;
                yPlay = yClick;
                signal = 2;

                box_RightClick(xClick, yClick);
            }
        }


        public void getXY_2_click(int xClick, int yClick, int flag)
        {
            enemyPlay = true;
            box_click(xClick, yClick);
            enemyPlay = false;
        }

        public void getXY_2_RightClick(int xClick, int yClick, int flag)
        {
            enemyPlay = true;
            box_RightClick(xClick, yClick);
            enemyPlay = false;
        }

        void CountFlag(int xClick, int yClick)
        {
            int flaged1 = 0;
            int flaged2 = 0;
            for (int i = 0; i < heightT; i++)
                for (int j = 0; j < widthT; j++)
                {
                    if (btnBox[i, j].Name == "flag")
                        flaged1++;
                    else if (btnBox[i, j].Name == "flag2")
                        flaged2++;
                }

            if (yourNumber == 1)
            {
                flag1 = mine / 2 - flaged1;
                flag2 = mine / 2 - flaged2;

                txbFlag1.Text = flag1.ToString();
                txbFlag2.Text = flag2.ToString();
            }
            else if (yourNumber == 2)
            {
                flag1 = mine / 2 - flaged1;
                flag2 = mine / 2 - flaged2;

                txbFlag1.Text = flag2.ToString();
                txbFlag2.Text = flag1.ToString();
            }

            // Khi đã đặt hết cờ, kiểm tra xem thắng hay thua
            if (txbFlag1.Text == "0")
            {
                xWon = -1;
                yWon = -1;
                if (yourNumber == 1)
                {
                    if (CheckWin(1))
                        numberWon = yourNumber;
                    else
                        numberWon = enemyNumber;
                }
                else if (yourNumber == 2)
                {
                    if (CheckWin(2))
                        numberWon = enemyNumber;
                    else
                        numberWon = yourNumber;
                }
                yourNumber = 0; // mục đích để không kiểm tra nữa
            }
            else if (txbFlag2.Text == "0")
            {
                xWon = -1;
                yWon = -1;
                if (yourNumber == 1)
                {
                    if (CheckWin(2))
                        numberWon = enemyNumber;
                    else
                        numberWon = yourNumber;
                }
                else if (yourNumber == 2)
                {
                    if (CheckWin(1))
                        numberWon = yourNumber;
                    else
                        numberWon = enemyNumber;
                }
                yourNumber = 0; // mục đích để không kiểm tra nữa
            }
        }

        void SetFlag(int x, int y)
        {
            btnBox[x, y].BackgroundImage = Properties.Resources.flag_red_2;
            btnBox[x, y].Name = "flag";
        }

        void SetFlag_2(int x, int y)
        {
            btnBox[x, y].BackgroundImage = Properties.Resources.flag_yellow_2;
            btnBox[x, y].Enabled = false;
            btnBox[x, y].Name = "flag2";
        }

        void UnSetFlag(int x, int y)
        {
            btnBox[x, y].BackgroundImage = Properties.Resources.box_background;
            btnBox[x, y].Enabled = true;
            btnBox[x, y].Name = "nonFlag";
        }

        bool CheckWin(int number)
        {
            for (int i = 0; i < heightT; i++)
            {
                for (int j = 0; j < widthT; j++)
                {
                    if (number == 1)
                    {
                        if (btnBox[i, j].Name == "flag")
                            if (board[i, j] != -1)
                                return false;
                    }
                    else if (number == 2)
                    {
                        if (btnBox[i, j].Name == "flag2")
                            if (board[i, j] != -1)
                                return false;
                    }
                }
            }
            return true;
        }

        public void Won(int x, int y)
        {
            // Hiện thị mìn
            ShowMines(x, y);
            panelBoard.Enabled = false;
            tmr1.Stop();
            frmMessBox.lb.Text = "You won!";
            frmMessBox.Show();
        }

        public void Lose(int x, int y)
        {
            // Hiện thị mìn
            ShowMines(x, y);
            panelBoard.Enabled = false;
            tmr1.Stop();
            frmMessBox.lb.Text = "You lose!";
            frmMessBox.Show();
        }

        void ShowMines(int x, int y)
        {
            // Hiện thị mìn
            if (x != -1 && y != -1)
                btnBox[x, y].BackgroundImage = Properties.Resources.mine_fail;

            for (int i = 0; i < heightT; i++)
            {
                for (int j = 0; j < widthT; j++)
                {
                    if (!(i == x && j == y))
                    {
                        if (board[i, j] == -1)
                        {
                            btnBox[i, j].Text = " ";
                            if (btnBox[i, j].Name == "flag")
                                btnBox[i, j].BackgroundImage = Properties.Resources.mine_true_red;
                            else if (btnBox[i, j].Name == "flag2")
                                btnBox[i, j].BackgroundImage = Properties.Resources.mine_true_yellow;
                            else if (btnBox[i, j].Name == "nonFlag")
                                btnBox[i, j].BackgroundImage = Properties.Resources.mine;
                        }
                        else if (board[i, j] != -1)
                        {
                            if (btnBox[i, j].Name == "flag")
                            {
                                btnBox[i, j].Text = " ";
                                btnBox[i, j].BackgroundImage = Properties.Resources.flag_red_fail_2;
                            }
                            else if (btnBox[i, j].Name == "flag2")
                            {
                                btnBox[i, j].Text = " ";
                                btnBox[i, j].BackgroundImage = Properties.Resources.flag_yellow_fail_2;
                            }
                        }
                    }
                }
            }
            
        }

        // Time play
        private void tmr1_Tick(object sender, EventArgs e)
        {
            txbSecond.Text = (int.Parse(txbSecond.Text) + 1).ToString();
            if (txbSecond.Text == "60")
            {
                txbSecond.Text = "0";
                txbMinute.Text = (int.Parse(txbMinute.Text) + 1).ToString();
            }
        }

        // Time kiểm tra
        private void tmr_Tick(object sender, EventArgs e)
        {
            
        }

        // Button event
        public void btnPlay_Click(object sender, EventArgs e)
        {
            Play();
        }

        public void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnGiveUp_Click(object sender, EventArgs e)
        {
            DialogResult ask = MessageBox.Show("Are you sure?", "Minesweeper", MessageBoxButtons.YesNo);
            if (ask == DialogResult.Yes)
            {
                xWon = -1;
                yWon = -1;
                numberWon = enemyNumber;
            }
        }

        public void btnHome_Click(object sender, EventArgs e)
        {
            clickHome = true;
            frmMessBox.Hide();
        }

    }
}
