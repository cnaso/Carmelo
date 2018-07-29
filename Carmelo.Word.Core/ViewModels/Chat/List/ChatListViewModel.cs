using System.Collections.Generic;

namespace Carmelo.Word.Core
{
    /// <summary>
    /// View Model for the chat message list user control.
    /// </summary>
    public class ChatListViewModel : BaseViewModel
    {
        /// <summary>
        /// List of user chat itmes.
        /// </summary>
        public List<ChatListItemViewModel> Items { get; set; }
    }
}
