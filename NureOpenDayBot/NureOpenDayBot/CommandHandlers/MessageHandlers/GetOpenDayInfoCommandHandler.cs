﻿using NureOpenDayBot.Navigation;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace NureOpenDayBot.CommandHandlers.MessageHandlers
{
    /// <summary>
    /// Handles get open day info request.
    /// </summary>
    public class GetOpenDayInfoCommandHandler : ITelegramCommandHandler
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly Message _message;

        public GetOpenDayInfoCommandHandler(ITelegramBotClient botClient, Message message)
        {
            _telegramBotClient = botClient;
            _message = message;
        }

        /// <inheritdoc />
        public async Task HandleAsync(CancellationToken cancellationToken)
        {
            await _telegramBotClient.SendTextMessageAsync(
                    chatId: _message.Chat.Id,
                    text: "Оберіть факультет, який Вас цікавить",
                    replyMarkup: SpecialitySelectionMenu.GetInstance().GetSpecialitySelectionMenu(),
                    cancellationToken: cancellationToken);
        }
    }
}
