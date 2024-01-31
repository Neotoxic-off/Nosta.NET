using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nosta.NET
{
    public class Logged
    {
        public Logger logger { get; set; }

        public Logged()
        {
            logger = new Logger();
        }

        virtual public void Log(Logger.Types type, object message)
        {
            logger.Log(type, message);
        }
    }
}
