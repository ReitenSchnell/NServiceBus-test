﻿using System;
using NServiceBus;

namespace Messages
{
    public class PostCreated : IEvent
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
