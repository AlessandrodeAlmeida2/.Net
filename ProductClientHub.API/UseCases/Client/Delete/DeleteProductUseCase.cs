using ProductClientHub.API.Infrastructure;
using ProductClientHub.Exceptions.ExceptionBase;

namespace ProductClientHub.API.UseCases.Product.Delete
{
    public class DeleteClientUseCase
    {
        public void Execute(Guid id)
        {
            var dbContext = new ProductClientHubDbContext();

            var entity = dbContext.clients.FirstOrDefault(c => c.Id == id);
            if (entity == null)
                throw new NotFoundException("Client not found");

            dbContext.clients.Remove(entity);

            dbContext.SaveChanges();
        }
    }
}
