using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orocess
{
    public partial class msgbox : Form
    {
        private IntPtr HHook;
        private Random random = new Random();

        public msgbox()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Hide();

            timer1.Interval = 500; //コマ
            timer1.Enabled = true;
        }

        private void msgbox_Load(object sender, EventArgs e)
        {
            // フォームを非表示にする
            this.Hide();
            //タイトルバー非表示
            this.FormBorderStyle = FormBorderStyle.None;

            // フォームをランダムな位置に表示する
            Random random = new Random();
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int formWidth = this.Width;
            int formHeight = this.Height;

            int posX = random.Next(0, screenWidth - formWidth);
            int posY = random.Next(0, screenHeight - formHeight);

            this.Location = new System.Drawing.Point(posX, posY);

            SetHook(this);

            // ランダムなインデックスを生成
            int randomIndex = random.Next(messages.Length);
            //メッセージボックスを表示する
            DialogResult result = MessageBox.Show(messages[randomIndex],
                "",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        // ランダムなメッセージを格納する配列
        private string[] messages = {
            "What is the meaning of your existence?",
            "You don't exist.",
            "I will make you disappear.",
            "I will not forgive you even if you die. Never.",
            "Do not look behind you.",
            "It is time for children to go to bed. There must be something to do first.",
            "You are not well. Is it because your friends are not happy with you?",
            "Are you really surrounded by people? Maybe they are aliens.",
            "We acted first. Now it's our turn to kill you.",
            "You cannot escape. That way doesn't exist.",
            "It's all your fault. Everything."
        };

        private void SetHook(IWin32Window owner)
        {
            // フック設定
            IntPtr hInstance = WindowsAPI.GetWindowLong(this.Handle, (int)WindowsAPI.WindowLongParam.GWLP_HINSTANCE);
            IntPtr threadId = WindowsAPI.GetCurrentThreadId();
            HHook = WindowsAPI.SetWindowsHookEx((int)WindowsAPI.HookType.WH_CBT, new WindowsAPI.HOOKPROC(CBTProc), hInstance, threadId);
        }

        private IntPtr CBTProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode == (int)WindowsAPI.HCBT.HCBT_ACTIVATE)
            {
                WindowsAPI.RECT rectOwner;
                WindowsAPI.RECT rectMsgBox;
                int x, y;

                // オーナーウィンドウの位置と大きさを取得
                WindowsAPI.GetWindowRect(this.Handle, out rectOwner);
                // MessageBoxの位置と大きさを取得
                WindowsAPI.GetWindowRect(wParam, out rectMsgBox);

                // MessageBoxの表示位置を計算
                x = rectOwner.Left + (rectOwner.Width - rectMsgBox.Width) / 2;
                y = rectOwner.Top + (rectOwner.Height - rectMsgBox.Height) / 2;

                //MessageBoxの位置を設定
                WindowsAPI.SetWindowPos(wParam, 0, x, y, 0, 0,
                  (uint)(WindowsAPI.SetWindowPosFlags.SWP_NOSIZE | WindowsAPI.SetWindowPosFlags.SWP_NOZORDER | WindowsAPI.SetWindowPosFlags.SWP_NOACTIVATE));

                // フック解除
                WindowsAPI.UnhookWindowsHookEx(HHook);
            }
            // 次のプロシージャへのポインタ
            return WindowsAPI.CallNextHookEx(HHook, nCode, wParam, lParam);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            msgbox randam = new msgbox();
            randam.Show();
        }
    }
}
