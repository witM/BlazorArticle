using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorArticle
{
    public class ModelArticleBase_<TId> : IArticle<TId>
    {
        public TId Id { get; set; }

        public string? Name { get; set; }

        public string? Content { get; set; }

    }
}
