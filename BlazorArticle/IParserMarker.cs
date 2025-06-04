using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazorArticle
{





    internal interface IParserMarker
    {
        string MarkerName { get; } // np. "YouTube"
        Regex Pattern { get; }
        bool TryParse(Match match, out ComponentFragment? fragment);
    }
}
