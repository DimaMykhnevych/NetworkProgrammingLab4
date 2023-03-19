using NureOpenDayBot.CommandHandlers;
using NureOpenDayBot.CommandHandlers.ChatMemberUpdatedHandlers;
using NureOpenDayBot.Factories.Contracts;
using Telegram.Bot.Types;

namespace NureOpenDayBot.Factories
{
    /// <summary>
    /// Chat Member Updated Handler Factory.
    /// </summary>
    public class ChatMemberUpdatedHandlerFactory : IChatMemberUpdatedHandlerFactory
    {
        /// <inheritdoc />
        public ITelegramCommandHandler Create(ChatMemberUpdated chatMemberUpdated)
        {
            return new ChatMemberUpdatedHandler(chatMemberUpdated);
        }
    }
}
