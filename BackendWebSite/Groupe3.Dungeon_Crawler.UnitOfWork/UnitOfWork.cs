using Groupe3.Dungeon_Crawler.Repository;
using Groupe3.Dungeon_Crawler.Repository.Contracts;
using Groupe3.Dungeon_Crawler.UnitOfWork.Contract;
using Groupe3.Dungeon_Crrawler.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Groupe3.Dungeon_Crawler.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext, GameService> where TContext : DbContext
    {
        private readonly TContext _context;
        private bool disposed = false;
        private Dictionary<Type, object> _repositories;
        private GameService _gameService;

        /// <summary>
        /// Initializes a new instance of the UnitOfWork<TContext>.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(TContext context, GameService gameService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _gameService = gameService;
        }

        public GameService GameService => _gameService;

        public TContext DbContext => _context;

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity.Entity
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new GenericRepository<TEntity>(_context);
            }

            return (IGenericRepository<TEntity>)_repositories[type];
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                if (_repositories != null)
                {
                    _repositories.Clear();
                }
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
