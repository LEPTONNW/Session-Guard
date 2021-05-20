using Microsoft.Win32;
using NetFwTypeLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Destiny2방화벽
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            주소텍스트.Enabled = false;
            주소추가.Enabled = false;
            this.상태정보.Hide();
            this.개인세션생성.Hide();
            //this.주소텍스트.Hide();
            //this.주소추가.Hide();
            //this.listBox1.Hide();
            //this.삭제.Hide();
            //this.규칙추가.Hide();
            //this.규칙제거.Hide();

            //this.MaximizeBox = false;
            //string temp = isFirewallEnabled().ToString();
            //if (temp == "False" || temp == "false")
            //{
            //    this.SH_B.BackColor = Color.Red;
            //    SH_B.Text = "방화벽 꺼짐";
            //}
            //else if (temp == "True" || temp == "true")
            //{
            //    this.SH_B.BackColor = Color.Blue;
            //    SH_B.Text = "방화벽 켜짐";
            //}

            //규칙추가.Enabled = true;
            //규칙제거.Enabled = false;
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenThread(Form1.ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

        [DllImport("kernel32.dll")]
        private static extern uint SuspendThread(IntPtr hThread);

        [DllImport("kernel32.dll")]
        private static extern int ResumeThread(IntPtr hThread);

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool CloseHandle(IntPtr handle);

        public List<String> pidtext = new List<String>();
        public static int IPA_ALLOW_CO = 0; //추가주소 카운트
        public List<String> IPA = new List<String>();
        public List<String> Arr_IPA = new List<String>();
        public static string[] Arr;

        public static bool isFirewallEnabled()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\SharedAccess\\Parameters\\FirewallPolicy\\StandardProfile"))
                {
                    if (key == null)
                    {
                        return false;
                    }
                    else
                    {
                        Object o = key.GetValue("EnableFirewall");
                        if (o == null)
                        {
                            return false;
                        }
                        else
                        {
                            int firewall = (int)o;
                            if (firewall == 1)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        protected override void WndProc(ref Message m) //마우스 함수
        {
            switch (m.Msg)

            {

                case 0x84:

                    base.WndProc(ref m);

                    if ((int)m.Result == 0x1)

                        m.Result = (IntPtr)0x2;

                    return;

            }
            base.WndProc(ref m);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            try
            {
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.Write(@"netsh advfirewall set allprofiles state off" + Environment.NewLine);
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());


                //인,아웃 차단해제
                INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                firewallPolicy.Rules.Remove("Destiny2-Solo-1");

                INetFwPolicy2 firewallPolicy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                firewallPolicy2.Rules.Remove("Destiny2-Solo-2");

                INetFwPolicy2 firewallPolicy3 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                firewallPolicy3.Rules.Remove("Destiny2-Solo-1");

                INetFwPolicy2 firewallPolicy4 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                firewallPolicy4.Rules.Remove("Destiny2-Solo-2");
            }
            catch { }
            Application.ExitThread();
            Application.Exit();
            this.Close();
        }

        private void 규칙추가_Click(object sender, EventArgs e)
        {
            INetFwRule firewallRule = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule")); //아웃바운드
            firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            firewallRule.Description = "데스티니 방화벽";
            firewallRule.Protocol = 6;
            firewallRule.RemotePorts = "27000-27100";
            firewallRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
            firewallRule.InterfaceTypes = "All";
            firewallRule.Name = "Destiny2-Solo-1"; // 방화벽 규칙을 구분하는 이름, 삭제시에도 사용됩니다
            firewallRule.Enabled = true;
            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            firewallPolicy.Rules.Add(firewallRule);

            INetFwRule firewallRule2 = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
            firewallRule2.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            firewallRule2.Description = "데스티니 방화벽";
            firewallRule2.Protocol = 17;
            firewallRule2.RemotePorts = "27000-27060";
            firewallRule2.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
            firewallRule2.InterfaceTypes = "All";
            firewallRule2.Name = "Destiny2-Solo-2"; // 방화벽 규칙을 구분하는 이름, 삭제시에도 사용됩니다
            firewallRule2.Enabled = true;
            INetFwPolicy2 firewallPolicy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            firewallPolicy2.Rules.Add(firewallRule2);

            /////////////////////////////////////////////////
            /////////////////////////////////////////////////




            MessageBox.Show("솔로모드가 켜졌습니다.");

            규칙추가.Enabled = false;
            규칙제거.Enabled = true;
        }

        private void 규칙제거_Click(object sender, EventArgs e)
        {
            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            firewallPolicy.Rules.Remove("Destiny2-Solo-1");

            INetFwPolicy2 firewallPolicy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            firewallPolicy2.Rules.Remove("Destiny2-Solo-2");

            //INetFwPolicy2 firewallPolicy3 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            //firewallPolicy3.Rules.Remove("Destiny2-Solo-1");

            //INetFwPolicy2 firewallPolicy4 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            //firewallPolicy4.Rules.Remove("Destiny2-Solo-2");

            규칙추가.Enabled = true;
            규칙제거.Enabled = false;

            MessageBox.Show("솔로모드가 꺼졌습니다.");
        }

        private void SH_B_Click(object sender, EventArgs e)
        {
            if (SH_B.Text == "솔로모드 꺼짐")
            {
                주소텍스트.Enabled = true;
                주소추가.Enabled = true;

                this.SH_B.BackColor = Color.Blue;
                SH_B.Text = "솔로모드 켜짐";

                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.Write(@"netsh advfirewall set allprofiles state on" + Environment.NewLine);
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());

                if (IPA_ALLOW_CO == 0)
                {

                    INetFwRule firewallRule = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule")); //아웃바운드
                    firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                    firewallRule.Description = "데스티니 방화벽";
                    firewallRule.Protocol = 6;
                    firewallRule.RemotePorts = "27000-27100";
                    firewallRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                    firewallRule.InterfaceTypes = "All";
                    firewallRule.Name = "Destiny2-Solo-1"; // 방화벽 규칙을 구분하는 이름, 삭제시에도 사용됩니다
                    firewallRule.Enabled = true;
                    INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                    firewallPolicy.Rules.Add(firewallRule);

                    INetFwRule firewallRule2 = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                    firewallRule2.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                    firewallRule2.Description = "데스티니 방화벽";
                    firewallRule2.Protocol = 17;
                    firewallRule2.RemotePorts = "27000-27100";
                    firewallRule2.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                    firewallRule2.InterfaceTypes = "All";
                    firewallRule2.Name = "Destiny2-Solo-2"; // 방화벽 규칙을 구분하는 이름, 삭제시에도 사용됩니다
                    firewallRule2.Enabled = true;
                    INetFwPolicy2 firewallPolicy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                    firewallPolicy2.Rules.Add(firewallRule2);

                    INetFwRule firewallRule3 = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule")); //아웃바운드
                    firewallRule3.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                    firewallRule3.Description = "데스티니 방화벽";
                    firewallRule3.Protocol = 6;
                    firewallRule3.RemotePorts = "27000-27100";
                    firewallRule3.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                    firewallRule3.InterfaceTypes = "All";
                    firewallRule3.Name = "Destiny2-Solo-1"; // 방화벽 규칙을 구분하는 이름, 삭제시에도 사용됩니다
                    firewallRule3.Enabled = true;
                    INetFwPolicy2 firewallPolicy3 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                    firewallPolicy3.Rules.Add(firewallRule3);

                    INetFwRule firewallRule4 = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                    firewallRule4.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                    firewallRule4.Description = "데스티니 방화벽";
                    firewallRule4.Protocol = 17;
                    firewallRule4.RemotePorts = "27000-27100";
                    firewallRule4.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                    firewallRule4.InterfaceTypes = "All";
                    firewallRule4.Name = "Destiny2-Solo-2"; // 방화벽 규칙을 구분하는 이름, 삭제시에도 사용됩니다
                    firewallRule4.Enabled = true;
                    INetFwPolicy2 firewallPolicy4 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                    firewallPolicy4.Rules.Add(firewallRule4);
                }
                else
                {
                    INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                    firewallPolicy.Rules.Remove("Destiny2-Solo-1");

                    INetFwPolicy2 firewallPolicy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                    firewallPolicy2.Rules.Remove("Destiny2-Solo-2");

                    INetFwPolicy2 firewallPolicy3 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                    firewallPolicy3.Rules.Remove("Destiny2-Solo-1");

                    INetFwPolicy2 firewallPolicy4 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                    firewallPolicy4.Rules.Remove("Destiny2-Solo-2");

                    int Arr_Length = IPA.Count;

                    Arr = IPA.ToArray();
                    Arr_IPA = Arr.Select(Version.Parse).OrderBy(arg => arg).Select(arg => arg.ToString()).ToList(); //오름차순정렬

                    string temp = "1.1.1.1-";
                    foreach (string a in Arr_IPA)
                    {
                        string[] arr_temp = a.Split('.');
                        string temp2 = arr_temp[0] + "." + arr_temp[1] + "." + arr_temp[2] + ".";
                        temp += temp2 + (Convert.ToInt32(arr_temp[3]) - 1).ToString() + "," + temp2 + (Convert.ToInt32(arr_temp[3]) + 1).ToString() + "-";
                    }
                    temp += "255.255.255.254";
                    //MessageBox.Show(temp);

                    INetFwRule firewallRule = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule")); //아웃바운드
                    firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                    firewallRule.Description = "데스티니 방화벽";
                    firewallRule.Protocol = 6;
                    firewallRule.RemotePorts = "27000-27074";
                    firewallRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                    firewallRule.RemoteAddresses = temp;
                    firewallRule.InterfaceTypes = "All";
                    firewallRule.Name = "Destiny2-Solo-1"; // 방화벽 규칙을 구분하는 이름, 삭제시에도 사용됩니다
                    firewallRule.Enabled = true;
                    firewallPolicy.Rules.Add(firewallRule);

                    INetFwRule firewallRule2 = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                    firewallRule2.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                    firewallRule2.Description = "데스티니 방화벽";
                    firewallRule2.Protocol = 17;
                    firewallRule2.RemotePorts = "27000-27074";
                    firewallRule2.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                    firewallRule2.RemoteAddresses = temp;
                    firewallRule2.InterfaceTypes = "All";
                    firewallRule2.Name = "Destiny2-Solo-2"; // 방화벽 규칙을 구분하는 이름, 삭제시에도 사용됩니다
                    firewallRule2.Enabled = true;
                    firewallPolicy2.Rules.Add(firewallRule2);

                    //INetFwRule firewallRule3 = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule")); //아웃바운드
                    //firewallRule3.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                    //firewallRule3.Description = "데스티니 방화벽";
                    //firewallRule3.Protocol = 6;
                    //firewallRule3.RemotePorts = "27000-27074";
                    //firewallRule3.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                    //firewallRule3.RemoteAddresses = temp;
                    //firewallRule3.InterfaceTypes = "All";
                    //firewallRule3.Name = "Destiny2-Solo-1"; // 방화벽 규칙을 구분하는 이름, 삭제시에도 사용됩니다
                    //firewallRule3.Enabled = true;
                    //firewallPolicy3.Rules.Add(firewallRule3);

                    //INetFwRule firewallRule4 = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                    //firewallRule4.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                    //firewallRule4.Description = "데스티니 방화벽";
                    //firewallRule4.Protocol = 17;
                    //firewallRule4.RemotePorts = "27000-27074";
                    //firewallRule4.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                    //firewallRule4.RemoteAddresses = temp;
                    //firewallRule4.InterfaceTypes = "All";
                    //firewallRule4.Name = "Destiny2-Solo-2"; // 방화벽 규칙을 구분하는 이름, 삭제시에도 사용됩니다
                    //firewallRule4.Enabled = true;
                    //firewallPolicy4.Rules.Add(firewallRule4);

                }
                //MessageBox.Show("솔로모드가 켜졌습니다.");

                //규칙추가.Enabled = false;
                //규칙제거.Enabled = true;


            }
            else if (SH_B.Text == "솔로모드 켜짐")
            {
                주소텍스트.Enabled = false;
                주소추가.Enabled = false;
                this.SH_B.BackColor = Color.Red;
                SH_B.Text = "솔로모드 꺼짐";

                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.Write(@"netsh advfirewall set allprofiles state off" + Environment.NewLine);
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());


                INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                firewallPolicy.Rules.Remove("Destiny2-Solo-1");

                INetFwPolicy2 firewallPolicy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                firewallPolicy2.Rules.Remove("Destiny2-Solo-2");

                INetFwPolicy2 firewallPolicy3 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                firewallPolicy3.Rules.Remove("Destiny2-Solo-1");

                INetFwPolicy2 firewallPolicy4 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                firewallPolicy4.Rules.Remove("Destiny2-Solo-2");

                규칙추가.Enabled = true;
                규칙제거.Enabled = false;

                //MessageBox.Show("솔로모드가 꺼졌습니다.");
            }

        }

        private void 주소추가_Click(object sender, EventArgs e)
        {
            if (SH_B.Text == "솔로모드 꺼짐")
            {
                MessageBox.Show("솔로모드를 먼저 켜주세요");
            }
            else
            {
                if (주소텍스트.Text == "" || 주소텍스트.Text == string.Empty)
                {
                    MessageBox.Show("추가할 IP를 먼저 적어주세요");
                }
                else
                {
                    try
                    {
                        SH_B.PerformClick();
                        IPA.Add(주소텍스트.Text.ToString());
                        IPA_ALLOW_CO++;
                        listBox1.Items.Add(주소텍스트.Text);
                        주소텍스트.Text = "";

                        Thread.Sleep(250);
                        SH_B.PerformClick();
                    }
                    catch
                    {
                        MessageBox.Show("Error : 정확한 IP주소를 입력하지 않았거나 프로그램 오류입니다.");
                    }
                }
            }
        }

        private void 삭제_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("삭제할 값을 먼저 선택 또는 입력해 주세요");
            }
            else
            {
                SH_B.PerformClick();//끄기
                string temp = listBox1.SelectedItem.ToString();
                IPA.Remove(temp);
                IPA_ALLOW_CO--;
                listBox1.Items.Remove(listBox1.SelectedItem);
                Thread.Sleep(250);
                SH_B.PerformClick();//적용후 켜기
            }
        }

        private void 초기화_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems == null)
            {
                MessageBox.Show("삭제할 값을 먼저 선택 또는 입력해 주세요");
            }
            else
            {
                SH_B.PerformClick();
                IPA.Clear();
                IPA_ALLOW_CO = 0;
                listBox1.Items.Clear();
                Thread.Sleep(500);
                SH_B.PerformClick();
            }
        }
        public bool TF;
        public string[] SP;
        public int sec1 = 0;

        private void 개인세션생성_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    foreach (Process process in Process.GetProcesses())
                        this.WriteProcessInfo(process);

                    //검증단계
                }
                catch (Exception ex)
                {
                    int num = (int)MessageBox.Show(ex.Message.ToString());
                }

                foreach (string temp in pidtext)
                {
                    TF = temp.Contains("destiny2");
                    if (TF.ToString() == "true" || TF.ToString() == "True" || TF.ToString() == "TRUE")
                    {
                        SP = temp.Split(':');
                    }
                }
                // SP[1]이 그타 PID번호

                SuspendProcess(Convert.ToInt32(SP[1].ToString()));
                sec1 = 10;
                timer1.Start();
            }

            catch
            {
                MessageBox.Show("데스티니2 를 먼저 실행해 주세요");
            }
        }

        [Flags]
        public enum ThreadAccess
        {
            TERMINATE = 1,
            SUSPEND_RESUME = 2,
            GET_CONTEXT = 8,
            SET_CONTEXT = 16, // 0x00000010
            SET_INFORMATION = 32, // 0x00000020
            QUERY_INFORMATION = 64, // 0x00000040
            SET_THREAD_TOKEN = 128, // 0x00000080
            IMPERSONATE = 256, // 0x00000100
            DIRECT_IMPERSONATION = 512, // 0x00000200
        }

        private static void SuspendProcess(int pid)
        {
            Process processById = Process.GetProcessById(pid);
            if (processById.ProcessName == string.Empty)
                return;
            foreach (ProcessThread thread in (ReadOnlyCollectionBase)processById.Threads)
            {
                IntPtr num1 = Form1.OpenThread(Form1.ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
                if (!(num1 == IntPtr.Zero))
                {
                    int num2 = (int)Form1.SuspendThread(num1);
                    Form1.CloseHandle(num1);
                }
            }
        }

        public static void ResumeProcess(int pid)
        {
            Process processById = Process.GetProcessById(pid);
            if (processById.ProcessName == string.Empty)
                return;
            foreach (ProcessThread thread in (ReadOnlyCollectionBase)processById.Threads)
            {
                IntPtr num = Form1.OpenThread(Form1.ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
                if (!(num == IntPtr.Zero))
                {
                    do
                        ;
                    while (Form1.ResumeThread(num) > 0);
                    Form1.CloseHandle(num);
                }
            }
        }

        public void WriteProcessInfo(Process processInfo)
        {
            pidtext.Add(processInfo.ProcessName + " PID: " + (object)processInfo.Id);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec1--;
            상태정보.Text = sec1 + "초만 기다려주세요 개인 공개세션 생성중입니다.";
            if (sec1 == 0)
            {
                상태정보.Text = "개인공개세션 생성완료";
                ResumeProcess(Convert.ToInt32(SP[1].ToString()));
                sec1 = 10;
                timer1.Stop();
            }
        }
    }
}
