using Discord.WebSocket;
using Microsoft.Extensions.Logging;

namespace StockiBotService.Services.Commands;

public class CommandsService(ILogger<CommandsService> logger)
{
    public readonly Dictionary<string, Func<SocketSlashCommand, Task>> commands = new()
    {
        { "get-price-info", HandleGetStockPriceInfoAsync },
        { "get-stock-info", HandleGetStockInfoAsync },
        { "get-news", HandleGetNewsAsync },
        { "subscribe", HandleSubscribeAsync },
        { "unsubscribe", HandleUnsubscribeAsync },
    };

    public async Task HandleCommandAsync(SocketSlashCommand cmd)
    {
        if (commands.TryGetValue(cmd.CommandName, out var f))
            await f(cmd);
        logger.LogInformation($"{cmd.CommandName} executed @ {DateTime.Now}\n");
    }

    public static async Task HandleGetStockPriceInfoAsync(SocketSlashCommand cmd)
    {
        var ticker = cmd.Data.Options.FirstOrDefault();
        if (ticker is null)
        {
            return;
        }
        await Task.CompletedTask;
    }

    public static async Task HandleGetStockInfoAsync(SocketSlashCommand cmd)
    {
        var ticker = cmd.Data.Options.FirstOrDefault();
        if (ticker is null)
        {
            return;
        }
        await Task.CompletedTask;
    }

    public static async Task HandleGetNewsAsync(SocketSlashCommand cmd)
    {
        var ticker = cmd.Data.Options.FirstOrDefault();
        if (ticker is null)
        {
            return;
        }
        await Task.CompletedTask;
    }

    public static async Task HandleSubscribeAsync(SocketSlashCommand cmd)
    {
        var args = cmd.Data.Options.ToList();
        if (args is null || args.Count() != 3)
        {
            return;
        }
        await Task.CompletedTask;
    }

    public static async Task HandleUnsubscribeAsync(SocketSlashCommand cmd)
    {
        var ticker = cmd.Data.Options.FirstOrDefault();
        if (ticker is null)
        {
            return;
        }
        await Task.CompletedTask;
    }
}
