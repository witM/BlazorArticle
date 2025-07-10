using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorArticle
{

    /// <summary>
    /// Article content is fragmented to the two parts. This is the base Article fragment record.
    /// </summary>
    public abstract record ArticleFragment;

    /// <summary>
    /// Fragment representing html content.
    /// </summary>
    /// <param name="Html"></param>
    public record HtmlFragment(string Html) : ArticleFragment;

    /// <summary>
    /// Fragment representing dynamic component content.
    /// </summary>
    /// <param name="type">A Type of the component.</param>
    /// <param name="parameters">Parameters of the component. "string" is parameter name and "object" is parameter value.</param>
    public record ComponentFragment(Type type, Dictionary<string, object> parameters) : ArticleFragment;


    /// <summary>
    /// Base interface of an article parser.
    /// </summary>
    public interface IParserArticle
    {
        /// <summary>
        /// Parses the article content.
        /// </summary>
        /// <param name="content">Article content.</param>
        /// <param name="removedComments">Determines whether to remove comments from the source of the rendered article.</param>
        /// <returns>A list of render fragments to be rendered.</returns>
        List<ArticleFragment> Parse(string content, bool removedComments);

        /// <summary>
        /// Registers a marker parser that will be used to render a text marker as a component render fragment.
        /// </summary>
        /// <param name="marker"></param>
        void RegisterComponentParser(IParserMarker marker);


    }

}
