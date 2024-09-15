using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Queries;
using FastEndpoints;
using MediatR;
using Presentation.Contracts;
using Presentation.Mappers;

namespace Presentation.Controllers.Product
{
    public class GetById : EndpointWithoutRequest<ProductByIdResponse>
    {
        IMediator _mediator;

        public GetById(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("/products/{productId}");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var productId = Route<Guid>("productId");
            var product = await _mediator.Send(new GetProductByIdQuery(productId));
            if (product is null)
            {
                await SendNotFoundAsync(ct);
            }

            await SendOkAsync(product.ToApiResponse(), ct);
        }
    }
}