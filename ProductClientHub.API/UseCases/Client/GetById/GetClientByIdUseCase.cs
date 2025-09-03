using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionBase;

namespace ProductClientHub.API.UseCases.Client.GetById
{
    public class GetClientByIdUseCase
    {
        public ResponseClientJson Execute(Guid id)
        {
            var dbContext = new ProductClientHubDbContext();

            var entity = dbContext
                .clients
                .Include(c => c.Products)
                .FirstOrDefault(c => c.Id == id);
            if (entity is null)
                throw new NotFoundException("Client not found");

            return new ResponseClientJson
            {
                Id = id,
                Name = entity.Name,
                Email = entity.Email,
                Products = entity.Products.Select(p => new ResponseShortProductJson
                {
                    Id = p.Id,
                    Name = p.Name,
                    Brand = p.Brand,
                    Price = p.Price
                }).ToList()
            };
        }
    }
}
