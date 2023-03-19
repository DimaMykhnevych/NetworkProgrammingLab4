﻿using NureOpenDayBot.Constants;
using Telegram.Bot.Types.ReplyMarkups;

namespace NureOpenDayBot.Navigation
{
    public class SpecialitySelectionMenu
    {
        private readonly InlineKeyboardMarkup _inlineKeyboardMarkup;
        private static SpecialitySelectionMenu _instance;

        private SpecialitySelectionMenu()
        {
            List<List<InlineKeyboardButton>> facultyButtons = new();
            int columnsAmount = 3;
            int rowsAmount = FacultiesConstants.Faculties.Count / columnsAmount + 1;
            for (int i = 0; i < rowsAmount; i++)
            {
                List<InlineKeyboardButton> rowButtons = new();
                for (int j = 0; j < columnsAmount; j++)
                {
                    int currentFacultyIndex = i * columnsAmount + j;
                    if (currentFacultyIndex == FacultiesConstants.Faculties.Count)
                    {
                        break;
                    }

                    var faculty = FacultiesConstants.Faculties.ElementAt(i * columnsAmount + j);
                    InlineKeyboardButton facultyButton = InlineKeyboardButton.WithCallbackData(faculty);
                    rowButtons.Add(facultyButton);
                }

                facultyButtons.Add(rowButtons);
            }

            _inlineKeyboardMarkup = new(facultyButtons);
        }

        public static SpecialitySelectionMenu GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SpecialitySelectionMenu();
            }

            return _instance;
        }

        public InlineKeyboardMarkup GetSpecialitySelectionMenu()
        {
            return _inlineKeyboardMarkup;
        }
    }
}
