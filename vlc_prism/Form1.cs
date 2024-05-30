using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vlc_prism {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            tb_1.Text = "";
            tb_2.Text = "";
            tb_3.Text = "";
            tb_4.Text = "";
            tb_5.Text = "";
            tb_6.Text = "";
            tb_7.Text = "";
            tb_8.Text = "";
            tb_9.Text = "";
            tb_10.Text = "";
            tb_11.Text = "";
            tb_12.Text = "";
            tb_13.Text = "";
            tb_14.Text = "";
            tb_15.Text = "";
            tb_16.Text = "";
            tb_17.Text = "";
            tb_18.Text = "";
            tb_19.Text = "";
            tb_20.Text = "";
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.RunWorkerAsync();
            backgroundWorker3.RunWorkerAsync();
            backgroundWorker4.RunWorkerAsync();
        }

        private string panel_prism_timeout = "";
        private string wo_prism_timeout = "";
        private string uid_prism_timeout = "";
        private string up_prism_timeout_sn = "";
        private string up_prism_timeout_result = "";
        private string up_prism_timeout_dataSummary = "";
        private string up_prism_timeout() {
            return TeamPrecision.PRISM.cResults.SaveTestResult(up_prism_timeout_sn, up_prism_timeout_result, up_prism_timeout_dataSummary);
        }
        private string GetPanel_prism_timeout() {
            return TeamPrecision.PRISM.cSNs.GetPanel_uid_VLC(wo_prism_timeout, uid_prism_timeout);
        }
        private string MatchUID_prism_timeout() {
            return TeamPrecision.PRISM.cSNs.SaveUID_VLC(wo_prism_timeout, panel_prism_timeout, uid_prism_timeout);
        }
        private string CheckStatus_prism_timeout() {
            string[] ff = TeamPrecision.PRISM.cSNs.CheckStatusSNv3(up_prism_timeout_sn, wo_prism_timeout, "FCT1");
            return ff[1];
        }
        public string function_timeout(Func<string> function, int timeout) {
            Task<string> task = Task.Run(function);
            if (task.Wait(timeout)) return task.Result;
            else return "over timeout";
        }

        private TextBox getTextbox(int num = 0) {
            TextBox bb = new TextBox();
            switch (num) {
                case 0: bb = tb_1; break;
                case 1: bb = tb_2; break;
                case 2: bb = tb_3; break;
                case 3: bb = tb_4; break;
                case 4: bb = tb_5; break;
                case 5: bb = tb_6; break;
                case 6: bb = tb_7; break;
                case 7: bb = tb_8; break;
                case 8: bb = tb_9; break;
                case 9: bb = tb_10; break;
                case 10: bb = tb_11; break;
                case 11: bb = tb_12; break;
                case 12: bb = tb_13; break;
                case 13: bb = tb_14; break;
                case 14: bb = tb_15; break;
                case 15: bb = tb_16; break;
                case 16: bb = tb_17; break;
                case 17: bb = tb_18; break;
                case 18: bb = tb_19; break;
                case 19: bb = tb_20; break;
            }
            return bb;
        }
        private SerialPort vlc_serial1 = new SerialPort();
        private SerialPort vlc_serial2 = new SerialPort();
        private SerialPort vlc_serial3 = new SerialPort();
        private SerialPort vlc_serial4 = new SerialPort();
        private cmdAr cmd = new cmdAr();
        private string[] comport = new string[20];
        private void button1_Click(object sender, EventArgs e) {
            button1.Enabled = false;
            for (int i = 0; i < 20; i++) {
                try { comport[i] = File.ReadAllText("../../config/vlc_port_" + (i + 1) + ".txt"); } catch { }
            }
            tb_1.Text = "";
            tb_2.Text = "";
            tb_3.Text = "";
            tb_4.Text = "";
            tb_5.Text = "";
            tb_6.Text = "";
            tb_7.Text = "";
            tb_8.Text = "";
            tb_9.Text = "";
            tb_10.Text = "";
            tb_11.Text = "";
            tb_12.Text = "";
            tb_13.Text = "";
            tb_14.Text = "";
            tb_15.Text = "";
            tb_16.Text = "";
            tb_17.Text = "";
            tb_18.Text = "";
            tb_19.Text = "";
            tb_20.Text = "";
            run1 = true;
            run2 = true;
            run3 = true;
            run4 = true;
            while (run1 | run2 | run3 | run4) DelaymS(100);
            button1.Enabled = true;
        }
        private List<int> vlc_rx1 = new List<int>();
        private bool vlc_flag_data1 = false;
        private void vlc_DataReceivedHandler1(object sender, SerialDataReceivedEventArgs e) {
            Thread.Sleep(50);
            int length = 0;
            while (true) {
                vlc_serial1 = (SerialPort)sender;
                try { length = vlc_serial1.BytesToRead; } catch { return; }
                if (length == 0) return;
                int buf = 0;
                for (int i = 0; i < length; i++) {
                    try { buf = vlc_serial1.ReadByte(); } catch { }
                    vlc_rx1.Add(buf);
                }
                Thread.Sleep(50);
                try { if (vlc_serial1.BytesToRead != 0) continue; } catch { return; }
                break;
            }
            vlc_serial1.DiscardInBuffer();
            vlc_serial1.DiscardOutBuffer();
            vlc_flag_data1 = true;
        }
        private List<int> vlc_rx2 = new List<int>();
        private bool vlc_flag_data2 = false;
        private void vlc_DataReceivedHandler2(object sender, SerialDataReceivedEventArgs e) {
            Thread.Sleep(50);
            int length = 0;
            while (true) {
                vlc_serial2 = (SerialPort)sender;
                try { length = vlc_serial2.BytesToRead; } catch { return; }
                if (length == 0) return;
                int buf = 0;
                for (int i = 0; i < length; i++) {
                    try { buf = vlc_serial2.ReadByte(); } catch { }
                    vlc_rx2.Add(buf);
                }
                Thread.Sleep(50);
                try { if (vlc_serial2.BytesToRead != 0) continue; } catch { return; }
                break;
            }
            vlc_serial2.DiscardInBuffer();
            vlc_serial2.DiscardOutBuffer();
            vlc_flag_data2 = true;
        }
        private List<int> vlc_rx3 = new List<int>();
        private bool vlc_flag_data3 = false;
        private void vlc_DataReceivedHandler3(object sender, SerialDataReceivedEventArgs e) {
            Thread.Sleep(50);
            int length = 0;
            while (true) {
                vlc_serial3 = (SerialPort)sender;
                try { length = vlc_serial3.BytesToRead; } catch { return; }
                if (length == 0) return;
                int buf = 0;
                for (int i = 0; i < length; i++) {
                    try { buf = vlc_serial3.ReadByte(); } catch { }
                    vlc_rx3.Add(buf);
                }
                Thread.Sleep(50);
                try { if (vlc_serial3.BytesToRead != 0) continue; } catch { return; }
                break;
            }
            vlc_serial3.DiscardInBuffer();
            vlc_serial3.DiscardOutBuffer();
            vlc_flag_data3 = true;
        }
        private List<int> vlc_rx4 = new List<int>();
        private bool vlc_flag_data4 = false;
        private void vlc_DataReceivedHandler4(object sender, SerialDataReceivedEventArgs e) {
            Thread.Sleep(50);
            int length = 0;
            while (true) {
                vlc_serial4 = (SerialPort)sender;
                try { length = vlc_serial4.BytesToRead; } catch { return; }
                if (length == 0) return;
                int buf = 0;
                for (int i = 0; i < length; i++) {
                    try { buf = vlc_serial4.ReadByte(); } catch { }
                    vlc_rx4.Add(buf);
                }
                Thread.Sleep(50);
                try { if (vlc_serial4.BytesToRead != 0) continue; } catch { return; }
                break;
            }
            vlc_serial4.DiscardInBuffer();
            vlc_serial4.DiscardOutBuffer();
            vlc_flag_data4 = true;
        }
        public static void DelaymS(int mS) {
            Stopwatch stopwatchDelaymS = new Stopwatch();
            stopwatchDelaymS.Restart();
            while (mS > stopwatchDelaymS.ElapsedMilliseconds) {
                if (!stopwatchDelaymS.IsRunning) stopwatchDelaymS.Start();
                Application.DoEvents();
            }
            stopwatchDelaymS.Stop();
        }
        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern int GetAsyncKeyState(int vKey);
        private static void discom(string cmd, string comport) {//enable disable//
            ManagementObjectSearcher objOSDetails2 = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'");
            ManagementObjectCollection osDetailsCollection2 = objOSDetails2.Get();
            foreach (ManagementObject usblist in osDetailsCollection2) {
                string arrport = usblist.GetPropertyValue("NAME").ToString();
                if (arrport.Contains(comport)) {
                    Process devManViewProc = new Process();
                    devManViewProc.StartInfo.FileName = "DevManView.exe";
                    devManViewProc.StartInfo.Arguments = "/" + cmd + " \"" + arrport + "\"";
                    devManViewProc.Start();
                    devManViewProc.WaitForExit();
                }
            }
        }
        private byte[] get_forMat_send(byte cmds, byte[] data_send) {
            cmdAr cmd = new cmdAr();
            List<byte> cmdData = new List<byte>();
            cmdData.Add(cmd.Head);
            cmdData.Add(cmds);
            byte[] intBytes = BitConverter.GetBytes(data_send.Length);
            intBytes[0] += 1;
            cmdData.Add(intBytes[0]);
            foreach (byte xx in data_send) cmdData.Add(xx);
            byte checkSum = 0;
            foreach (byte xx in cmdData) checkSum += xx;
            cmdData.Add(checkSum);
            byte[] sends = cmdData.ToArray();
            return sends;
        }
        private byte check_sum(List<int> dd) {
            byte ss = 0;
            for (int i = 0; i < dd.Count - 1; i++) ss += Convert.ToByte(dd[i]);
            return ss;
        }
        private void send_cmd1(byte cmds, byte[] data_send) {
            List<byte> cmdData = new List<byte>();
            cmdData.Add(cmd.Head);
            cmdData.Add(cmds);
            byte[] intBytes = BitConverter.GetBytes(data_send.Length);
            intBytes[0] += 1;
            cmdData.Add(intBytes[0]);
            foreach (byte xx in data_send) cmdData.Add(xx);
            byte checkSum = 0;
            foreach (byte xx in cmdData) checkSum += xx;
            cmdData.Add(checkSum);
            byte[] sends = cmdData.ToArray();
            vlc_rx1.Clear();
            vlc_serial1.DiscardInBuffer();
            vlc_serial1.DiscardOutBuffer();
            vlc_flag_data1 = false;
            try { vlc_serial1.Write(sends, 0, sends.Length); } catch {
                return;
            }
            Stopwatch time_rx = new Stopwatch();
            time_rx.Restart();
            while (time_rx.ElapsedMilliseconds < 5000) {
                if (!vlc_flag_data1) { Thread.Sleep(50); continue; }
                time_rx.Stop();
                break;
            }
            while (time_rx.ElapsedMilliseconds < 5000) {
                vlc_flag_data1 = false;
                Thread.Sleep(100);
                if (vlc_flag_data1) { continue; }
                break;
            }
        }
        private void send_cmd2(byte cmds, byte[] data_send) {
            List<byte> cmdData = new List<byte>();
            cmdData.Add(cmd.Head);
            cmdData.Add(cmds);
            byte[] intBytes = BitConverter.GetBytes(data_send.Length);
            intBytes[0] += 1;
            cmdData.Add(intBytes[0]);
            foreach (byte xx in data_send) cmdData.Add(xx);
            byte checkSum = 0;
            foreach (byte xx in cmdData) checkSum += xx;
            cmdData.Add(checkSum);
            byte[] sends = cmdData.ToArray();
            vlc_rx2.Clear();
            vlc_serial2.DiscardInBuffer();
            vlc_serial2.DiscardOutBuffer();
            vlc_flag_data2 = false;
            try { vlc_serial2.Write(sends, 0, sends.Length); } catch {
                return;
            }
            Stopwatch time_rx = new Stopwatch();
            time_rx.Restart();
            while (time_rx.ElapsedMilliseconds < 5000) {
                if (!vlc_flag_data2) { Thread.Sleep(50); continue; }
                time_rx.Stop();
                break;
            }
            while (time_rx.ElapsedMilliseconds < 5000) {
                vlc_flag_data2 = false;
                Thread.Sleep(100);
                if (vlc_flag_data2) { continue; }
                break;
            }
        }
        private void send_cmd3(byte cmds, byte[] data_send) {
            List<byte> cmdData = new List<byte>();
            cmdData.Add(cmd.Head);
            cmdData.Add(cmds);
            byte[] intBytes = BitConverter.GetBytes(data_send.Length);
            intBytes[0] += 1;
            cmdData.Add(intBytes[0]);
            foreach (byte xx in data_send) cmdData.Add(xx);
            byte checkSum = 0;
            foreach (byte xx in cmdData) checkSum += xx;
            cmdData.Add(checkSum);
            byte[] sends = cmdData.ToArray();
            vlc_rx3.Clear();
            vlc_serial3.DiscardInBuffer();
            vlc_serial3.DiscardOutBuffer();
            vlc_flag_data3 = false;
            try { vlc_serial3.Write(sends, 0, sends.Length); } catch {
                return;
            }
            Stopwatch time_rx = new Stopwatch();
            time_rx.Restart();
            while (time_rx.ElapsedMilliseconds < 5000) {
                if (!vlc_flag_data3) { Thread.Sleep(50); continue; }
                time_rx.Stop();
                break;
            }
            while (time_rx.ElapsedMilliseconds < 5000) {
                vlc_flag_data3 = false;
                Thread.Sleep(100);
                if (vlc_flag_data3) { continue; }
                break;
            }
        }
        private void send_cmd4(byte cmds, byte[] data_send) {
            List<byte> cmdData = new List<byte>();
            cmdData.Add(cmd.Head);
            cmdData.Add(cmds);
            byte[] intBytes = BitConverter.GetBytes(data_send.Length);
            intBytes[0] += 1;
            cmdData.Add(intBytes[0]);
            foreach (byte xx in data_send) cmdData.Add(xx);
            byte checkSum = 0;
            foreach (byte xx in cmdData) checkSum += xx;
            cmdData.Add(checkSum);
            byte[] sends = cmdData.ToArray();
            vlc_rx4.Clear();
            vlc_serial4.DiscardInBuffer();
            vlc_serial4.DiscardOutBuffer();
            vlc_flag_data4 = false;
            try { vlc_serial4.Write(sends, 0, sends.Length); } catch {
                return;
            }
            Stopwatch time_rx = new Stopwatch();
            time_rx.Restart();
            while (time_rx.ElapsedMilliseconds < 5000) {
                if (!vlc_flag_data4) { Thread.Sleep(50); continue; }
                time_rx.Stop();
                break;
            }
            while (time_rx.ElapsedMilliseconds < 5000) {
                vlc_flag_data4 = false;
                Thread.Sleep(100);
                if (vlc_flag_data4) { continue; }
                break;
            }
        }

        private bool run1 = false;
        private TextBox text1 = new TextBox();
        private int head1 = 0;
        private string uid1 = "";
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            Stopwatch s = new Stopwatch();
            while (true) {
                if (!run1) { Thread.Sleep(500); continue; }
                int[] num2 = { 0, 4, 8, 12, 16 };
                foreach (int num in num2) {
                    Thread.Sleep(500);
                    text1 = getTextbox(num);
                    head1 = num;
                    backgroundWorker1.ReportProgress(0);
                    if (comport[num] == "" || comport[num] == null) {
                        backgroundWorker1.ReportProgress(1);
                        continue;
                    }
                    try { vlc_serial1.Close(); } catch { }
                    try { vlc_serial1.Dispose(); } catch { }
                    vlc_serial1 = new SerialPort(comport[num]);
                    vlc_serial1.DataReceived += vlc_DataReceivedHandler1;
                    vlc_serial1.BaudRate = 9600;
                    vlc_serial1.DataBits = 8;
                    vlc_serial1.StopBits = StopBits.One;
                    vlc_serial1.Parity = Parity.None;
                    vlc_serial1.Handshake = Handshake.None;
                    vlc_serial1.RtsEnable = true;
                    s.Restart();
                    while (s.ElapsedMilliseconds < 2500) {
                        try { vlc_serial1.Close(); } catch { }
                        try { vlc_serial1.Open(); } catch { Thread.Sleep(50); continue; }
                        Thread.Sleep(500);
                        s.Stop();
                        break;
                    }
                    if (s.IsRunning) {
                        try { vlc_serial1.Close(); } catch { }
                        discom("disable", comport[num]);
                        discom("enable", comport[num]);
                        backgroundWorker1.ReportProgress(2);
                        continue;
                    }
                label1:
                    byte[] data = { 0x01 };
                    for (int hhh = 0; hhh < 4; hhh++)
                    {
                        send_cmd1(cmd.Power, data);
                        if (num == 17)
                        {
                            int gggg = 0;
                        }
                        if (vlc_rx1.Count == 0)
                        {
                            if (hhh < 2)
                            {
                                try
                                {
                                    vlc_serial1.DtrEnable = true;
                                    vlc_serial1.RtsEnable = true;
                                }
                                catch { }
                                DelaymS(2500);
                                try
                                {
                                    vlc_serial1.DtrEnable = false;
                                    vlc_serial1.RtsEnable = false;
                                }
                                catch { }
                                continue;
                            }
                            else
                            {
                                try { vlc_serial1.Close(); } catch { }
                                discom("disable", comport[num]);
                                discom("enable", comport[num]);
                                try { vlc_serial1.Open(); } catch { }
                                continue;
                            }
                        }
                        if (vlc_rx1.Count > 50) { Thread.Sleep(500); continue; }
                        break;
                    }
                    if (vlc_rx1.Count != 1) { backgroundWorker1.ReportProgress(4); continue; }
                    if (vlc_rx1[0] != cmd.Ack) { backgroundWorker1.ReportProgress(4); continue; }

                    data[0] = 0x03;
                    send_cmd1(cmd.Debug, data);
                    if (vlc_rx1.Count == 0) goto label1;
                    if (vlc_rx1.Count != 13) { backgroundWorker1.ReportProgress(4); continue; }
                    if (vlc_rx1[0] != cmd.Head) { backgroundWorker1.ReportProgress(4); continue; }
                    if (vlc_rx1[1] != cmd.Debug) { backgroundWorker1.ReportProgress(4); continue; }
                    if (vlc_rx1[2] != (vlc_rx1.Count - 3)) { backgroundWorker1.ReportProgress(4); continue; }
                    if (vlc_rx1[3] != data[0]) { backgroundWorker1.ReportProgress(4); continue; }
                    if (vlc_rx1[vlc_rx1.Count - 1] != check_sum(vlc_rx1)) { backgroundWorker1.ReportProgress(4); continue; }
                    string sss = "";
                    for (int j = 4; j < vlc_rx1.Count - 1; j++) {
                        sss += vlc_rx1[j].ToString("X2");
                    }
                    uid1 = sss;
                    backgroundWorker1.ReportProgress(3);

                    data[0] = 0x00;
                    send_cmd1(cmd.Power, data);
                    if (vlc_rx1.Count != 1) { backgroundWorker1.ReportProgress(4); continue; }
                    if (vlc_rx1[0] != cmd.Ack) { backgroundWorker1.ReportProgress(4); continue; }

                    try { vlc_serial1.Close(); } catch { }
                    try { vlc_serial1.Dispose(); } catch { }
                }
                 run1 = false;
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            if (e.ProgressPercentage == 0) {
                text1.Text = "Head " + (head1 + 1) + "\r\n";
            }else if (e.ProgressPercentage == 1) {
                text1.Text += "File port err\r\n";
            } else if (e.ProgressPercentage == 2) {
                text1.Text += "Open port err\r\n";
            } else if (e.ProgressPercentage == 3) {
                text1.Text += uid1 + "\r\n";
            }
            else if (e.ProgressPercentage == 4)
            {
                text1.Text += "Err\r\n";
                try { vlc_serial1.Close(); } catch { }
                try { vlc_serial1.Dispose(); } catch { }
            }
        }

        private bool run2 = false;
        private TextBox text2 = new TextBox();
        private int head2 = 0;
        private string uid2 = "";
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e) {
            Stopwatch s = new Stopwatch();
            while (true) {
                if (!run2) { Thread.Sleep(500); continue; }
                int[] num2 = { 1, 5, 9, 13, 17 };
                foreach (int num in num2) {
                    Thread.Sleep(500);
                    text2 = getTextbox(num);
                    head2 = num;
                    backgroundWorker2.ReportProgress(0);
                    if (comport[num] == "" || comport[num] == null) {
                        backgroundWorker2.ReportProgress(1);
                        continue;
                    }
                    try { vlc_serial2.Close(); } catch { }
                    try { vlc_serial2.Dispose(); } catch { }
                    vlc_serial2 = new SerialPort(comport[num]);
                    vlc_serial2.DataReceived += vlc_DataReceivedHandler2;
                    vlc_serial2.BaudRate = 9600;
                    vlc_serial2.DataBits = 8;
                    vlc_serial2.StopBits = StopBits.One;
                    vlc_serial2.Parity = Parity.None;
                    vlc_serial2.Handshake = Handshake.None;
                    vlc_serial2.RtsEnable = true;
                    s.Restart();
                    while (s.ElapsedMilliseconds < 2500) {
                        try { vlc_serial2.Close(); } catch { }
                        try { vlc_serial2.Open(); } catch { Thread.Sleep(50); continue; }
                        Thread.Sleep(500);
                        s.Stop();
                        break;
                    }
                    if (s.IsRunning) {
                        try { vlc_serial2.Close(); } catch { }
                        discom("disable", comport[num]);
                        discom("enable", comport[num]);
                        backgroundWorker2.ReportProgress(2);
                        continue;
                    }
                    label2:
                    byte[] data = { 0x01 };
                    for (int hhh = 0; hhh < 4; hhh++)
                    {
                        send_cmd2(cmd.Power, data);
                        if(num == 17)
                        {
                            int gggg = 0;
                        }
                        if (vlc_rx2.Count == 0)
                        {
                            if(hhh < 2)
                            {
                                try
                                {
                                    vlc_serial2.DtrEnable = true;
                                    vlc_serial2.RtsEnable = true;
                                }
                                catch { }
                                DelaymS(2500);
                                try
                                {
                                    vlc_serial2.DtrEnable = false;
                                    vlc_serial2.RtsEnable = false;
                                }
                                catch { }
                                continue;
                            }
                            else
                            {
                                try { vlc_serial2.Close(); } catch { }
                                discom("disable", comport[num]);
                                discom("enable", comport[num]);
                                try { vlc_serial2.Open(); } catch { }
                                continue;
                            }
                        }
                        if (vlc_rx2.Count > 50) { Thread.Sleep(500); continue; }
                        break;
                    }
                    if (vlc_rx2.Count != 1) { backgroundWorker2.ReportProgress(4); continue; }
                    if (vlc_rx2[0] != cmd.Ack) {backgroundWorker2.ReportProgress(4); continue; }

                    data[0] = 0x03;
                    send_cmd2(cmd.Debug, data);
                    if (vlc_rx2.Count == 0) goto label2;
                    if (vlc_rx2.Count != 13) { backgroundWorker2.ReportProgress(4); continue; }
                    if (vlc_rx2[0] != cmd.Head) { backgroundWorker2.ReportProgress(4); continue; }
                    if (vlc_rx2[1] != cmd.Debug) { backgroundWorker2.ReportProgress(4); continue; }
                    if (vlc_rx2[2] != (vlc_rx2.Count - 3)) { backgroundWorker2.ReportProgress(4); continue; }
                    if (vlc_rx2[3] != data[0]) { backgroundWorker2.ReportProgress(4); continue; }
                    if (vlc_rx2[vlc_rx2.Count - 1] != check_sum(vlc_rx2)) { backgroundWorker2.ReportProgress(4); continue; }
                    string sss = "";
                    for (int j = 4; j < vlc_rx2.Count - 1; j++) {
                        sss += vlc_rx2[j].ToString("X2");
                    }
                    uid2 = sss;
                    backgroundWorker2.ReportProgress(3);

                    data[0] = 0x00;
                    send_cmd2(cmd.Power, data);
                    if (vlc_rx2.Count != 1) { backgroundWorker2.ReportProgress(4); continue; }
                    if (vlc_rx2[0] != cmd.Ack) { backgroundWorker2.ReportProgress(4); continue; }

                    try { vlc_serial2.Close(); } catch { }
                    try { vlc_serial2.Dispose(); } catch { }
                }



                run2 = false;
            }
        }
        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            if (e.ProgressPercentage == 0) {
                text2.Text = "Head " + (head2 + 1) + "\r\n";
            } else if (e.ProgressPercentage == 1) {
                text2.Text += "File port err\r\n";
            } else if (e.ProgressPercentage == 2) {
                text2.Text += "Open port err\r\n";
            } else if (e.ProgressPercentage == 3) {
                text2.Text += uid2 + "\r\n";
            }
            else if (e.ProgressPercentage == 4)
            {
                text2.Text += "Err\r\n";
                try { vlc_serial2.Close(); } catch { }
                try { vlc_serial2.Dispose(); } catch { }
            }
        }

        private bool run3 = false;
        private TextBox text3 = new TextBox();
        private int head3 = 0;
        private string uid3 = "";
        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e) {
            Stopwatch s = new Stopwatch();
            while (true) {
                if (!run3) { Thread.Sleep(500); continue; }
                int[] num2 = { 2, 6, 10, 14, 18 };
                foreach (int num in num2) {
                    Thread.Sleep(500);
                    text3 = getTextbox(num);
                    head3 = num;
                    backgroundWorker3.ReportProgress(0);
                    if (comport[num] == "" || comport[num] == null) {
                        backgroundWorker3.ReportProgress(1);
                        continue;
                    }
                    try { vlc_serial3.Close(); } catch { }
                    try { vlc_serial3.Dispose(); } catch { }
                    vlc_serial3 = new SerialPort(comport[num]);
                    vlc_serial3.DataReceived += vlc_DataReceivedHandler3;
                    vlc_serial3.BaudRate = 9600;
                    vlc_serial3.DataBits = 8;
                    vlc_serial3.StopBits = StopBits.One;
                    vlc_serial3.Parity = Parity.None;
                    vlc_serial3.Handshake = Handshake.None;
                    vlc_serial3.RtsEnable = true;
                    s.Restart();
                    while (s.ElapsedMilliseconds < 2500) {
                        try { vlc_serial3.Close(); } catch { }
                        try { vlc_serial3.Open(); } catch { Thread.Sleep(50); continue; }
                        Thread.Sleep(500);
                        s.Stop();
                        break;
                    }
                    if (s.IsRunning) {
                        try { vlc_serial3.Close(); } catch { }
                        discom("disable", comport[num]);
                        discom("enable", comport[num]);
                        backgroundWorker3.ReportProgress(2);
                        continue;
                    }
                label3:
                    byte[] data = { 0x01 };
                    for (int hhh = 0; hhh < 4; hhh++)
                    {
                        send_cmd3(cmd.Power, data);
                        if (num == 17)
                        {
                            int gggg = 0;
                        }
                        if (vlc_rx3.Count == 0)
                        {
                            if (hhh < 2)
                            {
                                try
                                {
                                    vlc_serial3.DtrEnable = true;
                                    vlc_serial3.RtsEnable = true;
                                }
                                catch { }
                                DelaymS(2500);
                                try
                                {
                                    vlc_serial3.DtrEnable = false;
                                    vlc_serial3.RtsEnable = false;
                                }
                                catch { }
                                continue;
                            }
                            else
                            {
                                try { vlc_serial3.Close(); } catch { }
                                discom("disable", comport[num]);
                                discom("enable", comport[num]);
                                try { vlc_serial3.Open(); } catch { }
                                continue;
                            }
                        }
                        if (vlc_rx3.Count > 50) { Thread.Sleep(500); continue; }
                        break;
                    }
                    if (vlc_rx3.Count != 1) { backgroundWorker3.ReportProgress(4); continue; }
                    if (vlc_rx3[0] != cmd.Ack) { backgroundWorker3.ReportProgress(4); continue; }

                    data[0] = 0x03;
                    send_cmd3(cmd.Debug, data);
                    if (vlc_rx3.Count == 0) goto label3;
                    if (vlc_rx3.Count != 13) { backgroundWorker3.ReportProgress(4); continue; }
                    if (vlc_rx3[0] != cmd.Head) { backgroundWorker3.ReportProgress(4); continue; }
                    if (vlc_rx3[1] != cmd.Debug) { backgroundWorker3.ReportProgress(4); continue; }
                    if (vlc_rx3[2] != (vlc_rx3.Count - 3)) { backgroundWorker3.ReportProgress(4); continue; }
                    if (vlc_rx3[3] != data[0]) { backgroundWorker3.ReportProgress(4); continue; }
                    if (vlc_rx3[vlc_rx3.Count - 1] != check_sum(vlc_rx3)) { backgroundWorker3.ReportProgress(4); continue; }
                    string sss = "";
                    for (int j = 4; j < vlc_rx3.Count - 1; j++) {
                        sss += vlc_rx3[j].ToString("X2");
                    }
                    uid3 = sss;
                    backgroundWorker3.ReportProgress(3);

                    data[0] = 0x00;
                    send_cmd3(cmd.Power, data);
                    if (vlc_rx3.Count != 1) { backgroundWorker3.ReportProgress(4); continue; }
                    if (vlc_rx3[0] != cmd.Ack) { backgroundWorker3.ReportProgress(4); continue; }

                    try { vlc_serial3.Close(); } catch { }
                    try { vlc_serial3.Dispose(); } catch { }
                }



                run3 = false;
            }
        }
        private void backgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            if (e.ProgressPercentage == 0) {
                text3.Text = "Head " + (head3 + 1) + "\r\n";
            } else if (e.ProgressPercentage == 1) {
                text3.Text += "File port err\r\n";
            } else if (e.ProgressPercentage == 2) {
                text3.Text += "Open port err\r\n";
            } else if (e.ProgressPercentage == 3) {
                text3.Text += uid3 + "\r\n";
            }
            else if (e.ProgressPercentage == 4)
            {
                text3.Text += "Err\r\n";
                try { vlc_serial3.Close(); } catch { }
                try { vlc_serial3.Dispose(); } catch { }
            }
        }

        private bool run4 = false;
        private TextBox text4 = new TextBox();
        private int head4 = 0;
        private string uid4 = "";
        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e) {
            Stopwatch s = new Stopwatch();
            while (true) {
                if (!run4) { Thread.Sleep(500); continue; }
                int[] num2 = { 3, 7, 11, 15, 19 };
                foreach (int num in num2) {
                    Thread.Sleep(500);
                    text4 = getTextbox(num);
                    head4 = num;
                    backgroundWorker4.ReportProgress(0);
                    if (comport[num] == "" || comport[num] == null) {
                        backgroundWorker4.ReportProgress(1);
                        continue;
                    }
                    try { vlc_serial4.Close(); } catch { }
                    try { vlc_serial4.Dispose(); } catch { }
                    vlc_serial4 = new SerialPort(comport[num]);
                    vlc_serial4.DataReceived += vlc_DataReceivedHandler4;
                    vlc_serial4.BaudRate = 9600;
                    vlc_serial4.DataBits = 8;
                    vlc_serial4.StopBits = StopBits.One;
                    vlc_serial4.Parity = Parity.None;
                    vlc_serial4.Handshake = Handshake.None;
                    vlc_serial4.RtsEnable = true;
                    s.Restart();
                    while (s.ElapsedMilliseconds < 2500) {
                        try { vlc_serial4.Close(); } catch { }
                        try { vlc_serial4.Open(); } catch { Thread.Sleep(50); continue; }
                        Thread.Sleep(500);
                        s.Stop();
                        break;
                    }
                    if (s.IsRunning) {
                        try { vlc_serial4.Close(); } catch { }
                        discom("disable", comport[num]);
                        discom("enable", comport[num]);
                        backgroundWorker4.ReportProgress(2);
                        continue;
                    }
                label4:
                    byte[] data = { 0x01 };
                    for (int hhh = 0; hhh < 4; hhh++)
                    {
                        send_cmd4(cmd.Power, data);
                        if (num == 17)
                        {
                            int gggg = 0;
                        }
                        if (vlc_rx4.Count == 0)
                        {
                            if (hhh < 2)
                            {
                                try
                                {
                                    vlc_serial4.DtrEnable = true;
                                    vlc_serial4.RtsEnable = true;
                                }
                                catch { }
                                DelaymS(2500);
                                try
                                {
                                    vlc_serial4.DtrEnable = false;
                                    vlc_serial4.RtsEnable = false;
                                }
                                catch { }
                                continue;
                            }
                            else
                            {
                                try { vlc_serial4.Close(); } catch { }
                                discom("disable", comport[num]);
                                discom("enable", comport[num]);
                                try { vlc_serial4.Open(); } catch { }
                                continue;
                            }
                        }
                        if (vlc_rx4.Count > 50) { Thread.Sleep(500); continue; }
                        break;
                    }
                    if (vlc_rx4.Count != 1) { backgroundWorker4.ReportProgress(4); continue; }
                    if (vlc_rx4[0] != cmd.Ack) { backgroundWorker4.ReportProgress(4); continue; }

                    data[0] = 0x03;
                    send_cmd4(cmd.Debug, data);
                    if (vlc_rx4.Count == 0) goto label4;
                    if (vlc_rx4.Count != 13) { backgroundWorker4.ReportProgress(4); continue; }
                    if (vlc_rx4[0] != cmd.Head) { backgroundWorker4.ReportProgress(4); continue; }
                    if (vlc_rx4[1] != cmd.Debug) { backgroundWorker4.ReportProgress(4); continue; }
                    if (vlc_rx4[2] != (vlc_rx4.Count - 3)) { backgroundWorker4.ReportProgress(4); continue; }
                    if (vlc_rx4[3] != data[0]) { backgroundWorker4.ReportProgress(4); continue; }
                    if (vlc_rx4[vlc_rx4.Count - 1] != check_sum(vlc_rx4)) { backgroundWorker4.ReportProgress(4); continue; }
                    string sss = "";
                    for (int j = 4; j < vlc_rx4.Count - 1; j++) {
                        sss += vlc_rx4[j].ToString("X2");
                    }
                    uid4 = sss;
                    backgroundWorker4.ReportProgress(3);

                    data[0] = 0x00;
                    send_cmd4(cmd.Power, data);
                    if (vlc_rx4.Count != 1) { backgroundWorker4.ReportProgress(4); continue; }
                    if (vlc_rx4[0] != cmd.Ack) { backgroundWorker4.ReportProgress(4); continue; }

                    try { vlc_serial4.Close(); } catch { }
                    try { vlc_serial4.Dispose(); } catch { }
                }



                run4 = false;
            }
        }
        private void backgroundWorker4_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            if (e.ProgressPercentage == 0) {
                text4.Text = "Head " + (head4 + 1) + "\r\n";
            } else if (e.ProgressPercentage == 1) {
                text4.Text += "File port err\r\n";
            } else if (e.ProgressPercentage == 2) {
                text4.Text += "Open port err\r\n";
            } else if (e.ProgressPercentage == 3) {
                text4.Text += uid4 + "\r\n";
            }
            else if (e.ProgressPercentage == 4)
            {
                text4.Text += "Err\r\n";
                try { vlc_serial4.Close(); } catch { }
                try { vlc_serial4.Dispose(); } catch { }
            }
        }

        private void bt_dummy_Click(object sender, EventArgs e) {
            save_uid_gold_board("pass");
        }
        private void button2_Click(object sender, EventArgs e) {
            save_uid_gold_board("fail");
        }
        private void save_uid_gold_board(string status) {
            string gold_board = "pass";
            string file = "";
            if(status == "fail") {
                gold_board = "fail";
                file = "_fail";
            }
            string[] id = { "62074", "62074" };
            string uid_all = "";
            string index = "";
            while (true) {
                string input = Microsoft.VisualBasic.Interaction.InputBox("_กรุณาใส่รหัสผ่าน", "Dummy", "", 500, 300);
                if (input == "") return;
                if (!id.Contains(input)) {
                    MessageBox.Show("_รหัสผ่านไม่ถูกต้อง");
                    continue;
                }
                break;
            }
            while (true) {
                string input = Microsoft.VisualBasic.Interaction.InputBox("_กรุณาใส่ลำดับของ Gold board (" + gold_board + ")", "Gold board", "", 500, 300);
                if (input == "") return;
                if (input != "1" && input != "2" && input != "3") {
                    MessageBox.Show("_ลำดับไม่ถูกต้อง (1, 2, 3) เท่านั้น");
                    continue;
                }
                index = input;
                break;
            }
            string[] uid2 = tb_1.Text.Replace("\r\n", "ฃ").Split('ฃ');
            string uid = uid2[uid2.Length - 2];
            uid_all += uid + "\r\n";
            uid2 = tb_2.Text.Replace("\r\n", "ฃ").Split('ฃ');
            uid = uid2[uid2.Length - 2];
            uid_all += uid + "\r\n";
            uid2 = tb_3.Text.Replace("\r\n", "ฃ").Split('ฃ');
            uid = uid2[uid2.Length - 2];
            uid_all += uid + "\r\n";
            uid2 = tb_4.Text.Replace("\r\n", "ฃ").Split('ฃ');
            uid = uid2[uid2.Length - 2];
            uid_all += uid + "\r\n";
            uid2 = tb_5.Text.Replace("\r\n", "ฃ").Split('ฃ');
            uid = uid2[uid2.Length - 2];
            uid_all += uid + "\r\n";
            uid2 = tb_6.Text.Replace("\r\n", "ฃ").Split('ฃ');
            uid = uid2[uid2.Length - 2];
            uid_all += uid + "\r\n";
            uid2 = tb_7.Text.Replace("\r\n", "ฃ").Split('ฃ');
            uid = uid2[uid2.Length - 2];
            uid_all += uid + "\r\n";
            uid2 = tb_8.Text.Replace("\r\n", "ฃ").Split('ฃ');
            uid = uid2[uid2.Length - 2];
            uid_all += uid + "\r\n";
            uid2 = tb_9.Text.Replace("\r\n", "ฃ").Split('ฃ');
            uid = uid2[uid2.Length - 2];
            uid_all += uid + "\r\n";
            uid2 = tb_10.Text.Replace("\r\n", "ฃ").Split('ฃ');
            uid = uid2[uid2.Length - 2];
            uid_all += uid + "\r\n";
            uid2 = tb_11.Text.Replace("\r\n", "ฃ").Split('ฃ');
            uid = uid2[uid2.Length - 2];
            uid_all += uid + "\r\n";
            uid2 = tb_12.Text.Replace("\r\n", "ฃ").Split('ฃ');
            uid = uid2[uid2.Length - 2];
            uid_all += uid + "\r\n";
            uid2 = tb_13.Text.Replace("\r\n", "ฃ").Split('ฃ');
            uid = uid2[uid2.Length - 2];
            uid_all += uid + "\r\n";
            uid2 = tb_14.Text.Replace("\r\n", "ฃ").Split('ฃ');
            uid = uid2[uid2.Length - 2];
            uid_all += uid + "\r\n";
            uid2 = tb_15.Text.Replace("\r\n", "ฃ").Split('ฃ');
            uid = uid2[uid2.Length - 2];
            uid_all += uid + "\r\n";
            uid2 = tb_16.Text.Replace("\r\n", "ฃ").Split('ฃ');
            uid = uid2[uid2.Length - 2];
            uid_all += uid + "\r\n";
            uid2 = tb_17.Text.Replace("\r\n", "ฃ").Split('ฃ');
            uid = uid2[uid2.Length - 2];
            uid_all += uid + "\r\n";
            uid2 = tb_18.Text.Replace("\r\n", "ฃ").Split('ฃ');
            uid = uid2[uid2.Length - 2];
            uid_all += uid + "\r\n";
            uid2 = tb_19.Text.Replace("\r\n", "ฃ").Split('ฃ');
            uid = uid2[uid2.Length - 2];
            uid_all += uid + "\r\n";
            uid2 = tb_20.Text.Replace("\r\n", "ฃ").Split('ฃ');
            uid = uid2[uid2.Length - 2];
            uid_all += uid;
            if (index == "1") index = "";
            File.WriteAllText("../../config/vlc_dummy_uid"+ file + index + ".txt", uid_all);
            MessageBox.Show("Save UID OK");
        }
    }
    public class cmdAr {
        public byte Start = 0x01;
        public byte Stop = 0x02;
        public byte TesterID = 0x03;
        public byte Result = 0x04;
        public byte UID = 0x05;
        public byte SpecVersion = 0x06;
        public byte Calibrate = 0x08;
        public byte Current = 0x09;
        public byte Load = 0x0A;
        public byte Drive = 0x0B;
        public byte SetFactor = 0x0C;
        public byte Update = 0x0D;
        public byte Head = 0x49;
        public byte Ack = 0x94;
        public byte Debug = 0x12;
        public byte Power = 0x0F;
    }
}
