using Gecko;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        Random rand = new Random();

        // những biến thông số sẽ truyền vào cửa sổ play
        int widthT = 0; // width of table
        int heightT = 0; // height of table
        int mine = 0; // number of mines
        int modeP; // chế độ chơi: 1 người hoặc 2 người

        // Biền dùng để kiểm tra và lấy dữ liệu từ server 
        bool checkGetData = false;
        int[,] serverData = new int[5,5];
        //  status   x   y   flag    tinHieu
        //  0        0   0   0       0        //0
        //  0        0   0   0       0        //1
        //  0        0   0   0       0        //2
        // whoWin          0/1/2              //3
        // statusRoom      0/1/2/3            //4

        bool isConnectedToServer = false; // Kiểm tra xem đã kết nối tới server chưa
        bool isWentToRoom = false; // Kiểm tra đã vào phòng chưa
        bool is2PlayerOnline = false;
        bool isRoomBoss = false;
        bool isResetServer = false;
        int flag = 0;
        int yourNumber, enemyNumber;

        FormCustom frmCustom;
        FormPlay frmPlay;
        FormPlay2Player frmPlay2Player;
        WaitingOther frmWaitingOther;

        private void btn_Click(object sender, EventArgs e)
        {

            GetScore();

        }

        public Form1()
        {
            InitializeComponent();
            Xpcom.Initialize("Firefox");
            frmCustom = new FormCustom();
            tmr.Start();
            GetScore();
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            Play(9, 9, 10);
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            Play(16, 16, 40);
        }

        private void btnExpert_Click(object sender, EventArgs e)
        {
            Play(16, 30, 90);
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            frmCustom.Show();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (CheckIP())
            {
                //wbInput.Navigate("http://" + txbIP.Text + "/minesweeper/input.php");
                //isResetServer = true;
                isConnectedToServer = true; 
                //txbIP.Visible = false;
                //btnConnect.Visible = false;
                checkGetData = true; // Bắt đầu get dữ liệu

                btnEasy.Visible = true;
                btnMedium.Visible = true;
                btnExpert.Visible = true;
                btnCustom.Visible = true;
            }
            else
            {
                MessageBox.Show("Cannot connect to server! Please check the IP.", "Minesweeper", MessageBoxButtons.OK);
            }
        }

        void Play(int hei, int wid, int mn)
        {
            widthT = wid;
            heightT = hei;
            mine = mn;
            flag = mine / 2;

            //if (checkGetData)
            //{
            //    if ((serverData[4, 0] == 3 || serverData[4, 0] == 2) && !wbInput.IsBusy)
            //        MessageBox.Show("You cannot create room now", "Minesweeper", MessageBoxButtons.OK);
            //    else if (serverData[4, 0] == 0 && !wbInput.IsBusy)
            //    {
            //        isWentToRoom = true;
            //        isRoomBoss = true;

            //        WaitingRoom();
            //    }
            //}
            //else
                Play1Player();
        }

        void Play1Player()
        {
            frmPlay = new FormPlay();
            if (txbName.Text == "")
                txbName.Text = "Anonymous";
            frmPlay.txbName.Text = txbName.Text;
            frmPlay.txbHeightT.Text = heightT.ToString();
            frmPlay.txbWidthT.Text = widthT.ToString();
            frmPlay.txbMines.Text = mine.ToString();
            frmPlay.Play();
            frmPlay.Show();
        }

        void WaitingRoom()
        {
            if (isRoomBoss)
            {
                string jsTmp = IdxMineStr();
                string js = @"set_idxMineStr('" + jsTmp + @"');
                          document.getElementsByName('stt2')[0].value = '';   

                          document.getElementsByName('stt1')[0].value = '1'; 
                          document.getElementsByName('flag1')[0].value = '" + mine / 2 + @"';

                          document.getElementsByName('x3')[0].value = '" + heightT + @"'; 
                          document.getElementsByName('y3')[0].value = '" + widthT + @"';
                          document.getElementsByName('flag3')[0].value = '" + mine + @"';
                            
                          document.getElementsByName('statusRoom')[0].value = '1'; 

                          document.getElementsByName('send')[0].click(); ";
                ExecuteJS(js);

                yourNumber = 1;
                ShowWaiting();
            }
            else
                Play2Player();
        }

        void Play2Player()
        {
            frmPlay2Player = new FormPlay2Player();
            frmPlay2Player.txbHeightT.Text = heightT.ToString();
            frmPlay2Player.txbWidthT.Text = widthT.ToString();
            frmPlay2Player.txbMines.Text = mine.ToString();
            frmPlay2Player.txbFlag.Text = flag.ToString();
            frmPlay2Player.txbYourNumber.Text = yourNumber.ToString();
            //frmPlay2Player.txbIP.Text = txbIP.Text;
            frmPlay2Player.Play();
            frmPlay2Player.Show();
        }

        void ShowWaiting()
        {
            frmWaitingOther = new WaitingOther();
            frmWaitingOther.Show();
        }

        // timer
        private void tmr_Tick(object sender, EventArgs e)
        {
            if (yourNumber == 1)
                enemyNumber = 2;
            else
                enemyNumber = 1;

            // Kiểm tra hiện thị các cửa sổ
            if ((frmPlay == null || frmPlay.Visible == false) &&
                (frmCustom == null || frmCustom.Visible == false) &&
                (frmWaitingOther == null || frmWaitingOther.Visible == false) &&
                (frmPlay2Player == null || frmPlay2Player.Visible == false))
            {
                frmPlay = null;
                frmWaitingOther = null;
                frmPlay2Player = null;
                this.Visible = true;
            }
            else
                this.Visible = false;
            if (frmPlay2Player != null)
            {
                if (frmPlay2Player.Visible == true)
                {
                    if (frmWaitingOther != null)
                        frmWaitingOther.Visible = false;
                }
            }

            // Nếu ở form Custom ấn Play
            if (frmCustom.play)
            {
                frmCustom.play = false;
                Play(frmCustom.heightT, frmCustom.widthT, frmCustom.mine);
            }

            // Kiểm tra chế độ chơi
            if (ModePlay.SelectedIndex == 0)
                modeP = 1;
            else
                modeP = 2;


            if (modeP == 1)
            {
                //txbIP.Visible = false;
                //btnConnect.Visible = false;
                txbName.Visible = true;
                lbYourName.Visible = true;
                this.Width = 910;

                btnEasy.Visible = true;
                btnMedium.Visible = true;
                btnExpert.Visible = true;
                btnCustom.Visible = true;

                checkGetData = false; // Tắt get dữ liệu
            } // Nếu chế độ chơi là 1 player
            else if (modeP == 2)
            {
                if (!CheckInternet())
                {
                    modeP = 1;
                    ModePlay.SelectedIndex = 0;
                    MessageBox.Show("No internet!", "Minesweeper", MessageBoxButtons.OK);
                }
                else
                {
                    if (!isConnectedToServer)
                    {
                        //txbIP.Visible = true;
                        //btnConnect.Visible = true;
                        btnEasy.Visible = false;
                        btnMedium.Visible = false;
                        btnExpert.Visible = false;
                        btnCustom.Visible = false;
                    }
                    else
                        checkGetData = true;

                    txbName.Visible = false;
                    lbYourName.Visible = false;
                    this.Width = 466;
                }

            } // Nếu chế độ chơi là 2 players

            // Get data liên tục từ server 
            //if (checkGetData)
            //{
            //    // Lấy dữ liệu và đổ vào mảng serverData 
            //    if (!wbInput.IsBusy)
            //    {
            //        using (WebClient client = new WebClient())
            //        {
            //            string str = client.DownloadString("http://" + txbIP.Text + "/minesweeper/get.php");

            //            // Lấy từng dòng
            //            GetDataAtLine(str, 1);
            //            GetDataAtLine(str, 2);
            //            GetDataAtLine(str, 3);
            //            GetDataAtLine(str, 4);
            //            GetDataAtLine(str, 5);
            //        }
            //    }

            //    // Khi chưa vào phòng
            //    if (!isWentToRoom)
            //    {
            //        if (serverData[4, 0] == 0 && !wbInput.IsBusy) // Chưa có ai
            //        {
            //            is2PlayerOnline = false;
            //            isWentToRoom = false;
            //        }
            //        else if (serverData[4, 0] == 1 && !wbInput.IsBusy) // Nếu có rồi thì vào phòng
            //        {
            //            is2PlayerOnline = true;
            //            isRoomBoss = false;
            //            isWentToRoom = true; // Báo là đã vào phòng

            //            heightT = serverData[2, 1];
            //            widthT = serverData[2, 2];
            //            mine = serverData[2, 3];
            //            flag = mine / 2;

            //            if (serverData[0, 0] == 0)
            //            {
            //                string js = @"document.getElementsByName('stt2')[0].value = '';
            //                              document.getElementsByName('stt3')[0].value = '';

            //                              document.getElementsByName('stt1')[0].value = '1'; 
            //                              document.getElementsByName('flag1')[0].value = '" + (serverData[2, 3] / 2) + @"';
            //                              document.getElementsByName('statusRoom')[0].value = '2'; 
            //                              document.getElementsByName('send')[0].click()";
            //                ExecuteJS(js);

            //                yourNumber = 1;
            //            }
            //            else if (serverData[1, 0] == 0)
            //            {
            //                string js = @"document.getElementsByName('stt1')[0].value = ''; 
            //                              document.getElementsByName('stt3')[0].value = '';

            //                              document.getElementsByName('stt2')[0].value = '1'; 
            //                              document.getElementsByName('flag2')[0].value = '" + (serverData[2, 3] / 2) + @"';
            //                              document.getElementsByName('statusRoom')[0].value = '2'; 
            //                              document.getElementsByName('send')[0].click()";
            //                ExecuteJS(js);

            //                yourNumber = 2;
            //            }
            //            Play2Player();
            //        }
            //    }

            //    // Vào phòng
            //    if (isRoomBoss && serverData[4, 0] == 2)
            //    {
            //        if (serverData[2, 1] != 0 && serverData[2, 2] != 0 && !wbInput.IsBusy) // kiểm tra xem width và height đã được set chưa
            //        {
            //            is2PlayerOnline = true;
            //            isRoomBoss = false;

            //            heightT = serverData[2, 1];
            //            widthT = serverData[2, 2];
            //            mine = serverData[2, 3];
            //            flag = mine / 2;
            //            Play2Player();
            //        }
            //    }

            //    //Nghe dữ liệu từ đối phương - Truyền dữ liệu khi người này vừa chơi
            //    if (is2PlayerOnline == true && !wbInput.IsBusy)
            //    {
            //        // Nghe đối phương
            //        if (serverData[enemyNumber - 1, 4] != 0 && !wbInput.IsBusy)
            //        {
            //            // Thực hiện ấn boxBtn ở form Play2Player
            //            if (serverData[enemyNumber - 1, 4] == 1)
            //                frmPlay2Player.getXY_2_click(serverData[enemyNumber - 1, 1], serverData[enemyNumber - 1, 2], serverData[enemyNumber - 1, 3]);
            //            else if (serverData[enemyNumber - 1, 4] == 2)
            //                frmPlay2Player.getXY_2_RightClick(serverData[enemyNumber - 1, 1], serverData[enemyNumber - 1, 2], serverData[enemyNumber - 1, 3]);

            //            // Chuyển đổi tín hiệu về 0
            //            int flagTmp = 0;
            //            if (yourNumber == 1)
            //                flagTmp = frmPlay2Player.flag1;
            //            else if (yourNumber == 2)
            //                flagTmp = frmPlay2Player.flag2;

            //            serverData[enemyNumber - 1, 4] = 0;
            //            string js = @"document.getElementsByName('stt" + yourNumber + @"')[0].value = '';
            //                          document.getElementsByName('stt3')[0].value = '';
            //                          document.getElementsByName('stt" + enemyNumber + @"')[0].value = '1';
            //                          document.getElementsByName('flag" + enemyNumber + @"')[0].value = '" + flagTmp + @"';
            //                          document.getElementsByName('tinHieu" + enemyNumber + @"')[0].value = '0';
            //                          document.getElementsByName('send')[0].click(); ";
            //            ExecuteJS(js);
            //        }

            //        //Truyền
            //        if (frmPlay2Player != null && frmPlay2Player.signal != 0 && !wbInput.IsBusy)
            //        {
            //            int flagTmp = 0;
            //            if (yourNumber == 1)
            //                flagTmp = frmPlay2Player.flag1;
            //            else if (yourNumber == 2)
            //                flagTmp = frmPlay2Player.flag2;

            //            string js = @"document.getElementsByName('stt" + enemyNumber + @"')[0].value = '';
            //                          document.getElementsByName('stt" + yourNumber + @"')[0].value = '1';
            //                          document.getElementsByName('x" + yourNumber + @"')[0].value = '" + frmPlay2Player.xPlay + @"';
            //                          document.getElementsByName('y" + yourNumber + @"')[0].value = '" + frmPlay2Player.yPlay + @"';
            //                          document.getElementsByName('flag" + yourNumber + @"')[0].value = '" + flagTmp + @"';
            //                          document.getElementsByName('tinHieu" + yourNumber + @"')[0].value = '" + frmPlay2Player.signal + @"';
            //                          document.getElementsByName('send')[0].click(); ";
            //            frmPlay2Player.signal = 0;
            //            ExecuteJS(js);
            //        }

            //        // Nghe kiểm tra thắng thua ở server xong thì gửi thông báo đến form 2Player
            //        if (serverData[3, 0] != 0 && frmPlay2Player.numberWon == 0 && !wbInput.IsBusy)
            //        {
            //            if (serverData[3, 0] == 1)
            //            {
            //                if (yourNumber == 1)
            //                    frmPlay2Player.Won(serverData[3, 1], serverData[3, 2]);
            //                else
            //                    frmPlay2Player.Lose(serverData[3, 1], serverData[3, 2]);
            //            }
            //            else if (serverData[3, 0] == 2)
            //            {
            //                if (yourNumber == 2)
            //                    frmPlay2Player.Won(serverData[3, 1], serverData[3, 2]);
            //                else
            //                    frmPlay2Player.Lose(serverData[3, 1], serverData[3, 2]);
            //            }
            //            frmPlay2Player.numberWon = 3;

            //            //// Reset giá trị whoWin
            //            //string js = @"document.getElementsByName('stt1')[0].value = '';
            //            //              document.getElementsByName('stt2')[0].value = '';
            //            //              document.getElementsByName('stt3')[0].value = '';
            //            //              document.getElementsByName('whoWin')[0].value = '0';
            //            //              document.getElementsByName('xWin')[0].value = '0';
            //            //              document.getElementsByName('yWin')[0].value = '0';                  
            //            //              document.getElementsByName('send')[0].click(); ";
            //            //ExecuteJS(js);
            //        }
            //    }

            //    // Kiểm tra thắng thua ở form 2Player xong thì gửi lên server 
            //    if (frmPlay2Player != null && frmPlay2Player.numberWon != 0 && frmPlay2Player.numberWon != 3 && !wbInput.IsBusy)
            //    {
            //        string js = @"document.getElementsByName('stt1')[0].value = '';
            //                  document.getElementsByName('stt2')[0].value = '';
            //                  document.getElementsByName('stt3')[0].value = '';
            //                  document.getElementsByName('whoWin')[0].value = '" + frmPlay2Player.numberWon + @"';
            //                  document.getElementsByName('xWin')[0].value = '" + frmPlay2Player.xWon + @"';
            //                  document.getElementsByName('yWin')[0].value = '" + frmPlay2Player.yWon + @"';
            //                  document.getElementsByName('send')[0].click(); ";
            //        ExecuteJS(js);
            //        frmPlay2Player.numberWon = 0;
            //    }
            //}

            // Khi ở form Waiting ấn nút Home
            if (frmWaitingOther != null && frmWaitingOther.clickHome)
            {
                frmWaitingOther.clickHome = false;
                frmWaitingOther.Visible = false;
                OutRoom();
            }

            // Khi ở form Play ấn nut Home
            if (frmPlay != null && frmPlay.clickHome)
            {
                frmPlay.clickHome = false;
                frmPlay.Hide();

                // Ghi vào số điểm mới 
                if (!(frmPlay.txbMinute.Text == "00" && frmPlay.txbSecond.Text == "00"))
                {
                    if (frmPlay.txbScore.Text != "0")
                    {
                        string[] dtTmp = File.ReadAllLines("score.txt");
                        string[] dt = new string[dtTmp.Length + 3];

                        for (int i = 0; i < dtTmp.Length; i++)
                            dt[i] = dtTmp[i];

                        dt[dtTmp.Length] = frmPlay.txbName.Text;
                        dt[dtTmp.Length + 1] = frmPlay.txbScore.Text;
                        if (frmPlay.txbSecond.Text.Length == 1)
                            frmPlay.txbSecond.Text = "0" + frmPlay.txbSecond.Text;
                        dt[dtTmp.Length + 2] = frmPlay.txbMinute.Text + ":" + frmPlay.txbSecond.Text;
                        File.WriteAllLines("score.txt", dt);

                        GetScore();
                    }
                }

                frmPlay.Clear();
            }

            // Khi ở form Play2Player ấn nút Home
            if (frmPlay2Player != null && frmPlay2Player.clickHome)
            {
                frmPlay2Player.clickHome = false;
                frmPlay2Player.Visible = false;
                OutRoom();
            }

            // Khi ở form Play2Player ấn nút Give up
            if (frmPlay2Player != null && frmPlay2Player.clickGiveUp)
            {
                frmPlay2Player.clickGiveUp = false;

                // Gửi tín hiệu đầu hàng lên server (tinHieu = 3)
                GiveUp();
            }

            // Enable nút Home và Give up ở form Play2Player
            if (frmPlay2Player != null && frmPlay2Player.tmr1.Enabled)
            {
                frmPlay2Player.btnHome.Enabled = false;
                frmPlay2Player.btnGiveUp.Enabled = true;
            }
            else if (frmPlay2Player != null && frmPlay2Player.tmr1.Enabled == false)
            {
                frmPlay2Player.btnHome.Enabled = true;
                frmPlay2Player.btnGiveUp.Enabled = false;
            }

        }

        void GetScore()
        {
            string[] dt = File.ReadAllLines("score.txt");
            string[,] dt2 = new string[dt.Length / 3, 3];
            for (int i = 0; i < dt.Length; i=i+3)
            {
                dt2[i / 3, 0] = dt[i];
                dt2[i / 3, 1] = dt[i + 1];
                dt2[i / 3, 2] = dt[i + 2];
            }

            int rowCountTmp = dtScore.RowCount;
            for (int i=0; i< rowCountTmp; i++)
                dtScore.Rows.Remove(dtScore.Rows[0]);

            for (int i = 0; i < dt2.GetLength(0); i++)
                dtScore.Rows.Add(dt2[i, 0], int.Parse(dt2[i, 1]), dt2[i, 2]);

            dtScore.Sort(dtScore.Columns[1], ListSortDirection.Descending);
            if (dtScore.RowCount != 0)
                dtScore.Rows[0].Selected = true;
        }

        void OutRoom()
        {
            //isWentToRoom = false;
            //isRoomBoss = false;
            //is2PlayerOnline = false;

            //int statusRoom = 2;
            //if (serverData[4, 0] == 2 && !wbInput.IsBusy)
            //    statusRoom = 3;
            //else if ((serverData[4, 0] == 3 || serverData[4, 0] == 1) && !wbInput.IsBusy)
            //    statusRoom = 0;

            //string js = @"document.getElementsByName('stt" + yourNumber + @"')[0].value = '0';
            //              document.getElementsByName('x" + yourNumber + @"')[0].value = '0';
            //              document.getElementsByName('y" + yourNumber + @"')[0].value = '0';
            //              document.getElementsByName('flag" + yourNumber + @"')[0].value = '0';
            //              document.getElementsByName('tinHieu" + yourNumber + @"')[0].value = '0';

            //              document.getElementsByName('stt" + enemyNumber + @"')[0].value = '';

            //              document.getElementsByName('x3')[0].value = '0'; 
            //              document.getElementsByName('y3')[0].value = '0'; 
            //              document.getElementsByName('flag3')[0].value = '0'; 
                
            //              document.getElementsByName('whoWin')[0].value = '0'; 
            //              document.getElementsByName('xWin')[0].value = '0'; 
            //              document.getElementsByName('yWin')[0].value = '0'; 
            //              document.getElementsByName('statusRoom')[0].value = '" + statusRoom + @"';

            //              document.getElementsByName('send')[0].click(); ";
            //ExecuteJS(js);
        }

        void GiveUp()
        {
            string js = @"document.getElementsByName('stt1')[0].value = '';
                          document.getElementsByName('stt2')[0].value = '';
                          document.getElementsByName('stt3')[0].value = '';
                          document.getElementsByName('whoWin')[0].value = '"+ enemyNumber + @"';
                          document.getElementsByName('xWin')[0].value = '-1';
                          document.getElementsByName('yWin')[0].value = '-1';
                          document.getElementsByName('send')[0].click(); ";
            ExecuteJS(js);
        }

        int[,] CreateIdxMine()
        {
            int[,] mineIdx = new int[mine, 2];
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

            return mineIdx;
        }

        string IdxMineStr()
        {
            // Gửi vị trí của mìn lên server 
            int[,] mineIdx = CreateIdxMine();
            string idxMineStr = "";
            for (int i = 0; i < mine; i++)
                idxMineStr += mineIdx[i, 0] + "-" + mineIdx[i, 1] + @"..";

            return idxMineStr;
        }

        void ExecuteJS(string js)
        {
            //using (AutoJSContext context = new AutoJSContext(wbInput.Window))
            //{
            //    string result;
            //    context.EvaluateScript(js, out result);
            //}
        }

        void GetDataAtLine(string str, int line)
        {
            string strTmp = "";
            for (int i = str.IndexOf(line + @"' value='") + 10; str[i] != '\''; i++)
                strTmp += str[i];
            strTmp = " " + strTmp + " ";

            int order = 0;
            for (int i = 0; i < strTmp.Length; i++)
            {
                if (strTmp[i] == ' ')
                {
                    int k = 1;
                    string strTmpData = "";
                    while (i + k < strTmp.Length && strTmp[i + k] != ' ')
                    {
                        strTmpData += strTmp[i + k];
                        k++;
                    }

                    if (strTmpData != "")
                        serverData[line - 1, order] = int.Parse(strTmpData);
                    order++;
                }
            }
        }

        // Check internet
        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        bool CheckInternet()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }

        //Check IP
        bool CheckIP()
        {
            //try
            //{
            //    using (var client = new WebClientWithTimeout())
            //        using (client.OpenRead("http://" + txbIP.Text))
            //            return true;

            //}
            //catch
            //{
            //    return false;
            //}
            return false;
        }

        private void wbInput_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            // Khi mới vào thì reset server 
            if (isResetServer)
            {
                isResetServer = false;
                string js = @"document.getElementsByName('stt1')[0].value = '0';
                          document.getElementsByName('x1')[0].value = '0';
                          document.getElementsByName('y1')[0].value = '0';
                          document.getElementsByName('flag1')[0].value = '0';
                          document.getElementsByName('tinHieu1')[0].value = '0';

                          document.getElementsByName('stt2')[0].value = '0';
                          document.getElementsByName('x2')[0].value = '0';
                          document.getElementsByName('y2')[0].value = '0';
                          document.getElementsByName('flag2')[0].value = '0';
                          document.getElementsByName('tinHieu2')[0].value = '0';

                          document.getElementsByName('x3')[0].value = '0'; 
                          document.getElementsByName('y3')[0].value = '0'; 
                          document.getElementsByName('flag3')[0].value = '0'; 
                
                          document.getElementsByName('whoWin')[0].value = '0'; 
                          document.getElementsByName('xWin')[0].value = '0'; 
                          document.getElementsByName('yWin')[0].value = '0'; 
                          document.getElementsByName('statusRoom')[0].value = '0';

                          document.getElementsByName('send')[0].click(); ";
                ExecuteJS(js);
            }
        }

        public class WebClientWithTimeout : WebClient
        {
            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest wr = base.GetWebRequest(address);
                wr.Timeout = 2000; // timeout in milliseconds (ms)
                return wr;
            }
        }
    }
}
