using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorArticle
{

    public abstract record ArticleFragment;
    public record HtmlFragment(string Html) : ArticleFragment;
    public record ComponentFragment(Type type, Dictionary<string, object> parameters) : ArticleFragment;


    public interface IParserArticle
    {
        List<ArticleFragment> Parse(string content, bool removedComments);

        string ParseStyle(string css, bool isCompressed);
        //void RegisterComponentParser(IParserMarker parser);
    }
}
