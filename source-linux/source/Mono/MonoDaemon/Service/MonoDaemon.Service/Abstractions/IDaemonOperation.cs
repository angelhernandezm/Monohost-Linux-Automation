using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace MonoDaemon.Service
{
	/// <summary>
	/// I daemon operation.
	/// </summary>
	[ServiceContract]
	public interface IDaemonOperation
	{
		/// <summary>
		/// Gets the running processes.
		/// </summary>
		/// <returns>The running processes.</returns>
		[OperationContract]
		List<ProcessInformation> GetRunningProcesses ();

		/// <summary>
		/// Gets the name of the process by.
		/// </summary>
		/// <returns>The process by name.</returns>
		/// <param name="processName">Process name.</param>
		[OperationContract]
		ProcessInformation GetProcessByName (string processName);

		/// <summary>
		/// Starts the remote process.
		/// </summary>
		/// <param name="processName">Process name.</param>
		[OperationContract]
		void StartRemoteProcess (string processName);
	}
}

