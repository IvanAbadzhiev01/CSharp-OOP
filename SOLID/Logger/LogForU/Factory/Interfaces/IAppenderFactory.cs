using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Enums;
using LogForU.Core.Layouts.Interfaces;

namespace LogForU.Factory.Interfaces
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string appenderType, ILayout layout, ReportLevel reportLevel);
        IAppender CreateAppender(string appenderType, ILayout layout);

    }
}
