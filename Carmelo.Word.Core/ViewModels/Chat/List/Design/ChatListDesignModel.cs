using System.Collections.Generic;

namespace Carmelo.Word.Core
{
    /// <summary>
    /// Design Model for the <see cref="ChatListViewModel"/>.
    /// </summary>
    public class ChatListDesignModel : ChatListViewModel
    {
        public static ChatListDesignModel Instance { get { return instance; } }

        private static readonly ChatListDesignModel instance = new ChatListDesignModel();

        private ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Initials = "JD",
                    Name = "John Doe",
                    Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ProfilePictureRGB = "888888",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Initials = "DA",
                    Name = "Dimetri Alky",
                    Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Initials = "PL",
                    Name = "Parnell Lovetz",
                    Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ProfilePictureRGB = "3099c5",
                    IsSelected = true
                }
            };
        }
    }
}
