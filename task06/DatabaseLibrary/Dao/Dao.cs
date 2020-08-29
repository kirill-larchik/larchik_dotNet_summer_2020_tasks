using System.Collections.Generic;

namespace DatabaseLibrary.Dao
{
    /// <summary>
    /// Dao interface describind CRUD.
    /// </summary>
    /// <typeparam name="T">The object type.</typeparam>
    public interface Dao<T>
    {
        /// <summary>
        /// Connection string of the database.
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// Returns a list of nodes.
        /// </summary>
        /// <returns></returns>
        List<T> Read();

        /// <summary>
        /// Returns a node by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Updates a node in the database.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Update(T obj);

        /// <summary>
        /// Deletes a node from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// Create a new node in the database.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Create(T obj);
    }
}
