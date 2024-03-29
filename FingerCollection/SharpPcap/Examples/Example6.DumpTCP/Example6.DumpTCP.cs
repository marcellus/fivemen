using System;
using Tamir.IPLib;
using Tamir.IPLib.Packets;

namespace Tamir.IPLib.Test.Example6
{
	/// <summary>
	/// Basic capture example
	/// </summary>
	public class DumpTCP
	{
		/// <summary>
		/// Basic capture example
		/// </summary>
		[STAThread]
		public static void Main(string[] args)
		{
			string ver = Tamir.IPLib.Version.GetVersionString();
			/* Print SharpPcap version */
			Console.WriteLine("SharpPcap {0}, Example6.DumpTCP.cs", ver);
			Console.WriteLine();

			/* Retrieve the device list */
			PcapDeviceList devices = SharpPcap.GetAllDevices();

			/*If no device exists, print error */
			if(devices.Count<1)
			{
				Console.WriteLine("No device found on this machine");
				return;
			}
			
			Console.WriteLine("The following devices are available on this machine:");
			Console.WriteLine("----------------------------------------------------");
			Console.WriteLine();

			int i=0;

			/* Scan the list printing every entry */
			foreach(PcapDevice dev in devices)
			{
				/* Description */
				Console.WriteLine("{0}) {1}",i,dev.PcapDescription);
				i++;
			}

			Console.WriteLine();
			Console.Write("-- Please choose a device to capture: ");
			i = int.Parse( Console.ReadLine() );

			PcapDevice device = devices[i];

			//Register our handler function to the 'packet arrival' event
			device.PcapOnPacketArrival += 
				new SharpPcap.PacketArrivalEvent( device_PcapOnPacketArrival );

			//Open the device for capturing
			//true -- means promiscuous mode
			//1000 -- means a read wait of 1000ms
			device.PcapOpen(true, 1000);

			//tcpdump filter to capture only TCP/IP packets			
			string filter = "ip and tcp";
			//Associate the filter with this capture
			device.PcapSetFilter( filter );

			Console.WriteLine();
			Console.WriteLine
				("-- The following tcpdump filter will be applied: \"{0}\"", 
				filter);
			Console.WriteLine
				("-- Listenning on {0}, hit 'Ctrl-C' to exit...",
				device.PcapDescription);

			//Start capture 'INFINTE' number of packets
			device.PcapCapture( SharpPcap.INFINITE );

			//Close the pcap device
			//(Note: this line will never be called since
			// we're capturing infinite number of packets
			device.PcapClose();
		}

		/// <summary>
		/// Prints the time, length, src ip, src port, dst ip and dst port
		/// for each TCP/IP packet received on the network
		/// </summary>
		private static void device_PcapOnPacketArrival(object sender, Packet packet)
		{			
			if(packet is TCPPacket)
			{				
				DateTime time = packet.PcapHeader.Date;
				int len = packet.PcapHeader.PacketLength;

				TCPPacket tcp = (TCPPacket)packet;
				string srcIp = tcp.SourceAddress;
				string dstIp = tcp.DestinationAddress;
				int srcPort = tcp.SourcePort;
				int dstPort = tcp.DestinationPort;

				Console.WriteLine("{0}:{1}:{2},{3} Len={4} {5}:{6} -> {7}:{8}", 
					time.Hour, time.Minute, time.Second, time.Millisecond, len,
					srcIp, srcPort, dstIp, dstPort);
			}
		}
	}
}
