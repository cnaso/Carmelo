namespace Carmelo.Word.Core
{
    /// <summary>
    /// View Model for the chat list items user control.
    /// </summary>
    public class ChatListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Users displayed name from the chat.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Users last message from the chat.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Users displayed name initials.
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// Users displayed initial background color.
        /// </summary>
        public string ProfilePictureRGB { get; set; }

        /// <summary>
        /// User has new message pending.
        /// </summary>
        public bool NewContentAvailable { get; set; }

        /// <summary>
        /// User is selected or not in the list.
        /// </summary>
        public bool IsSelected { get; set; }
    }
}
