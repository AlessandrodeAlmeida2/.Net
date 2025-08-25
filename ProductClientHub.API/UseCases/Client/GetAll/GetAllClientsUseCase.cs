using ProductClientHub.API.Infrastructure;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Communication.Requests;

namespace ProductClientHub.API.UseCases.Client.GetAll
{
    public class GetAllClientsUseCase
    {
        public ResponseAllClientsJson Execute()
        {
            var dbContext = new ProductClientHubDbContext();

            var clients = dbContext.clients.ToList();

            return new ResponseAllClientsJson
            {
                Clients = clients.Select(client => new ResponseShortClientJson
                {
                    Id = client.Id,
                    Name = client.Name
                }).ToList()
            };
        }
    }
}
