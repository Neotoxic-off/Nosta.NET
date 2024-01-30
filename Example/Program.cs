namespace Nosta.NET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Nosta.NET.Factory factory = new Factory("rom.gba");

            Console.WriteLine(factory.rom.exists);
            Console.WriteLine(factory.rom.architecture);
            Console.WriteLine(factory.rom.padding);

            factory.rom.opcodes = factory.rom.GetOpcodes();
            Console.WriteLine(factory.opcodes.Count());

            foreach (var opcode in factory.opcodes)
            {
                Console.WriteLine(opcode.Key.ToString());
                Console.WriteLine(opcode.Value.ToString());
            }
        }
    }
}