using DatabaseLibrary.Dao;

namespace DatabaseLibrary.Factory
{
    /// <summary>
    /// Class contains a factory method.
    /// </summary>
    /// <typeparam name="T">The object type.</typeparam>
    public abstract class DaoCreator<T>
    {
        /// <summary>
        /// Create the dao object.
        /// </summary>
        /// <returns></returns>
        public abstract Dao<T> CreateDao();
    }
}
