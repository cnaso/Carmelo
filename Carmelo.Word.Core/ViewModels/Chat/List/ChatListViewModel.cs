using System.Collections.Generic;

namespace Carmelo.Word.Core
{
    /// <summary>
    /// View Model for the <see cref="ChatListControl"/> user control.
    /// </summary>
    public class ChatListViewModel : BaseViewModel
    {
        public List<ChatListItemViewModel> Items { get; set; }
    }
}
