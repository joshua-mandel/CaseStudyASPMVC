using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Models.DataAccess
{
	public class Repository<T> : IRepository<T> where T : class
	{
		protected SportsProContext context { get; set; }
		private DbSet<T> dbSet { get; set; }
		public Repository(SportsProContext ctx)
		{
			context = ctx;
			dbSet = context.Set<T>();
		}

		public IEnumerable<T> List(QueryOptions<T> options)
		{
			IQueryable<T> query = BuildQuery(options);
			return query.ToList();
		}

		public T? Get(int id)
		{
			return dbSet.Find(id);
		}

		public T? Get(QueryOptions<T> options)
		{
			IQueryable<T> query = BuildQuery(options);
			return query.FirstOrDefault();
		}

		public void Insert(T entity)
		{
			dbSet.Add(entity);
		}

		public void Update(T entity)
		{
			dbSet.Update(entity);
		}

		public void Delete(T entity)
		{
			dbSet.Remove(entity);
		}

		public void Save()
		{
			context.SaveChanges();
		}

		private IQueryable<T> BuildQuery(QueryOptions<T> options)
		{
			IQueryable<T> query = dbSet;

			foreach (string include in options.GetIncludes())
			{
				query = query.Include(include);
			}

			if (options.HasWhere)
			{
				query = query.Where(options.Where);
			}
			if (options.HasOrderBy)
			{
				query = query.OrderBy(options.OrderBy);
			}

			return query;
		}
	}
}
