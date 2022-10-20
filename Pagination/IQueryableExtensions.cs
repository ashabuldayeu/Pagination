using System.Linq;
using System.Linq.Expressions;

namespace Pagination
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyPagination<T, TKey>(this IQueryable<T> query, PaginationRequest<TKey> paginationRequest, Expression<Func<T, TKey>> keySelector)
        {
            var compareTo =  Expression.Call(keySelector.Body, "CompareTo", Type.EmptyTypes, Expression.Constant(paginationRequest.LastKey));
            var comparison = Expression.GreaterThan(compareTo, Expression.Constant(0));
            Expression<Func<T, bool>> expression = Expression.Lambda<Func<T, bool>>(comparison, keySelector.Parameters[0]);
            return query.OrderBy(keySelector).Where(expression).Take((int)paginationRequest.Take);
        }
    }
}
