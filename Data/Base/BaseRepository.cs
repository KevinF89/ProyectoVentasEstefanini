using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Base
{
    /// <summary>
    /// Repository implementation to for the data entities.
    /// </summary>
    /// <typeparam name="T">Generic type for the data entities.</typeparam>
    public class BaseRepository<T> where T : class
    {
        /// <summary>
        /// The database context.
        /// </summary>
        private readonly DbContext context;

        /// <summary>
        /// The entities.
        /// </summary>
        private DbSet<T> entities;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BaseRepository(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the table.
        /// </summary>
        public IQueryable<T> Track
        {
            get
            {
                return this.Entities;
            }
        }

        /// <summary>
        /// Gets the table with no tracking option.
        /// </summary>
        public IQueryable<T> NoTrack
        {
            get
            {
                return this.Entities.AsNoTracking();
            }
        }

        /// <summary>
        /// Gets the entities.
        /// </summary>
        protected virtual DbSet<T> Entities
        {
            get
            {
                if (this.entities == null)
                {
                    this.entities = this.context.Set<T>();
                }

                return this.entities;
            }
        }

        /// <summary>
        /// Deletes the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void Delete(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }

            while (entities.Count() > 0)
            {
                this.context.Entry(entities.ElementAt(0)).State = EntityState.Deleted;
            }

            this.context.SaveChanges();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.Entities.Remove(entity);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Deletes the specified entities asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>The count of deleted items.</returns>
        public async Task<int> DeleteAsync(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }

            foreach (var entity in entities)
            {
                this.context.Entry(entity).State = EntityState.Deleted;
            }

            return await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The number of changes in the database.</returns>
        public async Task<int> DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.context.Entry(entity).State = EntityState.Deleted;
            this.Entities.Remove(entity);
            return await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.Entities.Add(entity);

            this.context.SaveChanges();
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>      
        public async Task<int> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.context.Entry(entity).State = EntityState.Modified;
            return await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>      
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        /// <summary>
        /// Inserts the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void Insert(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }

            foreach (T entity in entities)
            {
                this.Entities.Add(entity);
            }

            this.context.SaveChanges();
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The number of changes in the database.</returns>
        public async Task<int> InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.Entities.Add(entity);
            return await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Inserts the asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>The number of changes in the database.</returns>
        public async Task<int> InsertAsync(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }

            foreach (var entity in entities)
            {
                this.Entities.Add(entity);
            }

            return await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Save the context changes (needs table tracking).
        /// </summary>
        /// <returns>The number of changes in the database.</returns>
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        /// <summary>
        /// Save the context changes asynchronously (needs table tracking).
        /// </summary>
        /// <returns>The task</returns>
        public async Task<int> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Detach an entity from table tracking.
        /// </summary>
        /// <param name="entity">Entity to detach.</param>
        public void Detach(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.context.Entry(entity).State = EntityState.Detached;
        }

        /// <summary>
        /// Detach an entity from table tracking.
        /// </summary>
        /// <param name="entities">Entities to detach.</param>
        public void Detach(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }

            while (entities.Count() > 0)
            {
                this.context.Entry(entities.ElementAt(0)).State = EntityState.Detached;
            }
        }
    }
}
