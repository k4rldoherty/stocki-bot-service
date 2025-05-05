using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;

public class CommandRegistry(ILogger<CommandRegistry> logger)
{
    public async Task InitializeCommandsAsync(DiscordSocketClient client)
    {
        var globalCommands = await client.GetGlobalApplicationCommandsAsync();

        if (!globalCommands.Any(x => x.Name.Equals("get-price-info")))
        {
            var priceCommand = new SlashCommandBuilder()
                .WithName("stock-price")
                .WithDescription(
                    "Gets the price of a stock by passing in a ticker eg 'PLTR' after the command"
                )
                .AddOption(
                    "ticker",
                    ApplicationCommandOptionType.String,
                    "The symbol to get the price of a stock",
                    true
                )
                .Build();

            await client.CreateGlobalApplicationCommandAsync(priceCommand);
            logger.LogInformation($"{priceCommand.Name} registered");
        }
        if (!globalCommands.Any(x => x.Name == "get-stock-info"))
        {
            var infoCommand = new SlashCommandBuilder()
                .WithName("info")
                .WithDescription(
                    "Retrives information about a stock by passing in a ticker eg 'PLTR'"
                )
                .AddOption(
                    "ticker",
                    ApplicationCommandOptionType.String,
                    "The ticker symbol of a stock",
                    true
                )
                .Build();

            await client.CreateGlobalApplicationCommandAsync(infoCommand);
            logger.LogInformation($"{infoCommand.Name} registered");
        }
        if (!globalCommands.Any(x => x.Name == "get-news"))
        {
            var newsCommand = new SlashCommandBuilder()
                .WithName("news")
                .WithDescription(
                    "Get the lates news articles about a stock from a number of sources"
                )
                .AddOption(
                    "ticker",
                    ApplicationCommandOptionType.String,
                    "The ticker symbol of the stock you want to subscribe to news stories about",
                    true
                )
                .Build();
            await client.CreateGlobalApplicationCommandAsync(newsCommand);
            logger.LogInformation($"{newsCommand.Name} registered");
        }
        if (!globalCommands.Any(x => x.Name == "subscribe"))
        {
            var subscribeCommand = new SlashCommandBuilder()
                .WithName("subscribe")
                .WithDescription(
                    "Subscribes the user to price changes and / or latest news in a stock, either by email, message or both."
                )
                .AddOption(
                    "ticker",
                    ApplicationCommandOptionType.String,
                    "The ticker symbol of the stock you want to subscribe to notifications about",
                    true
                )
                .AddOption(
                    "price change %",
                    ApplicationCommandOptionType.Number,
                    "If the stocks price goes up / down this %, you will recieve a message",
                    true
                )
                .AddOption(
                    "news notifications",
                    ApplicationCommandOptionType.Boolean,
                    "Recieve daily news stories about the ticker, choose false if not required",
                    true
                )
                .Build();
            await client.CreateGlobalApplicationCommandAsync(subscribeCommand);
            logger.LogInformation($"{subscribeCommand.Name} registered");
        }

        if (!globalCommands.Any(x => x.Name == "unsubscribe"))
        {
            var unsubscribeCommand = new SlashCommandBuilder()
                .WithName("unsubscribe")
                .WithDescription(
                    "Unsubscribes the user to price changes and latest news in a stock, either by email, message or both."
                )
                .AddOption(
                    "ticker",
                    ApplicationCommandOptionType.String,
                    "The ticker symbol of the stock you want to unsubscribe to notifications about",
                    true
                )
                .Build();
            await client.CreateGlobalApplicationCommandAsync(unsubscribeCommand);
            logger.LogInformation($"{unsubscribeCommand.Name} registered");
        }
        // More commands here ...
    }
}
