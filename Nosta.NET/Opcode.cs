namespace Nosta.NET
{
    public class Opcode : Logged
    {
        public byte instruction { get; set; }
        public string value { get; set; }
        public Action<int[]> executable { get; set; }

        public Opcode(byte instruction)
        {
            this.instruction = instruction;
            this.value = string.Format("{0:X}", instruction);
        }

        public void Link(Action<int[]> executable)
        {
            this.executable = executable;
        }
    }
}