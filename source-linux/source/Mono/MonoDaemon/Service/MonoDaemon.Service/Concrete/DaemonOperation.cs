using System;
using System.Threading;
using System.Diagnostics;
using System.ServiceModel;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MonoDaemon.Service
{
	/// <summary>
	/// Daemon operation.
	/// </summary>
	[ServiceContract]
	public class DaemonOperation: IDaemonOperation
	{
		/// <summary>
		/// The qt messenger.
		/// </summary>
		public static Action<string> QtMessenger;

		/// <summary>
		/// Bubbles the message up.
		/// </summary>
		/// <param name="message">Message.</param>
		private void BubbleMessageUp(string message) {
			if (!string.IsNullOrEmpty (message) && QtMessenger != null)
				QtMessenger.Invoke (message);
		}

		/// <summary>
		/// Gets the running processes.
		/// </summary>
		/// <returns>The running processes.</returns>
		public List<ProcessInformation> GetRunningProcesses ()
		{
			BubbleMessageUp (string.Format("GetRunningProcesses was called on {0}", new object[] { DateTime.Now }));
			var p = Process.GetProcesses ();
			var retval = new List<ProcessInformation> ();

			foreach (var item in p) {
				try {
					retval.Add (new ProcessInformation () {
						ImagePath = item.MainModule.FileName,
						Pid = item.Id,
						ProcessName = item.ProcessName
					});
				} catch {
					// Safe to ignore
				}
			}

			return retval;
		}

		/// <summary>
		/// Gets the name of the process by.
		/// </summary>
		/// <returns>The process by name.</returns>
		/// <param name="processName">Process name.</param>
		public ProcessInformation GetProcessByName (string processName)
		{
			var found = false;
			ProcessInformation retval = null;
			BubbleMessageUp (string.Format("GetProcessByName was called on {0} - Parameter:{1}", new object[] { DateTime.Now, processName }));

			if (!string.IsNullOrEmpty (processName)) {
				var allProcs = Process.GetProcesses ();

				for (var x = 0; x < allProcs.Length && !found; x++) {
					try {
						var p = allProcs [x];

						if (p.ProcessName.ToLowerInvariant ().Contains (processName)) {
							retval = new ProcessInformation () {
								ImagePath = p.MainModule.FileName,
								Pid = p.Id,
								ProcessName = p.ProcessName
							};
							found = true;
						}
					} catch {
						// Safe to ignore
					}
				}
			}

			return retval;
		}

		/// <summary>
		/// Starts the remote process.
		/// </summary>
		/// <param name="processName">Process name.</param>
		public void StartRemoteProcess (string processName)
		{
			if (!string.IsNullOrEmpty (processName)) {
				BubbleMessageUp (string.Format("StartRemoteProcess was called on {0} - Parameter:{1}", new object[] { DateTime.Now, processName }));
				new Thread (new ThreadStart (() => {
					using (var p = Process.Start (new ProcessStartInfo (processName)))
						Debug.WriteLine (string.Format ("Launching process... {0}", new object[] { processName }));
				})).Start ();
			}
		}
	}
}