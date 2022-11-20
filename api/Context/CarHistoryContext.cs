using CarHistoryAPI.Model;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarHistoryAPI.Context;
public class CarHistoryContext : DbContext
{
    public CarHistoryContext(DbContextOptions<CarHistoryContext> opt) : base(opt)
    {
    }
    public DbSet<MileageModel> Users => Set<MileageModel>();

    #region Required
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
    }
    #endregion
}