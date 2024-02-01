namespace Nosta.NET
{
    public class Cpu
    {
        public ushort PC { get; set; }
        public ushort SP { get; set; }

        public byte RA { get; set; }
        public byte RB { get; set; }
        public byte RC { get; set; }
        public byte RD { get; set; }
        public byte RE { get; set; }
        public byte RF { get; set; }
        public byte RH { get; set; }
        public byte RL { get; set; }

        public ushort RAF
        {
            get
            {
                return (ushort)((RA << 8) | RF);
            }
            set
            {
                RA = (byte)(value >> 8);
                RF = (byte)(value & 0xFF);
            }
        }

        public ushort RBC
        {
            get
            {
                return (ushort)((RB << 8) | RC);
            }
            set
            {
                RB = (byte)(value >> 8);
                RC = (byte)(value & 0xFF);
            }
        }

        public ushort RDE
        {
            get
            {
                return (ushort)((RD << 8) | RE);
            }
            set
            {
                RD = (byte)(value >> 8);
                RE = (byte)(value & 0xFF);
            }
        }

        public ushort RHL
        {
            get
            {
                return (ushort)((RH << 8) | RL);
            }
            set
            {
                RH = (byte)(value >> 8);
                RL = (byte)(value & 0xFF);
            }
        }
    }
}
