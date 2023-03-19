using NureOpenDayBot.CommandHandlers;
using Telegram.Bot.Types;

namespace NureOpenDayBot.Factories.Contracts
{
    public interface IMessageHandlerFactory
    {
        public ITelegramCommandHandler Create(Message message);
    }
}
