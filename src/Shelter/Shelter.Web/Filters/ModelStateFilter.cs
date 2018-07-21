using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Shelter
{
	public class ModelStateFilter : ActionFilterAttribute
	{
		public override void OnResultExecuting(ResultExecutingContext context)
		{
			var result = new JsonResult(
				new ShelterResponseViewModel<object>
				{
					Success = context.ModelState.IsValid,
					Data = (context.Result as ObjectResult).Value
				});

			context.Result = result;
			context.HttpContext.Response.StatusCode = context.ModelState.IsValid
				? StatusCodes.Status200OK
				: StatusCodes.Status400BadRequest;
		}
	}
}