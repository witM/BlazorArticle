using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorArticle
{
    /// <summary>
    /// The base class of article style that implements IStyle interface
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public class ModelStyleBase<TId> : IStyle<TId> 
    {
        public TId Id { get; set; }
        public string? Name { get; set; }
        public string? Content { get; set; }
    }
}
