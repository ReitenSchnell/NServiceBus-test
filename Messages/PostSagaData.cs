using System;
using NServiceBus.Saga;

namespace Messages
{
    public class PostSagaData : ContainSagaData
    {
        [Unique]
        public Guid PostId { get; set; }

        public bool IsApproved { get; set; }
    }
}