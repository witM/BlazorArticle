using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorArticle
{
    /// <summary>
    /// Base Interface supporting the article model. The interface is used by BlazorArticle.Component library.
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IArticle<TId>
    {
        /// <summary>
        /// Unique article Id
        /// </summary>
        TId Id { get; }

        /// <summary>
        /// Article name. Should be unique but can be empty.
        /// </summary>
        string? Name {  get; }

        //DateTime DateCreated { get; }
        //DateTime DateModified { get; }

        /// <summary>
        /// Content of the article.
        /// </summary>
        string? Content { get; }
    }

}
