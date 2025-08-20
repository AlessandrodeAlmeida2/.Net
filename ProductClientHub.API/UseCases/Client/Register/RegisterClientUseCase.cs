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
            var validator = new RegisterClientValidator();
            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOrValidationException(errors);
            }

            return new ResponseClientJson();
        }
    }
}