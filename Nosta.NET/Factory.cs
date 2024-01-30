namespace Nosta.NET
{
    public class Factory
    {
        public Dictionary<long, Opcode> opcodes { get; set; }
        public Rom rom { get; set; }

        public Factory(string romPath)
        {
            opcodes = new Dictionary<long, Opcode>();
            rom = new Rom(romPath);

            Prepare();
        }

        private void Prepare()
        {
            foreach (long instruction in rom.opcodes)
            {
                Bind(instruction, new Opcode(instruction)
                {
                    executable = DullFunction
                });
            }
        }

        public bool Bind(long instruction, Opcode opcode)
        {          
            if (opcodes.ContainsKey(instruction) == false)
            {
                opcodes[instruction] = opcode;

                return (true);
            }

            return (false);
        }

        public void DullFunction(int[] args)
        {
            Console.WriteLine($"DullFunction called with {args.Count()} args");
        }
    }
}
