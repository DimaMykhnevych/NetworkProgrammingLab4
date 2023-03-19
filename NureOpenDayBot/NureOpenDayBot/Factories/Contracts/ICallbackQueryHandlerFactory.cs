using NureOpenDayBot.CommandHandlers;
using Telegram.Bot.Types;

namespace NureOpenDayBot.Factories.Contracts
{
    public interface ICallbackQueryHandlerFactory
    {
        public ITelegramCommandHandler Create(CallbackQuery callbackQuery);
    }
}
