namespace Nosta.NET
{
    public class Opcode
    {
        public long operation { get; set; }
        public Action<int[]> executable { get; set; }

        public Opcode(long operation)
        {
            this.operation = operation;
        }

        public void Link(Action<int[]> executable)
        {
            this.executable = executable;
        }
    }
}