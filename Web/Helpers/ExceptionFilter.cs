using System.Net;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ExceptionFilter : ActionFilterAttribute, IAsyncExceptionFilter
{
    private readonly IHostEnvironment _hostEnvironment;
    public ExceptionFilter(IHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }


    public  Task OnExceptionAsync(ExceptionContext context)
    {
        Exception ex = context.Exception;
        String errMessage=context.Exception.Message;
        if (ex is ValidationException)
        {
         var response=new ResponseBase(){
             Message=errMessage,
             StatusCode= (int)HttpStatusCode.UnprocessableEntity
         };

         context.Result=new ObjectResult(response);
          context.HttpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
        }
        if (ex is AuthorizationException)
        {
           var response=new ResponseBase(){
             Message="Unauthorized",
             StatusCode= (int)HttpStatusCode.Unauthorized
         };
          context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
            return Task.CompletedTask;
    }
}