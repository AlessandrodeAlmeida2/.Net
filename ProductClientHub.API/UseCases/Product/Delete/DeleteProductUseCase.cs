using ProductClientHub.API.Infrastructure;
using ProductClientHub.Exceptions.ExceptionBase;

namespace ProductClientHub.API.UseCases.Product.Delete
{
    public class DeleteProductUseCase
    {
        public void Execute(Guid id)
        {
            var dbContext = new ProductClientHubDbContext();

            var entity = dbContext.products.FirstOrDefault(c => c.Id == id);
            if (entity == null)
                throw new NotFoundException("Product not found");

            dbContext.products.Remove(entity);

            dbContext.SaveChanges();
        }
    }
}
