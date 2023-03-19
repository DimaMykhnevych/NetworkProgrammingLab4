using Telegram.Bot.Types;

namespace NureOpenDayBot.Repositories
{
    public static class ChatMemberRepository
    {
        private static readonly List<User> members = new();

        public static IEnumerable<User> GetChatMembers()
        {
            return members;
        }

        public static void AddChatMember(User member)
        {
            var memberExists = members.Exists(x => x.Id == member.Id);
            if (!memberExists)
            {
                members.Add(member);
            }
        }

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
