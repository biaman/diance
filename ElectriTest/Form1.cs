using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ElectriTest.KeyBoardHookLib;

namespace ElectriTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private KeyBoardHookLib _keyBoardHook = null;
        

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            _keyBoardHook = new KeyBoardHookLib();        
            _keyBoardHook.InstallHook(this.OnKeyPre);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_keyBoardHook != null)
                _keyBoardHook.UninstallHook();
        }
        //客户端键盘捕捉事件
        public void OnKeyPre(KeyBoardHookLib.HookStruct hookStruct, out bool handle)
        {
            handle = false;//预设不拦截
            if (hookStruct.vkCode == 91)//拦截左win键
            {
                handle = true;
            }
            if (hookStruct.vkCode == 92)//右win
            {
                handle = true;
            }
            if (hookStruct.vkCode == (int)Keys.Escape && (int)Control.ModifierKeys == (int)Keys.Control)
            {
                handle = true;
            }
            if (hookStruct.vkCode == (int)Keys.F4 && (int)Control.ModifierKeys == (int)Keys.Alt) ;
            {
                handle = true;
            }
            if (hookStruct.vkCode == (int)Keys.F1)
            {
                handle = true;
            }
            if ((int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Alt + (int)Keys.Delete)
            {
                handle = true;
            }
            if (hookStruct.vkCode >= (int)Keys.A && hookStruct.vkCode <= (int)Keys.Z)
            {
                if (hookStruct.vkCode == (int)Keys.B)
                    hookStruct.vkCode = (int)Keys.None;
                handle = true;
            }
            Keys key = (Keys)hookStruct.vkCode;
            label1.Text = "你按下了：" + (key == Keys.None ? "" : key.ToString());
        }
    }
    }
