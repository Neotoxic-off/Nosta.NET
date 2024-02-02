namespace Nosta.NET
{
    public class Cpu
    {
        [Flags]
        public enum Flags
        {
            Zero = 1 << 7,
            Subtract = 1 << 6,
            HalfCarry = 1 << 5,
            Carry = 1 << 4,
        }

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
            get => (ushort)((RA << 8) | RF);
            set
            {
                RA = (byte)(value >> 8);
                RF = (byte)(value & 0xFF);
            }
        }

        public ushort RBC
        {
            get => (ushort)((RB << 8) | RC);
            set
            {
                RB = (byte)(value >> 8);
                RC = (byte)(value & 0xFF);
            }
        }

        public ushort RDE
        {
            get => (ushort)((RD << 8) | RE);
            set
            {
                RD = (byte)(value >> 8);
                RE = (byte)(value & 0xFF);
            }
        }

        public ushort RHL
        {
            get => (ushort)((RH << 8) | RL);
            set
            {
                RH = (byte)(value >> 8);
                RL = (byte)(value & 0xFF);
            }
        }

        public void LoadRegister(ref byte register, byte value)
        {
            register = value;
            UpdateFlagsAfterLoad(value);
        }

        public void LoadRegister(ref ushort register, ushort value)
        {
            register = value;
        }

        public void IncrementRegister(ref byte register)
        {
            register++;
            UpdateFlagsAfterIncDec(register);
        }

        public void DecrementRegister(ref byte register)
        {
            register--;
            UpdateFlagsAfterIncDec(register);
        }

        public void Add(byte value)
        {
            int result = RA + value;

            RF = 0;

            if (result > 0xFF)
                RF |= (byte)Flags.Carry;

            RA = (byte)result;

            UpdateFlagsAfterArithmetic(RA, value, result);
        }

        private void UpdateFlagsAfterLoad(byte value)
        {
            RF = 0;

            SetZeroFlag(value == 0);
        }

        private void UpdateFlagsAfterIncDec(byte result)
        {
            RF = (byte)(RF & ~((byte)Flags.Zero | (byte)Flags.Subtract | (byte)Flags.HalfCarry));
            SetZeroFlag(result == 0);
            RF |= (byte)Flags.Subtract;
        }

        private void UpdateFlagsAfterArithmetic(byte operand1, byte operand2, int result)
        {
            RF |= (byte)Flags.Subtract;
            SetZeroFlag(result == 0);
            SetCarryFlag(result > 0xFF);
            SetHalfCarryFlag(((operand1 & 0x0F) + (operand2 & 0x0F)) > 0x0F);
        }

        private void SetZeroFlag(bool condition)
        {
            if (condition)
                RF |= (byte)Flags.Zero;
        }

        private void SetCarryFlag(bool condition)
        {
            if (condition)
                RF |= (byte)Flags.Carry;
        }

        private void SetHalfCarryFlag(bool condition)
        {
            if (condition)
                RF |= (byte)Flags.HalfCarry;
        }
    }
}
