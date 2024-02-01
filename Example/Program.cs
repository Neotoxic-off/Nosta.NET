namespace Nosta.NET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Nosta.NET.Factory factory = new Factory("rom.gba");
            Nosta.NET.Cpu cpu = new NET.Cpu();

            object[] data = { cpu.PC, cpu.RA, cpu.RAF };

            foreach (var op in factory.rom.opcodes)
            {
                factory.Bind(op, factory.DullFunction);
            }

            factory.opcodes[factory.rom.opcodes[0]].executable(data);

            factory.Log(Logger.Types.Information, $"opcode loaded {factory.opcodes.Count}");
        }
    }
}
