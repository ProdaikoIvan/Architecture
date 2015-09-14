using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Extensions.WebExtensions
{
    public static class SelectListExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> items, Func<T, string> text,
            Func<T, string> value = null, Func<T, bool> selected = null)
        {
            return items.Select(country => new SelectListItem
            {
                Value = (value == null ? text.Invoke(country) : value.Invoke(country)),
                Text = text.Invoke(country)
            }).ToList();
        }
    }
}