using System;
using Messages;
using NServiceBus;

namespace PublishingServer
{
    public class CreatePostHandlerCopy : IHandleMessages<CreatePost>
    {
        public IBus Bus { get; set; }
        
        public void Handle(CreatePost message)
        {
            Console.WriteLine(@"Post with second COPY with id: {1}", message.Title, message.Id);
//            Console.WriteLine(@"Publishing: PostCreated event for Id: {0}", message.Id);
//            Bus.Publish<PostCreated>(e => { e.Id = message.Id; });
        }
    }
}
