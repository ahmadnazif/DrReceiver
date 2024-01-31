using NLog;
using NLog.Config;
using System.Runtime.CompilerServices;

namespace DrReceiver.Services;

public class Logger
{
    private readonly bool enable;
    private readonly NLog.Logger debugLogger = LogManager.GetLogger("Debug");
    private readonly NLog.Logger drLogger = LogManager.GetLogger("Dr");

    public LoggingConfiguration LoggingConfiguration { get; }

    public Logger(IConfiguration cfg)
    {
        enable = bool.Parse(cfg["NLogConfig:Enable"]);

        if (enable)
        {
            var path = cfg["NLogConfig:LogPath"];
            var logList = LoggersToAdd();
            var ext = cfg["NLogConfig:LogFileType"];

            NLogConfig config = new(path);
            foreach (var log in logList)
                config.AddLog(log, $"{log}{ext}");
            LoggingConfiguration = config.FinalizeConfig();
        }
    }

    private static List<string> LoggersToAdd()
    {
        return
        [
            "Debug",
            "Dr"
        ];
    }


    public void Debug(string txt)
    {
        if (enable)
        {
            debugLogger.Info(txt);
        }
    }

    public void Dr(string str)
    {
        if (enable)
        {
            drLogger.Info($"{str}");
        }
    }
}
