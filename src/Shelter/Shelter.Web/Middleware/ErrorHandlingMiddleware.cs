using System;
using System.Collections.Generic;
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
			catch (ShelterValidationException exception)
			{
				var model = new ShelterResponseJsonModel<Dictionary<string, string[]>>
				{
					Success = false,
					Data = exception.GetValidationMessage()
				};

				await HandleExceptionAsync(context, HttpStatusCode.BadRequest, model, options);
			}
			catch (Exception exception)
			{
				var model = new ShelterResponseJsonModel<string>
				{
					Success = false,
					Data = exception.Message
				};
				
				await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, model, options);
			}
		}

		private async Task HandleExceptionAsync(
			HttpContext context, 
			HttpStatusCode code, 
			ShelterResponseJsonModel model, 
			IOptions<MvcJsonOptions> options)
		{
			var result = JsonConvert.SerializeObject(model, options.Value.SerializerSettings);
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)code;
			await context.Response.WriteAsync(result);
		}
	}
}