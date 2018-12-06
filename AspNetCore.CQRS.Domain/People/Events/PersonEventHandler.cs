using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCore.CQRS.Domain.People.Events
{
    public class PersonEventHandler :
        INotificationHandler<ChangePersonEmailEvent>,
        INotificationHandler<ChangePersonNameEvent>,
        INotificationHandler<DeletePersonEvent>,
        INotificationHandler<RegisterPersonEvent>
    {
        public Task Handle(ChangePersonEmailEvent notification, CancellationToken cancellationToken)
        {
            // Do Stuff
            return Task.CompletedTask;
        }

        public Task Handle(ChangePersonNameEvent notification, CancellationToken cancellationToken)
        {
            // Do Stuff
            return Task.CompletedTask;
        }

        public Task Handle(DeletePersonEvent notification, CancellationToken cancellationToken)
        {
            // Do Stuff
            return Task.CompletedTask;
        }

        public Task Handle(RegisterPersonEvent notification, CancellationToken cancellationToken)
        {
            // Do Stuff
            return Task.CompletedTask;
        }
    }
}
