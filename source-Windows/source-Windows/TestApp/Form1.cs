using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}



		/// <summary>
		/// Handles the 1 event of the button1_Click control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void button1_Click_1(object sender, EventArgs e) {
			using (var proxy = new MonoDaemonProxy()) {
				var procs = proxy.GetRunningProcesses();

				if (procs != null && procs.Length > 0)
					Array.ForEach(procs, x => listBox1.Items.Add($"Process Name: {x.ProcessName} - Pid: {x.Pid} - Image Path:{x.ImagePath}"));
			}
		}

		/// <summary>
		/// Handles the Click event of the button2 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void button2_Click(object sender, EventArgs e) {
			if (!string.IsNullOrEmpty(textBox1.Text)) {
				using (var proxy = new MonoDaemonProxy()) {
					var proc = proxy.GetProcessByName(textBox1.Text);

					if (proc != null)
						MessageBox.Show($"Process Name: {proc.ProcessName} - Pid: {proc.Pid} - Image Path:{proc.ImagePath}");
				}
			}
		}

		/// <summary>
		/// Handles the Click event of the button3 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void button3_Click(object sender, EventArgs e) {
			if (!string.IsNullOrEmpty(textBox2.Text)) {
				using (var proxy = new MonoDaemonProxy()) {
					proxy.StartRemoteProcess(textBox2.Text);
				}
			}
		}
	}
}
