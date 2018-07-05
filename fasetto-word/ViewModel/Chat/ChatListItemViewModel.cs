using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using fasetto_word.Infrastructure;

namespace fasetto_word.ViewModel.Chat
{
    /// <summary>
    /// ViewModel for each chat list item in the overview chat list
    /// </summary>
    public class ChatListItemViewModel:BaseViewModel
    {
        #region Public Properites
        /// <summary>
        /// Display name of this chat list.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The latest message of this chat.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// The initials to the show for the profile picture background.
        /// </summary>
        public string Initials { get; set; }
        /// <summary>
        /// The RGB value (in hex) for the background color of the prifile Picture.
        /// </summary>
        public string PrifilePictureRgb { get; set; }
        /// <summary>
        /// True if the this chat item is unread message.
        /// </summary>
        public bool NewContentAvailable { get; set; }
        /// <summary>
        /// True if the item is selected.
        /// </summary>
        public bool IsSelected { get; set; }
        #endregion
    }
}
