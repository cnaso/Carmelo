using System;
using System.Collections.Generic;

namespace Carmelo.Word.Core
{
    /// <summary>
    /// Design Model for the <see cref="ChatMessageListViewModel"/>.
    /// </summary>
    public class ChatMessageListDesignModel : ChatMessageListViewModel
    {
        public static ChatMessageListDesignModel Instance { get { return instance; } }

        private static readonly ChatMessageListDesignModel instance = new ChatMessageListDesignModel();

        public ChatMessageListDesignModel()
        {
            Items = new List<ChatMessageListItemViewModel>
            {
                new ChatMessageListItemViewModel
                {
                    Initials = "JD",
                    SenderName = "John Doe",
                    Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ProfilePictureRGB = "888888",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.6)),
                    IsSentByMe = false
                },
                new ChatMessageListItemViewModel
                {
                    Initials = "PL",
                    SenderName = "Parnell Jones",
                    Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    ProfilePictureRGB = "333333",
                    MessageSentTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3)),
                    MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(5.5)),
                    IsSentByMe = true
                },
                new ChatMessageListItemViewModel
                {
                    Initials = "DM",
                    SenderName = "Dominic M.",
                    Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt.",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(2.7)),
                    IsSentByMe = false
                },
                new ChatMessageListItemViewModel
                {
                    Initials = "TJ",
                    SenderName = "Tom Jones",
                    Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Lorem ipsum dolor sit amet.",
                    ProfilePictureRGB = "ffa800",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    MessageReadTime = DateTimeOffset.UtcNow,
                    IsSentByMe = true
                }
            };
        }
    }
}
