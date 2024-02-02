using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Orocess
{
    public partial class main : Form
    {
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        public main()
        {
            InitializeComponent();
            DialogResult result = MessageBox.Show("Does it really start? This software was created to destroy your PC. If you run it, your PC will not boot properly. Running this software is at your own risk. Do you really want to run this software? No kidding.",
    "Warning",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Exclamation,
    MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {

            }
            else if (result == DialogResult.No)
            {
                Application.Exit();
                this.Close();
                Environment.Exit(0);
            }

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            deep deep = new deep();
            deep.Show();
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
    }
}
