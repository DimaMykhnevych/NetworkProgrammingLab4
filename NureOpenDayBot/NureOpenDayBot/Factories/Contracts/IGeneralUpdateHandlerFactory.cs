using NureOpenDayBot.CommandHandlers;
using Telegram.Bot.Types;

namespace NureOpenDayBot.Factories.Contracts
{
    public interface IGeneralUpdateHandlerFactory
    {
        public ITelegramCommandHandler? Create(Update update);
    }
}
