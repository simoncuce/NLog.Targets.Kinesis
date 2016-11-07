namespace NLog.Targets.Kinesis
{
    internal static class Log
    {
        private static readonly Logger LoggerClass = LogManager.GetCurrentClassLogger();

        public static Logger Logger()
        {
            return LoggerClass;
        }
    }
}