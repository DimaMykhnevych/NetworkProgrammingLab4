using NureOpenDayBot.CommandHandlers;
using NureOpenDayBot.CommandHandlers.MessageHandlers;
using NureOpenDayBot.Constants;
using NureOpenDayBot.Factories.Contracts;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace NureOpenDayBot.Factories
{
    public class MessageHandlerFactory : IMessageHandlerFactory
    {
        private readonly ITelegramBotClient _telegramBotClient;

        public MessageHandlerFactory(ITelegramBotClient telegramBotClient)
        {
            _telegramBotClient = telegramBotClient;
        }

        public ITelegramCommandHandler Create(Message message)
        {
            var adminLoginEntity = message.EntityValues?.FirstOrDefault(m => m.Contains(CommandConstants.AdminLoginCommand));
            if (adminLoginEntity != null)
            {
                return new AdminLoginCommandHandler(_telegramBotClient, message);
            }

            return message.Text switch
            {
                "/start" => new StartCommandHandler(_telegramBotClient, message),
                MainMenuConstants.GetChatMembersButtonText => new GetChatMembersHandler(_telegramBotClient, message),
                MainMenuConstants.GetOpenDayInfoButtonText => new GetOpenDayInfoCommandHandler(_telegramBotClient, message),
                _ => new UnknownCommandHandler(_telegramBotClient, message),
            };
        }
    }
}
