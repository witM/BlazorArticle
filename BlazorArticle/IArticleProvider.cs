using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorArticle
{
    /// <summary>
    /// Base interface of the article provider.
    /// </summary>
    /// <typeparam name="Id"></typeparam>
    /// <typeparam name="TModel">Inherits from IArticle</typeparam>
    public interface IArticleProvider<TModel, Id> where TModel : IArticle<Id>
    {
        /// <summary>
        /// Get the IArticle by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TModel> GetArticleAsync(Id id);

        /// <summary>
        /// Get the IArticle by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<TModel> GetArticleByNameAsync(string name);
    }
}
