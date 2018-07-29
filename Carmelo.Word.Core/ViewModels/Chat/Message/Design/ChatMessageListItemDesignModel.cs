using System;

namespace Carmelo.Word.Core
{
    /// <summary>
    /// Design Model for the <see cref="ChatMessageListItemViewModel"/>.
    /// </summary>
    public class ChatMessageListItemDesignModel : ChatMessageListItemViewModel
    {
        public static ChatMessageListItemDesignModel Instance { get { return instance; } }

        private static readonly ChatMessageListItemDesignModel instance = new ChatMessageListItemDesignModel();

        public ChatMessageListItemDesignModel()
        {
            Initials = "JD";
            SenderName = "John Doe";
            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            ProfilePictureRGB = "888888";
            MessageSentTime = DateTimeOffset.UtcNow;
            MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3));
            IsSentByMe = false;
        }
    }
}
