using NureOpenDayBot.CommandHandlers;
using Telegram.Bot.Types;

namespace NureOpenDayBot.Factories.Contracts
{
    /// <summary>
    /// Represents common interface for message handler factories.
    /// </summary>
    public interface IMessageHandlerFactory
    {
        /// <summary>
        /// Creates message handler.
        /// </summary>
        /// <param name="message">Received message.</param>
        /// <returns>Appropriate command handler.</returns>
        public ITelegramCommandHandler Create(Message message);
    }
}
