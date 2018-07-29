using System;

namespace Carmelo.Word.Core
{
    /// <summary>
    /// View Model for the chat message list items user control.
    /// </summary>
    public class ChatMessageListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Users displayed name from the chat.
        /// </summary>
        public string SenderName { get; set; }

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
        /// User is selected or not in the list.
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// Chat sent by the signed in user.
        /// </summary>
        public bool IsSentByMe { get; set; }

        /// <summary>
        /// Message has been read.
        /// </summary>
        public bool IsMessageRead => MessageReadTime > DateTimeOffset.MinValue;

        /// <summary>
        /// Time message was read or <see cref="DateTimeOffset.MinValue"/> if it is not.
        /// </summary>
        public DateTimeOffset MessageReadTime { get; set; }

        /// <summary>
        /// Time message was sent.
        /// </summary>
        public DateTimeOffset MessageSentTime { get; set; }
    }
}
