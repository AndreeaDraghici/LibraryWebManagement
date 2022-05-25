using WebApp.Services.Interfaces;

namespace WebApp.Services
{
    public class ConsoleLogger : ILog
    {
        public void  Info(string textToLog)
        {
            Console.WriteLine($"Logger message: {textToLog}");
        }
    }
}
