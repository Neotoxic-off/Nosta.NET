using System;
using System.IO;

namespace Nosta.NET
{
    public class Rom
    {
        public enum Architecture
        {
            x64,
            x86,
            unknown
        };

        public Architecture architecture { get; set; }
        public string path { get; set; }
        public int padding { get; set; }
        public bool exists { get; set; }
        public List<long> opcodes { get; set; }

        public Rom(string path)
        {
            this.path = path;
            this.exists = File.Exists(path);
            this.architecture = GetArchitecture();
            this.padding = GetPadding();
            this.opcodes = GetOpcodes();
        }

        public int GetPadding()
        {
            Dictionary<Architecture, int> padding = new Dictionary<Architecture, int>()
            {
                { Architecture.x64, 8 },
                { Architecture.x86, 4 },
                { Architecture.unknown, 1 }
            };

            return (padding[this.architecture]);
        }


        public Architecture GetArchitecture()
        {
            FileInfo? fileInfo = null;
            int size64 = (4 * 1024 * 1024);

            if (this.exists == true)
            {
                fileInfo = new FileInfo(this.path);
                if (fileInfo.Length > size64)
                {
                    return (Architecture.x64);
                }

                return (Architecture.x86);
            }

            return (Architecture.unknown);
        }

        public List<long> GetOpcodes()
        {
            List<long> opcodes = new List<long>();
            int bytesRead = 0;
            byte[]? buffer = null;

            if (this.exists == true && this.architecture != Architecture.unknown)
            {
                using (FileStream fileStream = new FileStream(this.path, FileMode.Open, FileAccess.Read))
                {
                    buffer = new byte[this.padding];

                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        opcodes.Add(
                            BitConverter.ToInt64(buffer, 0)
                        );
                    }
                }
            }

            return (opcodes);
        }
    }
}