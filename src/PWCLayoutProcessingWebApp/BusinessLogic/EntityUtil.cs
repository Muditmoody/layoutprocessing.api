using Microsoft.EntityFrameworkCore;
using PWCLayoutProcessingWebApp.Models;

namespace PWCLayoutProcessingWebApp.BusinessLogic
{
#nullable enable

    /// <summary>
    /// Entity Utility Class
    /// </summary>
    public static class EntityUtil
    {
        /// <summary>
        /// Adds the entity to database table
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        /// <param name="dataEntity">The data entity.</param>
        /// <param name="entities">The entities to be added</param>
        /// <param name="finder">Finder Lambda that search for existing entities in case of update</param>
        /// <param name="transformer">The transformer that transforms incoming entity to required database entity</param>
        /// <param name="doSearch">Flag to enable search and updates</param>
        /// <returns>Result with success (number of entities affected) or failure</returns>
        public static Result AddEntity<T, U>(DbContext dbContext, DbSet<T> dataEntity, IEnumerable<U> entities, Func<T, U, bool> finder, Func<U, T, T> transformer, bool doSearch = false) where T : class
        {
            foreach (var entity in entities.Where(entity => entity is not null))
            {
                if (doSearch && finder != null && dataEntity.AsEnumerable().Any(i => finder(i, entity)))
                {
                    var currentItem = dataEntity.AsEnumerable().FirstOrDefault(i => finder(i, entity));
                    var item = transformer(entity, currentItem);

                    if (currentItem != null && item != null)
                    {
                        dataEntity.Entry(currentItem).CurrentValues.SetValues(item);
                    }
                    else if (currentItem is null && item is not null)
                    {
                        dataEntity.Add(item);
                    }
                }
                else
                {
                    var item = transformer(entity, null);
                    dataEntity.Add(item);
                }
            }
            return new Result.Ok<int>(dbContext.SaveChanges());
        }

        /// <summary>
        /// Removes the entity.
        /// </summary>
        /// <param name="dbContext">The db context.</param>
        /// <param name="dataEntity">The data entity.</param>
        /// <param name="entities">The entities.</param>
        /// <returns>A Result.</returns>
        public static Result RemoveEntity<T>(DbContext dbContext, DbSet<T> dataEntity, IEnumerable<T> entities) where T : class
        {
            foreach (var entity in entities.Where(entity => entity is not null))
            {
                if (dataEntity.Contains(entity))
                    dataEntity.Remove(entity);
            }
            return new Result.Ok<int>(dbContext.SaveChanges());
        }
    }
}