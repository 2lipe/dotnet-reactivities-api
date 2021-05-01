using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reactivities.Infra.Context;

namespace Reactivities.Application.Activities
{
    public class DeleteActivity
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }
        
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Id);

                if (activity == null)
                {
                    throw new FileNotFoundException($"Activity with ID: {request.Id} was not found");
                }

                _context.Remove(activity);

                await _context.SaveChangesAsync();
                
                return Unit.Value;
            }
        }
    }
}