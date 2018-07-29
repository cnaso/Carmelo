using System.Collections.Generic;

namespace Carmelo.Word.Core
{
    /// <summary>
    /// View Model for the chat message list user control.
    /// </summary>
    public class ChatMessageListViewModel : BaseViewModel
    {
        public List<ChatMessageListItemViewModel> Items { get; set; }
    }
}
