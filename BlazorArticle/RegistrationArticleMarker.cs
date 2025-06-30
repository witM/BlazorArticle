using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlazorArticle;

namespace BlazorArticle.Components
{
    public class RegistrationArticleMarker
    {
        readonly IParserArticle _parser = null;
        public RegistrationArticleMarker(IParserArticle parser)
        {
            _parser = parser;
            //
            //parser.RegisterComponentParser(new AlertCounter_ParserMarker());

        }

        public void RegisterMarker(IParserMarker marker)
        {
            _parser.RegisterComponentParser(marker);
        }
    }
}
