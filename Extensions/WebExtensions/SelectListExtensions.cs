using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Extensions.WebExtensions
{
    public static class SelectListExtensions
    {
        public async static Task<List<SelectListItem>> ToSelectListAsync<TEntity>(this IEnumerable<TEntity> items, Func<TEntity, string> text,
        Func<TEntity, string> value = null, Func<TEntity, bool> selected = null)
        {
            return await Task.Run(() => items.Select(country => new SelectListItem
            {
                Value = (value == null ? text.Invoke(country) : value.Invoke(country)),
                Text = text.Invoke(country)
            }).ToList());
        }
    }
}