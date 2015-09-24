namespace Phoenix.PhoenixApp.Application.MainBoundedContext.ProfileModule.Messaging
{
    using System;

    public class ManageFriendshipRequest : RequestBase
    {
        public Guid FriendshipId { get; set; }

        public ManageFriendshipRequestType RequestType { get; set; }

        public string UserName { get; set; }
    }
}