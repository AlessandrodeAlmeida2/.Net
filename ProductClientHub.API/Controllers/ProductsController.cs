using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Client.GetAll;
using ProductClientHub.API.UseCases.Product.Delete;
using ProductClientHub.API.UseCases.Product.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpPost]
        [Route("{clientId}")]
        [ProducesResponseType(typeof(ResponseShortProductJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseShortProductJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseShortProductJson), StatusCodes.Status404NotFound)]
        public IActionResult Register([FromRoute] Guid clientId, [FromBody] RequestProductJson request)
        {
            var useCase = new RegisterProductUseCase();

            var response = useCase.Execute(clientId, request);

            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllProductsJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            var useCase = new GetAllProductsUseCase();

            var response = useCase.Execute();

            if (response.Products.Count == 0)
                return NoContent();

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseShortProductJson), StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var useCase = new DeleteProductUseCase();

            useCase.Execute(id);

            return NoContent();
        }
    }
}
