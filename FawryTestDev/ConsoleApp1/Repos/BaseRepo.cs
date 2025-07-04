using ConsoleApp1.InterFaces;
using System.Security.Cryptography;

namespace ConsoleApp1.Repos
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        public List<T> DbSet { get; set; }

        public BaseRepo(List<T> dbSet)
        {
            DbSet = dbSet ?? throw new ArgumentNullException(nameof(dbSet), "DbSet cannot be null.");
        }
        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public bool Delete(int Id)
        {
            T element = GetById(Id);

            if (element == null)
                return false;

            var elementIdType = typeof(T).GetProperty("Id");

            if (elementIdType == null)
                throw new InvalidOperationException($"Type {typeof(T).Name} does not have an 'Id' property.");

            int elementId = (int)elementIdType.GetValue(element);

            return DbSet.Remove(element);
        }

        public List<T> GetAll()
        {
            return DbSet;
        }

        public T GetById(int id)
        {
            var elementId = typeof(T).GetProperty("Id");

            if(elementId == null)
                throw new InvalidOperationException($"Type {typeof(T).Name} does not have an 'Id' property.");

            return DbSet.FirstOrDefault(item => elementId.GetValue(item) is int intValue && intValue == id);


        }

        public void Update(int Id, T entity)
        {
            T element = GetById(Id);

            if (element == null)
                throw new InvalidOperationException($"Element with Id {Id} not found.");

            bool isDeleted = DbSet.Remove(element);

            if (!isDeleted)
                throw new InvalidOperationException($"Failed to remove element with Id {Id}.");

            DbSet.Add(entity);
        }
    }
}
