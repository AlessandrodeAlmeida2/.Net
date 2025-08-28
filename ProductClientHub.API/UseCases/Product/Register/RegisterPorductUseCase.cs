using ProductClientHub.API.Entities;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Product.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionBase;

namespace ProductClientHub.API.UseCases.Product.Register
{
    public class RegisterProductUseCase
    {
        public ResponseShortProductJson Execute(Guid clientId, RequestProductJson request)
        {
            var dbContext = new ProductClientHubDbContext();

            Validate(dbContext, clientId, request);

            var entity = new Products
            {
                Name = request.Name,
                Brand = request.Brand,
                Price = request.Price,
                ClientId = clientId,
            };

            dbContext.products.Add(entity);

            dbContext.SaveChanges();

            return new ResponseShortProductJson
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        private void Validate(ProductClientHubDbContext dbContext, Guid clientId, RequestProductJson request)
        {
            var clientExist = dbContext.clients.Any(c => c.Id == clientId);
            if (clientExist == false)
            {
                throw new NotFoundException("Client not found");
            }

            var validator = new RequestProductValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOrValidationException(errors);
            }
        }
    }
}