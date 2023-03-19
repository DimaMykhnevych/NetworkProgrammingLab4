using NureOpenDayBot.CommandHandlers;
using NureOpenDayBot.CommandHandlers.CallbackQueryHandlers;
using NureOpenDayBot.CommandHandlers.MessageHandlers;
using NureOpenDayBot.Constants;
using NureOpenDayBot.Factories.Contracts;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace NureOpenDayBot.Factories
{
    /// <summary>
    /// Callback query handler factory.
    /// </summary>
    public class CallbackQueryHandlerFactory : ICallbackQueryHandlerFactory
    {
        private readonly ITelegramBotClient _telegramBotClient;

        public CallbackQueryHandlerFactory(ITelegramBotClient telegramBotClient)
        {
            _telegramBotClient = telegramBotClient;
        }

        /// <inheritdoc />
        public ITelegramCommandHandler Create(CallbackQuery callbackQuery)
        {
            // if the command is sent to get faculty open day info.
            if (FacultiesConstants.Faculties.Contains(callbackQuery.Data))
            {
                return new GetOpenDayInfoCallbackQueryHandler(_telegramBotClient, callbackQuery);
            }

            return new UnknownCommandHandler(_telegramBotClient, callbackQuery.Message!);
        }
    }
}
