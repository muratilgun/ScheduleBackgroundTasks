using ScheduleBackgroundTasks.BackgroundTasks;

namespace ScheduleBackgroundTasks.ScheduleTask;
public class SampleTask2 : ScheduledProcessor
{
    public SampleTask2(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
    }

    protected override string Schedule => "*/2 * * * *";

    public override async Task ProcessInScope(IServiceProvider scopeServiceProvider)
    {
        Random random = new();
        int randomNumber =  random.Next(1, 100);
        Console.WriteLine("SampleTask2 : " + DateTime.Now.ToString() + " Random Number : " + randomNumber.ToString());
        await Task.Run(() => Task.CompletedTask);
    }
}
