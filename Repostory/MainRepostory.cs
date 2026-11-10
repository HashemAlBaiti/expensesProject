

using expensesProject.Data;
using expensesProject.Repostory.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Repostory.Repostory
{
    public class MainRepostory<T> : IRepostory<T> where T : class
    {
        public MainRepostory(AppDbContext _context)
        {
            this._context = _context;
        }

        protected AppDbContext _context;
        
        public void AddMany(List<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public void AddOne(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public async Task AddOneAsync(T entity)
        {
            _ = _context.Set<T>().AddAsync(entity);
        }

        public void DeleteMany(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void DeleteOne(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> FindByIdAsync(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public T? FindId(int? Id, params string[] agers)
        {
            IQueryable<T> entity = _context.Set<T>();

            foreach (string name in agers)
            {
                entity = entity.Include(name);
            }

            return entity.FirstOrDefault(e => EF.Property<int?>(e, "Id") == Id);
        }

        public T? FindId(int? Id)
        {
            return _context.Set<T>().FirstOrDefault(e => EF.Property<int?>(e, "Id") == Id);
        }

        public async Task<T> FindByIdAsync(int Id, params string[] agers)
        {
            IQueryable<T> entity = _context.Set<T>();
            foreach (string name in agers)
            {
                entity = entity.Include(name);
            }
            return await entity.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == Id);
        }

        public async Task<bool> ExistAsyc(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Any(match);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public IEnumerable<T> GetAll(params string[] agers)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var ager in agers)
            {
                query = query.Include(ager);
            }
            return query.AsNoTracking().ToList();
        }

        public IQueryable<T> GetQueryable()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params string[] agers)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var ager in agers)
            {
                query = query.Include(ager);
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public List<T> SelectMany(Expression<Func<T, bool>> match, params string[] agers)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var ager in agers)
            {
                query = query.Include(ager);
            }
            return query.Where(match).ToList();
        }


        public List<T> SelectMany(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Where(match).ToList();
        }

        public async Task<List<T>> SelectManyAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().Where(match).ToListAsync();
        }

        public T SelectOne(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().SingleOrDefault(match);
        }

        public async Task<T> SelectOneAsync(string agers, Expression<Func<T, bool>> match)
        {


            IQueryable<T> query =  _context.Set<T>();

           
                query = query.Include(agers);
            

            return query.SingleOrDefault();


        }

        public void UpdateMany(List<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
        }

        public void UpdateOne(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async  Task<IEnumerable<TResult>> GetSelected<TResult>(Expression<Func<T, bool>> filter = null, Expression<Func<T, TResult>> selector = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = _context.Set<T>();

            // 2. تطبيق الفلتر (Where) إذا تم إرساله
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // 3. تطبيق الترتيب (OrderBy) إذا تم إرساله
            if (orderBy != null)
            {
                query = orderBy(query).AsNoTracking();
            }

            // 4. تطبيق التحويل (Select) والتنفيذ وجلب البيانات من قاعدة البيانات
            if (selector != null)
            {
                return query.Select(selector).ToList();
            }

            // في حال لم يتم إرسال selector (حالة احتياطية ولكن غالباً ستحتاجه دائماً في هذه الدالة)
            return await query.Cast<TResult>().ToListAsync();
        }

        public IEnumerable<TResult> GetSelectedHash<TResult>(Expression<Func<T, bool>> filter = null, Expression<Func<T, TResult>> selector = null, Expression<Func<T, bool>> orderBy = null)
        {
            IQueryable<T> query = _context.Set<T>();

            // 2. تطبيق الفلتر (Where) إذا تم إرساله
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // 3. تطبيق الترتيب (OrderBy) إذا تم إرساله
            if (orderBy != null)
            {
                query = query.OrderBy(orderBy);
            }

            // 4. تطبيق التحويل (Select) والتنفيذ وجلب البيانات من قاعدة البيانات
            if (selector != null)
            {
                return query.Select(selector).ToList();
            }

            // في حال لم يتم إرسال selector (حالة احتياطية ولكن غالباً ستحتاجه دائماً في هذه الدالة)
            return query.Cast<TResult>().ToList();
        }



        public IEnumerable<T> SelectWithPagination(IQueryable<T> query, int PageNumber, int PageSize, params string[] agers)
        {
            foreach (var Table in agers)
            {
                query = query.Include(Table);
            }
            IEnumerable<T> result = query.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();

            return result;
        }

        public IEnumerable<T> SelectWithPagination(int PageNumber, int PageSize,params string[] agers)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var Table in agers)
            {
                query = query.Include(Table);
            }

            IEnumerable<T> result = query.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();

            return result;
        }

        public async Task<IEnumerable<T>> SelectWithPaginationAsync(IQueryable<T> query, int PageNumber, int PageSize, params string[] agers)
        {
            foreach (var Table in agers)
            {
                query = query.Include(Table);
            }
            IEnumerable<T> result = await query.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToListAsync();

            return result;
        }

       
    }
}
