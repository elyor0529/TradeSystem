namespace Trade.Data
{
    public abstract class RepositoryContextBase
    {
        public abstract IRepository<T> GetRepository<T>() where T : class;
         
    }
}