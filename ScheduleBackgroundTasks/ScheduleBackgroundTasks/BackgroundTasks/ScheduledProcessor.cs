﻿using NCrontab;

namespace ScheduleBackgroundTasks.BackgroundTasks;
public abstract class ScheduledProcessor : ScopedProcessor
{
    private CrontabSchedule _schedule;
    private DateTime _nextRun;

    protected abstract string Schedule { get; }

    public ScheduledProcessor(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    {
        _schedule = CrontabSchedule.Parse(Schedule);
        _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        do
        {
            var now = DateTime.Now;

            if (now > _nextRun)
            {
                await Process();

                _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
            }

            await Task.Delay(5000, cancellationToken);

        } while (!cancellationToken.IsCancellationRequested);
    }
}