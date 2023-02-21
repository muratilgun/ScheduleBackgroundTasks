namespace ScheduleBackgroundTasks.Services;
public class ReportGenerator : IReportGenerator
{

    public string GenerateDailyReport() 
    { 
        Console.WriteLine($"GenerateDailyReport : " + DateTime.Now.ToString()); 
        return "GenerateDailyReport";
    }

}
