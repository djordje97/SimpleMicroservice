using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastEndpoints;
using MediatR;
using Presentation.Contracts;
using Presentation.Mappers;

namespace Presentation.Controllers.Product
{
    public class Create : Endpoint<CreateProductRequest, CreateProductResponse>
    {
        private readonly IMediator _mediator;

        public Create(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Post("products");
        }

        public override async Task HandleAsync(CreateProductRequest req, CancellationToken ct)
        {
            var product = await _mediator.Send(req.ToCommand(), ct);
            await SendOkAsync(product.ToApiResponseFromCommand(), ct);
        }
    }
}