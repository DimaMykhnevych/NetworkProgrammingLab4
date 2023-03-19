using NureOpenDayBot.CommandHandlers;
using Telegram.Bot.Types;

namespace NureOpenDayBot.Factories.Contracts
{
    /// <summary>
    /// Represents common interface for chat member updated handler factories.
    /// </summary>
    public interface IChatMemberUpdatedHandlerFactory
    {
        /// <summary>
        /// Creates chat member updated command handler.
        /// </summary>
        /// <param name="chatMemberUpdated">Received chat member updated query.</param>
        /// <returns>Appropriate command handler.</returns>
        public ITelegramCommandHandler Create(ChatMemberUpdated chatMemberUpdated);
    }
}
