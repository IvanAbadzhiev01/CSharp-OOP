using LogForU.Core.Enums;
using LogForU.Core.Exceptioms;
using LogForU.Core.Exceptions;
using LogForU.Core.Models.Interfaces;
using LogForU.Core.Utils;

namespace LogForU.Core.Models
{
    public class Message : IMessage
    {
        private string createTime;
        private string text;
        private ReportLevel reportLevel;

        public Message(string createdTime, string text, ReportLevel reportLevel)
        {
            CreatedTime = createdTime;
            Text = text;
            ReportLevel = reportLevel;
        }

        public string CreatedTime
        {
            get => createTime;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyCreatedTimeExceptions();
                }

                if (!DateTimeValidator.ValidateDateTime(value))
                {
                    throw new InvalidDateTimeExceptions();
                }

                createTime = value;
            }
        }

        public string Text
        {
            get => text;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyMessageTextExceptions();
                }

                text = value;
            }
        }

        public ReportLevel ReportLevel { get; private set; }
    }
}
