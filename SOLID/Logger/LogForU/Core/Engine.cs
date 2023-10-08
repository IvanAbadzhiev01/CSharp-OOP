using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Enums;
using LogForU.Core.Interfaces;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Core.Logers;
using LogForU.Core.Logers.Interfaces;
using LogForU.Factory.Interfaces;
using LogForU.IO.Interfaces;

namespace LogForU.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private ILayoutFactory layoutFactory;
        private IReportLevelFactory reportLevelFactory;
        private IAppenderFactory appenderFactory;
        private readonly ICollection<ILogger> loggers;

        public Engine(IReader reader,
            IWriter writer,

            ILayoutFactory layoutFactory,
            IReportLevelFactory reportLevelFactory,
            IAppenderFactory appenderFactory)
        {
            this.reader = reader;
            this.writer = writer;

            this.loggers = new List<ILogger>();
            this.layoutFactory = layoutFactory;
            this.reportLevelFactory = reportLevelFactory;
            this.appenderFactory = appenderFactory;

        }

        public void Run()
        {
            int n = int.Parse(reader.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commandInfo = reader.ReadLine().Split(" ");
                loggers.Add(CreateLoger(commandInfo));
            }


        }

        private ILogger CreateLoger(string[] commandInfo)
        {
            string appenderInfo = commandInfo[0];
            string layoutInfo = commandInfo[1];
            ILayout layout = layoutFactory.CreateLayout(layoutInfo);
            if (commandInfo.Length == 3)
            {
                string reportLevelInfo = commandInfo[2];
                ReportLevel reportLevel = reportLevelFactory.ReportLevelSet(reportLevelInfo);
                IAppender appenderRL = appenderFactory.CreateAppender(appenderInfo, layout, reportLevel);
                return new Logger(appenderRL);

            }
            IAppender appender = appenderFactory.CreateAppender(appenderInfo, layout);
            return new Logger(appender);



        }
    }
}
