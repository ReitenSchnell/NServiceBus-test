using System;
using Messages;
using NServiceBus;

namespace PublishingTool
{
    public class PostCreator : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }
        
        public void Start()
        {
            Console.WriteLine("Press 1 to send a message, press 2 to approve last message.To exit, Ctrl + C");
            var key = Console.ReadLine();
            var oldId = Guid.NewGuid();
            while (key != null)
            {
                switch (key)
                {
                    case "1":
                        var id = Guid.NewGuid();
                        Bus.Send("PublishingServer", new CreatePost { Title = "Some new post " + id, Id = id });
                        Console.WriteLine("Sent a new CreatePost message with id: {0}", id.ToString("N"));
                        oldId = id;
                        break;
                    case "2":
                        Bus.Send("PublishingServer", new ApprovePost { Id = oldId, WhenApproved = DateTime.Today});
                        Console.WriteLine("Sent a new ApprovePost message with id: {0}", oldId.ToString("N"));
                        break;
                }
                key = Console.ReadLine();
            }
        }
        
        public void Stop()
        {
        }
    }
}
