using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Shelter
{
	public class ErrorHandlingMiddleware
	{
		private readonly RequestDelegate next;

		public ErrorHandlingMiddleware(RequestDelegate next)
		{
			this.next = next;
		}

		public async Task Invoke(HttpContext context, IOptions<MvcJsonOptions> options)
		{
			try
			{
				await next(context);
			}
			catch (Exception exception)
			{
				var code = HttpStatusCode.InternalServerError;

				var model = new ShelterResponseViewModel<string>
				{
					Success = false,
					Data = exception.Message
				};

				var result = JsonConvert.SerializeObject(model, options.Value.SerializerSettings);
				context.Response.ContentType = "application/json";
				context.Response.StatusCode = (int)code;
				await context.Response.WriteAsync(result);
			}
		}
	}
}