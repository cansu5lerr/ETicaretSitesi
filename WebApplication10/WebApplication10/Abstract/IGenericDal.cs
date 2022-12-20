namespace WebApplication10.Abstract
{
    public interface IGenericDal <T> where T : class
    {
        List<T> GetListAll();
        void Insert(T item);
        void Update(T item);
        void Delete(T item);
        T GetById(int id);

    }
}
