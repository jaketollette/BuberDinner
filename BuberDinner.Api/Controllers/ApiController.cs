using BuberDinner.Api.Common.Errors.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
      protected IActionResult Problem(List<Error> errors)
      {
        HttpContext.Items[HttpContextItemKeys.Errors] = errors;
        var firstError = errors[0];

        var statusCode = firstError.Type switch
        {
          ErrorType.Conflict => StatusCodes.Status409Conflict,
          ErrorType.Validation => StatusCodes.Status400BadRequest,
          ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
          ErrorType.Forbidden => StatusCodes.Status403Forbidden,
          ErrorType.NotFound => StatusCodes.Status404NotFound,
          _ => 500
        };

        return Problem(
          detail: firstError.Description,
          statusCode: statusCode
        );
      }
    }
}