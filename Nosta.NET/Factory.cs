namespace Nosta.NET
{
    public class Factory : Logged
    {
        public Dictionary<byte, Opcode> opcodes { get; set; }
        public Rom rom { get; set; }

        public Factory(string romPath)
        {
            opcodes = new Dictionary<byte, Opcode>();
            rom = new Rom(romPath);
        }

        public bool Bind(byte instruction, Action<object[]> action)
        {
            if (opcodes.ContainsKey(instruction) == false)
            {
                opcodes[instruction] = new Opcode(instruction) {
                    executable = action
                };

                return (true);
            }

            return (false);
        }

        public void DullFunction(object[] args)
        {
            Log(Logger.Types.Information, $"DullFunction called with {args.Count()} args");

            foreach (object o in args)
            {
                Log(Logger.Types.Information, $"{o}");
            }
        }
    }
}
