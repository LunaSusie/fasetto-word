using System.Collections.Generic;
using fasetto_word.Infrastructure;

namespace fasetto_word.ViewModel.Chat
{
    /// <summary>
    /// The viewmodel for chat list.
    /// </summary>
    public class ChatListViewModel:BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The chat list items for the list.
        /// </summary>
        public List<ChatListItemViewModel> Items { get; set; }

        #endregion
    }
}