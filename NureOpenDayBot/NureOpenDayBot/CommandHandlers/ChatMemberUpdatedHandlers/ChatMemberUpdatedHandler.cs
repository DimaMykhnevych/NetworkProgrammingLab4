using NureOpenDayBot.Repositories;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace NureOpenDayBot.CommandHandlers.ChatMemberUpdatedHandlers
{
    /// <summary>
    /// Handles chat members updates.
    /// </summary>
    public class ChatMemberUpdatedHandler : ITelegramCommandHandler
    {
        private readonly ChatMemberUpdated _chatMemberUpdated;

        public ChatMemberUpdatedHandler(ChatMemberUpdated chatMemberUpdated)
        {
            _chatMemberUpdated = chatMemberUpdated;
        }

        /// <inheritdoc />
        public async Task HandleAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"{_chatMemberUpdated.From.Username ?? _chatMemberUpdated.From.FirstName} - {_chatMemberUpdated.NewChatMember.Status}");

            // If user resterted bot.
            if (_chatMemberUpdated.NewChatMember.Status == ChatMemberStatus.Member ||
                _chatMemberUpdated.NewChatMember.Status == ChatMemberStatus.Creator)
            {
                ChatMemberRepository.AddChatMember(_chatMemberUpdated.From);
                return;
            }

            // If user stopped and deleted the bot.
            if (_chatMemberUpdated.NewChatMember.Status == ChatMemberStatus.Kicked)
            {
                ChatMemberRepository.DeleteChatMember(_chatMemberUpdated.From);
                return;
            }
        }
    }
}
