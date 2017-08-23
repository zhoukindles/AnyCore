using AnyCore.Core.Domain.ApplicationUser;
using AnyCore.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AnyCore.Data
{
    public class AnyContext : DbContext
    {
        public AnyContext(DbContextOptions<AnyContext> options)
            : base(options)
        {
            
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        

        #region Utilities

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                type.BaseType.GetGenericTypeDefinition() == typeof(AnyEntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
            //...or do it manually below. For example,
            //modelBuilder.Configurations.Add(new LanguageMap());

            base.OnModelCreating(modelBuilder);
        }

        ///// <summary>
        ///// Attach an entity to the context or return an already attached entity (if it was already attached)
        ///// </summary>
        ///// <typeparam name="T">TEntity</typeparam>
        ///// <param name="entity">Entity</param>
        ///// <returns>Attached entity</returns>
        //protected virtual T AttachEntityToContext<T>(T entity) where T : class, new()
        //{
        //    //little hack here until Entity Framework really supports stored procedures
        //    //otherwise, navigation properties of loaded entities are not loaded until an entity is attached to the context
        //    var alreadyAttached = Set<T>().Local.FirstOrDefault();
        //    if (alreadyAttached == null)
        //    {
        //        //attach new entity
        //        Set<T>().Attach(entity);
        //        return entity;
        //    }

        //    //entity is already loaded
        //    return alreadyAttached;
        //}

        #endregion
    }
}
