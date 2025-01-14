
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.DeleteProduct;

//public record DeleteProductRequest();
public record DelteProductResponse(bool IsSuccess);
public class DeleteProductEnpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id}",
            async (Guid id, ISender sender) => 
            {
                var result = await sender.Send(new DeleteProductCommand(id));

                var response = result.Adapt<DelteProductResponse>();

                return Results.Ok(response);
            })
            .WithName("DeleteProduct")
            .Produces<DelteProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Product")
            .WithDescription("Delete Product");
    }
}
