using System;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;

namespace HardwareInfo
{
	internal class HardwareDetection
	{
		public static string macIdInfo()
		{
			String macAdress = string.Empty;
			string mac = null;
			foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
			{
				OperationalStatus ot = nic.OperationalStatus;
				if (nic.OperationalStatus == OperationalStatus.Up)
				{
					macAdress = nic.GetPhysicalAddress().ToString();
					break;
				}
			}
			for (int i = 0; i <= macAdress.Length - 1; i++)
			{
				mac = mac + ":" + macAdress.Substring(i, 2);
				// mac adresini alırken parçalı aldığı için aralara : işareti ekliyoruz
				i++;
			}

			// string' in en başına fazladan eklenen 0. indexteki karakter olan : işaretini siliyoruz.

			mac = mac.Remove(0, 1);
			return mac;
		}

		

	

		public static string getHddSerial()
		{
			String hddSerial = null;

			ManagementObjectSearcher hddSearcher = new ManagementObjectSearcher("Select * FROM WIN32_DiskDrive");
			ManagementObjectCollection mObject = hddSearcher.Get();

			foreach (ManagementObject obj in mObject)
			{
				hddSerial = (string)obj["SerialNumber"];
			}
			return hddSerial;
		}

		public static string getRamSize()
		{
			string ramSizeInfo = null;
			ManagementObjectSearcher ramSearcher = new ManagementObjectSearcher("Select * From Win32_ComputerSystem");

			foreach (ManagementObject mObject in ramSearcher.Get())
			{
				double Ram_Bytes = (Convert.ToDouble(mObject["TotalPhysicalMemory"]));
				double ramgb = Ram_Bytes / 1073741824;
				double ramSize = Math.Ceiling(ramgb);
				ramSizeInfo = ramSize.ToString() + " GB";
			}
			return ramSizeInfo;
		}

		public static string getVideoControllerInfo()
		{
			string videoControllerInfo = null;
			string name = null;
			string ram = null;
			string horizontalResolution = null;
			string verticalResolution = null;
			string deviceID = null;

			ManagementObjectSearcher vidSearcher = new ManagementObjectSearcher("Select * from Win32_VideoController Where availability='3'"); // Where availability='3'");

			foreach (ManagementObject mObject in vidSearcher.Get())
			{
				name = mObject["name"].ToString();
				ram = (Convert.ToDouble(mObject["AdapterRam"]) / 1073741824).ToString();
				deviceID = (string)mObject["DeviceID"];
				horizontalResolution = mObject["CurrentHorizontalResolution"].ToString();
				verticalResolution = mObject["CurrentVerticalResolution"].ToString();
			}
			videoControllerInfo = name + "\r\n Ram Miktarı : " + ram + " GB \r\n ID : " + deviceID + "\r\n Çözünürlük :" + horizontalResolution + " x " + verticalResolution;

			return videoControllerInfo;
		}

		public static string getOSinfo()
		{
			string osSerial = null;
			string osVersionInfo = null;
			string OSinfo = null;

			ManagementObjectSearcher osInfo = new ManagementObjectSearcher("Select * From Win32_OperatingSystem");

			foreach (ManagementObject osInfoObj in osInfo.Get())
			{
				osSerial = (string)osInfoObj["Caption"];
				osVersionInfo = (string)osInfoObj["Version"];
				OSinfo = osSerial + " - " + osVersionInfo;
			}

			return OSinfo;
		}
	}
}