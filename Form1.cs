using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.IO;

namespace WordCards
{
    public partial class frmWordCards : Form
    {
        /// <summary>
        /// 單字清單
        /// </summary>
        WordCollection _WordList = new WordCollection();

        /// <summary>
        /// Windows Media Player 播放器
        /// </summary>
        WindowsMediaPlayer wmp = new WindowsMediaPlayer();

        // 避免硬編碼，動態取得應用程式執行路徑
        string strWordFile;

        /// <summary>
        /// 是否自動播放
        /// </summary>
        bool isPlay = false;

        // --- 動態縮放需要的變數與結構 ---
        private struct ControlInfo
        {
            public int Left;
            public int Top;
            public int Width;
            public int Height;
            public float FontSize;
        }

        private Dictionary<Control, ControlInfo> _controlsInfo = new Dictionary<Control, ControlInfo>();
        private int _originalFormWidth;
        private int _originalFormHeight;
        // ---------------------------------

        public frmWordCards()
        {
            InitializeComponent();
            // 初始化單字檔的完整路徑
            strWordFile = Path.Combine(Application.StartupPath, "WordCards.txt");

            // 綁定視窗大小改變的事件
            this.Resize += new System.EventHandler(this.frmWordCards_Resize);
        }

        private void frmWordCards_Load(object sender, EventArgs e)
        {
            string[] lines;
            // 若單字檔存在
            if (File.Exists(strWordFile))
            {
                lines = File.ReadAllLines(strWordFile, Encoding.UTF8);
            }
            else
            {
                MessageBox.Show($"找不到單字檔\n{strWordFile}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            // 載入單字檔
            this._WordList.LoadFromStringArray(lines);
            if (this._WordList.Count > 0)
            {
                // 更新單字清單
                UpdateWordList();
                // 顯示第一個單字
                this.ShowWord(_WordList[0]);
                tsslMessage.Text = $"單字數量：{_WordList.Count}";
            }

            // 在表單載入的最後，記錄所有控制項的初始尺寸
            RecordInitialSizes();
        }

        /// <summary>
        /// 顯示單字
        /// </summary>
        private void ShowWord(WordItem word)
        {
            txtWord.Text = word.Word;
            txtPhonogram.Text = word.Phonogram;
            txtExplain.Text = word.Explain;
        }

        private void UpdateWordList()
        {
            lstWordList.BeginUpdate(); // 開始更新
            lstWordList.Items.Clear();
            foreach (WordItem item in this._WordList)
            {
                lstWordList.Items.Add(item);
            }
            lstWordList.EndUpdate(); // 結束更新
        }

        /// <summary>
        /// 播放單字音檔
        /// </summary>
        public void PlayWord(WordItem word)
        {
            // 避免硬編碼，確保音效檔路徑正確
            string soundPath = Path.Combine(Application.StartupPath, word.SoundPath);

            // 判斷音效檔是否存在
            if (File.Exists(soundPath))
            {
                // 播放單字音檔
                wmp.URL = soundPath;
                wmp.settings.autoStart = false;
                wmp.settings.mute = false;
                wmp.controls.play();
            }
            else
            {
                tsslMessage.Text = $"找無 {word.SoundPath} 音效檔";
            }
        }

        /// <summary>
        /// 播放目前選取的單字
        /// </summary>
        private void PlaySelectedWord()
        {
            // 判斷目前選的項目是否為空
            if (lstWordList.SelectedItem != null)
            {
                // 取得目前選取的單字索引
                int idx = lstWordList.SelectedIndex;
                // 顯示單字
                ShowWord(_WordList[idx]);
                // 播放單字的發音
                PlayWord(_WordList[idx]);
            }
        }

        private void lstWordList_Click(object sender, EventArgs e)
        {
            // 判斷是否自動播放
            if (isPlay == true)
            {
                btnAutoPlay.PerformClick(); // 點擊自動播放按鈕
            }

            // 判斷是否有選取項目
            if (lstWordList.SelectedItem != null)
            {
                if (lstWordList.SelectedItem.ToString().Length != 0)
                {
                    // 顯示並播放目前選取的單字
                    PlaySelectedWord();
                }
            }
        }

        /// <summary>
        /// 將單字清單的選項移到下一個
        /// </summary>
        private void NextWordList()
        {
            // 將焦點移到單字清單
            lstWordList.Focus();

            // 判斷目前選的下一項是否超過清單的項目數
            if (lstWordList.SelectedIndex + 1 >= lstWordList.Items.Count)
            {
                lstWordList.SelectedIndex = 0; // 如果超過就回到第一項
            }
            else
            {
                lstWordList.SelectedIndex++; // 如果沒有就選擇下一項
            }

            // 計算目前 lstWordList 顯示的行數
            int lstRows = lstWordList.Height / lstWordList.GetItemHeight(0);

            // 如果目前選的項目大於 lstRows / 2
            if (lstWordList.SelectedIndex >= lstRows / 2)
            {
                // 將 lstWordList 的選項保持在中間
                lstWordList.TopIndex = lstWordList.SelectedIndex - lstRows / 2;
            }
        }

        private void timPlayer_Tick(object sender, EventArgs e)
        {
            // 移到下一個單字
            NextWordList();
            // 顯示並播放目前選取的單字
            PlaySelectedWord();
        }

        private void btnAutoPlay_Click(object sender, EventArgs e)
        {
            // 將焦點移到單字清單
            lstWordList.Focus();
            // 若目前不是自動播放
            if (isPlay == false)
            {
                btnAutoPlay.Text = "Stop";
                isPlay = true;
                // 顯示並播放目前選取的單字
                PlaySelectedWord();
                timPlayer.Start();
            }
            else
            {
                btnAutoPlay.Text = "Play";
                isPlay = false;
                timPlayer.Stop();
            }
        }

        private void frmWordCards_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isPlay == true)
            {
                return;
            }

            switch (e.KeyChar)
            {
                case (char)Keys.Return:
                    // 當按下 Enter 時，播放下一個單字
                    NextWordList();
                    // 顯示並播放目前選取的單字
                    PlaySelectedWord();
                    e.Handled = true;
                    break;
                case (char)Keys.Space:
                    // 當按下 Space 時，重複播放目前單字
                    if (lstWordList.SelectedIndex >= 0)
                    {
                        // 顯示並播放目前選取的單字
                        PlaySelectedWord();
                    }
                    e.Handled = true;
                    break;
            }
        }

