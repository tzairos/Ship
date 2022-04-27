using System.Reflection;
using MediatR;
using FluentValidation;
using ShipWebService.Helpers;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews(opt =>
{
    opt.AllowEmptyInputInBodyModelBinding = true;
}).AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include;
    opt.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.IgnoreAndPopulate;
    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});
var assembly = Assembly.GetExecutingAssembly();
builder.Services.AddApplicationCoreServices();
builder.Services.AddMediatR(assembly);

builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddAutoMapper(assembly);
builder.Services.Configure<ApiBehaviorOptions>(options =>
{

    options.InvalidModelStateResponseFactory = actionContext =>
      {
          var validationErrors = actionContext.ModelState.Keys
              .SelectMany(key => actionContext.ModelState[key].Errors.Select(x => new ValidationError
              { Field = key, Message = x.ErrorMessage })).ToList();
          var formattedErrors = (validationErrors.Select(x => $"{x.Field}:{x.Message}").ToList());

          throw new ApplicationException(String.Join("\n", formattedErrors), ErrorType.ValdiationError);
      };

});
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
var connectionString =
            builder.Configuration.GetConnectionString("Default");
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddDbContextFactory<ShipContext>((options) =>
            {
                options.UseSqlite(connectionString);
            });
builder.Services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseMiddleware<JwtMiddleware>();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");

});
app.MapFallbackToFile("index.html"); ;
using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    try
    {
        var contextFactory = scopedProvider.GetRequiredService<IDbContextFactory<ShipContext>>();
        await ContextSeed.SeedAsync(contextFactory, app.Logger);


    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred seeding the DB.");
    }
}
app.Run();
