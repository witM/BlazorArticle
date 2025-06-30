using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlazorArticle;
using BlazorArticle.Components.ArticleComponents;

namespace BlazorArticle.Components
{
    public class RegistrationArticleMarker
    {
        readonly IParserArticle _parser = null;
        public RegistrationArticleMarker(IParserArticle parser)
        {
            _parser = parser;
            //
            parser.RegisterComponentParser(new AlertCounter_ParserMarker());

        }

      
    }
}
