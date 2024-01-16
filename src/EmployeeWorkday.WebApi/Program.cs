using EmployeeWorkday.Mediator;
using EmployeeWorkday.Mediator.MediatR;
using EmployeeWorkday.WebApi.UseCases.Requests;
using MediatR;

//builder
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(config =>
{
    config.AddConsole();
    config.AddDebug();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IApplicationMediator, MediatRAdapter>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(AuthRequest).Assembly);
});

builder.Services.AddTransient(typeof(IRequestHandler<,>), typeof(RequestHandlerAdapter<,>));
builder.Services.AddTransient(typeof(INotificationHandler<>), typeof(NotificationHandlerAdapter<>));

builder.Services.AddEntityFrameworkNpgsql();
builder.Services
    .AddControllers();

// app
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
