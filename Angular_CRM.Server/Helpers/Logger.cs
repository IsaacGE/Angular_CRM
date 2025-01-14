using log4net;
using System.Reflection;

namespace Angular_CRM.Server.Helpers
{
    public class Logger : ILogger
    {
        private readonly ILog _logger;

        public Logger()
        {
            this._logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        }

        public void Debug(string message)
        {
            this._logger?.Debug(message);
        }

        public void Info(string message)
        {
            this._logger?.Info(message);
        }

        public void Warn(string message)
        {
            this._logger.Warn(message);
        }

        public void Error(string message, Exception? ex = null)
        {
            var currentException = ex;
            var lastException = ex;

            while (true)
            {
                message += $"\nException Message: {currentException?.Message}";
                currentException = currentException?.InnerException;

                if (currentException == null) break;
                else lastException = currentException;
            }

            this._logger?.Error(message, lastException);
        }
    }
}
