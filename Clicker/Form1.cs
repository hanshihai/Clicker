using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clicker
{
    public partial class Main : Form
    {
        System.Threading.Thread _backendThread = null;

        int X = 0;
        int Y = 0;
        int duration = 5;
        int timer = 1000;

        [System.Runtime.InteropServices.DllImport("User32")]
        public extern static void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);
        [System.Runtime.InteropServices.DllImport("User32")]
        public extern static void SetCursorPos(int x, int y);
        [System.Runtime.InteropServices.DllImport("User32")]
        public extern static bool GetCursorPos(out POINT p);
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }
        public enum MouseEventFlags
        {
            Move = 0x0001, //移动鼠标
            LeftDown = 0x0002,//模拟鼠标左键按下
            LeftUp = 0x0004,//模拟鼠标左键抬起
            RightDown = 0x0008,//鼠标右键按下
            RightUp = 0x0010,//鼠标右键抬起
            MiddleDown = 0x0020,//鼠标中键按下 
            MiddleUp = 0x0040,//中键抬起
            Wheel = 0x0800,
            Absolute = 0x8000//标示是否采用绝对坐标
        }

        public Main()
        {
            InitializeComponent();
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            Stream fileStream = null;
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK) {
                try
                {
                    if ((fileStream = openFileDialog1.OpenFile()) != null)
                    {
                        StreamReader reader = new StreamReader(openFileDialog1.FileName, Encoding.ASCII);
                        executor = new Executor();
                        String content = reader.ReadLine();
                        while (content != null)
                        {
                            bool result = executor.add(content);
                            if (!result)
                            {
                                throw new Exception("There is error in the script: " + content);
                            }
                            content = reader.ReadLine();
                        }
                        this.textBox1.Text = "script is ready!";
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("eror when get script: " + ex.Message);
                }
                finally {
                    if (fileStream != null) {
                        fileStream.Close();
                    }
                }
            }
        }

        void threadExecute()
        {
            int maxTime = 50000;
            int run = 0;
            DateTime start = DateTime.Now;
            try
            {
                while (run < maxTime)
                {
                    DateTime current = DateTime.Now;
                    if (current.CompareTo(start.AddMinutes(duration)) <= 0)
                    {
                        int size = executor.getSize();
                        for (int i = 0; i < size; i++)
                        {
                            String[] line = executor.get(i);
                            if (line[0] != null)
                            {
                                if (executor.Go().Equals(line[0]))
                                {
                                    if (line.Length != 3)
                                    {
                                        int lineNumber = i + 1;
                                        throw new Exception("script error without enough parametersin line: " + lineNumber);
                                    }
                                    else
                                    {
                                        go(line[1], line[2]);
                                    }

                                }
                                else if (executor.Click().Equals(line[0]))
                                {
                                    click();
                                }
                                else if (executor.Sleep().Equals(line[0]))
                                {
                                    if (line.Length != 2)
                                    {
                                        int lineNumber = i + 1;
                                        throw new Exception("script error without enough parametersin line: " + lineNumber);
                                    }
                                    else {
                                        sleep(line[1]);
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                    System.Threading.Thread.Sleep(timer);
                    run++;
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Error reports out from script." + ex.Message);
            }

            _backendThread = null;
        }

        void go(String x, String y) {
            X = Int32.Parse(x);
            Y = Int32.Parse(y);
            SetCursorPos(X, Y);
        }

        void click() {
            mouse_event((int)(MouseEventFlags.LeftDown | MouseEventFlags.Absolute), X, Y, 0, IntPtr.Zero);
            mouse_event((int)(MouseEventFlags.LeftUp | MouseEventFlags.Absolute), X, Y, 0, IntPtr.Zero);
        }

        void sleep(String time) {
            int t = Int32.Parse(time);
            System.Threading.Thread.Sleep(t);
        }

        private void Show_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "Starting script";
            if (_backendThread == null)
            {
                _backendThread = new System.Threading.Thread(new System.Threading.ThreadStart(threadExecute));
                _backendThread.IsBackground = true;
                _backendThread.Start();
            }
            this.textBox1.Text = "End script";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F12)
            {
                if (_backendThread != null)
                {
                    _backendThread.Abort();
                    _backendThread = null;
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            StringBuilder result = new StringBuilder();
            int size = executor.getSize();
            for (int i = 0; i < size; i++) {
                String[] line = executor.get(i);
                StringBuilder builder = new StringBuilder();
                foreach (String s in line) {
                    builder.Append(s + " ");
                }
                result.Append(builder.ToString() + System.Environment.NewLine);
            }
            this.textBox1.Text = result.ToString();
        }
    }
}
