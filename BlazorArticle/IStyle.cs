using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorArticle
{
    /// <summary>
    /// Base Interface supporting the style model. Contains only: Id, Name, Content. The interface is used by BlazorArticle.Component library.
    /// For the purpose of quickly changing styles while presenting the article to the user (e.g., applying a dark theme), there should be a simple entity that implements this interface to load the appropriate style content and refresh it in the browser. Additionally, there may be other systems and entities, for example, for grouping styles.
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IStyle<TId>
    {
        /// <summary>
        /// Unique style Id
        /// </summary>
        TId Id { get; }

        /// <summary>
        /// Style name. Should be unique but can be empty.
        /// </summary>
        string? Name { get; }

        //DateTime DateCreated { get; }
        //DateTime DateModified { get; }

        /// <summary>
        /// Content of the style.
        /// </summary>
        string? Content { get; }
    }
}
