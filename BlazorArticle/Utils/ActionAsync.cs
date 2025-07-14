using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorArticle.Utils
{
    /// <summary>
    /// Delegate which representing asynchronous action.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="model">TModel object.</param>
    /// <returns>returns a Task </returns>
    public delegate Task ActionAsync<TModel>(TModel model);

}
