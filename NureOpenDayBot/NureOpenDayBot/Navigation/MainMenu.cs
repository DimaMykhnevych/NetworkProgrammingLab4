using NureOpenDayBot.Constants;
using Telegram.Bot.Types.ReplyMarkups;

namespace NureOpenDayBot.Navigation
{
    public sealed class MainMenu
    {
        private readonly ReplyKeyboardMarkup _replyKeyboardMarkup;
        private static MainMenu _instance;

        private MainMenu()
        {
            KeyboardButton openDayInfo = new (MainMenuConstants.GetOpenDayInfoButtonText);
            KeyboardButton getChatMembers = new (MainMenuConstants.GetChatMembersButtonText);
            KeyboardButton[] buttons = new [] { openDayInfo, getChatMembers };
            _replyKeyboardMarkup = new (buttons) { ResizeKeyboard = true };
        }

        public static MainMenu GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MainMenu();
            }

            return _instance;
        }

        public ReplyKeyboardMarkup GetMainMenu()
        {
            return _replyKeyboardMarkup;
        }
    }
}
