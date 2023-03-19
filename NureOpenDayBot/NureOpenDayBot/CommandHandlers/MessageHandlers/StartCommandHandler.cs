using NureOpenDayBot.Constants;
using NureOpenDayBot.Navigation;
using NureOpenDayBot.Repositories;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace NureOpenDayBot.CommandHandlers.MessageHandlers
{
    public class StartCommandHandler : ITelegramCommandHandler
    {
        private const string welcomeMessage = "Вітаємо Вас в боті NURE Open Day Bot! 👋\n\n" +
            "За допомогою цього боту Ви можете дізнатися інформацію про Дні відкритих дверей" +
           $" в ХНУРЕ: для цього натисніть кнопку *{MainMenuConstants.GetOpenDayInfoButtonText}*.\n\n" +
           $"Щоб отримати статистику по поточним підписникам, натисніть кнопку *{MainMenuConstants.GetChatMembersButtonText}*";
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly Message _message;

        public StartCommandHandler(ITelegramBotClient botClient, Message message)
        {
            _telegramBotClient = botClient;
            _message = message;
        }

        public async Task HandleAsync(CancellationToken cancellationToken)
        {
            ChatMemberRepository.AddChatMember(_message.From);
            await _telegramBotClient.SendTextMessageAsync(
                    chatId: _message.Chat.Id,
                    text: welcomeMessage,
                    replyMarkup: MainMenu.GetInstance().GetMainMenu(),
                    parseMode: ParseMode.Markdown,
                    cancellationToken: cancellationToken);
        }
    }
}
