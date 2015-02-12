using System;
using NServiceBus;

namespace Messages
{
    public class ApprovePost : ICommand
    {
        public Guid Id { get; set; }
        public DateTime WhenApproved { get; set; }
    }
}