using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Client.Register;
using ProductClientHub.API.UseCases.Client.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Exceptions.ExceptionBase;

namespace ProductClientHub.API.UseCases.Client.Update
{
    public class UpdateClientUseCase
    {
        public void Execute(Guid clientId, RequestClientJson request)
        {
            Validade(request);

            var dbContext = new ProductClientHubDbContext();

            var entity = dbContext.clients.FirstOrDefault(c => c.Id == clientId);

            if (entity is null)
                throw new NotFoundException("Cliente não encontrado");

            entity.Name = request.Name;
            entity.Email = request.Email;

            dbContext.clients.Update(entity);
            dbContext.SaveChanges();
        }

        private void Validade(RequestClientJson request)
        {
            var validator = new RequestClientValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOrValidationException(errors);
            }
        }
    }
}
