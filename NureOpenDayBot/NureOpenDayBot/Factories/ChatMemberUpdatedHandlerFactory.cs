using NureOpenDayBot.CommandHandlers;
using NureOpenDayBot.CommandHandlers.ChatMemberUpdatedHandlers;
using NureOpenDayBot.Factories.Contracts;
using Telegram.Bot.Types;

namespace NureOpenDayBot.Factories
{
    public class ChatMemberUpdatedHandlerFactory : IChatMemberUpdatedHandlerFactory
    {
        public ITelegramCommandHandler Create(ChatMemberUpdated chatMemberUpdated)
        {
            return new ChatMemberUpdatedHandler(chatMemberUpdated);
        }
    }
}
