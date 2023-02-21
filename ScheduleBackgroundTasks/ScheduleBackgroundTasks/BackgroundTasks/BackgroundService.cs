using System.Threading;

namespace ScheduleBackgroundTasks.BackgroundTasks;
public abstract class BackgroundService : IHostedService
{
    private Task _executingTask;
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    public virtual Task StartAsync(CancellationToken cancellationToken)
    {
        _executingTask = ExecuteAsync(_cancellationTokenSource.Token);
        if (_executingTask.IsCompleted) return _executingTask;

        return Task.CompletedTask;
    }

    public virtual async Task StopAsync(CancellationToken cancellationToken)
    {
        if (_executingTask == null) return;

        try
        {
            _cancellationTokenSource.Cancel();
        }
        finally
        {
            await Task.WhenAny(_executingTask, Task.Delay(Timeout.Infinite, cancellationToken));
        }
    }

    protected virtual async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        do
        {
            await Process();
            await Task.Delay(5000, cancellationToken);
        } while (!cancellationToken.IsCancellationRequested);
    }

    protected abstract Task Process();
}
