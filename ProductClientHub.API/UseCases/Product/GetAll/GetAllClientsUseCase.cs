using ProductClientHub.API.Infrastructure;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Communication.Requests;
using ProductClientHub.API.Entities;

namespace ProductClientHub.API.UseCases.Client.GetAll
{
    public class GetAllProductsUseCase
    {
        public ResponseAllProductsJson Execute()
        {
            var dbContext = new ProductClientHubDbContext();

            var products = dbContext.products.ToList();

            return new ResponseAllProductsJson
            {
                Products = products.Select(p => new ResponseShortProductJson
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList()
            };
        }
    }
}
