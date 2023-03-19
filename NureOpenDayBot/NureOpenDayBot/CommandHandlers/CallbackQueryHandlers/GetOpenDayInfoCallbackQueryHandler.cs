using NureOpenDayBot.Constants;
using NureOpenDayBot.Navigation;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace NureOpenDayBot.CommandHandlers.CallbackQueryHandlers
{
    /// <summary>
    /// Gets open day info for requested faculty.
    /// </summary>
    public class GetOpenDayInfoCallbackQueryHandler : ITelegramCommandHandler
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly CallbackQuery _callbackQuery;

        public GetOpenDayInfoCallbackQueryHandler(ITelegramBotClient botClient, CallbackQuery callbackQuery)
        {
            _telegramBotClient = botClient;
            _callbackQuery = callbackQuery;
        }

        /// <inheritdoc />
        public async Task HandleAsync(CancellationToken cancellationToken)
        {
            var requiredFaculty = _callbackQuery.Data ?? "КН";
            var facultyFullName = FacultiesConstants.FacultyFullNames[requiredFaculty];
            var facultyOpenDayInfo = FacultiesConstants.FacultyOpenDayInfo[requiredFaculty];
            var fullOpenDayInfo = $"*{requiredFaculty} ({facultyFullName})*\n\n{facultyOpenDayInfo}";

            // Answering to the callback query.
            await _telegramBotClient.AnswerCallbackQueryAsync(_callbackQuery.Id);

            // Sending message with required info.
            await _telegramBotClient.SendTextMessageAsync(
                    chatId: _callbackQuery.Message!.Chat.Id,
                    text: fullOpenDayInfo,
                    replyMarkup: MainMenu.GetInstance().GetMainMenu(),
                    parseMode: ParseMode.Markdown,
                    cancellationToken: cancellationToken);
        }
    }
}