        private void lstWordList_DoubleClick(object sender, EventArgs e)
        {
            lstWordList.Focus();
            // 目前選取的索引
            int idx = lstWordList.SelectedIndex;
            frmEditWord edit = new frmEditWord(_WordList[idx]);
            DialogResult result = edit.ShowDialog(this);
            // 如果使用者按下 儲存 按鈕
            if (result == DialogResult.Yes)
            {
                // 顯示並播放目前選取的單字
                PlaySelectedWord();

                // 儲存單字
                _WordList.SaveToFile(strWordFile);
            }
        }

        // --- 以下為動態縮放邏輯實作 ---

        private void RecordInitialSizes()
        {
            _originalFormWidth = this.Width;
            _originalFormHeight = this.Height;
            RegisterControls(this);
        }

        private void RegisterControls(Control container)
        {
            foreach (Control c in container.Controls)
            {
                ControlInfo info;
                info.Left = c.Left;
                info.Top = c.Top;
                info.Width = c.Width;
                info.Height = c.Height;
                info.FontSize = c.Font.Size;

                _controlsInfo[c] = info;

                if (c.Controls.Count > 0)
                {
                    RegisterControls(c);
                }
            }
        }

        private void frmWordCards_Resize(object sender, EventArgs e)
        {
            ScaleControls();
        }

        private void ScaleControls()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                return;
            }
            if (_originalFormWidth == 0)
            {
                return;
            }
            if (_originalFormHeight == 0)
            {
                return;
            }

            float scaleX = (float)this.Width / _originalFormWidth;
            float scaleY = (float)this.Height / _originalFormHeight;

            float fontScale = scaleX;
            if (scaleY < scaleX)
            {
                fontScale = scaleY;
            }

            foreach (var pair in _controlsInfo)
            {
                Control c = pair.Key;
                ControlInfo info = pair.Value;

                c.Left = (int)(info.Left * scaleX);
                c.Top = (int)(info.Top * scaleY);
                c.Width = (int)(info.Width * scaleX);
                c.Height = (int)(info.Height * scaleY);

                if (fontScale > 0)
                {
                    c.Font = new Font(c.Font.FontFamily, info.FontSize * fontScale, c.Font.Style);
                }
            }
        }
    }
}