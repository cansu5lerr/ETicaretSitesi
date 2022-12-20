namespace WebApplication10.Abstract
{
    public interface IRepository<T> where T : class
    {
        List<T> List();
        void Insert(T item);
        void Update(T item);
        void Delete(T item);
        T GetById(int id);


    }
}
