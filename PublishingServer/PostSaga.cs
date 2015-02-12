using System;
using Messages;
using NServiceBus;
using NServiceBus.Saga;
using Raven.Imports.Newtonsoft.Json;

namespace PublishingServer
{
    public class PostSaga:Saga<PostSagaData>,
        IAmStartedByMessages<CreatePost>,
        IHandleMessages<ApprovePost>,
        IHandleTimeouts<ApprovalTimeout>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<PostSagaData> mapper)
        {
            mapper.ConfigureMapping<ApprovePost>(post => post.Id).ToSaga(data => data.PostId);
        }

        public void Handle(CreatePost message)
        {
            Console.Out.WriteLine("Creating saga");
            Data.PostId = message.Id;
            RequestTimeout<ApprovalTimeout>(TimeSpan.FromSeconds(30));
        }

        public void Handle(ApprovePost message)
        {
            Console.Out.WriteLine("Approving post");
            Data.IsApproved = true;
            MarkAsComplete();
        }

        public void Timeout(ApprovalTimeout state)
        {
            Console.Out.WriteLine("Timeout worked");
            if (!Data.IsApproved)
            {
                Console.Out.WriteLine("Fuck off, I will approve it");
                Data.IsApproved = true;
                MarkAsComplete();
            }
        }
    }
}