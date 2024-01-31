namespace Nosta.NET
{
    public class Factory : Logged
    {
        public Dictionary<long, Opcode> opcodes { get; set; }
        public Rom rom { get; set; }

        public Factory(string romPath)
        {
            opcodes = new Dictionary<long, Opcode>();
            rom = new Rom(romPath);
        }

        public bool Bind(long instruction, Opcode opcode)
        {          
            if (opcodes.ContainsKey(instruction) == false)
            {
                Log(Logger.Types.Success, $"{instruction} binded to {opcode}");
                opcodes[instruction] = opcode;

                return (true);
            }
            Log(Logger.Types.Error, $"{instruction} failed to bind");
            return (false);
        }

        public void DullFunction(int[] args)
        {
            Console.WriteLine($"DullFunction called with {args.Count()} args");
        }
    }
}
