using Carmelo.Word.Core.ViewModels.Base;

namespace Carmelo.Word.Core.ViewModels.Chat
{
    /// <summary>
    /// View Model for the <see cref="ChatListItemControl"/> user control.
    /// </summary>
    public class ChatListItemViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string Message { get; set; }

        public string Initials { get; set; }

        public string ProfilePictureRGB { get; set; }

        public bool NewContentAvailable { get; set; }

        public bool IsSelected { get; set; }
    }
}
