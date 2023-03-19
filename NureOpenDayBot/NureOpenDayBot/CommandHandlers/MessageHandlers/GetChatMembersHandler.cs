using NureOpenDayBot.Constants;
using NureOpenDayBot.Navigation;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace NureOpenDayBot.CommandHandlers.MessageHandlers
{
    public class GetChatMembersHandler : ITelegramCommandHandler
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly Message _message;

        public GetChatMembersHandler(ITelegramBotClient botClient, Message message)
        {
            _telegramBotClient = botClient;
            _message = message;
        }

        public async Task HandleAsync(CancellationToken cancellationToken)
        {
            await _telegramBotClient.SendTextMessageAsync(
                    chatId: _message.Chat.Id,
                    text: "❗️ Ви повинні авторизуватися, щоб отримати поточних підпісників.\n\n" +
                    $"Для цього виконайте команду {CommandConstants.AdminLoginCommand} та введите пароль, наприклад {CommandConstants.AdminLoginCommand} <i>password</i>",
                    replyMarkup: MainMenu.GetInstance().GetMainMenu(),
                    parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
        }
    }
}
