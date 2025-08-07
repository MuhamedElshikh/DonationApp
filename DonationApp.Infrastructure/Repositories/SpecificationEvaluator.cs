using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.Applications.Interfaces;
using DonationApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DonationApp.Infrastructure.Repositories
{
    static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> GetQuery<TEntity, TKey>(IQueryable<TEntity> inputQuery, ISpecifications<TEntity, TKey> specifications)
            where TEntity : BaseEntity<TKey>
        {
            var query = inputQuery;
            if (specifications.Criteria is not null)
                query = query.Where(specifications.Criteria);

            if (specifications.OrderBy is not null)
                query = query.OrderBy(specifications.OrderBy);
            else if (specifications.OrderByDescending is not null)
                query = query.OrderByDescending(specifications.OrderByDescending);

            if (specifications.IsPagination)
                query = query.Skip(specifications.Skip).Take(specifications.Take);


            query = specifications.IncludeExpressions.Aggregate(query, (curruntQuery, includeExpression) =>
            curruntQuery.Include(includeExpression));

            return query;
        }
    }
}
