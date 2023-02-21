using ScheduleBackgroundTasks.BackgroundTasks;

namespace ScheduleBackgroundTasks.ScheduleTask;
public class SampleTask1 : ScheduledProcessor
{
    public SampleTask1(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
    }

    protected override string Schedule => "*/1 * * * *";

    public override async Task ProcessInScope(IServiceProvider scopeServiceProvider)
    {
        Console.WriteLine("SampleTask1 : " + DateTime.Now.ToString());
        await Task.Run(() => Task.CompletedTask);
    }
}
