using System;

public static class Reporter
{
    private static readonly Logger TheLogger = LogManager.GetCurrentClassLogger();
    private static ExtentReports ReportManager { get; set; }
}
