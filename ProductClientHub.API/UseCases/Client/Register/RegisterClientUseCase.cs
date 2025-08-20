using Org.BouncyCastle.Asn1.Ocsp;
using ProductClientHub.API.Entities;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
// Adicione o 'using' para a sua nova exceção
using ProductClientHub.Exceptions.ExceptionBase;
// A classe base abstrata também pode estar no mesmo namespace
using ProductClientHub.Exceptions.ExeptionBase;


namespace ProductClientHub.API.UseCases.Client.Register
{
    public class RegisterClientUseCase
    {
        public ResponseClientJson Execute(RequestClientJson request)
        {
            Validate(request);

            var dbContext = new ProductClientHubDbContext();

            var entity = new Entities.Client
            {
                Name = request.Name,
                Email = request.Email
            };

            dbContext.clients.Add(entity);

            dbContext.SaveChanges();

            return new ResponseClientJson
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        private void Validate(RequestClientJson request)
        {
            var validator = new RegisterClientValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOrValidationException(errors);
            }
        }
    }
}