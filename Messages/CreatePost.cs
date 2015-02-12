using System;
using NServiceBus;

namespace Messages
{
    public class CreatePost : ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
