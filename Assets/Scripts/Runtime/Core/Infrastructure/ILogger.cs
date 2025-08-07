namespace Runtime.Core.Infrastructure
{
    public interface ILogger
    {
        void Log(string message);
        void Warning(string message);
        void Error(string message);
    }
}