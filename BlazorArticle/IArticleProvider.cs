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
        /// Get the article by Id.
        /// </summary>
        /// <param name="id">Id of the article</param>
        /// <returns></returns>
        Task<TModel?> GetArticleAsync(Id id);

        /// <summary>
        /// Get the article by name.
        /// </summary>
        /// <param name="name">Name of the article</param>
        /// <returns></returns>
        Task<TModel?> GetArticleByNameAsync(string name);
    }


    /// <summary>
    /// Extended interface of article provider with version checking.
    /// </summary>
    /// <typeparam name="Id"></typeparam>
    /// <typeparam name="TModel">Inherits from IArticle</typeparam>
    /// <typeparam name="TVersion">Version type of the article</typeparam>
    public interface IArticleProviderVersion<TModel, Id, TVersion> : IArticleProvider<TModel, Id> where TModel: IArticle<Id>
    {
        /// <summary>
        /// Get the article by name with given version of the article.
        /// </summary>
        /// <param name="name">Name of the article</param>
        /// <param name="version">Version of the article</param>
        Task<TModel?> GetArticleByNameAsync(string name, TVersion version);
    }

    /// <summary>
    /// Base interface of the file article provider.
    /// </summary>
    /// <typeparam name="TModel">Inherits from IArticle</typeparam>
    /// <typeparam name="Id"></typeparam>
    public interface IFileArticleProvider<TModel, Id> where TModel: IArticle<Id>
    {
        /// <summary>
        /// Get the article by given file path.
        /// </summary>
        /// <param name="path">Path to the article. Relative or absolute.</param>
        /// <returns></returns>
        Task<TModel> GetArticleByPathAsync(string path);
    }

}
