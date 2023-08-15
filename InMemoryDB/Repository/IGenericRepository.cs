namespace InMemoryDB.Repository
{
    public interface IGenericRepository<E, K>
    {
        public List<E> GetAll();
        public E GetById(K id);
        public E Create(E entity);
        public E Update(E entity);
        public void Delete(K id);
    }
}