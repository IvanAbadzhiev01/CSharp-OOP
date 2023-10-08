using LogForU.Core.Enums;

namespace LogForU.Core.Models.Interfaces
{
    public interface IMessage
    {

        public string CreatedTime { get; }
        public string Text { get; }
        public ReportLevel ReportLevel { get; }
    }
}
