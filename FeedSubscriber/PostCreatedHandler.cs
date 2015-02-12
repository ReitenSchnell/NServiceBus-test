using System;
using Messages;
using NServiceBus;

namespace FeedSubscriber
{
    public class PostCreatedHandler : IHandleMessages<PostCreated>
    {
        public IBus Bus { get; set; }

        public void Handle(PostCreated message)
        {
            Console.WriteLine(@"Post with title:{0} placed with id: {1}", message.Title, message.Id);
        }
    }
}
