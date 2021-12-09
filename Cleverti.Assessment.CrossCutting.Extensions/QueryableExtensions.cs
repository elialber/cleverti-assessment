using Cleverti.Assessment.CrossCutting.Extensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cleverti.Assessment.CrossCutting.Extensions
{
    public static class QueryableExtensions
    {
        public static Page<T> ToPaginate<T>(this IQueryable<T> query, int currentPage, int totalPerPage) where T : class
        {
            var resultado = new Page<T>
            {
                CurrentPage = currentPage,
                TotalPerPage = totalPerPage,
                TotalItems = query.Count()
            };

            var totalPaginas = (double)resultado.TotalItems / totalPerPage;
            resultado.TotalPage = (int)Math.Ceiling(totalPaginas);

            var skip = (currentPage - 1) * totalPerPage;

            resultado.Result = query.Skip(skip).Take(totalPerPage).ToList();

            return resultado;
        }

        public static Page<T> ToPaginate<T>(this IEnumerable<T> query, int currentPage, int totalPerPage) where T : class
        {
            var resultado = new Page<T>
            {
                CurrentPage = currentPage,
                TotalPerPage = totalPerPage,
                TotalItems = Convert.ToInt64(query.Count())
            };

            var totalPaginas = (double)resultado.TotalItems / totalPerPage;
            resultado.TotalPage = (int)Math.Ceiling(totalPaginas);

            var skip = (currentPage - 1) * totalPerPage;

            resultado.Result = query.Skip(skip).Take(totalPerPage).ToList();

            return resultado;
        }
    }
}
