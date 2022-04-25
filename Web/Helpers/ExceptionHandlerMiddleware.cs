namespace ShipWebService.Helpers;
using System.Net;
using System.Text.Json;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {

        try
        {
            await _next(context);
        }
        //ApplicationException
         catch (ApplicationException error)
        {
            if(error.ErrorType==ErrorType.ValdiationError){
                 context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
            var response = new ResponseBase()
            {
                //Exception = error,
                Message = error.Message,
                StatusCode = (int)HttpStatusCode.UnprocessableEntity
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
            else{
                 context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var response = new ResponseBase()
            {
                //Exception = error,
                Message = "Internal Server Error from the custom middleware.",
                StatusCode = (int)HttpStatusCode.UnprocessableEntity
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }

        }
        catch (Exception error)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var response = new ResponseBase()
            {
                //Exception = error,
                Message = "Internal Server Error from the custom middleware.",
                StatusCode = (int)HttpStatusCode.UnprocessableEntity
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}