using NureOpenDayBot.Constants;
using NureOpenDayBot.Navigation;
using NureOpenDayBot.Repositories;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace NureOpenDayBot.CommandHandlers.MessageHandlers
{
    /// <summary>
    /// Handles admin login.
    /// </summary>
    public class AdminLoginCommandHandler : ITelegramCommandHandler
    {
        private const string validPassword = "12345";
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly Message _message;

        public AdminLoginCommandHandler(ITelegramBotClient botClient, Message message)
        {
            _telegramBotClient = botClient;
            _message = message;
        }

        /// <inheritdoc />
        public async Task HandleAsync(CancellationToken cancellationToken)
        {
            var commandSplit = _message.Text?.Split(CommandConstants.AdminLoginCommand, StringSplitOptions.RemoveEmptyEntries);

            // If command has invalid format
            if (commandSplit?.Length != 1)
            {
                await _telegramBotClient.SendTextMessageAsync(
                        chatId: _message.Chat.Id,
                        text: $"Невірний формат введених данних. Валідний формат: {CommandConstants.AdminLoginCommand} password",
                        replyMarkup: MainMenu.GetInstance().GetMainMenu(),
                        cancellationToken: cancellationToken);
                return;
            }

            var password = commandSplit[0].Trim();

            // If user entered wrong password
            if (password != validPassword)
            {
                await _telegramBotClient.SendTextMessageAsync(
                        chatId: _message.Chat.Id,
                        text: $"Невірний пароль. Спробуйте ще раз",
                        replyMarkup: MainMenu.GetInstance().GetMainMenu(),
                        cancellationToken: cancellationToken);
                return;
            }

            // Getting current chat members
            var members = ChatMemberRepository.GetChatMembers();
            StringBuilder sb = new("Поточні підписники боту: \n\n");
            foreach (var member in members)
            {
                sb.AppendLine($"Id: {member.Id} \t Username: {member.Username ?? member.FirstName}");
            }

            sb.AppendLine($"Загальна кількість підписників: {members.Count()}");
            await _telegramBotClient.SendTextMessageAsync(
                    chatId: _message.Chat.Id,
                    text: sb.ToString(),
                    replyMarkup: MainMenu.GetInstance().GetMainMenu(),
                    cancellationToken: cancellationToken);
        }
    }
}
