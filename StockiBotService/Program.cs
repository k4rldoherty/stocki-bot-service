using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StockiBotService.Services;
using StockiBotService.Services.Commands;
using StockiBotService.Services.Input;

var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureAppConfiguration(cfg => cfg.AddEnvironmentVariables());
builder.ConfigureServices(
    (context, services) =>
    {
        services.AddSingleton<DiscordSocketClient>();
        services.AddHostedService<BotService>();
        services.AddSingleton<CommandsService>();
        services.AddSingleton<CommandRegistry>();
        services.AddSingleton<InputHandlerService>();
        services.AddSingleton<HttpClient>();
    }
);
builder.ConfigureLogging(logging => logging.AddConsole());

var app = builder.Build();

await app.RunAsync();
