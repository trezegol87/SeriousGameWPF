using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Management;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SeriousGameWPF
{
    /// <summary>
    /// Helps us to check wether the user tries to YARRRR
    /// </summary>
    internal class PirateDetector 
    {
        public string CentralProcessingUnitId { get; set; }
        public string MacAddress { get; set; }
        public string BaseIdentifier { get; set; }
        public string BiosIdentifier { get; set; }
        public string HardDiscIdentifier { get; set; }
        public string VideoCardIdentifier { get; set; }
        
        /// <summary>
        /// Get hardware unique keys
        /// </summary>
        public PirateDetector()
        {
            this.CentralProcessingUnitId = FingerPrint.CpuId();
            this.MacAddress = FingerPrint.MacId();
            this.BaseIdentifier = FingerPrint.BaseId();
            this.BiosIdentifier = FingerPrint.BiosId();
            this.HardDiscIdentifier = FingerPrint.DiskId();
            this.VideoCardIdentifier = FingerPrint.VideoId();
        }

        /// <summary>
        /// Gets MAC Address
        /// </summary>
        /// <returns>mac</returns>
        private static string GetMacAddress()
        {
            var macAddresses = string.Empty;

            foreach (var networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += networkInterface.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return macAddresses;
        }

        /// <summary>
        /// Gets CPU identifier
        /// </summary>
        /// <returns>id</returns>
        private string CpuId()
        {
            var cpuInfo = string.Empty;
            var mc = new ManagementClass("win32_processor");
            var moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if (cpuInfo == "")
                {
                    //Get only the first CPU's ID
                    cpuInfo = mo.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            return cpuInfo;
        }

        /// <summary>
        /// Gets HDD identifier
        /// </summary>
        /// <returns>id</returns>
        private string HddId()
        {
            ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + "C" + @":""");
            dsk.Get();
            string volumeSerial = dsk["VolumeSerialNumber"].ToString();
            return volumeSerial;
        }

        /// <summary>
        /// Reads the data.bin file located in root
        /// </summary>
        public bool ReadAuthenticationFile()
        {
            IFormatter formatter = new BinaryFormatter();
            StringBuilder sb = new StringBuilder();
            const string fileName = "data.bin";

            if (!File.Exists(fileName)) return false; //this file MUST be there

            if (new FileInfo(fileName).Length == 0) //first run 
            {
                UpdateFile(fileName, sb, formatter);
                return true;   
            }

            using (var stream = new FileStream("data.bin", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                formatter = new BinaryFormatter();
                var piratePrint = formatter.Deserialize(stream);
                var separatedPrint = ((string)piratePrint).Split('#');
                var isPirateVersion = CheckPiracy(separatedPrint);

                //UpdateFile(fileName, sb, formatter);  //In case of hardware change

                return isPirateVersion;
            }
        }

        private void UpdateFile(string fileName, StringBuilder sb, IFormatter formatter)
        {
            sb.Append(FingerPrint.CpuId());
            sb.Append('#');
            sb.Append(FingerPrint.BaseId());
            sb.Append('#');
            sb.Append(FingerPrint.BiosId());
            sb.Append('#');
            sb.Append(FingerPrint.DiskId());
            sb.Append('#');
            sb.Append(FingerPrint.MacId());
            sb.Append('#');
            sb.Append(FingerPrint.VideoId());

            using (var stream = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.None))
            {
                //should be object, not string
                formatter.Serialize(stream, sb.ToString());
            }
        }

        /// <summary>
        /// Checks wether it is still the same machine 
        /// or slightly different, in case of hardware upgrade
        /// </summary>
        /// <param name="separatedPrint">keys separated with '-'</param>
        /// <returns>user tries to YARRRR</returns>
        private bool CheckPiracy(IReadOnlyList<string> separatedPrint)
        {
            const int tolerance = 4; //in case of hardware upgrade
            var hardwareDeviation = 0;

            if (separatedPrint[0] != CentralProcessingUnitId)
                hardwareDeviation++;
            if (separatedPrint[1] != BaseIdentifier)
                hardwareDeviation++;
            if (separatedPrint[2] != BiosIdentifier)
                hardwareDeviation++;
            if (separatedPrint[3] != HardDiscIdentifier)
                hardwareDeviation++;
            if (separatedPrint[4] != MacAddress)
                hardwareDeviation++;
            if (separatedPrint[5] != VideoCardIdentifier)
                hardwareDeviation++;

            return hardwareDeviation <= tolerance;
        }
    }
}
