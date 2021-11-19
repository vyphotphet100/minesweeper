using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minesweeper.Dtos;

namespace Minesweeper
{
    public partial class FormPlay : Form
    {

        public int widthT,
                   heightT,
                   mine;
        public bool clickHome = false;
        Random rand = new Random();
        Panel panelBoard;
        int[,] board; // bảng chơi
        int[,] mineIdx; // vị trí của mìn
        int[,] hashBoardButton; // Dùng để lưu hashcode của các button
        Button[,] btnBox; // Tạo các button

        private void btn_Click(object sender, EventArgs e)
        {
            tmr.Start();
            ProblemDto problem = new ProblemDto()
            {
                start = true
            };
            FindWay(problem);
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                button1.Visible = false;
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            //FindWay();
        }





        public FormPlay()
        {
            InitializeComponent();
        }

        public void Play()
        {
            this.Text = "Play: " + heightT + "x" + widthT;

            heightT = int.Parse(txbHeightT.Text);
            widthT = int.Parse(txbWidthT.Text);
            mine = int.Parse(txbMines.Text);

            board = new int[heightT, widthT];
            hashBoardButton = new int[heightT, widthT];
            btnBox = new Button[heightT, widthT];

            txbMinute.Text = "00";
            txbSecond.Text = "00";
            lbMine.Text = mine.ToString();
            txbFlag.Text = mine.ToString();

            txbScore.Text = "0";

            CreateBoard();
        }

        public void PlayAgain()
        {
            Clear2();

            this.Text = "Play: " + heightT + "x" + widthT;

            heightT = int.Parse(txbHeightT.Text);
            widthT = int.Parse(txbWidthT.Text);
            mine = int.Parse(txbMines.Text);

            //board = new int[heightT, widthT];
            hashBoardButton = new int[heightT, widthT];
            btnBox = new Button[heightT, widthT];

            txbMinute.Text = "00";
            txbSecond.Text = "00";
            lbMine.Text = mine.ToString();
            txbFlag.Text = mine.ToString();

            txbScore.Text = "0";

            CreateBoard2();
        }

        public void Clear()
        {
            this.Text = "Play";
            tmr1.Stop();

            txbMinute.Text = "00";
            txbSecond.Text = "00";
            lbMine.Text = "0";
            txbFlag.Text = "0";

            //board = null;
            hashBoardButton = null;
            btnBox = null;
            panelBorder.Controls.Remove(panelBoard);
            panelBoard = null;
        }

        public void Clear2()
        {
            this.Text = "Play";
            //tmr1.Stop();

            //txbMinute.Text = "00";
            //txbSecond.Text = "00";
            lbMine.Text = "0";
            txbFlag.Text = "0";

            //board = null;
            hashBoardButton = null;
            btnBox = null;
            panelBorder.Controls.Remove(panelBoard);
            panelBoard = null;
        }

        void ShowResult()
        {
            ShowMines(-1, -1);
            panelBoard.Enabled = false;
            tmr1.Stop();
        }

        void CreateBoard()
        {
            mineIdx = new int[mine, 2]; // vị trí của mìn
            panelBoard = new Panel();

            // Set tất cả giá trị của mảng mineIdx về -1
            for (int i = 0; i < mine; i++)
            {
                mineIdx[i, 0] = -1;
                mineIdx[i, 1] = -1;
            }

            // Lấy vị trí mìn một cách ngẫu nhiên
            for (int i = 0; i < mine; i++)
            {
                int x = rand.Next(0, heightT);
                int y = rand.Next(0, widthT);

                // Kiểm tra xem vị trí của mìn đã xuất hiện chưa
                bool check = true;
                for (int k = 0; k < mine; k++)
                {
                    if (mineIdx[k, 0] == x && mineIdx[k, 1] == y)
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    mineIdx[i, 0] = x;
                    mineIdx[i, 1] = y;
                }
                else
                    i--;
            }

            // Thêm mìn vào bảng
            for (int i = 0; i < mine; i++)
            {
                board[mineIdx[i, 0], mineIdx[i, 1]] = -1;
            }

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
                    btnBox[i, j].BackColor = Color.Black;
                    btnBox[i, j].FlatStyle = FlatStyle.Flat;
                    btnBox[i, j].ForeColor = SystemColors.InactiveCaptionText;
                    btnBox[i, j].Size = new Size(widBox, heiBox);
                    btnBox[i, j].Name = "nonFlag";
                    btnBox[i, j].UseVisualStyleBackColor = false;
                    btnBox[i, j].MouseUp += new MouseEventHandler(this.getXY_Click);
                    btnBox[i, j].BackgroundImage = Properties.Resources.box_background;
                    btnBox[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    hashBoardButton[i, j] = btnBox[i, j].GetHashCode();

                    btnBox[i, j].Location = new Point(3 + (2 * j) + (btnBox[i, j].Width * j), 3 + (2 * i) + (btnBox[i, j].Width * i));
                    panelBoard.Controls.Add(btnBox[i, j]);
                }
            }
        }

