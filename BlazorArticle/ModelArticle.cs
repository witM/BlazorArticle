using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorArticle
{
    /// <summary>
    /// The base class of article model that implements IArticle interface
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public class ModelArticleBase_<TId> : IArticle<TId>
    {
        public TId Id { get; set; }

        public string? Name { get; set; }

        public string? Content { get; set; }

    }

    /// <summary>
    /// The base class of article model.
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public class ModelArticleBase<TId> : ModelArticleBase_<TId>
    {
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string? Title { get; set; } = string.Empty;
    }
}
