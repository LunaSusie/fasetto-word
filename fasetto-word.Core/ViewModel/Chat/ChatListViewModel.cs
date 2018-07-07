using System.Collections.Generic;
using fasetto_word.Core.Infrastructure;

namespace fasetto_word.Core.ViewModel.Chat
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