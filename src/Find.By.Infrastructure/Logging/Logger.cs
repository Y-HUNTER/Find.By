using System;

namespace Find.By.Core.Logging
{
    public class Logger
    {
        private static readonly Logger _logger;

        public static Logger GetLogger()
        {
            return _logger;
        }

        static Logger()
        {
            _logger = new Logger();
        }

        private Logger()
        {
            
        }

        public void Warning(string message)
        {
            WriteMessage("Warning", message);
        }

        public void Error(string message)
        {
            WriteMessage("Error", message);
        }

        public void Info(string message)
        {
            WriteMessage("Info", message);
        }

        private void WriteMessage(string type, string message)
        {
            Console.WriteLine("{0}|{1}|{2}", DateTime.Now.ToShortTimeString(), type, message);
        }
    }
}
