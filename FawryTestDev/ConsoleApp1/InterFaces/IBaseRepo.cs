
namespace ConsoleApp1.InterFaces
{
    public interface IBaseRepo<T> where T : class
    {
        List<T> DbSet { get; set; }
        void Add(T entity);
        void Update(int Id,T entity);
        bool Delete(int Id);
        T GetById(int id);
        List<T> GetAll();
    }
}
