namespace Carmelo.Word.Core.ViewModels.Chat.Design
{
    /// <summary>
    /// Design Model for the <see cref="ChatListItemViewModel"/>.
    /// </summary>
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        public static ChatListItemDesignModel Instance { get { return instance; } }

        private static readonly ChatListItemDesignModel instance = new ChatListItemDesignModel();

        private ChatListItemDesignModel()
        {
            Initials = "JD";
            Name = "John Doe";
            Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
            ProfilePictureRGB = "888888";
        }
    }
}
