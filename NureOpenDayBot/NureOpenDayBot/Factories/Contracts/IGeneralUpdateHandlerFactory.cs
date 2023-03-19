using NureOpenDayBot.CommandHandlers;
using Telegram.Bot.Types;

namespace NureOpenDayBot.Factories.Contracts
{
    /// <summary>
    /// Represents interface for general update handler factories.
    /// </summary>
    public interface IGeneralUpdateHandlerFactory
    {
        /// <summary>
        /// Creates handler for given update.
        /// </summary>
        /// <param name="message">Received update.</param>
        /// <returns>Appropriate command handler.</returns>
        public ITelegramCommandHandler? Create(Update update);
    }
}
