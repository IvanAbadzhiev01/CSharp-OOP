using LogForU.Core.Appenders;
using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Enums;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Exceptions;
using LogForU.Factory.Interfaces;

namespace LogForU.Factory
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string appenderType, ILayout layout, ReportLevel reportLevel)
        {
            switch (appenderType)
            {
                case "ConsoleAppender":
                    return new ConsoleAppender(layout, reportLevel);
                case "FileAppender":
                    return new FileAppender(layout, reportLevel);
                default:
                    throw new InvaidAppenderType();
            }
        }

        public IAppender CreateAppender(string appenderType, ILayout layout)
        {
            switch (appenderType)
            {
                case "ConsoleAppender":
                    return new ConsoleAppender(layout);
                case "FileAppender":
                    return new FileAppender(layout);
                default:
                    throw new InvaidAppenderType();
            }
        }
    }
}
