using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorArticle
{
    /// <summary>
    /// Base interface of article style provider
    /// </summary>
    /// <typeparam name="TId">Id of the Style</typeparam>
    /// <typeparam name="TModel">inherits from IStyle</typeparam>
    /// 
    public interface IArticleStyleProvider<TModel, TId> where TModel : IStyle<TId>
    {
        /// <summary>
        /// Get style by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TModel> GetStyleAsync(TId id);

        /// <summary>
        /// Get style by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<TModel> GetStyleByNameAsync(string name);
    }
}
