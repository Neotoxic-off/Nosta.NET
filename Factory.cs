namespace Nosta.NET
{
    public class Factory
    {
        public Dictionary<long, Opcode> opcodes { get; set; }

        public Factory()
        {
            opcodes = new Dictionary<long, Opcode>();
        }

        public bool Bind(long instruction, Opcode opcode)
        {          
            if (opcodes.ContainsKey(instruction) == false)
            {
                opcodes.Add(
                    { instruction, opcode }
                );

                return (true);
            }

            return (false);
        }
    }
}