        void CreateBoard2()
        {
            //int[,] mineIdx = new int[mine, 2]; // vị trí của mìn
            panelBoard = new Panel();

            //// Set tất cả giá trị của mảng mineIdx về -1
            //for (int i = 0; i < mine; i++)
            //{
            //    mineIdx[i, 0] = -1;
            //    mineIdx[i, 1] = -1;
            //}

            //// Lấy vị trí mìn một cách ngẫu nhiên
            //for (int i = 0; i < mine; i++)
            //{
            //    int x = rand.Next(0, heightT);
            //    int y = rand.Next(0, widthT);

            //    // Kiểm tra xem vị trí của mìn đã xuất hiện chưa
            //    bool check = true;
            //    for (int k = 0; k < mine; k++)
            //    {
            //        if (mineIdx[k, 0] == x && mineIdx[k, 1] == y)
            //        {
            //            check = false;
            //            break;
            //        }
            //    }
            //    if (check)
            //    {
            //        mineIdx[i, 0] = x;
            //        mineIdx[i, 1] = y;
            //    }
            //    else
            //        i--;
            //}

            //// Thêm mìn vào bảng
            //for (int i = 0; i < mine; i++)
            //{
            //    board[mineIdx[i, 0], mineIdx[i, 1]] = -1;
            //}

            //// Điền các số còn lại vào mảng
            //for (int i = 0; i < heightT; i++)
            //{
            //    for (int j = 0; j < widthT; j++)
            //    {
            //        if (board[i, j] != -1)
            //        {
            //            if (i - 1 >= 0 && j - 1 >= 0 && board[i - 1, j - 1] == -1) board[i, j]++;
            //            if (i - 1 >= 0 && board[i - 1, j] == -1) board[i, j]++;
            //            if (i - 1 >= 0 && j + 1 < widthT && board[i - 1, j + 1] == -1) board[i, j]++;
            //            if (j + 1 < widthT && board[i, j + 1] == -1) board[i, j]++;
            //            if (i + 1 < heightT && j + 1 < widthT && board[i + 1, j + 1] == -1) board[i, j]++;
            //            if (i + 1 < heightT && board[i + 1, j] == -1) board[i, j]++;
            //            if (i + 1 < heightT && j - 1 >= 0 && board[i + 1, j - 1] == -1) board[i, j]++;
            //            if (j - 1 >= 0 && board[i, j - 1] == -1) board[i, j]++;
            //        }
            //    }
            //}

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
                    btnBox[i, j].BackColor = Color.Black;
                    btnBox[i, j].FlatStyle = FlatStyle.Flat;
                    btnBox[i, j].ForeColor = SystemColors.InactiveCaptionText;
                    btnBox[i, j].Size = new Size(widBox, heiBox);
                    btnBox[i, j].Name = "nonFlag";
                    btnBox[i, j].UseVisualStyleBackColor = false;
                    btnBox[i, j].MouseUp += new MouseEventHandler(this.getXY_Click);
                    btnBox[i, j].BackgroundImage = Properties.Resources.box_background;
                    btnBox[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    hashBoardButton[i, j] = btnBox[i, j].GetHashCode();

                    btnBox[i, j].Location = new Point(3 + (2 * j) + (btnBox[i, j].Width * j), 3 + (2 * i) + (btnBox[i, j].Width * i));
                    panelBoard.Controls.Add(btnBox[i, j]);
                }
            }
        }

        void getXY_Click(object sender, MouseEventArgs e)
        {
            tmr1.Start();

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

            if (e.Button == MouseButtons.Left)
            {
                box_click(xClick, yClick);
            }
                
            else if (e.Button == MouseButtons.Right)
                box_RightClick(xClick, yClick);

            // Đếm số cờ được đặt
            CountFlag();
        }
        void box_click(int xClick, int yClick)
        {
            if (btnBox[xClick, yClick].Name == "nonFlag")
            {
                // Khi đào phải mìn
                if (board[xClick, yClick] == -1)
                {
                    //Lose(xClick, yClick);
                    PlayAgain();
                }
                else // Nếu không
                {
                    //Mở ô
                    if (board[xClick, yClick] != 0)
                        btnBox[xClick, yClick].Text = board[xClick, yClick].ToString();
                    //btnBox[xClick, yClick].BackColor = Color.White;
                    btnBox[xClick, yClick].BackgroundImage = Properties.Resources.box_background_open;
                    btnBox[xClick, yClick].Name = "opened";

                    #region Mở rộng vùng xung quanh
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
                    #endregion

                }
            }
            else if (btnBox[xClick, yClick].Name == "flag")
                UnSetFlag(xClick, yClick);
        }

        void box_RightClick(int xClick, int yClick)
        {
            if (btnBox[xClick, yClick].Name == "nonFlag")
                SetFlag(xClick, yClick);
            //else if (btnBox[xClick, yClick].Name == "flag")
            //    UnSetFlag(xClick, yClick);
        }

        void CountFlag()
        {
            int flag = 0;
            for (int i=0; i<heightT; i++)
                for (int j=0; j<widthT; j++)
                    if (btnBox[i, j].Name == "flag")
                        flag++;
            txbFlag.Text = (mine-flag).ToString();

            // Khi đã đặt hết cờ, kiểm tra xem thắng hay thua
            if(txbFlag.Text == "0")
            {
                if (CheckWin())
                    Win();
                else
                    Lose(-1, -1);
            }
        }

        void SetFlag(int x, int y)
        {
            btnBox[x, y].Name = "flag";
            btnBox[x, y].BackgroundImage = Properties.Resources.flag_red;
        }

        void UnSetFlag(int x, int y)
        {
            btnBox[x, y].Name = "nonFlag";
            btnBox[x, y].BackgroundImage = Properties.Resources.box_background;
        }

        bool CheckWin()
        {
            for (int i=0; i<heightT; i++)
            {
                for (int j=0; j<widthT; j++)
                {
                    if (board[i, j] == -1)
                        if (btnBox[i, j].Name != "flag")
                            return false;
                }
            }
            return true;
        }

        void Win()
        {
            // Hiện thị mìn
            ShowMines(-1, -1);
            CountScore();
            panelBoard.Enabled = false;
            tmr1.Stop();
            
            
            tmr.Stop();

            MessBox messBox = new MessBox();
            messBox.lb.Text = "Mày hành tao như thế đủ chưa??";
            messBox.Show();
        }

        void Lose(int x, int y)
        {
            // Hiện thị mìn
            ShowMines(x, y);
            panelBoard.Enabled = false;
            tmr1.Stop();

            tmr.Stop();

            MessBox messBox = new MessBox();
            messBox.lb.Text = "You lose!";
            messBox.Show();
        }

        void ShowMines(int x, int y)
        {
            // Hiện thị mìn
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
                                btnBox[i, j].BackgroundImage = Properties.Resources.mine_true;
                            else if (btnBox[i, j].Name == "nonFlag")
                                btnBox[i, j].BackgroundImage = Properties.Resources.mine;
                        }
                        else if (board[i, j] != -1)
                        {
                            if (btnBox[i, j].Name == "flag")
                            {
                                btnBox[i, j].Text = " ";
                                btnBox[i, j].BackgroundImage = Properties.Resources.flag_red_fail;
                            }
                        }
                    }
                    
                }
            }
            if (x != -1 && y != -1)
                btnBox[x, y].BackgroundImage = Properties.Resources.mine_fail;
        }

        void CountScore()
        {
            for (int i=0; i<heightT; i++)
            {
                for (int j=0; j<widthT; j++)
                {
                    if (btnBox[i, j].Name == "flag" && board[i, j] == -1) // Nếu đặt đúng cờ
                        txbScore.Text = (int.Parse(txbScore.Text) + 10).ToString();
                    if (btnBox[i, j].Name == "nonFlag") // Nếu ô chưa mở
                        txbScore.Text = (int.Parse(txbScore.Text) + 10).ToString();
                }
            }
            btnHome.Focus();
        }

        async void FindWay(ProblemDto problem)
        {
            // Chuyển đổi bảng
            int[,] boardPlayed = new int[heightT, widthT];
            for (int i = 0; i < heightT; i++)
            {
                for (int j = 0; j < widthT; j++)
                {
                    if (btnBox[i, j].Name == "nonFlag")
                        //Chưa mở
                        boardPlayed[i, j] = -2;
                    else if (btnBox[i, j].Name == "flag")
                        //Chưa mở có đặt cờ
                        boardPlayed[i, j] = -1;
                    else if (btnBox[i, j].Name == "opened")
                    {
                        if (btnBox[i, j].Text != " " && btnBox[i, j].Text != "")
                            //Đã mở mà có số
                            boardPlayed[i, j] = int.Parse(btnBox[i, j].Text);
                        else
                            //Đã mở mà không gắn số
                            boardPlayed[i, j] = 0;
                    }
                }
            }

            problem.state = boardPlayed;
            problem.mine = mine;
            var action = await ApiGateway.GetHintAsync(problem);
            problem.start = false;

            //DialogResult dr =  MessageBox.Show("X: " + action.X + "\nY: " + action.Y + "\naction: " + action.task, "Announcement", MessageBoxButtons.OKCancel);
            if (CheckWin())
                Win();
            else
            {
                if (action.notMineActions != null)
                {
                    for(int i=0; i< action.notMineActions.Length; i++)
                        box_click(action.notMineActions[i][0], action.notMineActions[i][1]);
                }

                if (action.havingMineActions != null)
                {
                    for (int i = 0; i < action.havingMineActions.Length; i++)
                        box_RightClick(action.havingMineActions[i][0], action.havingMineActions[i][1]);
                }

                if (action.task == 1)
                {
                    box_click(action.X, action.Y);
                    FindWay(problem);
                }
                else if (action.task == -1)
                {
                    box_RightClick(action.X, action.Y);
                    FindWay(problem);
                }
                else if (action.task == 10)
                {
                    //box_RightClick(action.X, action.Y);
                }
            }
            

            //if (dr == DialogResult.OK)
            
        }

        int CountMineAround(float[,] boardPlayed, int i, int j)
        {
            int ans = 0;
            if (i - 1 >= 0 && j - 1 >= 0 &&
                boardPlayed[i - 1, j - 1] == -2)
                ans++;
            if (i - 1 >= 0 &&
                boardPlayed[i - 1, j]== -2)
                ans++;
            if (i - 1 >= 0 && j + 1 < widthT &&
                boardPlayed[i - 1, j + 1] == -2)
                ans++;
            if (j + 1 < widthT &&
                boardPlayed[i, j + 1] == -2)
                ans++;
            if (i + 1 < heightT && j + 1 < widthT &&
                boardPlayed[i + 1, j + 1] == -2)
                ans++;
            if (i + 1 < heightT &&
               boardPlayed[i + 1, j] == -2)
                ans++;
            if (i + 1 < heightT && j - 1 >= 0 &&
                boardPlayed[i + 1, j - 1] == -2)
                ans++;
            if (j - 1 >= 0 &&
                boardPlayed[i, j - 1] == -2)
                ans++;

            return ans;
        }
        int CountNonFlagBox(float[,] boardPlayed, int i, int j)
        {
            int ans = 0;
            if (i - 1 >= 0 && j - 1 >= 0 &&
                (boardPlayed[i - 1, j - 1] >= 10 ||
                boardPlayed[i - 1, j - 1] == 0))
                ans++;
            if (i - 1 >= 0 &&
                (boardPlayed[i - 1, j] >= 10 ||
                boardPlayed[i - 1, j] == 0))
                ans++;
            if (i - 1 >= 0 && j + 1 < widthT &&
                (boardPlayed[i - 1, j + 1] >= 10 ||
                boardPlayed[i - 1, j + 1] == 0))
                ans++;
            if (j + 1 < widthT &&
                (boardPlayed[i, j + 1] >= 10 ||
                boardPlayed[i, j + 1] == 0))
                ans++;
            if (i + 1 < heightT && j + 1 < widthT &&
                (boardPlayed[i + 1, j + 1] >= 10 ||
                boardPlayed[i + 1, j + 1] == 0))
                ans++;
            if (i + 1 < heightT &&
               (boardPlayed[i + 1, j] >= 10 ||
                boardPlayed[i + 1, j] == 0))
                ans++;
            if (i + 1 < heightT && j - 1 >= 0 &&
                (boardPlayed[i + 1, j - 1] >= 10 ||
                boardPlayed[i + 1, j - 1] == 0))
                ans++;
            if (j - 1 >= 0 &&
                (boardPlayed[i, j - 1] >= 10 ||
                boardPlayed[i, j - 1] == 0))
                ans++;

            return ans;
        }

        void ClickFirstNonFlag(float[,] boardPlayed, int i, int j)
        {
            if (i - 1 >= 0 && j - 1 >= 0 &&
                (boardPlayed[i - 1, j - 1] >= 10 ||
                boardPlayed[i - 1, j - 1] == 0))
                box_click(i - 1, j - 1);
            else if (i - 1 >= 0 &&
                (boardPlayed[i - 1, j] >= 10 ||
                boardPlayed[i - 1, j] == 0))
                box_click(i - 1, j);
            else if (i - 1 >= 0 && j + 1 < widthT &&
                (boardPlayed[i - 1, j + 1] >= 10 ||
                boardPlayed[i - 1, j + 1] == 0))
                box_click(i - 1, j + 1);
            else if (j + 1 < widthT &&
                (boardPlayed[i, j + 1] >= 10 ||
                boardPlayed[i, j + 1] == 0))
                box_click(i, j + 1);
            else if (i + 1 < heightT && j + 1 < widthT &&
                (boardPlayed[i + 1, j + 1] >= 10 ||
                boardPlayed[i + 1, j + 1] == 0))
                box_click(i + 1, j + 1);
            else if (i + 1 < heightT &&
               (boardPlayed[i + 1, j] >= 10 ||
                boardPlayed[i + 1, j] == 0))
                box_click(i + 1, j);
            else if (i + 1 < heightT && j - 1 >= 0 &&
                (boardPlayed[i + 1, j - 1] >= 10 ||
                boardPlayed[i + 1, j - 1] == 0))
                box_click(i + 1, j - 1);
            else if (j - 1 >= 0 &&
                (boardPlayed[i, j - 1] >= 10 ||
                boardPlayed[i, j - 1] == 0))
                box_click(i, j - 1);
        }

        void GetFirstNonFlag(float[,] boardPlayed, int i, int j, ref int i0, ref int j0)
        {
            if (i - 1 >= 0 && j - 1 >= 0 &&
                (boardPlayed[i - 1, j - 1] >= 10 ||
                boardPlayed[i - 1, j - 1] == 0))
            {
                i0 = i - 1;
                j0 = j - 1;
            }
            else if (i - 1 >= 0 &&
                (boardPlayed[i - 1, j] >= 10 ||
                boardPlayed[i - 1, j] == 0))
            {
                i0 = i - 1;
                j0 = j;
            }
            else if (i - 1 >= 0 && j + 1 < widthT &&
                (boardPlayed[i - 1, j + 1] >= 10 ||
                boardPlayed[i - 1, j + 1] == 0))
            {
                i0 = i - 1;
                j0 = j + 1;
            }
            else if (j + 1 < widthT &&
                (boardPlayed[i, j + 1] >= 10 ||
                boardPlayed[i, j + 1] == 0))
            {
                i0 = i;
                j0 = j + 1;
            }
            else if (i + 1 < heightT && j + 1 < widthT &&
                (boardPlayed[i + 1, j + 1] >= 10 ||
                boardPlayed[i + 1, j + 1] == 0))
            {
                i0 = i + 1;
                j0 = j + 1;
            }
            else if (i + 1 < heightT &&
               (boardPlayed[i + 1, j] >= 10 ||
                boardPlayed[i + 1, j] == 0))
            {
                i0 = i + 1;
                j0 = j;
            }
            else if (i + 1 < heightT && j - 1 >= 0 &&
                (boardPlayed[i + 1, j - 1] >= 10 ||
                boardPlayed[i + 1, j - 1] == 0))
            {
                i0 = i + 1;
                j0 = j - 1;
            }
            else if (j - 1 >= 0 &&
                (boardPlayed[i, j - 1] >= 10 ||
                boardPlayed[i, j - 1] == 0))
            {
                i0 = i;
                j0 = j - 1;
            }
        }

        void PlusAvgIdx(float[,] boardPlayed, int i, int j, float avgIdx)
        {
            if (i - 1 >= 0 && j - 1 >= 0 &&
                (boardPlayed[i - 1, j - 1] >= 10 ||
                boardPlayed[i - 1, j - 1] == 0))
                boardPlayed[i - 1, j - 1] += avgIdx;
            if (i - 1 >= 0 &&
                (boardPlayed[i - 1, j] >= 10 ||
                boardPlayed[i - 1, j] == 0))
                boardPlayed[i - 1, j] += avgIdx;
            if (i - 1 >= 0 && j + 1 < widthT &&
                (boardPlayed[i - 1, j + 1] >= 10 ||
                boardPlayed[i - 1, j + 1] == 0))
                boardPlayed[i - 1, j + 1] += avgIdx;
            if (j + 1 < widthT &&
                (boardPlayed[i, j + 1] >= 10 ||
                boardPlayed[i, j + 1] == 0))
                boardPlayed[i, j - 1] += avgIdx;
            if (i + 1 < heightT && j + 1 < widthT &&
                (boardPlayed[i + 1, j + 1] >= 10 ||
                boardPlayed[i + 1, j + 1] == 0))
                boardPlayed[i + 1, j + 1] += avgIdx;
            if (i + 1 < heightT &&
               (boardPlayed[i + 1, j] >= 10 ||
                boardPlayed[i + 1, j] == 0))
                boardPlayed[i + 1, j] += avgIdx;
            if (i + 1 < heightT && j - 1 >= 0 &&
                (boardPlayed[i + 1, j - 1] >= 10 ||
                boardPlayed[i + 1, j - 1] == 0))
                boardPlayed[i + 1, j - 1] += avgIdx;
            if (j - 1 >= 0 &&
                (boardPlayed[i, j - 1] >= 10 ||
                boardPlayed[i, j - 1] == 0))
                boardPlayed[i, j - 1] += avgIdx;
        }
        





        // Time
        private void tmr1_Tick(object sender, EventArgs e)
        {
            txbSecond.Text = (int.Parse(txbSecond.Text) + 1).ToString();
            if (txbSecond.Text == "60")
            {
                txbSecond.Text = "0";
                txbMinute.Text = (int.Parse(txbMinute.Text) + 1).ToString();
            }
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
            if (tmr1.Enabled)
            {
                DialogResult ask = MessageBox.Show("Are you sure?", "Minesweeper", MessageBoxButtons.YesNo);
                if (ask == DialogResult.Yes)
                    ShowResult();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (tmr1.Enabled == true)
            {
                DialogResult ask = MessageBox.Show("Are you sure?", "Minesweeper", MessageBoxButtons.YesNo);
                if (ask == DialogResult.Yes)
                    clickHome = true;
            }
            else
                clickHome = true;
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            if (tmr1.Enabled == true)
            {
                DialogResult ask = MessageBox.Show("Are you sure?", "Minesweeper", MessageBoxButtons.YesNo);
                if (ask == DialogResult.Yes)
                {
                    Clear();
                    Play();
                }
            }
            else
            {
                Clear();
                Play();
            }
        }

    }
}
