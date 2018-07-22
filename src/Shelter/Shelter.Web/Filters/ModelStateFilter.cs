using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Shelter
{
	public class ModelStateFilter : ActionFilterAttribute
	{
		public override void OnResultExecuting(ResultExecutingContext context)
		{
			var data = (context.Result as ObjectResult)?.Value
				?? context.Result;
			
			var result = new JsonResult(
				new ShelterResponseJsonModel<object>
				{
					Success = context.ModelState.IsValid,
					Data = data
				});

			context.Result = result;
			context.HttpContext.Response.StatusCode = context.ModelState.IsValid
				? StatusCodes.Status200OK
				: StatusCodes.Status400BadRequest;
		}
	}
}