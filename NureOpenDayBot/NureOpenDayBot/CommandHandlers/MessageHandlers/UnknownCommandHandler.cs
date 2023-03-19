using NureOpenDayBot.Navigation;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace NureOpenDayBot.CommandHandlers.MessageHandlers
{
    public class UnknownCommandHandler : ITelegramCommandHandler
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly Message _message;

        public UnknownCommandHandler(ITelegramBotClient botClient, Message message)
        {
            _telegramBotClient = botClient;
            _message = message;
        }

        public async Task HandleAsync(CancellationToken cancellationToken)
        {
            await _telegramBotClient.SendTextMessageAsync(
                    chatId: _message.Chat.Id,
                    text: "Невідома команда, спробуйте ще раз",
                    replyMarkup: MainMenu.GetInstance().GetMainMenu(),
                    cancellationToken: cancellationToken);
        }
    }
}
