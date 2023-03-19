using Telegram.Bot.Types;

namespace NureOpenDayBot.Repositories
{
    /// <summary>
    /// Stores chat members.
    /// </summary>
    public static class ChatMemberRepository
    {
        /// <summary>
        /// Current chat members.
        /// </summary>
        private static readonly List<User> members = new();

        /// <summary>
        /// Gets current chat members.
        /// </summary>
        /// <returns>Chat members.</returns>
        public static IEnumerable<User> GetChatMembers()
        {
            return members;
        }

        /// <summary>
        /// Adds chat member if not exist.
        /// </summary>
        /// <param name="member">Chat member to add.</param>
        public static void AddChatMember(User member)
        {
            var memberExists = members.Exists(x => x.Id == member.Id);
            if (!memberExists)
            {
                members.Add(member);
            }
        }

        /// <summary>
        /// Deletes chat member if not exist.
        /// </summary>
        /// <param name="member">Chat member to delete.</param>
        public static void DeleteChatMember(User member)
        {
            var existingMember = members.FirstOrDefault(x => x.Id == member.Id);
            if (existingMember != null)
            {
                members.Remove(existingMember);
            }
        }
    }
}
