using ScheduleBackgroundTasks.BackgroundTasks;
using ScheduleBackgroundTasks.Services;

namespace ScheduleBackgroundTasks.ScheduleTask;
public class SampleTask3 : ScheduledProcessor
{
    public SampleTask3(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
    }

    protected override string Schedule => "*/1 * * * *";

    public override async Task ProcessInScope(IServiceProvider scopeServiceProvider)
    {

        Console.WriteLine("SampleTask3 : " + DateTime.Now.ToString());
        IReportGenerator reportGenerator = scopeServiceProvider.GetService<IReportGenerator>();
        _ = reportGenerator.GenerateDailyReport();
        await Task.Run(() => Task.CompletedTask);
    }
}
