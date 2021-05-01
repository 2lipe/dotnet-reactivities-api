using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Reactivities.Domain.Entities;
using Reactivities.Infra.Context;

namespace Reactivities.Application.Activities
{
    public class UpdateActivity
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public Activity Activity { get; set; }
        }
        
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Id);

                if (activity == null)
                {
                    throw new FileNotFoundException($"Activity with ID: {request.Id} was not found");
                }

                _mapper.Map(request.Activity, activity);
                
                await _context.SaveChangesAsync();
                
                return Unit.Value;
            }
        }
    }
}