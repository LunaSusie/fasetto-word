using System.Collections.Generic;
using fasetto_word.ViewModel.Chat;

namespace fasetto_word.ViewModel.Design
{
    /// <summary>
    /// design-time for <see cref="ChatListViewModel" />
    /// </summary>
    public class ChatListDesignModel : ChatListViewModel
    {
        #region singleton

        public static ChatListDesignModel Instance => new ChatListDesignModel();

        #endregion

        #region Constructor

        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Initials = "LM",
                    Name = "Luke",
                    Message = "This the chat message!It may be longer longer longer longer!!",
                    PrifilePictureRgb = "3099c5",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Initials = "JA",
                    Name = "Jesse",
                    Message = "This the chat message!It may be longer longer longer longer!!",
                    PrifilePictureRgb = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Initials = "PL",
                    Name = "Parnell",
                    Message = "This the chat message!It may be longer longer longer longer!!",
                    PrifilePictureRgb = "00d405",
                    IsSelected = true
                },
                new ChatListItemViewModel
                {
                    Initials = "LM",
                    Name = "Luke",
                    Message = "This the chat message!It may be longer longer longer longer!!",
                    PrifilePictureRgb = "3099c5"
                },
                new ChatListItemViewModel
                {
                    Initials = "JA",
                    Name = "Jesse",
                    Message = "This the chat message!It may be longer longer longer longer!!",
                    PrifilePictureRgb = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Initials = "PL",
                    Name = "Parnell",
                    Message = "This the chat message!It may be longer longer longer longer!!",
                    PrifilePictureRgb = "00d405"
                },
                new ChatListItemViewModel
                {
                    Initials = "LM",
                    Name = "Luke",
                    Message = "This the chat message!It may be longer longer longer longer!!",
                    PrifilePictureRgb = "3099c5"
                },
                new ChatListItemViewModel
                {
                    Initials = "JA",
                    Name = "Jesse",
                    Message = "This the chat message!It may be longer longer longer longer!!",
                    PrifilePictureRgb = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Initials = "PL",
                    Name = "Parnell",
                    Message = "This the chat message!It may be longer longer longer longer!!",
                    PrifilePictureRgb = "00d405"
                }
            };
        }

        #endregion
    }
}