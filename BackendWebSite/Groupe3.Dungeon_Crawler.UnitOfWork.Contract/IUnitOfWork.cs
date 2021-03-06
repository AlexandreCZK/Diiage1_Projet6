using Groupe3.Dungeon_Crawler.Repository.Contracts;
using Groupe3.Dungeon_Crrawler.Services;
using Microsoft.EntityFrameworkCore;
using System;

namespace Groupe3.Dungeon_Crawler.UnitOfWork.Contract
{
    public interface IUnitOfWork<TContext, IGameService> : IDisposable where TContext : DbContext where IGameService : GameService
    {
        IGameService GameService { get; }

        /// <summary>
        /// Gets the db context.
        /// </summary>
        /// <returns>The instance of type TContext.</returns>
        TContext DbContext { get; }

        /// <summary>
        /// Gets the specified repository for the TEntity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>An instance of type inherited from GenericRepository interface.</returns>
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity.Entity;

        /// <summary>
        /// Commit all changes made in this context to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        int Save();
    }
}
