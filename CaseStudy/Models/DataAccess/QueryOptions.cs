using System.Linq.Expressions;

namespace CaseStudy.Models.DataAccess
{
	public class QueryOptions<T>
	{
		public Expression<Func<T, Object>> OrderBy { get; set; }
		public Expression<Func<T, bool>> Where { get; set; }
		public string Includes { set => includes = value.Replace(" ", "").Split(','); }
		public string[] GetIncludes() => includes;
		public bool HasWhere => Where != null;
		public bool HasOrderBy => OrderBy != null;

		public string[] includes = Array.Empty<string>();
	}
}
