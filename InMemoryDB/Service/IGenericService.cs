namespace InMemoryDB.Service
{
    public interface IGenericService<D, K>
    {
        public List<D> GetAll();
        public D GetById(K id);
        public D Create(D data);
        public D Update(K id, D data);
        public void Delete(K id);
    }
}