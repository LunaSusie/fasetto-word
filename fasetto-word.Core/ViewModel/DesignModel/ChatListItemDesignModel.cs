using fasetto_word.Core.ViewModel.Chat;

namespace fasetto_word.Core.ViewModel.DesignModel
{
    /// <summary>
    /// design-time for <see cref="ChatListItemViewModel"/>
    /// </summary>
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        #region singleton
        public static ChatListItemDesignModel Instance=>new ChatListItemDesignModel();
        #endregion

        #region Constructor

        public ChatListItemDesignModel()
        {
            Initials = "LM";
            Name = "Luke";
            Message = "This the chat message!It may be longer longer longer longer!!";
            PrifilePictureRgb = "FF0000";
            NewContentAvailable = false;
        }

        #endregion
    }
}