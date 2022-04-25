using ApplicationCore.Entities.UserAggreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace Infrastructure.Data;
public class ContextSeed
{
    public static async Task SeedAsync(IDbContextFactory<Infrastructure.Data.ShipContext> contextFactory,
        ILogger logger,
        int retry = 0)
    {

        using var context = contextFactory.CreateDbContext();

             context.Database.EnsureDeleted();
         context.Database.EnsureCreated();

        var retryForAvailability = retry;
        try
        {


            if (!await context.Ships.AnyAsync())
            {
                await context.Ships.AddRangeAsync(
                    GetPreconfiguredShips());

                await context.SaveChangesAsync();
            }
            if (!await context.Users.AnyAsync())
            {
                await context.Users.AddRangeAsync(
                    GetPreconfiguredUsers());

                await context.SaveChangesAsync();
            }

        }
        catch (Exception ex)
        {
            if (retryForAvailability >= 10) throw;

            retryForAvailability++;

            logger.LogError(ex.Message);
            await SeedAsync(contextFactory, logger, retryForAvailability);
            throw;
        }
    }

    static IEnumerable<ApplicationCore.Entities.ShipAggreate.Ship> GetPreconfiguredShips()
    {
        return new List<ApplicationCore.Entities.ShipAggreate.Ship>
            {
              new ApplicationCore.Entities.ShipAggreate.Ship(){
                  Code="testcode1",
                  Length=5,
                  Name="testName1",
                  Width=5
              },
              new ApplicationCore.Entities.ShipAggreate.Ship(){
                  Code="testcode2",
                  Length=5,
                  Name="testName2",
                  Width=5
              }
            };
    }

    static IEnumerable<User> GetPreconfiguredUsers()
    {
        return new List<User>
            {
                new User(){
                    Id=1,
                    Password="test",
                    Username="test"
                }
            };
    }

}