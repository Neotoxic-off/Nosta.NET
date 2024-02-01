namespace Nosta.NET
{
    public class Input
    {
        public enum States
        {
            Stopped,
            Running
        };

        public ConsoleKeyInfo userInputHandler { get; set; }
        public States state { get; set; }

        public bool Available()
        {
            return (Console.KeyAvailable);
        }

        public void Start()
        {
            if (state == States.Stopped && Available() == true)
            {
                state = States.Running;
                userInputHandler = Console.ReadKey(true);
            }
        }

        public void Stop()
        {
            if (state == States.Running)
            {
                state = States.Stopped;
            }
        }
    }
}
