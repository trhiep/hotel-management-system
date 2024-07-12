using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using log4net;

namespace HotelManagementSystem.Logs
{
    public static class LoggerConfig
    {
        public static void Configure()
        {
            var hierarchy = (Hierarchy)LogManager.GetRepository();

            // General Appender
            var generalAppender = new FileAppender
            {
                Name = "GeneralAppender",
                File = "general.log",
                AppendToFile = true,
                Layout = new PatternLayout("%date [%thread] %-5level %logger - %message%newline")
            };
            generalAppender.ActivateOptions();
            hierarchy.Root.AddAppender(generalAppender);

            // Info Appender
            var infoAppender = new FileAppender
            {
                Name = "InfoAppender",
                File = "info.log",
                AppendToFile = true,
                Layout = new PatternLayout("%date [%thread] %-5level %logger - %message%newline")
            };
            infoAppender.AddFilter(new log4net.Filter.LevelRangeFilter { LevelMin = log4net.Core.Level.Info, LevelMax = log4net.Core.Level.Info });
            infoAppender.ActivateOptions();
            hierarchy.Root.AddAppender(infoAppender);

            // Error Appender
            var errorAppender = new FileAppender
            {
                Name = "ErrorAppender",
                File = "error.log",
                AppendToFile = true,
                Layout = new PatternLayout("%date [%thread] %-5level %logger - %message%newline")
            };
            errorAppender.AddFilter(new log4net.Filter.LevelRangeFilter { LevelMin = log4net.Core.Level.Error, LevelMax = log4net.Core.Level.Error });
            errorAppender.ActivateOptions();
            hierarchy.Root.AddAppender(errorAppender);

            hierarchy.Root.Level = log4net.Core.Level.All;
            hierarchy.Configured = true;
        }
    }
}
