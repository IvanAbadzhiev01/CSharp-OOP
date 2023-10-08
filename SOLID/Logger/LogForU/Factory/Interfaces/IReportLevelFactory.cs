using LogForU.Core.Enums;

namespace LogForU.Factory.Interfaces
{
    public interface IReportLevelFactory
    {
        ReportLevel ReportLevelSet(string reportLevel);
    }
}
