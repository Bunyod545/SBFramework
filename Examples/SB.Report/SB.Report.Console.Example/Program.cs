using SB.Report.Console.Example.BankStatmentReport;
using System.Diagnostics;
using System.Reflection;

string appFolder = AppContext.BaseDirectory;
var filePath = Path.Combine(appFolder, "BankStatementReport.xlsx");

var report = new BankStatmentReport();
report.Generate();
report.SaveReport(filePath);