using NureOpenDayBot.CommandHandlers;
using NureOpenDayBot.CommandHandlers.CallbackQueryHandlers;
using NureOpenDayBot.CommandHandlers.MessageHandlers;
using NureOpenDayBot.Constants;
using NureOpenDayBot.Factories.Contracts;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace NureOpenDayBot.Factories
{
    public class CallbackQueryHandlerFactory : ICallbackQueryHandlerFactory
    {
        private readonly ITelegramBotClient _telegramBotClient;

        public CallbackQueryHandlerFactory(ITelegramBotClient telegramBotClient)
        {
            _telegramBotClient = telegramBotClient;
        }

        public ITelegramCommandHandler Create(CallbackQuery callbackQuery)
        {
            if (FacultiesConstants.Faculties.Contains(callbackQuery.Data))
            {
                return new GetOpenDayInfoCallbackQueryHandler(_telegramBotClient, callbackQuery);
            }

            return new UnknownCommandHandler(_telegramBotClient, callbackQuery.Message!);
        }
    }
}
