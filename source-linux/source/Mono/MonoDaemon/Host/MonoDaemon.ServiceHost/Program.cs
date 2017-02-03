using System;
using System.Text;
using MonoDaemon.Service;
using System.ServiceModel;
using System.Runtime.InteropServices;

namespace MonoDaemon
{
	public class ServiceHost
	{
		/// <summary>
		/// The m host.
		/// </summary>
		private static System.ServiceModel.ServiceHost m_host;

		/// <summary>
		/// Gets or sets the external callback.
		/// </summary>
		/// <value>The external callback.</value>
		protected GCHandle ExternalCallback {
			get; 
			set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MonoDaemon.ServiceHost"/> class.
		/// </summary>
		public ServiceHost ()
		{
			Console.WriteLine ("WCF Host - started");
		}


		/// <summary>
		/// Shows the message.
		/// </summary>
		/// <param name="message">Message.</param>
		protected void ShowMessage (string message)
		{
			if (!string.IsNullOrEmpty (message)) {
				Console.WriteLine (message);
				var bytes = Encoding.Default.GetBytes (message);
				var buffer = new byte[bytes.Length + 1];
				Array.Copy (bytes, buffer, bytes.Length);
				buffer [buffer.Length - 1] = (byte) '\0';
				((Utilities.QtExternalCode)ExternalCallback.Target).Invoke (buffer);
			}
		}


		/// <summary>
		/// Initializes the host.
		/// </summary>
		/// <param name="callback">Callback.</param>
		public void InitializeHost (IntPtr callback)
		{
			if (callback != IntPtr.Zero) {
				ExternalCallback = GCHandle.Alloc (Marshal.GetDelegateForFunctionPointer<Utilities.QtExternalCode> (callback));
				DaemonOperation.QtMessenger = new Action<string> (ShowMessage);
			}

			ShowMessage ("Creating binding...");
			var binding = new BasicHttpBinding ();
			binding.Security.Mode = BasicHttpSecurityMode.None; 

			ShowMessage ("Allocating endpoint addresses...");
			var address = new Uri ("http://localhost:8888/monodaemon");
			var addressMex = new Uri ("http://localhost:8888/monodaemon/mex");

			ShowMessage ("Creating host...");
			m_host = new System.ServiceModel.ServiceHost (typeof(DaemonOperation),
				new Uri[] { new Uri ("http://localhost:8888/monodaemon") }); 

			ShowMessage ("Adding behaviors...");
			m_host.Description.Behaviors.Remove<System.ServiceModel.Description.ServiceMetadataBehavior> ();
			m_host.Description.Behaviors.Add (new System.ServiceModel.Description.ServiceMetadataBehavior {
				HttpGetEnabled = true, HttpsGetEnabled = false
			}); 

			ShowMessage ("Adding endpoints...");
			m_host.AddServiceEndpoint (typeof(IDaemonOperation), binding, address);
			m_host.AddServiceEndpoint (System.ServiceModel.Description.ServiceMetadataBehavior.MexContractName, 
				System.ServiceModel.Description.MetadataExchangeBindings.CreateMexHttpBinding (), addressMex); 

			ShowMessage ("Starting host...");
			m_host.Open ();
		}
	}
}