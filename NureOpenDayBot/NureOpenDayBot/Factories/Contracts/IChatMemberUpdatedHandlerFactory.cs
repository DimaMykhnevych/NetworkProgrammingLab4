using NureOpenDayBot.CommandHandlers;
using Telegram.Bot.Types;

namespace NureOpenDayBot.Factories.Contracts
{
    public interface IChatMemberUpdatedHandlerFactory
    {
        public ITelegramCommandHandler Create(ChatMemberUpdated chatMemberUpdated);
    }
}
