using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Banking.CurrentAccount.Application.Wrappers;
using Microsoft.EntityFrameworkCore;

namespace Banking.CurrentAccount.Helpers
{
    public static class IQueryablePageListExtensions
    {
        /// <summary>
        ///     Converts the specified source to <see cref="IPagedList{T}" /> by the specified <paramref name="pageIndex" /> and
        ///     <paramref name="pageSize" />.
        /// </summary>
        /// <typeparam name="T">The type of the source.</typeparam>
        /// <param name="source">The source to paging.</param>
        /// <param name="pageIndex">The index of the page.</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <param name="cancellationToken">
        ///     A <see cref="CancellationToken" /> to observe while waiting for the task to complete.
        /// </param>
        /// <param name="indexFrom">The start index value.</param>
        /// <returns>An instance of the inherited from <see cref="IPagedList{T}" /> interface.</returns>
        public static async Task<PagedResponse<IReadOnlyList<T>>> ToPagedListAsync<T>(this IQueryable<T> source, int pageIndex,
            int pageSize, int indexFrom = 0, CancellationToken cancellationToken = default)
        {
            if (indexFrom > pageIndex)
            {
                throw new ArgumentException(
                    $"indexFrom: {indexFrom} > pageIndex: {pageIndex}, must indexFrom <= pageIndex");
            }

            var count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
            var items =  await source
                               .Skip((pageIndex) * pageSize)
                               .Take(pageSize)
                               .ToListAsync(); ;

            var pagedList = new PagedResponse<IReadOnlyList<T>>
            (
                data: items,
                pageNumber: pageIndex,
                pageSize: pageSize,
                totalPages: (int)Math.Ceiling(count / (double)pageSize),
                totalRecords: count
            );

            return pagedList;
        }
    }
}