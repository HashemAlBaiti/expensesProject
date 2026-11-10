using System.Linq.Expressions;

namespace expensesProject.Repostory.Base
{
    public interface IRepostory<T> where T : class
    {
        T? FindId(int? Id, params string[] agers);   
        T? FindId(int? Id);   
        Task<T> FindByIdAsync(int Id);
        Task<T> FindByIdAsync(int Id, params string[] agers);

        Task<bool> ExistAsyc(Expression<Func<T,bool>> match);


        T SelectOne(Expression<Func<T, bool>> match);
        Task<T> SelectOneAsync(string agers, Expression<Func<T, bool>> match);  


        List<T> SelectMany(Expression<Func<T, bool>> match);
        List<T> SelectMany(Expression<Func<T, bool>> match, params string[] agers);

        IEnumerable<T> SelectWithPagination(int PageNumber, int PageSize, params string[] agers);
        IEnumerable<T> SelectWithPagination(IQueryable<T> query, int PageNumber, int PageSize, params string[] agers);
        Task<IEnumerable<T>> SelectWithPaginationAsync(IQueryable<T> query, int PageNumber, int PageSize, params string[] agers);

        Task<List<T>> SelectManyAsync(Expression<Func<T, bool>> match);


        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(params string[] agers);

        IQueryable<T> GetQueryable();
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params string[] agers);


       

        void AddOne(T entity);
        Task AddOneAsync(T entity);
        void AddMany(List<T> entities); 


        void UpdateOne(T entity);
        void UpdateMany(List<T> entities);


        void DeleteOne(T entity);
        void DeleteMany(List<T> entities);


        Task<IEnumerable<TResult>> GetSelected<TResult>(
      Expression<Func<T, bool>> filter = null,
      Expression<Func<T, TResult>> selector = null,
      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);


        IEnumerable<TResult> GetSelectedHash<TResult>(
      Expression<Func<T, bool>> filter = null,
      Expression<Func<T, TResult>> selector = null,
      Expression<Func<T, bool>> orderBy = null);

    }
}
