using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ElectronicCars.Core.Models;
using System.Globalization;
namespace ElectronicCars.Extensions
{
    public static class IQueryableExtensions
    {

        public static IQueryable<Sale> ApplyFiltering(this IQueryable<Sale> query, SaleQuery queryObj)
        {
            if (queryObj.Locations.FirstOrDefault() != null)
                query = query.Where(v => queryObj.Locations.Contains(v.SalesLocation));

            if (queryObj.Months.FirstOrDefault() != null)
                query = query.Where(v => v.LastUpdate != null && queryObj.Months.Contains(new SaleQueryMonths() { Month = v.LastUpdate.Month, Year = v.LastUpdate.Year }));


            return query;
        }

        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObj, Dictionary<string, Expression<Func<T, object>>> columnsMap)
        {
            if (String.IsNullOrWhiteSpace(queryObj.SortBy) || !columnsMap.ContainsKey(queryObj.SortBy))
                return query;

            if (queryObj.IsSortAscending)
                return query.OrderBy(columnsMap[queryObj.SortBy]);
            else
                return query.OrderByDescending(columnsMap[queryObj.SortBy]);
        }


        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            if (queryObj.Page <= 0)
                queryObj.Page = 1;

            if (queryObj.PageSize <= 0)
                queryObj.PageSize = 10;

            return query.Skip((queryObj.Page - 1) * queryObj.PageSize).Take(queryObj.PageSize);
        }
    }
    static class DateTimeExtensions
    {
        public static string ToMonthName(this DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month);
        }

        public static string ToShortMonthName(this DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month);
        }
    }
}