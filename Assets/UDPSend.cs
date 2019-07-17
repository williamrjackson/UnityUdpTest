using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

namespace MOS
{
	public class UDPSend : MonoBehaviour
	{
		public int port; // define in Start
		private string IP = "127.0.0.1";
		
		// "connection" things
		IPEndPoint remoteEndPoint;
		UdpClient client;


		// start from unity3d
		public void Start ()
		{
			// define port
			if (port == 0)
			{
				port = 8051;
			}

			// ----------------------------
			// Senden
			// ----------------------------
			remoteEndPoint = new IPEndPoint (IPAddress.Parse(IP), port);
			client = new UdpClient();

			// status
			print ("Sending to " + IP + " : " + port);
		}

		// inputFromConsole
		private void inputFromConsole ()
		{
			try
			{
				string text;
				do
				{
					text = Console.ReadLine ();

					// Den Text zum Remote-Client senden.
					if (text != "")
					{

						// Daten mit der UTF8-Kodierung in das Binärformat kodieren.
						byte[] data = Encoding.UTF8.GetBytes (text);

						// Den Text zum Remote-Client senden.
						client.Send (data, data.Length, remoteEndPoint);
					}
				} while (text != "");
			}
			catch (Exception err)
			{
				print (err.ToString ());
			}

		}

		// sendData
		public void sendString(string message)
		{
			try
			{
				byte[] data = Encoding.UTF8.GetBytes (message);

				client.Send (data, data.Length, remoteEndPoint);
			}
			catch (Exception err)
			{
				Debug.Log(err.ToString());
			}
		}
	}
}
