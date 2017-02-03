using System;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace MonoDaemon.Service
{
	/// <summary>
	/// Process information.
	/// </summary>
	[DataContract]
	public class ProcessInformation
	{
		/// <summary>
		/// Gets or sets the name of the process.
		/// </summary>
		/// <value>The name of the process.</value>
		[DataMember]
		public string ProcessName {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the image path.
		/// </summary>
		/// <value>The image path.</value>
		[DataMember]
		public string ImagePath { 
			get; 
			set; 
		}

		/// <summary>
		/// Gets or sets the pid.
		/// </summary>
		/// <value>The pid.</value>
		[DataMember]
		public int Pid {
			get;
			set;
		}
	}
}

