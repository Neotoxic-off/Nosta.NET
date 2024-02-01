namespace Nosta.NET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Nosta.NET.Factory factory = new Factory("rom.gba");
            int[] data = { 1, 2, 3 };

            foreach (var op in factory.rom.opcodes) {
                factory.Bind(op, factory.DullFunction);
            }

            Console.WriteLine($"{factory.opcodes.Count}");
        }
    }
}
