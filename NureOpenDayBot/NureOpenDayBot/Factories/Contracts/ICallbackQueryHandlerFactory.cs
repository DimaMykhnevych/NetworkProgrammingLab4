using NureOpenDayBot.CommandHandlers;
using Telegram.Bot.Types;

namespace NureOpenDayBot.Factories.Contracts
{
    /// <summary>
    /// Represents common interface for callback query handler factories.
    /// </summary>
    public interface ICallbackQueryHandlerFactory
    {
        /// <summary>
        /// Creates callback query command handler.
        /// </summary>
        /// <param name="callbackQuery">Received callback query.</param>
        /// <returns>Appropriate command handler.</returns>
        public ITelegramCommandHandler Create(CallbackQuery callbackQuery);
    }
}
