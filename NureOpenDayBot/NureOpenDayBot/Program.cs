using NureOpenDayBot.Factories;
using NureOpenDayBot.Factories.Contracts;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

Console.OutputEncoding = System.Text.Encoding.UTF8;
var botClient = new TelegramBotClient("{YOUR_TOKEN}");

using CancellationTokenSource cts = new();

// Creating update handlers factory.
IGeneralUpdateHandlerFactory generalUpdateHandlerFactory = new GeneralUpdateHandlerFactory(botClient);

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
};

// Starting receiving updates.
botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);

var me = await botClient.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// Send cancellation request to stop bot.
cts.Cancel();

/// <summary>
/// Handles updates.
/// </summary>
async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    // Getting required handler.
    var handler = generalUpdateHandlerFactory.Create(update);
    if (handler != null)
    {
        Console.WriteLine($"Handling {update.Type} update type");
        try
        {
            // Handling request.
            await handler.HandleAsync(cancellationToken);
        }
        catch(ApiRequestException ex)
        {
            Console.WriteLine($"Exception occured during handling updates: {ex.Message}");
        }

        return;
    }

    Console.WriteLine($"The {update.Type} update type is not supported yet");
}

/// <summary>
/// Handles errors.
/// </summary>
Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}