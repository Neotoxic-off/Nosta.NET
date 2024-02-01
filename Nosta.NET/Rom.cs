using System;
using System.IO;

namespace Nosta.NET
{
    public class Rom : Logged
    {
        public enum Architecture
        {
            x64,
            x86,
            unknown
        };

        public Architecture architecture { get; set; }
        public string path { get; set; }
        public int bufferSize { get; set; }
        public bool exists { get; set; }
        public List<byte> opcodes { get; set; }

        public Rom(string path)
        {
            this.path = path;
            this.exists = File.Exists(path);
            this.architecture = GetArchitecture();
            this.bufferSize = GetBufferSize();
            this.opcodes = GetOpcodes();
        }

        public int GetBufferSize()
        {
            Dictionary<Architecture, int> paddings = new Dictionary<Architecture, int>()
            {
                { Architecture.x64, 4096 },
                { Architecture.x86, 4096 },
                { Architecture.unknown, 1 }
            };

            return (paddings[this.architecture]);
        }

        public Architecture GetArchitecture()
        {
            FileInfo? fileInfo = null;
            int size64 = (4 * 1024 * 1024);

            if (this.exists == true)
            {
                Log(Logger.Types.Information, $"checking rom architecture");
                fileInfo = new FileInfo(this.path);
                if (fileInfo.Length > size64)
                {
                    Log(Logger.Types.Success, $"architecture: x64");

                    return (Architecture.x64);
                }

                Log(Logger.Types.Success, $"architecture: x86");

                return (Architecture.x86);
            }
            Log(Logger.Types.Error, $"architecture: unknown");

            return (Architecture.unknown);
        }

        public List<byte> GetOpcodes()
        {
            int bytesRead = 0;
            byte[]? buffer = null;
            List<byte> data = new List<byte>();

            if (this.exists == true && this.architecture != Architecture.unknown)
            {
                Log(Logger.Types.Information, $"loading opcodes");
                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (BinaryReader binaryReader = new BinaryReader(fileStream))
                {
                    buffer = new byte[bufferSize];

                    while ((bytesRead = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        for (int i = 0; i < bytesRead; i++)
                        {
                            data.Add(buffer[i]);
                        }
                    }
                }
                Log(Logger.Types.Success, $"loaded {data.Count} opcodes");
            }

            return (data);
        }
    }
}
