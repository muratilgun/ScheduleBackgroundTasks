﻿namespace ScheduleBackgroundTasks.BackgroundTasks;
public abstract class ScopedProcessor : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public ScopedProcessor(IServiceScopeFactory serviceScopeFactory) : base()
    {
        _serviceScopeFactory = serviceScopeFactory;
    }
    protected override async Task Process()
    {
        using var scope = _serviceScopeFactory.CreateScope();
        await ProcessInScope(scope.ServiceProvider);

        throw new NotImplementedException();
    }
    public abstract Task ProcessInScope(IServiceProvider serviceProvider);
}

