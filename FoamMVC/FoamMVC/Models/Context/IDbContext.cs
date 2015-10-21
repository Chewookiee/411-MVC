using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoamMVC.Models.Context
{
    public interface IDbContext
    {
        #region DbContext public properties
        DbChangeTracker ChangeTracker { get; }
        DbContextConfiguration Configuration { get; }
        Database Database { get; }
        #endregion

        #region DbContext public methods
        IEnumerable<DbEntityValidationResult> GetValidationErrors();
        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet Set(Type entityType);
        int SaveChanges();
        #endregion

        DbSet<Category> Categories { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<Like> Likes { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<PalletDescriptor> PalletDescriptors { get; set; }
        DbSet<PalletGroup> PalletGroups { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<ReviewScoreForDescriptor> ReviewScoreForDescriptors { get; set; }
        DbSet<Tag> Tags { get; set; }
        //DbSet<User> Users { get; set; }
        DbSet<UserScoreForDescriptor> UserScoreForDescriptors { get; set; }
    }
}
