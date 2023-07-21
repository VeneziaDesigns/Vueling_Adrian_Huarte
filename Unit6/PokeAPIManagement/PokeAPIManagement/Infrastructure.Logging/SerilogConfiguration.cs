using System;
using System.IO;
using Serilog;
using Serilog.Extensions.Logging;
using Serilog.Sinks.MSSqlServer;

namespace Infrastructure.Logging
{
    public class SerilogConfiguration
    {
        #region local file log
        private static string _logFilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "SerilogWithDI.log");
        public static SerilogLoggerProvider ConfigureLocalFileLog()
        {
            return new SerilogLoggerProvider(new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File(_logFilePath)
                .CreateLogger());
        }
        #endregion

        #region Sql Server Db log
        private static string _logDbConnectionString =
            "data source=.;initial catalog=TestSerilogInDB;user id=sa;password=Sm1ll@SqlServer2019;MultipleActiveResultSets=True;App=EntityFramework";
        public static SerilogLoggerProvider ConfigureSqlServerDbLog()
        {
            var logDB = _logDbConnectionString;
            var sinkOpts = new MSSqlServerSinkOptions();
            sinkOpts.SchemaName = "dbo";
            sinkOpts.TableName = "Logs";
            sinkOpts.AutoCreateSqlDatabase = true;
            var columnOpts = new ColumnOptions();
            columnOpts.Store.Remove(StandardColumn.Properties);
            columnOpts.Store.Add(StandardColumn.LogEvent);
            columnOpts.LogEvent.DataLength = 2048;
            columnOpts.PrimaryKey = columnOpts.TimeStamp;
            columnOpts.TimeStamp.NonClusteredIndex = true;

            var logConfigurationForDB = new LoggerConfiguration()
                .WriteTo.MSSqlServer(
                    connectionString: logDB,
                    sinkOptions: sinkOpts,
                    columnOptions: columnOpts
                ).CreateLogger();

            return new SerilogLoggerProvider(logConfigurationForDB);
        }

        #endregion
    }
}
