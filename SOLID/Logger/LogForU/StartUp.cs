using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Logers;
using LogForU.Core.Logers.Interfaces;
using LogForU.Core.Appenders;
using LogForU.Core.Utils;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Core.Layouts;
using LogForU.Core.IO;
using LogForU.CustomLayout;
using LogForU.IO.Interfaces;
using LogForU.IO;
using LogForU.Core.Interfaces;
using LogForU.Core;
using LogForU.Factory.Interfaces;
using LogForU.Factory;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWrite();
ILayoutFactory layoutFactory = new LayoutFactory();
IReportLevelFactory reportLevelFactory = new ReportLevelFactory();
IAppenderFactory appenderFactory = new AppenderFactory();
IEngine engine = new Engine(reader, writer, layoutFactory, reportLevelFactory, appenderFactory);
engine.Run();


//var simpleLayout = new SimpleLayout();
//var consoleAppender = new ConsoleAppender(simpleLayout);

//var file = new LogFile();
//var fileAppender = new FileAppender(simpleLayout, file);

//var logger = new Logger(consoleAppender, fileAppender);
//logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
//logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

//var xmlLayout = new XmlLayout();
//var consoleAppender = new ConsoleAppender(xmlLayout);
//var logger = new Logger(consoleAppender);

//logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
//logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");