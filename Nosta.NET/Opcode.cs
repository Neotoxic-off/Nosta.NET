namespace Nosta.NET
{
    public class Opcode : Logged
    {
        public long operation { get; set; }
        public string value { get; set; }
        public Action<int[]> executable { get; set; }

        public Opcode(long operation)
        {
            this.operation = operation;
            this.value = string.Format("{0:X}", operation);
        }

        public void Link(Action<int[]> executable)
        {
            this.executable = executable;
        }
    }
}