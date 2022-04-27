using System;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using ShipWebService.Commands.AddShip;
using ApplicationCore.Interfaces;
using AutoMapper;

namespace Web.Tests;

[TestFixture]
public class BaseTest
{
    public IServiceCollection _services;

    public IConfiguration Configuration { get; protected set; }

    protected IMediator _mediator;


    protected IServiceProvider _serviceProvider;
    protected DbContextOptions<ShipContext> _contextOptions;

    [SetUp]
    public void BaseSetup()
    {
        _services = new ServiceCollection();
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");
        Environment.SetEnvironmentVariable("ApplicationName", "Ship.Web");

       
            

        _services.AddLogging();
        _services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
        _services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
        var assembly = Assembly.GetAssembly(typeof(AddShipCommand));
        _services.AddMediatR(assembly);
        _contextOptions = new DbContextOptionsBuilder<ShipContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        EnsureDbCreated();

        var mockDbContextFactory = new Mock<IDbContextFactory<ShipContext>>();
        mockDbContextFactory
            .Setup(x => x.CreateDbContext())
            .Returns(() => new ShipContext(_contextOptions));
        _services.AddSingleton(mockDbContextFactory.Object);
    }

    private void EnsureDbCreated()
    {
        using var context = new ShipContext(_contextOptions);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
}