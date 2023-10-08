using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Enums;
using LogForU.Core.IO.Interfaces;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Core.Models.Interfaces;
using System;
using System.IO;

namespace LogForU.Core.Appenders
{
    public class FileAppender : IAppender
    {

        public FileAppender(ILayout layout, ILogFile logFile, ReportLevel report = ReportLevel.Info)
        {
            Layout = layout;
            ReportLevel = report;
            LogFile = logFile;
        }
        public FileAppender(ILayout layout, ReportLevel report = ReportLevel.Info)
        {
            Layout = layout;
            ReportLevel = report;

        }
        public ILayout Layout { get; private set; }

        public ILogFile LogFile { get; private set; }
        public ReportLevel ReportLevel { get; set; }

        public int MessagesAppended { get; private set; }

        public void AppendMessage(IMessage message)
        {
            string content = string.Format(Layout.Format, message.CreatedTime, message.ReportLevel, message.Text);

            LogFile.WriteLine(content);
            File.AppendAllText(LogFile.FullPath, content + Environment.NewLine);
            MessagesAppended++;
        }
    }
}
