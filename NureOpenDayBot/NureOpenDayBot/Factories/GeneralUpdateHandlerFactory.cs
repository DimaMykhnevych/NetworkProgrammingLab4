using NureOpenDayBot.CommandHandlers;
using NureOpenDayBot.Factories.Contracts;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace NureOpenDayBot.Factories
{
    /// <summary>
    /// General Update Handler Factory.
    /// </summary>
    public class GeneralUpdateHandlerFactory : IGeneralUpdateHandlerFactory
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly IMessageHandlerFactory _messageHandlerFactory;
        private readonly IChatMemberUpdatedHandlerFactory _memberUpdatedHandlerFactory;
        private readonly ICallbackQueryHandlerFactory _callbackQueryHandlerFactory;

        public GeneralUpdateHandlerFactory(ITelegramBotClient telegramBotClient)
        {
            _telegramBotClient = telegramBotClient;
            _messageHandlerFactory = new MessageHandlerFactory(_telegramBotClient);
            _memberUpdatedHandlerFactory = new ChatMemberUpdatedHandlerFactory();
            _callbackQueryHandlerFactory = new CallbackQueryHandlerFactory(_telegramBotClient);
        }

        /// <inheritdoc />
        public ITelegramCommandHandler? Create(Update update)
        {
            if (update.Type == UpdateType.Message && update.Message?.Text != null)
            {
                return _messageHandlerFactory.Create(update.Message);
            }

            if (update.Type == UpdateType.CallbackQuery && update.CallbackQuery != null)
            {
                return _callbackQueryHandlerFactory.Create(update.CallbackQuery);
            }

            if (update.Type == UpdateType.MyChatMember && update.MyChatMember != null)
            {
                return _memberUpdatedHandlerFactory.Create(update.MyChatMember);
            }

            return null;
        }
    }
}
