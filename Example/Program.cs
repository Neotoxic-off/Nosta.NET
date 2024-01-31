namespace Nosta.NET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Nosta.NET.Factory factory = new Factory("rom.gba");
            int[] data = { 1, 2, 3 };

            factory.Bind(factory.rom.opcodes[0], new Opcode(factory.rom.opcodes[0])
            {
                executable = factory.DullFunction
            });

            factory.opcodes[factory.rom.opcodes[0]].executable(data);
        }
    }
}