using LogForU.Core.Enums;
using LogForU.Exceptions;
using LogForU.Factory.Interfaces;

namespace LogForU.Factory
{
    public class ReportLevelFactory : IReportLevelFactory
    {
        public ReportLevel ReportLevelSet(string reportLevel)
        {
            switch (reportLevel)
            {
                case "INFO":
                    return ReportLevel.Info;
                case "WARNING":
                    return ReportLevel.Warning;
                case "ERROR":
                    return ReportLevel.Error;
                case "CRITICAL":
                    return ReportLevel.Critical;
                case "FATAL":
                    return ReportLevel.Fatal;
                default:
                    throw new InvalidReportLevelExceptions();
            }
        }
    }
}
