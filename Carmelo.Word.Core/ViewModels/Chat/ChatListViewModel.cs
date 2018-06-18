using Carmelo.Word.Core.ViewModels.Base;
using System.Collections.Generic;

namespace Carmelo.Word.Core.ViewModels.Chat
{
    /// <summary>
    /// View Model for the <see cref="ChatListControl"/> user control.
    /// </summary>
    public class ChatListViewModel : BaseViewModel
    {
        public List<ChatListItemViewModel> Items { get; set; }
    }
}
