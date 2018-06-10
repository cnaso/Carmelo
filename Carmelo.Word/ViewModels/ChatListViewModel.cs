using Carmelo.Base.ViewModels;
using System.Collections.Generic;

namespace Carmelo.Word.ViewModels
{
    /// <summary>
    /// View Model for the <see cref="ChatListControl"/> user control.
    /// </summary>
    public class ChatListViewModel : BaseViewModel
    {
        public List<ChatListItemViewModel> Items { get; set; }
    }
}
