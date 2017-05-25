namespace LogTask.Logger_Class
{
    internal class LogHelper
    {
        private readonly log4net.ILog _logger;
        internal LogHelper()
        {
            log4net.Config.XmlConfigurator.Configure();
            _logger = log4net.LogManager.GetLogger("Logger");
        }

        public void LogError(string msg)
        {
            _logger.Error(msg);
        }
        public void LogWarning(string msg)
        {
            _logger.Warn(msg);
        }
        public void LogInfo(string msg)
        {
            _logger.Info(msg);
        }
    }
}
