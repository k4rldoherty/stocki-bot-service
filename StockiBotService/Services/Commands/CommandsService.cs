using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using StockiBotService.Services.Api;

namespace StockiBotService.Services.Commands;

public class CommandsService
{
    private Dictionary<string, Func<SocketSlashCommand, Task>> commands = new();
    private readonly ILogger<OrchestratorClient> _logger;
    private readonly OrchestratorClient _client;

    public CommandsService(ILogger<OrchestratorClient> logger, OrchestratorClient client)
    {
        _logger = logger;
        _client = client;
        commands.Add("get-price-info", HandleGetStockPriceInfoAsync);
        commands.Add("get-stock-info", HandleGetStockInfoAsync);
        commands.Add("get-news", HandleGetNewsAsync);
        commands.Add("subscribe", HandleSubscribeAsync);
        commands.Add("unsubscribe", HandleUnsubscribeAsync);
    }

    public async Task HandleCommandAsync(SocketSlashCommand cmd)
    {
        if (commands.TryGetValue(cmd.CommandName, out var f))
        {
            // TODO: SOMETHING WRONG HERE
            _logger.LogInformation("RUNNING COMMAND");
            await f(cmd);
        }
        _logger.LogInformation($"{cmd.CommandName} executed @ {DateTime.Now}");
    }

    public async Task HandleGetStockPriceInfoAsync(SocketSlashCommand cmd)
    {
        var tickerOption = cmd.Data.Options.FirstOrDefault();
        if (tickerOption == null)
        {
            await cmd.RespondAsync($"Ticker invalid");
            return;
        }
        // TODO: FIX THIS
        var res = await _client.GetStockPriceData(tickerOption.Value.ToString());
        await cmd.RespondAsync($"{res}");
    }

    private async Task HandleGetStockInfoAsync(SocketSlashCommand cmd)
    {
        var ticker = cmd.Data.Options.FirstOrDefault();
        if (ticker is null)
        {
            return;
        }
        await Task.CompletedTask;
    }

    private async Task HandleGetNewsAsync(SocketSlashCommand cmd)
    {
        var ticker = cmd.Data.Options.FirstOrDefault();
        if (ticker is null)
        {
            return;
        }
        await Task.CompletedTask;
    }

    private async Task HandleSubscribeAsync(SocketSlashCommand cmd)
    {
        var args = cmd.Data.Options.ToList();
        if (args is null || args.Count() != 3)
        {
            return;
        }
        await Task.CompletedTask;
    }

    private async Task HandleUnsubscribeAsync(SocketSlashCommand cmd)
    {
        var ticker = cmd.Data.Options.FirstOrDefault();
        if (ticker is null)
        {
            return;
        }
        await Task.CompletedTask;
    }
}
