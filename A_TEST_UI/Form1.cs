using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RobloxAPI;

namespace A_TEST_UI
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Miner_System lol = new Miner_System();
			lol.Start_Mining();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			foreach (var process in Process.GetProcessesByName("Lua U Decompiler"))
			{
				process.Kill();
			}
		}
	}
}
