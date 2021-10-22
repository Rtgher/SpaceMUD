using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Data.Base.Interface;

namespace SpaceMUD.Database.Repositor.Base.Interface
{
    /// <summary>
    /// A public interface for a generic IRepository to be used throughout the game.
    /// </summary>
    /// <typeparam name="T">The object type to handle.</typeparam>
    public interface IRepository<T> where T : IDatabaseObject
    {
        /// <summary>
        /// Returns all objects of that type. Potentially resource intensive. Use Sparingly.
        /// </summary>
        /// <returns>A Collection of all items.</returns>
        IEnumerable<T> GetAll();
        /// <summary>
        ///Returns all objects of that type. Potentially resource intensive. Use Sparingly.
        /// </summary>
        /// <returns>Async Task containing a collection of all items.</returns>
        Task<IEnumerable<T>> GetAllAsync();
        /// <summary>
        /// Returns a single entity by its Id.
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <returns>A single entity</returns>
        T GetSingle(long id);
        /// <summary>
        /// Returns a single entity by its Id asynchronously.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <returns>A Task containing a single entity.</returns>
        Task<T> GetSingleAsync(long id);
        /// <summary>
        /// Insert an object into the Database.
        /// </summary>
        /// <param name="obj">the object to be inserted.</param>
        /// <returns>The object after it was inserted.</returns>
        T Insert(T obj);
        /// <summary>
        /// Insert an object into the Database asynchronously.
        /// </summary>
        /// <param name="obj">the object to be inserted.</param>
        /// <returns>A Task containing the object after it was inserted.</returns>
        Task<T> InsertAsync(T Obj);
        /// <summary>
        /// Updates an item in the database.
        /// </summary>
        /// <param name="obj">The object to update.</param>
        void Update(T obj);
        /// <summary>
        /// Updates an item in the database async.
        /// </summary>
        /// <param name="obj">The object to update asynchrounously.</param>
        Task UpdateAsync(T obj);

    }
}
