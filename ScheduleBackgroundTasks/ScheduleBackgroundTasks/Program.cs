using ScheduleBackgroundTasks.ScheduleTask;
using ScheduleBackgroundTasks.Services;

namespace ScheduleBackgroundTasks;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddScoped<IReportGenerator, ReportGenerator>();
        builder.Services.AddSingleton<IHostedService,SampleTask1>();
        builder.Services.AddSingleton<IHostedService,SampleTask2>();
        builder.Services.AddSingleton<IHostedService,SampleTask3>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}